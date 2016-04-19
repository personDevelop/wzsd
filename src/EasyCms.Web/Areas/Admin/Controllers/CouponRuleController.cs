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
    public class CouponRuleController : Controller
    {
        CouponRuleBll bll = new CouponRuleBll();
        //
        // GET: /Admin/CouponRule/
        public ActionResult Index()
        {

            return View();
        }
        public string GetListNotPage()
        {
            System.Data.DataTable dt = bll.GetList();
            return JsonWithDataTable.Serialize(dt);

        }
        public string GetList(string name, int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(  name, pagenum + 1, pagesize, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }
        public string GetListForSelecte(string name, int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(  name, pagenum, pagesize, ref   recordCount, true);
            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;
        }
        public string CheckRepeat(string ID, string RecordStatus, string val)
        {
            return bll.Exit(ID, RecordStatus, val).ToString().ToLower();

        }
        //
        // POST: /Admin/CouponRule/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            CouponRule p = null; ;

           if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<CouponRule>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<CouponRule>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                    p.Createor = Session.GetUserID();
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
                    p = new CouponRule();

                } 

            
            return View("Edit", p);
        }

        //
        // GET: /Admin/CouponRule/Edit/5
        public ActionResult Edit(string id)
        {

            CouponRule p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new CouponRule();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/CouponRule/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
