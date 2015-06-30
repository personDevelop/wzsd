﻿using Newtonsoft.Json;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyCms.Model
{
    /// <summary>
    /// 商品信息
    /// </summary>  
    [JsonObject]
    public partial class ShopProductInfo : BaseEntity
    {
        public static Column _ = new Column("ShopProductInfo");

        public ShopProductInfo()
        {
            this.TableName = "ShopProductInfo";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private string _SKU;

        private string _TypeId;

        private string _BrandId;

        private string _SupplierId;

        private string _RegionId;

        private string _ShortDescription;

        private string _Unit;

        private string _Description;

        private string _Meta_Title;

        private string _Meta_Description;

        private string _Meta_Keywords;

        private int _SalesType;

        private int _SaleStatus;

        private int _VistiCounts;

        private int _SaleCounts;

        private int _SaleNum;

        private int _DisplaySequence;

        private decimal _MarketPrice;

        private decimal _SalePrice;

        private decimal _CostPrice;

        private decimal _Points;

        private decimal _Stock;

        private decimal _MaxQuantity;

        private decimal _MinQuantity;

        private string _Tags;

        private bool _IsVirtualProduct;

        private DateTime _ManufactureDate;

        private DateTime _LaunchDate;

        private DateTime _SaleDate;

        private DateTime _AddedDate;

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
        ///  编号,
        /// </summary>

        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  SKU码,
        /// </summary>

        [DbProperty(MapingColumnName = "SKU", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  商品类型,
        /// </summary>

        [DbProperty(MapingColumnName = "TypeId", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  品牌,
        /// </summary>

        [DbProperty(MapingColumnName = "BrandId", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  商家,
        /// </summary>

        [DbProperty(MapingColumnName = "SupplierId", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        /// <summary>
        ///  所在地,
        /// </summary>

        [DbProperty(MapingColumnName = "RegionId", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RegionId
        {
            get
            {
                return this._RegionId;
            }
            set
            {
                this.OnPropertyChanged("RegionId", this._RegionId, value);
                this._RegionId = value;
            }
        }

        /// <summary>
        ///  简单描述,
        /// </summary>

        [DbProperty(MapingColumnName = "ShortDescription", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  计量单位,
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
        ///  商品介绍,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "text", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this.OnPropertyChanged("Description", this._Description, value);
                this._Description = value;
            }
        }

        /// <summary>
        ///  页面标题,
        /// </summary>

        [DbProperty(MapingColumnName = "Meta_Title", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Meta_Title
        {
            get
            {
                return this._Meta_Title;
            }
            set
            {
                this.OnPropertyChanged("Meta_Title", this._Meta_Title, value);
                this._Meta_Title = value;
            }
        }

        /// <summary>
        ///  Meta描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Meta_Description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Meta_Description
        {
            get
            {
                return this._Meta_Description;
            }
            set
            {
                this.OnPropertyChanged("Meta_Description", this._Meta_Description, value);
                this._Meta_Description = value;
            }
        }

        /// <summary>
        ///  Meta关键字,
        /// </summary>

        [DbProperty(MapingColumnName = "Meta_Keywords", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Meta_Keywords
        {
            get
            {
                return this._Meta_Keywords;
            }
            set
            {
                this.OnPropertyChanged("Meta_Keywords", this._Meta_Keywords, value);
                this._Meta_Keywords = value;
            }
        }

        /// <summary>
        ///  销售类型,0 赠品  1 正常销售
        /// </summary>

        [DbProperty(MapingColumnName = "SalesType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int SalesType
        {
            get
            {
                return this._SalesType;
            }
            set
            {
                this.OnPropertyChanged("SalesType", this._SalesType, value);
                this._SalesType = value;
            }
        }

        /// <summary>
        ///  商品状态,0,下架 1 上架，2上架审批，3上架退回
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
        ///  访问次数,
        /// </summary>

        [DbProperty(MapingColumnName = "VistiCounts", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int VistiCounts
        {
            get
            {
                return this._VistiCounts;
            }
            set
            {
                this.OnPropertyChanged("VistiCounts", this._VistiCounts, value);
                this._VistiCounts = value;
            }
        }

        /// <summary>
        ///  销售个数,
        /// </summary>

        [DbProperty(MapingColumnName = "SaleCounts", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int SaleCounts
        {
            get
            {
                return this._SaleCounts;
            }
            set
            {
                this.OnPropertyChanged("SaleCounts", this._SaleCounts, value);
                this._SaleCounts = value;
            }
        }

        /// <summary>
        ///  销售次数,指订单个数
        /// </summary>

        [DbProperty(MapingColumnName = "SaleNum", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int SaleNum
        {
            get
            {
                return this._SaleNum;
            }
            set
            {
                this.OnPropertyChanged("SaleNum", this._SaleNum, value);
                this._SaleNum = value;
            }
        }

        /// <summary>
        ///  显示顺序,
        /// </summary>

        [DbProperty(MapingColumnName = "DisplaySequence", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int DisplaySequence
        {
            get
            {
                return this._DisplaySequence;
            }
            set
            {
                this.OnPropertyChanged("DisplaySequence", this._DisplaySequence, value);
                this._DisplaySequence = value;
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
        ///  可得积分,
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
        ///  警戒最高库存,
        /// </summary>

        [DbProperty(MapingColumnName = "MaxQuantity", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal MaxQuantity
        {
            get
            {
                return this._MaxQuantity;
            }
            set
            {
                this.OnPropertyChanged("MaxQuantity", this._MaxQuantity, value);
                this._MaxQuantity = value;
            }
        }

        /// <summary>
        ///  警戒最低库存,
        /// </summary>

        [DbProperty(MapingColumnName = "MinQuantity", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal MinQuantity
        {
            get
            {
                return this._MinQuantity;
            }
            set
            {
                this.OnPropertyChanged("MinQuantity", this._MinQuantity, value);
                this._MinQuantity = value;
            }
        }

        /// <summary>
        ///  标签,
        /// </summary>

        [DbProperty(MapingColumnName = "Tags", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Tags
        {
            get
            {
                return this._Tags;
            }
            set
            {
                this.OnPropertyChanged("Tags", this._Tags, value);
                this._Tags = value;
            }
        }

        /// <summary>
        ///  虚拟产品,虚拟产品无需物流
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
        ///  生产日期,
        /// </summary>

        [DbProperty(MapingColumnName = "ManufactureDate", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime ManufactureDate
        {
            get
            {
                return this._ManufactureDate;
            }
            set
            {
                this.OnPropertyChanged("ManufactureDate", this._ManufactureDate, value);
                this._ManufactureDate = value;
            }
        }

        /// <summary>
        ///  上市日期,
        /// </summary>

        [DbProperty(MapingColumnName = "LaunchDate", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime LaunchDate
        {
            get
            {
                return this._LaunchDate;
            }
            set
            {
                this.OnPropertyChanged("LaunchDate", this._LaunchDate, value);
                this._LaunchDate = value;
            }
        }

        /// <summary>
        ///  上架日期,
        /// </summary>

        [DbProperty(MapingColumnName = "SaleDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime SaleDate
        {
            get
            {
                return this._SaleDate;
            }
            set
            {
                this.OnPropertyChanged("SaleDate", this._SaleDate, value);
                this._SaleDate = value;
            }
        }

        /// <summary>
        ///  添加日期,
        /// </summary>

        [DbProperty(MapingColumnName = "AddedDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime AddedDate
        {
            get
            {
                return this._AddedDate;
            }
            set
            {
                this.OnPropertyChanged("AddedDate", this._AddedDate, value);
                this._AddedDate = value;
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

                SKU = new PropertyItem("SKU", tableName);

                TypeId = new PropertyItem("TypeId", tableName);

                BrandId = new PropertyItem("BrandId", tableName);

                SupplierId = new PropertyItem("SupplierId", tableName);

                RegionId = new PropertyItem("RegionId", tableName);

                ShortDescription = new PropertyItem("ShortDescription", tableName);

                Unit = new PropertyItem("Unit", tableName);

                Description = new PropertyItem("Description", tableName);

                Meta_Title = new PropertyItem("Meta_Title", tableName);

                Meta_Description = new PropertyItem("Meta_Description", tableName);

                Meta_Keywords = new PropertyItem("Meta_Keywords", tableName);

                SalesType = new PropertyItem("SalesType", tableName);

                SaleStatus = new PropertyItem("SaleStatus", tableName);

                VistiCounts = new PropertyItem("VistiCounts", tableName);

                SaleCounts = new PropertyItem("SaleCounts", tableName);

                SaleNum = new PropertyItem("SaleNum", tableName);

                DisplaySequence = new PropertyItem("DisplaySequence", tableName);

                MarketPrice = new PropertyItem("MarketPrice", tableName);

                SalePrice = new PropertyItem("SalePrice", tableName);

                CostPrice = new PropertyItem("CostPrice", tableName);

                Points = new PropertyItem("Points", tableName);

                Stock = new PropertyItem("Stock", tableName);

                MaxQuantity = new PropertyItem("MaxQuantity", tableName);

                MinQuantity = new PropertyItem("MinQuantity", tableName);

                Tags = new PropertyItem("Tags", tableName);

                IsVirtualProduct = new PropertyItem("IsVirtualProduct", tableName);

                ManufactureDate = new PropertyItem("ManufactureDate", tableName);

                LaunchDate = new PropertyItem("LaunchDate", tableName);

                SaleDate = new PropertyItem("SaleDate", tableName);

                AddedDate = new PropertyItem("AddedDate", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// SKU码,
            /// </summary> 
            public PropertyItem SKU = null;
            /// <summary>
            /// 商品类型,
            /// </summary> 
            public PropertyItem TypeId = null;
            /// <summary>
            /// 品牌,
            /// </summary> 
            public PropertyItem BrandId = null;
            /// <summary>
            /// 商家,
            /// </summary> 
            public PropertyItem SupplierId = null;
            /// <summary>
            /// 所在地,
            /// </summary> 
            public PropertyItem RegionId = null;
            /// <summary>
            /// 简单描述,
            /// </summary> 
            public PropertyItem ShortDescription = null;
            /// <summary>
            /// 计量单位,
            /// </summary> 
            public PropertyItem Unit = null;
            /// <summary>
            /// 商品介绍,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 页面标题,
            /// </summary> 
            public PropertyItem Meta_Title = null;
            /// <summary>
            /// Meta描述,
            /// </summary> 
            public PropertyItem Meta_Description = null;
            /// <summary>
            /// Meta关键字,
            /// </summary> 
            public PropertyItem Meta_Keywords = null;
            /// <summary>
            /// 销售类型,0 赠品  1 正常销售
            /// </summary> 
            public PropertyItem SalesType = null;
            /// <summary>
            /// 商品状态,0,下架 1 上架，2上架审批，3上架退回
            /// </summary> 
            public PropertyItem SaleStatus = null;
            /// <summary>
            /// 访问次数,
            /// </summary> 
            public PropertyItem VistiCounts = null;
            /// <summary>
            /// 销售个数,
            /// </summary> 
            public PropertyItem SaleCounts = null;
            /// <summary>
            /// 销售次数,指订单个数
            /// </summary> 
            public PropertyItem SaleNum = null;
            /// <summary>
            /// 显示顺序,
            /// </summary> 
            public PropertyItem DisplaySequence = null;
            /// <summary>
            /// 市场价,
            /// </summary> 
            public PropertyItem MarketPrice = null;
            /// <summary>
            /// 销售价,
            /// </summary> 
            public PropertyItem SalePrice = null;
            /// <summary>
            /// 成本价,
            /// </summary> 
            public PropertyItem CostPrice = null;
            /// <summary>
            /// 可得积分,
            /// </summary> 
            public PropertyItem Points = null;
            /// <summary>
            /// 库存,
            /// </summary> 
            public PropertyItem Stock = null;
            /// <summary>
            /// 警戒最高库存,
            /// </summary> 
            public PropertyItem MaxQuantity = null;
            /// <summary>
            /// 警戒最低库存,
            /// </summary> 
            public PropertyItem MinQuantity = null;
            /// <summary>
            /// 标签,
            /// </summary> 
            public PropertyItem Tags = null;
            /// <summary>
            /// 虚拟产品,虚拟产品无需物流
            /// </summary> 
            public PropertyItem IsVirtualProduct = null;
            /// <summary>
            /// 生产日期,
            /// </summary> 
            public PropertyItem ManufactureDate = null;
            /// <summary>
            /// 上市日期,
            /// </summary> 
            public PropertyItem LaunchDate = null;
            /// <summary>
            /// 上架日期,
            /// </summary> 
            public PropertyItem SaleDate = null;
            /// <summary>
            /// 添加日期,
            /// </summary> 
            public PropertyItem AddedDate = null;
        }
        #endregion
    }

    public partial class ShopProductInfo
    {
        [NotDbCol]
        public string ShopCategoryName { get; set; }
        [NotDbCol]
        public string ShopCategoryID { get; set; }
        protected override void OnCreate()
        {
            AddedDate = DateTime.Now;
            SaleDate = AddedDate;
            Stock = int.MinValue;
        }
    
    }
}
