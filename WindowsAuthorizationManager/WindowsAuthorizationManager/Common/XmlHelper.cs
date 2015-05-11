using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Schroders.Framework.Log;
using System.Linq;

namespace WindowsAuthorizationManager.Common
{
    public static class XmlHelper
    {
        static readonly Dictionary<string, object> cacher = new Dictionary<string, object>();

        public static T GetMappingConfiguration<T>(string fileName)
        {
            //Check File Name.
            if (string.IsNullOrEmpty(fileName))
                return default(T);

            //Check the cache.
            if (cacher.ContainsKey(fileName))
            {
                T item = (T)cacher[fileName];
                if (item != null)
                    return item;
                else cacher.Remove(fileName);
            }

            if (!System.IO.File.Exists(fileName))
                return default(T);

            object obj = null;
            DateTime start = DateTime.Now;

            try
            {
                var s = new XmlSerializer(typeof(T));
                using (var r = new StreamReader(fileName))
                {
                    obj = s.Deserialize(r);
                }

                //LogManager.GetLogger().WriteLog(string.Format("It take {0} to read file: {1}", (DateTime.Now - start), fileName));
            }
            catch (Exception ex)
            {
                //LogManager.GetLogger().WriteError(ex);
                throw ex;
            }

            if (obj == null)
            {
                //LogManager.GetLogger().WriteLog(string.Format("Data of file: {1} is empty", (DateTime.Now - start), fileName));
                throw new Exception(string.Format("Data of file: {1} is empty", (DateTime.Now - start), fileName));
            }
            else
            {
                try
                { cacher.Add(fileName, obj); }
                catch
                { cacher[fileName] = obj; }
                //cacher.Add( fileName, obj );
            }

            return (T)obj;
        }

        public static void SaveConfigurationToFile(object data, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return;
            if (System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);

            var serializer = new XmlSerializer(data.GetType());
            using (var writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer.BaseStream, data);
            }
        }

        public static IEnumerable<T> GetAllCacheByType<T>()
        {
            return from t in cacher
                   where t.Value is T
                   select (T)t.Value;
        }
    }
}
