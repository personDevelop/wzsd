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
    /// 优惠券发放
    /// </summary>  
    [JsonObject]
    public partial class SendCoupon : BaseEntity
    {
        public static Column _ = new Column("SendCoupon");

        public SendCoupon()
        {
            this.TableName = "SendCoupon";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _CouponID;

        private string _CouponName;

        private DateTime? _SendTime;

        private int _SendCount;

        private string _SendUserID;

        private string _SendUserName;

        private SendCouponType _SendType;

        private string _AccountOrder;

        private DateTime? _StartRegistTime;

        private DateTime? _EndRegistTime;

        private int _MaxBuyCount;

        private int _MinBuyCount;

        private bool _IsNotContendSended;

        private DateTime _CreateTime;

        private string _Note;

        private DjStatus _Status;

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
        ///  优惠券ID,
        /// </summary>

        [DbProperty(MapingColumnName = "CouponID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  优惠券名称,
        /// </summary>

        [DbProperty(MapingColumnName = "CouponName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  发放时间,
        /// </summary>

        [DbProperty(MapingColumnName = "SendTime", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? SendTime
        {
            get
            {
                return this._SendTime;
            }
            set
            {
                this.OnPropertyChanged("SendTime", this._SendTime, value);
                this._SendTime = value;
            }
        }

        /// <summary>
        ///  发放个数,
        /// </summary>

        [DbProperty(MapingColumnName = "SendCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int SendCount
        {
            get
            {
                return this._SendCount;
            }
            set
            {
                this.OnPropertyChanged("SendCount", this._SendCount, value);
                this._SendCount = value;
            }
        }

        /// <summary>
        ///  发放人id,
        /// </summary>

        [DbProperty(MapingColumnName = "SendUserID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SendUserID
        {
            get
            {
                return this._SendUserID;
            }
            set
            {
                this.OnPropertyChanged("SendUserID", this._SendUserID, value);
                this._SendUserID = value;
            }
        }

        /// <summary>
        ///  发放人名称,
        /// </summary>

        [DbProperty(MapingColumnName = "SendUserName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SendUserName
        {
            get
            {
                return this._SendUserName;
            }
            set
            {
                this.OnPropertyChanged("SendUserName", this._SendUserName, value);
                this._SendUserName = value;
            }
        }

        /// <summary>
        ///  发放类型,0全员发放，1按照用户等级发放,2按注册时间发放，3按购买次数发放
        /// </summary>

        [DbProperty(MapingColumnName = "SendType", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public SendCouponType SendType
        {
            get
            {
                return this._SendType;
            }
            set
            {
                this.OnPropertyChanged("SendType", this._SendType, value);
                this._SendType = value;
            }
        }

        /// <summary>
        ///  对应会员等级,
        /// </summary>

        [DbProperty(MapingColumnName = "AccountOrder", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string AccountOrder
        {
            get
            {
                return this._AccountOrder;
            }
            set
            {
                this.OnPropertyChanged("AccountOrder", this._AccountOrder, value);
                this._AccountOrder = value;
            }
        }

        /// <summary>
        ///  开始注册时间,
        /// </summary>

        [DbProperty(MapingColumnName = "StartRegistTime", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? StartRegistTime
        {
            get
            {
                return this._StartRegistTime;
            }
            set
            {
                this.OnPropertyChanged("StartRegistTime", this._StartRegistTime, value);
                this._StartRegistTime = value;
            }
        }

        /// <summary>
        ///  截止注册时间,
        /// </summary>

        [DbProperty(MapingColumnName = "EndRegistTime", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? EndRegistTime
        {
            get
            {
                return this._EndRegistTime;
            }
            set
            {
                this.OnPropertyChanged("EndRegistTime", this._EndRegistTime, value);
                this._EndRegistTime = value;
            }
        }

        /// <summary>
        ///  最大购买次数,
        /// </summary>

        [DbProperty(MapingColumnName = "MaxBuyCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int MaxBuyCount
        {
            get
            {
                return this._MaxBuyCount;
            }
            set
            {
                this.OnPropertyChanged("MaxBuyCount", this._MaxBuyCount, value);
                this._MaxBuyCount = value;
            }
        }

        /// <summary>
        ///  最低购买次数,
        /// </summary>

        [DbProperty(MapingColumnName = "MinBuyCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int MinBuyCount
        {
            get
            {
                return this._MinBuyCount;
            }
            set
            {
                this.OnPropertyChanged("MinBuyCount", this._MinBuyCount, value);
                this._MinBuyCount = value;
            }
        }

        /// <summary>
        ///  不包含已发放过的会员,
        /// </summary>

        [DbProperty(MapingColumnName = "IsNotContendSended", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsNotContendSended
        {
            get
            {
                return this._IsNotContendSended;
            }
            set
            {
                this.OnPropertyChanged("IsNotContendSended", this._IsNotContendSended, value);
                this._IsNotContendSended = value;
            }
        }

        /// <summary>
        ///  创建日期,
        /// </summary>

        [DbProperty(MapingColumnName = "CreateTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime CreateTime
        {
            get
            {
                return this._CreateTime;
            }
            set
            {
                this.OnPropertyChanged("CreateTime", this._CreateTime, value);
                this._CreateTime = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  状态,
        /// </summary>

        [DbProperty(MapingColumnName = "Status", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DjStatus Status
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

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                CouponID = new PropertyItem("CouponID", tableName);

                CouponName = new PropertyItem("CouponName", tableName);

                SendTime = new PropertyItem("SendTime", tableName);

                SendCount = new PropertyItem("SendCount", tableName);

                SendUserID = new PropertyItem("SendUserID", tableName);

                SendUserName = new PropertyItem("SendUserName", tableName);

                SendType = new PropertyItem("SendType", tableName);

                AccountOrder = new PropertyItem("AccountOrder", tableName);

                StartRegistTime = new PropertyItem("StartRegistTime", tableName);

                EndRegistTime = new PropertyItem("EndRegistTime", tableName);

                MaxBuyCount = new PropertyItem("MaxBuyCount", tableName);

                MinBuyCount = new PropertyItem("MinBuyCount", tableName);

                IsNotContendSended = new PropertyItem("IsNotContendSended", tableName);

                CreateTime = new PropertyItem("CreateTime", tableName);

                Note = new PropertyItem("Note", tableName);

                Status = new PropertyItem("Status", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 优惠券ID,
            /// </summary> 
            public PropertyItem CouponID = null;
            /// <summary>
            /// 优惠券名称,
            /// </summary> 
            public PropertyItem CouponName = null;
            /// <summary>
            /// 发放时间,
            /// </summary> 
            public PropertyItem SendTime = null;
            /// <summary>
            /// 发放个数,
            /// </summary> 
            public PropertyItem SendCount = null;
            /// <summary>
            /// 发放人id,
            /// </summary> 
            public PropertyItem SendUserID = null;
            /// <summary>
            /// 发放人名称,
            /// </summary> 
            public PropertyItem SendUserName = null;
            /// <summary>
            /// 发放类型,0全员发放，1按照用户等级发放,2按注册时间发放，3按购买次数发放
            /// </summary> 
            public PropertyItem SendType = null;
            /// <summary>
            /// 对应会员等级,
            /// </summary> 
            public PropertyItem AccountOrder = null;
            /// <summary>
            /// 开始注册时间,
            /// </summary> 
            public PropertyItem StartRegistTime = null;
            /// <summary>
            /// 截止注册时间,
            /// </summary> 
            public PropertyItem EndRegistTime = null;
            /// <summary>
            /// 最大购买次数,
            /// </summary> 
            public PropertyItem MaxBuyCount = null;
            /// <summary>
            /// 最低购买次数,
            /// </summary> 
            public PropertyItem MinBuyCount = null;
            /// <summary>
            /// 不包含已发放过的会员,
            /// </summary> 
            public PropertyItem IsNotContendSended = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CreateTime = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 状态,
            /// </summary> 
            public PropertyItem Status = null;
        }
        #endregion
    }
}
