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
    /// 账号余额日志表
    /// </summary>  
    [JsonObject]
    public partial class AccuontMoneyLog : BaseEntity
    {
        public static Column _ = new Column("AccuontMoneyLog");

        public AccuontMoneyLog()
        {
            this.TableName = "AccuontMoneyLog";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _UserID;

        private AddOrRemove _OpType;

        private OpEvent _OpMoneyEvent;

        private DateTime _OpTime;

        private decimal _Amount;

        private decimal _Balance;

        private string _Note;

        private string _OpUserID;

        private OpStatus _OpStatus;

        private string _ReplyNote;

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
        ///  用户id,
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
        ///  增加或减少,
        /// </summary>

        [DbProperty(MapingColumnName = "OpType", DbTypeString = "int", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AddOrRemove OpType
        {
            get
            {
                return this._OpType;
            }
            set
            {
                this.OnPropertyChanged("OpType", this._OpType, value);
                this._OpType = value;
            }
        }

        /// <summary>
        ///  操作类型,
        /// </summary>

        [DbProperty(MapingColumnName = "OpMoneyEvent", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public OpEvent OpMoneyEvent
        {
            get
            {
                return this._OpMoneyEvent;
            }
            set
            {
                this.OnPropertyChanged("OpMoneyEvent", this._OpMoneyEvent, value);
                this._OpMoneyEvent = value;
            }
        }

        /// <summary>
        ///  操作时间,
        /// </summary>

        [DbProperty(MapingColumnName = "OpTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime OpTime
        {
            get
            {
                return this._OpTime;
            }
            set
            {
                this.OnPropertyChanged("OpTime", this._OpTime, value);
                this._OpTime = value;
            }
        }

        /// <summary>
        ///  变更金额,
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
        ///  余额,
        /// </summary>

        [DbProperty(MapingColumnName = "Balance ", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Balance
        {
            get
            {
                return this._Balance;
            }
            set
            {
                this.OnPropertyChanged("Balance ", this._Balance, value);
                this._Balance = value;
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
        ///  操作人（空为系统）,
        /// </summary>

        [DbProperty(MapingColumnName = "OpUserID", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string OpUserID
        {
            get
            {
                return this._OpUserID;
            }
            set
            {
                this.OnPropertyChanged("OpUserID", this._OpUserID, value);
                this._OpUserID = value;
            }
        }

        /// <summary>
        ///  状态,0未处理,1处理中,2成功,99失败
        /// </summary>

        [DbProperty(MapingColumnName = "OpStatus", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public OpStatus OpStatus
        {
            get
            {
                return this._OpStatus;
            }
            set
            {
                this.OnPropertyChanged("OpStatus", this._OpStatus, value);
                this._OpStatus = value;
            }
        }

        /// <summary>
        ///  回复备注信息,
        /// </summary>

        [DbProperty(MapingColumnName = "ReplyNote", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ReplyNote
        {
            get
            {
                return this._ReplyNote;
            }
            set
            {
                this.OnPropertyChanged("ReplyNote", this._ReplyNote, value);
                this._ReplyNote = value;
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

                OpType = new PropertyItem("OpType", tableName);

                OpMoneyEvent = new PropertyItem("OpMoneyEvent", tableName);

                OpTime = new PropertyItem("OpTime", tableName);

                Amount = new PropertyItem("Amount", tableName);

                Balance = new PropertyItem("Balance ", tableName);

                Note = new PropertyItem("Note", tableName);

                OpUserID = new PropertyItem("OpUserID", tableName);

                OpStatus = new PropertyItem("OpStatus", tableName);

                ReplyNote = new PropertyItem("ReplyNote", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 用户id,
            /// </summary> 
            public PropertyItem UserID = null;
            /// <summary>
            /// 增加或减少,
            /// </summary> 
            public PropertyItem OpType = null;
            /// <summary>
            /// 操作类型,
            /// </summary> 
            public PropertyItem OpMoneyEvent = null;
            /// <summary>
            /// 操作时间,
            /// </summary> 
            public PropertyItem OpTime = null;
            /// <summary>
            /// 变更金额,
            /// </summary> 
            public PropertyItem Amount = null;
            /// <summary>
            /// 余额,
            /// </summary> 
            public PropertyItem Balance = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 操作人（空为系统）,
            /// </summary> 
            public PropertyItem OpUserID = null;
            /// <summary>
            /// 状态,0未处理,1处理中,2成功,99失败
            /// </summary> 
            public PropertyItem OpStatus = null;
            /// <summary>
            /// 回复备注信息,
            /// </summary> 
            public PropertyItem ReplyNote = null;
        }
        #endregion
    }
}
