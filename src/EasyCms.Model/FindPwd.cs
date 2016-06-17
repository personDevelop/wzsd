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
    /// 查找密码记录
    /// </summary>  
    [JsonObject]
    public partial class FindPwd : BaseEntity
    {
        public static Column _ = new Column("FindPwd");

        public FindPwd()
        {
            this.TableName = "FindPwd";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _UserID;

        private string _EmailOrTel;

        private string _VariyCode;

        private ValidType _VaryType;

        private DateTime _SendTime;

        private DateTime _EndTime;

        private SendMsgType _Target;

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
        ///  邮箱或电话,
        /// </summary>

        [DbProperty(MapingColumnName = "EmailOrTel", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string EmailOrTel
        {
            get
            {
                return this._EmailOrTel;
            }
            set
            {
                this.OnPropertyChanged("EmailOrTel", this._EmailOrTel, value);


                this._EmailOrTel = value;
            }
        }

        /// <summary>
        ///  验证信息,
        /// </summary>

        [DbProperty(MapingColumnName = "VariyCode", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string VariyCode
        {
            get
            {
                return this._VariyCode;
            }
            set
            {
                this.OnPropertyChanged("VariyCode", this._VariyCode, value);


                this._VariyCode = value;
            }
        }

        /// <summary>
        ///  类型,0邮箱,1手机
        /// </summary>

        [DbProperty(MapingColumnName = "VaryType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public ValidType VaryType
        {
            get
            {
                return this._VaryType;
            }
            set
            {
                this.OnPropertyChanged("VaryType", this._VaryType, value);


                this._VaryType = value;
            }
        }

        /// <summary>
        ///  发生时间,
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
        ///  过期时间,
        /// </summary>

        [DbProperty(MapingColumnName = "EndTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime EndTime
        {
            get
            {
                return this._EndTime;
            }
            set
            {
                this.OnPropertyChanged("EndTime", this._EndTime, value);


                this._EndTime = value;
            }
        }

        /// <summary>
        ///  动作目的,
        /// </summary>

        [DbProperty(MapingColumnName = "Target", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public SendMsgType Target
        {
            get
            {
                return this._Target;
            }
            set
            {
                this.OnPropertyChanged("Target", this._Target, value);


                this._Target = value;
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

                EmailOrTel = new PropertyItem("EmailOrTel", tableName);

                VariyCode = new PropertyItem("VariyCode", tableName);

                VaryType = new PropertyItem("VaryType", tableName);

                SendTime = new PropertyItem("SendTime", tableName);

                EndTime = new PropertyItem("EndTime", tableName);

                Target = new PropertyItem("Target", tableName);


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
            /// 邮箱或电话,
            /// </summary> 
            public PropertyItem EmailOrTel = null;
            /// <summary>
            /// 验证信息,
            /// </summary> 
            public PropertyItem VariyCode = null;
            /// <summary>
            /// 类型,0邮箱,1手机
            /// </summary> 
            public PropertyItem VaryType = null;
            /// <summary>
            /// 发生时间,
            /// </summary> 
            public PropertyItem SendTime = null;
            /// <summary>
            /// 过期时间,
            /// </summary> 
            public PropertyItem EndTime = null;
            /// <summary>
            /// 动作目的,
            /// </summary> 
            public PropertyItem Target = null;
        }
        #endregion
    }

    public partial class FindPwd {
        [NotDbCol]
        public string Code { get; set; }

    }
}
