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
    /// 系统广告牌管理
    /// </summary>  
    [JsonObject]
    public partial class SystemBrandInfo : BaseEntity
    {
        public static Column _ = new Column("SystemBrandInfo");

        public SystemBrandInfo()
        {
            this.TableName = "SystemBrandInfo";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private BrandType _BrandType;

        private AppHandleTag _AppHandleTag;

        private string _ActionValue;

        private DateTime _CreateTime;

        private bool _IsTop;

        private DateTime _TopTime;

        private string _VideoUrl;

        private bool _IsVideo;

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
        ///  编号,
        /// </summary>

        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  类型,
        /// </summary>

        [DbProperty(MapingColumnName = "BrandType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public BrandType BrandType
        {
            get
            {
                return this._BrandType;
            }
            set
            {
                this.OnPropertyChanged("BrandType", this._BrandType, value);
                this._BrandType = value;
            }
        }

        /// <summary>
        ///  动作类型,
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
        ///  附属的值,
        /// </summary>

        [DbProperty(MapingColumnName = "ActionValue", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ActionValue
        {
            get
            {
                return this._ActionValue;
            }
            set
            {
                this.OnPropertyChanged("ActionValue", this._ActionValue, value);
                this._ActionValue = value;
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
        ///  是否置顶,
        /// </summary>

        [DbProperty(MapingColumnName = "IsTop", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsTop
        {
            get
            {
                return this._IsTop;
            }
            set
            {
                this.OnPropertyChanged("IsTop", this._IsTop, value);
                this._IsTop = value;
            }
        }

        /// <summary>
        ///  置顶日期,
        /// </summary>

        [DbProperty(MapingColumnName = "TopTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime TopTime
        {
            get
            {
                return this._TopTime;
            }
            set
            {
                this.OnPropertyChanged("TopTime", this._TopTime, value);
                this._TopTime = value;
            }
        }

        /// <summary>
        ///  视频URL,
        /// </summary>

        [DbProperty(MapingColumnName = "VideoUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 300, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string VideoUrl
        {
            get
            {
                return this._VideoUrl;
            }
            set
            {
                this.OnPropertyChanged("VideoUrl", this._VideoUrl, value);
                this._VideoUrl = value;
            }
        }

        /// <summary>
        ///  是视频广告,
        /// </summary>

        [DbProperty(MapingColumnName = "IsVideo", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsVideo
        {
            get
            {
                return this._IsVideo;
            }
            set
            {
                this.OnPropertyChanged("IsVideo", this._IsVideo, value);
                this._IsVideo = value;
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

                BrandType = new PropertyItem("BrandType", tableName);

                AppHandleTag = new PropertyItem("AppHandleTag", tableName);

                ActionValue = new PropertyItem("ActionValue", tableName);

                CreateTime = new PropertyItem("CreateTime", tableName);

                IsTop = new PropertyItem("IsTop", tableName);

                TopTime = new PropertyItem("TopTime", tableName);

                VideoUrl = new PropertyItem("VideoUrl", tableName);

                IsVideo = new PropertyItem("IsVideo", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 类型,
            /// </summary> 
            public PropertyItem BrandType = null;
            /// <summary>
            /// 动作类型,
            /// </summary> 
            public PropertyItem AppHandleTag = null;
            /// <summary>
            /// 附属的值,
            /// </summary> 
            public PropertyItem ActionValue = null;
            /// <summary>
            /// 创建时间,
            /// </summary> 
            public PropertyItem CreateTime = null;
            /// <summary>
            /// 是否置顶,
            /// </summary> 
            public PropertyItem IsTop = null;
            /// <summary>
            /// 置顶日期,
            /// </summary> 
            public PropertyItem TopTime = null;
            /// <summary>
            /// 视频URL,
            /// </summary> 
            public PropertyItem VideoUrl = null;
            /// <summary>
            /// 是视频广告,
            /// </summary> 
            public PropertyItem IsVideo = null;
        }
        #endregion
    }
}
