using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.IO;
using EasyCms.Model;

namespace EasyCms.Web.Common
{
    public class GatawayConfig
    {
        static XDocument doc = null;
        public static List<Gataway> GatawayList = new List<Gataway>();
        private const string ConfigPath = "~/Gateway.config";
        static GatawayConfig()
        {
            doc = XDocument.Load(Path.Combine(System.Environment.CurrentDirectory, ConfigPath));
            GetAllGataway();

        }

        static void GetAllGataway()
        {

            foreach (var item in doc.Root.Element("providers").Elements("add"))
            {
                GatawayList.Add(Gataway.Phrase(item));
            }
        }

    }
}