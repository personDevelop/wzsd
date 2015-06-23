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
    public class ShopBrandInfoController : Controller
    {
        ShopBrandInfoBll bll = new ShopBrandInfoBll();
        //
        // GET: /Admin/ShopBrandInfo/
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult GetList()
        {
            System.Data.DataTable dt = bll.GetList();
            return Json(new { data = dt });


        }
        public ActionResult GetListForSelecte()
        {
            System.Data.DataTable dt = bll.GetList(true);
            return Json(new { data = dt });
        }

        //
        // POST: /Admin/ShopBrandInfo/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopBrandInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<ShopBrandInfo>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopBrandInfo>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                   
                }
                bll.Save(p);
                TempData.Add("IsSuccess", "保存成功");
                ModelState.Clear();


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/ShopBrandInfo/Edit/5
        public ActionResult Edit(string id)
        {

            ShopBrandInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopBrandInfo();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ShopBrandInfo/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
