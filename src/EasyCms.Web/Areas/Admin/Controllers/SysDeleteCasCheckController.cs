﻿using EasyCms.Business;
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
    public class SysDeleteCasCheckController : Controller
    {
        SysDeleteCasCheckBll bll = new SysDeleteCasCheckBll();
        //
        // GET: /Admin/SysDeleteCasCheck/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum.PhrasePageIndex(), pagesize, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }
         
        //
        // POST: /Admin/SysDeleteCasCheck/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            SysDeleteCasCheck p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<SysDeleteCasCheck>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<SysDeleteCasCheck>();

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
                if (collection["IsContinueAdd"] == "1")
                {
                    p = new SysDeleteCasCheck();

                } 

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/SysDeleteCasCheck/Edit/5
        public ActionResult Edit(string id)
        {

            SysDeleteCasCheck p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new SysDeleteCasCheck();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/SysDeleteCasCheck/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
