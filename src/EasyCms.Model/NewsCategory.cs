using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyCms.Model
{
    /// <summary>
    /// 新闻分类
    /// </summary>  
    public partial class NewsCategory : BaseEntity
    {
        public static Column _ = new Column("NewsCategory");

        public NewsCategory()
        {
            this.TableName = "NewsCategory";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private int _ClassTypeID;

        private int _ClassModel;

        private string _Description;

        private string _DescriptionText;

        private string _ImageUrl;

        private string _Keywords;

        private int _OrderNo;

        private int _State;

        private bool _AllowAddContent;

        private string _ParentID;

        private string _FJM;

        private int _JS;

        private string _Note;

        private bool _AllowSubclass;

        private string _PageModelName;

        private DateTime _CreatedDate;

        private string _CreatedUserID;

        private string _Meta_Title;

        private string _Meta_Description;

        private string _Meta_Keywords;

        private int _WebSiteType;

        #endregion

        #region 属性

        /// <summary>
        ///  主键,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  栏目类型,主导航 /频道版块
        /// </summary>

        [DbProperty(MapingColumnName = "ClassTypeID", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ClassTypeID
        {
            get
            {
                return this._ClassTypeID;
            }
            set
            {
                this.OnPropertyChanged("ClassTypeID", this._ClassTypeID, value);
                this._ClassTypeID = value;
            }
        }

        /// <summary>
        ///  内容模式,文章列表0/单文章1
        /// </summary>

        [DbProperty(MapingColumnName = "ClassModel", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ClassModel
        {
            get
            {
                return this._ClassModel;
            }
            set
            {
                this.OnPropertyChanged("ClassModel", this._ClassModel, value);
                this._ClassModel = value;
            }
        }

        /// <summary>
        ///  栏目描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "text", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this.OnPropertyChanged("Description", this._Description, value);
                this._Description = value;
            }
        }

        /// <summary>
        ///  栏目描述纯文本,
        /// </summary>

        [DbProperty(MapingColumnName = "DescriptionText", DbTypeString = "text", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string DescriptionText
        {
            get
            {
                return this._DescriptionText;
            }
            set
            {
                this.OnPropertyChanged("DescriptionText", this._DescriptionText, value);
                this._DescriptionText = value;
            }
        }

        /// <summary>
        ///  缩略图,
        /// </summary>

        [DbProperty(MapingColumnName = "ImageUrl", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ImageUrl
        {
            get
            {
                return this._ImageUrl;
            }
            set
            {
                this.OnPropertyChanged("ImageUrl", this._ImageUrl, value);
                this._ImageUrl = value;
            }
        }

        /// <summary>
        ///  关键字,
        /// </summary>

        [DbProperty(MapingColumnName = "Keywords", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Keywords
        {
            get
            {
                return this._Keywords;
            }
            set
            {
                this.OnPropertyChanged("Keywords", this._Keywords, value);
                this._Keywords = value;
            }
        }

        /// <summary>
        ///  显示顺序,
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
        ///  状态,0草稿,1等待审核， 2审核通过
        /// </summary>

        [DbProperty(MapingColumnName = "State", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int State
        {
            get
            {
                return this._State;
            }
            set
            {
                this.OnPropertyChanged("State", this._State, value);
                this._State = value;
            }
        }

        /// <summary>
        ///  允许增加内容,
        /// </summary>

        [DbProperty(MapingColumnName = "AllowAddContent", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool AllowAddContent
        {
            get
            {
                return this._AllowAddContent;
            }
            set
            {
                this.OnPropertyChanged("AllowAddContent", this._AllowAddContent, value);
                this._AllowAddContent = value;
            }
        }

        /// <summary>
        ///  父级类别,
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
        ///  分级码,
        /// </summary>

        [DbProperty(MapingColumnName = "FJM", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string FJM
        {
            get
            {
                return this._FJM;
            }
            set
            {
                this.OnPropertyChanged("FJM", this._FJM, value);
                this._FJM = value;
            }
        }

        /// <summary>
        ///  级数,
        /// </summary>

        [DbProperty(MapingColumnName = "JS", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int JS
        {
            get
            {
                return this._JS;
            }
            set
            {
                this.OnPropertyChanged("JS", this._JS, value);
                this._JS = value;
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
        ///  允许增加子类,
        /// </summary>

        [DbProperty(MapingColumnName = "AllowSubclass", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool AllowSubclass
        {
            get
            {
                return this._AllowSubclass;
            }
            set
            {
                this.OnPropertyChanged("AllowSubclass", this._AllowSubclass, value);
                this._AllowSubclass = value;
            }
        }

        /// <summary>
        ///  页模型名称,
        /// </summary>

        [DbProperty(MapingColumnName = "PageModelName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PageModelName
        {
            get
            {
                return this._PageModelName;
            }
            set
            {
                this.OnPropertyChanged("PageModelName", this._PageModelName, value);
                this._PageModelName = value;
            }
        }

        /// <summary>
        ///  创建日期,
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
        ///  创建人ID,
        /// </summary>

        [DbProperty(MapingColumnName = "CreatedUserID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CreatedUserID
        {
            get
            {
                return this._CreatedUserID;
            }
            set
            {
                this.OnPropertyChanged("CreatedUserID", this._CreatedUserID, value);
                this._CreatedUserID = value;
            }
        }

        /// <summary>
        ///  页面标题,
        /// </summary>

        [DbProperty(MapingColumnName = "Meta_Title", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Meta_Title
        {
            get
            {
                return this._Meta_Title;
            }
            set
            {
                this.OnPropertyChanged("Meta_Title", this._Meta_Title, value);
                this._Meta_Title = value;
            }
        }

        /// <summary>
        ///  页面描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Meta_Description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Meta_Description
        {
            get
            {
                return this._Meta_Description;
            }
            set
            {
                this.OnPropertyChanged("Meta_Description", this._Meta_Description, value);
                this._Meta_Description = value;
            }
        }

        /// <summary>
        ///  页面关键字,
        /// </summary>

        [DbProperty(MapingColumnName = "Meta_Keywords", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Meta_Keywords
        {
            get
            {
                return this._Meta_Keywords;
            }
            set
            {
                this.OnPropertyChanged("Meta_Keywords", this._Meta_Keywords, value);
                this._Meta_Keywords = value;
            }
        }

        /// <summary>
        ///  所属站点,0默认站点,1手机站点
        /// </summary>

        [DbProperty(MapingColumnName = "WebSiteType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int WebSiteType
        {
            get
            {
                return this._WebSiteType;
            }
            set
            {
                this.OnPropertyChanged("WebSiteType", this._WebSiteType, value);
                this._WebSiteType = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                Code = new PropertyItem("Code", tableName);

                Name = new PropertyItem("Name", tableName);

                ClassTypeID = new PropertyItem("ClassTypeID", tableName);

                ClassModel = new PropertyItem("ClassModel", tableName);

                Description = new PropertyItem("Description", tableName);

                DescriptionText = new PropertyItem("DescriptionText", tableName);

                ImageUrl = new PropertyItem("ImageUrl", tableName);

                Keywords = new PropertyItem("Keywords", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);

                State = new PropertyItem("State", tableName);

                AllowAddContent = new PropertyItem("AllowAddContent", tableName);

                ParentID = new PropertyItem("ParentID", tableName);

                FJM = new PropertyItem("FJM", tableName);

                JS = new PropertyItem("JS", tableName);

                Note = new PropertyItem("Note", tableName);

                AllowSubclass = new PropertyItem("AllowSubclass", tableName);

                PageModelName = new PropertyItem("PageModelName", tableName);

                CreatedDate = new PropertyItem("CreatedDate", tableName);

                CreatedUserID = new PropertyItem("CreatedUserID", tableName);

                Meta_Title = new PropertyItem("Meta_Title", tableName);

                Meta_Description = new PropertyItem("Meta_Description", tableName);

                Meta_Keywords = new PropertyItem("Meta_Keywords", tableName);

                WebSiteType = new PropertyItem("WebSiteType", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 栏目类型,主导航 /频道版块
            /// </summary> 
            public PropertyItem ClassTypeID = null;
            /// <summary>
            /// 内容模式,文章列表0/单文章1
            /// </summary> 
            public PropertyItem ClassModel = null;
            /// <summary>
            /// 栏目描述,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 栏目描述纯文本,
            /// </summary> 
            public PropertyItem DescriptionText = null;
            /// <summary>
            /// 缩略图,
            /// </summary> 
            public PropertyItem ImageUrl = null;
            /// <summary>
            /// 关键字,
            /// </summary> 
            public PropertyItem Keywords = null;
            /// <summary>
            /// 显示顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
            /// <summary>
            /// 状态,0草稿,1等待审核， 2审核通过
            /// </summary> 
            public PropertyItem State = null;
            /// <summary>
            /// 允许增加内容,
            /// </summary> 
            public PropertyItem AllowAddContent = null;
            /// <summary>
            /// 父级类别,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 分级码,
            /// </summary> 
            public PropertyItem FJM = null;
            /// <summary>
            /// 级数,
            /// </summary> 
            public PropertyItem JS = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 允许增加子类,
            /// </summary> 
            public PropertyItem AllowSubclass = null;
            /// <summary>
            /// 页模型名称,
            /// </summary> 
            public PropertyItem PageModelName = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CreatedDate = null;
            /// <summary>
            /// 创建人ID,
            /// </summary> 
            public PropertyItem CreatedUserID = null;
            /// <summary>
            /// 页面标题,
            /// </summary> 
            public PropertyItem Meta_Title = null;
            /// <summary>
            /// 页面描述,
            /// </summary> 
            public PropertyItem Meta_Description = null;
            /// <summary>
            /// 页面关键字,
            /// </summary> 
            public PropertyItem Meta_Keywords = null;
            /// <summary>
            /// 所属站点,0默认站点,1手机站点
            /// </summary> 
            public PropertyItem WebSiteType = null;
        }
        #endregion
    }


    public partial class NewsCategory
    {
        protected override void OnCreate()
        {
           
            AllowAddContent = AllowSubclass = true;
            CreatedDate = DateTime.Now;
        }
        [NotDbCol]
        public string ParentName { get; set; }
    }
}
