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
    /// 导出明细
    /// </summary>  
    [JsonObject]
    public partial class SysExportMx : BaseEntity
    {
        public static Column _ = new Column("SysExportMx");

        public SysExportMx()
        {
            this.TableName = "SysExportMx";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private string _SourcTable;

        private ShowType _ShowType;

        private AggregateType _AggregateType;

        private AlignType _AlignType;

        private int _OrderNo;

        private string _GroupCode;

        private string _GroupName;

        private string _MID;

        private string _FormatType;

        private bool _IsMergeRow;

        private bool _NotExport;

        private bool _IsKey;

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

        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  所属表,
        /// </summary>

        [DbProperty(MapingColumnName = "SourcTable", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SourcTable
        {
            get
            {
                return this._SourcTable;
            }
            set
            {
                this.OnPropertyChanged("SourcTable", this._SourcTable, value);
                this._SourcTable = value;
            }
        }

        /// <summary>
        ///  类型,
        /// </summary>

        [DbProperty(MapingColumnName = "ShowType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public ShowType ShowType
        {
            get
            {
                return this._ShowType;
            }
            set
            {
                this.OnPropertyChanged("ShowType", this._ShowType, value);
                this._ShowType = value;
            }
        }

        /// <summary>
        ///  聚合类型,
        /// </summary>

        [DbProperty(MapingColumnName = "AggregateType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AggregateType AggregateType
        {
            get
            {
                return this._AggregateType;
            }
            set
            {
                this.OnPropertyChanged("AggregateType", this._AggregateType, value);
                this._AggregateType = value;
            }
        }

        /// <summary>
        ///  对齐方式,
        /// </summary>

        [DbProperty(MapingColumnName = "AlignType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AlignType AlignType
        {
            get
            {
                return this._AlignType;
            }
            set
            {
                this.OnPropertyChanged("AlignType", this._AlignType, value);
                this._AlignType = value;
            }
        }

        /// <summary>
        ///  顺序,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderNo", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int OrderNo
        {
            get
            {
                return this._OrderNo;
            }
            set
            {
                this.OnPropertyChanged("OrderNo", this._OrderNo, value);
                this._OrderNo = value;
            }
        }

        /// <summary>
        ///  对应表头合并组,对应合并列的第一个Code
        /// </summary>

        [DbProperty(MapingColumnName = "GroupCode", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string GroupCode
        {
            get
            {
                return this._GroupCode;
            }
            set
            {
                this.OnPropertyChanged("GroupCode", this._GroupCode, value);
                this._GroupCode = value;
            }
        }

        /// <summary>
        ///  对应表头合并组标题,同一个组中有一个就行
        /// </summary>

        [DbProperty(MapingColumnName = "GroupName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string GroupName
        {
            get
            {
                return this._GroupName;
            }
            set
            {
                this.OnPropertyChanged("GroupName", this._GroupName, value);
                this._GroupName = value;
            }
        }

        /// <summary>
        ///  主表ID,
        /// </summary>

        [DbProperty(MapingColumnName = "MID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string MID
        {
            get
            {
                return this._MID;
            }
            set
            {
                this.OnPropertyChanged("MID", this._MID, value);
                this._MID = value;
            }
        }

        /// <summary>
        ///  格式类型,日期型 用 yyyymmdd等标准格式，数值用n2代表精度
        /// </summary>

        [DbProperty(MapingColumnName = "FormatType", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string FormatType
        {
            get
            {
                return this._FormatType;
            }
            set
            {
                this.OnPropertyChanged("FormatType", this._FormatType, value);
                this._FormatType = value;
            }
        }

        /// <summary>
        ///  是否合并行,同列不同行 的值可合并
        /// </summary>

        [DbProperty(MapingColumnName = "IsMergeRow", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsMergeRow
        {
            get
            {
                return this._IsMergeRow;
            }
            set
            {
                this.OnPropertyChanged("IsMergeRow", this._IsMergeRow, value);
                this._IsMergeRow = value;
            }
        }

        /// <summary>
        ///  不导出,
        /// </summary>

        [DbProperty(MapingColumnName = "NotExport", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool NotExport
        {
            get
            {
                return this._NotExport;
            }
            set
            {
                this.OnPropertyChanged("NotExport", this._NotExport, value);
                this._NotExport = value;
            }
        }

        /// <summary>
        ///  是主键,
        /// </summary>

        [DbProperty(MapingColumnName = "IsKey", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsKey
        {
            get
            {
                return this._IsKey;
            }
            set
            {
                this.OnPropertyChanged("IsKey", this._IsKey, value);
                this._IsKey = value;
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

                SourcTable = new PropertyItem("SourcTable", tableName);

                ShowType = new PropertyItem("ShowType", tableName);

                AggregateType = new PropertyItem("AggregateType", tableName);

                AlignType = new PropertyItem("AlignType", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);

                GroupCode = new PropertyItem("GroupCode", tableName);

                GroupName = new PropertyItem("GroupName", tableName);

                MID = new PropertyItem("MID", tableName);

                FormatType = new PropertyItem("FormatType", tableName);

                IsMergeRow = new PropertyItem("IsMergeRow", tableName);

                NotExport = new PropertyItem("NotExport", tableName);

                IsKey = new PropertyItem("IsKey", tableName);


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
            /// 所属表,
            /// </summary> 
            public PropertyItem SourcTable = null;
            /// <summary>
            /// 类型,
            /// </summary> 
            public PropertyItem ShowType = null;
            /// <summary>
            /// 聚合类型,
            /// </summary> 
            public PropertyItem AggregateType = null;
            /// <summary>
            /// 对齐方式,
            /// </summary> 
            public PropertyItem AlignType = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
            /// <summary>
            /// 对应表头合并组,对应合并列的第一个Code
            /// </summary> 
            public PropertyItem GroupCode = null;
            /// <summary>
            /// 对应表头合并组标题,同一个组中有一个就行
            /// </summary> 
            public PropertyItem GroupName = null;
            /// <summary>
            /// 主表ID,
            /// </summary> 
            public PropertyItem MID = null;
            /// <summary>
            /// 格式类型,日期型 用 yyyymmdd等标准格式，数值用n2代表精度
            /// </summary> 
            public PropertyItem FormatType = null;
            /// <summary>
            /// 是否合并行,同列不同行 的值可合并
            /// </summary> 
            public PropertyItem IsMergeRow = null;
            /// <summary>
            /// 不导出,
            /// </summary> 
            public PropertyItem NotExport = null;
            /// <summary>
            /// 是主键,
            /// </summary> 
            public PropertyItem IsKey = null;
        }
        #endregion
    }
}
