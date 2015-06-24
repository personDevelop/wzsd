using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using EasyCms.Web.Common;


namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class NewsCategoryController : Controller
    {
        NewsCategoryBll bll = new NewsCategoryBll();
        //
        // GET: /Admin/NewsCategory/
        public ActionResult Index()
        {

            return View();
        }
        public string GetList()
        {
            System.Data.DataTable dt = bll.GetList();
            return JsonWithDataTable.Serialize(dt);
            //string result = JsonConvert.Convert2Json(dt);
            //return result;

        }
        public string GetListForSelecte()
        {
            System.Data.DataTable dt = bll.GetList(true);
            return JsonWithDataTable.Serialize(dt);
            //string result = JsonConvert.Convert2Json(dt);
            //return result;
        }
        public string CheckRepeat(string ID, string ParentID, string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID, ParentID, RecordStatus, val, IsCode).ToString().ToLower();

        }
        //
        // POST: /Admin/NewsCategory/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            NewsCategory p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<NewsCategory>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<NewsCategory>();

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
        // GET: /Admin/NewsCategory/Edit/5
        public ActionResult Edit(string id)
        {

            NewsCategory p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new NewsCategory();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/NewsCategory/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}