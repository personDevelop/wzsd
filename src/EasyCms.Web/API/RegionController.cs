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

        public HttpResponseMessage GetChildRegion(int id=0)
        {

            DataTable dt = new AdministrativeRegionsBll().GetList(id, true);
            string result = JsonWithDataTable.Serialize(dt);
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }

        public HttpResponseMessage GetRegionPath(int id)
        {
            DataTable dt= new AdministrativeRegionsBll().GetOne(id);
        
            if (dt.Rows[0]["FullPath"].ToString().Contains("|"))
            {
                dt = new AdministrativeRegionsBll().GetPathByFullPath(dt.Rows[0]["FullPath"].ToString());
            } 
          
            string result = JsonWithDataTable.Serialize(dt);
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }
    }
}
