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
    /// 团购信息
    /// </summary>  
    [JsonObject]
    public partial class ShopGroupBuy : BaseEntity
    {
        public static Column _ = new Column("ShopGroupBuy");

        public ShopGroupBuy()
        {
            this.TableName = "ShopGroupBuy";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ActivityName;

        private string _ActivityTitle;

        private int _RegionId;

        private DateTime _StartDate;

        private DateTime _EndDate;

        private decimal _FinePrice;

        private int _GroupCount;

        private int _LimitQty;

        private int _MaxCount;

        private int _BuyCount;

        private string _GroupBuyImage;

        private int _Sequence;

        private AcitivyStatus _Status;

        private string _KeyWords;

        private string _SEODescription;

        private string _PCDescribe;

        private string _Description;

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

        [DbProperty(MapingColumnName = "ActivityTitle", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  所在地,
        /// </summary>

        [DbProperty(MapingColumnName = "RegionId", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int RegionId
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
        ///  团购开始时间,
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
        ///  团购结束时间,
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
        ///  违约金,团购成功了，但是最终用户退单 收违约金
        /// </summary>

        [DbProperty(MapingColumnName = "FinePrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal FinePrice
        {
            get
            {
                return this._FinePrice;
            }
            set
            {
                this.OnPropertyChanged("FinePrice", this._FinePrice, value);
                this._FinePrice = value;
            }
        }

        /// <summary>
        ///  团购满足数量,达到这个数量 团购才算成功
        /// </summary>

        [DbProperty(MapingColumnName = "GroupCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int GroupCount
        {
            get
            {
                return this._GroupCount;
            }
            set
            {
                this.OnPropertyChanged("GroupCount", this._GroupCount, value);
                this._GroupCount = value;
            }
        }

        /// <summary>
        ///  单次购买限购数量,一个订单限购数量
        /// </summary>

        [DbProperty(MapingColumnName = "LimitQty", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int LimitQty
        {
            get
            {
                return this._LimitQty;
            }
            set
            {
                this.OnPropertyChanged("LimitQty", this._LimitQty, value);
                this._LimitQty = value;
            }
        }

        /// <summary>
        ///  商品总限购数量,一个账号限购数量
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
        ///  已提交订单购买的数量,当这个字段和GroupCount相等时，团购自动关闭
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
        ///  团购宣传图片,
        /// </summary>

        [DbProperty(MapingColumnName = "GroupBuyImage", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string GroupBuyImage
        {
            get
            {
                return this._GroupBuyImage;
            }
            set
            {
                this.OnPropertyChanged("GroupBuyImage", this._GroupBuyImage, value);
                this._GroupBuyImage = value;
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
        ///  团购状态,
        /// </summary>

        [DbProperty(MapingColumnName = "Status", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AcitivyStatus Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this.OnPropertyChanged("Status", this._Status, value);
                this._Status = value;
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
        ///  团购描述,
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

                RegionId = new PropertyItem("RegionId", tableName);

                StartDate = new PropertyItem("StartDate", tableName);

                EndDate = new PropertyItem("EndDate", tableName);

                FinePrice = new PropertyItem("FinePrice", tableName);

                GroupCount = new PropertyItem("GroupCount", tableName);

                LimitQty = new PropertyItem("LimitQty", tableName);

                MaxCount = new PropertyItem("MaxCount", tableName);

                BuyCount = new PropertyItem("BuyCount", tableName);

                GroupBuyImage = new PropertyItem("GroupBuyImage", tableName);

                Sequence = new PropertyItem("Sequence", tableName);

                Status = new PropertyItem("Status", tableName);

                KeyWords = new PropertyItem("KeyWords", tableName);

                SEODescription = new PropertyItem("SEODescription", tableName);

                PCDescribe = new PropertyItem("PCDescribe", tableName);

                Description = new PropertyItem("Description", tableName);

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
            /// 所在地,
            /// </summary> 
            public PropertyItem RegionId = null;
            /// <summary>
            /// 团购开始时间,
            /// </summary> 
            public PropertyItem StartDate = null;
            /// <summary>
            /// 团购结束时间,
            /// </summary> 
            public PropertyItem EndDate = null;
            /// <summary>
            /// 违约金,团购成功了，但是最终用户退单 收违约金
            /// </summary> 
            public PropertyItem FinePrice = null;
            /// <summary>
            /// 团购满足数量,达到这个数量 团购才算成功
            /// </summary> 
            public PropertyItem GroupCount = null;
            /// <summary>
            /// 单次购买限购数量,一个订单限购数量
            /// </summary> 
            public PropertyItem LimitQty = null;
            /// <summary>
            /// 商品总限购数量,一个账号限购数量
            /// </summary> 
            public PropertyItem MaxCount = null;
            /// <summary>
            /// 已提交订单购买的数量,当这个字段和GroupCount相等时，团购自动关闭
            /// </summary> 
            public PropertyItem BuyCount = null;
            /// <summary>
            /// 团购宣传图片,
            /// </summary> 
            public PropertyItem GroupBuyImage = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem Sequence = null;
            /// <summary>
            /// 团购状态,
            /// </summary> 
            public PropertyItem Status = null;
            /// <summary>
            /// 关键字,
            /// </summary> 
            public PropertyItem KeyWords = null;
            /// <summary>
            /// SEO描述,
            /// </summary> 
            public PropertyItem SEODescription = null;
            /// <summary>
            /// 电脑描述,
            /// </summary> 
            public PropertyItem PCDescribe = null;
            /// <summary>
            /// 团购描述,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CreateDate = null;
        }
        #endregion
    }
}
