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
    public class ShopGroupBuyController : Controller
    {
        ShopActivityBll bll = new ShopActivityBll();
        //
        // GET: /Admin/ShopGroupBuy/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(string Name, int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(Name, pagenum + 1, pagesize, ref recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }
       
        //
        // POST: /Admin/ShopGroupBuy/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopGroupBuy p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<ShopGroupBuy>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopGroupBuy>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                    p.CreateDate = DateTime.Now;
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
                    p = new ShopGroupBuy();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/ShopGroupBuy/Edit/5
        public ActionResult Edit(string id)
        {

            ShopGroupBuy p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopGroupBuy();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ShopGroupBuy/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }

     
        //
        // GET: /Admin/ShopGroupBuy/Delete/5
        public ActionResult AddProduct(string id, string other = null)
        {
            ShopCountProducnt p = null;
            if (string.IsNullOrWhiteSpace(other) || other.Length<10)
            {
                p = new ShopCountProducnt() { ActivityID = id };

            }
            else
            {
                p = bll.GetShopCountProducnt(other);
            }
            return View("SelectProductCard", p); 
        }

        public ActionResult SaveProduct(FormCollection collection)
        {
            ShopCountProducnt p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetShopCountProducnt(collection["ID"]);
                    p.BindForm<ShopCountProducnt>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopCountProducnt>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    } 
                }
             string msg=   bll.SaveShopCountProducnt(p);
                return Json(new { result = string.IsNullOrWhiteSpace(msg), id=p.ID, msg = msg }); 
            }
            catch (Exception ex)
            {
              
                return Json(new { result = false, id = p.ID, msg = ex.Message });
            }
           
        }
        [HttpPost]
        //
        // GET: /Admin/ShopGroupBuy/Delete/5
        public string RemoveIDProduct(string id)
        {
            return  bll.RemoveIDProduct(id);
        }

        public string GetSubList(string id)
        {
         
            System.Data.DataTable dt = bll.GetSubList(id);

            string result = JsonWithDataTable.Serialize(dt);
          
            return result;
        }

        public string IsQyOrStop(string id,int opcode)
        { return bll.IsQyOrStop(id,   opcode); }
    }
}
