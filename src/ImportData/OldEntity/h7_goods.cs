using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportData.OldEntity
{
    /// <summary>
    /// h7_goods
    /// </summary> 
    
    public partial class h7_goods : BaseEntity
    {
        public static Column _ = new Column("h7_goods");

        public h7_goods()
        {
            this.TableName = "h7_goods";
        }
       

        #region 私有变量
        private int _id;
        private string _name;
        private string _goods_no;
        private int _model_id;
        private decimal _sell_price;
        private decimal? _market_price;
        private decimal? _cost_price;
        private DateTime? _up_time;
        private DateTime? _down_time;
        private DateTime _create_time;
        private int _store_nums;
        private string _img;
        private int _is_del;
        private string _content;
        private string _keywords;
        private string _description;
        private string _search_words;
        private decimal _weight;
        private int _point;
        private string _unit;
        private int? _brand_id;
        private int _visit;
        private int _favorite;
        private int _sort;
        private string _spec_array;
        private int _exp;
        private int _comments;
        private int _sale;
        private int _grade;

        #endregion

        #region 属性
        /// <summary>
        ///  id,
        /// </summary>
        [PrimaryKey]
        [DbProperty(MapingColumnName = "id", DbTypeString = "int", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        
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
        [DbProperty(MapingColumnName = "name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 505, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        
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
        ///  goods_no,
        /// </summary>
        [DbProperty(MapingColumnName = "goods_no", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 505, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        
        public string goods_no
        {
            get
            {
                return this._goods_no;
            }
            set
            {

                this.OnPropertyChanged("goods_no", this._goods_no, value);
                this._goods_no = value;
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
        ///  sell_price,
        /// </summary>
        [DbProperty(MapingColumnName = "sell_price", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        
        public decimal sell_price
        {
            get
            {
                return this._sell_price;
            }
            set
            {

                this.OnPropertyChanged("sell_price", this._sell_price, value);
                this._sell_price = value;
            }
        }

        /// <summary>
        ///  market_price,
        /// </summary>
        [DbProperty(MapingColumnName = "market_price", DbTypeString = "decimal", ColumnIsNull = true, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
        
        public decimal? market_price
        {
            get
            {
                return this._market_price;
            }
            set
            {

                this.OnPropertyChanged("market_price", this._market_price, value);
                this._market_price = value;
            }
        }

        /// <summary>
        ///  cost_price,
        /// </summary>
        [DbProperty(MapingColumnName = "cost_price", DbTypeString = "decimal", ColumnIsNull = true, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
        
        public decimal? cost_price
        {
            get
            {
                return this._cost_price;
            }
            set
            {

                this.OnPropertyChanged("cost_price", this._cost_price, value);
                this._cost_price = value;
            }
        }

        /// <summary>
        ///  up_time,
        /// </summary>
        [DbProperty(MapingColumnName = "up_time", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
        
        public DateTime? up_time
        {
            get
            {
                return this._up_time;
            }
            set
            {

                this.OnPropertyChanged("up_time", this._up_time, value);
                this._up_time = value;
            }
        }

        /// <summary>
        ///  down_time,
        /// </summary>
        [DbProperty(MapingColumnName = "down_time", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
        
        public DateTime? down_time
        {
            get
            {
                return this._down_time;
            }
            set
            {

                this.OnPropertyChanged("down_time", this._down_time, value);
                this._down_time = value;
            }
        }

        /// <summary>
        ///  create_time,
        /// </summary>
        [DbProperty(MapingColumnName = "create_time", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        
        public DateTime create_time
        {
            get
            {
                return this._create_time;
            }
            set
            {

                this.OnPropertyChanged("create_time", this._create_time, value);
                this._create_time = value;
            }
        }

        /// <summary>
        ///  store_nums,
        /// </summary>
        [DbProperty(MapingColumnName = "store_nums", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]
        
        public int store_nums
        {
            get
            {
                return this._store_nums;
            }
            set
            {

                this.OnPropertyChanged("store_nums", this._store_nums, value);
                this._store_nums = value;
            }
        }

        /// <summary>
        ///  img,
        /// </summary>
        [DbProperty(MapingColumnName = "img", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 505, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
        
        public string img
        {
            get
            {
                return this._img;
            }
            set
            {

                this.OnPropertyChanged("img", this._img, value);
                this._img = value;
            }
        }

        /// <summary>
        ///  is_del,
        /// </summary>
        [DbProperty(MapingColumnName = "is_del", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]
        
        public int is_del
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

        /// <summary>
        ///  content,
        /// </summary>
        [DbProperty(MapingColumnName = "content", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
        
        public string content
        {
            get
            {
                return this._content;
            }
            set
            {

                this.OnPropertyChanged("content", this._content, value);
                this._content = value;
            }
        }

        /// <summary>
        ///  keywords,
        /// </summary>
        [DbProperty(MapingColumnName = "keywords", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 505, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
        
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
        ///  description,
        /// </summary>
        [DbProperty(MapingColumnName = "description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 505, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
        
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
        ///  search_words,
        /// </summary>
        [DbProperty(MapingColumnName = "search_words", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
        
        public string search_words
        {
            get
            {
                return this._search_words;
            }
            set
            {

                this.OnPropertyChanged("search_words", this._search_words, value);
                this._search_words = value;
            }
        }

        /// <summary>
        ///  weight,
        /// </summary>
        [DbProperty(MapingColumnName = "weight", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0.00))")]
        
        public decimal weight
        {
            get
            {
                return this._weight;
            }
            set
            {

                this.OnPropertyChanged("weight", this._weight, value);
                this._weight = value;
            }
        }

        /// <summary>
        ///  point,
        /// </summary>
        [DbProperty(MapingColumnName = "point", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]
        
        public int point
        {
            get
            {
                return this._point;
            }
            set
            {

                this.OnPropertyChanged("point", this._point, value);
                this._point = value;
            }
        }

        /// <summary>
        ///  unit,
        /// </summary>
        [DbProperty(MapingColumnName = "unit", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 10, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
        
        public string unit
        {
            get
            {
                return this._unit;
            }
            set
            {

                this.OnPropertyChanged("unit", this._unit, value);
                this._unit = value;
            }
        }

        /// <summary>
        ///  brand_id,
        /// </summary>
        [DbProperty(MapingColumnName = "brand_id", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
        
        public int? brand_id
        {
            get
            {
                return this._brand_id;
            }
            set
            {

                this.OnPropertyChanged("brand_id", this._brand_id, value);
                this._brand_id = value;
            }
        }

        /// <summary>
        ///  visit,
        /// </summary>
        [DbProperty(MapingColumnName = "visit", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]
        
        public int visit
        {
            get
            {
                return this._visit;
            }
            set
            {

                this.OnPropertyChanged("visit", this._visit, value);
                this._visit = value;
            }
        }

        /// <summary>
        ///  favorite,
        /// </summary>
        [DbProperty(MapingColumnName = "favorite", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]
        
        public int favorite
        {
            get
            {
                return this._favorite;
            }
            set
            {

                this.OnPropertyChanged("favorite", this._favorite, value);
                this._favorite = value;
            }
        }

        /// <summary>
        ///  sort,
        /// </summary>
        [DbProperty(MapingColumnName = "sort", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((99))")]
        
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
        ///  spec_array,
        /// </summary>
        [DbProperty(MapingColumnName = "spec_array", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]
        
        public string spec_array
        {
            get
            {
                return this._spec_array;
            }
            set
            {

                this.OnPropertyChanged("spec_array", this._spec_array, value);
                this._spec_array = value;
            }
        }

        /// <summary>
        ///  exp,
        /// </summary>
        [DbProperty(MapingColumnName = "exp", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]
        
        public int exp
        {
            get
            {
                return this._exp;
            }
            set
            {

                this.OnPropertyChanged("exp", this._exp, value);
                this._exp = value;
            }
        }

        /// <summary>
        ///  comments,
        /// </summary>
        [DbProperty(MapingColumnName = "comments", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]
        
        public int comments
        {
            get
            {
                return this._comments;
            }
            set
            {

                this.OnPropertyChanged("comments", this._comments, value);
                this._comments = value;
            }
        }

        /// <summary>
        ///  sale,
        /// </summary>
        [DbProperty(MapingColumnName = "sale", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]
        
        public int sale
        {
            get
            {
                return this._sale;
            }
            set
            {

                this.OnPropertyChanged("sale", this._sale, value);
                this._sale = value;
            }
        }

        /// <summary>
        ///  grade,
        /// </summary>
        [DbProperty(MapingColumnName = "grade", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]
        
        public int grade
        {
            get
            {
                return this._grade;
            }
            set
            {

                this.OnPropertyChanged("grade", this._grade, value);
                this._grade = value;
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

                goods_no = new PropertyItem("goods_no", tableName);

                model_id = new PropertyItem("model_id", tableName);

                sell_price = new PropertyItem("sell_price", tableName);

                market_price = new PropertyItem("market_price", tableName);

                cost_price = new PropertyItem("cost_price", tableName);

                up_time = new PropertyItem("up_time", tableName);

                down_time = new PropertyItem("down_time", tableName);

                create_time = new PropertyItem("create_time", tableName);

                store_nums = new PropertyItem("store_nums", tableName);

                img = new PropertyItem("img", tableName);

                is_del = new PropertyItem("is_del", tableName);

                content = new PropertyItem("content", tableName);

                keywords = new PropertyItem("keywords", tableName);

                description = new PropertyItem("description", tableName);

                search_words = new PropertyItem("search_words", tableName);

                weight = new PropertyItem("weight", tableName);

                point = new PropertyItem("point", tableName);

                unit = new PropertyItem("unit", tableName);

                brand_id = new PropertyItem("brand_id", tableName);

                visit = new PropertyItem("visit", tableName);

                favorite = new PropertyItem("favorite", tableName);

                sort = new PropertyItem("sort", tableName);

                spec_array = new PropertyItem("spec_array", tableName);

                exp = new PropertyItem("exp", tableName);

                comments = new PropertyItem("comments", tableName);

                sale = new PropertyItem("sale", tableName);

                grade = new PropertyItem("grade", tableName);


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
            /// goods_no,
            /// </summary> 
            public PropertyItem goods_no = null;
            /// <summary>
            /// model_id,
            /// </summary> 
            public PropertyItem model_id = null;
            /// <summary>
            /// sell_price,
            /// </summary> 
            public PropertyItem sell_price = null;
            /// <summary>
            /// market_price,
            /// </summary> 
            public PropertyItem market_price = null;
            /// <summary>
            /// cost_price,
            /// </summary> 
            public PropertyItem cost_price = null;
            /// <summary>
            /// up_time,
            /// </summary> 
            public PropertyItem up_time = null;
            /// <summary>
            /// down_time,
            /// </summary> 
            public PropertyItem down_time = null;
            /// <summary>
            /// create_time,
            /// </summary> 
            public PropertyItem create_time = null;
            /// <summary>
            /// store_nums,
            /// </summary> 
            public PropertyItem store_nums = null;
            /// <summary>
            /// img,
            /// </summary> 
            public PropertyItem img = null;
            /// <summary>
            /// is_del,
            /// </summary> 
            public PropertyItem is_del = null;
            /// <summary>
            /// content,
            /// </summary> 
            public PropertyItem content = null;
            /// <summary>
            /// keywords,
            /// </summary> 
            public PropertyItem keywords = null;
            /// <summary>
            /// description,
            /// </summary> 
            public PropertyItem description = null;
            /// <summary>
            /// search_words,
            /// </summary> 
            public PropertyItem search_words = null;
            /// <summary>
            /// weight,
            /// </summary> 
            public PropertyItem weight = null;
            /// <summary>
            /// point,
            /// </summary> 
            public PropertyItem point = null;
            /// <summary>
            /// unit,
            /// </summary> 
            public PropertyItem unit = null;
            /// <summary>
            /// brand_id,
            /// </summary> 
            public PropertyItem brand_id = null;
            /// <summary>
            /// visit,
            /// </summary> 
            public PropertyItem visit = null;
            /// <summary>
            /// favorite,
            /// </summary> 
            public PropertyItem favorite = null;
            /// <summary>
            /// sort,
            /// </summary> 
            public PropertyItem sort = null;
            /// <summary>
            /// spec_array,
            /// </summary> 
            public PropertyItem spec_array = null;
            /// <summary>
            /// exp,
            /// </summary> 
            public PropertyItem exp = null;
            /// <summary>
            /// comments,
            /// </summary> 
            public PropertyItem comments = null;
            /// <summary>
            /// sale,
            /// </summary> 
            public PropertyItem sale = null;
            /// <summary>
            /// grade,
            /// </summary> 
            public PropertyItem grade = null;
        }
        #endregion
    }

    public partial class h7_goods_photo_relation : BaseEntity
    {
        public static Column _ = new Column("h7_goods_photo_relation");

        public h7_goods_photo_relation()
        {
            this.TableName = "h7_goods_photo_relation";
        }
        

        #region 私有变量

        private int _id;

        private int _goods_id;

        private string _photo_id;

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
        ///  photo_id,
        /// </summary>

        [DbProperty(MapingColumnName = "photo_id", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 32, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        
        public string photo_id
        {
            get
            {
                return this._photo_id;
            }
            set
            {
                this.OnPropertyChanged("photo_id", this._photo_id, value);
                this._photo_id = value;
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

                photo_id = new PropertyItem("photo_id", tableName);


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
            /// photo_id,
            /// </summary> 
            public PropertyItem photo_id = null;
        }
        #endregion
    }
    /// <summary>
    /// h7_goods_photo
    /// </summary>  

    public partial class h7_goods_photo : BaseEntity
    {
        public static Column _ = new Column("h7_goods_photo");

        public h7_goods_photo()
        {
            this.TableName = "h7_goods_photo";
            OnCreate();
        }


        #region 私有变量

        private string _id;

        private string _img;

        #endregion

        #region 属性

        /// <summary>
        ///  id,
        /// </summary>

        [DbProperty(MapingColumnName = "id", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 32, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string id
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
        ///  img,
        /// </summary>

        [DbProperty(MapingColumnName = "img", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string img
        {
            get
            {
                return this._img;
            }
            set
            {
                this.OnPropertyChanged("img", this._img, value);
                this._img = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                id = new PropertyItem("id", tableName);

                img = new PropertyItem("img", tableName);


            }
            /// <summary>
            /// id,
            /// </summary> 
            public PropertyItem id = null;
            /// <summary>
            /// img,
            /// </summary> 
            public PropertyItem img = null;
        }
        #endregion
    }

    public partial class goods_photo : BaseEntity
    {
        public int goods_id { get; set; }
        public string img { get; set; }
    }

}
