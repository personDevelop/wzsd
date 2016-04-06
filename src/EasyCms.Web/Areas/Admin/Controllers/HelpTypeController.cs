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
    public class HelpTypeController : Controller
    {
        HelpTypeBll bll = new HelpTypeBll();
        //
        // GET: /Admin/HelpType/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList()
        {

            System.Data.DataTable dt = bll.GetList();
            return JsonWithDataTable.Serialize(dt);
            ;

        }
      
        public string GetListForSelecte()
        {
            System.Data.DataTable dt = bll.GetList(true);
            return JsonWithDataTable.Serialize(dt);
        }
        public string CheckRepeat(string ID, string ParentID, string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID, ParentID, RecordStatus, val, IsCode).ToString().ToLower();

        }
        //
        // POST: /Admin/HelpType/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            HelpType p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<HelpType>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<HelpType>();

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
                    TempData.Add("IsSuccess", "保存成功");

                }
                else
                {
                    TempData["IsSuccess"] = "保存成功";
                }
                ModelState.Clear();
                if (collection["IsContinueAdd"] == "1")
                {
                    p = new HelpType();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/HelpType/Edit/5
        public ActionResult Edit(string id)
        {

            HelpType p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new HelpType();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/HelpType/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
