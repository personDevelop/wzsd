using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyCms.Model
{
    /// <summary>
    /// 商品分类
    /// </summary>  
    public partial class ShopCategory : BaseEntity
    {
        public static Column _ = new Column("ShopCategory");

        public ShopCategory()
        {
            this.TableName = "ShopCategory";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private string _ParentID;

        private string _ClassCode;

        private bool _IsMx;

        private int _OrderNo;

        private string _Theme;

        private string _PageTitle;

        private string _Description;

        private string _KewWord;

        private int _Depth;

        private string _SKUPrefix;

        private string _BigLogo;

        private string _SmallLogo;

        private bool _IsEnable;

        private string _Note;

        private string _AssociatedProductType;

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
        ///  分类名称,
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
        ///  上级分类,
        /// </summary>

        [DbProperty(MapingColumnName = "ParentID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        [DbProperty(MapingColumnName = "ClassCode", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  是否明细,
        /// </summary>

        [DbProperty(MapingColumnName = "IsMx", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsMx
        {
            get
            {
                return this._IsMx;
            }
            set
            {
                this.OnPropertyChanged("IsMx", this._IsMx, value);
                this._IsMx = value;
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
        ///  主题皮肤,
        /// </summary>

        [DbProperty(MapingColumnName = "Theme", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Theme
        {
            get
            {
                return this._Theme;
            }
            set
            {
                this.OnPropertyChanged("Theme", this._Theme, value);
                this._Theme = value;
            }
        }

        /// <summary>
        ///  页面标题,
        /// </summary>

        [DbProperty(MapingColumnName = "PageTitle", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PageTitle
        {
            get
            {
                return this._PageTitle;
            }
            set
            {
                this.OnPropertyChanged("PageTitle", this._PageTitle, value);
                this._PageTitle = value;
            }
        }

        /// <summary>
        ///  页面描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  页面关键字,
        /// </summary>

        [DbProperty(MapingColumnName = "KewWord", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string KewWord
        {
            get
            {
                return this._KewWord;
            }
            set
            {
                this.OnPropertyChanged("KewWord", this._KewWord, value);
                this._KewWord = value;
            }
        }

        /// <summary>
        ///  深度,
        /// </summary>

        [DbProperty(MapingColumnName = "Depth", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Depth
        {
            get
            {
                return this._Depth;
            }
            set
            {
                this.OnPropertyChanged("Depth", this._Depth, value);
                this._Depth = value;
            }
        }

        /// <summary>
        ///  SKU码前缀,
        /// </summary>

        [DbProperty(MapingColumnName = "SKUPrefix", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SKUPrefix
        {
            get
            {
                return this._SKUPrefix;
            }
            set
            {
                this.OnPropertyChanged("SKUPrefix", this._SKUPrefix, value);
                this._SKUPrefix = value;
            }
        }

        /// <summary>
        ///  分类大图标地址,
        /// </summary>

        [DbProperty(MapingColumnName = "BigLogo", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BigLogo
        {
            get
            {
                return this._BigLogo;
            }
            set
            {
                this.OnPropertyChanged("BigLogo", this._BigLogo, value);
                this._BigLogo = value;
            }
        }

        /// <summary>
        ///  分类小图标地址,
        /// </summary>

        [DbProperty(MapingColumnName = "SmallLogo", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SmallLogo
        {
            get
            {
                return this._SmallLogo;
            }
            set
            {
                this.OnPropertyChanged("SmallLogo", this._SmallLogo, value);
                this._SmallLogo = value;
            }
        }

        /// <summary>
        ///  启用,
        /// </summary>

        [DbProperty(MapingColumnName = "IsEnable", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsEnable
        {
            get
            {
                return this._IsEnable;
            }
            set
            {
                this.OnPropertyChanged("IsEnable", this._IsEnable, value);
                this._IsEnable = value;
            }
        }

        /// <summary>
        ///  分类描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "text", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  关联商品类型,
        /// </summary>

        [DbProperty(MapingColumnName = "AssociatedProductType", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string AssociatedProductType
        {
            get
            {
                return this._AssociatedProductType;
            }
            set
            {
                this.OnPropertyChanged("AssociatedProductType", this._AssociatedProductType, value);
                this._AssociatedProductType = value;
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

                ParentID = new PropertyItem("ParentID", tableName);

                ClassCode = new PropertyItem("ClassCode", tableName);

                IsMx = new PropertyItem("IsMx", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);

                Theme = new PropertyItem("Theme", tableName);

                PageTitle = new PropertyItem("PageTitle", tableName);

                Description = new PropertyItem("Description", tableName);

                KewWord = new PropertyItem("KewWord", tableName);

                Depth = new PropertyItem("Depth", tableName);

                SKUPrefix = new PropertyItem("SKUPrefix", tableName);

                BigLogo = new PropertyItem("BigLogo", tableName);

                SmallLogo = new PropertyItem("SmallLogo", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                Note = new PropertyItem("Note", tableName);

                AssociatedProductType = new PropertyItem("AssociatedProductType", tableName);


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
            /// 分类名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 上级分类,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 分级码,
            /// </summary> 
            public PropertyItem ClassCode = null;
            /// <summary>
            /// 是否明细,
            /// </summary> 
            public PropertyItem IsMx = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
            /// <summary>
            /// 主题皮肤,
            /// </summary> 
            public PropertyItem Theme = null;
            /// <summary>
            /// 页面标题,
            /// </summary> 
            public PropertyItem PageTitle = null;
            /// <summary>
            /// 页面描述,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 页面关键字,
            /// </summary> 
            public PropertyItem KewWord = null;
            /// <summary>
            /// 深度,
            /// </summary> 
            public PropertyItem Depth = null;
            /// <summary>
            /// SKU码前缀,
            /// </summary> 
            public PropertyItem SKUPrefix = null;
            /// <summary>
            /// 分类大图标地址,
            /// </summary> 
            public PropertyItem BigLogo = null;
            /// <summary>
            /// 分类小图标地址,
            /// </summary> 
            public PropertyItem SmallLogo = null;
            /// <summary>
            /// 启用,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 分类描述,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 关联商品类型,
            /// </summary> 
            public PropertyItem AssociatedProductType = null;
        }
        #endregion
    }
    public partial class ShopCategory
    {
        protected override void OnCreate()
        {
            this.IsEnable = true;
        }
        [NotDbCol]
        public string ParentName { get; set; }
    }
}
