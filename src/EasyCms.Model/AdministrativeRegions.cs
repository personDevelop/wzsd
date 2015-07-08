using Newtonsoft.Json;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model
{
    /// <summary>
    /// 行政区域
    /// </summary>  
    [JsonObject]
    public partial class AdministrativeRegions : BaseEntity
    {
        public static Column _ = new Column("AdministrativeRegions");

        public AdministrativeRegions()
        {
            this.TableName = "AdministrativeRegions";
            OnCreate();
        }


        #region 私有变量

        private int _ID;

        private int _ParentID;

        private string _Code;

        private string _Name;

        private string _ShotName;

        private string _Path;

        private string _FullPath;

        private int _Jb;

        private string _Qh;

        private string _ZipCode;

        private string _Note;

        private bool _IsStop;

        #endregion

        #region 属性

        /// <summary>
        ///  主键,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = true, StepSize = 0, ColumnDefaultValue = "")]

        public int ID
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
        ///  上级路径,0位根路径
        /// </summary>

        [DbProperty(MapingColumnName = "ParentID", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {
                this.OnPropertyChanged("ParentID", this._ParentID, value);
                this._ParentID = value;
            }
        }

        /// <summary>
        ///  编号,
        /// </summary>

        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  简称,
        /// </summary>

        [DbProperty(MapingColumnName = "ShotName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShotName
        {
            get
            {
                return this._ShotName;
            }
            set
            {
                this.OnPropertyChanged("ShotName", this._ShotName, value);
                this._ShotName = value;
            }
        }

        /// <summary>
        ///  路径,
        /// </summary>

        [DbProperty(MapingColumnName = "Path", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Path
        {
            get
            {
                return this._Path;
            }
            set
            {
                this.OnPropertyChanged("Path", this._Path, value);
                this._Path = value;
            }
        }

        /// <summary>
        ///  全路径ID,
        /// </summary>

        [DbProperty(MapingColumnName = "FullPath", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string FullPath
        {
            get
            {
                return this._FullPath;
            }
            set
            {
                this.OnPropertyChanged("FullPath", this._FullPath, value);
                this._FullPath = value;
            }
        }

        /// <summary>
        ///  级别,
        /// </summary>

        [DbProperty(MapingColumnName = "Jb", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Jb
        {
            get
            {
                return this._Jb;
            }
            set
            {
                this.OnPropertyChanged("Jb", this._Jb, value);
                this._Jb = value;
            }
        }

        /// <summary>
        ///  区号,
        /// </summary>

        [DbProperty(MapingColumnName = "Qh", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Qh
        {
            get
            {
                return this._Qh;
            }
            set
            {
                this.OnPropertyChanged("Qh", this._Qh, value);
                this._Qh = value;
            }
        }

        /// <summary>
        ///  邮编,
        /// </summary>

        [DbProperty(MapingColumnName = "ZipCode", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ZipCode
        {
            get
            {
                return this._ZipCode;
            }
            set
            {
                this.OnPropertyChanged("ZipCode", this._ZipCode, value);
                this._ZipCode = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  是否停用,
        /// </summary>

        [DbProperty(MapingColumnName = "IsStop", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsStop
        {
            get
            {
                return this._IsStop;
            }
            set
            {
                this.OnPropertyChanged("IsStop", this._IsStop, value);
                this._IsStop = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                ParentID = new PropertyItem("ParentID", tableName);

                Code = new PropertyItem("Code", tableName);

                Name = new PropertyItem("Name", tableName);

                ShotName = new PropertyItem("ShotName", tableName);

                Path = new PropertyItem("Path", tableName);

                FullPath = new PropertyItem("FullPath", tableName);

                Jb = new PropertyItem("Jb", tableName);

                Qh = new PropertyItem("Qh", tableName);

                ZipCode = new PropertyItem("ZipCode", tableName);

                Note = new PropertyItem("Note", tableName);

                IsStop = new PropertyItem("IsStop", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 上级路径,0位根路径
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 简称,
            /// </summary> 
            public PropertyItem ShotName = null;
            /// <summary>
            /// 路径,
            /// </summary> 
            public PropertyItem Path = null;
            /// <summary>
            /// 全路径ID,
            /// </summary> 
            public PropertyItem FullPath = null;
            /// <summary>
            /// 级别,
            /// </summary> 
            public PropertyItem Jb = null;
            /// <summary>
            /// 区号,
            /// </summary> 
            public PropertyItem Qh = null;
            /// <summary>
            /// 邮编,
            /// </summary> 
            public PropertyItem ZipCode = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 是否停用,
            /// </summary> 
            public PropertyItem IsStop = null;
        }
        #endregion
    }
    public partial class AdministrativeRegions
    {
        
        [NotDbCol]
        public string ParentName { get; set; }
    }
}
