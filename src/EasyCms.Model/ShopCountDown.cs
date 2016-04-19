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
    /// 限时抢购
    /// </summary>  
    [JsonObject]
    public partial class ShopCountDown : BaseEntity
    {
        public static Column _ = new Column("ShopCountDown");

        public ShopCountDown()
        {
            this.TableName = "ShopCountDown";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ActivityName;

        private string _ActivityTitle;

        private AcitivyStatus _ActivityStatus;

        private int _MaxCount;

        private int _BuyCount;

        private string _ImageID;

        private string _PCDescribe;

        private string _Describe;

        private string _MinUserOrder;

        private string _Coupon;

        private bool _IsLimit;

        private int _SendJf;

        private int _OneMaxCount;

        private int _OneMinCount;

        private ActivityType _ActivityType;

        private LoopType _LoopType;

        private string _KeyWords;

        private string _SEODescription;

        private DateTime _CreateDate;

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
        ///  活动名称,
        /// </summary>

        [DbProperty(MapingColumnName = "ActivityName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ActivityName
        {
            get
            {
                return this._ActivityName;
            }
            set
            {
                this.OnPropertyChanged("ActivityName", this._ActivityName, value);
                this._ActivityName = value;
            }
        }

        /// <summary>
        ///  活动标语,
        /// </summary>

        [DbProperty(MapingColumnName = "ActivityTitle", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 300, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ActivityTitle
        {
            get
            {
                return this._ActivityTitle;
            }
            set
            {
                this.OnPropertyChanged("ActivityTitle", this._ActivityTitle, value);
                this._ActivityTitle = value;
            }
        }

        /// <summary>
        ///  状态,
        /// </summary>

        [DbProperty(MapingColumnName = "ActivityStatus", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AcitivyStatus ActivityStatus
        {
            get
            {
                return this._ActivityStatus;
            }
            set
            {
                this.OnPropertyChanged("ActivityStatus", this._ActivityStatus, value);
                this._ActivityStatus = value;
            }
        }

        /// <summary>
        ///  限制总数量,
        /// </summary>

        [DbProperty(MapingColumnName = "MaxCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int MaxCount
        {
            get
            {
                return this._MaxCount;
            }
            set
            {
                this.OnPropertyChanged("MaxCount", this._MaxCount, value);
                this._MaxCount = value;
            }
        }

        /// <summary>
        ///  已购买的数量,
        /// </summary>

        [DbProperty(MapingColumnName = "BuyCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int BuyCount
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
        ///  宣传图片,
        /// </summary>

        [DbProperty(MapingColumnName = "ImageID", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ImageID
        {
            get
            {
                return this._ImageID;
            }
            set
            {
                this.OnPropertyChanged("ImageID", this._ImageID, value);
                this._ImageID = value;
            }
        }

        /// <summary>
        ///  电脑描述,
        /// </summary>

        [DbProperty(MapingColumnName = "PCDescribe", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PCDescribe
        {
            get
            {
                return this._PCDescribe;
            }
            set
            {
                this.OnPropertyChanged("PCDescribe", this._PCDescribe, value);
                this._PCDescribe = value;
            }
        }

        /// <summary>
        ///  描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Describe", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Describe
        {
            get
            {
                return this._Describe;
            }
            set
            {
                this.OnPropertyChanged("Describe", this._Describe, value);
                this._Describe = value;
            }
        }

        /// <summary>
        ///  最低用户等级,
        /// </summary>

        [DbProperty(MapingColumnName = "MinUserOrder", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string MinUserOrder
        {
            get
            {
                return this._MinUserOrder;
            }
            set
            {
                this.OnPropertyChanged("MinUserOrder", this._MinUserOrder, value);
                this._MinUserOrder = value;
            }
        }

        /// <summary>
        ///  赠送优惠劵,
        /// </summary>

        [DbProperty(MapingColumnName = "Coupon", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Coupon
        {
            get
            {
                return this._Coupon;
            }
            set
            {
                this.OnPropertyChanged("Coupon", this._Coupon, value);
                this._Coupon = value;
            }
        }

        /// <summary>
        ///  是否限购,
        /// </summary>

        [DbProperty(MapingColumnName = "IsLimit", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsLimit
        {
            get
            {
                return this._IsLimit;
            }
            set
            {
                this.OnPropertyChanged("IsLimit", this._IsLimit, value);
                this._IsLimit = value;
            }
        }

        /// <summary>
        ///  赠送积分,
        /// </summary>

        [DbProperty(MapingColumnName = "SendJf", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int SendJf
        {
            get
            {
                return this._SendJf;
            }
            set
            {
                this.OnPropertyChanged("SendJf", this._SendJf, value);
                this._SendJf = value;
            }
        }

        /// <summary>
        ///  每人限购上限,
        /// </summary>

        [DbProperty(MapingColumnName = "OneMaxCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int OneMaxCount
        {
            get
            {
                return this._OneMaxCount;
            }
            set
            {
                this.OnPropertyChanged("OneMaxCount", this._OneMaxCount, value);
                this._OneMaxCount = value;
            }
        }

        /// <summary>
        ///  每人限购下限,
        /// </summary>

        [DbProperty(MapingColumnName = "OneMinCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int OneMinCount
        {
            get
            {
                return this._OneMinCount;
            }
            set
            {
                this.OnPropertyChanged("OneMinCount", this._OneMinCount, value);
                this._OneMinCount = value;
            }
        }

        /// <summary>
        ///  活动类型,单品促销，买送促销，赠品促销，套装促销，满赠促销，满减促销，
        /// </summary>

        [DbProperty(MapingColumnName = "ActivityType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public ActivityType ActivityType
        {
            get
            {
                return this._ActivityType;
            }
            set
            {
                this.OnPropertyChanged("ActivityType", this._ActivityType, value);
                this._ActivityType = value;
            }
        }

        /// <summary>
        ///  轮询方式,无,天,周
        /// </summary>

        [DbProperty(MapingColumnName = "LoopType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public LoopType LoopType
        {
            get
            {
                return this._LoopType;
            }
            set
            {
                this.OnPropertyChanged("LoopType", this._LoopType, value);
                this._LoopType = value;
            }
        }

        /// <summary>
        ///  关键字,
        /// </summary>

        [DbProperty(MapingColumnName = "KeyWords", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string KeyWords
        {
            get
            {
                return this._KeyWords;
            }
            set
            {
                this.OnPropertyChanged("KeyWords", this._KeyWords, value);
                this._KeyWords = value;
            }
        }

        /// <summary>
        ///  SEO描述,
        /// </summary>

        [DbProperty(MapingColumnName = "SEODescription", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SEODescription
        {
            get
            {
                return this._SEODescription;
            }
            set
            {
                this.OnPropertyChanged("SEODescription", this._SEODescription, value);
                this._SEODescription = value;
            }
        }

        /// <summary>
        ///  创建日期,
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

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                ActivityName = new PropertyItem("ActivityName", tableName);

                ActivityTitle = new PropertyItem("ActivityTitle", tableName);

                ActivityStatus = new PropertyItem("ActivityStatus", tableName);

                MaxCount = new PropertyItem("MaxCount", tableName);

                BuyCount = new PropertyItem("BuyCount", tableName);

                ImageID = new PropertyItem("ImageID", tableName);

                PCDescribe = new PropertyItem("PCDescribe", tableName);

                Describe = new PropertyItem("Describe", tableName);

                MinUserOrder = new PropertyItem("MinUserOrder", tableName);

                Coupon = new PropertyItem("Coupon", tableName);

                IsLimit = new PropertyItem("IsLimit", tableName);

                SendJf = new PropertyItem("SendJf", tableName);

                OneMaxCount = new PropertyItem("OneMaxCount", tableName);

                OneMinCount = new PropertyItem("OneMinCount", tableName);

                ActivityType = new PropertyItem("ActivityType", tableName);

                LoopType = new PropertyItem("LoopType", tableName);

                KeyWords = new PropertyItem("KeyWords", tableName);

                SEODescription = new PropertyItem("SEODescription", tableName);

                CreateDate = new PropertyItem("CreateDate", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 活动名称,
            /// </summary> 
            public PropertyItem ActivityName = null;
            /// <summary>
            /// 活动标语,
            /// </summary> 
            public PropertyItem ActivityTitle = null;
            /// <summary>
            /// 状态,
            /// </summary> 
            public PropertyItem ActivityStatus = null;
            /// <summary>
            /// 限制总数量,
            /// </summary> 
            public PropertyItem MaxCount = null;
            /// <summary>
            /// 已购买的数量,
            /// </summary> 
            public PropertyItem BuyCount = null;
            /// <summary>
            /// 宣传图片,
            /// </summary> 
            public PropertyItem ImageID = null;
            /// <summary>
            /// 电脑描述,
            /// </summary> 
            public PropertyItem PCDescribe = null;
            /// <summary>
            /// 描述,
            /// </summary> 
            public PropertyItem Describe = null;
            /// <summary>
            /// 最低用户等级,
            /// </summary> 
            public PropertyItem MinUserOrder = null;
            /// <summary>
            /// 赠送优惠劵,
            /// </summary> 
            public PropertyItem Coupon = null;
            /// <summary>
            /// 是否限购,
            /// </summary> 
            public PropertyItem IsLimit = null;
            /// <summary>
            /// 赠送积分,
            /// </summary> 
            public PropertyItem SendJf = null;
            /// <summary>
            /// 每人限购上限,
            /// </summary> 
            public PropertyItem OneMaxCount = null;
            /// <summary>
            /// 每人限购下限,
            /// </summary> 
            public PropertyItem OneMinCount = null;
            /// <summary>
            /// 活动类型,单品促销，买送促销，赠品促销，套装促销，满赠促销，满减促销，
            /// </summary> 
            public PropertyItem ActivityType = null;
            /// <summary>
            /// 轮询方式,无,天,周
            /// </summary> 
            public PropertyItem LoopType = null;
            /// <summary>
            /// 关键字,
            /// </summary> 
            public PropertyItem KeyWords = null;
            /// <summary>
            /// SEO描述,
            /// </summary> 
            public PropertyItem SEODescription = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CreateDate = null;
        }
        #endregion
    }


    public partial class ShopCountDown
    {
        [NotDbCol]
        public string CouponName { get; set; }
    }
}
