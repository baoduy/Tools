using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WindowsAuthorizationManager.Entities
{
    [Serializable]
    public class EnvironmentEntity
    {
        public EnvironmentEntity()
        {
            this.ConnectionString = string.Empty;
            this.EnvironmentName = string.Empty;
        }

        [XmlAttribute]
        public string EnvironmentName { get; set; }
        [XmlAttribute]
        public string ConnectionString { get; set; }
    }
}
