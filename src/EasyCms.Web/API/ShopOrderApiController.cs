using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Model.Ali;
using EasyCms.Model.ViewModel;
using EasyCms.Web.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace EasyCms.Web.API
{
    public class ShopOrderApiController : BaseAPIControl
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="order">此处订单并不起作用，主要是为了接收其商品明细数据</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CreateOrder([FromBody] ShopOrderModel order)
        {
            if (order.OrderItems == null || order.OrderItems.Count == 0)
            {
                return "请选择要购买的商品".FormatError();
            }
            else
            {
                string err = string.Empty;

                string userid = Request.GetAccountID();
                order = new ShopOrderBll().CreateOrder(order, host, userid, out err);
                if (!string.IsNullOrWhiteSpace(err))
                {
                    return err.FormatError();

                }
                else
                {
                    //获取默认地址
                    order.ShopAddress = new ShopShippingAddressBll().GetDefaultShopAddressForShow(userid);
                    //获取促销信息
                    //获取运费,先固定0
                    order.Freight = 0;

                    //获取配送信息  //先不获取了
                    if (string.IsNullOrWhiteSpace(err))
                    {
                        return order.FormatObj(true, "ShopOrderModel.Freight",
                            "ShopOrderModel.TotalPrice", ShopShippingAddress._.ID.FullName,
                            ShopShippingAddress._.Address.FullName,
                             ShopShippingAddress._.CelPhone.FullName,
                            "OrderItem.ProductID",
                             "OrderItem.Sku",
                              "OrderItem.BuyCount",
                               "OrderItem.IsGifts",
                                "OrderItem.OrderType",
                                 "OrderItem.OrderResId",
                                  "OrderItem.ProductCode",
                                    "OrderItem.ProductName",
                                      "OrderItem.ImgPath",
                                        "OrderItem.MarketPrice",
                                          "OrderItem.SalePrice",
                                            "OrderItem.Point",
                                              "OrderItem.IsVirtualProduct",
    ShopShippingAddress._.IsDefault.FullName,
   ShopShippingAddress._.RegionId.FullName,
    ShopShippingAddress._.Remark.FullName,
   ShopShippingAddress._.ShipName.FullName,
   ShopShippingAddress._.UserId.FullName,
   ShopShippingAddress._.Zipcode.FullName,
                            "ShopPromotionSimpal.ID", "ShopPromotionSimpal.Name", "ShopPromotionSimpal.HandsaleProductName", "ShopPromotionSimpal.HandsaleCouponName", "CouponAccount.ID"
                            , "CouponAccount.Name", "CouponAccount.CardValue", "CouponAccount.CanMutilUse", "CouponAccount.IsCanCombie", "CouponAccount.MinPrice"
                            , "CouponAccount.HaveCount", "CouponAccount.UsingCount", "CouponAccount.CategoryId", "CouponAccount.ProductId", "CouponAccount.ProductSku"



                            );
                    }
                    else
                    {
                        return err.FormatError();
                    }
                }

            }



        }

        /// <summary>
        /// 返回的信息 包含 是否有拆分订单，自动拆分的原则是 团购或者参与促销活动的商品 必须单独一个订单,
        /// 或者包含虚拟产品，也会自动拆分订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PostOrder([FromBody] ShopOrderModel order)
        {
            if (order.OrderItems == null || order.OrderItems.Count == 0)
            {
                return "请选择要购买的商品".FormatError();
            }
            else
            {
                string err = string.Empty;


                ManagerUserInfo user = Request.GetAccount();

                bool mustGenerSign;
                string orderID = new ShopOrderBll().Submit(order, user, out   mustGenerSign, out err);
                if (!string.IsNullOrWhiteSpace(err))
                {
                    return err.FormatError();

                }
                else
                {
                    if (mustGenerSign)
                    {
                        bool isSucess = new ShopPaymentTypesBll().GenerPayPara(orderID, out err);
                        return new { OrderID = orderID, hasSign = isSucess, GateWay = "alipaydirect", Sign = err }.FormatObj();
                    }
                    else
                    {
                        return new { OrderID = orderID, hasSign = false, GateWay = string.Empty, Sign = string.Empty }.FormatObj();
                    }



                }

            }
        }

        [HttpPost]
        public HttpResponseMessage PayOrder([FromBody] PayPara payPara)
        {

            string err = string.Empty;
            bool isSucess = new ShopPaymentTypesBll().GenerPayPara(payPara, out err);
            if (isSucess)
            {
                return new { OrderID = payPara.OrderNo, hasSign = isSucess, GateWay = "alipaydirect", Sign = err }.FormatObj();
            }
            else
            {
                return err.FormatError();

            }



        }
        /// <summary>
        /// 获取我的订单，排序 按照订单时间倒排 
        /// </summary>
        /// <param name="id">页数</param>
        /// <param name="pageIndex">订单状态（-1 查所有状态）</param>
        /// <param name="other">其他where 条件</param>
        /// <returns></returns> 
        public HttpResponseMessage GetOrders(int id = 1, string pageIndex = "", string other = "")
        {
            int queryPage = id;

            if (queryPage == 0)
            {
                queryPage = 1;
            }



            string err = string.Empty;


            ManagerUserInfo user = Request.GetAccount();

            List<ShopOrder> list = new ShopOrderBll().GetMyOrder(host, user, queryPage, pageIndex, other, out err);
            if (!string.IsNullOrWhiteSpace(err))
            {
                return err.FormatError();

            }
            else
            {
                return list.FormatObj(true, ShopOrder._.ID.FullName, ShopOrder._.ParentID.FullName, ShopOrder._.OrderType.FullName,
            ShopOrder._.OrderResId.FullName,
            ShopOrder._.PayTypeName.FullName,
            ShopOrder._.ExpressCompanyName.FullName,
            ShopOrder._.ShipOrderNum.FullName,
            ShopOrder._.FreightActual.FullName,
            "ShopOrder.ShipStatusStr",
            ShopOrder._.ShipStatus.FullName,
              "ShopOrder.PayStatusStr",
            ShopOrder._.PayStatus.FullName,
                 "ShopOrder.OrderStatusStr",
            ShopOrder._.OrderStatus.FullName,
                "ShopOrder.CommentStatusStr",
            ShopOrder._.CommentStatus.FullName,
            ShopOrder._.TotalPrice.FullName, ShopOrder._.Discount.FullName, ShopOrder._.CreateDate.FullName, ShopOrderItem._.ID.FullName, ShopOrderItem._.OrderID.FullName, ShopOrderItem._.BrandName.FullName,
                ShopOrderItem._.Count.FullName, ShopOrderItem._.HandselCount.FullName, ShopOrderItem._.IsHandsel.FullName,
                ShopOrderItem._.IsVirtualProduct.FullName, ShopOrderItem._.MarketPrice.FullName,
                ShopOrderItem._.Price.FullName, ShopOrderItem._.Preferential.FullName,
                ShopOrderItem._.ProductID.FullName, ShopOrderItem._.ProductCode.FullName, ShopOrderItem._.ProductSKU.FullName,
                ShopOrderItem._.ProductName.FullName, ShopOrderItem._.ProductThumb.FullName, ShopOrderItem._.TotalPrice.FullName,
                ShopOrderItem._.Sequence.FullName);
            }


        }

        /// <summary>
        /// 获取我的订单，排序 按照订单时间倒排 
        /// </summary>
        /// <param name="id">页数</param>
        /// <param name="pageIndex">订单状态（-1 查所有状态）</param>
        /// <param name="other">其他where 条件</param>
        /// <returns></returns> 
        public HttpResponseMessage GetOrder(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                return "订单编号不能为空".FormatError();
            }


            ManagerUserInfo user = Request.GetAccount();
            string err = null;
            ShopOrder order = new ShopOrderBll().GetOrder(host, id, user.ID, out   err);
            if (!string.IsNullOrWhiteSpace(err))
            {
                return err.FormatError();

            }
            else
            {
                return order.FormatObj(false, ShopOrder._.ParentID.FullName, ShopOrder._.HasChildren.FullName, ShopOrder._.MemberID
                    .FullName, ShopOrder._.MemberName.FullName, ShopOrder._.MemberEmail.FullName, ShopOrder._.MemberCallPhone.FullName, ShopOrder._.RegionID.FullName, ShopOrder._.ShipZip.FullName,
                    ShopOrder._.ShipEmail.FullName, ShopOrder._.ShipModeID
                    .FullName, ShopOrder._.ShipModeName.FullName, ShopOrder._.PayTypeGateWay.FullName,
                    ShopOrder._.PayTypeID.FullName, ShopOrder._.ExpressCompanyID.FullName,
                    ShopOrder._.FreightAdjust.FullName,
                    ShopOrder._.FreightActual.FullName, ShopOrder._.Weight
                    .FullName, ShopOrder._.CostPrice.FullName,
                    ShopOrder._.PayMoney.FullName, ShopOrder._.OrderPoint.FullName, ShopOrder._.ReturnMoney.FullName,
                    ShopOrder._.SellerID.FullName, ShopOrder._.SellerName.FullName, ShopOrder._.SellerEmail.FullName, ShopOrder._.SellerPhone.FullName, ShopOrder._.SupplierID
                    .FullName, ShopOrder._.SupplierName.FullName, ShopOrder._.OrderIP
                     .FullName, ShopOrder._.SpecifiedDate.FullName, ShopOrder._.ExportCount.FullName,
                     ShopOrder._.HasDelete.FullName, ShopOrder._.ClientType.FullName, ShopOrder._.PublishDateTime.FullName
                      , ShopOrderItem._.ReturnCount.FullName, ShopOrderItem._.UseJf.FullName, ShopOrderItem._.CostPrice.FullName,
                      ShopOrderItem._.ReturnMoney.FullName, ShopOrderItem._.ProductType.FullName,
                      ShopOrderItem._.Point.FullName, ShopOrderItem._.SupplierName.FullName, ShopOrderItem._.RegionName.FullName, ShopOrderItem._.ShortDescription.FullName
                       );
            }



        }


        public HttpResponseMessage GetOrderStatus(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return "订单编号不能为空".FormatError();
            }




            ManagerUserInfo user = Request.GetAccount();
            string err = null;
            DataTable dt = new ShopOrderBll().GetOrderStatus(id, Request.GetAccount(false).ID, out   err);
            if (!string.IsNullOrWhiteSpace(err))
            {
                return err.FormatError();

            }
            else
            {
                return dt.Format();
            }


        }


        [HttpGet]
        public HttpResponseMessage CancleOrder(string id)
        {
            string error;
            string accountid = Request.GetAccountID();
            int isSucess = new ShopOrderBll().CancleOrder(accountid, id, out error);
            switch (isSucess)
            {
                case 0:
                    return error.FormatError();
                default:
                    return new { Msg = error, Code = isSucess }.FormatObj();
            }


        }
        [HttpGet]
        public HttpResponseMessage Delete(string id)
        {
            string err;

            bool result = new ShopShippingAddressBll().UserDelete(Request.GetAccountID(), id, out err);
            return err.Format(result);
        }

        public HttpResponseMessage PaySuccess([FromBody] ReciveForm rf)
        {
            string err = string.Empty;
            bool isSucess = new ShopOrderBll().PaySuccess(rf.Data, out err);
            return err.Format(isSucess);
        }

        public HttpResponseMessage ReturnOrder([FromBody] ShopReturnOrder ro)
        {
            string error;
            string accountid = Request.GetAccountID();
            bool isSucess = new ShopReturnOrderBll().ReturnOrder(accountid, ro, out error);
            if (isSucess)
            {
                return new { Msg = "已提交退货申请，请您耐心等待", ReturnOrderID = error }.FormatObj();

            }
            else
            {
                return error.FormatError();
            }

        }



        /// <summary>
        /// 获取可退商品列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetCanReturnDetail(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                return "订单编号不能为空".FormatError();
            }

            DataTable dt = new ShopOrderBll().GetCanReturnDetail(host, id);
            return dt.Format();
        }


        public HttpResponseMessage GetReturnOrders(int id = 1, string pageIndex = "", string other = "")
        {
            int queryPage = id;

            if (queryPage == 0)
            {
                queryPage = 1;
            }



            string err = string.Empty;


            ManagerUserInfo user = Request.GetAccount();

            List<ShopReturnOrder> list = new ShopOrderBll().GetMyReturnOrders(host, user, queryPage, pageIndex, other, out err);
            if (!string.IsNullOrWhiteSpace(err))
            {
                return err.FormatError();

            }
            else
            {
                return list.FormatObj(true, ShopReturnOrder._.ID.FullName, ShopReturnOrder._.OrderId.FullName, ShopReturnOrder._.CreatedDate.FullName,
                ShopReturnOrder._.Description.FullName,
                ShopReturnOrder._.ReturnType.FullName,
                ShopReturnOrder._.Status.FullName,
                ShopReturnOrder._.RefuseReason.FullName, "ShopReturnOrder.StatusStr", ShopReturnOrderItem._.ID.FullName, ShopReturnOrderItem._.OrderId.FullName, ShopReturnOrderItem._.ReturnOrderId.FullName,
                    ShopReturnOrderItem._.SaleCount.FullName, ShopReturnOrderItem._.RequestQuantity.FullName, ShopReturnOrderItem._.ReturnCount.FullName,
                    ShopReturnOrderItem._.SellPrice.FullName,
                  ShopReturnOrderItem._.ProductCode.FullName,
                    ShopReturnOrderItem._.Name.FullName, "ShopReturnOrderItem.ProductThumb");
            }


        }

        /// <summary>
        /// 获取我的订单，排序 按照订单时间倒排 
        /// </summary>
        /// <param name="id">页数</param>
        /// <param name="pageIndex">订单状态（-1 查所有状态）</param>
        /// <param name="other">其他where 条件</param>
        /// <returns></returns> 
        public HttpResponseMessage GetReturnOrder(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                return "订单编号不能为空".FormatError();
            }


            ManagerUserInfo user = Request.GetAccount();
            string err = null;
            ShopReturnOrder order = new ShopOrderBll().GetReturnOrder(host, id, user.ID, out   err);
            if (!string.IsNullOrWhiteSpace(err))
            {
                return err.FormatError();

            }
            else
            {
                return order.FormatObj(true, ShopReturnOrder._.ID.FullName, ShopReturnOrder._.OrderId.FullName, ShopReturnOrder._.CreatedDate.FullName,
                ShopReturnOrder._.Description.FullName,
                ShopReturnOrder._.ReturnType.FullName,
                ShopReturnOrder._.Status.FullName,
                ShopReturnOrder._.RefuseReason.FullName, "ShopReturnOrder.StatusStr", ShopReturnOrderItem._.ID.FullName, ShopReturnOrderItem._.OrderId.FullName, ShopReturnOrderItem._.ReturnOrderId.FullName,
                    ShopReturnOrderItem._.SaleCount.FullName, ShopReturnOrderItem._.RequestQuantity.FullName, ShopReturnOrderItem._.ReturnCount.FullName,
                    ShopReturnOrderItem._.SellPrice.FullName,
                  ShopReturnOrderItem._.ProductCode.FullName,
                    ShopReturnOrderItem._.Name.FullName, "ShopReturnOrderItem.ProductThumb");
            }



        }
    }
}
