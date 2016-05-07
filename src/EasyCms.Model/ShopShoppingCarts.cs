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
    /// 购物车
    /// </summary>  
    [JsonObject]
    public partial class ShopShoppingCarts : BaseEntity
    {
        public static Column _ = new Column("ShopShoppingCarts");

        public ShopShoppingCarts()
        {
            this.TableName = "ShopShoppingCarts";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private ShopBuyType _ItemType;

        private string _ActivityID;

        private string _UserId;

        private string _ProductId;

        private string _SKU;

        private string _Name;

        private string _ThumbnailsUrl;

        private string _Description;

        private decimal _Quantity;

        private decimal _CostPrice;

        private decimal _MarketPrice;

        private decimal _SellPrice;

        private string _Attributes;

        private decimal _Weight;

        private DateTime _AddTime;

        private bool _IsSelected;

        #endregion

        #region 属性

        /// <summary>
        ///  主键ID,
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
        ///  类型,0 普通购物，1，赠品,2.套餐，3，团购，4 秒杀
        /// </summary>

        [DbProperty(MapingColumnName = "ItemType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((1))")]

        public ShopBuyType ItemType
        {
            get
            {
                return this._ItemType;
            }
            set
            {
                this.OnPropertyChanged("ItemType", this._ItemType, value);
                this._ItemType = value;
            }
        }

        /// <summary>
        ///  活动ID,促销活动的id 或者团购的id或者秒杀的id
        /// </summary>

        [DbProperty(MapingColumnName = "ActivityID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ActivityID
        {
            get
            {
                return this._ActivityID;
            }
            set
            {
                this.OnPropertyChanged("ActivityID", this._ActivityID, value);
                this._ActivityID = value;
            }
        }

        /// <summary>
        ///  会员ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "UserId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                this.OnPropertyChanged("UserId", this._UserId, value);
                this._UserId = value;
            }
        }

        /// <summary>
        ///  商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  SKU,
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
        ///  商品图标,
        /// </summary>

        [DbProperty(MapingColumnName = "ThumbnailsUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 600, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ThumbnailsUrl
        {
            get
            {
                return this._ThumbnailsUrl;
            }
            set
            {
                this.OnPropertyChanged("ThumbnailsUrl", this._ThumbnailsUrl, value);
                this._ThumbnailsUrl = value;
            }
        }

        /// <summary>
        ///  描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  数量,
        /// </summary>

        [DbProperty(MapingColumnName = "Quantity", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this.OnPropertyChanged("Quantity", this._Quantity, value);
                this._Quantity = value;
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
        ///  售价,
        /// </summary>

        [DbProperty(MapingColumnName = "SellPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal SellPrice
        {
            get
            {
                return this._SellPrice;
            }
            set
            {
                this.OnPropertyChanged("SellPrice", this._SellPrice, value);
                this._SellPrice = value;
            }
        }

        /// <summary>
        ///  属性,
        /// </summary>

        [DbProperty(MapingColumnName = "Attributes", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Attributes
        {
            get
            {
                return this._Attributes;
            }
            set
            {
                this.OnPropertyChanged("Attributes", this._Attributes, value);
                this._Attributes = value;
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
        ///  添加时间,
        /// </summary>

        [DbProperty(MapingColumnName = "AddTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime AddTime
        {
            get
            {
                return this._AddTime;
            }
            set
            {
                this.OnPropertyChanged("AddTime", this._AddTime, value);
                this._AddTime = value;
            }
        }

        /// <summary>
        ///  是否勾选，虚字段,
        /// </summary>
        [NotDbCol]

        [DbProperty(MapingColumnName = "IsSelected", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsSelected
        {
            get
            {
                return this._IsSelected;
            }
            set
            {
                this.OnPropertyChanged("IsSelected", this._IsSelected, value);
                this._IsSelected = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                ItemType = new PropertyItem("ItemType", tableName);

                ActivityID = new PropertyItem("ActivityID", tableName);

                UserId = new PropertyItem("UserId", tableName);

                ProductId = new PropertyItem("ProductId", tableName);

                SKU = new PropertyItem("SKU", tableName);

                Name = new PropertyItem("Name", tableName);

                ThumbnailsUrl = new PropertyItem("ThumbnailsUrl", tableName);

                Description = new PropertyItem("Description", tableName);

                Quantity = new PropertyItem("Quantity", tableName);

                CostPrice = new PropertyItem("CostPrice", tableName);

                MarketPrice = new PropertyItem("MarketPrice", tableName);

                SellPrice = new PropertyItem("SellPrice", tableName);

                Attributes = new PropertyItem("Attributes", tableName);

                Weight = new PropertyItem("Weight", tableName);

                AddTime = new PropertyItem("AddTime", tableName);

                IsSelected = new PropertyItem("IsSelected", tableName);


            }
            /// <summary>
            /// 主键ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 类型,0 普通购物，1，赠品,2.套餐，3，团购，4 秒杀
            /// </summary> 
            public PropertyItem ItemType = null;
            /// <summary>
            /// 活动ID,促销活动的id 或者团购的id或者秒杀的id
            /// </summary> 
            public PropertyItem ActivityID = null;
            /// <summary>
            /// 会员ID,
            /// </summary> 
            public PropertyItem UserId = null;
            /// <summary>
            /// 商品ID,
            /// </summary> 
            public PropertyItem ProductId = null;
            /// <summary>
            /// SKU,
            /// </summary> 
            public PropertyItem SKU = null;
            /// <summary>
            /// 商品名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 商品图标,
            /// </summary> 
            public PropertyItem ThumbnailsUrl = null;
            /// <summary>
            /// 描述,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 数量,
            /// </summary> 
            public PropertyItem Quantity = null;
            /// <summary>
            /// 成本价,
            /// </summary> 
            public PropertyItem CostPrice = null;
            /// <summary>
            /// 市场价,
            /// </summary> 
            public PropertyItem MarketPrice = null;
            /// <summary>
            /// 售价,
            /// </summary> 
            public PropertyItem SellPrice = null;
            /// <summary>
            /// 属性,
            /// </summary> 
            public PropertyItem Attributes = null;
            /// <summary>
            /// 重量,
            /// </summary> 
            public PropertyItem Weight = null;
            /// <summary>
            /// 添加时间,
            /// </summary> 
            public PropertyItem AddTime = null;
            /// <summary>
            /// 是否勾选，虚字段,
            /// </summary> 
            public PropertyItem IsSelected = null;
        }
        #endregion
    }

    /// <summary>
    /// Cookie里存贮的购物车信息
    /// </summary>  
    [JsonObject]
    public partial class CookieCard 
    {
         
        #region 属性
         
        public ShopBuyType BuyType
        {
            get;

            set;
        }

        /// <summary>
        ///  活动ID,促销活动的id 或者团购的id或者秒杀的id
        /// </summary>
 
        public string ActivityID
        {
            get;

            set;
        }

         

        /// <summary>
        ///  商品ID,
        /// </summary>
 
        public string ProductId
        {
            get;

            set;
        }

        /// <summary>
        ///  SKU,
        /// </summary>

          public string SKU
        {
            get;

            set;
        }

         
        public decimal Quantity
        {
            get;

            set;
        } 

        /// <summary>
        ///  添加时间,格式为 yyyy-MM-dd HH:mm:ss
        /// </summary>
 
        public string AddTime
        {
            get;

            set;
        }
 

        #endregion
         
    }


    public partial class ShopCardInfo
    {

        #region 属性
        
        public ShopBuyType BuyType
        {
            get;

            set;
        }

        /// <summary>
        ///  活动ID,促销活动的id 或者团购的id或者秒杀的id
        /// </summary>

        public string ActivityID
        {
            get;

            set;
        }



        /// <summary>
        ///  商品ID,
        /// </summary>

       
        public string ProductId
        {
            get;

            set;
        }

        /// <summary>
        ///  SKU,
        /// </summary>

        
        public string SKU
        {
            get;

            set;
        }


        public decimal Quantity
        {
            get;

            set;
        }

        /// <summary>
        ///  添加时间,格式为 yyyy-MM-dd HH:mm:ss
        /// </summary>

        public string AddTime
        {
            get;

            set;
        }
        public string Name
        {
            get;

            set;
        }

        public string GuiGeInfo
        {
            get;

            set;
        }
        public string ThumbImgUrl
        {
            get;

            set;
        }
        public decimal Stock
        {
            get;

            set;
        }
        public decimal SalePrice
        {
            get;

            set;
        }
        public bool IsSale
        {
            get;

            set;
        }
        #endregion

    }
}
