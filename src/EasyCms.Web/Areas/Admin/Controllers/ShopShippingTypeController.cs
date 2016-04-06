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
    public class ShopShippingTypeController : Controller
    {
        ShopShippingTypeBll bll = new ShopShippingTypeBll();
        //
        // GET: /Admin/ShopShippingType/
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
        public string CheckRepeat(string ID, string RecordStatus, string val )
        {
            return bll.Exit(ID,  RecordStatus, val ).ToString().ToLower();

        }
        //
        // POST: /Admin/ShopShippingType/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopShippingType p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<ShopShippingType>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopShippingType>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                    
                }
                //获取支付方式
                List<string> producTypeList = new List<string>();
                foreach (string item in collection.Keys)
                {
                    if (item.StartsWith("spt"))
                    {
                        string ptID = item.Substring(3);
                        if (!string.IsNullOrWhiteSpace(ptID))
                        {
                            producTypeList.Add(ptID);
                        }

                    }
                }
                List<ShopRegionFright> list= collection.BindList<ShopRegionFright>();
                bll.Save(p, producTypeList,list);
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
                    p = new ShopShippingType();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/ShopShippingType/Edit/5
        public ActionResult Edit(string id)
        {

            ShopShippingType p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopShippingType();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ShopShippingType/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }

       
        //
        // GET: /Admin/ShopShippingType/Delete/5
        public string GetShopRegionFrightList(string id)
        {
   return  JsonWithDataTable.Serialize(bll.GetShopRegionFrightList(id));
        }

        
    }
}
