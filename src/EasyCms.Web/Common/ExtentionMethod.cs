using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyCms.Common
{
    public static class ExtentionMethod
    {
        public static bool IsJsonRequest(this HttpRequestBase request)
        {
            return "json" == request["format"];
        }


    }
}