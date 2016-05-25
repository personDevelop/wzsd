using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportData.OldEntity
{
    /// <summary>
    /// h7_order_goods
    /// </summary>  
    
    public partial class h7_order_goods : BaseEntity
    {
        public static Column _ = new Column("h7_order_goods");

        public h7_order_goods()
        {
            this.TableName = "h7_order_goods";
            OnCreate();
        }


        #region 私有变量

        private int _id;

        private int _order_id;

        private int? _goods_id;

        private string _img;

        private int? _product_id;

        private decimal _goods_price;

        private decimal _real_price;

        private int _goods_nums;

        private string _goods_array;

        private decimal? _goods_weight;

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
        ///  order_id,
        /// </summary>

        [DbProperty(MapingColumnName = "order_id", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int order_id
        {
            get
            {
                return this._order_id;
            }
            set
            {
                this.OnPropertyChanged("order_id", this._order_id, value);


                this._order_id = value;
            }
        }

        /// <summary>
        ///  goods_id,
        /// </summary>

        [DbProperty(MapingColumnName = "goods_id", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int? goods_id
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
        ///  img,
        /// </summary>

        [DbProperty(MapingColumnName = "img", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  product_id,
        /// </summary>

        [DbProperty(MapingColumnName = "product_id", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int? product_id
        {
            get
            {
                return this._product_id;
            }
            set
            {
                this.OnPropertyChanged("product_id", this._product_id, value);


                this._product_id = value;
            }
        }

        /// <summary>
        ///  goods_price,
        /// </summary>

        [DbProperty(MapingColumnName = "goods_price", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal goods_price
        {
            get
            {
                return this._goods_price;
            }
            set
            {
                this.OnPropertyChanged("goods_price", this._goods_price, value);


                this._goods_price = value;
            }
        }

        /// <summary>
        ///  real_price,
        /// </summary>

        [DbProperty(MapingColumnName = "real_price", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal real_price
        {
            get
            {
                return this._real_price;
            }
            set
            {
                this.OnPropertyChanged("real_price", this._real_price, value);


                this._real_price = value;
            }
        }

        /// <summary>
        ///  goods_nums,
        /// </summary>

        [DbProperty(MapingColumnName = "goods_nums", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int goods_nums
        {
            get
            {
                return this._goods_nums;
            }
            set
            {
                this.OnPropertyChanged("goods_nums", this._goods_nums, value);


                this._goods_nums = value;
            }
        }

        /// <summary>
        ///  goods_array,
        /// </summary>

        [DbProperty(MapingColumnName = "goods_array", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string goods_array
        {
            get
            {
                return this._goods_array;
            }
            set
            {
                this.OnPropertyChanged("goods_array", this._goods_array, value);


                this._goods_array = value;
            }
        }

        /// <summary>
        ///  goods_weight,
        /// </summary>

        [DbProperty(MapingColumnName = "goods_weight", DbTypeString = "decimal", ColumnIsNull = true, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal? goods_weight
        {
            get
            {
                return this._goods_weight;
            }
            set
            {
                this.OnPropertyChanged("goods_weight", this._goods_weight, value);


                this._goods_weight = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                id = new PropertyItem("id", tableName);

                order_id = new PropertyItem("order_id", tableName);

                goods_id = new PropertyItem("goods_id", tableName);

                img = new PropertyItem("img", tableName);

                product_id = new PropertyItem("product_id", tableName);

                goods_price = new PropertyItem("goods_price", tableName);

                real_price = new PropertyItem("real_price", tableName);

                goods_nums = new PropertyItem("goods_nums", tableName);

                goods_array = new PropertyItem("goods_array", tableName);

                goods_weight = new PropertyItem("goods_weight", tableName);


            }
            /// <summary>
            /// id,
            /// </summary> 
            public PropertyItem id = null;
            /// <summary>
            /// order_id,
            /// </summary> 
            public PropertyItem order_id = null;
            /// <summary>
            /// goods_id,
            /// </summary> 
            public PropertyItem goods_id = null;
            /// <summary>
            /// img,
            /// </summary> 
            public PropertyItem img = null;
            /// <summary>
            /// product_id,
            /// </summary> 
            public PropertyItem product_id = null;
            /// <summary>
            /// goods_price,
            /// </summary> 
            public PropertyItem goods_price = null;
            /// <summary>
            /// real_price,
            /// </summary> 
            public PropertyItem real_price = null;
            /// <summary>
            /// goods_nums,
            /// </summary> 
            public PropertyItem goods_nums = null;
            /// <summary>
            /// goods_array,
            /// </summary> 
            public PropertyItem goods_array = null;
            /// <summary>
            /// goods_weight,
            /// </summary> 
            public PropertyItem goods_weight = null;
        }
        #endregion
    }

}
