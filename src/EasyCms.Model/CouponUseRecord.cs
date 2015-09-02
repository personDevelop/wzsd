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
    /// 优惠券使用记录
    /// </summary>  
    [JsonObject]
    public partial class CouponUseRecord : BaseEntity
    {
        public static Column _ = new Column("CouponUseRecord");

        public CouponUseRecord()
        {
            this.TableName = "CouponUseRecord";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _CouponUserID;

        private DateTime _CreateDate;

        private int _ActionType;

        private string _ActionDescribe;

        private string _UserID;

        private string _RelationOrderID;

        private string _RelationOrderDetailID;

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
        ///  优惠券会员ID,
        /// </summary>

        [DbProperty(MapingColumnName = "CouponUserID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CouponUserID
        {
            get
            {
                return this._CouponUserID;
            }
            set
            {
                this.OnPropertyChanged("CouponUserID", this._CouponUserID, value);
                this._CouponUserID = value;
            }
        }

        /// <summary>
        ///  发生时间,
        /// </summary>

        [DbProperty(MapingColumnName = "CreateDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  动作类型,
        /// </summary>

        [DbProperty(MapingColumnName = "ActionType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ActionType
        {
            get
            {
                return this._ActionType;
            }
            set
            {
                this.OnPropertyChanged("ActionType", this._ActionType, value);
                this._ActionType = value;
            }
        }

        /// <summary>
        ///  动作描述,
        /// </summary>

        [DbProperty(MapingColumnName = "ActionDescribe", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ActionDescribe
        {
            get
            {
                return this._ActionDescribe;
            }
            set
            {
                this.OnPropertyChanged("ActionDescribe", this._ActionDescribe, value);
                this._ActionDescribe = value;
            }
        }

        /// <summary>
        ///  会员ID,
        /// </summary>

        [DbProperty(MapingColumnName = "UserID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                this.OnPropertyChanged("UserID", this._UserID, value);
                this._UserID = value;
            }
        }

        /// <summary>
        ///  关联订单ID,
        /// </summary>

        [DbProperty(MapingColumnName = "RelationOrderID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RelationOrderID
        {
            get
            {
                return this._RelationOrderID;
            }
            set
            {
                this.OnPropertyChanged("RelationOrderID", this._RelationOrderID, value);
                this._RelationOrderID = value;
            }
        }

        /// <summary>
        ///  关联订单明细ID,
        /// </summary>

        [DbProperty(MapingColumnName = "RelationOrderDetailID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RelationOrderDetailID
        {
            get
            {
                return this._RelationOrderDetailID;
            }
            set
            {
                this.OnPropertyChanged("RelationOrderDetailID", this._RelationOrderDetailID, value);
                this._RelationOrderDetailID = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                CouponUserID = new PropertyItem("CouponUserID", tableName);

                CreateDate = new PropertyItem("CreateDate", tableName);

                ActionType = new PropertyItem("ActionType", tableName);

                ActionDescribe = new PropertyItem("ActionDescribe", tableName);

                UserID = new PropertyItem("UserID", tableName);

                RelationOrderID = new PropertyItem("RelationOrderID", tableName);

                RelationOrderDetailID = new PropertyItem("RelationOrderDetailID", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 优惠券会员ID,
            /// </summary> 
            public PropertyItem CouponUserID = null;
            /// <summary>
            /// 发生时间,
            /// </summary> 
            public PropertyItem CreateDate = null;
            /// <summary>
            /// 动作类型,
            /// </summary> 
            public PropertyItem ActionType = null;
            /// <summary>
            /// 动作描述,
            /// </summary> 
            public PropertyItem ActionDescribe = null;
            /// <summary>
            /// 会员ID,
            /// </summary> 
            public PropertyItem UserID = null;
            /// <summary>
            /// 关联订单ID,
            /// </summary> 
            public PropertyItem RelationOrderID = null;
            /// <summary>
            /// 关联订单明细ID,
            /// </summary> 
            public PropertyItem RelationOrderDetailID = null;
        }
        #endregion
    }

}
