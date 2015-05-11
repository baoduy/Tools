namespace AppPoolController.Class
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.DirectoryServices;
    using System.DirectoryServices.ActiveDirectory;
    using System.IO;
    using System.Diagnostics;
    using System.Reflection;
    using System.Configuration;
    using System.Text.RegularExpressions;

    public class AppPool
    {
        public enum AppPoolStatus
        {
            Unknow = 0,
            Start = 1,
            Stop = 2,
        }

        public static IList<DirectoryEntry> GetAllAppPool(string serverName, string adminUsername, string adminPassword)
        {
            IList<DirectoryEntry> list = new List<DirectoryEntry>();
            using (DirectoryEntry appPools = new DirectoryEntry("IIS://" + serverName + "/w3svc/apppools", adminUsername, adminPassword))
            {
                foreach (DirectoryEntry AppPool in appPools.Children)
                    list.Add(AppPool);
            }
            return list;
        }

        public static DirectoryEntry GetAppPool(string serverName, string adminUsername, string adminPassword, string appPoolName)
        {
            foreach (DirectoryEntry AppPool in GetAllAppPool(serverName, adminUsername, adminPassword))
            {
                if (appPoolName.Equals(AppPool.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return AppPool;
                }
            }
            return null;
        }

        public static bool Exist(string serverName, string adminUsername, string adminPassword, string appPoolName)
        {
            return GetAppPool(serverName, adminUsername, adminPassword, appPoolName) != null;
        }

        public static bool StopAppPool(string serverName, string adminUsername, string adminPassword, string appPoolName)
        {
            string path = "IIS://" + serverName + "/W3SVC/AppPools/" + appPoolName;
            DirectoryEntry app = new DirectoryEntry(path, adminUsername, adminPassword);
            return StopAppPool(app);
        }

        public static bool StartAppPool(string serverName, string adminUsername, string adminPassword, string appPoolName)
        {
            string path = "IIS://" + serverName + "/W3SVC/AppPools/" + appPoolName;
            DirectoryEntry app = new DirectoryEntry(path, adminUsername, adminPassword);
            return StartAppPool(app);
        }

        public static bool StopAppPool(DirectoryEntry appPool)
        { return SetAppPoolStatus(appPool, AppPoolStatus.Stop); }

        public static bool StartAppPool(DirectoryEntry appPool)
        { return SetAppPoolStatus(appPool, AppPoolStatus.Start); }

        public static bool SetAppPoolStatus(DirectoryEntry appPool, AppPoolStatus appPoolStatus)
        {
            if (appPool != null)
            {
                //System.DirectoryServices.PropertyCollection ports = appPool.Properties;
                //ports["AppPoolCommand"].Value = appPoolStatus;//Stop = 2, Start = 1;
                //appPool.CommitChanges();
                try
                {
                    appPool.RefreshCache();
                    if (appPoolStatus == AppPoolStatus.Start)
                        appPool.Invoke("Start", null);
                    else appPool.Invoke("Stop", null);

                    return true;
                }
                catch { }
            }

            return false;
        }

        public static AppPoolStatus GetAppPoolStatus(DirectoryEntry appPool)
        {
            if (appPool != null)
            {
                System.DirectoryServices.PropertyCollection ports = appPool.Properties;
                return (AppPoolStatus)ports["AppPoolCommand"].Value;//Stop = 2, Start = 1;
            }

            return AppPoolStatus.Unknow;
        }

        public static bool RecycleAppPool(string serverName, string adminUsername, string adminPassword, string appPoolName)
        {
            string path = "IIS://" + serverName + "/W3SVC/AppPools/" + appPoolName;
            DirectoryEntry app = new DirectoryEntry(path, adminUsername, adminPassword);
            return RecycleAppPool(app);

            //DirectoryEntry AppPool = GetAppPool(serverName, adminUsername, adminPassword, appPoolName);
            //return RecycleAppPool(AppPool);
        }

        public static bool RecycleAppPool(DirectoryEntry appPool)
        {
            if (appPool != null)
            {
                try
                {
                    appPool.RefreshCache();
                    appPool.Invoke("Recycle", null);
                    //appPool.Close();
                    return true;
                }
                catch
                {
                    StopAppPool(appPool);
                    StartAppPool(appPool);
                }
            }

            return false;
        }

        /// <summary>
        /// Creates AppPool
        /// </summary>
        /// <param name="metabasePath"></param>
        /// <param name="appPoolName"></param>
        public static bool CreateAppPool(string serverName, string adminUsername, string adminPassword, string appPoolName)
        {
            try
            {
                string metabasePath = "IIS://" + serverName + "/W3SVC/AppPools";
                using (DirectoryEntry apppools = new DirectoryEntry(metabasePath))//, apppools;
                {
                    using (DirectoryEntry newpool = apppools.Children.Add(appPoolName, "IIsApplicationPool"))
                    {
                        newpool.CommitChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Failed in CreateAppPool with the following exception: \n{0}", ex.Message));
            }
        }

        /// <summary>
        /// Assigns AppPool to Virtual Directory
        /// </summary>
        /// <param name="metabasePath"></param>
        /// <param name="appPoolName"></param>
        public static bool AssignVDirToAppPool(string metabasePath, string appPoolName)
        {
            //  metabasePath is of the form "IIS://<servername>/W3SVC/<siteID>/Root[/<vDir>]"
            //    for example "IIS://localhost/W3SVC/1/Root/MyVDir"
            //  appPoolName is of the form "<name>", for example, "MyAppPool"
            //Console.WriteLine("\nAssigning application {0} to the application pool named {1}:", metabasePath, appPoolName);

            using (DirectoryEntry vDir = new DirectoryEntry(metabasePath))
            {
                string className = vDir.SchemaClassName.ToString();
                if (className.EndsWith("VirtualDir"))
                {
                    object[] param = { 0, appPoolName, true };
                    vDir.Invoke("AppCreate3", param);
                    vDir.Properties["AppIsolated"][0] = "2";
                    return true;
                }
                else
                    throw new Exception(" Failed in AssignVDirToAppPool; only virtual directories can be assigned to application pools");
            }
        }

        /// <summary>
        /// Delete AppPool
        /// </summary>
        /// <param name="metabasePath"></param>
        /// <param name="appPoolName"></param>
        public static bool DeleteAppPool(string serverName, string adminUsername, string adminPassword, string appPoolName)
        {
            DirectoryEntry AppPool = GetAppPool(serverName, adminUsername, adminPassword, appPoolName);
            if (AppPool != null)
            {
                AppPool.DeleteTree();
                return true;
            }
            return false;
        }
    }
}
