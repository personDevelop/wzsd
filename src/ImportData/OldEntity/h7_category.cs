using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportData.OldEntity
{
    /// <summary>
    /// h7_category
    /// </summary> 
     
    public partial class h7_category : BaseEntity
    {
        public static Column _ = new Column("h7_category");

        public h7_category()
        {
            this.TableName = "h7_category";
        }
         

        #region 私有变量
        private int _id;
        private string _name;
        private int _parent_id;
        private int _sort;
        private int _visibility;
        private int _model_id;
        private string _keywords;
        private string _descript;
        private string _title;
        private string _thumb;

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
        ///  visibility,
        /// </summary>
        [DbProperty(MapingColumnName = "visibility", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((1))")]
         
        public int visibility
        {
            get
            {
                return this._visibility;
            }
            set
            {

                this.OnPropertyChanged("visibility", this._visibility, value);
                this._visibility = value;
            }
        }

        /// <summary>
        ///  model_id,
        /// </summary>
        [DbProperty(MapingColumnName = "model_id", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
         
        public int model_id
        {
            get
            {
                return this._model_id;
            }
            set
            {

                this.OnPropertyChanged("model_id", this._model_id, value);
                this._model_id = value;
            }
        }

        /// <summary>
        ///  keywords,
        /// </summary>
        [DbProperty(MapingColumnName = "keywords", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
         
        public string keywords
        {
            get
            {
                return this._keywords;
            }
            set
            {

                this.OnPropertyChanged("keywords", this._keywords, value);
                this._keywords = value;
            }
        }

        /// <summary>
        ///  descript,
        /// </summary>
        [DbProperty(MapingColumnName = "descript", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
         
        public string descript
        {
            get
            {
                return this._descript;
            }
            set
            {

                this.OnPropertyChanged("descript", this._descript, value);
                this._descript = value;
            }
        }

        /// <summary>
        ///  title,
        /// </summary>
        [DbProperty(MapingColumnName = "title", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
         
        public string title
        {
            get
            {
                return this._title;
            }
            set
            {

                this.OnPropertyChanged("title", this._title, value);
                this._title = value;
            }
        }

        /// <summary>
        ///  thumb,
        /// </summary>
        [DbProperty(MapingColumnName = "thumb", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
         
        public string thumb
        {
            get
            {
                return this._thumb;
            }
            set
            {

                this.OnPropertyChanged("thumb", this._thumb, value);
                this._thumb = value;
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

                parent_id = new PropertyItem("parent_id", tableName);

                sort = new PropertyItem("sort", tableName);

                visibility = new PropertyItem("visibility", tableName);

                model_id = new PropertyItem("model_id", tableName);

                keywords = new PropertyItem("keywords", tableName);

                descript = new PropertyItem("descript", tableName);

                title = new PropertyItem("title", tableName);

                thumb = new PropertyItem("thumb", tableName);


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
            /// parent_id,
            /// </summary> 
            public PropertyItem parent_id = null;
            /// <summary>
            /// sort,
            /// </summary> 
            public PropertyItem sort = null;
            /// <summary>
            /// visibility,
            /// </summary> 
            public PropertyItem visibility = null;
            /// <summary>
            /// model_id,
            /// </summary> 
            public PropertyItem model_id = null;
            /// <summary>
            /// keywords,
            /// </summary> 
            public PropertyItem keywords = null;
            /// <summary>
            /// descript,
            /// </summary> 
            public PropertyItem descript = null;
            /// <summary>
            /// title,
            /// </summary> 
            public PropertyItem title = null;
            /// <summary>
            /// thumb,
            /// </summary> 
            public PropertyItem thumb = null;
        }
        #endregion
    }
    /// <summary>
    /// h7_category_extend
    /// </summary>  
   
    public partial class h7_category_extend : BaseEntity
    {
        public static Column _ = new Column("h7_category_extend");

        public h7_category_extend()
        {
            this.TableName = "h7_category_extend";
            OnCreate();
        }


        #region 私有变量

        private int _id;

        private int _goods_id;

        private int _category_id;

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
        ///  goods_id,
        /// </summary>

        [DbProperty(MapingColumnName = "goods_id", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int goods_id
        {
            get
            {
                return this._goods_id;
            }
            set
            {
                this.OnPropertyChanged("goods_id", this._goods_id, value);
                this._goods_id = value;
            }
        }

        /// <summary>
        ///  category_id,
        /// </summary>

        [DbProperty(MapingColumnName = "category_id", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int category_id
        {
            get
            {
                return this._category_id;
            }
            set
            {
                this.OnPropertyChanged("category_id", this._category_id, value);
                this._category_id = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                id = new PropertyItem("id", tableName);

                goods_id = new PropertyItem("goods_id", tableName);

                category_id = new PropertyItem("category_id", tableName);


            }
            /// <summary>
            /// id,
            /// </summary> 
            public PropertyItem id = null;
            /// <summary>
            /// goods_id,
            /// </summary> 
            public PropertyItem goods_id = null;
            /// <summary>
            /// category_id,
            /// </summary> 
            public PropertyItem category_id = null;
        }
        #endregion
    }

}
