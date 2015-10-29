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
    public class SysMsgTempSetController : Controller
    {
        SysMsgTempSetBll bll = new SysMsgTempSetBll();
        //
        // GET: /Admin/SysMsgTempSet/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(int pagenum, int pagesize)
        {
            
            System.Data.DataTable dt = bll.GetList( );

            string result = JsonWithDataTable.Serialize(dt);
           
            return result;

        }

        public string CheckRepeat(string ID, string RecordStatus, int sendType, bool IsManager)
        {
            return bll.Exit(ID, RecordStatus, sendType, IsManager).ToString().ToLower();

        }
        //
        // POST: /Admin/SysMsgTempSet/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            SysMsgTempSet p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<SysMsgTempSet>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<SysMsgTempSet>();

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
                    p = new SysMsgTempSet();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/SysMsgTempSet/Edit/5
        public ActionResult Edit(string id)
        {

            SysMsgTempSet p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new SysMsgTempSet();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/SysMsgTempSet/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
