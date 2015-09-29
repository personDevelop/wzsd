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
    /// 交易接口异步通知日志
    /// </summary>  
    [JsonObject]
    public partial class AsynchNotifyLog : BaseEntity
    {
        public static Column _ = new Column("AsynchNotifyLog");

        public AsynchNotifyLog()
        {
            this.TableName = "AsynchNotifyLog";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private DateTime _CreateTime;

        private string _TradeStatus;

        private string _ResOrderID;

        private string _TradeNo;

        private string _NodifyID;

        private string _NotifyContent;

        private string _Body;

        private string _ReturnContent;

        private string _Result;

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
        ///  支付网关,
        /// </summary>

        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  支付名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = true, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  通知时间,
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
        ///  交易状态,
        /// </summary>

        [DbProperty(MapingColumnName = "TradeStatus", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string TradeStatus
        {
            get
            {
                return this._TradeStatus;
            }
            set
            {
                this.OnPropertyChanged("TradeStatus", this._TradeStatus, value);
                this._TradeStatus = value;
            }
        }

        /// <summary>
        ///  对应订单ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ResOrderID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ResOrderID
        {
            get
            {
                return this._ResOrderID;
            }
            set
            {
                this.OnPropertyChanged("ResOrderID", this._ResOrderID, value);
                this._ResOrderID = value;
            }
        }

        /// <summary>
        ///  对应交易号,
        /// </summary>

        [DbProperty(MapingColumnName = "TradeNo", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string TradeNo
        {
            get
            {
                return this._TradeNo;
            }
            set
            {
                this.OnPropertyChanged("TradeNo", this._TradeNo, value);
                this._TradeNo = value;
            }
        }

        /// <summary>
        ///  对应通知ID,
        /// </summary>

        [DbProperty(MapingColumnName = "NodifyID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string NodifyID
        {
            get
            {
                return this._NodifyID;
            }
            set
            {
                this.OnPropertyChanged("NodifyID", this._NodifyID, value);
                this._NodifyID = value;
            }
        }

        /// <summary>
        ///  通知内容,
        /// </summary>

        [DbProperty(MapingColumnName = "NotifyContent", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 2000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string NotifyContent
        {
            get
            {
                return this._NotifyContent;
            }
            set
            {
                this.OnPropertyChanged("NotifyContent", this._NotifyContent, value);
                this._NotifyContent = value;
            }
        }

        /// <summary>
        ///  商品名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Body", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 2000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Body
        {
            get
            {
                return this._Body;
            }
            set
            {
                this.OnPropertyChanged("Body", this._Body, value);
                this._Body = value;
            }
        }

        /// <summary>
        ///  返回内容,
        /// </summary>

        [DbProperty(MapingColumnName = "ReturnContent", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ReturnContent
        {
            get
            {
                return this._ReturnContent;
            }
            set
            {
                this.OnPropertyChanged("ReturnContent", this._ReturnContent, value);
                this._ReturnContent = value;
            }
        }

        /// <summary>
        ///  接口达到的效果,成功更新订单付款，没有找到订单，没有找到订单付款方式等
        /// </summary>

        [DbProperty(MapingColumnName = "Result", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Result
        {
            get
            {
                return this._Result;
            }
            set
            {
                this.OnPropertyChanged("Result", this._Result, value);
                this._Result = value;
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

                CreateTime = new PropertyItem("CreateTime", tableName);

                TradeStatus = new PropertyItem("TradeStatus", tableName);

                ResOrderID = new PropertyItem("ResOrderID", tableName);

                TradeNo = new PropertyItem("TradeNo", tableName);

                NodifyID = new PropertyItem("NodifyID", tableName);

                NotifyContent = new PropertyItem("NotifyContent", tableName);

                Body = new PropertyItem("Body", tableName);

                ReturnContent = new PropertyItem("ReturnContent", tableName);

                Result = new PropertyItem("Result", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 支付网关,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 支付名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 通知时间,
            /// </summary> 
            public PropertyItem CreateTime = null;
            /// <summary>
            /// 交易状态,
            /// </summary> 
            public PropertyItem TradeStatus = null;
            /// <summary>
            /// 对应订单ID,
            /// </summary> 
            public PropertyItem ResOrderID = null;
            /// <summary>
            /// 对应交易号,
            /// </summary> 
            public PropertyItem TradeNo = null;
            /// <summary>
            /// 对应通知ID,
            /// </summary> 
            public PropertyItem NodifyID = null;
            /// <summary>
            /// 通知内容,
            /// </summary> 
            public PropertyItem NotifyContent = null;
            /// <summary>
            /// 商品名称,
            /// </summary> 
            public PropertyItem Body = null;
            /// <summary>
            /// 返回内容,
            /// </summary> 
            public PropertyItem ReturnContent = null;
            /// <summary>
            /// 接口达到的效果,成功更新订单付款，没有找到订单，没有找到订单付款方式等
            /// </summary> 
            public PropertyItem Result = null;
        }
        #endregion
    }

}
