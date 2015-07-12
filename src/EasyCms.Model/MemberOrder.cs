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
    /// 会员等级
    /// </summary>  
    [JsonObject]
    public partial class MemberOrder : BaseEntity
    {
        public static Column _ = new Column("MemberOrder");

        public MemberOrder()
        {
            this.TableName = "MemberOrder";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private string _Img;

        private decimal _MinVal;

        private decimal _MaxVal;

        private bool _IsEnable;

        private string _Note;

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

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                Code = new PropertyItem("Code", tableName);

                Name = new PropertyItem("Name", tableName);

                Img = new PropertyItem("Img", tableName);

                MinVal = new PropertyItem("MinVal", tableName);

                MaxVal = new PropertyItem("MaxVal", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                Note = new PropertyItem("Note", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 等级,
            /// </summary> 
            public PropertyItem Code = null;
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
        }
        #endregion
    }
}
