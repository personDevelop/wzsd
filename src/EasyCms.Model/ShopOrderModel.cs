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
    public class ShopOrderModel
    {
        /// <summary>
        /// 0，普通，1促销，2团购
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 订单对应的销售模式ID,普通订单的为空
        /// 这个就是对应的促销活动ID，这个如果是当前购买的商品符合一定的促销活动，会根据促销活动定价。
        /// </summary>
        public string OrderResId { get; set; }

        /// <summary>
        /// 使用优惠券ID
        /// </summary>
        public string UsingCouponsID { get; set; }

        /// <summary>
        /// 收件人地址ID
        /// </summary>
        public string AddressID { get; set; }
        /// <summary>
        /// 支付方式ID
        /// </summary>
        public string PayTypeID { get; set; }

        /// <summary>
        /// 是否使用发票
        /// </summary>
        public string IsInvoice { get; set; }
        /// <summary>
        /// 发票填写客户名称,
        /// </summary> 
        public string InvoiceInfo { get; set; }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string Remark { get; set; }


        /// <summary>
        /// 运费
        /// </summary>
        public decimal Freight { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        public ShopShippingAddress ShopAddress { get; set; }

        /// <summary>
        /// 会员本次购买可使用的优惠券
        /// </summary>
        public List<ShopShippingAddress> AccountCoupon { get; set; }


        /// <summary>
        /// 可送积分,再总订单金额的基础上 看是否有满足情况的送积分规则
        /// </summary>
        public int Point { get; set; }

        public List<ShopPromotionSimpal> Promotion { get; set; }

        /// <summary>
        /// 赠送优惠券
        /// </summary>
        public List<CouponAccount> Coupon { get; set; }
    }

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

        public List<ShopPromotionSimpal> Promotion { get; set; }

        /// <summary>
        /// 赠送优惠券
        /// </summary>
        public List<CouponAccount> Coupon { get; set; }
        #endregion




        public void AddPromotion(ShopPromotion item)
        {
            if (Promotion == null)
            {
                Promotion = new List<ShopPromotionSimpal>();
            }
            Promotion.Add(new ShopPromotionSimpal() { ID = item.ID, Name = item.RuleName, HandsaleProductName = item.HandProductName, HandsaleCouponName = item.CouponName });
        }

        public void AddCoupon(CouponAccount item)
        {
            throw new NotImplementedException();
        }
    }
}
