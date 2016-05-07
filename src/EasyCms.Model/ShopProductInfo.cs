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

        private decimal _Weight;

        private string _PCDescription;

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

        private DateTime? _ManufactureDate;

        private DateTime? _LaunchDate;

        private DateTime _SaleDate;

        private DateTime _AddedDate;

        private bool _IsEnableSku;

        private int _CommentCount;

        private bool _IsCashOnDelivery;

        private string _VideoImg;

        private string _VideoUrl;

        private int _GoodCount;

        private int _MiddleCount;

        private int _BadCount;

        #endregion

        #region 属性

        /// <summary>
        ///  主键,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        [DbProperty(MapingColumnName = "TypeId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  电脑版商品介绍,
        /// </summary>

        [DbProperty(MapingColumnName = "PCDescription", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PCDescription
        {
            get
            {
                return this._PCDescription;
            }
            set
            {
                this.OnPropertyChanged("PCDescription", this._PCDescription, value);
                this._PCDescription = value;
            }
        }

        /// <summary>
        ///  商品介绍,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        public DateTime? ManufactureDate
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

        public DateTime? LaunchDate
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

        /// <summary>
        ///  启用SKU,
        /// </summary>

        [DbProperty(MapingColumnName = "IsEnableSku", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  评论次数,
        /// </summary>

        [DbProperty(MapingColumnName = "CommentCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int CommentCount
        {
            get
            {
                return this._CommentCount;
            }
            set
            {
                this.OnPropertyChanged("CommentCount", this._CommentCount, value);
                this._CommentCount = value;
            }
        }

        /// <summary>
        ///  支持货到付款,
        /// </summary>

        [DbProperty(MapingColumnName = "IsCashOnDelivery", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsCashOnDelivery
        {
            get
            {
                return this._IsCashOnDelivery;
            }
            set
            {
                this.OnPropertyChanged("IsCashOnDelivery", this._IsCashOnDelivery, value);
                this._IsCashOnDelivery = value;
            }
        }

        /// <summary>
        ///  视频封面,
        /// </summary>

        [DbProperty(MapingColumnName = "VideoImg", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string VideoImg
        {
            get
            {
                return this._VideoImg;
            }
            set
            {
                this.OnPropertyChanged("VideoImg", this._VideoImg, value);
                this._VideoImg = value;
            }
        }

        /// <summary>
        ///  视频连接,一行一个链接，最多支持三个
        /// </summary>

        [DbProperty(MapingColumnName = "VideoUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 2000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string VideoUrl
        {
            get
            {
                return this._VideoUrl;
            }
            set
            {
                this.OnPropertyChanged("VideoUrl", this._VideoUrl, value);
                this._VideoUrl = value;
            }
        }

        /// <summary>
        ///  好评个数,
        /// </summary>

        [DbProperty(MapingColumnName = "GoodCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int GoodCount
        {
            get
            {
                return this._GoodCount;
            }
            set
            {
                this.OnPropertyChanged("GoodCount", this._GoodCount, value);
                this._GoodCount = value;
            }
        }

        /// <summary>
        ///  中评个数,
        /// </summary>

        [DbProperty(MapingColumnName = "MiddleCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int MiddleCount
        {
            get
            {
                return this._MiddleCount;
            }
            set
            {
                this.OnPropertyChanged("MiddleCount", this._MiddleCount, value);
                this._MiddleCount = value;
            }
        }

        /// <summary>
        ///  差评个数,
        /// </summary>

        [DbProperty(MapingColumnName = "BadCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int BadCount
        {
            get
            {
                return this._BadCount;
            }
            set
            {
                this.OnPropertyChanged("BadCount", this._BadCount, value);
                this._BadCount = value;
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

                Weight = new PropertyItem("Weight", tableName);

                PCDescription = new PropertyItem("PCDescription", tableName);

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

                IsEnableSku = new PropertyItem("IsEnableSku", tableName);

                CommentCount = new PropertyItem("CommentCount", tableName);

                IsCashOnDelivery = new PropertyItem("IsCashOnDelivery", tableName);

                VideoImg = new PropertyItem("VideoImg", tableName);

                VideoUrl = new PropertyItem("VideoUrl", tableName);

                GoodCount = new PropertyItem("GoodCount", tableName);

                MiddleCount = new PropertyItem("MiddleCount", tableName);

                BadCount = new PropertyItem("BadCount", tableName);


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
            /// 重量,
            /// </summary> 
            public PropertyItem Weight = null;
            /// <summary>
            /// 电脑版商品介绍,
            /// </summary> 
            public PropertyItem PCDescription = null;
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
            /// <summary>
            /// 启用SKU,
            /// </summary> 
            public PropertyItem IsEnableSku = null;
            /// <summary>
            /// 评论次数,
            /// </summary> 
            public PropertyItem CommentCount = null;
            /// <summary>
            /// 支持货到付款,
            /// </summary> 
            public PropertyItem IsCashOnDelivery = null;
            /// <summary>
            /// 视频封面,
            /// </summary> 
            public PropertyItem VideoImg = null;
            /// <summary>
            /// 视频连接,一行一个链接，最多支持三个
            /// </summary> 
            public PropertyItem VideoUrl = null;
            /// <summary>
            /// 好评个数,
            /// </summary> 
            public PropertyItem GoodCount = null;
            /// <summary>
            /// 中评个数,
            /// </summary> 
            public PropertyItem MiddleCount = null;
            /// <summary>
            /// 差评个数,
            /// </summary> 
            public PropertyItem BadCount = null;
        }
        #endregion
    }



    public partial class ShopProductInfo
    {
        [NotDbCol]
        public string ShopCategoryName { get; set; }
        [NotDbCol]
        public string TypeName  { get; set; }
        [NotDbCol]
        public string BrandName { get; set; }

        
        [NotDbCol]
        public string ShopCategoryID { get; set; }


        [NotDbCol]
        public string ThumbImgUrl { get; set; }
        protected override void OnCreate()
        {
            AddedDate = DateTime.Now;
            SaleDate = AddedDate;
            Stock = int.MaxValue;
            SalesType = 1;
            SaleStatus = 1;
            IsCashOnDelivery = true;
        }

    }

    /// <summary>
    /// 供接口使用，传递给前台
    /// </summary>
    [JsonObject]
    public class ShopSaleProductInfo
    {
        #region 属性
        /// <summary>
        ///  主键,
        /// </summary> 
        public string ID
        {
            get;
            set;
        }

        /// <summary>
        ///  编号,
        /// </summary> 
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        ///  名称,
        /// </summary> 
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///  SKU码,
        /// </summary> 
        public string SKU
        {
            get;
            set;
        }

        /// <summary>
        ///  商品类型,
        /// </summary> 
        public string TypeId
        {
            get;
            set;
        }
        public string TypeName
        {
            get;
            set;
        }
        /// <summary>
        ///  品牌,
        /// </summary> 
        public string BrandId
        {
            get;
            set;
        }
        /// <summary>
        ///  品牌,
        /// </summary> 
        public string BrandName
        {
            get;
            set;
        }
        /// <summary>
        ///  商家,
        /// </summary> 
        public string SupplierName
        {
            get;
            set;
        }

        /// <summary>
        ///  所在地,
        /// </summary> 
        public string RegionName
        {
            get;
            set;
        }

        /// <summary>
        ///  简单描述,
        /// </summary> 
        public string ShortDescription
        {
            get;
            set;
        }

        /// <summary>
        ///  计量单位,
        /// </summary> 
        public string Unit
        {
            get;
            set;
        }

        /// <summary>
        ///  重量,
        /// </summary> 
        public string Weight
        {
            get;
            set;
        }

        ///// <summary>
        /////  商品介绍,
        ///// </summary> 
        //public string Description
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        ///  销售类型,0 赠品  1 正常销售
        /// </summary> 
        public int SalesType
        {
            get;
            set;
        }


        /// <summary>
        ///  销售个数,
        /// </summary> 
        public int SaleCounts
        {
            get;
            set;
        }

        /// <summary>
        ///  市场价,
        /// </summary> 
        public decimal MarketPrice
        {
            get;
            set;
        }

        /// <summary>
        ///  销售价,
        /// </summary> 
        public decimal SalePrice
        {
            get;
            set;
        }


        /// <summary>
        ///  可得积分,
        /// </summary> 
        public decimal Points
        {
            get;
            set;
        }

        /// <summary>
        ///  库存,
        /// </summary> 
        public decimal Stock
        {
            get;
            set;
        }
        /// <summary>
        ///  虚拟产品,虚拟产品无需物流
        /// </summary> 
        public bool IsVirtualProduct
        {
            get;
            set;
        }

        /// <summary>
        ///  生产日期,
        /// </summary> 
        public DateTime? ManufactureDate
        {
            get;
            set;
        }

        /// <summary>
        ///  上市日期,
        /// </summary> 
        public DateTime? LaunchDate
        {
            get;
            set;
        }

        /// <summary>
        ///  上架日期,
        /// </summary> 
        public DateTime SaleDate
        {
            get;
            set;
        }
        /// <summary>
        ///  启用SKU,
        /// </summary> 
        public bool IsEnableSku
        {
            get;
            set;
        }

        /// <summary>
        /// 价格范围
        /// </summary>
       
        public string PriceRange { get; set; }
        /// <summary>
        /// 价格范围
        /// </summary>
        
        public string DefaultSkuID { get; set; }
        /// <summary>
        /// 价格范围
        /// </summary>
        
        public string DefaultGgVals { get; set; }
        /// <summary>
        /// 规格名称串
        /// </summary>
        
        public string DefaultGgText { get; set; }
        
      
        public System.Data.DataTable dtImg { get; set; }
        
        public System.Data.DataTable dtAttr { get; set; }

        #endregion
    }


    /// <summary>
    /// 获取商品的url或者html  和视频连接
    /// </summary>
    public class ProductLink {

        public string ID { get; set; }
        /// <summary>
        /// 后续考虑静态页 先保留，目前的使用方式是 判断该值是否为null或者空 如果是  则使用HtmlStr
        /// </summary>
        public string UrlStr { get; set; }
        public string HtmlStr { get; set; }
        /// <summary>
        /// 最多三个
        /// </summary>
        public List<string> VideoUrl { get; set; }


        /// <summary>
        /// 视频封面
        /// </summary>
        public string VideoImg { get; set; }
    }



}
