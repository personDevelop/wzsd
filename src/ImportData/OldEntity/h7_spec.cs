using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportData.OldEntity
{
    /// <summary>
    /// h7_spec
    /// </summary>  

    public partial class h7_spec : BaseEntity
    {
        public static Column _ = new Column("h7_spec");

        public h7_spec()
        {
            this.TableName = "h7_spec";
            OnCreate();
        }


        #region 私有变量

        private int _id;

        private string _name;

        private string _value;

        private int _type;

        private string _note;

        private int? _is_del;

        #endregion

        #region 属性

        /// <summary>
        ///  id,
        /// </summary>

        [DbProperty(MapingColumnName = "id", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this.OnPropertyChanged("id", this._id, value);
                this._id = value;
            }
        }

        /// <summary>
        ///  name,
        /// </summary>

        [DbProperty(MapingColumnName = "name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this.OnPropertyChanged("name", this._name, value);
                this._name = value;
            }
        }

        /// <summary>
        ///  value,
        /// </summary>

        [DbProperty(MapingColumnName = "value", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public string value
        {
            get
            {
                return this._value;
            }
            set
            {
                this.OnPropertyChanged("value", this._value, value);
                this._value = value;
            }
        }

        /// <summary>
        ///  type,
        /// </summary>

        [DbProperty(MapingColumnName = "type", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((1))")]

        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this.OnPropertyChanged("type", this._type, value);
                this._type = value;
            }
        }

        /// <summary>
        ///  note,
        /// </summary>

        [DbProperty(MapingColumnName = "note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public string note
        {
            get
            {
                return this._note;
            }
            set
            {
                this.OnPropertyChanged("note", this._note, value);
                this._note = value;
            }
        }

        /// <summary>
        ///  is_del,
        /// </summary>

        [DbProperty(MapingColumnName = "is_del", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]

        public int? is_del
        {
            get
            {
                return this._is_del;
            }
            set
            {
                this.OnPropertyChanged("is_del", this._is_del, value);
                this._is_del = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                id = new PropertyItem("id", tableName);

                name = new PropertyItem("name", tableName);

                value = new PropertyItem("value", tableName);

                type = new PropertyItem("type", tableName);

                note = new PropertyItem("note", tableName);

                is_del = new PropertyItem("is_del", tableName);


            }
            /// <summary>
            /// id,
            /// </summary> 
            public PropertyItem id = null;
            /// <summary>
            /// name,
            /// </summary> 
            public PropertyItem name = null;
            /// <summary>
            /// value,
            /// </summary> 
            public PropertyItem value = null;
            /// <summary>
            /// type,
            /// </summary> 
            public PropertyItem type = null;
            /// <summary>
            /// note,
            /// </summary> 
            public PropertyItem note = null;
            /// <summary>
            /// is_del,
            /// </summary> 
            public PropertyItem is_del = null;
        }
        #endregion
    }

}
