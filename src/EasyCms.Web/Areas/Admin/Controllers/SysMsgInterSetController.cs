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
    public class SysMsgInterSetController : Controller
    {
        SysMsgInterSetBll bll = new SysMsgInterSetBll();
        //
        // GET: /Admin/SysMsgInterSet/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList( )
        {
             
            System.Data.DataTable dt = bll.GetList( ); 
            string result = JsonWithDataTable.Serialize(dt);
            
            return result;

        }
       
        public string CheckRepeat(string ID, string RecordStatus, string val )
        {
            return bll.Exit(ID,  RecordStatus, val ).ToString().ToLower();

        }
        //
        // POST: /Admin/SysMsgInterSet/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            SysMsgInterSet p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<SysMsgInterSet>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<SysMsgInterSet>();

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
                    p = new SysMsgInterSet();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/SysMsgInterSet/Edit/5
        public ActionResult Edit(string id)
        {

            SysMsgInterSet p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new SysMsgInterSet();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/SysMsgInterSet/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
