using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AppPoolController.Class
{
    public static class Functions
    {
        public const string EnvironmentFileName = "Environment.xml";

        public static void SaveEnvironment(IList<EnvironmentEntry> list)
        {
            using (Stream stream = File.Open(EnvironmentFileName, FileMode.Create))
            {
                BinaryFormatter bformatter = new BinaryFormatter();

                foreach (EnvironmentEntry env in list)
                {
                    bformatter.Serialize(stream, env);
                }
            }
        }

        public static IList<EnvironmentEntry> ReadEnvironment()
        {
            IList<EnvironmentEntry> list = new List<EnvironmentEntry>();

            if (System.IO.File.Exists(EnvironmentFileName))
            {
                using (Stream stream = File.Open(EnvironmentFileName, FileMode.Open))
                {
                    BinaryFormatter bformatter = new BinaryFormatter();

                    EnvironmentEntry env = null;
                    while (stream.Position < stream.Length)
                    {
                        env = (EnvironmentEntry)bformatter.Deserialize(stream);
                        list.Add(env);
                    }
                }
            }
            return list;
        }
    }
}
