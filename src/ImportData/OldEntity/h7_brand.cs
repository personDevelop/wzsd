using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImportData.OldEntity
{
    /// <summary>
    /// h7_brand
    /// </summary>  
    
    public partial class h7_brand : BaseEntity
    {
        public static Column _ = new Column("h7_brand");

        public h7_brand()
        {
            this.TableName = "h7_brand";
            OnCreate();
        }


        #region 私有变量

        private int _id;

        private string _name;

        private string _logo;

        private string _url;

        private string _description;

        private int _sort;

        private string _category_ids;

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

        [DbProperty(MapingColumnName = "name", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  logo,
        /// </summary>

        [DbProperty(MapingColumnName = "logo", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string logo
        {
            get
            {
                return this._logo;
            }
            set
            {
                this.OnPropertyChanged("logo", this._logo, value);
                this._logo = value;
            }
        }

        /// <summary>
        ///  url,
        /// </summary>

        [DbProperty(MapingColumnName = "url", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string url
        {
            get
            {
                return this._url;
            }
            set
            {
                this.OnPropertyChanged("url", this._url, value);
                this._url = value;
            }
        }

        /// <summary>
        ///  description,
        /// </summary>

        [DbProperty(MapingColumnName = "description", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string description
        {
            get
            {
                return this._description;
            }
            set
            {
                this.OnPropertyChanged("description", this._description, value);
                this._description = value;
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

        /// <summary>
        ///  category_ids,
        /// </summary>

        [DbProperty(MapingColumnName = "category_ids", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public string category_ids
        {
            get
            {
                return this._category_ids;
            }
            set
            {
                this.OnPropertyChanged("category_ids", this._category_ids, value);
                this._category_ids = value;
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

                logo = new PropertyItem("logo", tableName);

                url = new PropertyItem("url", tableName);

                description = new PropertyItem("description", tableName);

                sort = new PropertyItem("sort", tableName);

                category_ids = new PropertyItem("category_ids", tableName);


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
            /// logo,
            /// </summary> 
            public PropertyItem logo = null;
            /// <summary>
            /// url,
            /// </summary> 
            public PropertyItem url = null;
            /// <summary>
            /// description,
            /// </summary> 
            public PropertyItem description = null;
            /// <summary>
            /// sort,
            /// </summary> 
            public PropertyItem sort = null;
            /// <summary>
            /// category_ids,
            /// </summary> 
            public PropertyItem category_ids = null;
        }
        #endregion
    }

}
