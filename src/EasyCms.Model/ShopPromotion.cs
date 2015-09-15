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
    /// 促销活动
    /// </summary>  
    [JsonObject]
    public partial class ShopPromotion : BaseEntity
    {
        public static Column _ = new Column("ShopPromotion");

        public ShopPromotion()
        {
            this.TableName = "ShopPromotion";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _RuleID;

        private string _BuyCategoryId;

        private string _BuyCategoryName;

        private string _BuyProductId;

        private string _BuyProductName;

        private string _BuySKUID;

        private decimal _BuyCount;

        private string _HandsaleProductId;

        private string _HandsaleProductSKUID;

        private string _CouponID;

        private string _CouponName;

        private decimal _HandsaleMaxCount;

        private decimal _HandsaleCount;

        private decimal _MinPrice;

        private decimal _MaxPrice;

        private DateTime _StartDate;

        private DateTime _EndDate;

        private bool _IsEnable;

        private string _CreateUser;

        private DateTime _CreateDate;

        private string _Note;

        private int _ActionStatus;

        private decimal _HasSendCount;

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
        ///  促销规则,
        /// </summary>

        [DbProperty(MapingColumnName = "RuleID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RuleID
        {
            get
            {
                return this._RuleID;
            }
            set
            {
                this.OnPropertyChanged("RuleID", this._RuleID, value);
                this._RuleID = value;
            }
        }

        /// <summary>
        ///  促销商品分类,
        /// </summary>

        [DbProperty(MapingColumnName = "BuyCategoryId", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BuyCategoryId
        {
            get
            {
                return this._BuyCategoryId;
            }
            set
            {
                this.OnPropertyChanged("BuyCategoryId", this._BuyCategoryId, value);
                this._BuyCategoryId = value;
            }
        }

        /// <summary>
        ///  商品分类名称,
        /// </summary>

        [DbProperty(MapingColumnName = "BuyCategoryName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BuyCategoryName
        {
            get
            {
                return this._BuyCategoryName;
            }
            set
            {
                this.OnPropertyChanged("BuyCategoryName", this._BuyCategoryName, value);
                this._BuyCategoryName = value;
            }
        }

        /// <summary>
        ///  促销商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "BuyProductId", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BuyProductId
        {
            get
            {
                return this._BuyProductId;
            }
            set
            {
                this.OnPropertyChanged("BuyProductId", this._BuyProductId, value);
                this._BuyProductId = value;
            }
        }

        /// <summary>
        ///  商品名称,
        /// </summary>

        [DbProperty(MapingColumnName = "BuyProductName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BuyProductName
        {
            get
            {
                return this._BuyProductName;
            }
            set
            {
                this.OnPropertyChanged("BuyProductName", this._BuyProductName, value);
                this._BuyProductName = value;
            }
        }

        /// <summary>
        ///  促销商品SKUid,
        /// </summary>

        [DbProperty(MapingColumnName = "BuySKUID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BuySKUID
        {
            get
            {
                return this._BuySKUID;
            }
            set
            {
                this.OnPropertyChanged("BuySKUID", this._BuySKUID, value);
                this._BuySKUID = value;
            }
        }

        /// <summary>
        ///  购买指定数量,
        /// </summary>

        [DbProperty(MapingColumnName = "BuyCount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal BuyCount
        {
            get
            {
                return this._BuyCount;
            }
            set
            {
                this.OnPropertyChanged("BuyCount", this._BuyCount, value);
                this._BuyCount = value;
            }
        }

        /// <summary>
        ///  赠送商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "HandsaleProductId", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string HandsaleProductId
        {
            get
            {
                return this._HandsaleProductId;
            }
            set
            {
                this.OnPropertyChanged("HandsaleProductId", this._HandsaleProductId, value);
                this._HandsaleProductId = value;
            }
        }

        /// <summary>
        ///  赠送商品SKUID,
        /// </summary>

        [DbProperty(MapingColumnName = "HandsaleProductSKUID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string HandsaleProductSKUID
        {
            get
            {
                return this._HandsaleProductSKUID;
            }
            set
            {
                this.OnPropertyChanged("HandsaleProductSKUID", this._HandsaleProductSKUID, value);
                this._HandsaleProductSKUID = value;
            }
        }

        /// <summary>
        ///  赠送优惠券ID,
        /// </summary>

        [DbProperty(MapingColumnName = "CouponID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CouponID
        {
            get
            {
                return this._CouponID;
            }
            set
            {
                this.OnPropertyChanged("CouponID", this._CouponID, value);
                this._CouponID = value;
            }
        }

        /// <summary>
        ///  赠送优惠券名称,
        /// </summary>

        [DbProperty(MapingColumnName = "CouponName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CouponName
        {
            get
            {
                return this._CouponName;
            }
            set
            {
                this.OnPropertyChanged("CouponName", this._CouponName, value);
                this._CouponName = value;
            }
        }

        /// <summary>
        ///  最多赠送数量,
        /// </summary>

        [DbProperty(MapingColumnName = "HandsaleMaxCount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal HandsaleMaxCount
        {
            get
            {
                return this._HandsaleMaxCount;
            }
            set
            {
                this.OnPropertyChanged("HandsaleMaxCount", this._HandsaleMaxCount, value);
                this._HandsaleMaxCount = value;
            }
        }

        /// <summary>
        ///  赠送数量,
        /// </summary>

        [DbProperty(MapingColumnName = "HandsaleCount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal HandsaleCount
        {
            get
            {
                return this._HandsaleCount;
            }
            set
            {
                this.OnPropertyChanged("HandsaleCount", this._HandsaleCount, value);
                this._HandsaleCount = value;
            }
        }

        /// <summary>
        ///  限制最低金额,
        /// </summary>

        [DbProperty(MapingColumnName = "MinPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal MinPrice
        {
            get
            {
                return this._MinPrice;
            }
            set
            {
                this.OnPropertyChanged("MinPrice", this._MinPrice, value);
                this._MinPrice = value;
            }
        }

        /// <summary>
        ///  限制最高金额,
        /// </summary>

        [DbProperty(MapingColumnName = "MaxPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal MaxPrice
        {
            get
            {
                return this._MaxPrice;
            }
            set
            {
                this.OnPropertyChanged("MaxPrice", this._MaxPrice, value);
                this._MaxPrice = value;
            }
        }

        /// <summary>
        ///  活动开始时间,
        /// </summary>

        [DbProperty(MapingColumnName = "StartDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime StartDate
        {
            get
            {
                return this._StartDate;
            }
            set
            {
                this.OnPropertyChanged("StartDate", this._StartDate, value);
                this._StartDate = value;
            }
        }

        /// <summary>
        ///  活动结束时间,
        /// </summary>

        [DbProperty(MapingColumnName = "EndDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime EndDate
        {
            get
            {
                return this._EndDate;
            }
            set
            {
                this.OnPropertyChanged("EndDate", this._EndDate, value);
                this._EndDate = value;
            }
        }

        /// <summary>
        ///  状态,
        /// </summary>

        [DbProperty(MapingColumnName = "IsEnable", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsEnable
        {
            get
            {
                return this._IsEnable;
            }
            set
            {
                this.OnPropertyChanged("IsEnable", this._IsEnable, value);
                this._IsEnable = value;
            }
        }

        /// <summary>
        ///  创建人,
        /// </summary>

        [DbProperty(MapingColumnName = "CreateUser", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CreateUser
        {
            get
            {
                return this._CreateUser;
            }
            set
            {
                this.OnPropertyChanged("CreateUser", this._CreateUser, value);
                this._CreateUser = value;
            }
        }

        /// <summary>
        ///  创建时间,
        /// </summary>

        [DbProperty(MapingColumnName = "CreateDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime CreateDate
        {
            get
            {
                return this._CreateDate;
            }
            set
            {
                this.OnPropertyChanged("CreateDate", this._CreateDate, value);
                this._CreateDate = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Note
        {
            get
            {
                return this._Note;
            }
            set
            {
                this.OnPropertyChanged("Note", this._Note, value);
                this._Note = value;
            }
        }

        /// <summary>
        ///  活动状态,0有效，1无效
        /// </summary>

        [DbProperty(MapingColumnName = "ActionStatus", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ActionStatus
        {
            get
            {
                return this._ActionStatus;
            }
            set
            {
                this.OnPropertyChanged("ActionStatus", this._ActionStatus, value);
                this._ActionStatus = value;
            }
        }

        /// <summary>
        ///  已赠送数量,
        /// </summary>

        [DbProperty(MapingColumnName = "HasSendCount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal HasSendCount
        {
            get
            {
                return this._HasSendCount;
            }
            set
            {
                this.OnPropertyChanged("HasSendCount", this._HasSendCount, value);
                this._HasSendCount = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                RuleID = new PropertyItem("RuleID", tableName);

                BuyCategoryId = new PropertyItem("BuyCategoryId", tableName);

                BuyCategoryName = new PropertyItem("BuyCategoryName", tableName);

                BuyProductId = new PropertyItem("BuyProductId", tableName);

                BuyProductName = new PropertyItem("BuyProductName", tableName);

                BuySKUID = new PropertyItem("BuySKUID", tableName);

                BuyCount = new PropertyItem("BuyCount", tableName);

                HandsaleProductId = new PropertyItem("HandsaleProductId", tableName);

                HandsaleProductSKUID = new PropertyItem("HandsaleProductSKUID", tableName);

                CouponID = new PropertyItem("CouponID", tableName);

                CouponName = new PropertyItem("CouponName", tableName);

                HandsaleMaxCount = new PropertyItem("HandsaleMaxCount", tableName);

                HandsaleCount = new PropertyItem("HandsaleCount", tableName);

                MinPrice = new PropertyItem("MinPrice", tableName);

                MaxPrice = new PropertyItem("MaxPrice", tableName);

                StartDate = new PropertyItem("StartDate", tableName);

                EndDate = new PropertyItem("EndDate", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                CreateUser = new PropertyItem("CreateUser", tableName);

                CreateDate = new PropertyItem("CreateDate", tableName);

                Note = new PropertyItem("Note", tableName);

                ActionStatus = new PropertyItem("ActionStatus", tableName);

                HasSendCount = new PropertyItem("HasSendCount", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 促销规则,
            /// </summary> 
            public PropertyItem RuleID = null;
            /// <summary>
            /// 促销商品分类,
            /// </summary> 
            public PropertyItem BuyCategoryId = null;
            /// <summary>
            /// 商品分类名称,
            /// </summary> 
            public PropertyItem BuyCategoryName = null;
            /// <summary>
            /// 促销商品ID,
            /// </summary> 
            public PropertyItem BuyProductId = null;
            /// <summary>
            /// 商品名称,
            /// </summary> 
            public PropertyItem BuyProductName = null;
            /// <summary>
            /// 促销商品SKUid,
            /// </summary> 
            public PropertyItem BuySKUID = null;
            /// <summary>
            /// 购买指定数量,
            /// </summary> 
            public PropertyItem BuyCount = null;
            /// <summary>
            /// 赠送商品ID,
            /// </summary> 
            public PropertyItem HandsaleProductId = null;
            /// <summary>
            /// 赠送商品SKUID,
            /// </summary> 
            public PropertyItem HandsaleProductSKUID = null;
            /// <summary>
            /// 赠送优惠券ID,
            /// </summary> 
            public PropertyItem CouponID = null;
            /// <summary>
            /// 赠送优惠券名称,
            /// </summary> 
            public PropertyItem CouponName = null;
            /// <summary>
            /// 最多赠送数量,
            /// </summary> 
            public PropertyItem HandsaleMaxCount = null;
            /// <summary>
            /// 赠送数量,
            /// </summary> 
            public PropertyItem HandsaleCount = null;
            /// <summary>
            /// 限制最低金额,
            /// </summary> 
            public PropertyItem MinPrice = null;
            /// <summary>
            /// 限制最高金额,
            /// </summary> 
            public PropertyItem MaxPrice = null;
            /// <summary>
            /// 活动开始时间,
            /// </summary> 
            public PropertyItem StartDate = null;
            /// <summary>
            /// 活动结束时间,
            /// </summary> 
            public PropertyItem EndDate = null;
            /// <summary>
            /// 状态,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 创建人,
            /// </summary> 
            public PropertyItem CreateUser = null;
            /// <summary>
            /// 创建时间,
            /// </summary> 
            public PropertyItem CreateDate = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 活动状态,0有效，1无效
            /// </summary> 
            public PropertyItem ActionStatus = null;
            /// <summary>
            /// 已赠送数量,
            /// </summary> 
            public PropertyItem HasSendCount = null;
        }
        #endregion
    }

    public partial class ShopPromotion
    {
        protected override void OnCreate()
        {
            CreateDate = DateTime.Now;
            IsEnable = true;
        }
        [NotDbCol]
        public string BuySKUCode { get; set; }

        [NotDbCol]
        public string HandSKUCode { get; set; }
        [NotDbCol]
        public string HandProductName { get; set; }


        [NotDbCol]
        public string RuleName { get; set; }


        [NotDbCol]
        public string RuleTypeCode { get; set; }
        [NotDbCol]
        public string RuleTypeName { get; set; }


    }


    public class ShopPromotionSimpal
    {
        /// <summary>
        /// 促销活动ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 赠送产品名称
        /// </summary>
        public string HandsaleProductName { get; set; }

        /// <summary>
        /// 赠送优惠券名称
        /// </summary>
        public string HandsaleCouponName { get; set; }
    }
}
