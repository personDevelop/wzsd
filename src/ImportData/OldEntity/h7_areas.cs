using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportData.OldEntity
{
    /// <summary>
    /// h7_areas
    /// </summary>  
    
    public partial class h7_areas : BaseEntity
    {
        public static Column _ = new Column("h7_areas");

        public h7_areas()
        {
            this.TableName = "h7_areas";
            OnCreate();
        }


        #region 私有变量

        private int _area_id;

        private int _parent_id;

        private string _area_name;

        private int _sort;

        #endregion

        #region 属性

        /// <summary>
        ///  area_id,
        /// </summary>

        [DbProperty(MapingColumnName = "area_id", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int area_id
        {
            get
            {
                return this._area_id;
            }
            set
            {
                this.OnPropertyChanged("area_id", this._area_id, value);


                this._area_id = value;
            }
        }

        /// <summary>
        ///  parent_id,
        /// </summary>

        [DbProperty(MapingColumnName = "parent_id", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int parent_id
        {
            get
            {
                return this._parent_id;
            }
            set
            {
                this.OnPropertyChanged("parent_id", this._parent_id, value);


                this._parent_id = value;
            }
        }

        /// <summary>
        ///  area_name,
        /// </summary>

        [DbProperty(MapingColumnName = "area_name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string area_name
        {
            get
            {
                return this._area_name;
            }
            set
            {
                this.OnPropertyChanged("area_name", this._area_name, value);


                this._area_name = value;
            }
        }

        /// <summary>
        ///  sort,
        /// </summary>

        [DbProperty(MapingColumnName = "sort", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int sort
        {
            get
            {
                return this._sort;
            }
            set
            {
                this.OnPropertyChanged("sort", this._sort, value);


                this._sort = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                area_id = new PropertyItem("area_id", tableName);

                parent_id = new PropertyItem("parent_id", tableName);

                area_name = new PropertyItem("area_name", tableName);

                sort = new PropertyItem("sort", tableName);


            }
            /// <summary>
            /// area_id,
            /// </summary> 
            public PropertyItem area_id = null;
            /// <summary>
            /// parent_id,
            /// </summary> 
            public PropertyItem parent_id = null;
            /// <summary>
            /// area_name,
            /// </summary> 
            public PropertyItem area_name = null;
            /// <summary>
            /// sort,
            /// </summary> 
            public PropertyItem sort = null;
        }
        #endregion
    }

}
