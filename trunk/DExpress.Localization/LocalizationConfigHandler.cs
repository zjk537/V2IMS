using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Pst.DExpress.Localization
{
    class LocalizationConfigHandler
    {
        private LocalizationConfigHandler() { }

        private static LocalizationType runtimeLocalizationType = LocalizationType.Normal;    

        public static string RunTimeLocaliationTypeString
        {
            get { return runtimeLocalizationType.ToString(); }
        }

        public static LocalizationType RuntimeLocalizationType
        {
            set
            {
                runtimeLocalizationType = value;
            }
            get { return runtimeLocalizationType; }
        }

        private static string configPathFormat = @"LocalizationInfo\Adsage.Pst.{0}.Localization.{1}.config";
      
        public static Dictionary<string, string> ReadLocalizationConfig(ControlType controlType)
        {
            string configPath = string.Format(configPathFormat, controlType.ToString(), RunTimeLocaliationTypeString);

            Dictionary<string, string> dicNameValue = new Dictionary<string, string>();

            if (File.Exists(configPath))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(configPath);

                XmlNodeList xnDataList = xd.SelectNodes("configuration/root/data");

                foreach (XmlNode xn in xnDataList)
                {
                    if (!dicNameValue.Keys.Contains(xn.Attributes["name"].Value))
                    {
                        dicNameValue.Add(xn.Attributes["name"].Value,xn.Attributes["value"].Value);
                    }
                }
            }

           
            return dicNameValue;
        }
    }
}
