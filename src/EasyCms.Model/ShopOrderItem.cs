using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace EasyCms.Model
{
    /// <summary>
    /// 订单子表
    /// </summary>  
    [JsonObject]
    public partial class ShopOrderItem : BaseEntity
    {
        public static Column _ = new Column("ShopOrderItem");

        public ShopOrderItem()
        {
            this.TableName = "ShopOrderItem";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _OrderID;

        private string _ProductID;

        private string _ProductSKU;

        private string _ProductType;

        private string _ProductCode;

        private string _ProductName;

        private string _AttributeVal;

        private string _ProductThumb;

        private string _Unit;

        private decimal _Count;

        private bool _IsHandsel;

        private decimal _HandselCount;

        private decimal _ReturnCount;

        private decimal _UseJf;

        private decimal _CostPrice;

        private decimal _MarketPrice;

        private decimal _Price;

        private decimal _Preferential;

        private decimal _TotalPrice;

        private decimal _ReturnMoney;

        private decimal _Point;

        private int _Sequence;

        private string _Remark;

        private string _ProductTypeName;

        private string _BrandName;

        private string _SupplierName;

        private string _RegionName;

        private string _ShortDescription;

        private decimal _Weight;

        private bool _IsVirtualProduct;

        #endregion

        #region 属性

        /// <summary>
        ///  主键,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this.OnPropertyChanged("ID", this._ID, value);
                this._ID = value;
            }
        }

        /// <summary>
        ///  订单ID,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this.OnPropertyChanged("OrderID", this._OrderID, value);
                this._OrderID = value;
            }
        }

        /// <summary>
        ///  商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this.OnPropertyChanged("ProductID", this._ProductID, value);
                this._ProductID = value;
            }
        }

        /// <summary>
        ///  商品SKU,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductSKU", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductSKU
        {
            get
            {
                return this._ProductSKU;
            }
            set
            {
                this.OnPropertyChanged("ProductSKU", this._ProductSKU, value);
                this._ProductSKU = value;
            }
        }

        /// <summary>
        ///  商品类型,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductType", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductType
        {
            get
            {
                return this._ProductType;
            }
            set
            {
                this.OnPropertyChanged("ProductType", this._ProductType, value);
                this._ProductType = value;
            }
        }

        /// <summary>
        ///  商品编号,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductCode", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductCode
        {
            get
            {
                return this._ProductCode;
            }
            set
            {
                this.OnPropertyChanged("ProductCode", this._ProductCode, value);
                this._ProductCode = value;
            }
        }

        /// <summary>
        ///  商品名称,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this.OnPropertyChanged("ProductName", this._ProductName, value);
                this._ProductName = value;
            }
        }

        /// <summary>
        ///  规格值,
        /// </summary>

        [DbProperty(MapingColumnName = "AttributeVal", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string AttributeVal
        {
            get
            {
                return this._AttributeVal;
            }
            set
            {
                this.OnPropertyChanged("AttributeVal", this._AttributeVal, value);
                this._AttributeVal = value;
            }
        }

        /// <summary>
        ///  商品图像,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductThumb", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductThumb
        {
            get
            {
                return this._ProductThumb;
            }
            set
            {
                this.OnPropertyChanged("ProductThumb", this._ProductThumb, value);
                this._ProductThumb = value;
            }
        }

        /// <summary>
        ///  单位,
        /// </summary>

        [DbProperty(MapingColumnName = "Unit", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Unit
        {
            get
            {
                return this._Unit;
            }
            set
            {
                this.OnPropertyChanged("Unit", this._Unit, value);
                this._Unit = value;
            }
        }

        /// <summary>
        ///  订单数量,
        /// </summary>

        [DbProperty(MapingColumnName = "Count", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Count
        {
            get
            {
                return this._Count;
            }
            set
            {
                this.OnPropertyChanged("Count", this._Count, value);
                this._Count = value;
            }
        }

        /// <summary>
        ///  是否赠送,
        /// </summary>

        [DbProperty(MapingColumnName = "IsHandsel", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsHandsel
        {
            get
            {
                return this._IsHandsel;
            }
            set
            {
                this.OnPropertyChanged("IsHandsel", this._IsHandsel, value);
                this._IsHandsel = value;
            }
        }

        /// <summary>
        ///  赠送数量,
        /// </summary>

        [DbProperty(MapingColumnName = "HandselCount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal HandselCount
        {
            get
            {
                return this._HandselCount;
            }
            set
            {
                this.OnPropertyChanged("HandselCount", this._HandselCount, value);
                this._HandselCount = value;
            }
        }

        /// <summary>
        ///  退回数量,
        /// </summary>

        [DbProperty(MapingColumnName = "ReturnCount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal ReturnCount
        {
            get
            {
                return this._ReturnCount;
            }
            set
            {
                this.OnPropertyChanged("ReturnCount", this._ReturnCount, value);
                this._ReturnCount = value;
            }
        }

        /// <summary>
        ///  使用积分数,
        /// </summary>

        [DbProperty(MapingColumnName = "UseJf", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal UseJf
        {
            get
            {
                return this._UseJf;
            }
            set
            {
                this.OnPropertyChanged("UseJf", this._UseJf, value);
                this._UseJf = value;
            }
        }

        /// <summary>
        ///  成本价,
        /// </summary>

        [DbProperty(MapingColumnName = "CostPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal CostPrice
        {
            get
            {
                return this._CostPrice;
            }
            set
            {
                this.OnPropertyChanged("CostPrice", this._CostPrice, value);
                this._CostPrice = value;
            }
        }

        /// <summary>
        ///  市场价,
        /// </summary>

        [DbProperty(MapingColumnName = "MarketPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal MarketPrice
        {
            get
            {
                return this._MarketPrice;
            }
            set
            {
                this.OnPropertyChanged("MarketPrice", this._MarketPrice, value);
                this._MarketPrice = value;
            }
        }

        /// <summary>
        ///  单价,
        /// </summary>

        [DbProperty(MapingColumnName = "Price", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Price
        {
            get
            {
                return this._Price;
            }
            set
            {
                this.OnPropertyChanged("Price", this._Price, value);
                this._Price = value;
            }
        }

        /// <summary>
        ///  优惠金额,
        /// </summary>

        [DbProperty(MapingColumnName = "Preferential", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Preferential
        {
            get
            {
                return this._Preferential;
            }
            set
            {
                this.OnPropertyChanged("Preferential", this._Preferential, value);
                this._Preferential = value;
            }
        }

        /// <summary>
        ///  总价,单价*数量-优惠金额
        /// </summary>

        [DbProperty(MapingColumnName = "TotalPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal TotalPrice
        {
            get
            {
                return this._TotalPrice;
            }
            set
            {
                this.OnPropertyChanged("TotalPrice", this._TotalPrice, value);
                this._TotalPrice = value;
            }
        }

        /// <summary>
        ///  退回金额,
        /// </summary>

        [DbProperty(MapingColumnName = "ReturnMoney", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal ReturnMoney
        {
            get
            {
                return this._ReturnMoney;
            }
            set
            {
                this.OnPropertyChanged("ReturnMoney", this._ReturnMoney, value);
                this._ReturnMoney = value;
            }
        }

        /// <summary>
        ///  积分,
        /// </summary>

        [DbProperty(MapingColumnName = "Point", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Point
        {
            get
            {
                return this._Point;
            }
            set
            {
                this.OnPropertyChanged("Point", this._Point, value);
                this._Point = value;
            }
        }

        /// <summary>
        ///  顺序,
        /// </summary>

        [DbProperty(MapingColumnName = "Sequence", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Sequence
        {
            get
            {
                return this._Sequence;
            }
            set
            {
                this.OnPropertyChanged("Sequence", this._Sequence, value);
                this._Sequence = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Remark", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this.OnPropertyChanged("Remark", this._Remark, value);
                this._Remark = value;
            }
        }

        /// <summary>
        ///  商品类型名称,以下是扩展商品字段
        /// </summary>

        [DbProperty(MapingColumnName = "ProductTypeName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductTypeName
        {
            get
            {
                return this._ProductTypeName;
            }
            set
            {
                this.OnPropertyChanged("ProductTypeName", this._ProductTypeName, value);
                this._ProductTypeName = value;
            }
        }

        /// <summary>
        ///  品牌名称,
        /// </summary>

        [DbProperty(MapingColumnName = "BrandName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BrandName
        {
            get
            {
                return this._BrandName;
            }
            set
            {
                this.OnPropertyChanged("BrandName", this._BrandName, value);
                this._BrandName = value;
            }
        }

        /// <summary>
        ///  供应商名称,
        /// </summary>

        [DbProperty(MapingColumnName = "SupplierName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SupplierName
        {
            get
            {
                return this._SupplierName;
            }
            set
            {
                this.OnPropertyChanged("SupplierName", this._SupplierName, value);
                this._SupplierName = value;
            }
        }

        /// <summary>
        ///  地区,
        /// </summary>

        [DbProperty(MapingColumnName = "RegionName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RegionName
        {
            get
            {
                return this._RegionName;
            }
            set
            {
                this.OnPropertyChanged("RegionName", this._RegionName, value);
                this._RegionName = value;
            }
        }

        /// <summary>
        ///  简单描述,
        /// </summary>

        [DbProperty(MapingColumnName = "ShortDescription", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 5000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShortDescription
        {
            get
            {
                return this._ShortDescription;
            }
            set
            {
                this.OnPropertyChanged("ShortDescription", this._ShortDescription, value);
                this._ShortDescription = value;
            }
        }

        /// <summary>
        ///  重量,
        /// </summary>

        [DbProperty(MapingColumnName = "Weight", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Weight
        {
            get
            {
                return this._Weight;
            }
            set
            {
                this.OnPropertyChanged("Weight", this._Weight, value);
                this._Weight = value;
            }
        }

        /// <summary>
        ///  虚拟产品,
        /// </summary>

        [DbProperty(MapingColumnName = "IsVirtualProduct", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsVirtualProduct
        {
            get
            {
                return this._IsVirtualProduct;
            }
            set
            {
                this.OnPropertyChanged("IsVirtualProduct", this._IsVirtualProduct, value);
                this._IsVirtualProduct = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                OrderID = new PropertyItem("OrderID", tableName);

                ProductID = new PropertyItem("ProductID", tableName);

                ProductSKU = new PropertyItem("ProductSKU", tableName);

                ProductType = new PropertyItem("ProductType", tableName);

                ProductCode = new PropertyItem("ProductCode", tableName);

                ProductName = new PropertyItem("ProductName", tableName);

                AttributeVal = new PropertyItem("AttributeVal", tableName);

                ProductThumb = new PropertyItem("ProductThumb", tableName);

                Unit = new PropertyItem("Unit", tableName);

                Count = new PropertyItem("Count", tableName);

                IsHandsel = new PropertyItem("IsHandsel", tableName);

                HandselCount = new PropertyItem("HandselCount", tableName);

                ReturnCount = new PropertyItem("ReturnCount", tableName);

                UseJf = new PropertyItem("UseJf", tableName);

                CostPrice = new PropertyItem("CostPrice", tableName);

                MarketPrice = new PropertyItem("MarketPrice", tableName);

                Price = new PropertyItem("Price", tableName);

                Preferential = new PropertyItem("Preferential", tableName);

                TotalPrice = new PropertyItem("TotalPrice", tableName);

                ReturnMoney = new PropertyItem("ReturnMoney", tableName);

                Point = new PropertyItem("Point", tableName);

                Sequence = new PropertyItem("Sequence", tableName);

                Remark = new PropertyItem("Remark", tableName);

                ProductTypeName = new PropertyItem("ProductTypeName", tableName);

                BrandName = new PropertyItem("BrandName", tableName);

                SupplierName = new PropertyItem("SupplierName", tableName);

                RegionName = new PropertyItem("RegionName", tableName);

                ShortDescription = new PropertyItem("ShortDescription", tableName);

                Weight = new PropertyItem("Weight", tableName);

                IsVirtualProduct = new PropertyItem("IsVirtualProduct", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 订单ID,
            /// </summary> 
            public PropertyItem OrderID = null;
            /// <summary>
            /// 商品ID,
            /// </summary> 
            public PropertyItem ProductID = null;
            /// <summary>
            /// 商品SKU,
            /// </summary> 
            public PropertyItem ProductSKU = null;
            /// <summary>
            /// 商品类型,
            /// </summary> 
            public PropertyItem ProductType = null;
            /// <summary>
            /// 商品编号,
            /// </summary> 
            public PropertyItem ProductCode = null;
            /// <summary>
            /// 商品名称,
            /// </summary> 
            public PropertyItem ProductName = null;
            /// <summary>
            /// 规格值,
            /// </summary> 
            public PropertyItem AttributeVal = null;
            /// <summary>
            /// 商品图像,
            /// </summary> 
            public PropertyItem ProductThumb = null;
            /// <summary>
            /// 单位,
            /// </summary> 
            public PropertyItem Unit = null;
            /// <summary>
            /// 订单数量,
            /// </summary> 
            public PropertyItem Count = null;
            /// <summary>
            /// 是否赠送,
            /// </summary> 
            public PropertyItem IsHandsel = null;
            /// <summary>
            /// 赠送数量,
            /// </summary> 
            public PropertyItem HandselCount = null;
            /// <summary>
            /// 退回数量,
            /// </summary> 
            public PropertyItem ReturnCount = null;
            /// <summary>
            /// 使用积分数,
            /// </summary> 
            public PropertyItem UseJf = null;
            /// <summary>
            /// 成本价,
            /// </summary> 
            public PropertyItem CostPrice = null;
            /// <summary>
            /// 市场价,
            /// </summary> 
            public PropertyItem MarketPrice = null;
            /// <summary>
            /// 单价,
            /// </summary> 
            public PropertyItem Price = null;
            /// <summary>
            /// 优惠金额,
            /// </summary> 
            public PropertyItem Preferential = null;
            /// <summary>
            /// 总价,单价*数量-优惠金额
            /// </summary> 
            public PropertyItem TotalPrice = null;
            /// <summary>
            /// 退回金额,
            /// </summary> 
            public PropertyItem ReturnMoney = null;
            /// <summary>
            /// 积分,
            /// </summary> 
            public PropertyItem Point = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem Sequence = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Remark = null;
            /// <summary>
            /// 商品类型名称,以下是扩展商品字段
            /// </summary> 
            public PropertyItem ProductTypeName = null;
            /// <summary>
            /// 品牌名称,
            /// </summary> 
            public PropertyItem BrandName = null;
            /// <summary>
            /// 供应商名称,
            /// </summary> 
            public PropertyItem SupplierName = null;
            /// <summary>
            /// 地区,
            /// </summary> 
            public PropertyItem RegionName = null;
            /// <summary>
            /// 简单描述,
            /// </summary> 
            public PropertyItem ShortDescription = null;
            /// <summary>
            /// 重量,
            /// </summary> 
            public PropertyItem Weight = null;
            /// <summary>
            /// 虚拟产品,
            /// </summary> 
            public PropertyItem IsVirtualProduct = null;
        }
        #endregion
    }


}
