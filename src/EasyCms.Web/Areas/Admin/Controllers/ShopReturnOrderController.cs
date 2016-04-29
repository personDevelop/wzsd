using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using EasyCms.Web.Common;
using EasyCms.Session;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class ShopReturnOrderController : BaseControler
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
            System.Data.DataTable dt = bll.GetList(pagenum.PhrasePageIndex(), pagesize, where, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }

        public ActionResult Export( string returnOrderNo, string orderNo, string ShrMc, string ShrTel, string AccountName, string StartOrderDate,
          string EndOrderDate, string PayStatus, string ShipStatus, string OrderStatus)
        {
            
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


            return Server.FormatExportExcleJsonResult(StaticValue.ExportReturnOrder, where, "   ShopOrder.CreateDate desc");

        }

        public string GetReturnDetail(string id)
        {

            System.Data.DataTable dt = bll.GetReturnDetail(host, id);

            string result = JsonWithDataTable.Serialize(dt);

            return result;

        }
        public string GetReturnRoute(string id)
        {
            System.Data.DataTable dt = bll.GetReturnRoute(id);

            string result = JsonWithDataTable.Serialize(dt);

            return result;

        }

        //
        // GET: /Admin/ShopOrder/Edit/5
        public ActionResult Edit(string id, UserDjStatus other)
        {

            ShopReturnOrder p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("退货单单号不能为空");

            }
            else
                p = bll.GetEntity(id);
            ViewResult v = View("Edit", p);
            v.ViewBag.DjStatus = other;
            return v;
        }

        [HttpPost]
        //
        // GET: /Admin/ShopOrder/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }


        [HttpPost]
        [ValidateInput(false)]
        //
        // GET: /Admin/ShopOrder/Edit/5
        public JsonResult ExeAction(FormCollection collection)
        {
            string err = string.Empty;
            //接收动作
            string action = collection["SubmitActionType"];
            ActionEnum ae = ActionEnum.作废;
            switch (action)
            {

                case "1"://审批通过
                    ae = ActionEnum.同意退货;
                    break;
                case "2"://审批不通过
                    ae = ActionEnum.不同意退货;
                    break;
                case "3"://确认取货
                    ae = ActionEnum.完成取货;
                    break;
                case "4"://确认退款
                    ae = ActionEnum.完成退款;
                    break;
            }
            if (ae == ActionEnum.作废)
            {
                return "没有指定的操作".FormatErrorJsonResult();
            }
            else
            {
                //获取退货单ID  //获取退款金额  //获取取货地址
                string id = collection["ID"] as string;
                string ReturnMoney = collection["ReturnMoney"] as string;
                string IsShopReviceGood = collection["IsShopReviceGood"] as string;
                string RefuseReason = collection["RefuseReason"] as string;
                string ContactName = collection["ContactName"] as string;
                string PickTelPhone = collection["PickTelPhone"] as string;
                string PickAddress = collection["PickAddress"] as string;
                string PickRegionID = collection["PickRegionID"] as string;

                bool issucess = bll.ExeAction(ae, CmsSession.GetUserID(),CmsSession.GetUserName(), id, ReturnMoney, IsShopReviceGood, RefuseReason, ContactName, PickTelPhone, PickAddress, PickRegionID, out err);
                if (issucess)
                {

                    return (ae.ToString() + "操作成功").FormatJsonResult();
                }
                else
                { return err.FormatErrorJsonResult(); }
                
            }

        }
    }
}
