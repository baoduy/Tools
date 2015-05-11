using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsAuthorizationManager.Entities;
using System.Collections.Specialized;
using System.Xml.Serialization;
using System.IO;

namespace WindowsAuthorizationManager.Common
{
    public static class Helper
    {
        const char seperaterChar = '|';

        public static IList<EnvironmentEntity> ConvertToEnvironmentEntity(this StringCollection collection)
        {
            var list = new List<EnvironmentEntity>();

            if (collection != null)
            {
                foreach (var value in collection)
                {
                    if (!value.Contains(seperaterChar))
                        continue;

                    var split = value.Split(seperaterChar);
                    list.Add(new EnvironmentEntity() { EnvironmentName = split[0], ConnectionString = split[1] });
                }
            }

            return list;
        }

        public static StringCollection ConvertToStringCollection(this IList<EnvironmentEntity> list)
        {
            var collection = new StringCollection();

            foreach (var item in list)
                collection.Add(string.Format("{0}{1}{2}", item.EnvironmentName, seperaterChar, item.ConnectionString));

            return collection;
        }

        public static void SaveConfigurationToFile(EnvironmentCollection list, string fileName)
        {
            XmlHelper.SaveConfigurationToFile(list, fileName);
        }

        public static EnvironmentCollection GetConfigurationFromFile(string fileName)
        {
            var list =  XmlHelper.GetMappingConfiguration<EnvironmentCollection>(fileName);
            if (list == null)
                return new EnvironmentCollection();
            return list;
        }
    }
}
