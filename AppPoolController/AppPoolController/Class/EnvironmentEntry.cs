using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace AppPoolController.Class
{
    [Serializable]
    public class EnvironmentEntry : ISerializable
    {
        string name;
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        string serverList;
        public string ServerList
        {
            get
            {
                return serverList;
            }
            set { this.serverList = value; }
        }

        public IList<string> GetServerList()
        {
            IList<string> list = new List<string>();
            if (!string.IsNullOrEmpty(this.ServerList))
            {
                foreach (string ser in this.ServerList.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                { list.Add(ser); }
            }
            return list;
        }

        #region ISerializable Members
        public EnvironmentEntry(string name)
        {
            this.Name = name;
        }

        public EnvironmentEntry(SerializationInfo info, StreamingContext ctxt)
        {
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.UserName = (string)info.GetValue("UserName", typeof(string));
            this.Password = (string)info.GetValue("Password", typeof(string));
            this.ServerList = (string)info.GetValue("ServerList", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name);
            info.AddValue("UserName", this.UserName);
            info.AddValue("Password", this.Password);
            info.AddValue("ServerList", this.ServerList);
        }

        #endregion
    }
}
