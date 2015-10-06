using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Web.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace EasyCms.Web.API
{
    public class RegionController : ApiController
    {

        public HttpResponseMessage GetChildRegion(int id = 0)
        {
            

                DataTable dt = new AdministrativeRegionsBll().GetList(id, true);

                return dt.Format();
            
        }

        public HttpResponseMessage GetRegionPath(int id)
        {
            
                DataTable dt = new AdministrativeRegionsBll().GetOne(id);

                if (dt.Rows[0]["FullPath"].ToString().Contains("|"))
                {
                    dt = new AdministrativeRegionsBll().GetPathByFullPath(dt.Rows[0]["FullPath"].ToString());
                }

                return dt.Format();
           
        }
    }
}
