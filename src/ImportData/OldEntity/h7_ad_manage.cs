using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace ImportData.OldEntity
{
    /// <summary>
    /// h7_ad_manage
    /// </summary>  
    
    public partial class h7_ad_manage : BaseEntity
    {
        public static Column _ = new Column("h7_ad_manage");

        public h7_ad_manage()
        {
            this.TableName = "h7_ad_manage";
            OnCreate();
        }


        #region 私有变量

        private int _id;

        private string _name;

        private int _type;

        private int _position_id;

        private string _link;

        private int _order;

        private int _width;

        private int _height;

        private DateTime? _start_time;

        private DateTime? _end_time;

        private string _content;

        private string _description;

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
        ///  type,
        /// </summary>

        [DbProperty(MapingColumnName = "type", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  position_id,
        /// </summary>

        [DbProperty(MapingColumnName = "position_id", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int position_id
        {
            get
            {
                return this._position_id;
            }
            set
            {
                this.OnPropertyChanged("position_id", this._position_id, value);
                this._position_id = value;
            }
        }

        /// <summary>
        ///  link,
        /// </summary>

        [DbProperty(MapingColumnName = "link", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string link
        {
            get
            {
                return this._link;
            }
            set
            {
                this.OnPropertyChanged("link", this._link, value);
                this._link = value;
            }
        }

        /// <summary>
        ///  order,
        /// </summary>

        [DbProperty(MapingColumnName = "order", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int order
        {
            get
            {
                return this._order;
            }
            set
            {
                this.OnPropertyChanged("order", this._order, value);
                this._order = value;
            }
        }

        /// <summary>
        ///  width,
        /// </summary>

        [DbProperty(MapingColumnName = "width", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int width
        {
            get
            {
                return this._width;
            }
            set
            {
                this.OnPropertyChanged("width", this._width, value);
                this._width = value;
            }
        }

        /// <summary>
        ///  height,
        /// </summary>

        [DbProperty(MapingColumnName = "height", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int height
        {
            get
            {
                return this._height;
            }
            set
            {
                this.OnPropertyChanged("height", this._height, value);
                this._height = value;
            }
        }

        /// <summary>
        ///  start_time,
        /// </summary>

        [DbProperty(MapingColumnName = "start_time", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public DateTime? start_time
        {
            get
            {
                return this._start_time;
            }
            set
            {
                this.OnPropertyChanged("start_time", this._start_time, value);
                this._start_time = value;
            }
        }

        /// <summary>
        ///  end_time,
        /// </summary>

        [DbProperty(MapingColumnName = "end_time", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public DateTime? end_time
        {
            get
            {
                return this._end_time;
            }
            set
            {
                this.OnPropertyChanged("end_time", this._end_time, value);
                this._end_time = value;
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
        ///  description,
        /// </summary>

        [DbProperty(MapingColumnName = "description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                id = new PropertyItem("id", tableName);

                name = new PropertyItem("name", tableName);

                type = new PropertyItem("type", tableName);

                position_id = new PropertyItem("position_id", tableName);

                link = new PropertyItem("link", tableName);

                order = new PropertyItem("order", tableName);

                width = new PropertyItem("width", tableName);

                height = new PropertyItem("height", tableName);

                start_time = new PropertyItem("start_time", tableName);

                end_time = new PropertyItem("end_time", tableName);

                content = new PropertyItem("content", tableName);

                description = new PropertyItem("description", tableName);


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
            /// type,
            /// </summary> 
            public PropertyItem type = null;
            /// <summary>
            /// position_id,
            /// </summary> 
            public PropertyItem position_id = null;
            /// <summary>
            /// link,
            /// </summary> 
            public PropertyItem link = null;
            /// <summary>
            /// order,
            /// </summary> 
            public PropertyItem order = null;
            /// <summary>
            /// width,
            /// </summary> 
            public PropertyItem width = null;
            /// <summary>
            /// height,
            /// </summary> 
            public PropertyItem height = null;
            /// <summary>
            /// start_time,
            /// </summary> 
            public PropertyItem start_time = null;
            /// <summary>
            /// end_time,
            /// </summary> 
            public PropertyItem end_time = null;
            /// <summary>
            /// content,
            /// </summary> 
            public PropertyItem content = null;
            /// <summary>
            /// description,
            /// </summary> 
            public PropertyItem description = null;
        }
        #endregion
    }

    public partial class h7_ad_position : BaseEntity
    {
        public static Column _ = new Column("h7_ad_position");

        public h7_ad_position()
        {
            this.TableName = "h7_ad_position";
            OnCreate();
        }


        #region 私有变量

        private int _id;

        private string _name;

        private int _width;

        private int _height;

        private int _type;

        private int _fashion;

        private int _status;

        private int _ad_nums;

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

        [DbProperty(MapingColumnName = "name", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  width,
        /// </summary>

        [DbProperty(MapingColumnName = "width", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int width
        {
            get
            {
                return this._width;
            }
            set
            {
                this.OnPropertyChanged("width", this._width, value);
                this._width = value;
            }
        }

        /// <summary>
        ///  height,
        /// </summary>

        [DbProperty(MapingColumnName = "height", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int height
        {
            get
            {
                return this._height;
            }
            set
            {
                this.OnPropertyChanged("height", this._height, value);
                this._height = value;
            }
        }

        /// <summary>
        ///  type,
        /// </summary>

        [DbProperty(MapingColumnName = "type", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  fashion,
        /// </summary>

        [DbProperty(MapingColumnName = "fashion", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int fashion
        {
            get
            {
                return this._fashion;
            }
            set
            {
                this.OnPropertyChanged("fashion", this._fashion, value);
                this._fashion = value;
            }
        }

        /// <summary>
        ///  status,
        /// </summary>

        [DbProperty(MapingColumnName = "status", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int status
        {
            get
            {
                return this._status;
            }
            set
            {
                this.OnPropertyChanged("status", this._status, value);
                this._status = value;
            }
        }

        /// <summary>
        ///  ad_nums,
        /// </summary>

        [DbProperty(MapingColumnName = "ad_nums", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ad_nums
        {
            get
            {
                return this._ad_nums;
            }
            set
            {
                this.OnPropertyChanged("ad_nums", this._ad_nums, value);
                this._ad_nums = value;
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

                width = new PropertyItem("width", tableName);

                height = new PropertyItem("height", tableName);

                type = new PropertyItem("type", tableName);

                fashion = new PropertyItem("fashion", tableName);

                status = new PropertyItem("status", tableName);

                ad_nums = new PropertyItem("ad_nums", tableName);


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
            /// width,
            /// </summary> 
            public PropertyItem width = null;
            /// <summary>
            /// height,
            /// </summary> 
            public PropertyItem height = null;
            /// <summary>
            /// type,
            /// </summary> 
            public PropertyItem type = null;
            /// <summary>
            /// fashion,
            /// </summary> 
            public PropertyItem fashion = null;
            /// <summary>
            /// status,
            /// </summary> 
            public PropertyItem status = null;
            /// <summary>
            /// ad_nums,
            /// </summary> 
            public PropertyItem ad_nums = null;
        }
        #endregion
    }

}
