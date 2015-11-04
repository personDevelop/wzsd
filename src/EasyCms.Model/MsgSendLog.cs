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
    /// 信息发送记录
    /// </summary>  
    [JsonObject]
    public partial class MsgSendLog : BaseEntity
    {
        public static Column _ = new Column("MsgSendLog");

        public MsgSendLog()
        {
            this.TableName = "MsgSendLog";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _UserID;

        private string _MyNum;

        private string _ContactNum;

        private SendTool _SendTool;

        private string _SendContent;

        private DateTime _SendTime;

        private string _OrderNo;

        private bool _MsgStatus;

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
        ///  我发联系号,
        /// </summary>

        [DbProperty(MapingColumnName = "MyNum", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string MyNum
        {
            get
            {
                return this._MyNum;
            }
            set
            {
                this.OnPropertyChanged("MyNum", this._MyNum, value);
                this._MyNum = value;
            }
        }

        /// <summary>
        ///  用户联系号,手机，邮箱，app
        /// </summary>

        [DbProperty(MapingColumnName = "ContactNum", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ContactNum
        {
            get
            {
                return this._ContactNum;
            }
            set
            {
                this.OnPropertyChanged("ContactNum", this._ContactNum, value);
                this._ContactNum = value;
            }
        }

        /// <summary>
        ///  发送工具,
        /// </summary>

        [DbProperty(MapingColumnName = "SendTool", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public SendTool SendTool
        {
            get
            {
                return this._SendTool;
            }
            set
            {
                this.OnPropertyChanged("SendTool", this._SendTool, value);
                this._SendTool = value;
            }
        }

        /// <summary>
        ///  发送内容,
        /// </summary>

        [DbProperty(MapingColumnName = "SendContent", DbTypeString = "ntext", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SendContent
        {
            get
            {
                return this._SendContent;
            }
            set
            {
                this.OnPropertyChanged("SendContent", this._SendContent, value);
                this._SendContent = value;
            }
        }

        /// <summary>
        ///  发送时间,
        /// </summary>

        [DbProperty(MapingColumnName = "SendTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime SendTime
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
        ///  流水号,有些接口可能需要个流水号，查账用
        /// </summary>

        [DbProperty(MapingColumnName = "OrderNo", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string OrderNo
        {
            get
            {
                return this._OrderNo;
            }
            set
            {
                this.OnPropertyChanged("OrderNo", this._OrderNo, value);
                this._OrderNo = value;
            }
        }

        /// <summary>
        ///  是否发送成功,
        /// </summary>

        [DbProperty(MapingColumnName = "MsgStatus", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool MsgStatus
        {
            get
            {
                return this._MsgStatus;
            }
            set
            {
                this.OnPropertyChanged("MsgStatus", this._MsgStatus, value);
                this._MsgStatus = value;
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

                MyNum = new PropertyItem("MyNum", tableName);

                ContactNum = new PropertyItem("ContactNum", tableName);

                SendTool = new PropertyItem("SendTool", tableName);

                SendContent = new PropertyItem("SendContent", tableName);

                SendTime = new PropertyItem("SendTime", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);

                MsgStatus = new PropertyItem("MsgStatus", tableName);


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
            /// 我发联系号,
            /// </summary> 
            public PropertyItem MyNum = null;
            /// <summary>
            /// 用户联系号,手机，邮箱，app
            /// </summary> 
            public PropertyItem ContactNum = null;
            /// <summary>
            /// 发送工具,
            /// </summary> 
            public PropertyItem SendTool = null;
            /// <summary>
            /// 发送内容,
            /// </summary> 
            public PropertyItem SendContent = null;
            /// <summary>
            /// 发送时间,
            /// </summary> 
            public PropertyItem SendTime = null;
            /// <summary>
            /// 流水号,有些接口可能需要个流水号，查账用
            /// </summary> 
            public PropertyItem OrderNo = null;
            /// <summary>
            /// 是否发送成功,
            /// </summary> 
            public PropertyItem MsgStatus = null;
        }
        #endregion
    }
}
