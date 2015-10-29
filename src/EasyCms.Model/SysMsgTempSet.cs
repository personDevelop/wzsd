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
    /// 短信模板设置
    /// </summary>  
    [JsonObject]
    public partial class SysMsgTempSet : BaseEntity
    {
        public static Column _ = new Column("SysMsgTempSet");

        public SysMsgTempSet()
        {
            this.TableName = "SysMsgTempSet";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private SendMsgType _SendType;

        private bool _IsManager;

        private string _ManagerTel;

        private string _MsgTemplate;

        private string _RelationPlat;

        private string _RelationPlatName;

        private bool _IsEnable;

        private string _Note;

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
        ///  发送类型,
        /// </summary>

        [DbProperty(MapingColumnName = "SendType", DbTypeString = "int", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public SendMsgType SendType
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
        ///  对管理员,
        /// </summary>

        [DbProperty(MapingColumnName = "IsManager", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsManager
        {
            get
            {
                return this._IsManager;
            }
            set
            {
                this.OnPropertyChanged("IsManager", this._IsManager, value);
                this._IsManager = value;
            }
        }

        /// <summary>
        ///  管理员接收手机号,
        /// </summary>

        [DbProperty(MapingColumnName = "ManagerTel", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 2000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ManagerTel
        {
            get
            {
                return this._ManagerTel;
            }
            set
            {
                this.OnPropertyChanged("ManagerTel", this._ManagerTel, value);
                this._ManagerTel = value;
            }
        }

        /// <summary>
        ///  短信模板,用户名：{$UserName} 用户ID：{$UserID} 真实姓名：{$RealName} 密码：{$Password} 用户昵称：{$NickName} 订单号码：{$OrderNO} 快递公司：{$ExpressCompany} 快递单号：{$ExpressNumber} 金额：{$Money} 时间：{$Time} 标题：{$Title} 内容：{$Content} 客服电话：{$Phone} 客服传真：{$Fax} 客服邮箱：{$Email} 客服QQ：{$QQ} 域名：{$Domain} 站点名称：{$SiteName} 验证码：{$CheckCode} 
        /// </summary>

        [DbProperty(MapingColumnName = "MsgTemplate", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 2000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string MsgTemplate
        {
            get
            {
                return this._MsgTemplate;
            }
            set
            {
                this.OnPropertyChanged("MsgTemplate", this._MsgTemplate, value);
                this._MsgTemplate = value;
            }
        }

        /// <summary>
        ///  关联短信平台,
        /// </summary>

        [DbProperty(MapingColumnName = "RelationPlat", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RelationPlat
        {
            get
            {
                return this._RelationPlat;
            }
            set
            {
                this.OnPropertyChanged("RelationPlat", this._RelationPlat, value);
                this._RelationPlat = value;
            }
        }

        /// <summary>
        ///  关联短信平台名称,
        /// </summary>

        [DbProperty(MapingColumnName = "RelationPlatName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RelationPlatName
        {
            get
            {
                return this._RelationPlatName;
            }
            set
            {
                this.OnPropertyChanged("RelationPlatName", this._RelationPlatName, value);
                this._RelationPlatName = value;
            }
        }

        /// <summary>
        ///  启用,
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

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                SendType = new PropertyItem("SendType", tableName);

                IsManager = new PropertyItem("IsManager", tableName);

                ManagerTel = new PropertyItem("ManagerTel", tableName);

                MsgTemplate = new PropertyItem("MsgTemplate", tableName);

                RelationPlat = new PropertyItem("RelationPlat", tableName);

                RelationPlatName = new PropertyItem("RelationPlatName", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                Note = new PropertyItem("Note", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 发送类型,
            /// </summary> 
            public PropertyItem SendType = null;
            /// <summary>
            /// 对管理员,
            /// </summary> 
            public PropertyItem IsManager = null;
            /// <summary>
            /// 管理员接收手机号,
            /// </summary> 
            public PropertyItem ManagerTel = null;
            /// <summary>
            /// 短信模板,用户名：{$UserName} 用户ID：{$UserID} 真实姓名：{$RealName} 密码：{$Password} 用户昵称：{$NickName} 订单号码：{$OrderNO} 快递公司：{$ExpressCompany} 快递单号：{$ExpressNumber} 金额：{$Money} 时间：{$Time} 标题：{$Title} 内容：{$Content} 客服电话：{$Phone} 客服传真：{$Fax} 客服邮箱：{$Email} 客服QQ：{$QQ} 域名：{$Domain} 站点名称：{$SiteName} 验证码：{$CheckCode} 
            /// </summary> 
            public PropertyItem MsgTemplate = null;
            /// <summary>
            /// 关联短信平台,
            /// </summary> 
            public PropertyItem RelationPlat = null;
            /// <summary>
            /// 关联短信平台名称,
            /// </summary> 
            public PropertyItem RelationPlatName = null;
            /// <summary>
            /// 启用,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
        }
        #endregion
    }
}
