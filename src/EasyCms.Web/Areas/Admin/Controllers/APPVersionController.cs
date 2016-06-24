using EasyCms.Business;
using EasyCms.Model;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class APPVersionController : Controller
    {
        APPVersionBll bll = new APPVersionBll();
        // GET: Admin/APPVersion
        public ActionResult Index()
        {
            return View();
        }
        public string GetList(string name, int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(name, pagenum.PhrasePageIndex(), pagesize, ref recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }
        public string CheckRepeat(string ID, string RecordStatus, string val,int checkCode)
        {
            return bll.Exit(ID, RecordStatus, val,   checkCode).ToString().ToLower();

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            APPVersion p = null; ;

            if (collection["RecordStatus"] != "add")
            {
                p = bll.GetEntity(collection["ID"]);
                p.BindForm<APPVersion>(collection);
            }
            else
            {
                // TODO: Add insert logic here
                p = collection.Bind<APPVersion>();

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
                p = new APPVersion();

            }


            return View("Edit", p);
        }

        //
        // GET: /Admin/APPVersion/Edit/5
        public ActionResult Edit(string id)
        {

            APPVersion p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new APPVersion();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/APPVersion/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}