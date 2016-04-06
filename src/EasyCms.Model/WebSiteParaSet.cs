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
    /// 网站参数设置
    /// </summary>  
    [JsonObject]
    public partial class WebSiteParaSet : BaseEntity
    {
        public static Column _ = new Column("WebSiteParaSet");

        public WebSiteParaSet()
        {
            this.TableName = "WebSiteParaSet";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private RegistType _RegistType;

        private int _LoginNameType;

        private string _SaveName;

        private int _RegistraTimeLimit;

        private string _ShadowLoginName;

        private int _LoginErrorCount;

        private string _ImgType;

        private int _ImgLenth;

        private WaterType _WaterType;

        private int _WaterQuality;

        private WaterLocation _WaterLocation;

        private string _WaterText;

        private string _WaterFamily;

        private int _WaterTextSize;

        private string _WaterImg;

        private int _ImgTransparency;

        private string _BrandThumbnail;

        private string _DisplayThumbnail;

        private string _UserPhotoThumbnail;

        private string _UserOrderThumbnail;

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
        ///  注册名类型,
        /// </summary>

        [DbProperty(MapingColumnName = "RegistType", DbTypeString = "int", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public RegistType RegistType
        {
            get
            {
                return this._RegistType;
            }
            set
            {
                this.OnPropertyChanged("RegistType", this._RegistType, value);
                this._RegistType = value;
            }
        }

        /// <summary>
        ///  登陆名类型,
        /// </summary>

        [DbProperty(MapingColumnName = "LoginNameType", DbTypeString = "int", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int LoginNameType
        {
            get
            {
                return this._LoginNameType;
            }
            set
            {
                this.OnPropertyChanged("LoginNameType", this._LoginNameType, value);
                this._LoginNameType = value;
            }
        }

        /// <summary>
        ///  保留用户名,
        /// </summary>

        [DbProperty(MapingColumnName = "SaveName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SaveName
        {
            get
            {
                return this._SaveName;
            }
            set
            {
                this.OnPropertyChanged("SaveName", this._SaveName, value);
                this._SaveName = value;
            }
        }

        /// <summary>
        ///  注册时间限制(分钟),
        /// </summary>

        [DbProperty(MapingColumnName = "RegistraTimeLimit", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int RegistraTimeLimit
        {
            get
            {
                return this._RegistraTimeLimit;
            }
            set
            {
                this.OnPropertyChanged("RegistraTimeLimit", this._RegistraTimeLimit, value);
                this._RegistraTimeLimit = value;
            }
        }

        /// <summary>
        ///  影子登录名,
        /// </summary>

        [DbProperty(MapingColumnName = "ShadowLoginName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShadowLoginName
        {
            get
            {
                return this._ShadowLoginName;
            }
            set
            {
                this.OnPropertyChanged("ShadowLoginName", this._ShadowLoginName, value);
                this._ShadowLoginName = value;
            }
        }

        /// <summary>
        ///  登陆失败次数,
        /// </summary>

        [DbProperty(MapingColumnName = "LoginErrorCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int LoginErrorCount
        {
            get
            {
                return this._LoginErrorCount;
            }
            set
            {
                this.OnPropertyChanged("LoginErrorCount", this._LoginErrorCount, value);
                this._LoginErrorCount = value;
            }
        }

        /// <summary>
        ///  图片类型,
        /// </summary>

        [DbProperty(MapingColumnName = "ImgType", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ImgType
        {
            get
            {
                return this._ImgType;
            }
            set
            {
                this.OnPropertyChanged("ImgType", this._ImgType, value);
                this._ImgType = value;
            }
        }

        /// <summary>
        ///  图片大小（MB）,
        /// </summary>

        [DbProperty(MapingColumnName = "ImgLenth", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ImgLenth
        {
            get
            {
                return this._ImgLenth;
            }
            set
            {
                this.OnPropertyChanged("ImgLenth", this._ImgLenth, value);
                this._ImgLenth = value;
            }
        }

        /// <summary>
        ///  水印类型,
        /// </summary>

        [DbProperty(MapingColumnName = "WaterType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public WaterType WaterType
        {
            get
            {
                return this._WaterType;
            }
            set
            {
                this.OnPropertyChanged("WaterType", this._WaterType, value);
                this._WaterType = value;
            }
        }

        /// <summary>
        ///  水印质量,
        /// </summary>

        [DbProperty(MapingColumnName = "WaterQuality", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int WaterQuality
        {
            get
            {
                return this._WaterQuality;
            }
            set
            {
                this.OnPropertyChanged("WaterQuality", this._WaterQuality, value);
                this._WaterQuality = value;
            }
        }

        /// <summary>
        ///  水印位置,
        /// </summary>

        [DbProperty(MapingColumnName = "WaterLocation", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public WaterLocation WaterLocation
        {
            get
            {
                return this._WaterLocation;
            }
            set
            {
                this.OnPropertyChanged("WaterLocation", this._WaterLocation, value);
                this._WaterLocation = value;
            }
        }

        /// <summary>
        ///  水印文字,
        /// </summary>

        [DbProperty(MapingColumnName = "WaterText", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string WaterText
        {
            get
            {
                return this._WaterText;
            }
            set
            {
                this.OnPropertyChanged("WaterText", this._WaterText, value);
                this._WaterText = value;
            }
        }

        /// <summary>
        ///  文字字体,
        /// </summary>

        [DbProperty(MapingColumnName = "WaterFamily", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string WaterFamily
        {
            get
            {
                return this._WaterFamily;
            }
            set
            {
                this.OnPropertyChanged("WaterFamily", this._WaterFamily, value);
                this._WaterFamily = value;
            }
        }

        /// <summary>
        ///  文字大小,
        /// </summary>

        [DbProperty(MapingColumnName = "WaterTextSize", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int WaterTextSize
        {
            get
            {
                return this._WaterTextSize;
            }
            set
            {
                this.OnPropertyChanged("WaterTextSize", this._WaterTextSize, value);
                this._WaterTextSize = value;
            }
        }

        /// <summary>
        ///  水印图片,
        /// </summary>

        [DbProperty(MapingColumnName = "WaterImg", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string WaterImg
        {
            get
            {
                return this._WaterImg;
            }
            set
            {
                this.OnPropertyChanged("WaterImg", this._WaterImg, value);
                this._WaterImg = value;
            }
        }

        /// <summary>
        ///  图片透明度,
        /// </summary>

        [DbProperty(MapingColumnName = "ImgTransparency", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ImgTransparency
        {
            get
            {
                return this._ImgTransparency;
            }
            set
            {
                this.OnPropertyChanged("ImgTransparency", this._ImgTransparency, value);
                this._ImgTransparency = value;
            }
        }

        /// <summary>
        ///  品牌缩略图,
        /// </summary>

        [DbProperty(MapingColumnName = "BrandThumbnail", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BrandThumbnail
        {
            get
            {
                return this._BrandThumbnail;
            }
            set
            {
                this.OnPropertyChanged("BrandThumbnail", this._BrandThumbnail, value);
                this._BrandThumbnail = value;
            }
        }

        /// <summary>
        ///  商品展示缩略图,
        /// </summary>

        [DbProperty(MapingColumnName = "DisplayThumbnail", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string DisplayThumbnail
        {
            get
            {
                return this._DisplayThumbnail;
            }
            set
            {
                this.OnPropertyChanged("DisplayThumbnail", this._DisplayThumbnail, value);
                this._DisplayThumbnail = value;
            }
        }

        /// <summary>
        ///  用户头像缩略图,
        /// </summary>

        [DbProperty(MapingColumnName = "UserPhotoThumbnail", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserPhotoThumbnail
        {
            get
            {
                return this._UserPhotoThumbnail;
            }
            set
            {
                this.OnPropertyChanged("UserPhotoThumbnail", this._UserPhotoThumbnail, value);
                this._UserPhotoThumbnail = value;
            }
        }

        /// <summary>
        ///  用户等级头像缩略图,
        /// </summary>

        [DbProperty(MapingColumnName = "UserOrderThumbnail", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserOrderThumbnail
        {
            get
            {
                return this._UserOrderThumbnail;
            }
            set
            {
                this.OnPropertyChanged("UserOrderThumbnail", this._UserOrderThumbnail, value);
                this._UserOrderThumbnail = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                RegistType = new PropertyItem("RegistType", tableName);

                LoginNameType = new PropertyItem("LoginNameType", tableName);

                SaveName = new PropertyItem("SaveName", tableName);

                RegistraTimeLimit = new PropertyItem("RegistraTimeLimit", tableName);

                ShadowLoginName = new PropertyItem("ShadowLoginName", tableName);

                LoginErrorCount = new PropertyItem("LoginErrorCount", tableName);

                ImgType = new PropertyItem("ImgType", tableName);

                ImgLenth = new PropertyItem("ImgLenth", tableName);

                WaterType = new PropertyItem("WaterType", tableName);

                WaterQuality = new PropertyItem("WaterQuality", tableName);

                WaterLocation = new PropertyItem("WaterLocation", tableName);

                WaterText = new PropertyItem("WaterText", tableName);

                WaterFamily = new PropertyItem("WaterFamily", tableName);

                WaterTextSize = new PropertyItem("WaterTextSize", tableName);

                WaterImg = new PropertyItem("WaterImg", tableName);

                ImgTransparency = new PropertyItem("ImgTransparency", tableName);

                BrandThumbnail = new PropertyItem("BrandThumbnail", tableName);

                DisplayThumbnail = new PropertyItem("DisplayThumbnail", tableName);

                UserPhotoThumbnail = new PropertyItem("UserPhotoThumbnail", tableName);

                UserOrderThumbnail = new PropertyItem("UserOrderThumbnail", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 注册名类型,
            /// </summary> 
            public PropertyItem RegistType = null;
            /// <summary>
            /// 登陆名类型,
            /// </summary> 
            public PropertyItem LoginNameType = null;
            /// <summary>
            /// 保留用户名,
            /// </summary> 
            public PropertyItem SaveName = null;
            /// <summary>
            /// 注册时间限制(分钟),
            /// </summary> 
            public PropertyItem RegistraTimeLimit = null;
            /// <summary>
            /// 影子登录名,
            /// </summary> 
            public PropertyItem ShadowLoginName = null;
            /// <summary>
            /// 登陆失败次数,
            /// </summary> 
            public PropertyItem LoginErrorCount = null;
            /// <summary>
            /// 图片类型,
            /// </summary> 
            public PropertyItem ImgType = null;
            /// <summary>
            /// 图片大小（MB）,
            /// </summary> 
            public PropertyItem ImgLenth = null;
            /// <summary>
            /// 水印类型,
            /// </summary> 
            public PropertyItem WaterType = null;
            /// <summary>
            /// 水印质量,
            /// </summary> 
            public PropertyItem WaterQuality = null;
            /// <summary>
            /// 水印位置,
            /// </summary> 
            public PropertyItem WaterLocation = null;
            /// <summary>
            /// 水印文字,
            /// </summary> 
            public PropertyItem WaterText = null;
            /// <summary>
            /// 文字字体,
            /// </summary> 
            public PropertyItem WaterFamily = null;
            /// <summary>
            /// 文字大小,
            /// </summary> 
            public PropertyItem WaterTextSize = null;
            /// <summary>
            /// 水印图片,
            /// </summary> 
            public PropertyItem WaterImg = null;
            /// <summary>
            /// 图片透明度,
            /// </summary> 
            public PropertyItem ImgTransparency = null;
            /// <summary>
            /// 品牌缩略图,
            /// </summary> 
            public PropertyItem BrandThumbnail = null;
            /// <summary>
            /// 商品展示缩略图,
            /// </summary> 
            public PropertyItem DisplayThumbnail = null;
            /// <summary>
            /// 用户头像缩略图,
            /// </summary> 
            public PropertyItem UserPhotoThumbnail = null;
            /// <summary>
            /// 用户等级头像缩略图,
            /// </summary> 
            public PropertyItem UserOrderThumbnail = null;
        }
        #endregion
    }
}
