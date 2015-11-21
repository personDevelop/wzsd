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
    /// 消息推送
    /// </summary>  
    [JsonObject]
    public partial class SendMsgInfo : BaseEntity
    {
        public static Column _ = new Column("SendMsgInfo");

        public SendMsgInfo()
        {
            this.TableName = "SendMsgInfo";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private SendTool _SendTool;

        private string _SendContent;

        private string _ProductID;

        private string _ProductName;

        private int _SendTimeType;

        private DateTime? _SendTime;

        private SendMsgStatus _Status;

        private int _TotalUserCount;

        private int _HasSendUserCount;

        private string _Note;

        private DateTime _CreateTime;

        private string _CreateName;

        private SendArea _SendArea;

        private string _UserOrder;

        private string _CustomerAccuont;

        private string _CustomerAccuontName;

        private string _CustomerTelNo;

        private DateTime? _StartRegistTime;

        private DateTime? _EndRegistTime;

        private int _MaxBuyCount;

        private int _MinBuyCount;

        private int _HasSendCount;

        private AppHandleTag _AppHandleTag;

        private string _AppHandleContent;

        private MsgType _MsgType;

        private string _NoticeTitle;

        private string _NoticeAlert;

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
        ///  推送工具,0短信，1app，2邮件
        /// </summary>

        [DbProperty(MapingColumnName = "SendTool", DbTypeString = "int", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  推送内容,
        /// </summary>

        [DbProperty(MapingColumnName = "SendContent", DbTypeString = "ntext", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  推送商品,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductID", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this.OnPropertyChanged("ProductID", this._ProductID, value);
                this._ProductID = value;
            }
        }

        /// <summary>
        ///  商品名称,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this.OnPropertyChanged("ProductName", this._ProductName, value);
                this._ProductName = value;
            }
        }

        /// <summary>
        ///  推送时机,0立即，1指定时机
        /// </summary>

        [DbProperty(MapingColumnName = "SendTimeType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int SendTimeType
        {
            get
            {
                return this._SendTimeType;
            }
            set
            {
                this.OnPropertyChanged("SendTimeType", this._SendTimeType, value);
                this._SendTimeType = value;
            }
        }

        /// <summary>
        ///  指定时间,
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
        ///  状态,0草稿，1生效，2发送中，3完成
        /// </summary>

        [DbProperty(MapingColumnName = "Status", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public SendMsgStatus Status
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
        ///  总发送人个数,
        /// </summary>

        [DbProperty(MapingColumnName = "TotalUserCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int TotalUserCount
        {
            get
            {
                return this._TotalUserCount;
            }
            set
            {
                this.OnPropertyChanged("TotalUserCount", this._TotalUserCount, value);
                this._TotalUserCount = value;
            }
        }

        /// <summary>
        ///  已成功发送人个数,
        /// </summary>

        [DbProperty(MapingColumnName = "HasSendUserCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int HasSendUserCount
        {
            get
            {
                return this._HasSendUserCount;
            }
            set
            {
                this.OnPropertyChanged("HasSendUserCount", this._HasSendUserCount, value);
                this._HasSendUserCount = value;
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
        ///  创建时间,
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
        ///  创建人,
        /// </summary>

        [DbProperty(MapingColumnName = "CreateName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CreateName
        {
            get
            {
                return this._CreateName;
            }
            set
            {
                this.OnPropertyChanged("CreateName", this._CreateName, value);
                this._CreateName = value;
            }
        }

        /// <summary>
        ///  发放范围,
        /// </summary>

        [DbProperty(MapingColumnName = "SendArea", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public SendArea SendArea
        {
            get
            {
                return this._SendArea;
            }
            set
            {
                this.OnPropertyChanged("SendArea", this._SendArea, value);
                this._SendArea = value;
            }
        }

        /// <summary>
        ///  指定会员等级,
        /// </summary>

        [DbProperty(MapingColumnName = "UserOrder", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserOrder
        {
            get
            {
                return this._UserOrder;
            }
            set
            {
                this.OnPropertyChanged("UserOrder", this._UserOrder, value);
                this._UserOrder = value;
            }
        }

        /// <summary>
        ///  自定义发放会员,
        /// </summary>

        [DbProperty(MapingColumnName = "CustomerAccuont", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CustomerAccuont
        {
            get
            {
                return this._CustomerAccuont;
            }
            set
            {
                this.OnPropertyChanged("CustomerAccuont", this._CustomerAccuont, value);
                this._CustomerAccuont = value;
            }
        }

        /// <summary>
        ///  会员名称,
        /// </summary>

        [DbProperty(MapingColumnName = "CustomerAccuontName", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CustomerAccuontName
        {
            get
            {
                return this._CustomerAccuontName;
            }
            set
            {
                this.OnPropertyChanged("CustomerAccuontName", this._CustomerAccuontName, value);
                this._CustomerAccuontName = value;
            }
        }

        /// <summary>
        ///  自定义发放人手机号,
        /// </summary>

        [DbProperty(MapingColumnName = "CustomerTelNo", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CustomerTelNo
        {
            get
            {
                return this._CustomerTelNo;
            }
            set
            {
                this.OnPropertyChanged("CustomerTelNo", this._CustomerTelNo, value);
                this._CustomerTelNo = value;
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
        ///  发送次数,可以重复发送
        /// </summary>

        [DbProperty(MapingColumnName = "HasSendCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int HasSendCount
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

        /// <summary>
        ///  APP处理标识,
        /// </summary>

        [DbProperty(MapingColumnName = "AppHandleTag", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AppHandleTag AppHandleTag
        {
            get
            {
                return this._AppHandleTag;
            }
            set
            {
                this.OnPropertyChanged("AppHandleTag", this._AppHandleTag, value);
                this._AppHandleTag = value;
            }
        }

        /// <summary>
        ///  App处理内容,
        /// </summary>

        [DbProperty(MapingColumnName = "AppHandleContent", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string AppHandleContent
        {
            get
            {
                return this._AppHandleContent;
            }
            set
            {
                this.OnPropertyChanged("AppHandleContent", this._AppHandleContent, value);
                this._AppHandleContent = value;
            }
        }

        /// <summary>
        ///  消息类型,0 notification-通知，1message-消息
        /// </summary>

        [DbProperty(MapingColumnName = "MsgType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public MsgType MsgType
        {
            get
            {
                return this._MsgType;
            }
            set
            {
                this.OnPropertyChanged("MsgType", this._MsgType, value);
                this._MsgType = value;
            }
        }

        /// <summary>
        ///  通知标题,
        /// </summary>

        [DbProperty(MapingColumnName = "NoticeTitle", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string NoticeTitle
        {
            get
            {
                return this._NoticeTitle;
            }
            set
            {
                this.OnPropertyChanged("NoticeTitle", this._NoticeTitle, value);
                this._NoticeTitle = value;
            }
        }

        /// <summary>
        ///  通知栏提示文字,
        /// </summary>

        [DbProperty(MapingColumnName = "NoticeAlert", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string NoticeAlert
        {
            get
            {
                return this._NoticeAlert;
            }
            set
            {
                this.OnPropertyChanged("NoticeAlert", this._NoticeAlert, value);
                this._NoticeAlert = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                SendTool = new PropertyItem("SendTool", tableName);

                SendContent = new PropertyItem("SendContent", tableName);

                ProductID = new PropertyItem("ProductID", tableName);

                ProductName = new PropertyItem("ProductName", tableName);

                SendTimeType = new PropertyItem("SendTimeType", tableName);

                SendTime = new PropertyItem("SendTime", tableName);

                Status = new PropertyItem("Status", tableName);

                TotalUserCount = new PropertyItem("TotalUserCount", tableName);

                HasSendUserCount = new PropertyItem("HasSendUserCount", tableName);

                Note = new PropertyItem("Note", tableName);

                CreateTime = new PropertyItem("CreateTime", tableName);

                CreateName = new PropertyItem("CreateName", tableName);

                SendArea = new PropertyItem("SendArea", tableName);

                UserOrder = new PropertyItem("UserOrder", tableName);

                CustomerAccuont = new PropertyItem("CustomerAccuont", tableName);

                CustomerAccuontName = new PropertyItem("CustomerAccuontName", tableName);

                CustomerTelNo = new PropertyItem("CustomerTelNo", tableName);

                StartRegistTime = new PropertyItem("StartRegistTime", tableName);

                EndRegistTime = new PropertyItem("EndRegistTime", tableName);

                MaxBuyCount = new PropertyItem("MaxBuyCount", tableName);

                MinBuyCount = new PropertyItem("MinBuyCount", tableName);

                HasSendCount = new PropertyItem("HasSendCount", tableName);

                AppHandleTag = new PropertyItem("AppHandleTag", tableName);

                AppHandleContent = new PropertyItem("AppHandleContent", tableName);

                MsgType = new PropertyItem("MsgType", tableName);

                NoticeTitle = new PropertyItem("NoticeTitle", tableName);

                NoticeAlert = new PropertyItem("NoticeAlert", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 推送工具,0短信，1app，2邮件
            /// </summary> 
            public PropertyItem SendTool = null;
            /// <summary>
            /// 推送内容,
            /// </summary> 
            public PropertyItem SendContent = null;
            /// <summary>
            /// 推送商品,
            /// </summary> 
            public PropertyItem ProductID = null;
            /// <summary>
            /// 商品名称,
            /// </summary> 
            public PropertyItem ProductName = null;
            /// <summary>
            /// 推送时机,0立即，1指定时机
            /// </summary> 
            public PropertyItem SendTimeType = null;
            /// <summary>
            /// 指定时间,
            /// </summary> 
            public PropertyItem SendTime = null;
            /// <summary>
            /// 状态,0草稿，1生效，2发送中，3完成
            /// </summary> 
            public PropertyItem Status = null;
            /// <summary>
            /// 总发送人个数,
            /// </summary> 
            public PropertyItem TotalUserCount = null;
            /// <summary>
            /// 已成功发送人个数,
            /// </summary> 
            public PropertyItem HasSendUserCount = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 创建时间,
            /// </summary> 
            public PropertyItem CreateTime = null;
            /// <summary>
            /// 创建人,
            /// </summary> 
            public PropertyItem CreateName = null;
            /// <summary>
            /// 发放范围,
            /// </summary> 
            public PropertyItem SendArea = null;
            /// <summary>
            /// 指定会员等级,
            /// </summary> 
            public PropertyItem UserOrder = null;
            /// <summary>
            /// 自定义发放会员,
            /// </summary> 
            public PropertyItem CustomerAccuont = null;
            /// <summary>
            /// 会员名称,
            /// </summary> 
            public PropertyItem CustomerAccuontName = null;
            /// <summary>
            /// 自定义发放人手机号,
            /// </summary> 
            public PropertyItem CustomerTelNo = null;
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
            /// 发送次数,可以重复发送
            /// </summary> 
            public PropertyItem HasSendCount = null;
            /// <summary>
            /// APP处理标识,
            /// </summary> 
            public PropertyItem AppHandleTag = null;
            /// <summary>
            /// App处理内容,
            /// </summary> 
            public PropertyItem AppHandleContent = null;
            /// <summary>
            /// 消息类型,0 notification-通知，1message-消息
            /// </summary> 
            public PropertyItem MsgType = null;
            /// <summary>
            /// 通知标题,
            /// </summary> 
            public PropertyItem NoticeTitle = null;
            /// <summary>
            /// 通知栏提示文字,
            /// </summary> 
            public PropertyItem NoticeAlert = null;
        }
        #endregion
    }

}
