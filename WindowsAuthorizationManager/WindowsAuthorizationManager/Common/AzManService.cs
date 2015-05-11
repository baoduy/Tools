using System.Collections.Generic;
using System.Configuration;
using System.Security.Principal;
using AZROLESLib;
using System;
using System.IO;
using Schroders.Framework.Log;

namespace WindowsAuthorizationManager.Common
{
    /// <summary>
    /// This class provides services for AzMan role & scope functions
    /// </summary>
    public class AzManService:IDisposable
    {
        public string ConnectionString { get; set; }

        public AzManService(string connectionString)
        {
            this.ConnectionString = connectionString;
            _azManStore = null;
        }

        #region Variables & Properties
        //implement singleton pattern to manage AzAuthorizationStoreClass
        static AzAuthorizationStoreClass _azManStore = null;
        protected AzAuthorizationStoreClass azManStore
        {
            get
            {
                if (_azManStore == null)
                {
                    _azManStore = GetNewAzAuthorizationStoreClass();
                }

                return _azManStore;
            }
        }

        #endregion

        #region Initialization

        public AzManService() { }

        #endregion

        #region Helper Functions

        protected bool CaseInsensitiveCompare(string username1, string username2)
        {
            if ((username1 == null) || (username2 == null)) return false;

            return username1.ToUpper().Equals(username2.ToUpper());
        }

        public string ConvertToUsername(object SID)
        {
            if (SID is string)
            {
                SecurityIdentifier si = new SecurityIdentifier(SID as string);
                string account;
                try
                {
                    account = si.Translate(typeof(NTAccount)).ToString();
                }
                catch
                {
                    account = SID as string;
                }
                return account;
            }
            else
            {
                return string.Empty;
            }
        }

        protected bool CanAccessOperation(IAzApplication azApplication, string applicationName, string entity, string[] roles, int operationID, string username)
        {
            IAzClientContext clientContext;

            try
            {
                clientContext = azApplication.InitializeClientContextFromName(username, null, null);
            }
            catch
            {
                return false;
            }

            object[] operationIds = new object[] { operationID };
            object[] scopes = { entity };

            foreach (string role in roles)
            {
                object[] result = (object[])clientContext.AccessCheck(role,
                      scopes, operationIds, null, null, null, null, null);

                int accessAllowed = (int)result[0];
                if (accessAllowed == 0)
                {
                    // current user authorized to perform operation
                    return true;
                }
            }

            // current user NOT authorized to perform operation
            return false;
        }

