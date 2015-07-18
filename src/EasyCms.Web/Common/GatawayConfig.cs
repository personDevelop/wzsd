using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.IO;

namespace EasyCms.Web.Common
{
    public class GatawayConfig
    {
        static XDocument doc = null;
        private const string ConfigPath = "~/Gateway.config";
        static GatawayConfig()
        {
            doc = XDocument.Load(Path.Combine(System.Environment.CurrentDirectory, ConfigPath));
        }

        public void GetAllGataway()
        {

            foreach (var item in doc.Root.Element("providers").Elements("add"))
            {

            }
        }

    }
}