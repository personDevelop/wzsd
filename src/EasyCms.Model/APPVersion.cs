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
    /// APP维护
    /// </summary>  
    [JsonObject]
    public partial class APPVersion : BaseEntity
    {
        public static Column _ = new Column("APPVersion");

        public APPVersion()
        {
            this.TableName = "APPVersion";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private int _Version;

        private string _SoftPath;

        private string _UpdatePath;

        private AppPlatform _PlatForm;

        private string _PlatformVersion;

        private string _VersionName;

        private string _VersionNote;

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
        ///  版本号,
        /// </summary>

        [DbProperty(MapingColumnName = "Version", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Version
        {
            get
            {
                return this._Version;
            }
            set
            {
                this.OnPropertyChanged("Version", this._Version, value);


                this._Version = value;
            }
        }

        /// <summary>
        ///  程序路径,
        /// </summary>

        [DbProperty(MapingColumnName = "SoftPath", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SoftPath
        {
            get
            {
                return this._SoftPath;
            }
            set
            {
                this.OnPropertyChanged("SoftPath", this._SoftPath, value);


                this._SoftPath = value;
            }
        }

        /// <summary>
        ///  程序更新路径,
        /// </summary>

        [DbProperty(MapingColumnName = "UpdatePath", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UpdatePath
        {
            get
            {
                return this._UpdatePath;
            }
            set
            {
                this.OnPropertyChanged("UpdatePath", this._UpdatePath, value);


                this._UpdatePath = value;
            }
        }

        /// <summary>
        ///  平台,
        /// </summary>

        [DbProperty(MapingColumnName = "PlatForm", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AppPlatform PlatForm
        {
            get
            {
                return this._PlatForm;
            }
            set
            {
                this.OnPropertyChanged("PlatForm", this._PlatForm, value);


                this._PlatForm = value;
            }
        }

        /// <summary>
        ///  对应平台的最低版本,
        /// </summary>

        [DbProperty(MapingColumnName = "PlatformVersion", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PlatformVersion
        {
            get
            {
                return this._PlatformVersion;
            }
            set
            {
                this.OnPropertyChanged("PlatformVersion", this._PlatformVersion, value);


                this._PlatformVersion = value;
            }
        }

        /// <summary>
        ///  版本名称,
        /// </summary>

        [DbProperty(MapingColumnName = "VersionName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string VersionName
        {
            get
            {
                return this._VersionName;
            }
            set
            {
                this.OnPropertyChanged("VersionName", this._VersionName, value);


                this._VersionName = value;
            }
        }

        /// <summary>
        ///  更新说明,
        /// </summary>

        [DbProperty(MapingColumnName = "VersionNote", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string VersionNote
        {
            get
            {
                return this._VersionNote;
            }
            set
            {
                this.OnPropertyChanged("VersionNote", this._VersionNote, value);


                this._VersionNote = value;
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

                Version = new PropertyItem("Version", tableName);

                SoftPath = new PropertyItem("SoftPath", tableName);

                UpdatePath = new PropertyItem("UpdatePath", tableName);

                PlatForm = new PropertyItem("PlatForm", tableName);

                PlatformVersion = new PropertyItem("PlatformVersion", tableName);

                VersionName = new PropertyItem("VersionName", tableName);

                VersionNote = new PropertyItem("VersionNote", tableName);


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
            /// 版本号,
            /// </summary> 
            public PropertyItem Version = null;
            /// <summary>
            /// 程序路径,
            /// </summary> 
            public PropertyItem SoftPath = null;
            /// <summary>
            /// 程序更新路径,
            /// </summary> 
            public PropertyItem UpdatePath = null;
            /// <summary>
            /// 平台,
            /// </summary> 
            public PropertyItem PlatForm = null;
            /// <summary>
            /// 对应平台的最低版本,
            /// </summary> 
            public PropertyItem PlatformVersion = null;
            /// <summary>
            /// 版本名称,
            /// </summary> 
            public PropertyItem VersionName = null;
            /// <summary>
            /// 更新说明,
            /// </summary> 
            public PropertyItem VersionNote = null;
        }
        #endregion
    }
}
