using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Sharp.Common;
using System.Data;
using EasyCms.Business;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using EasyCms.Web.Common; 

namespace EasyCms.Web.API
{
    public class APPController : ApiController
    {
        string host { get { return this.Url.Request.RequestUri.Authority + RequestContext.VirtualPathRoot; } }
        public HttpResponseMessage GetNews(int id = 1)
        {
            //获取page  
            int page = id;
            //新闻id，定标题，简介，缩略图，新闻url 
            DataTable dt = new NewsInfoBll().GetAppNews(page, host);

            string result = JsonWithDataTable.Serialize(dt) ;
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain"); 
            return resp;

        }
        
        public HttpResponseMessage GetNew(string id = "")
        {

            var resp = new HttpResponseMessage(HttpStatusCode.OK);


            if (string.IsNullOrEmpty(id))
            {
                resp.Content = new StringContent("此新闻已被删除或屏蔽", Encoding.UTF8, "text/plain");
            }
            else
            {
                NewsInfo news = new NewsInfoBll().GetEntity(id);
                if (news.Description == null)
                {
                    news.Description = string.Empty;
                }
                string result = JsonWithDataTable.Serialize(news);
                resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            }  
            return resp;


        }

    }
}
