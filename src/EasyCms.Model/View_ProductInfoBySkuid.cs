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
    /// 根据商品Sku获取商品信息
    /// </summary>  
    [JsonObject]
    public partial class View_ProductInfoBySkuid : BaseEntity
    {
        public static Column _ = new Column("View_ProductInfoBySkuid");

        public View_ProductInfoBySkuid()
        {
            this.TableName = "View_ProductInfoBySkuid";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private bool _IsEnableSku;

        private string _Unit;

        private string _SKUCode;

        private decimal _SalePrice;

        private decimal _MarketPrice;

        private decimal _Stock;

        private string _SKUID;

        private bool _IsSale;

        private int _SaleStatus;

        private string _SKUName;

        private decimal _Points;

        private string _TypeId;

        private decimal _CostPrice;

        private string _ShortDescription;

        private decimal _Weight;

        private bool _IsVirtualProduct;

        private string _BrandId;

        private string _SupplierId;

        #endregion

        #region 属性

        /// <summary>
        ///  商品ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  商品编号,
        /// </summary>

        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this.OnPropertyChanged("Code", this._Code, value);
                this._Code = value;
            }
        }

        /// <summary>
        ///  商品名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 400, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnPropertyChanged("Name", this._Name, value);
                this._Name = value;
            }
        }

        /// <summary>
        ///  启用SKU,
        /// </summary>

        [DbProperty(MapingColumnName = "IsEnableSku", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 1, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsEnableSku
        {
            get
            {
                return this._IsEnableSku;
            }
            set
            {
                this.OnPropertyChanged("IsEnableSku", this._IsEnableSku, value);
                this._IsEnableSku = value;
            }
        }

        /// <summary>
        ///  单位,
        /// </summary>

        [DbProperty(MapingColumnName = "Unit", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  SKU编码,
        /// </summary>

        [DbProperty(MapingColumnName = "SKUCode", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SKUCode
        {
            get
            {
                return this._SKUCode;
            }
            set
            {
                this.OnPropertyChanged("SKUCode", this._SKUCode, value);
                this._SKUCode = value;
            }
        }

        /// <summary>
        ///  售价,
        /// </summary>

        [DbProperty(MapingColumnName = "SalePrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  市场价,
        /// </summary>

        [DbProperty(MapingColumnName = "MarketPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  库存,
        /// </summary>

        [DbProperty(MapingColumnName = "Stock", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  SKUID,
        /// </summary>

        [DbProperty(MapingColumnName = "SKUID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SKUID
        {
            get
            {
                return this._SKUID;
            }
            set
            {
                this.OnPropertyChanged("SKUID", this._SKUID, value);
                this._SKUID = value;
            }
        }

        /// <summary>
        ///  是否在售,
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
        ///  商品销售状态,
        /// </summary>

        [DbProperty(MapingColumnName = "SaleStatus", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int SaleStatus
        {
            get
            {
                return this._SaleStatus;
            }
            set
            {
                this.OnPropertyChanged("SaleStatus", this._SaleStatus, value);
                this._SaleStatus = value;
            }
        }

        /// <summary>
        ///  商品SKU名称,
        /// </summary>

        [DbProperty(MapingColumnName = "SKUName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SKUName
        {
            get
            {
                return this._SKUName;
            }
            set
            {
                this.OnPropertyChanged("SKUName", this._SKUName, value);
                this._SKUName = value;
            }
        }

        /// <summary>
        ///  积分,
        /// </summary>

        [DbProperty(MapingColumnName = "Points", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Points
        {
            get
            {
                return this._Points;
            }
            set
            {
                this.OnPropertyChanged("Points", this._Points, value);
                this._Points = value;
            }
        }

        /// <summary>
        ///  商品类型ID,
        /// </summary>

        [DbProperty(MapingColumnName = "TypeId", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string TypeId
        {
            get
            {
                return this._TypeId;
            }
            set
            {
                this.OnPropertyChanged("TypeId", this._TypeId, value);
                this._TypeId = value;
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
        ///  商品描述,
        /// </summary>

        [DbProperty(MapingColumnName = "ShortDescription", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  单重(kg),
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
        ///  是虚拟产品,
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

        /// <summary>
        ///  品牌ID,
        /// </summary>

        [DbProperty(MapingColumnName = "BrandId", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BrandId
        {
            get
            {
                return this._BrandId;
            }
            set
            {
                this.OnPropertyChanged("BrandId", this._BrandId, value);
                this._BrandId = value;
            }
        }

        /// <summary>
        ///  供应商ID,
        /// </summary>

        [DbProperty(MapingColumnName = "SupplierId", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SupplierId
        {
            get
            {
                return this._SupplierId;
            }
            set
            {
                this.OnPropertyChanged("SupplierId", this._SupplierId, value);
                this._SupplierId = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                Code = new PropertyItem("Code", tableName);

                Name = new PropertyItem("Name", tableName);

                IsEnableSku = new PropertyItem("IsEnableSku", tableName);

                Unit = new PropertyItem("Unit", tableName);

                SKUCode = new PropertyItem("SKUCode", tableName);

                SalePrice = new PropertyItem("SalePrice", tableName);

                MarketPrice = new PropertyItem("MarketPrice", tableName);

                Stock = new PropertyItem("Stock", tableName);

                SKUID = new PropertyItem("SKUID", tableName);

                IsSale = new PropertyItem("IsSale", tableName);

                SaleStatus = new PropertyItem("SaleStatus", tableName);

                SKUName = new PropertyItem("SKUName", tableName);

                Points = new PropertyItem("Points", tableName);

                TypeId = new PropertyItem("TypeId", tableName);

                CostPrice = new PropertyItem("CostPrice", tableName);

                ShortDescription = new PropertyItem("ShortDescription", tableName);

                Weight = new PropertyItem("Weight", tableName);

                IsVirtualProduct = new PropertyItem("IsVirtualProduct", tableName);

                BrandId = new PropertyItem("BrandId", tableName);

                SupplierId = new PropertyItem("SupplierId", tableName);


            }
            /// <summary>
            /// 商品ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 商品编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 商品名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 启用SKU,
            /// </summary> 
            public PropertyItem IsEnableSku = null;
            /// <summary>
            /// 单位,
            /// </summary> 
            public PropertyItem Unit = null;
            /// <summary>
            /// SKU编码,
            /// </summary> 
            public PropertyItem SKUCode = null;
            /// <summary>
            /// 售价,
            /// </summary> 
            public PropertyItem SalePrice = null;
            /// <summary>
            /// 市场价,
            /// </summary> 
            public PropertyItem MarketPrice = null;
            /// <summary>
            /// 库存,
            /// </summary> 
            public PropertyItem Stock = null;
            /// <summary>
            /// SKUID,
            /// </summary> 
            public PropertyItem SKUID = null;
            /// <summary>
            /// 是否在售,
            /// </summary> 
            public PropertyItem IsSale = null;
            /// <summary>
            /// 商品销售状态,
            /// </summary> 
            public PropertyItem SaleStatus = null;
            /// <summary>
            /// 商品SKU名称,
            /// </summary> 
            public PropertyItem SKUName = null;
            /// <summary>
            /// 积分,
            /// </summary> 
            public PropertyItem Points = null;
            /// <summary>
            /// 商品类型ID,
            /// </summary> 
            public PropertyItem TypeId = null;
            /// <summary>
            /// 成本价,
            /// </summary> 
            public PropertyItem CostPrice = null;
            /// <summary>
            /// 商品描述,
            /// </summary> 
            public PropertyItem ShortDescription = null;
            /// <summary>
            /// 单重(kg),
            /// </summary> 
            public PropertyItem Weight = null;
            /// <summary>
            /// 是虚拟产品,
            /// </summary> 
            public PropertyItem IsVirtualProduct = null;
            /// <summary>
            /// 品牌ID,
            /// </summary> 
            public PropertyItem BrandId = null;
            /// <summary>
            /// 供应商ID,
            /// </summary> 
            public PropertyItem SupplierId = null;
        }
        #endregion
    }

    public partial class View_ProductInfoBySkuid
    {
        [NotDbCol]
        public string BrandName { get; set; }
        [NotDbCol]
        public string ProductTypeName { get; set; }
        [NotDbCol]
        public string FilePath { get; set; }
    }
}
