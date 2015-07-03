using Newtonsoft.Json;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyCms.Model
{
    /// <summary>
    /// 商品库存量销售信息表
    /// </summary>  
    [JsonObject]
    public partial class ShopProductSKUInfo : BaseEntity
    {
        public static Column _ = new Column("ShopProductSKUInfo");

        public ShopProductSKUInfo()
        {
            this.TableName = "ShopProductSKUInfo";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _SKURelationID;

        private string _ProductId;

        private string _SKU;

        private decimal _Weight;

        private decimal _Stock;

        private decimal _MinAlertStock;

        private decimal _MaxAlertStock;

        private decimal _CostPrice;

        private decimal _MarketPrice;

        private decimal _SalePrice;

        private bool _IsSale;

        private int _OrderNo;

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
        ///  商品库存量关系ID,
        /// </summary>

        [DbProperty(MapingColumnName = "SKURelationID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SKURelationID
        {
            get
            {
                return this._SKURelationID;
            }
            set
            {
                this.OnPropertyChanged("SKURelationID", this._SKURelationID, value);
                this._SKURelationID = value;
            }
        }

        /// <summary>
        ///  商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductId", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductId
        {
            get
            {
                return this._ProductId;
            }
            set
            {
                this.OnPropertyChanged("ProductId", this._ProductId, value);
                this._ProductId = value;
            }
        }

        /// <summary>
        ///  SKU码,
        /// </summary>

        [DbProperty(MapingColumnName = "SKU", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SKU
        {
            get
            {
                return this._SKU;
            }
            set
            {
                this.OnPropertyChanged("SKU", this._SKU, value);
                this._SKU = value;
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
        ///  库存,
        /// </summary>

        [DbProperty(MapingColumnName = "Stock", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Stock
        {
            get
            {
                return this._Stock;
            }
            set
            {
                this.OnPropertyChanged("Stock", this._Stock, value);
                this._Stock = value;
            }
        }

        /// <summary>
        ///  最低警戒库存,
        /// </summary>

        [DbProperty(MapingColumnName = "MinAlertStock", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal MinAlertStock
        {
            get
            {
                return this._MinAlertStock;
            }
            set
            {
                this.OnPropertyChanged("MinAlertStock", this._MinAlertStock, value);
                this._MinAlertStock = value;
            }
        }

        /// <summary>
        ///  最高警戒库存,
        /// </summary>

        [DbProperty(MapingColumnName = "MaxAlertStock", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal MaxAlertStock
        {
            get
            {
                return this._MaxAlertStock;
            }
            set
            {
                this.OnPropertyChanged("MaxAlertStock", this._MaxAlertStock, value);
                this._MaxAlertStock = value;
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
        ///  销售价,
        /// </summary>

        [DbProperty(MapingColumnName = "SalePrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal SalePrice
        {
            get
            {
                return this._SalePrice;
            }
            set
            {
                this.OnPropertyChanged("SalePrice", this._SalePrice, value);
                this._SalePrice = value;
            }
        }

        /// <summary>
        ///  是否上架,
        /// </summary>

        [DbProperty(MapingColumnName = "IsSale", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsSale
        {
            get
            {
                return this._IsSale;
            }
            set
            {
                this.OnPropertyChanged("IsSale", this._IsSale, value);
                this._IsSale = value;
            }
        }

        /// <summary>
        ///  顺序,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderNo", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int OrderNo
        {
            get
            {
                return this._OrderNo;
            }
            set
            {
                this.OnPropertyChanged("OrderNo", this._OrderNo, value);
                this._OrderNo = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                SKURelationID = new PropertyItem("SKURelationID", tableName);

                ProductId = new PropertyItem("ProductId", tableName);

                SKU = new PropertyItem("SKU", tableName);

                Weight = new PropertyItem("Weight", tableName);

                Stock = new PropertyItem("Stock", tableName);

                MinAlertStock = new PropertyItem("MinAlertStock", tableName);

                MaxAlertStock = new PropertyItem("MaxAlertStock", tableName);

                CostPrice = new PropertyItem("CostPrice", tableName);

                MarketPrice = new PropertyItem("MarketPrice", tableName);

                SalePrice = new PropertyItem("SalePrice", tableName);

                IsSale = new PropertyItem("IsSale", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 商品库存量关系ID,
            /// </summary> 
            public PropertyItem SKURelationID = null;
            /// <summary>
            /// 商品ID,
            /// </summary> 
            public PropertyItem ProductId = null;
            /// <summary>
            /// SKU码,
            /// </summary> 
            public PropertyItem SKU = null;
            /// <summary>
            /// 重量,
            /// </summary> 
            public PropertyItem Weight = null;
            /// <summary>
            /// 库存,
            /// </summary> 
            public PropertyItem Stock = null;
            /// <summary>
            /// 最低警戒库存,
            /// </summary> 
            public PropertyItem MinAlertStock = null;
            /// <summary>
            /// 最高警戒库存,
            /// </summary> 
            public PropertyItem MaxAlertStock = null;
            /// <summary>
            /// 成本价,
            /// </summary> 
            public PropertyItem CostPrice = null;
            /// <summary>
            /// 市场价,
            /// </summary> 
            public PropertyItem MarketPrice = null;
            /// <summary>
            /// 销售价,
            /// </summary> 
            public PropertyItem SalePrice = null;
            /// <summary>
            /// 是否上架,
            /// </summary> 
            public PropertyItem IsSale = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
        }
        #endregion
    }

}
