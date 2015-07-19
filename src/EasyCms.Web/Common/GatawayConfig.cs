using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.IO;
using EasyCms.Model;
using System.Web.Hosting;

namespace EasyCms.Web.Common
{
    public class GatawayConfig
    {

        private const string ConfigPath = "~/Gateway.config";

        static List<Gataway> GatawayList = null;
        public static List<Gataway> GetAllGataway()
        {
            if (GatawayList == null)
            {


                GatawayList = new List<Gataway>();

                XDocument doc = XDocument.Load(HostingEnvironment.MapPath(ConfigPath));

                foreach (var item in doc.Root.Element("providers").Elements("add"))
                {
                    GatawayList.Add(Gataway.Phrase(item));
                }
            }
            return GatawayList;
        }

    }
}