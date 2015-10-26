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
    public class ShopOrderController : Controller
    {
        ShopOrderBll bll = new ShopOrderBll();
        //
        // GET: /Admin/ShopOrder/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(int pagenum, int pagesize, string orderNo, string ShrMc, string ShrTel, string AccountName, string StartOrderDate,
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
            if (!string.IsNullOrWhiteSpace(ShrTel))
            {
                where = where && (ShopOrder._.MemberCallPhone.StartsWith(ShrTel) || ShopOrder._.ShipTel.StartsWith(ShrTel));
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
            if (!string.IsNullOrWhiteSpace(OrderStatus))
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

        public string GetForPublishList(string orderNos)
        {

            WhereClip where = new WhereClip();

            where = ShopOrder._.ID.In(orderNos.Split(',').ToArray());


            System.Data.DataTable dt = bll.GetList(where);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + dt.Rows.Count.ToString() + "\",\"data\":" + result + "}";
            return result;

        }

        //
        // POST: /Admin/ShopOrder/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopOrder p = null;
            bool isSuccess = false;
            string err = string.Empty;
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

                bll.Save(p, EasyCms.Session.CmsSession.GetUserID(), CmsSession.GetUserName());
                isSuccess = true;
                err = "保存成功";
            }
            catch (Exception ex)
            {
                err = ex.Message + ex.StackTrace;
                new LogBll().WriteException(ex, EasyCms.Session.CmsSession.GetUserID());

            }
            if (isSuccess)
            {

                return err.FormatJsonResult();
            }
            else
            { return err.FormatErrorJsonResult(); }
        }

        //
        // GET: /Admin/ShopOrder/Edit/5
        public ActionResult Edit(string id, int other)
        {



            ShopOrder p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopOrder();
                throw new Exception("订单号不能为空");
            }
            else
                p = bll.GetEntity(id);
            ViewResult v = View("Edit", p);
            v.ViewBag.action = other;
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
            string err;
            Dictionary<string, string> result = bll.ExeAction(actionID, wlgs, orderIDs,CmsSession.GetUserID(), CmsSession.GetUserName(), out err);
            if (string.IsNullOrWhiteSpace(err))
            {
                return result.FormatJsonResult();

            }
            else
                return err.FormatErrorJsonResult();
        }

        public string GetOrderDetail(string id)
        {


            System.Data.DataTable dt = bll.GetOrderDetail(id);

            string result = JsonWithDataTable.Serialize(dt);
            return result;
        }
    }
}
