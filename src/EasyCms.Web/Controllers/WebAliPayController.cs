using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Controllers
{
    public class WebAliPayController : Controller
    {
        /// <summary>
        /// 支付结果同步返回的url  returnUrl
        /// </summary>
        /// <returns></returns>
        // GET: WebAliPay
        public ActionResult Index()
        {
            return View();
        }
    }
}