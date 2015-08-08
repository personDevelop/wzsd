using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EasyCms.Web.API
{
    public class BaseAPIControl : ApiController
    {
        public string host
        {
            get
            {

                string url = this.Url.Request.RequestUri.Authority + RequestContext.VirtualPathRoot;
                if (!url.StartsWith("http://")) url = "http://" + url;
                return url;
            }
        }
    }
}