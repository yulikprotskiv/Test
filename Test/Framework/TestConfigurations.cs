using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Test.Framework
{
    public class TestConfigurations
    {
        public static string Browser;
        public static string Username;
        public static string Password;

        public static TestConfigurations configs;
        
        private static string GetConfigFilePath()
        {
            string executingAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = new DirectoryInfo(executingAssembly).Parent.Parent.Parent.FullName;
            return Path.Combine(path, "TestConfigs.xml");
        }

        public static void GetConfigs()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(GetConfigFilePath());
            Username = xmlDoc.DocumentElement.SelectSingleNode("username").InnerText;
            Password = xmlDoc.DocumentElement.SelectSingleNode("password").InnerText;
            Browser = xmlDoc.DocumentElement.SelectSingleNode("browser").InnerText;
        }

        public static TestConfigurations GetInstance()
        {
            if (configs == null)
            {
                GetConfigFilePath();
                GetConfigs();
            }
            return configs;
        }
    }
}
