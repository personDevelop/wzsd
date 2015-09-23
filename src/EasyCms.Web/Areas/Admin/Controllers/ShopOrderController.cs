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
    public class ShopOrderController : Controller
    {
        ShopOrderBll bll = new ShopOrderBll();
        //
        // GET: /Admin/ShopOrder/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(int pagenum, int pagesize, string orderNo, string ShrMc, string AccountName, string StartOrderDate,
            string EndOrderDate, string PayStatus, string ShipStatus, string OrderStatus)
        {
            int recordCount = 0;
            WhereClip where = new WhereClip();
            if (!string.IsNullOrWhiteSpace(orderNo))
            {
                where = ShopOrder._.ID.StartsWith(orderNo);
            }
            if (!string.IsNullOrWhiteSpace(ShrMc))
            {
                where = where && ShopOrder._.ShipName.StartsWith(ShrMc);
            }
            if (!string.IsNullOrWhiteSpace(AccountName))
            {
                where = where && ShopOrder._.MemberName.StartsWith(AccountName);
            }
            DateTime start = DateTime.Now;
            if (StartOrderDate.TryPhrase("yyyy-MM-dd", out start))
            {
                where = where && ShopOrder._.CreateDate >= start;
            }
            if (EndOrderDate.TryPhrase("yyyy-MM-dd", out start))
            {
                where = where && ShopOrder._.CreateDate < start.AddDays(1);
            }
            if (!string.IsNullOrWhiteSpace(PayStatus))
            {
                string[] ps = PayStatus.Split(',');
                if (!ps.Contains(""))
                {
                    where = where && ShopOrder._.PayStatus.In(ps);
                }

            }
            if (!string.IsNullOrWhiteSpace(ShipStatus))
            {
                string[] ps = ShipStatus.Split(',');
                if (!ps.Contains(""))
                {
                    where = where && ShopOrder._.ShipStatus.In(ps);
                }

            }
            if (!string.IsNullOrWhiteSpace(PayStatus))
            {
                string[] ps = PayStatus.Split(',');
                if (!ps.Contains(""))
                {
                    where = where && ShopOrder._.PayStatus.In(ps);
                }

            } if (!string.IsNullOrWhiteSpace(OrderStatus))
            {
                string[] ps = OrderStatus.Split(',');
                if (!ps.Contains(""))
                {
                    where = where && ShopOrder._.OrderStatus.In(ps);
                }

            }
            System.Data.DataTable dt = bll.GetList(pagenum + 1, pagesize, where, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }

        //
        // POST: /Admin/ShopOrder/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopOrder p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<ShopOrder>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopOrder>();

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
                    p = new ShopOrder();

                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/ShopOrder/Edit/5
        public ActionResult Edit(string id)
        {

            ShopOrder p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopOrder();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ShopOrder/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }


        //
        // GET: /Admin/ShopOrder/Edit/5
        public ActionResult PublishToWl(string ids)
        {
            return View("PublishToWl");
        }

        [HttpPost]
        //
        // GET: /Admin/ShopOrder/Edit/5
        public ActionResult Publish(string wlgs, List<string> order)
        {
            return new JsonResult() {  Data="成功" };
        }
    }
}
