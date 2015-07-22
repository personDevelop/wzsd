using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model
{
    public class ShopOrderModel
    {
        /// <summary>
        /// 0，普通，1促销，2团购
        /// </summary>
        public int OrderType { get; set; }

        /// <summary>
        /// 订单对应的销售模式ID,普通订单的为空
        /// </summary>
        public string OrderResId { get; set; }

        /// <summary>
        /// 收件人地址ID
        /// </summary>
        public string AddressID { get; set; }
        /// <summary>
        /// 支付方式ID
        /// </summary>
        public string PayTypeID { get; set; }

        /// <summary>
        /// 使用优惠券ID
        /// </summary>
        public string UsingCouponsID { get; set; }

        /// <summary>
        /// 使用积分数量
        /// </summary>
        public decimal UsingIntegral { get; set; }

        /// <summary>
        /// 订单备注
        /// </summary>
        public string Remark { get; set; }

        public List<OrderItem> OrderItems { get; set; }

    }

    public class OrderItem
    {
        public string ProductID { get; set; }

        public string Sku { get; set; }
        public decimal BuyCount { get; set; }


    }
}