        private string[] GetUsersInScope(string applicationName, string scopeName)
        {
            List<string> usersInScope = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication != null)
                {
                    // Get all matched users in matched scope roles
                    foreach (IAzScope azScope in azApplication.Scopes)
                    {
                        if (scopeName.Equals(azScope.Name, StringComparison.InvariantCultureIgnoreCase))
                        {
                            foreach (IAzRole azRole in azScope.Roles)
                            {
                                foreach (object member in (object[])azRole.Members)
                                {
                                    string domainUsername = ConvertToUsername(member);
                                    if (!usersInScope.Contains(domainUsername))
                                        usersInScope.Add(domainUsername);
                                }
                            }
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetUsersInScope(applicationName, scopeName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usersInScope.ToArray();
        }

        private string[] GetUsersInScope(IAzScope azScope)
        {
            List<string> usersInScope = new List<string>();

            foreach (IAzRole azRole in azScope.Roles)
            {
                foreach (object member in (object[])azRole.Members)
                {
                    string domainUsername = ConvertToUsername(member);
                    if (!usersInScope.Contains(domainUsername))
                        usersInScope.Add(domainUsername);
                }
            }

            return usersInScope.ToArray();
        }

        #endregion

        #region Role Provider Functions

        public IList<string> GetRolesForUser(string applicationName, string username)
        {
            List<string> rolesOfUser = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Get all application roles of the user
                foreach (IAzRole azRole in azApplication.Roles)
                {
                    foreach (object member in (object[])azRole.Members)
                    {
                        if (CaseInsensitiveCompare(username, ConvertToUsername(member)))
                        {
                            if (!rolesOfUser.Contains(azRole.Name))
                                rolesOfUser.Add(azRole.Name);
                        }
                    }
                }

                // Get all scope roles of the user
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    foreach (IAzRole azRole in azScope.Roles)
                    {
                        foreach (object member in (object[])azRole.Members)
                        {
                            if (CaseInsensitiveCompare(username, ConvertToUsername(member)))
                            {
                                if (!rolesOfUser.Contains(azRole.Name))
                                    rolesOfUser.Add(azRole.Name);
                            }
                        }
                    }
                }

            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetRolesForUser(applicationName, username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rolesOfUser;
        }

        public bool IsUserInRole(string applicationName, string username, string roleName)
        {
            var roles = GetRolesForUser(applicationName, username);
            return string.Join(":", roles).Contains(roleName);
        }

        public string[] GetAllRoles(string applicationName)
        {
            List<string> roles = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Get all application roles
                foreach (IAzRole azRole in azApplication.Roles)
                {
                    if (!roles.Contains(azRole.Name))
                        roles.Add(azRole.Name);
                }

                // Get all scope roles
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    foreach (IAzRole azRole in azScope.Roles)
                    {
                        if (!roles.Contains(azRole.Name))
                            roles.Add(azRole.Name);
                    }
                }

            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetAllRoles(applicationName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return roles.ToArray();
        }

        public bool RoleExists(string applicationName, string roleName)
        {
            return String.Join(string.Empty, GetAllRoles(applicationName)).Contains(roleName);
        }

        public string[] GetUsersInRole(string applicationName, string roleName)
        {
            List<string> usersInRole = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Get all users in matched application roles
                foreach (IAzRole azRole in azApplication.Roles)
                {
                    if (azRole.Name == roleName)
                    {
                        foreach (object member in (object[])azRole.Members)
                        {
                            string domainUsername = ConvertToUsername(member);
                            if (!usersInRole.Contains(domainUsername))
                                usersInRole.Add(domainUsername);
                        }
                    }
                }

                // Get all users in matched scope roles
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    foreach (IAzRole azRole in azScope.Roles)
                    {
                        if (azRole.Name == roleName)
                        {
                            foreach (object member in (object[])azRole.Members)
                            {
                                string domainUsername = ConvertToUsername(member);
                                if (!usersInRole.Contains(domainUsername))
                                    usersInRole.Add(domainUsername);
                            }
                        }
                    }
                }

            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetUsersInRole(applicationName, roleName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usersInRole.ToArray();
        }

        public string[] GetUsersInRole(string applicationName, string scopeName, string roleName)
        {
            List<string> usersInRole = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Get all users in matched scope roles
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    if (azScope.Name == scopeName)
                    {
                        foreach (IAzRole azRole in azScope.Roles)
                        {
                            if (azRole.Name == roleName)
                            {
                                foreach (object member in (object[])azRole.Members)
                                {
                                    string domainUsername = ConvertToUsername(member);
                                    if (!usersInRole.Contains(domainUsername))
                                        usersInRole.Add(domainUsername);
                                }
                                break;
                            }
                        }
                        break;
                    }
                }

            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetUsersInRole(applicationName, scopeName, roleName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usersInRole.ToArray();
        }

        public string[] FindUsersInRole(string applicationName, string roleName, string usernameToMatch)
        {
            List<string> usersInRole = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Get all matched users in matched application roles
                foreach (IAzRole azRole in azApplication.Roles)
                {
                    if (azRole.Name == roleName)
                    {
                        foreach (object member in (object[])azRole.Members)
                        {
                            string domainUsername = ConvertToUsername(member);
                            if (domainUsername.ToUpper().IndexOf(usernameToMatch.ToUpper()) >= 0)
                            {
                                if (!usersInRole.Contains(domainUsername))
                                    usersInRole.Add(domainUsername);
                            }
                        }
                    }
                }

                // Get all matched users in matched scope roles
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    foreach (IAzRole azRole in azScope.Roles)
                    {
                        if (azRole.Name == roleName)
                        {
                            foreach (object member in (object[])azRole.Members)
                            {
                                string domainUsername = ConvertToUsername(member);
                                if (domainUsername.ToUpper().IndexOf(usernameToMatch.ToUpper()) >= 0)
                                {
                                    if (!usersInRole.Contains(domainUsername))
                                        usersInRole.Add(domainUsername);
                                }
                            }
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.FindUsersInRole(applicationName, roleName, usernameToMatch);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usersInRole.ToArray();
        }

        #endregion

        #region Required Schroders Functions

        // - Does a USER has a ROLE in an APPLICATION and BELONG to an ENTITY associated with that application.
        public bool IsUserInScopeRole(string applicationName, string username, string roleName, string scopeName)
        {
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    if (azScope.Name == scopeName)
                    {
                        foreach (IAzRole azRole in azScope.Roles)
                        {
                            if (azRole.Name == roleName)
                            {
                                foreach (object member in (object[])azRole.Members)
                                {
                                    if (CaseInsensitiveCompare(username, ConvertToUsername(member))) return true;
                                }
                            }
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.IsUserInScopeRole(applicationName, username, roleName, scopeName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        // - Given a USER & a ROLE, find out all the ENTITY(s) that the user has.
        public string[] GetScopesForUserWithRole(string applicationName, string username, string roleName)
        {
            List<string> scopes = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    foreach (IAzRole azRole in azScope.Roles)
                    {
                        if (azRole.Name == roleName)
                        {
                            foreach (object member in (object[])azRole.Members)
                            {
                                if (CaseInsensitiveCompare(username, ConvertToUsername(member)))
                                {
                                    if (!scopes.Contains(azScope.Name))
                                        scopes.Add(azScope.Name);
                                }
                            }
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetScopesForUserWithRole(applicationName, username, roleName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return scopes.ToArray();
        }

        // - Does a USER has a ROLE in an APPLICATION
        // Use the IsUserInRole function of the RoleProvider

        #endregion

        #region Additional Scope Functions

        public IList<string> GetScopesForUser(string applicationName, string username)
        {
            List<string> scopes = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    foreach (IAzRole azRole in azScope.Roles)
                    {
                        foreach (object member in (object[])azRole.Members)
                        {
                            if (CaseInsensitiveCompare(username, ConvertToUsername(member)))
                            {
                                if (!scopes.Contains(azScope.Name))
                                    scopes.Add(azScope.Name);
                            }
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetScopesForUser(applicationName, username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return scopes;
        }

        public string[] GetAllScopes(string applicationName)
        {
            List<string> scopes = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    if (!scopes.Contains(azScope.Name))
                        scopes.Add(azScope.Name);
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetAllScopes(applicationName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return scopes.ToArray();
        }

        public string[] GetAllApplications()
        {
            List<string> apps = new List<string>();

            try
            {
                IAzApplications azApps = azManStore.Applications;

                foreach (IAzApplication azApp in azApps)
                {
                    if ((azApp.Name != "PAC") && !apps.Contains(azApp.Name))
                    {
                        apps.Add(azApp.Name);
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetAllApplications();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return apps.ToArray();
        }

        public IList<string> GetAllUsers(string applicationName)
        {
            List<string> users = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    foreach (IAzRole azRole in azScope.Roles)
                    {
                        foreach (object member in (object[])azRole.Members)
                        {
                            string domainUsername = ConvertToUsername(member);
                            if (!users.Contains(domainUsername))
                                users.Add(domainUsername);
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetAllUsers(applicationName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return users;
        }

        public string[] GetRolesInScope(string applicationName, string scopeName)
        {
            List<string> roles = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    if (scopeName.Equals(azScope.Name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        foreach (IAzRole azRole in azScope.Roles)
                        {
                            if (!roles.Contains(azRole.Name))
                                roles.Add(azRole.Name);
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetRolesInScope(applicationName, scopeName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return roles.ToArray();
        }

        #endregion

        #region Support Scope Functions For Policy Checking

        public string[] GetRolesAndScopeRolesForUser(string applicationName, string username)
        {
            List<string> rolesOfUser = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Get all application roles of the user
                foreach (IAzRole azRole in azApplication.Roles)
                {
                    foreach (object member in (object[])azRole.Members)
                    {
                        if (CaseInsensitiveCompare(username, ConvertToUsername(member)))
                        {
                            if (!rolesOfUser.Contains(azRole.Name))
                                rolesOfUser.Add(azRole.Name);
                        }
                    }
                }

                // Get all scope roles of the user
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    foreach (IAzRole azRole in azScope.Roles)
                    {
                        foreach (object member in (object[])azRole.Members)
                        {
                            if (CaseInsensitiveCompare(username, ConvertToUsername(member)))
                            {
                                if (!rolesOfUser.Contains(azRole.Name))
                                    rolesOfUser.Add(azRole.Name);

                                // Role with scope
                                if (!rolesOfUser.Contains(azRole.Name + "|" + azScope.Name))
                                    rolesOfUser.Add(azRole.Name + "|" + azScope.Name);
                            }
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetRolesAndScopeRolesForUser(applicationName, username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rolesOfUser.ToArray();
        }

        #endregion

        #region Operation methods

        public string[] GetOperationsForUser(string applicationName, string username)
        {
            List<string> operations = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                string[] roles;
                var scopes = GetScopesForUser(applicationName, username);

                // Assume Operation are define at the Application level only
                // i.e. no operationd defined in the Scope level.
                foreach (string scope in scopes)
                {
                    roles = GetRolesInScope(applicationName, scope);
                    foreach (IAzOperation azOperation in azApplication.Operations)
                    {
                        if (CanAccessOperation(azApplication, applicationName, scope, roles, azOperation.OperationID, username) &&
                            !operations.Contains(azOperation.Name))
                        {
                            operations.Add(azOperation.Name);
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetOperationsForUser(applicationName, username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return operations.ToArray();
        }

        public string[] GetOperationsForUser(string applicationName, string scopeName, string username)
        {
            List<string> operations = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Get all the roles for a entity. Todo: get all possible roles
                string[] roles = GetRolesInScope(applicationName, scopeName);

                // Assume Operation are define at the Application level only
                // i.e. no operationd defined in the Scope level.
                foreach (IAzOperation azOperation in azApplication.Operations)
                {
                    if (CanAccessOperation(azApplication, applicationName, scopeName, roles, azOperation.OperationID, username) &&
                        !operations.Contains(azOperation.Name))
                    {
                        operations.Add(azOperation.Name);
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetOperationsForUser(applicationName, scopeName, username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return operations.ToArray();
        }

        public bool IsUserInOperation(string applicationName, string scopeName, string operationName, string username)
        {
            List<string> operations = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Get all the roles for a entity. Todo: get all possible roles
                string[] roles = GetRolesInScope(applicationName, scopeName);

                // Assume Operation are define at the Application level only
                // i.e. no operation defined in the Scope level.
                foreach (IAzOperation azOperation in azApplication.Operations)
                {
                    if (azOperation.Name.Equals(operationName, StringComparison.InvariantCultureIgnoreCase) &&
                        CanAccessOperation(azApplication, applicationName, scopeName, roles, azOperation.OperationID, username))
                    {
                        return true;
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.IsUserInOperation(applicationName, scopeName, operationName, username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public bool IsUserInOperation(string applicationName, string operationName, string username)
        {
            string[] operations = GetOperationsForUser(applicationName, username);
            foreach (string operation in operations)
            {
                if (operation == operationName) return true;
            }

            return false;
        }

        public bool OperationExists(string applicationName, string operationName)
        {
            return String.Join(string.Empty, GetAllOperations(applicationName)).Contains(operationName);
        }

        public string[] GetUsersForOperation(string applicationName, string scopeName, string operationName)
        {
            List<string> usersInOperation = new List<string>();
            try
            {
                // Get all the roles and users for the given Scope.
                string[] roles = GetRolesInScope(applicationName, scopeName);
                string[] users = GetUsersInScope(applicationName, scopeName);

                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Assume Operation are define at the Application level only
                // i.e. no operation defined in the Scope level.
                foreach (IAzOperation azOperation in azApplication.Operations)
                {
                    if (azOperation.Name.Equals(operationName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        foreach (string user in users)
                        {
                            if (CanAccessOperation(azApplication, applicationName, scopeName, roles, azOperation.OperationID, user))
                            {
                                if (!usersInOperation.Contains(user))
                                {
                                    usersInOperation.Add(user);
                                }
                            }
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetUsersForOperation(applicationName, scopeName, operationName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usersInOperation.ToArray();
        }

        public string[] GetUsersForOperation(string applicationName,
          string scopeName, string operationName, string applicationGroupName)
        {
            List<string> usersInOperationApplicationGroup = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // 1. Get Users in Operation
                // 2. Get Users in ApplicationGroupName
                string[] usersInOperation = GetUsersForOperation(applicationName,
                    scopeName, operationName);
                string[] usersInApplicationGroup = GetUsersInApplicationGroup(applicationName,
                    scopeName, applicationGroupName);

                // Return the intersection of (1) and (2)
                foreach (string userInOperation in usersInOperation)
                {
                    foreach (string userInApplicationGroup in usersInApplicationGroup)
                    {
                        if (userInOperation.Equals(userInApplicationGroup, StringComparison.InvariantCultureIgnoreCase) &&
                            !usersInOperationApplicationGroup.Contains(userInOperation))
                        {
                            usersInOperationApplicationGroup.Add(userInOperation);
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetUsersForOperation(applicationName, scopeName, operationName, applicationGroupName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usersInOperationApplicationGroup.ToArray();
        }

        protected string[] GetUsersInApplicationGroup(string applicationName,
            string scopeName, string applicationGroupName)
        {
            List<string> usersInApplicationGroup = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Get all scope roles of the user
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    if (azScope.Name.Equals(scopeName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        foreach (IAzApplicationGroup applicationGroup in azScope.ApplicationGroups)
                        {
                            if (applicationGroup.Name.Equals(applicationGroupName, StringComparison.InvariantCultureIgnoreCase))
                            {
                                foreach (object member in (object[])applicationGroup.Members)
                                {
                                    string domainUsername = ConvertToUsername(member);

                                    if (!usersInApplicationGroup.Contains(domainUsername))
                                        usersInApplicationGroup.Add(domainUsername);
                                }
                            }
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetUsersInApplicationGroup(applicationName, scopeName, applicationGroupName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usersInApplicationGroup.ToArray();
        }

        public string[] GetUsersInApplicationGroups(string applicationName, string scopeName, params string[] applicationGroupNames)
        {
            List<string> usersInApplicationGroup = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Get all scope roles of the user
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    if (azScope.Name.Equals(scopeName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        foreach (IAzApplicationGroup applicationGroup in azScope.ApplicationGroups)
                        {
                            if (Array.Exists<string>(applicationGroupNames, delegate(string gname) { return gname.Equals(applicationGroup.Name, StringComparison.InvariantCultureIgnoreCase); }))
                            {
                                foreach (object member in (object[])applicationGroup.Members)
                                {
                                    string domainUsername = ConvertToUsername(member);

                                    if (!usersInApplicationGroup.Contains(domainUsername))
                                        usersInApplicationGroup.Add(domainUsername);
                                }
                            }
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetUsersInApplicationGroups(applicationName, scopeName, applicationGroupNames);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usersInApplicationGroup.ToArray();
        }

        public string[] GetAllOperations(string applicationName)
        {
            List<string> operations = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                foreach (IAzOperation azOp in azApplication.Operations)
                {
                    operations.Add(azOp.Name);
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetAllOperations(applicationName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return operations.ToArray();
        }

        public string[] GetUserApplicationGroups(string applicationName, string scopeName, string username)
        {
            List<string> userApplicationGroup = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Get all scope roles of the user
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    if (azScope.Name.Equals(scopeName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        foreach (IAzApplicationGroup applicationGroup in azScope.ApplicationGroups)
                        {
                            if (IsUserInMembers((object[])applicationGroup.Members, username) &&
                                !userApplicationGroup.Contains(applicationGroup.Name))
                            {
                                userApplicationGroup.Add(applicationGroup.Name);
                            }
                        }
                        break;
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetUserApplicationGroups(applicationName, scopeName, username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userApplicationGroup.ToArray();
        }

        public string[] GetUserApplicationGroupsInAllScopes(string applicationName, string username)
        {
            List<string> userApplicationGroup = new List<string>();
            try
            {
                IAzApplication azApplication = azManStore.OpenApplication(applicationName,
                                                                          null);
                if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));
                // Get all scope roles of the user
                foreach (IAzScope azScope in azApplication.Scopes)
                {
                    foreach (IAzApplicationGroup applicationGroup in azScope.ApplicationGroups)
                    {
                        if (IsUserInMembers((object[])applicationGroup.Members,
                                           username) &&
                           !userApplicationGroup.Contains(applicationGroup.Name))
                        {
                            userApplicationGroup.Add(applicationGroup.Name);
                        }
                    }
                }
            }
            //Duy.Hoang 03-April-2013: Fix Lost SQL Connection
            catch (System.Runtime.InteropServices.COMException ex)
            {
                if (ex.Message.StartsWith("Element"))
                {
                    throw ex;
                }
                var log = LogManager.GetLogger();
                if (log != null)
                    log.WriteError(ex);

                _azManStore = GetNewAzAuthorizationStoreClass();
                return this.GetUserApplicationGroupsInAllScopes(applicationName, username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userApplicationGroup.ToArray();
        }


        public string[] GetExclusiveUsersForOperation(string applicationName, string scopeName, string operationName, string username)
        {
            List<string> usersInOperationApplicationGroup = new List<string>();

            // Get the User Application Group, assume only 1 user has at most 1 group
            string[] applicationGroup = GetUserApplicationGroups(applicationName, scopeName, username);

            if (applicationGroup.Length == 0)
            {
                return usersInOperationApplicationGroup.ToArray();
                //throw new System.Security.SecurityException( "User " + userName +
                //    " has zero ApplicationGroup and a user must belong to exactly 1 ApplicationGroup. " );
            }
            else if (applicationGroup.Length > 1)
            {
                return usersInOperationApplicationGroup.ToArray();
                //throw new System.Security.SecurityException( "User " + userName +
                //    " belong to more than one ApplicationGroup: " +
                //    applicationGroup.ToString());
            }

            // GetUsersForOperation
            string[] users = GetUsersForOperation(applicationName, scopeName,
                operationName, applicationGroup[0]);

            // Filter out the username passed
            foreach (string user in users)
            {
                if (!user.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                {
                    usersInOperationApplicationGroup.Add(user);
                }
            }

            return usersInOperationApplicationGroup.ToArray();
        }

        public string[] GetNoneExclusiveUsersForOperation(string applicationName, string scopeName, string operationName, string username)
        {
            List<string> usersInOperationApplicationGroup = new List<string>();

            // Get the User Application Group, assume only 1 user has at most 1 group
            string[] applicationGroup = GetUserApplicationGroups(applicationName, scopeName, username);

            if (applicationGroup.Length == 0)
            {
                return usersInOperationApplicationGroup.ToArray();
                //throw new System.Security.SecurityException( "User " + userName +
                //    " has zero ApplicationGroup and a user must belong to exactly 1 ApplicationGroup. " );
            }
            else if (applicationGroup.Length > 1)
            {
                return usersInOperationApplicationGroup.ToArray();
                //throw new System.Security.SecurityException( "User " + userName +
                //    " belong to more than one ApplicationGroup: " +
                //    applicationGroup.ToString());
            }

            // GetUsersForOperation
            string[] users = GetUsersForOperation(applicationName, scopeName,
                operationName, applicationGroup[0]);

            // Filter out the username passed
            foreach (string user in users)
            {
                usersInOperationApplicationGroup.Add(user);
            }

            return usersInOperationApplicationGroup.ToArray();
        }

        public string[] GetExclusiveUsersForOperation(string applicationName, string applicationGroupName, string[] operationNames, string username)
        {
            List<string> usersInOperation = new List<string>();
            var scopes = GetScopesForUser(applicationName, username);
            foreach (string scopeName in scopes)
            {
                foreach (string operationName in operationNames)
                {
                    string[] users = GetUsersForOperation(applicationName, scopeName, operationName, applicationGroupName);
                    // Filter out the username passed
                    foreach (string user in users)
                    {
                        if (!user.Equals(username, StringComparison.InvariantCultureIgnoreCase))
                        {
                            usersInOperation.Add(user);
                        }
                    }
                }
            }

            return usersInOperation.ToArray();
        }

        #endregion

        #region FFX Methods

        /// <summary>
        /// Groups users in same group
        /// </summary>
        /// <param name="applicationName"></param>
        /// <param name="scopeName"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        public Dictionary<string, List<string>> GroupUserInSameGroup(string applicationName, string scopeName, List<string> users)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            if ((users != null) && !string.IsNullOrEmpty(scopeName))
            {
                foreach (string user in users)
                {
                    string[] groups = GetUserApplicationGroups(applicationName, scopeName, user);
                    if (groups.Length > 0)
                    {
                        //In FFX, a user in a scope is only assigned in only one group, so only get first group
                        string group = groups[0];
                        if (!result.ContainsKey(group))
                        {
                            result.Add(group, new List<string>());
                        }
                        result[group].Add(user);
                    }
                }
            }
            else if (users != null)
            {
                foreach (string user in users)
                {
                    string[] groups = GetUserApplicationGroupsInAllScopes(applicationName, user);
                    if (groups.Length > 0)
                    {
                        //In FFX, a user in a scope is only assigned in only one group, so only get first group
                        foreach (string group in groups)
                        {
                            if (!result.ContainsKey(group))
                            {
                                result.Add(group,
                                           new List<string>());
                            }
                            result[group].Add(user);
                        }
                    }
                }
            }
            return result;
        }

        #endregion

        protected bool IsUserInMembers(object[] members, string userName)
        {
            foreach (object member in members)
            {
                string domainUsername = ConvertToUsername(member);
                if (domainUsername.Equals(userName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private AzAuthorizationStoreClass GetNewAzAuthorizationStoreClass()
        {
            AzAuthorizationStoreClass newAzManStore = new AzAuthorizationStoreClass();
            newAzManStore.Initialize(0, this.ConnectionString, null);
            return newAzManStore;
        }

        /// <summary>
        /// Refresh azManStore without creating new instance
        /// </summary>
        public void Reload()
        {
            try
            {
                azManStore.UpdateCache(null);
            }
            catch
            {
                _azManStore = GetNewAzAuthorizationStoreClass();
            }
        }

        #region New Methods added by Duy.Hoang
        public AppInfo GetAppInfo(string applicationName)
        {
            IAzApplication azApplication = azManStore.OpenApplication(applicationName, null);
            if (azApplication == null) throw new Exception(string.Format("Can't find {0} in azMan", applicationName));

            var appInfo = new AppInfo(azApplication.Name);
            appInfo.Scopes = this.GetScopeInfoInApplication(azApplication, appInfo);
            appInfo.RoleAssigments = this.GetRoleDefinitionInApp(azApplication, appInfo);
            return appInfo;
        }

        private IEnumerable<ScopeInfo> GetScopeInfoInApplication(IAzApplication azApplication, AppInfo ownerApp)
        {
            foreach (IAzScope azScope in azApplication.Scopes)
            {
                var scope = new ScopeInfo(ownerApp, azScope.Name);
                scope.Groups = GetGroupInfoInScope(azScope, scope);
                scope.Roles = this.GetRoleInfoInScopes(azScope, scope);
                yield return scope;
            }
        }

        private IEnumerable<GroupInfo> GetGroupInfoInScope(IAzScope azScope, ScopeInfo scopeInfo)
        {
            foreach (IAzApplicationGroup azGroup in azScope.ApplicationGroups)
            {
                var group = new GroupInfo(scopeInfo, azGroup.Name);
                group.Users = this.GetUsersInGroup(azGroup, group);
                yield return group;
            }
        }

        private IEnumerable<RoleInfo> GetRoleInfoInScopes(IAzScope azScope, ScopeInfo scopeInfo)
        {
            foreach (IAzRole azRole in azScope.Roles)
            {
                var role = new RoleInfo(scopeInfo, azRole.Name);
                role.Users = GetUsersInRole(azRole, role);
                yield return role;
            }
        }

        private IEnumerable<RoleAssignment> GetRoleAssignmentsInApp(IAzApplication azApplication, AppInfo ownerApp)
        {
            foreach (IAzRole azRole in azApplication.Roles)
            {
                var role = new RoleAssignment(ownerApp, azRole.Name);
                role.Operations = this.GetOperationInfoInRole(azRole);
                yield return role;
            }
        }

        private IEnumerable<RoleAssignment> GetRoleDefinitionInApp(IAzApplication azApplication, AppInfo ownerApp)
        {
            foreach (IAzTask azTask in azApplication.Tasks)
            {
                if (azTask.IsRoleDefinition != 1)
                    continue;

                var role = new RoleAssignment(ownerApp, azTask.Name);
                role.Operations = this.GetOperationInfoInTask(azTask);
                yield return role;
            }
        }

        private IEnumerable<string> GetOperationInfoInRole(IAzRole azRole)
        {
            foreach (IAzOperation op in (object[])azRole.Operations)
            {
                yield return op.Name;
            }
        }

        private IEnumerable<string> GetOperationInfoInTask(IAzTask azTask)
        {
            foreach (string opName in (Array)azTask.Operations)
            {
                yield return opName;
            }
        }

        private IEnumerable<UserOfGroup> GetUsersInGroup(IAzApplicationGroup azGroup, GroupInfo ownerGroup)
        {
            foreach (object member in (object[])azGroup.Members)
            {
                var userInfo = new UserOfGroup(ConvertToUsername(member), ownerGroup);
                yield return userInfo;
            }
        }

        private IEnumerable<UserOfRole> GetUsersInRole(IAzRole azRole, RoleInfo ownerRole)
        {
            foreach (object member in (object[])azRole.Members)
            {
                var userInfo = new UserOfRole(ConvertToUsername(member), ownerRole);
                yield return userInfo;
            }
        }

        public void CloseApplication(AppInfo appInfo)
        {
            this.azManStore.CloseApplication(appInfo.Name, 0);
        }
        #endregion

        public void Dispose()
        {
            if (this.azManStore != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_azManStore);
                _azManStore = null;
            }
        }
    }


    [Serializable]
    public abstract class AzManInfoBase
    {
        public virtual string Name { get; protected set; }
        public virtual AzManInfoBase Parent { get; protected set; }
    }

    [Serializable]
    public class AppInfo : AzManInfoBase
    {
        public AppInfo(string applicationName)
        {
            this.Name = applicationName;
        }

        public IEnumerable<ScopeInfo> Scopes { get; set; }
        public IEnumerable<RoleAssignment> RoleAssigments { get; set; }
    }

    [Serializable]
    public class ScopeInfo : AzManInfoBase
    {
        public ScopeInfo(AppInfo appInfo, string name)
        {
            this.Parent = appInfo;
            this.Name = name;
        }

        public new AppInfo Parent
        {
            get { return base.Parent as AppInfo; }
            set { base.Parent = value; }
        }
        public IEnumerable<GroupInfo> Groups { get; set; }
        public IEnumerable<RoleInfo> Roles { get; set; }
    }

    [Serializable]
    public class GroupInfo : AzManInfoBase
    {
        public GroupInfo(ScopeInfo scopeInfo, string groupName)
        {
            this.Parent = scopeInfo;
            this.Name = groupName;
        }

        public new ScopeInfo Parent
        {
            get { return base.Parent as ScopeInfo; }
            set { base.Parent = value; }
        }
        public IEnumerable<UserOfGroup> Users { get; set; }
    }

    [Serializable]
    public abstract class RoleBase : AzManInfoBase
    { 
    }

    [Serializable]
    public class RoleInfo : RoleBase
    {
        public RoleInfo(ScopeInfo scopeInfo, string roleName)
        {
            this.Parent = scopeInfo;
            this.Name = roleName;
        }

        public new ScopeInfo Parent
        {
            get { return base.Parent as ScopeInfo; }
            set { base.Parent = value; }
        }
        public IEnumerable<UserOfRole> Users { get; set; }
    }

    [Serializable]
    public class RoleAssignment : RoleBase
    {
        public RoleAssignment(AppInfo appInfo, string roleName)
        {
            this.Parent = appInfo;
            this.Name = roleName;
        }

        public new AppInfo Parent
        {
            get { return base.Parent as AppInfo; }
            set { base.Parent = value; }
        }
        public IEnumerable<string> Operations { get; set; }
    }

    [Serializable]
    public abstract class UserInfoBasbe : AzManInfoBase
    {
    }

    [Serializable]
    public class UserOfGroup : UserInfoBasbe
    {
        public UserOfGroup(string userName, GroupInfo groupInfo)
        {
            this.Name = userName;
            this.Parent = groupInfo;
        }

        public new GroupInfo Parent
        {
            get { return base.Parent as GroupInfo; }
            set { base.Parent = value; }
        }
    }

    [Serializable]
    public class UserOfRole : UserInfoBasbe
    {
        public UserOfRole(string userName, RoleInfo roleInfo)
        {
            this.Name = userName;
            this.Parent = roleInfo;
        }

        public new RoleInfo Parent
        {
            get { return base.Parent as RoleInfo; }
            set { base.Parent = value; }
        }
    }
}
