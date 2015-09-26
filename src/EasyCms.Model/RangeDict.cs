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
    /// 会员等级字典
    /// </summary>  
    [JsonObject]
    public partial class RangeDict : BaseEntity
    {
        public static Column _ = new Column("RangeDict");

        public RangeDict()
        {
            this.TableName = "RangeDict";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _RankLevel;

        private string _Name;

        private string _Img;

        private decimal _MinVal;

        private decimal _MaxVal;

        private bool _IsEnable;

        private string _Note;

        private int _LevelYear;

        private int _ReduceValue;

        private string _HasService;

        #endregion

        #region 属性

        /// <summary>
        ///  主键,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  等级,
        /// </summary>

        [DbProperty(MapingColumnName = "RankLevel", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RankLevel
        {
            get
            {
                return this._RankLevel;
            }
            set
            {
                this.OnPropertyChanged("RankLevel", this._RankLevel, value);
                this._RankLevel = value;
            }
        }

        /// <summary>
        ///  等级名称,
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
        ///  等级图标,
        /// </summary>

        [DbProperty(MapingColumnName = "Img", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Img
        {
            get
            {
                return this._Img;
            }
            set
            {
                this.OnPropertyChanged("Img", this._Img, value);
                this._Img = value;
            }
        }

        /// <summary>
        ///  等级值下限(包括),
        /// </summary>

        [DbProperty(MapingColumnName = "MinVal", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal MinVal
        {
            get
            {
                return this._MinVal;
            }
            set
            {
                this.OnPropertyChanged("MinVal", this._MinVal, value);
                this._MinVal = value;
            }
        }

        /// <summary>
        ///  等级值上限(不包括),
        /// </summary>

        [DbProperty(MapingColumnName = "MaxVal", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal MaxVal
        {
            get
            {
                return this._MaxVal;
            }
            set
            {
                this.OnPropertyChanged("MaxVal", this._MaxVal, value);
                this._MaxVal = value;
            }
        }

        /// <summary>
        ///  可用,
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
        ///  等级描述,
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
        ///  期限（年）,
        /// </summary>

        [DbProperty(MapingColumnName = "LevelYear", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int LevelYear
        {
            get
            {
                return this._LevelYear;
            }
            set
            {
                this.OnPropertyChanged("LevelYear", this._LevelYear, value);
                this._LevelYear = value;
            }
        }

        /// <summary>
        ///  超期期限后减少成长值,
        /// </summary>

        [DbProperty(MapingColumnName = "ReduceValue", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ReduceValue
        {
            get
            {
                return this._ReduceValue;
            }
            set
            {
                this.OnPropertyChanged("ReduceValue", this._ReduceValue, value);
                this._ReduceValue = value;
            }
        }

        /// <summary>
        ///  享有的服务,
        /// </summary>

        [DbProperty(MapingColumnName = "HasService", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string HasService
        {
            get
            {
                return this._HasService;
            }
            set
            {
                this.OnPropertyChanged("HasService", this._HasService, value);
                this._HasService = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                RankLevel = new PropertyItem("RankLevel", tableName);

                Name = new PropertyItem("Name", tableName);

                Img = new PropertyItem("Img", tableName);

                MinVal = new PropertyItem("MinVal", tableName);

                MaxVal = new PropertyItem("MaxVal", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                Note = new PropertyItem("Note", tableName);

                LevelYear = new PropertyItem("LevelYear", tableName);

                ReduceValue = new PropertyItem("ReduceValue", tableName);

                HasService = new PropertyItem("HasService", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 等级,
            /// </summary> 
            public PropertyItem RankLevel = null;
            /// <summary>
            /// 等级名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 等级图标,
            /// </summary> 
            public PropertyItem Img = null;
            /// <summary>
            /// 等级值下限(包括),
            /// </summary> 
            public PropertyItem MinVal = null;
            /// <summary>
            /// 等级值上限(不包括),
            /// </summary> 
            public PropertyItem MaxVal = null;
            /// <summary>
            /// 可用,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 等级描述,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 期限（年）,
            /// </summary> 
            public PropertyItem LevelYear = null;
            /// <summary>
            /// 超期期限后减少成长值,
            /// </summary> 
            public PropertyItem ReduceValue = null;
            /// <summary>
            /// 享有的服务,
            /// </summary> 
            public PropertyItem HasService = null;
        }
        #endregion
    }

}
