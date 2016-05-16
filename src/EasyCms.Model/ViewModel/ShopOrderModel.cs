using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model
{
    /// <summary>
    /// app提交时，得分三步
    /// 第一步，预提交：主要是根据选择的商品信息，返回促销活动（这个主要是提示作用，不参与金额计算），和可用的优惠券列表，
    /// app端 根据客户选择使用的优惠券 计算实际订单金额。
    /// 第二步，真正提交：提交成功后， 返回的字段包括  
    ///            是否成功、
    ///            支付方式是否是立即付款（如果时，调用相应的支付接口）、
    ///            对应的支付接口码（如果是立即支付，返回一个事先商定的支付接口码，调用不同的支付接口）
    /// 第三步 （只有需要支付的才会有）
    ///        调用相应的支付接口后，根据支付结果，通知服务端支付结果
    /// </summary>
    [Newtonsoft.Json.JsonObject]
    public class ShopOrderModel
    {
        /// <summary>
        /// 是否是货到付款
        /// </summary>
        public bool CashOnDelivery { get; set; }
        /// <summary>
        /// 支付方式ID
        /// </summary>
        public string PayTypeID { get; set; }

        /// <summary>
        /// 订单邮寄地址，提交订单时传递
        /// </summary>
        public string AddressID { get; set; }

        /// <summary>
        /// 是否使用发票
        /// </summary>
        public bool IsInvoice { get; set; }
        /// <summary>
        /// 发票填写客户名称,
        /// </summary> 
        public string InvoiceInfo { get; set; }
        /// <summary>
        /// 发票说明 比如 发票打印明细  是否增值税发票  发票内容 等等 可以在这里填写
        /// </summary>
        public string InvoiceNote { get; set; }

        /// <summary>
        /// 运费
        /// </summary>
        public decimal Freight { get; set; } 
        /// <summary>
        /// 使用余额数
        /// </summary>
        public decimal UserBalance { get; set; }
        /// <summary>
        /// 总价格   (商品总价格-优惠券金额) 不包含运费
        /// </summary>
        public decimal TotalPrice { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// 收货地址，生成订单时，返回给前台
        /// </summary>
        public ShopShippingAddress ShopAddress { get; set; }
         [JsonIgnore]
        List<ShopPromotionSimpal> _Promotion;
        public List<ShopPromotionSimpal> Promotion
        {
            get { return _Promotion; }
            set
            {
                if (value != null && value.Count == 1 && string.IsNullOrWhiteSpace(value[0].ID))
                {
                    return;
                }

                _Promotion = value;
            }
        }
         [JsonIgnore]
        public List<CouponAccount> _Coupon;
        /// <summary>
        /// 会员本次购买可使用的优惠券
        /// 生成订单时返回所有可用的优惠券
        /// 提交订单时 提供当前订单使用的优惠券
        /// </summary>
        public List<CouponAccount> Coupon
        {
            get { return _Coupon; }
            set
            {
                if (value != null && value.Count == 1 && string.IsNullOrWhiteSpace(value[0].ID))
                {
                    return;
                }

                _Coupon = value;
            }
        }


        /// <summary>
        /// 订单备注
        /// </summary>
        public string Remark { get; set; }
    }
    [Newtonsoft.Json.JsonObject]
    public class OrderItem
    {
        #region 生成订单时需要传递的参数
        /// <summary>
        /// 商品id
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// 商品SKUID
        /// </summary>
        public string Sku { get; set; }
        /// <summary>
        /// 商品购买数量
        /// </summary>
        public decimal BuyCount { get; set; }
        /// <summary>
        /// 是否是赠品
        /// </summary>
        public bool IsGifts { get; set; }
        /// <summary>
        /// 0，普通，1促销，2团购
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 订单对应的销售模式ID,普通订单的为空
        /// 这个就是对应的促销活动ID，这个如果是当前购买的商品符合一定的促销活动，会根据促销活动定价。
        /// </summary>
        public string OrderResId { get; set; }
        #endregion


        #region 返回的参数
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgPath { get; set; }


        /// <summary>
        /// 市场价
        /// </summary>
        public decimal MarketPrice { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 可送积分
        /// </summary>
        public int Point { get; set; }

        /// <summary>
        /// 是否是虚拟产品
        /// </summary>
        public bool IsVirtualProduct { get; set; }

        [JsonIgnore]
        List<ShopPromotionSimpal> _Promotion;
        /// <summary>
        /// 促销活动
        /// </summary>
        public List<ShopPromotionSimpal> Promotion
        {
            get { return _Promotion; }
            set
            {
                if (value != null && value.Count == 1 && string.IsNullOrWhiteSpace(value[0].ID))
                {
                    return;
                }

                _Promotion = value;
            }
        }
        #endregion


        public void AddPromotion(ShopPromotion item)
        {
            if (Promotion == null)
            {
                Promotion = new List<ShopPromotionSimpal>();
            }
            Promotion.Add(new ShopPromotionSimpal() { ID = item.ID, Name = item.RuleName, HandsaleProductName = item.HandProductName, HandsaleCouponName = item.CouponName });
        }
    }
}
