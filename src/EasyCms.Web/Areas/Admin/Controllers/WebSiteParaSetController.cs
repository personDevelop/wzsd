using EasyCms.Business;
using EasyCms.Model;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class WebSiteParaSetController : Controller
    {
        WebSiteParaSetBll bll = new WebSiteParaSetBll();
        // GET: Admin/AppSet
        public ActionResult Index()
        {
            WebSiteParaSet appSet = bll.GetEntity();
            return View(appSet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            WebSiteParaSet p = null; ;

            if (collection["RecordStatus"] != "add")
            {
                p = bll.GetEntity();
                p.BindForm<WebSiteParaSet>(collection);
            }
            else
            {
                // TODO: Add insert logic here
                p = collection.Bind<WebSiteParaSet>();

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