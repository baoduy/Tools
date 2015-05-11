using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsAuthorizationManager.Properties;
using WindowsAuthorizationManager.Common;
using WindowsAuthorizationManager.Entities;

namespace WindowsAuthorizationManager
{
    public partial class Main : Form
    {
        const string Add_Edit_Environment = "Add_Edit_Environment";

        private EnvironmentEntity CurrecntEnvironmentEntity { get; set; }

        private AzManService AzManService { get; set; }

        private ExportService ExportService { get; set; }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (this.ExportService != null)
                this.ExportService.Dispose();

            if (this.AzManService != null)
                this.AzManService.Dispose();

            System.Environment.Exit(0);
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.LoadMenu();
        }

        protected void LoadMenu()
        {
            this.menu_Environment.DropDownItems.Clear();

            foreach (var item in Helper.GetConfigurationFromFile(Settings.Default.ConfigurationFile))
            {
                this.menu_Environment.DropDownItems.Add(new CustomToolStripItem() { Text = item.EnvironmentName, Value = item, ToolTipText = item.ConnectionString });
            }

            this.menu_Environment.DropDownItems.Add(new ToolStripSeparator());
            this.menu_Environment.DropDownItems.Add(new CustomToolStripItem() { Text = "Add/Edit Environment", Value = Add_Edit_Environment });
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem is CustomToolStripItem)
            {
                var value = ((CustomToolStripItem)e.ClickedItem).Value;
                if (value is EnvironmentEntity)
                {
                    this.CurrecntEnvironmentEntity = (EnvironmentEntity)value;
                    this.AzManService = null;
                    this.menu_SelectedConnectionString.Text = string.Format("{0} - {1}", this.CurrecntEnvironmentEntity.EnvironmentName, this.CurrecntEnvironmentEntity.ConnectionString);
                    this.btn_Export.Enabled = !string.IsNullOrEmpty(this.CurrecntEnvironmentEntity.ConnectionString);
                }
                else switch (value.ToString())
                    {
                        case Add_Edit_Environment:
                            {
                                using (var addEvn = new AddEditEnvironment())
                                {
                                    if (addEvn.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                                        this.LoadMenu();
                                }
                            } break;
                        default: { } break;
                    }
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.data_AppNames.Text))
            {
                MessageBox.Show("Please specify the Application Name!", "Application Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.data_AppNames.Focus();
                return;
            }

            this.ControlIsEnabled(false);

            if (this.AzManService == null)
            {
                this.AzManService = new AzManService(this.CurrecntEnvironmentEntity.ConnectionString);
                this.btn_Reload.Enabled = true;
            }

            var applications = this.data_AppNames.Text.ToUpper();
            this.data_AppNames.Text = applications;

            this.ExportService = new ExportService(
                this.AzManService,
                this.CurrecntEnvironmentEntity.EnvironmentName,
                string.Format("{0:yyyyMMMddhhmmss}", DateTime.Now),
                applications.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries));

            if (this.op_RolesInApp.Checked)
                this.ExportService.ExportType = ExportType.RoleAssignments;
            if (op_ScopeGroupUser.Checked)
                this.ExportService.ExportType = ExportType.ScopeGroupUser;
            if (op_UserGroupScope.Checked)
                this.ExportService.ExportType = ExportType.UserGroupScope;
            if (op_ScopeRoleUser.Checked)
                this.ExportService.ExportType = ExportType.ScopeRoleUser;
            if (op_UserRoleScope.Checked)
                this.ExportService.ExportType = ExportType.UserRoleScope;
            if (this.op_UserScopeGroupRole.Checked)
                this.ExportService.ExportType = ExportType.UserScopeGroupRole;

            this.ExportService.ExportStatusChanged += (s, ev) => this.ExportCompleted();
            this.ExportService.Start();
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ExportService.ErrorMessage))
            {
                this.ExportCompleted();
            }
            else this.menu_Status.Text = string.Format("Current App: {0}, Status: {1}", this.ExportService.CurrentApplication, this.ExportService.ExportMessageStatus);
        }

        private void ExportCompleted()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.ExportCompleted));
                return;
            }

            if (this.ExportService.ExportStatus == ExportStatus.Finished
                || this.ExportService.ExportStatus == ExportStatus.Error)
            {
                this.ControlIsEnabled(true);
                this.timer1.Enabled = false;

                if (string.IsNullOrEmpty(this.ExportService.ErrorMessage))
                {
                    MessageBox.Show(string.Format("{0} has been exported", this.data_AppNames.Text), "Exported File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(Application.StartupPath);
 
                }
                else MessageBox.Show(this.ExportService.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ControlIsEnabled(bool enabled)
        {
            this.btn_Export.Enabled = enabled;
            this.data_AppNames.Enabled = enabled;
            this.groupOption.Enabled = enabled;
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            this.AzManService.Reload();
        }
    }
}
