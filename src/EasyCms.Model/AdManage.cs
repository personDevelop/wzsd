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
    /// PC端广告管理
    /// </summary>  
    [JsonObject]
    public partial class AdManage : BaseEntity
    {
        public static Column _ = new Column("AdManage");

        public AdManage()
        {
            this.TableName = "AdManage";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _PositionID;

        private string _Code;

        private string _Name;

        private AdType _AdType;

        private string _ImgageID;

        private string _AdContent;

        private AdLinkType _AdLinkType;

        private string _LinkVal;

        private string _LinkUrl;

        private int _OrderNo;

        private string _Note;

        private string _Width;

        private string _Height;

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
        ///  位置ID,
        /// </summary>

        [DbProperty(MapingColumnName = "PositionID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PositionID
        {
            get
            {
                return this._PositionID;
            }
            set
            {
                this.OnPropertyChanged("PositionID", this._PositionID, value);
                this._PositionID = value;
            }
        }

        /// <summary>
        ///  编号,
        /// </summary>

        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this.OnPropertyChanged("Code", this._Code, value);
                this._Code = value;
            }
        }

        /// <summary>
        ///  名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnPropertyChanged("Name", this._Name, value);
                this._Name = value;
            }
        }

        /// <summary>
        ///  广告类型,
        /// </summary>

        [DbProperty(MapingColumnName = "AdType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AdType AdType
        {
            get
            {
                return this._AdType;
            }
            set
            {
                this.OnPropertyChanged("AdType", this._AdType, value);
                this._AdType = value;
            }
        }

        /// <summary>
        ///  图片,对应图片ID
        /// </summary>

        [DbProperty(MapingColumnName = "ImgageID", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ImgageID
        {
            get
            {
                return this._ImgageID;
            }
            set
            {
                this.OnPropertyChanged("ImgageID", this._ImgageID, value);
                this._ImgageID = value;
            }
        }

        /// <summary>
        ///  广告内容,文字内容
        /// </summary>

        [DbProperty(MapingColumnName = "AdContent", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 2000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string AdContent
        {
            get
            {
                return this._AdContent;
            }
            set
            {
                this.OnPropertyChanged("AdContent", this._AdContent, value);
                this._AdContent = value;
            }
        }

        /// <summary>
        ///  链接类型,打开商品，打开新闻，打开公告，自定义
        /// </summary>

        [DbProperty(MapingColumnName = "AdLinkType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AdLinkType AdLinkType
        {
            get
            {
                return this._AdLinkType;
            }
            set
            {
                this.OnPropertyChanged("AdLinkType", this._AdLinkType, value);
                this._AdLinkType = value;
            }
        }

        /// <summary>
        ///  对应的值,
        /// </summary>

        [DbProperty(MapingColumnName = "LinkVal", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string LinkVal
        {
            get
            {
                return this._LinkVal;
            }
            set
            {
                this.OnPropertyChanged("LinkVal", this._LinkVal, value);
                this._LinkVal = value;
            }
        }

        /// <summary>
        ///  链接地址,当时商品时，存储商品名字，新闻和公告也是对应的名字
        /// </summary>

        [DbProperty(MapingColumnName = "LinkUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string LinkUrl
        {
            get
            {
                return this._LinkUrl;
            }
            set
            {
                this.OnPropertyChanged("LinkUrl", this._LinkUrl, value);
                this._LinkUrl = value;
            }
        }

        /// <summary>
        ///  顺序,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderNo", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int OrderNo
        {
            get
            {
                return this._OrderNo;
            }
            set
            {
                this.OnPropertyChanged("OrderNo", this._OrderNo, value);
                this._OrderNo = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Note
        {
            get
            {
                return this._Note;
            }
            set
            {
                this.OnPropertyChanged("Note", this._Note, value);
                this._Note = value;
            }
        }

        /// <summary>
        ///  宽度,
        /// </summary>

        [DbProperty(MapingColumnName = "Width", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Width
        {
            get
            {
                return this._Width;
            }
            set
            {
                this.OnPropertyChanged("Width", this._Width, value);
                this._Width = value;
            }
        }

        /// <summary>
        ///  高度,
        /// </summary>

        [DbProperty(MapingColumnName = "Height", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Height
        {
            get
            {
                return this._Height;
            }
            set
            {
                this.OnPropertyChanged("Height", this._Height, value);
                this._Height = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                PositionID = new PropertyItem("PositionID", tableName);

                Code = new PropertyItem("Code", tableName);

                Name = new PropertyItem("Name", tableName);

                AdType = new PropertyItem("AdType", tableName);

                ImgageID = new PropertyItem("ImgageID", tableName);

                AdContent = new PropertyItem("AdContent", tableName);

                AdLinkType = new PropertyItem("AdLinkType", tableName);

                LinkVal = new PropertyItem("LinkVal", tableName);

                LinkUrl = new PropertyItem("LinkUrl", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);

                Note = new PropertyItem("Note", tableName);

                Width = new PropertyItem("Width", tableName);

                Height = new PropertyItem("Height", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 位置ID,
            /// </summary> 
            public PropertyItem PositionID = null;
            /// <summary>
            /// 编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 广告类型,
            /// </summary> 
            public PropertyItem AdType = null;
            /// <summary>
            /// 图片,对应图片ID
            /// </summary> 
            public PropertyItem ImgageID = null;
            /// <summary>
            /// 广告内容,文字内容
            /// </summary> 
            public PropertyItem AdContent = null;
            /// <summary>
            /// 链接类型,打开商品，打开新闻，打开公告，自定义
            /// </summary> 
            public PropertyItem AdLinkType = null;
            /// <summary>
            /// 对应的值,
            /// </summary> 
            public PropertyItem LinkVal = null;
            /// <summary>
            /// 链接地址,当时商品时，存储商品名字，新闻和公告也是对应的名字
            /// </summary> 
            public PropertyItem LinkUrl = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 宽度,
            /// </summary> 
            public PropertyItem Width = null;
            /// <summary>
            /// 高度,
            /// </summary> 
            public PropertyItem Height = null;
        }
        #endregion
    }


    public partial class AdManage
    {
        [NotDbCol]
        public string PositionName { get; set; }
        [NotDbCol]
        public string AdImgUrl { get; set; }
    }
}
