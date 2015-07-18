using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasyCms.Model
{
    [JsonObject]
    public class Gataway
    {
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string logo { get; set; }
        public bool emailAddress { get; set; }
        public bool sellerAccount { get; set; }
        public bool primaryKey { get; set; }

        public bool secondKey { get; set; }
        public bool password { get; set; }
        public bool partner { get; set; }
        public string requestType { get; set; }
        public string notifyType { get; set; }
        public string urlFormat { get; set; }
        public string supportedCurrency { get; set; }
        public string displayName { get; set; }

        public static Gataway Phrase(XElement node)
        {
            return null;
        }
    }
}
