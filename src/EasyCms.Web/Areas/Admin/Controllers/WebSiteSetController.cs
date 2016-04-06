using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class WebSiteSetController : Controller
    {
        WebSiteSetBll bll = new WebSiteSetBll();
        public ActionResult Index()
        {
            WebSiteSet WebSiteSet = bll.GetEntity();
            return View(WebSiteSet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            WebSiteSet p = null; ;

            if (collection["RecordStatus"] != "add")
            {
                p = bll.GetEntity();
                p.BindForm<WebSiteSet>(collection);
            }
            else
            {
                // TODO: Add insert logic here
                p = collection.Bind<WebSiteSet>();

            }

            if (p.RecordStatus == Sharp.Common.StatusType.add)
            {
                if (string.IsNullOrWhiteSpace(p.ID))
                {
                    p.ID = Guid.NewGuid().ToString();
                }
            }
            bll.Save(p);
            if (TempData.ContainsKey("IsSuccess"))
            {
                TempData["IsSuccess"] = "保存成功";

            }
            else
            {
                TempData.Add("IsSuccess", "保存成功");
            }
            ModelState.Clear();
            return View("Index", p);
        }
    }
}
