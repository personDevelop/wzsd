using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using System.Data;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class NewsInfoController : Controller
    {
        NewsInfoBll bll = new NewsInfoBll();
        //
        // GET: /Admin/NewsInfo/
        public ActionResult Index()
        {

            return View();
        }
        public string GetList()
        {
            System.Data.DataTable dt = bll.GetList();
            string result = JsonConvert.Convert2Json(dt);
            return result;


        }
        public ActionResult GetListForSelecte()
        {
            System.Data.DataTable dt = bll.GetList(true);
            return Json(new { data = dt });
        }

        //
        // POST: /Admin/NewsInfo/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            NewsInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<NewsInfo>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<NewsInfo>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                    p.CreatedUserID = Session.GetUserID();
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
        // GET: /Admin/NewsInfo/Edit/5
        public ActionResult Edit(string id)
        {

            NewsInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new NewsInfo();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/NewsInfo/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}