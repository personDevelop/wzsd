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
    public class ShopExtendInfoValueController : BaseControler
    {
        ShopProductTypeBll bll = new ShopProductTypeBll();
        //
        // GET: /Admin/ShopExtendInfoValue/
        public ActionResult Index(string ID)
        {

            if (string.IsNullOrEmpty(ID))
            {
                ViewData.Add("ShopExtendInfoEntity", null);
            }
            else
                ViewData.Add("ShopExtendInfoEntity", bll.GetShopExtendInfo(ID));
            return View();
        }

        public string GetList(string attriID)
        {
          
            System.Data.DataTable dt = bll.GetValList(host,attriID);

            string result = JsonWithDataTable.Serialize(dt);
            //result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
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

                p.ShopExtendInfo = bll.GetShopExtendInfo(collection["AttributeId"]);
                bll.SaveAttrVal(p);
                ModelState.Clear();
                if (TempData.ContainsKey("IsSuccess"))
                {
                    TempData["IsSuccess"] = "保存成功";

                }
                else
                {
                    TempData.Add("IsSuccess", "保存成功");
                }
               
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
        public ActionResult Edit(string id, string other)
        {
            string attrid = other;
            ShopExtendInfoValue p = null;
         
            if (string.IsNullOrWhiteSpace(id) || id == "new")
            {
                p = new ShopExtendInfoValue();
                p.AttributeId = other;

            }
            else
            {
                p = bll.GetAttrEntity(id);
                attrid = p.AttributeId;
            }
            p .ShopExtendInfo= bll.GetShopExtendInfo(attrid);
            ViewBag.indexid = attrid;
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ShopExtendInfoValue/Delete/5
        public string Delete(string id)
        {
            string result = "";
            bll.DeleteAttrVal(id, out result);
            return result;
        }

        public string CheckRepeat(string ID, string AttributeId, string RecordStatus, string val )
        {
            return bll.Exit(ID, AttributeId, RecordStatus, val ).ToString().ToLower();

        }
       
    }
}
