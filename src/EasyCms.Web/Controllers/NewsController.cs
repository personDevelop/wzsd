using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(string id)
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNum">页号从1开始</param>
        /// <param name="pageSize">每页显示个数 默认20</param>
        /// <returns></returns>
        public string GetNews(int pageNum = 1, int pageSize = 20)
        { 
            int recourdCount = 0, pageCount = 0;
            //新闻id，定标题，简介，缩略图，新闻url 
            DataTable dt = new NewsInfoBll().GetNews(pageNum, pageSize, ref recourdCount,ref pageCount);

           
            string result = JsonWithDataTable.Serialize(new {pageNum=pageNum, recourdCount = recourdCount, pageCount = pageCount, data = dt });
            return result;
            



        }
    }
}