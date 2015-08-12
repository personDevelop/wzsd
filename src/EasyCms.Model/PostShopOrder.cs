using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model
{
    public class PostShopOrder
    {
        #region 属性
         
        /// <summary>
        ///  订单类型,0，普通，1促销，2团购
        /// </summary> 
        public int OrderType
        {
            get;
            set;
        } 
        /// <summary>
        ///  订单对应的销售模式ID,团购、促销ID
        /// </summary> 
        public string OrderResId
        {
            get;
            set;
        } 
        public int AddressID
        {
            get;
            set;
        } 
        /// <summary>
        ///  配送方式ID,
        /// </summary> 
        public string ShipModeID
        {
            get;
            set;
        } 
        /// <summary>
        ///  付款方式ID,
        /// </summary> 
        public string PayTypeID
        {
            get;
            set;
        } 
       
        /// <summary>
        ///  优惠券ID,
        /// </summary> 
        public bool YHQID
        {
            get;
            set;
        }

        /// <summary>
        ///  积分抵金额规则ID,
        /// </summary> 
        public bool JFDJEID
        {
            get;
            set;
        }
        /// <summary>
        ///  免运费,
        /// </summary> 
        public bool IsFreeShiping
        {
            get;
            set;
        }
        /// <summary>
        ///  实际运费,
        /// </summary> 
        public decimal FreightActual
        {
            get;
            set;
        } 
        /// <summary>
        ///  订单说明,
        /// </summary> 
        public string Remark
        {
            get;
            set;
        } 
        /// <summary>
        ///  付款状态,0,未付款，1已付款
        /// </summary> 
        public int PayStatus
        {
            get;
            set;
        } 
        /// <summary>
        ///  发票,
        /// </summary> 
        public bool IsInvoice
        {
            get;
            set;
        }

        /// <summary>
        ///  发票填写客户名称,
        /// </summary> 
        public string InvoiceInfo
        {
            get;
            set;
        } 

        /// <summary>
        ///  卖家ID,空位红七商城
        /// </summary> 
        public string SellerID
        {
            get;
            set;
        } 
        /// <summary>
        ///  送货时机,0,任意，1周一至周五，2周末，3指定日期
        /// </summary> 
        public int DeliveryTime
        {
            get;
            set;
        } 
        /// <summary>
        ///  指定日期,
        /// </summary> 
        public DateTime? SpecifiedDate
        {
            get;
            set;
        }
        #endregion
    }
    public class PostOrderItem
    {
        #region 属性
         
        /// <summary>
        ///  商品ID,
        /// </summary> 
        public string ProductID
        {
            get;
            set;
        } 
        /// <summary>
        ///  商品SKU,
        /// </summary> 
        public string ProductSKUID
        {
            get;
            set;
        }

        /// <summary>
        ///  订单数量,
        /// </summary> 
        public decimal Count
        {
            get;
            set;
        }

        /// <summary>
        ///  赠送数量,
        /// </summary>

        public decimal HandselCount
        {
            get;
            set;
        }
        /// <summary>
        ///  是否赠送,
        /// </summary> 
        public bool IsHandsel
        {
            get;
            set;
        } 
        /// <summary>
        ///  使用积分数,
        /// </summary> 
        public decimal UseJf
        {
            get;
            set;
        } 
        /// <summary>
        ///  单价,
        /// </summary> 
        public decimal Price
        {
            get;
            set;
        } 
        #endregion
    }
}
