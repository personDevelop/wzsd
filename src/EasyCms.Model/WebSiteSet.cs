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
    /// 网站设置
    /// </summary>  
    [JsonObject]
    public partial class WebSiteSet : BaseEntity
    {
        public static Column _ = new Column("WebSiteSet");

        public WebSiteSet()
        {
            this.TableName = "WebSiteSet";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _WebSiteUrl;

        private string _Name;

        private string _Logo;

        private string _Contactor;

        private string _QQ;

        private string _Email;

        private string _Telphone;

        private string _CallNum;

        private string _Address;

        private string _titlePix;

        private string _Keywords;

        private string _Description;

        private string _BeiAN;

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
        ///  网址,
        /// </summary>

        [DbProperty(MapingColumnName = "WebSiteUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = true, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string WebSiteUrl
        {
            get
            {
                return this._WebSiteUrl;
            }
            set
            {
                this.OnPropertyChanged("WebSiteUrl", this._WebSiteUrl, value);
                this._WebSiteUrl = value;
            }
        }

        /// <summary>
        ///  名称,
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
        ///  logo,
        /// </summary>

        [DbProperty(MapingColumnName = "Logo", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Logo
        {
            get
            {
                return this._Logo;
            }
            set
            {
                this.OnPropertyChanged("Logo", this._Logo, value);
                this._Logo = value;
            }
        }

        /// <summary>
        ///  联系人,
        /// </summary>

        [DbProperty(MapingColumnName = "Contactor", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Contactor
        {
            get
            {
                return this._Contactor;
            }
            set
            {
                this.OnPropertyChanged("Contactor", this._Contactor, value);
                this._Contactor = value;
            }
        }

        /// <summary>
        ///  QQ,
        /// </summary>

        [DbProperty(MapingColumnName = "QQ", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string QQ
        {
            get
            {
                return this._QQ;
            }
            set
            {
                this.OnPropertyChanged("QQ", this._QQ, value);
                this._QQ = value;
            }
        }

        /// <summary>
        ///  Email,
        /// </summary>

        [DbProperty(MapingColumnName = "Email", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this.OnPropertyChanged("Email", this._Email, value);
                this._Email = value;
            }
        }

        /// <summary>
        ///  手机,
        /// </summary>

        [DbProperty(MapingColumnName = "Telphone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Telphone
        {
            get
            {
                return this._Telphone;
            }
            set
            {
                this.OnPropertyChanged("Telphone", this._Telphone, value);
                this._Telphone = value;
            }
        }

        /// <summary>
        ///  客服电话,
        /// </summary>

        [DbProperty(MapingColumnName = "CallNum", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CallNum
        {
            get
            {
                return this._CallNum;
            }
            set
            {
                this.OnPropertyChanged("CallNum", this._CallNum, value);
                this._CallNum = value;
            }
        }

        /// <summary>
        ///  地址,
        /// </summary>

        [DbProperty(MapingColumnName = "Address", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this.OnPropertyChanged("Address", this._Address, value);
                this._Address = value;
            }
        }

        /// <summary>
        ///  首页title后缀,
        /// </summary>

        [DbProperty(MapingColumnName = "titlePix", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string titlePix
        {
            get
            {
                return this._titlePix;
            }
            set
            {
                this.OnPropertyChanged("titlePix", this._titlePix, value);
                this._titlePix = value;
            }
        }

        /// <summary>
        ///  首页keywords,
        /// </summary>

        [DbProperty(MapingColumnName = "Keywords", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Keywords
        {
            get
            {
                return this._Keywords;
            }
            set
            {
                this.OnPropertyChanged("Keywords", this._Keywords, value);
                this._Keywords = value;
            }
        }

        /// <summary>
        ///  首页description,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this.OnPropertyChanged("Description", this._Description, value);
                this._Description = value;
            }
        }

        /// <summary>
        ///  备案信息,
        /// </summary>

        [DbProperty(MapingColumnName = "BeiAN", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BeiAN
        {
            get
            {
                return this._BeiAN;
            }
            set
            {
                this.OnPropertyChanged("BeiAN", this._BeiAN, value);
                this._BeiAN = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                WebSiteUrl = new PropertyItem("WebSiteUrl", tableName);

                Name = new PropertyItem("Name", tableName);

                Logo = new PropertyItem("Logo", tableName);

                Contactor = new PropertyItem("Contactor", tableName);

                QQ = new PropertyItem("QQ", tableName);

                Email = new PropertyItem("Email", tableName);

                Telphone = new PropertyItem("Telphone", tableName);

                CallNum = new PropertyItem("CallNum", tableName);

                Address = new PropertyItem("Address", tableName);

                titlePix = new PropertyItem("titlePix", tableName);

                Keywords = new PropertyItem("Keywords", tableName);

                Description = new PropertyItem("Description", tableName);

                BeiAN = new PropertyItem("BeiAN", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 网址,
            /// </summary> 
            public PropertyItem WebSiteUrl = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// logo,
            /// </summary> 
            public PropertyItem Logo = null;
            /// <summary>
            /// 联系人,
            /// </summary> 
            public PropertyItem Contactor = null;
            /// <summary>
            /// QQ,
            /// </summary> 
            public PropertyItem QQ = null;
            /// <summary>
            /// Email,
            /// </summary> 
            public PropertyItem Email = null;
            /// <summary>
            /// 手机,
            /// </summary> 
            public PropertyItem Telphone = null;
            /// <summary>
            /// 客服电话,
            /// </summary> 
            public PropertyItem CallNum = null;
            /// <summary>
            /// 地址,
            /// </summary> 
            public PropertyItem Address = null;
            /// <summary>
            /// 首页title后缀,
            /// </summary> 
            public PropertyItem titlePix = null;
            /// <summary>
            /// 首页keywords,
            /// </summary> 
            public PropertyItem Keywords = null;
            /// <summary>
            /// 首页description,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 备案信息,
            /// </summary> 
            public PropertyItem BeiAN = null;
        }
        #endregion
    }
}
