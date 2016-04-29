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
    public class ShopCountDownController : Controller
    {
        ShopActivityBll bll = new ShopActivityBll();
        //
        // GET: /Admin/ShopCountDown/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(string Name, int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetShopCountDownList(  Name, pagenum.PhrasePageIndex(), pagesize, ref recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }
      
       
        //
        // POST: /Admin/ShopCountDown/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopCountDown p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetShopCountDownEntity(collection["ID"]);
                    p.BindForm<ShopCountDown>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopCountDown>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                    p.CreateDate = DateTime.Now;
                }
                bll.SaveShopCountDown(p);
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
                    p = new ShopCountDown();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/ShopCountDown/Edit/5
        public ActionResult Edit(string id)
        {

            ShopCountDown p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopCountDown();
            }
            else
                p = bll.GetShopCountDownEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ShopCountDown/Delete/5
        public string Delete(string id)
        {
            return bll.DeleteShopCountDown(id);
        }



        //
        // GET: /Admin/ShopGroupBuy/Delete/5
        public ActionResult AddTime(string id, string other = null)
        {
            ShopCountDownTime p = null;
            if (string.IsNullOrWhiteSpace(other) || other.Contains(";"))
            {
                p = new ShopCountDownTime() { ActivityID = id };
                string[] others = other.Split(';');
                p.LoopType = (LoopType)int.Parse(others[1])  ;
            }
            else
            {
                p = bll.GetShopCountTime(other);
            }
            return View("CountDownTime", p);
        }

        public ActionResult SaveTime(FormCollection collection)
        {
            ShopCountDownTime p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetShopCountTime(collection["ID"]);
                    p.BindForm<ShopCountDownTime>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopCountDownTime>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                }
                string msg = bll.SaveShopCountDownTime(p);
                return Json(new { result = string.IsNullOrWhiteSpace(msg), id = p.ID, msg = msg });
            }
            catch (Exception ex)
            {

                return Json(new { result = false, id = p.ID, msg = ex.Message });
            }

        }
        [HttpPost]
        //
        // GET: /Admin/ShopGroupBuy/Delete/5
        public string RemoveIDTime(string id)
        {
            return bll.RemoveIDTime(id);
        }
        [HttpPost]
        //
        // GET: /Admin/ShopGroupBuy/Delete/5
        public string RemoveIDTimeByActivityID(string id)
        {
            return bll.RemoveIDTimeByActivityID(id);
        }
        public string GetSubTimeList(string id)
        {

            System.Data.DataTable dt = bll.GetSubTimeList(id);

            string result = JsonWithDataTable.Serialize(dt);

            return result;
        }

        public string IsQyOrStop(string id, int opcode)
        { return bll.IsQyOrStopCuoutDown(id, opcode); }
    }
}
