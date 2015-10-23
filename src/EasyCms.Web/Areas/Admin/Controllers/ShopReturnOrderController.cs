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
    public class ShopReturnOrderController : Controller
    {
        ShopReturnOrderBll bll = new ShopReturnOrderBll();
        //
        // GET: /Admin/ShopReturnOrder/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(int pagenum, int pagesize, string returnOrderNo, string orderNo, string ShrMc, string ShrTel, string AccountName, string StartOrderDate,
            string EndOrderDate, string PayStatus, string ShipStatus, string OrderStatus)
        {
            int recordCount = 0;
            WhereClip where = new WhereClip();
            if (!string.IsNullOrWhiteSpace(returnOrderNo))
            {
                where = ShopReturnOrder._.ID.StartsWith(orderNo);
            }
            if (!string.IsNullOrWhiteSpace(orderNo))
            {
                where = ShopReturnOrder._.OrderId.StartsWith(orderNo);
            }
            if (!string.IsNullOrWhiteSpace(ShrMc))
            {
                where = where && ShopReturnOrder._.ContactName.StartsWith(ShrMc);
            }
            if (!string.IsNullOrWhiteSpace(AccountName))
            {
                where = where && ShopReturnOrder._.UserName.StartsWith(AccountName);
            }
            if (!string.IsNullOrWhiteSpace(ShrTel))
            {
                where = where && ShopReturnOrder._.PickTelPhone.StartsWith(ShrTel);
            }
            DateTime start = DateTime.Now;
            if (StartOrderDate.TryPhrase("yyyy-MM-dd", out start))
            {
                where = where && ShopReturnOrder._.CreatedDate >= start;
            }
            if (EndOrderDate.TryPhrase("yyyy-MM-dd", out start))
            {
                where = where && ShopReturnOrder._.CreatedDate < start.AddDays(1);
            }
            if (!string.IsNullOrWhiteSpace(PayStatus))
            {
                string[] ps = PayStatus.Split(',');
                if (!ps.Contains(""))
                {
                    where = where && ShopReturnOrder._.ReturnMoneyStatus.In(ps);
                }

            }
            if (!string.IsNullOrWhiteSpace(ShipStatus))
            {
                string[] ps = ShipStatus.Split(',');
                if (!ps.Contains(""))
                {
                    where = where && ShopReturnOrder._.LogisticStatus.In(ps);
                }

            }
            if (!string.IsNullOrWhiteSpace(OrderStatus))
            {
                string[] ps = OrderStatus.Split(',');
                if (!ps.Contains(""))
                {
                    where = where && ShopReturnOrder._.Status.In(ps);
                }

            }
            System.Data.DataTable dt = bll.GetList(pagenum + 1, pagesize, where, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }

        public string GetReturnDetail(string returnOrderNo)
        {
            int recordCount = 0;

            System.Data.DataTable dt = bll.GetReturnDetail(returnOrderNo);

            string result = JsonWithDataTable.Serialize(dt);
            
            return result;

        }


        //
        // GET: /Admin/ShopOrder/Edit/5
        public ActionResult Edit(string id)
        {

            ShopReturnOrder p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopReturnOrder();
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
        public ActionResult PublishToWl(ActionEnum id, string other)
        {
            ViewResult v = View("PublishToWl");

            switch (id)
            {
                case ActionEnum.创建订单:
                    break;
                case ActionEnum.付款:
                    break;
                case ActionEnum.发货:
                    ViewBag.Title = "发货到物流";
                    break;
                case ActionEnum.签收:
                    ViewBag.Title = "客户已签收订单";
                    break;
                case ActionEnum.申请退货:
                    break;
                case ActionEnum.不同意退货:
                    break;
                case ActionEnum.同意退货:
                    break;
                case ActionEnum.完成退货:
                    break;
                case ActionEnum.完成退款:
                    break;
                case ActionEnum.申请取消订单:
                    break;
                case ActionEnum.取消订单:
                    break;
                case ActionEnum.快递中转:
                    break;
                case ActionEnum.导出订单:
                    break;
                case ActionEnum.拒收:
                    ViewBag.Title = "客户已拒收订单";
                    break;
                case ActionEnum.作废:
                    ViewBag.Title = "作废订单";
                    break;
                default:
                    break;
            }
            v.ViewBag.Action = id;
            v.ViewBag.OrderIDS = other;
            return v;
        }

        [HttpPost]
        //
        // GET: /Admin/ShopOrder/Edit/5
        public ActionResult ExeAction(ActionEnum actionID, string wlgs, List<string> orderIDs)
        {
            string err = string.Empty;
            //Dictionary<string, string> result = bll.ExeAction(actionID, wlgs, orderIDs, out err);
            //if (string.IsNullOrWhiteSpace(err))
            //{
            //    return result.FormatJsonResult();

            //}
            //else
            return err.FormatErrorJsonResult();
        }
    }
}
