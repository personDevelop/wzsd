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
    /// 短信接口设置
    /// </summary>  
    [JsonObject]
    public partial class SysMsgInterSet : BaseEntity
    {
        public static Column _ = new Column("SysMsgInterSet");

        public SysMsgInterSet()
        {
            this.TableName = "SysMsgInterSet";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Name;

        private string _UserNo;

        private string _Pwd;

        private string _Url;

        private bool _IsEnable;

        private string _TelNum;

        private int _MaxWordCount;

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
        ///  短信平台名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  用户名,
        /// </summary>

        [DbProperty(MapingColumnName = "UserNo", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserNo
        {
            get
            {
                return this._UserNo;
            }
            set
            {
                this.OnPropertyChanged("UserNo", this._UserNo, value);
                this._UserNo = value;
            }
        }

        /// <summary>
        ///  密码,
        /// </summary>

        [DbProperty(MapingColumnName = "Pwd", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Pwd
        {
            get
            {
                return this._Pwd;
            }
            set
            {
                this.OnPropertyChanged("Pwd", this._Pwd, value);
                this._Pwd = value;
            }
        }

        /// <summary>
        ///  接口Url,
        /// </summary>

        [DbProperty(MapingColumnName = "Url", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Url
        {
            get
            {
                return this._Url;
            }
            set
            {
                this.OnPropertyChanged("Url", this._Url, value);
                this._Url = value;
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
        ///  手机号码,
        /// </summary>

        [DbProperty(MapingColumnName = "TelNum", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string TelNum
        {
            get
            {
                return this._TelNum;
            }
            set
            {
                this.OnPropertyChanged("TelNum", this._TelNum, value);
                this._TelNum = value;
            }
        }

        /// <summary>
        ///  最大字数,0不控制字符个数
        /// </summary>

        [DbProperty(MapingColumnName = "MaxWordCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int MaxWordCount
        {
            get
            {
                return this._MaxWordCount;
            }
            set
            {
                this.OnPropertyChanged("MaxWordCount", this._MaxWordCount, value);
                this._MaxWordCount = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                Name = new PropertyItem("Name", tableName);

                UserNo = new PropertyItem("UserNo", tableName);

                Pwd = new PropertyItem("Pwd", tableName);

                Url = new PropertyItem("Url", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                TelNum = new PropertyItem("TelNum", tableName);

                MaxWordCount = new PropertyItem("MaxWordCount", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 短信平台名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 用户名,
            /// </summary> 
            public PropertyItem UserNo = null;
            /// <summary>
            /// 密码,
            /// </summary> 
            public PropertyItem Pwd = null;
            /// <summary>
            /// 接口Url,
            /// </summary> 
            public PropertyItem Url = null;
            /// <summary>
            /// 启用,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 手机号码,
            /// </summary> 
            public PropertyItem TelNum = null;
            /// <summary>
            /// 最大字数,0不控制字符个数
            /// </summary> 
            public PropertyItem MaxWordCount = null;
        }
        #endregion
    }


    public partial class SysMsgInterSet
    {
        protected override void OnCreate()
        {
            IsEnable = true;

        }
    }
}
