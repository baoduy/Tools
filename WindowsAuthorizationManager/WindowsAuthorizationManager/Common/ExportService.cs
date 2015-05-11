using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Schroders.Framework.Log;

namespace WindowsAuthorizationManager.Common
{
    public class ExportService : IDisposable
    {
        public string CurrentApplication { get; private set; }

        private string exportMessageStatus;
        public string ExportMessageStatus
        {
            get { return exportMessageStatus; }
            private set
            {
                exportMessageStatus = value;
                Thread.Sleep(5);
            }
        }

        public string ErrorMessage { get; private set; }
        public ExportType ExportType { get; set; }
        public IList<string> ExportedFiles { get; private set; }

        private ExportStatus _ExportStatus = ExportStatus.Stoped;
        public ExportStatus ExportStatus
        {
            get { return _ExportStatus; }
            private set
            {

                if (this._ExportStatus != value)
                {
                    _ExportStatus = value;
                    this.OnExportStatusChanged(EventArgs.Empty);
                }
            }
        }

        private string[] Applications { get; set; }
        private AzManService AzMan { get; set; }
        private string PrefixFileName { get; set; }
        private string SubfixFileName { get; set; }
        private Thread CurrentThread { get; set; }

        public event EventHandler ExportStatusChanged;
        protected virtual void OnExportStatusChanged(EventArgs e)
        {
            if (this.ExportStatusChanged != null)
            { this.ExportStatusChanged(this, e); }
        }

        public ExportService(AzManService azMan, string prefixFileName, string subfixFileName, params string[] applications)
        {
            this.AzMan = azMan;
            this.Applications = applications;
            this.ExportStatus = Common.ExportStatus.Stoped;
            this.ExportType = Common.ExportType.ScopeGroupUser;
            this.PrefixFileName = prefixFileName;
            this.SubfixFileName = subfixFileName;
            this.ExportedFiles = new List<string>();
        }

