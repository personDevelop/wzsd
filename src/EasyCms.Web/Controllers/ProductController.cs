using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="other">商品SKUid</param>
        /// <returns></returns>
        public ActionResult Index(string id,string other)
        {
            string error;
            ShopProductInfo p = new ShopProductInfoBll().GetWebEntity(id, other, out   error);
            if (string.IsNullOrWhiteSpace(error))
            {
                return View(p);

            }

            return View("Error",new MessageModel("商品不存在或已下架", error, ShowMsgType.info));
        }
    }
}