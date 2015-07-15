using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace EasyCms 
{
    public static class ExtentionMethod
    {
        public static bool IsJsonRequest(this HttpRequestBase request)
        {
            return "json" == request["format"];
        }

        public static string GetQueryValue(this HttpRequestMessage request, string key)
        {
            string value = null;
            IEnumerable<KeyValuePair<string, string>> querystring = request.GetQueryNameValuePairs();
            foreach (var item in querystring)
            {
                if (item.Key.ToLower() == key.ToLower())
                {
                    value = item.Value;
                    break;
                }
            } 
            return value; 
        }


    }
}