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
    /// 导出设置
    /// </summary>  
    [JsonObject]
    public partial class SysExportSet : BaseEntity
    {
        public static Column _ = new Column("SysExportSet");

        public SysExportSet()
        {
            this.TableName = "SysExportSet";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private string _ExportTable;

        private bool _ShowTableCaption;

        private string _Note;

        private string _SqlStr;

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
        ///  涉及到的表,
        /// </summary>

        [DbProperty(MapingColumnName = "ExportTable", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ExportTable
        {
            get
            {
                return this._ExportTable;
            }
            set
            {
                this.OnPropertyChanged("ExportTable", this._ExportTable, value);
                this._ExportTable = value;
            }
        }

        /// <summary>
        ///  是否显示表头,
        /// </summary>

        [DbProperty(MapingColumnName = "ShowTableCaption", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool ShowTableCaption
        {
            get
            {
                return this._ShowTableCaption;
            }
            set
            {
                this.OnPropertyChanged("ShowTableCaption", this._ShowTableCaption, value);
                this._ShowTableCaption = value;
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
        ///  取数Sql,如果有取数sql,则后台也通过这个进行取数
        /// </summary>

        [DbProperty(MapingColumnName = "SqlStr", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 4000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SqlStr
        {
            get
            {
                return this._SqlStr;
            }
            set
            {
                this.OnPropertyChanged("SqlStr", this._SqlStr, value);
                this._SqlStr = value;
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

                ExportTable = new PropertyItem("ExportTable", tableName);

                ShowTableCaption = new PropertyItem("ShowTableCaption", tableName);

                Note = new PropertyItem("Note", tableName);

                SqlStr = new PropertyItem("SqlStr", tableName);


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
            /// 涉及到的表,
            /// </summary> 
            public PropertyItem ExportTable = null;
            /// <summary>
            /// 是否显示表头,
            /// </summary> 
            public PropertyItem ShowTableCaption = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 取数Sql,如果有取数sql,则后台也通过这个进行取数
            /// </summary> 
            public PropertyItem SqlStr = null;
        }
        #endregion
    }
}
