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
    public class ShopExtendInfoValueController : Controller
    {
        ShopProductTypeBll bll = new ShopProductTypeBll();
        //
        // GET: /Admin/ShopExtendInfoValue/
        public ActionResult Index(string ID)
        {
            ViewData.Add("attriID", ID);
            if (string.IsNullOrEmpty(ID))
            {
                ViewData.Add("ShopExtendInfoEntity", null);
            }
            else
                ViewData.Add("ShopExtendInfoEntity", bll.GetShopExtendInfo(ID));
            return View();
        }

        public string GetList(int pagenum, int pagesize, string attriID)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetValList(attriID, pagenum + 1, pagesize, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }

        //
        // POST: /Admin/ShopExtendInfoValue/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopExtendInfoValue p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetAttrVal(collection["ID"]);
                    p.BindForm<ShopExtendInfoValue>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopExtendInfoValue>();

                }
                bll.SaveAttrVal(p);
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
                    p = new ShopExtendInfoValue();

                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/ShopExtendInfoValue/Edit/5
        public ActionResult Edit(string id)
        {

            ShopExtendInfoValue p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopExtendInfoValue();
            }
            else
                p = bll.GetAttrEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ShopExtendInfoValue/Delete/5
        public string Delete(string id)
        {
            return bll.DeleteAttrVal(id).ToString();
        }
    }
}
