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
    /// 帮助分类
    /// </summary>  
    [JsonObject]
    public partial class HelpType : BaseEntity
    {
        public static Column _ = new Column("HelpType");

        public HelpType()
        {
            this.TableName = "HelpType";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private bool _IsShowButtom;

        private bool _IsShowNavi;

        private string _Note;

        private string _ParentID;

        private string _ClassCode;

        private bool _IsDetails;

        private int _Series;

        private int _OrderNo;

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
        ///  是否在PC底部展示,
        /// </summary>

        [DbProperty(MapingColumnName = "IsShowButtom", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsShowButtom
        {
            get
            {
                return this._IsShowButtom;
            }
            set
            {
                this.OnPropertyChanged("IsShowButtom", this._IsShowButtom, value);
                this._IsShowButtom = value;
            }
        }

        /// <summary>
        ///  是否在PC导航展示,
        /// </summary>

        [DbProperty(MapingColumnName = "IsShowNavi", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsShowNavi
        {
            get
            {
                return this._IsShowNavi;
            }
            set
            {
                this.OnPropertyChanged("IsShowNavi", this._IsShowNavi, value);
                this._IsShowNavi = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  父分类,
        /// </summary>

        [DbProperty(MapingColumnName = "ParentID", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ParentID
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
        ///  分级码,
        /// </summary>

        [DbProperty(MapingColumnName = "ClassCode", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ClassCode
        {
            get
            {
                return this._ClassCode;
            }
            set
            {
                this.OnPropertyChanged("ClassCode", this._ClassCode, value);
                this._ClassCode = value;
            }
        }

        /// <summary>
        ///  明细,
        /// </summary>

        [DbProperty(MapingColumnName = "IsDetails", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsDetails
        {
            get
            {
                return this._IsDetails;
            }
            set
            {
                this.OnPropertyChanged("IsDetails", this._IsDetails, value);
                this._IsDetails = value;
            }
        }

        /// <summary>
        ///  级数,
        /// </summary>

        [DbProperty(MapingColumnName = "Series", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Series
        {
            get
            {
                return this._Series;
            }
            set
            {
                this.OnPropertyChanged("Series", this._Series, value);
                this._Series = value;
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

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                Code = new PropertyItem("Code", tableName);

                Name = new PropertyItem("Name", tableName);

                IsShowButtom = new PropertyItem("IsShowButtom", tableName);

                IsShowNavi = new PropertyItem("IsShowNavi", tableName);

                Note = new PropertyItem("Note", tableName);

                ParentID = new PropertyItem("ParentID", tableName);

                ClassCode = new PropertyItem("ClassCode", tableName);

                IsDetails = new PropertyItem("IsDetails", tableName);

                Series = new PropertyItem("Series", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);


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
            /// 是否在PC底部展示,
            /// </summary> 
            public PropertyItem IsShowButtom = null;
            /// <summary>
            /// 是否在PC导航展示,
            /// </summary> 
            public PropertyItem IsShowNavi = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 父分类,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 分级码,
            /// </summary> 
            public PropertyItem ClassCode = null;
            /// <summary>
            /// 明细,
            /// </summary> 
            public PropertyItem IsDetails = null;
            /// <summary>
            /// 级数,
            /// </summary> 
            public PropertyItem Series = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
        }
        #endregion
    }

    public partial class HelpType
    {
        [NotDbCol]
        public string ParentName { get; set; }

        [NotDbCol]
        public bool IsContent { get; set; }
    }
}

