﻿using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class AdManageController : Controller
    {
        AdManageBll bll = new AdManageBll();
        //
        // GET: /Admin/AdManage/
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
        public string GetListForSelecte(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum, pagesize, ref recordCount );
            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;
        }
        public string CheckRepeat(string ID,  string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID,   RecordStatus, val, IsCode).ToString().ToLower();

        }
        //
        // POST: /Admin/AdManage/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            AdManage p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<AdManage>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<AdManage>();

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
                    p = new AdManage();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/AdManage/Edit/5
        public ActionResult Edit(string id)
        {

            AdManage p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new AdManage();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/AdManage/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
