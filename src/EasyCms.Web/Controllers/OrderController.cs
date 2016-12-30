
using AliPayCommon;
using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Session;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Controllers
{
    public class OrderController : Controller
    {
       
        [ValidateAntiForgeryToken]
        public ActionResult Index(ShopOrderModel order)
        {
            return CreateOrder(order);

        }

       private ActionResult CreateOrder(ShopOrderModel order,string viewname="index")
        {
            string guid = string.Format("SubmitCheck|{0}|{1}", Guid.NewGuid(), false);
            Session[guid] = "0";
            ViewBag.SubmitCheck = guid;
            string error = string.Empty;
            if (order.OrderItems == null || order.OrderItems.Count == 0)
            {

                error = "请选择要购买的商品";
            }
            else
            {
                string userid = CmsSession.GetUserID();
                order = new ShopOrderBll().CreateOrder(order, "", userid, ActionPlatform.商城网站, out error);
                if (string.IsNullOrWhiteSpace(error))
                {
                    //获取默认地址
                    order.ShopAddress = new ShopShippingAddressBll().GetDefaultShopAddressForShow(userid);
                    //获取促销信息
                    //获取运费,先固定0
                    order.Freight = 0;

                    //获取配送信息  //先不获取了
                    //默认货到付款的支付方式
                    order.CashOnDelivery = true;
                }

            }
            if (string.IsNullOrWhiteSpace(error))
            {
                return View(viewname,order);
            }
            else
            {
                return View("Error", new MessageModel("请重新下单", error, ShowMsgType.warning));
            }
        }
        public ActionResult Buy(string id,string other)
        {
            ShopOrderModel order = new ShopOrderModel() {  OrderItems= new List<OrderItem>()};
            order.OrderItems.Add(new OrderItem() {  BuyCount=1, ProductID=id, Sku= other });
            return CreateOrder(order);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitOrder(ShopOrderModel order)
        {

            string Msg = string.Empty;
            string orderID = string.Empty;
            string SubmitCheck = Request.Form["SubmitCheck"];
            ViewBag.SubmitCheck = SubmitCheck;

            ManagerUserInfo user = null;
            if (string.IsNullOrWhiteSpace(Session[SubmitCheck] as string))
            {
                Msg = "您的订单已失效，请重新到购物车里选择商品再提交订单";

            }
            else
            { 
                user = EasyCms.Session.CmsSession.GetUser();
                if (user == null)
                {
                    Msg = "请先登录红七商城";
                }
                else
                if (order.OrderItems == null || order.OrderItems.Count == 0)
                {
                    Msg = "请选择要购买的商品";
                }
                else
                { 
                    bool mustGenerSign;
                    try
                    {
                        orderID = new ShopOrderBll().Submit(order, user, ActionPlatform.商城网站, out mustGenerSign, out Msg);

                        if (string.IsNullOrWhiteSpace(Msg))
                        { 
                            Session.Remove(SubmitCheck);
                            //删除购物车中的商品
                            WhereClip where = ShopShoppingCarts._.UserId == user.ID && new WhereClip("1=1");
                            foreach (OrderItem item in order.OrderItems)
                            {
                                if (string.IsNullOrWhiteSpace(item.Sku))
                                {
                                    where = where || (ShopShoppingCarts._.ProductId == item.ProductID && ShopShoppingCarts._.SKU.IsNullOrEmpty());
                                }
                                else
                                {
                                    where = where || (ShopShoppingCarts._.ProductId == item.ProductID && ShopShoppingCarts._.SKU == item.Sku);
                                }

                            }
                            new ShopShoppingCartsBll().Delete(where);
                            if (mustGenerSign)
                            {

                                try
                                {
                                    string sHtmlText = new ShopPaymentTypesBll().PayByPc(orderID, out Msg);

                                    if (string.IsNullOrWhiteSpace(Msg))
                                    {
                                        Response.Write(sHtmlText);
                                        Response.End();
                                    }
                                    else
                                    {
                                        return View("Error", new MessageModel() { Msg = "订单支付失败,稍后请到我的订单里再次支付或联系我们的客服,给您带来不便,敬请谅解。", MsgType = ShowMsgType.error, Title = "订单在线支付失败：订单号：" + orderID });

                                    }
                                }
                                catch (Exception ep)
                                {
                                    (SharpLogService.LogClientInstance as ILog).Write(ep, user.ID+ "订单支付失败:" + JsonWithDataTable.Serialize(order));
                                    return View("Error", new MessageModel() { Msg = "订单支付失败,稍后请到我的订单里再次支付或联系我们的客服,给您带来不便,敬请谅解。", MsgType = ShowMsgType.error, Title = "订单在线支付失败：订单号：" + orderID });

                                }

                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        (SharpLogService.LogClientInstance as ILog).Write(ex, user.ID+ "提交订单:" + JsonWithDataTable.Serialize(order));
                        Msg = "系统繁忙,请稍后再试";
                    }
                }

            }
            if (string.IsNullOrWhiteSpace(Msg))
            {
                
                return View("Error", new MessageModel() { Msg = "订单提交成功,请您保持手机畅通，", MsgType = ShowMsgType.success, Title = "订单提交成功：订单号：" + orderID });
            }
            else
            {
                ViewBag.Msg = Msg;
                return View("index", order);
            }


        }
        public void Pay(string id)
        {
            string Msg;
            ManagerUserInfo user =  EasyCms.Session.CmsSession.GetUser();
            if (user == null)
            {
                Msg = "请先登录红七商城";
            }
            try
            {
                string sHtmlText = new ShopPaymentTypesBll().PayByPc(id, out Msg);

                if (string.IsNullOrWhiteSpace(Msg))
                {
                    Response.Write(sHtmlText);
                    Response.End();
                }
                else
                {
                    //return View("Error", new MessageModel() { Msg = "订单支付失败,稍后请到我的订单里再次支付或联系我们的客服,给您带来不便,敬请谅解。", MsgType = ShowMsgType.error, Title = "订单在线支付失败：订单号：" + id });

                }
            }
            catch (Exception ep)
            {
                (SharpLogService.LogClientInstance as ILog).Write(ep, user.ID + "订单支付失败:" );
                //return View("Error", new MessageModel() { Msg = "订单支付失败,稍后请到我的订单里再次支付或联系我们的客服,给您带来不便,敬请谅解。", MsgType = ShowMsgType.error, Title = "订单在线支付失败：订单号：" + id });

            }
            //ViewBag.Msg = Msg;
            //return View();
        }

        public ActionResult PayReturn()
        {
            MessageModel model = new MessageModel();

            string out_trade_no = Request.QueryString["out_trade_no"];

            string trade_no = Request.QueryString["trade_no"];
            string trade_status = Request.QueryString["trade_status"];

            if (trade_status == "TRADE_FINISHED" || trade_status == "TRADE_SUCCESS")
            {
                model.MsgType = ShowMsgType.success;
                model.Msg = "订单支付成功";
                model.Msg = "订单:" + out_trade_no + "支付成功,交易号：" + trade_no;
                new ShopOrderBll().PaySuccess(out_trade_no, trade_no, true);
            }
            else
            {
                model.MsgType = ShowMsgType.error;
                model.Msg = "订单支付失败";
                model.Msg = "订单:" + out_trade_no + "支付失败,交易号：" + trade_no;
            }
            return View("Error", model);
        }

        [HttpPost]
        public string Notify()
        {
            AliAsynchNotify notify = null;
            string returnStr = "success";
            string Result = "";
            string content = "";
            try
            {
                SortedDictionary<string, string> sPara = Core.GetRequestPost(Request, out notify, out content);
                if (sPara.Count > 0)//判断是否有带返回参数
                {
                    //根据订单的订单编号 查找支付方式，然后再获取支付宝的配置参数
                    //这里不能根据sellerid 获取 是因为支付宝的支付方式也分多种
                    //商户订单号
                    string orderID = notify.out_trade_no;
                    if (string.IsNullOrWhiteSpace(orderID))
                    {
                        Result = returnStr = "无订单号";
                        returnStr = "fail";
                    }
                    else
                    {
                        //先根据参数传递过来的值，或者支付宝的配置参数
                        AliPayConfig aliNotify = new ShopShippingTypeBll().GetPayType(orderID, out Result);
                        if (aliNotify == null)
                        {
                            returnStr = "fail";
                        }
                        else
                        {
                            bool verifyResult = true;// Core.VarifySign(sPara, notify.notify_id, notify.sign, aliNotify);

                            if (verifyResult)//验证成功
                            {

                                bool isEist = new AsynchNotifyLogBll().Exit(notify.notify_id, notify.trade_status);
                                if (isEist)
                                {
                                    //处理过该状态  只记录日志 不再操作业务
                                    Result = "处理过该状态";
                                }
                                else
                                {
                                    AliTradeStatus tradestatus = Sharp.Common.EnumPhrase.Phrase<AliTradeStatus>(notify.trade_status);
                                    switch (tradestatus)
                                    {
                                        case AliTradeStatus.WAIT_BUYER_PAY:
                                        case AliTradeStatus.TRADE_CLOSED:
                                        case AliTradeStatus.TRADE_FINISHED:
                                        default:
                                            Result = tradestatus + "不处理";
                                            break;
                                        case AliTradeStatus.TRADE_SUCCESS:
                                            //付款成功
                                            //更新订单的付款状态 和操作日志记录，并发送短信或系统内通知
                                            new ShopOrderBll().PaySuccess(notify.out_trade_no, notify.trade_no, false);
                                            Result = "付款成功";
                                            break;
                                    }

                                }



                                //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                                returnStr = "success";  //请不要修改或删除

                                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            }
                            else//验证失败
                            {
                                returnStr = "fail";
                            }
                        }
                    }

                }
                else
                {
                    Result = returnStr = "无通知参数";
                }

                //生成通知日志
                AsynchNotifyLog Loga = new AsynchNotifyLog()
                {
                    ID = Guid.NewGuid().ToString(),
                    Code = "alipaydirect",
                    Name = "支付宝无线即时到账",
                    CreateTime = DateTime.Now,
                    TradeStatus = notify.trade_status,
                    ResOrderID = notify.out_trade_no,
                    TradeNo = notify.out_trade_no,
                    NodifyID = notify.notify_id,
                    NotifyContent = content,
                    Body = notify.body,
                    ReturnContent = returnStr,
                    Result = Result,

                };
                new AsynchNotifyLogBll().Save(Loga);
                Response.Write(returnStr);
            }
            catch (Exception ex)
            {
                new LogBll().WriteException(ex);
                new LogBll().Write(content);
                throw;
            }
            return "success";
        }

        public JsonResult GetMyOrder(string date,string status)
        {
            string err = null;
            WhereClip where = null;
            if (!string.IsNullOrWhiteSpace(date))
            {
                if (date == "0")
                {
                    where = ShopOrder._.CreateDate >= DateTime.Now.Date.AddMonths(-3);
                }
                else if (date.StartsWith("<"))
                {
                    int year = 0;
                    if (int.TryParse(date.Substring(1), out year))
                    {
                        DateTime d = new DateTime(year, 1, 1);
                        where = ShopOrder._.CreateDate < d;
                    }
                }
                else
                {
                    int year = 0;
                    if (int.TryParse(date , out year))
                    {
                        DateTime d = new DateTime(year, 1, 1);
                        DateTime d2 = new DateTime(year + 1, 1, 1);
                        where = ShopOrder._.CreateDate >= d && ShopOrder._.CreateDate < d2;
                    } 
                } 
            }
            List<ShopOrder> list = new ShopOrderBll().GetMyOrder("", CmsSession.GetUser(), 1, status, "", out err, where);
            return new JsonResult() {  JsonRequestBehavior= JsonRequestBehavior.AllowGet, Data=list};
        }

        public ActionResult Info(string id)
        {
            ShopOrderBll bll = new ShopOrderBll();
               ShopOrderModelInfo order = bll.getDataTable(ShopOrder._.ID== id).ToFirst<ShopOrderModelInfo>();
            string ShipRegion =new AdministrativeRegionsBll().GetPathByID ( order.RegionID).Replace("/", "");
            order.ShipAddress = ShipRegion + order.ShipAddress;
            if (order!=null)
            {
                order.OrderItems = bll.GetOrderDetail(id).ToList<ShopOrderItem>();
                return View(order);
            }
            return View();
        }
    }
}