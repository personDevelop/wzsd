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

        private string _SKUID;

        private string _UserId;

        private string _ReviewText;

        private DateTime _CreatedDate;

        private string _ParentID;

        private int _Status;

        private string _OrderId;

        private string _ImagesID;

        private string _ClassCode;

        private bool _hasReply;

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

        [DbProperty(MapingColumnName = "ProductId", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  SKU码,
        /// </summary>

        [DbProperty(MapingColumnName = "SKUID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SKUID
        {
            get
            {
                return this._SKUID;
            }
            set
            {
                this.OnPropertyChanged("SKUID", this._SKUID, value);
                this._SKUID = value;
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

        [DbProperty(MapingColumnName = "ParentID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {
                this.OnPropertyChanged("ParentID", this._ParentID, value);
                this._ParentID = value;
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

        /// <summary>
        ///  分级码,
        /// </summary>

        [DbProperty(MapingColumnName = "ClassCode", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ClassCode
        {
            get
            {
                return this._ClassCode;
            }
            set
            {
                this.OnPropertyChanged("ClassCode", this._ClassCode, value);
                this._ClassCode = value;
            }
        }

        /// <summary>
        ///  已回复,
        /// </summary>

        [DbProperty(MapingColumnName = "hasReply", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool hasReply
        {
            get
            {
                return this._hasReply;
            }
            set
            {
                this.OnPropertyChanged("hasReply", this._hasReply, value);
                this._hasReply = value;
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

                SKUID = new PropertyItem("SKUID", tableName);

                UserId = new PropertyItem("UserId", tableName);

                ReviewText = new PropertyItem("ReviewText", tableName);

                CreatedDate = new PropertyItem("CreatedDate", tableName);

                ParentID = new PropertyItem("ParentID", tableName);

                Status = new PropertyItem("Status", tableName);

                OrderId = new PropertyItem("OrderId", tableName);

                ImagesID = new PropertyItem("ImagesID", tableName);

                ClassCode = new PropertyItem("ClassCode", tableName);

                hasReply = new PropertyItem("hasReply", tableName);


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
            /// SKU码,
            /// </summary> 
            public PropertyItem SKUID = null;
            /// <summary>
            /// 会员ID,
            /// </summary> 
            public PropertyItem UserId = null;
            /// <summary>
            /// 评论内容,
            /// </summary> 
            public PropertyItem ReviewText = null;
            /// <summary>
            /// 评论日期,
            /// </summary> 
            public PropertyItem CreatedDate = null;
            /// <summary>
            /// 父ID,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 状态,0未审核，1已审核，2审核不通过
            /// </summary> 
            public PropertyItem Status = null;
            /// <summary>
            /// 订单ID,
            /// </summary> 
            public PropertyItem OrderId = null;
            /// <summary>
            /// 晒图图片,
            /// </summary> 
            public PropertyItem ImagesID = null;
            /// <summary>
            /// 分级码,
            /// </summary> 
            public PropertyItem ClassCode = null;
            /// <summary>
            /// 已回复,
            /// </summary> 
            public PropertyItem hasReply = null;
        }
        #endregion
    }
    public partial class ShopProductReviews
    {
        [NotDbCol]
        public string ProductName { get; set; }
          [NotDbCol]
        public string ProductImg { get; set; }
          [NotDbCol]
        public string[] Images { get; set; }
          [NotDbCol]
        public string UserName { get; set; }
          [NotDbCol]
        public string StatusStr
        {
            get
            {
                return ((DjStatus)Status).ToString();
            }
        }
          [NotDbCol]
        public ShopProductReviews CurrentReply { get; set; }
          [NotDbCol]
        public string LastReply { get; set; }
    }
}
