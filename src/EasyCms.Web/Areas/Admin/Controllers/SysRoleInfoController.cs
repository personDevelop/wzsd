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
    public class SysRoleInfoController : Controller
    {
        SysRoleInfoBll bll = new SysRoleInfoBll();
        //
        // GET: /Admin/SysRoleInfo/
        public ActionResult Index()
        {

            return View();
        }
        public string GetList()
        {
            System.Data.DataTable dt = bll.GetList();
            return JsonWithDataTable.Serialize(dt);

        }
     
        public string GetListForSelecte( )
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(  true);
            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;
        }
        public string CheckRepeat(string ID, string ParentID, string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID, ParentID, RecordStatus, val, IsCode).ToString().ToLower();

        }
        //
        // POST: /Admin/SysRoleInfo/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            SysRoleInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<SysRoleInfo>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<SysRoleInfo>();

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
                if (collection["IsContinueAdd"] == "1")
                {
                    p = new SysRoleInfo();

                } 


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/SysRoleInfo/Edit/5
        public ActionResult Edit(string id)
        {

            SysRoleInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new SysRoleInfo();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/SysRoleInfo/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
