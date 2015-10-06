using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms
{
    public class BaseControler : Controller
    {

        public string host
        {
            get
            {
                string url = HttpContext.Request.Url.Authority + HttpContext.Request.ApplicationPath;
                if (!url.StartsWith("http://")) url = "http://" + url;
                return url;
             
            }
        }
         
    }
}