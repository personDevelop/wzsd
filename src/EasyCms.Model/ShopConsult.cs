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
    /// 商品咨询
    /// </summary>  
    [JsonObject]
    public partial class ShopConsult : BaseEntity
    {
        public static Column _ = new Column("ShopConsult");

        public ShopConsult()
        {
            this.TableName = "ShopConsult";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ProductId;

        private string _UserId;

        private string _ReviewText;

        private DateTime _CreatedDate;

        private string _ConsoltTypeID;

        private string _ParentID;

        private string _ClassCode;

        private CommentStatus _Status;

        private string _ProductName;

        private string _UserName;

        private string _ConsoltTypeName;

        #endregion

        #region 属性

        /// <summary>
        ///  主键,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        [DbProperty(MapingColumnName = "ProductId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        [DbProperty(MapingColumnName = "UserId", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  咨询内容,
        /// </summary>

        [DbProperty(MapingColumnName = "ReviewText", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  咨询日期,
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
        ///  咨询类型ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ConsoltTypeID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ConsoltTypeID
        {
            get
            {
                return this._ConsoltTypeID;
            }
            set
            {
                this.OnPropertyChanged("ConsoltTypeID", this._ConsoltTypeID, value);
                this._ConsoltTypeID = value;
            }
        }

        /// <summary>
        ///  父ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ParentID", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  分级码,
        /// </summary>

        [DbProperty(MapingColumnName = "ClassCode", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  状态,0，未答复，1已答复,2已屏蔽
        /// </summary>

        [DbProperty(MapingColumnName = "Status", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public CommentStatus Status
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
        ///  商品名称,
        /// </summary>
        [NotDbCol]

        [DbProperty(MapingColumnName = "ProductName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductName
        {
            get
            {
                return this._ProductName;
            }
            set
            {
                this.OnPropertyChanged("ProductName", this._ProductName, value);
                this._ProductName = value;
            }
        }

        /// <summary>
        ///  会员名称,
        /// </summary>
        [NotDbCol]

        [DbProperty(MapingColumnName = "UserName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  咨询类型,
        /// </summary>
        [NotDbCol]

        [DbProperty(MapingColumnName = "ConsoltTypeName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ConsoltTypeName
        {
            get
            {
                return this._ConsoltTypeName;
            }
            set
            {
                this.OnPropertyChanged("ConsoltTypeName", this._ConsoltTypeName, value);
                this._ConsoltTypeName = value;
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

                CreatedDate = new PropertyItem("CreatedDate", tableName);

                ConsoltTypeID = new PropertyItem("ConsoltTypeID", tableName);

                ParentID = new PropertyItem("ParentID", tableName);

                ClassCode = new PropertyItem("ClassCode", tableName);

                Status = new PropertyItem("Status", tableName);

                ProductName = new PropertyItem("ProductName", tableName);

                UserName = new PropertyItem("UserName", tableName);

                ConsoltTypeName = new PropertyItem("ConsoltTypeName", tableName);


            }
            /// <summary>
            /// 主键,
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
            /// 咨询内容,
            /// </summary> 
            public PropertyItem ReviewText = null;
            /// <summary>
            /// 咨询日期,
            /// </summary> 
            public PropertyItem CreatedDate = null;
            /// <summary>
            /// 咨询类型ID,
            /// </summary> 
            public PropertyItem ConsoltTypeID = null;
            /// <summary>
            /// 父ID,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 分级码,
            /// </summary> 
            public PropertyItem ClassCode = null;
            /// <summary>
            /// 状态,0，未答复，1已答复,2已屏蔽
            /// </summary> 
            public PropertyItem Status = null;
            /// <summary>
            /// 商品名称,
            /// </summary> 
            public PropertyItem ProductName = null;
            /// <summary>
            /// 会员名称,
            /// </summary> 
            public PropertyItem UserName = null;
            /// <summary>
            /// 咨询类型,
            /// </summary> 
            public PropertyItem ConsoltTypeName = null;
        }
        #endregion
    }


    public partial class ShopConsult
    {
        [NotDbCol]
        public string ProductImg { get; set; }
        [NotDbCol]
    public ShopConsult CurrentShopConsult { get; set; }

        [NotDbCol]
        public string LastReply { get; set; }
    }
}