        internal void Start()
        {
            this.DisposeCurrentThread();
            this.CurrentThread = new Thread(() =>
            {
                try
                {
                    this.ExportStatus = Common.ExportStatus.Running;

                    foreach (var app in this.Applications)
                    {
                        this.CurrentApplication = app;

                        bool hasData = false;
                        var fileName = string.Format("{0}_{1}_{2}_{3}.csv", this.PrefixFileName, app, this.ExportType, this.SubfixFileName);

                        if (System.IO.File.Exists(fileName))
                            System.IO.File.Delete(fileName);

                        using (var file = new System.IO.StreamWriter(fileName))
                        {
                            //Get AppInfo
                            this.ExportMessageStatus = "Get infomation from AzMan";
                            var appInfo = this.AzMan.GetAppInfo(app);

                            switch (this.ExportType)
                            {
                                case ExportType.ScopeGroupUser:
                                    {
                                        file.WriteLine("Scope,Group,User");

                                        foreach (var s in appInfo.Scopes)
                                            foreach (var g in s.Groups)
                                                foreach (var u in g.Users)
                                                {
                                                    this.ExportMessageStatus = string.Format("Export {0} to file '{1}' ...", u.Name, fileName);
                                                    file.WriteLine("{0},{1},{2}", s.Name, g.Name, u.Name);
                                                    hasData = true;
                                                }

                                    } break;
                                case Common.ExportType.UserGroupScope:
                                    {
                                        file.WriteLine("User,Group,Scope");

                                        this.ExportMessageStatus = string.Format("Exporting... Consolidate information from AzMan...");
                                        var users = from s in appInfo.Scopes
                                                    from g in s.Groups
                                                    from u in g.Users
                                                    orderby u.Name
                                                    select u;

                                        foreach (var u in users.Where(t => t.Name.ToUpper().StartsWith("SCHRODERSAD")))
                                        {
                                            this.ExportMessageStatus = string.Format("Export {0} to file '{1}' ...", u.Name, fileName);
                                            file.WriteLine("{0},{1},{2}", u.Name, u.Parent.Name, u.Parent.Parent.Name);
                                            hasData = true;
                                        }
                                    } break;
                                case Common.ExportType.ScopeRoleUser:
                                    {
                                        file.WriteLine("Scope,Rolse Assignment,User");

                                        foreach (var s in appInfo.Scopes)
                                            foreach (var r in s.Roles)
                                                foreach (var u in r.Users.Where(t => t.Name.ToUpper().StartsWith("SCHRODERSAD")))
                                                {
                                                    this.ExportMessageStatus = string.Format("Export {0} to file '{1}' ...", u.Name, fileName);
                                                    file.WriteLine("{0},{1},{2}", s.Name, r.Name, u.Name);
                                                    hasData = true;
                                                }
                                    } break;
                                case Common.ExportType.UserRoleScope:
                                    {
                                        this.ExportMessageStatus = string.Format("Exporting... Consolidate information from AzMan...");
                                        file.WriteLine("User,Rolse Assignment,Scope");

                                        var users = from s in appInfo.Scopes
                                                    from r in s.Roles
                                                    from u in r.Users
                                                    orderby u.Name
                                                    select u;

                                        foreach (var u in users.Where(t => t.Name.ToUpper().StartsWith("SCHRODERSAD")))
                                        {
                                            this.ExportMessageStatus = string.Format("Export {0} to file '{1}' ...", u.Name, fileName);
                                            file.WriteLine("{0},{1},{2}", u.Name, u.Parent.Name, u.Parent.Parent.Name);
                                            hasData = true;
                                        }
                                    } break;
                                case Common.ExportType.UserScopeGroupRole:
                                    {
                                        file.WriteLine("User,Scope,Groups,Role Assignments");

                                        this.ExportMessageStatus = string.Format("Consolidate information from AzMan...");

                                        var users = (from s in appInfo.Scopes
                                                     from g in s.Groups
                                                     from r in s.Roles
                                                     from ug in g.Users
                                                     from ur in r.Users
                                                     where ug.Name == ur.Name
                                                     select new
                                                     {
                                                         Name = ur.Name,
                                                         Scope = s.Name,
                                                         Group = ug.Parent.Name,
                                                         Role = ur.Parent.Name
                                                     }).ToList();

                                        foreach (var u in users.Where(t => t.Name.ToUpper().StartsWith("SCHRODERSAD")).OrderBy(t => t.Name).OrderBy(t => t.Scope))
                                        {
                                            this.ExportMessageStatus = string.Format("Export {0} to file '{1}' ...", u.Name, fileName);
                                            file.WriteLine(string.Format("{0},{1},{2},{3}", u.Name, u.Scope, u.Group, u.Role));
                                            hasData = true;
                                        }
                                    } break;
                                case ExportType.RoleAssignments:
                                    {
                                        file.WriteLine("Role Assignments,Operation");

                                        foreach (var role in appInfo.RoleAssigments)
                                            foreach (var opName in role.Operations)
                                            {
                                                this.ExportMessageStatus = string.Format("Export {0} to file '{1}' ...", role.Name, fileName);
                                                file.WriteLine(string.Format("{0},{1}", role.Name, opName));
                                                hasData = true;
                                            }
                                    } break;

                            }

                            if (hasData)
                                this.ExportedFiles.Add(fileName);
                            else if (System.IO.File.Exists(fileName))
                                System.IO.File.Delete(fileName);

                            //Close AppInfo
                            this.AzMan.CloseApplication(appInfo);
                        }
                    }

                    this.ExportMessageStatus = "Completed.";
                    this.ExportStatus = Common.ExportStatus.Finished;
                }
                catch (Exception ex)
                {
                    this.ExportStatus = Common.ExportStatus.Error;
                    this.ErrorMessage = ex.Message;
                    var log = LogManager.GetLogger();
                    if (log != null)
                        log.WriteError(ex);
                }
            }) { IsBackground = true };

            this.CurrentThread.Start();
        }

        public void Dispose()
        {
            DisposeCurrentThread();
        }

        private void DisposeCurrentThread()
        {
            if (this.CurrentThread != null
                && this.CurrentThread.IsAlive)
                this.CurrentThread.Abort();
        }
    }

    public enum ExportStatus
    {
        Running,
        Stoped,
        Finished,
        Error,
    }

    public enum ExportType
    {
        RoleAssignments,
        ScopeGroupUser,
        UserGroupScope,
        ScopeRoleUser,
        UserRoleScope,
        UserScopeGroupRole,
    }
}
