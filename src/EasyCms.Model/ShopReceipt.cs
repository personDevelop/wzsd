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
    /// 收款单
    /// </summary>  
    [JsonObject]
    public partial class ShopReceipt : BaseEntity
    {
        public static Column _ = new Column("ShopReceipt");

        public ShopReceipt()
        {
            this.TableName = "ShopReceipt";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _UserID;

        private string _OrderID;

        private decimal _Amount;

        private DateTime _PayTime;

        private string _PayTypeID;

        private string _AdminID;

        private PayStatus _PayStatus;

        private string _Note;

        private bool _IsDelete;

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
        ///  用户ID,
        /// </summary>

        [DbProperty(MapingColumnName = "UserID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  订单ID,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this.OnPropertyChanged("OrderID", this._OrderID, value);
                this._OrderID = value;
            }
        }

        /// <summary>
        ///  金额,
        /// </summary>

        [DbProperty(MapingColumnName = "Amount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                this.OnPropertyChanged("Amount", this._Amount, value);
                this._Amount = value;
            }
        }

        /// <summary>
        ///  支付时间,
        /// </summary>

        [DbProperty(MapingColumnName = "PayTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime PayTime
        {
            get
            {
                return this._PayTime;
            }
            set
            {
                this.OnPropertyChanged("PayTime", this._PayTime, value);
                this._PayTime = value;
            }
        }

        /// <summary>
        ///  支付方式ID,
        /// </summary>

        [DbProperty(MapingColumnName = "PayTypeID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PayTypeID
        {
            get
            {
                return this._PayTypeID;
            }
            set
            {
                this.OnPropertyChanged("PayTypeID", this._PayTypeID, value);
                this._PayTypeID = value;
            }
        }

        /// <summary>
        ///  管理员ID,
        /// </summary>

        [DbProperty(MapingColumnName = "AdminID", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string AdminID
        {
            get
            {
                return this._AdminID;
            }
            set
            {
                this.OnPropertyChanged("AdminID", this._AdminID, value);
                this._AdminID = value;
            }
        }

        /// <summary>
        ///  支付状态,0:准备，1:支付成功
        /// </summary>

        [DbProperty(MapingColumnName = "PayStatus", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public PayStatus PayStatus
        {
            get
            {
                return this._PayStatus;
            }
            set
            {
                this.OnPropertyChanged("PayStatus", this._PayStatus, value);
                this._PayStatus = value;
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
        ///  是否删除,
        /// </summary>

        [DbProperty(MapingColumnName = "IsDelete", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsDelete
        {
            get
            {
                return this._IsDelete;
            }
            set
            {
                this.OnPropertyChanged("IsDelete", this._IsDelete, value);
                this._IsDelete = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                UserID = new PropertyItem("UserID", tableName);

                OrderID = new PropertyItem("OrderID", tableName);

                Amount = new PropertyItem("Amount", tableName);

                PayTime = new PropertyItem("PayTime", tableName);

                PayTypeID = new PropertyItem("PayTypeID", tableName);

                AdminID = new PropertyItem("AdminID", tableName);

                PayStatus = new PropertyItem("PayStatus", tableName);

                Note = new PropertyItem("Note", tableName);

                IsDelete = new PropertyItem("IsDelete", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 用户ID,
            /// </summary> 
            public PropertyItem UserID = null;
            /// <summary>
            /// 订单ID,
            /// </summary> 
            public PropertyItem OrderID = null;
            /// <summary>
            /// 金额,
            /// </summary> 
            public PropertyItem Amount = null;
            /// <summary>
            /// 支付时间,
            /// </summary> 
            public PropertyItem PayTime = null;
            /// <summary>
            /// 支付方式ID,
            /// </summary> 
            public PropertyItem PayTypeID = null;
            /// <summary>
            /// 管理员ID,
            /// </summary> 
            public PropertyItem AdminID = null;
            /// <summary>
            /// 支付状态,0:准备，1:支付成功
            /// </summary> 
            public PropertyItem PayStatus = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 是否删除,
            /// </summary> 
            public PropertyItem IsDelete = null;
        }
        #endregion
    }
}
