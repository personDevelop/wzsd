using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using EasyCms.Web.Common;
using System.Data;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class ShopPaymentTypesController : Controller
    {
        ShopPaymentTypesBll bll = new ShopPaymentTypesBll();
        //
        // GET: /Admin/ShopPaymentTypes/
        public ActionResult Index()
        {

            return View();
        }
        public string GetList()
        {
            System.Data.DataTable dt = bll.GetList();
            DataColumn dc = new DataColumn("GatewayName");
            dt.Columns.Add(dc);
            List<Gataway> list = GatawayConfig.GetAllGataway();
            foreach (DataRow item in dt.Rows)
            {
                string gateway = item["Gateway"] as string;
                if (list.Exists(p => p.name == gateway))
                {
                    item["GatewayName"] = list.Find(p => p.name == gateway).displayName;
                } 
            }
            dt.AcceptChanges();
            return JsonWithDataTable.Serialize(dt);

        }

        public string GetListForSelecte(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(true);
            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;
        }
        public string CheckRepeat(string ID, string ParentID, string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID, ParentID, RecordStatus, val, IsCode).ToString().ToLower();

        }
        //
        // POST: /Admin/ShopPaymentTypes/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopPaymentTypes p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<ShopPaymentTypes>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopPaymentTypes>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }

                }
                p.DrivePath = string.Empty;
                if ( collection["DrivePath1"] == "on")
                {
                    p.DrivePath = "1";
                }
                if (collection["DrivePath2"] == "on")
                {
                    p.DrivePath += "|2";
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
        // GET: /Admin/ShopPaymentTypes/Edit/5
        public ActionResult Edit(string id)
        {

            ShopPaymentTypes p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopPaymentTypes();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ShopPaymentTypes/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
