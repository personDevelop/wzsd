using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Web.Common;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class SystemBrandInfoController : Controller 
    {
        SystemBrandInfoBll bll = new SystemBrandInfoBll();
        //
        // GET: /Admin/SystemBrandInfo/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum + 1, pagesize, ref recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }

        //
        // POST: /Admin/SystemBrandInfo/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            SystemBrandInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<SystemBrandInfo>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<SystemBrandInfo>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                        
                    }
                  
                }
                p.CreateTime = DateTime.Now;
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
                    p = new SystemBrandInfo();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/SystemBrandInfo/Edit/5
        public ActionResult Edit(string id)
        {

            SystemBrandInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new SystemBrandInfo();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/SystemBrandInfo/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
       

    }
}