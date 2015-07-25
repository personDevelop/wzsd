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
    /// 商品评论
    /// </summary>  
    [JsonObject]
    public partial class ShopProductReviews : BaseEntity
    {
        public static Column _ = new Column("ShopProductReviews");

        public ShopProductReviews()
        {
            this.TableName = "ShopProductReviews";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ProductId;

        private string _UserId;

        private string _ReviewText;

        private string _UserName;

        private string _UserEmail;

        private DateTime _CreatedDate;

        private string _ParentId;

        private int _Status;

        private string _OrderId;

        private string _SKU;

        private string _Attribute;

        private string _ImagesID;

        #endregion

        #region 属性

        /// <summary>
        ///  主键ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 1, ColumnDefaultValue = "")]

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
        ///  商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductId", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductId
        {
            get
            {
                return this._ProductId;
            }
            set
            {
                this.OnPropertyChanged("ProductId", this._ProductId, value);
                this._ProductId = value;
            }
        }

        /// <summary>
        ///  会员ID,
        /// </summary>

        [DbProperty(MapingColumnName = "UserId", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                this.OnPropertyChanged("UserId", this._UserId, value);
                this._UserId = value;
            }
        }

        /// <summary>
        ///  评论内容,
        /// </summary>

        [DbProperty(MapingColumnName = "ReviewText", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 4000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ReviewText
        {
            get
            {
                return this._ReviewText;
            }
            set
            {
                this.OnPropertyChanged("ReviewText", this._ReviewText, value);
                this._ReviewText = value;
            }
        }

        /// <summary>
        ///  会员姓名,
        /// </summary>

        [DbProperty(MapingColumnName = "UserName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 400, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this.OnPropertyChanged("UserName", this._UserName, value);
                this._UserName = value;
            }
        }

        /// <summary>
        ///  会员邮箱,
        /// </summary>

        [DbProperty(MapingColumnName = "UserEmail", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserEmail
        {
            get
            {
                return this._UserEmail;
            }
            set
            {
                this.OnPropertyChanged("UserEmail", this._UserEmail, value);
                this._UserEmail = value;
            }
        }

        /// <summary>
        ///  评论日期,
        /// </summary>

        [DbProperty(MapingColumnName = "CreatedDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime CreatedDate
        {
            get
            {
                return this._CreatedDate;
            }
            set
            {
                this.OnPropertyChanged("CreatedDate", this._CreatedDate, value);
                this._CreatedDate = value;
            }
        }

        /// <summary>
        ///  父ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ParentId", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ParentId
        {
            get
            {
                return this._ParentId;
            }
            set
            {
                this.OnPropertyChanged("ParentId", this._ParentId, value);
                this._ParentId = value;
            }
        }

        /// <summary>
        ///  状态,0未审核，1已审核，2审核不通过
        /// </summary>

        [DbProperty(MapingColumnName = "Status", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this.OnPropertyChanged("Status", this._Status, value);
                this._Status = value;
            }
        }

        /// <summary>
        ///  订单ID,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderId", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]

        public string OrderId
        {
            get
            {
                return this._OrderId;
            }
            set
            {
                this.OnPropertyChanged("OrderId", this._OrderId, value);
                this._OrderId = value;
            }
        }

        /// <summary>
        ///  SKU码,
        /// </summary>

        [DbProperty(MapingColumnName = "SKU", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 400, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SKU
        {
            get
            {
                return this._SKU;
            }
            set
            {
                this.OnPropertyChanged("SKU", this._SKU, value);
                this._SKU = value;
            }
        }

        /// <summary>
        ///  商品规格值,
        /// </summary>

        [DbProperty(MapingColumnName = "Attribute", DbTypeString = "text", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Attribute
        {
            get
            {
                return this._Attribute;
            }
            set
            {
                this.OnPropertyChanged("Attribute", this._Attribute, value);
                this._Attribute = value;
            }
        }

        /// <summary>
        ///  晒图图片,
        /// </summary>

        [DbProperty(MapingColumnName = "ImagesID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ImagesID
        {
            get
            {
                return this._ImagesID;
            }
            set
            {
                this.OnPropertyChanged("ImagesID", this._ImagesID, value);
                this._ImagesID = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                ProductId = new PropertyItem("ProductId", tableName);

                UserId = new PropertyItem("UserId", tableName);

                ReviewText = new PropertyItem("ReviewText", tableName);

                UserName = new PropertyItem("UserName", tableName);

                UserEmail = new PropertyItem("UserEmail", tableName);

                CreatedDate = new PropertyItem("CreatedDate", tableName);

                ParentId = new PropertyItem("ParentId", tableName);

                Status = new PropertyItem("Status", tableName);

                OrderId = new PropertyItem("OrderId", tableName);

                SKU = new PropertyItem("SKU", tableName);

                Attribute = new PropertyItem("Attribute", tableName);

                ImagesID = new PropertyItem("ImagesID", tableName);


            }
            /// <summary>
            /// 主键ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 商品ID,
            /// </summary> 
            public PropertyItem ProductId = null;
            /// <summary>
            /// 会员ID,
            /// </summary> 
            public PropertyItem UserId = null;
            /// <summary>
            /// 评论内容,
            /// </summary> 
            public PropertyItem ReviewText = null;
            /// <summary>
            /// 会员姓名,
            /// </summary> 
            public PropertyItem UserName = null;
            /// <summary>
            /// 会员邮箱,
            /// </summary> 
            public PropertyItem UserEmail = null;
            /// <summary>
            /// 评论日期,
            /// </summary> 
            public PropertyItem CreatedDate = null;
            /// <summary>
            /// 父ID,
            /// </summary> 
            public PropertyItem ParentId = null;
            /// <summary>
            /// 状态,0未审核，1已审核，2审核不通过
            /// </summary> 
            public PropertyItem Status = null;
            /// <summary>
            /// 订单ID,
            /// </summary> 
            public PropertyItem OrderId = null;
            /// <summary>
            /// SKU码,
            /// </summary> 
            public PropertyItem SKU = null;
            /// <summary>
            /// 商品规格值,
            /// </summary> 
            public PropertyItem Attribute = null;
            /// <summary>
            /// 晒图图片,
            /// </summary> 
            public PropertyItem ImagesID = null;
        }
        #endregion
    }
}
