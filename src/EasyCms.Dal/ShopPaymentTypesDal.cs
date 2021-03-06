﻿using AliPayMobileClient;
using AliPayPcClient;
using EasyCms.Model;
using EasyCms.Model.Ali;
using Sharp.Common;
using Sharp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Dal
{
    public class ShopPaymentTypesDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {

            string error = "";
            Dal.Delete("ShopPaymentTypes", "ID", id, out error);
            return error;
        }

        public int Save(ShopPaymentTypes item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<ShopPaymentTypes>().Select(ShopPaymentTypes._.ID, ShopPaymentTypes._.Name).OrderBy(ShopPaymentTypes._.DisplaySequence).ToDataTable();
            }
            else
            {

                DataTable dt = Dal.From<ShopPaymentTypes>().OrderBy(ShopPaymentTypes._.DisplaySequence).ToDataTable();

                return dt;
            }

        }
        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = ShopPaymentTypes._.Name == val;
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopPaymentTypes._.ID != ID;

            }
            return !Dal.Exists<ShopPaymentTypes>(where);
        }

        public ShopPaymentTypes GetEntity(string id)
        {
            return Dal.Find<ShopPaymentTypes>(id);
        }

       

        public DataTable GetPayTypeForSelecte(string ShippingModeId)
        {
            return Dal.From<ShopPaymentTypes>()
                .Join<ShopShippingPayment>(ShopPaymentTypes._.ID== ShopShippingPayment._.PaymentModeId && ShopShippingPayment._.ShippingModeId== ShippingModeId , JoinType.leftJoin)
                .Where(ShopPaymentTypes._.IsEnable == true)
                .OrderBy(ShopPaymentTypes._.DisplaySequence)
                .Select(ShopPaymentTypes._.ID, ShopPaymentTypes._.Gateway,  ShopPaymentTypes._.ShortName, ShopShippingPayment._.ID.Alias("RalationID")).ToDataTable() ;
        }

        public DataTable GetPayType(int payType)
        {
            return Dal.From<ShopPaymentTypes>().Where(ShopPaymentTypes._.IsEnable == true && ShopPaymentTypes._.DrivePath.Contains(payType.ToString()))
                .OrderBy(ShopPaymentTypes._.DisplaySequence)
                .Select(ShopPaymentTypes._.ID, ShopPaymentTypes._.IsDefault,   ShopPaymentTypes._.ShortName).ToDataTable();
        }

        internal string GetPayTypeName(string payTypeID, bool isCashOnDelivery)
        {
            if (isCashOnDelivery)
            {
                return "货到付款";
            }
            return Dal.From<ShopPaymentTypes>().Where(ShopPaymentTypes._.ID == payTypeID).Select(ShopPaymentTypes._.Name)
                .ToScalar() as string;
        }

        public bool GenerPayPara(string orderID, out string error)
        {
            error = string.Empty;
            bool result = true;
            ShopPaymentTypes spay = Dal.From<ShopPaymentTypes>().Join<ShopOrder>(ShopPaymentTypes._.ID == ShopOrder._.PayTypeID).Where(ShopOrder._.ID == orderID)
                     .Select(ShopPaymentTypes._.ID.All).ToFirst<ShopPaymentTypes>();

            if (spay == null)
            {
                error = "当前订单没有支付方式" + orderID;
                result = false;
            }
            else
            {
                ShopOrder order = Dal.From<ShopOrder>().Where(ShopOrder._.ID == orderID).Select(ShopOrder._.PayMoney).ToFirst<ShopOrder>();
                List<ShopOrderItem> list = Dal.From<ShopOrderItem>().Select(ShopOrderItem._.ProductName).Where(ShopOrderItem._.OrderID == orderID).List<ShopOrderItem>();
                string body = string.Empty;
                foreach (var item in list)
                {
                    body += item.ProductName + ";";
                }
                if (string.IsNullOrWhiteSpace(body))
                {
                    body = "购物";
                }
                else body = body.Remove(body.Length - 1);
                AlipayMob apy = new AlipayMob()
                {
                    partner = spay.Partner,
                    notify_url = spay.NotifyUrl,
                    out_trade_no = orderID,
                    subject = body,
                    seller_id = spay.MerchantCode,
                    total_fee = order.PayMoney.ToString(),
                    body = body
                };
                error = apy.GenerSign(spay.SecretKey);
            }


            return result;

        }


        public string PayByPc(string orderID, out string error)
        {
           error = string.Empty;
            string result = string.Empty;
            bool updatePayTYPE = false;
            ShopPaymentTypes spay = Dal.From<ShopPaymentTypes>().Join<ShopOrder>(ShopPaymentTypes._.ID == ShopOrder._.PayTypeID).Where(ShopOrder._.ID == orderID)
                     .Select(ShopPaymentTypes._.ID.All).ToFirst<ShopPaymentTypes>();
            if (spay==null)
            {
                spay = Dal.Find<ShopPaymentTypes>( ShopPaymentTypes._.IsEnable == true && ShopPaymentTypes._.DrivePath.Contains("2") && ShopPaymentTypes._.Name=="支付宝" );
                if (spay!=null)
                {
                    updatePayTYPE = true;
                }

            }
            if (spay == null)
            {
                error = "当前订单没有支付方式" + orderID; 
            }
            else
            {
                ShopOrder order = Dal.From<ShopOrder>().Where(ShopOrder._.ID == orderID).Select(ShopOrder._.PayMoney).ToFirst<ShopOrder>();
                List<ShopOrderItem> list = Dal.From<ShopOrderItem>().Select(ShopOrderItem._.ProductName).Where(ShopOrderItem._.OrderID == orderID).List<ShopOrderItem>();
                string body = string.Empty;
                foreach (var item in list)
                {
                    body += item.ProductName + ";";
                }
                if (string.IsNullOrWhiteSpace(body))
                {
                    body = "购物";
                }
                else body = body.Remove(body.Length - 1);
                AlipayPC apy = new AlipayPC()
                {
                    partner = spay.Partner,
                    notify_url = spay.NotifyUrl,
                     return_url=spay.ReturnUrl, 
                    out_trade_no = orderID,
                    subject = "红七商城订单支付"+ orderID,
                    seller_id = spay.MerchantCode,
                    total_fee = order.PayMoney.ToString(),
                    body = body
                };
                result = apy.GenerSign(spay.SecretKey);
                if (updatePayTYPE)
                {
                    ShopOrder orderUpdate = new ShopOrder() { RecordStatus = StatusType.update, Where = ShopOrder._.ID == orderID, PayTypeID = spay.ID, PayTypeName = spay.Name };
                    Dal.Submit(orderUpdate);
                }
               
            }


            return result;
        }

        public bool GenerPayPara(PayPara payPara, out string error)
        {
            error = string.Empty;
            bool result = true;
            if (string.IsNullOrWhiteSpace(payPara.OrderNo))
            {
                error = "订单编号不能为空";
                result = false;
            }
            else
            {
                string payTypeID = payPara.PayTypeID;
                ShopPaymentTypes spay = null;

                if (string.IsNullOrWhiteSpace(payTypeID))
                {
                    spay = Dal.From<ShopPaymentTypes>().Join<ShopOrder>(ShopPaymentTypes._.ID == ShopOrder._.PayTypeID).Where(ShopOrder._.ID == payPara.OrderNo)
                      .Select(ShopPaymentTypes._.ID.All).ToFirst<ShopPaymentTypes>();
                }
                else
                {

                    spay = Dal.Find<ShopPaymentTypes>(payTypeID);

                }


                if (spay == null)
                {
                    error = "当前订单没有支付方式";
                    result = false;
                }
                else
                {
                    bool isChangePayType = spay.ID != payTypeID;

                    ShopOrder order = Dal.From<ShopOrder>().Where(ShopOrder._.ID == payPara.OrderNo).Select(ShopOrder._.PayMoney,
                        ShopOrder._.ID, ShopOrder._.PayStatus, ShopOrder._.OrderStatus,
                        ShopOrder._.PayTypeID, ShopOrder._.PayTypeName).ToFirst<ShopOrder>();
                    if (order.PayStatus != (int)PayStatus.未付款)
                    {
                        error = "当前订单已经付过款，无须再次付款";
                        result = false;
                    }
                    else
                    {
                        List<ShopOrderItem> list = Dal.From<ShopOrderItem>().Select(ShopOrderItem._.ProductName).Where(ShopOrderItem._.OrderID == payPara.OrderNo).List<ShopOrderItem>();
                        string body = string.Empty;
                        foreach (var item in list)
                        {
                            body += item.ProductName + ";";
                        }
                        if (string.IsNullOrWhiteSpace(body))
                        {
                            body = "购物";
                        }
                        else body = body.Remove(body.Length - 1);
                        AlipayMob apy = new AlipayMob()
                        {
                            partner = spay.Partner,
                            notify_url = spay.NotifyUrl,
                            out_trade_no = payPara.OrderNo,
                            subject = body,
                            seller_id = spay.MerchantCode,
                            total_fee = order.PayMoney.ToString(),
                            body = body
                        };
                        if (isChangePayType)
                        {

                            //生成订单动作日志
                            ShopOrderAction orderAction = new ShopOrderAction()
                            {

                                ID = Guid.NewGuid().ToString(),
                                ActionCode = ActionEnum.付款,
                                ActionName = ActionEnum.付款.ToString(),
                                Username = "支付宝",
                                OrderId = payPara.OrderNo,
                                ActionDate = DateTime.Now,
                                Remark = "客户主动发起修改订单付款方式，旧付款方式为" + order.PayTypeID + " " + order.PayTypeName,
                            };
                            order.PayTypeID = spay.ID;
                            order.PayTypeName = spay.Name;
                            Dal.Submit(orderAction, order);
                        }
                        error = apy.GenerSign(spay.SecretKey);



                    }
                }

            }
            return result;

        }
    }

}
