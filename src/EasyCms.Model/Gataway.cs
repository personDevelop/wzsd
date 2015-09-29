using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            Gataway g = new Gataway();
            PropertyInfo[] ps = g.GetType().GetProperties();
            foreach (PropertyInfo item in ps)
            {
                XAttribute atr = node.Attribute(item.Name);
                if (atr != null)
                {
                    string s = atr.Value;
                    try
                    {
                        if (item.PropertyType.FullName=="System.Boolean")
                        {
                            bool d = false;
                            bool.TryParse(s, out d);
                            item.SetValue(g, d,null);
                        }
                        else
                        {
                            item.SetValue(g, s, null);
                        }
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }

            }
            return g;
        }
    }
}
