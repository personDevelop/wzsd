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

namespace EasyCms.Web.API
{
    public class APPController : ApiController
    {
         
        public HttpResponseMessage  GetNews(int page = 1)
        {

            //新闻id，定标题，简介，缩略图，新闻url 
            DataTable dt = new NewsInfoBll().GetAppNews(page);
            string result = JsonConvert.Convert2Json(dt);
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;

        }
        //[HttpGet]
        //public string  OneNew(string newsid="")
        //{
        //    var resp = new HttpResponseMessage(HttpStatusCode.OK);


        //    if (string.IsNullOrEmpty(newsid))
        //    {
        //        resp.Content = new StringContent("此新闻已别删除或屏蔽", Encoding.UTF8, "text/plain");
        //    }
        //    else
        //    {
        //       NewsInfo news = new NewsInfoBll().GetEntity(newsid);
        //       resp.Content = new StringContent(news.Description, Encoding.UTF8, "text/plain");
        //    }
        //    return "resp";
             

        //}

    }
}
