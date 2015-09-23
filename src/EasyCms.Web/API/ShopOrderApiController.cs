using EasyCms.Business;
using EasyCms.Model;
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

                try
                {
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
                catch (Exception ex)
                {

                    return ex.Format();
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

                try
                {
                    ManagerUserInfo user = Request.GetAccount();

                    string orderID = new ShopOrderBll().Submit(order, user, out err);
                    if (!string.IsNullOrWhiteSpace(err))
                    {
                        return err.FormatError();

                    }
                    else
                    {
                        return orderID.FormatObj();
                    }
                }
                catch (Exception ex)
                {

                    return ex.Format();
                }
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

            int queryStatus = -1;
            if (!string.IsNullOrWhiteSpace(pageIndex))
            {
                if (!int.TryParse(pageIndex, out queryStatus))
                {
                    queryStatus = -1;
                }
            }

            string err = string.Empty;

            try
            {
                ManagerUserInfo user = Request.GetAccount();

                List<ShopOrder> list = new ShopOrderBll().GetMyOrder(user, queryPage, queryStatus, other, out err);
                if (!string.IsNullOrWhiteSpace(err))
                {
                    return err.FormatError();

                }
                else
                {
                    return list.FormatObjProp(true, ShopOrder._.ID, ShopOrder._.ParentID, ShopOrder._.OrderType,
                ShopOrder._.OrderResId,
                ShopOrder._.PayTypeName,
                ShopOrder._.ExpressCompanyName,
                ShopOrder._.ShipOrderNum,
                ShopOrder._.FreightActual,
                ShopOrder._.ShipStatus,
                ShopOrder._.PayStatus,
                ShopOrder._.OrderStatus,
                ShopOrder._.CommentStatus,
                ShopOrder._.TotalPrice, ShopOrder._.CreateDate, ShopOrderItem._.ID, ShopOrderItem._.OrderID, ShopOrderItem._.BrandName,
                    ShopOrderItem._.Count, ShopOrderItem._.HandselCount, ShopOrderItem._.IsHandsel,
                    ShopOrderItem._.IsVirtualProduct, ShopOrderItem._.MarketPrice,
                    ShopOrderItem._.Price, ShopOrderItem._.Preferential,
                    ShopOrderItem._.ProductID, ShopOrderItem._.ProductCode, ShopOrderItem._.ProductSKU,
                    ShopOrderItem._.ProductName, ShopOrderItem._.ProductThumb, ShopOrderItem._.TotalPrice,
                    ShopOrderItem._.Sequence);
                }
            }
            catch (Exception ex)
            {

                return ex.Format();
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



            try
            {
                ManagerUserInfo user = Request.GetAccount();
                string err = null;
                ShopOrder order = new ShopOrderBll().GetOrder(id, Request.GetAccount().ID, out   err);
                if (!string.IsNullOrWhiteSpace(err))
                {
                    return err.FormatError();

                }
                else
                {
                    return order.FormatObj();
                }

            }
            catch (Exception ex)
            {

                return ex.Format();
            }

        }
    }
}
