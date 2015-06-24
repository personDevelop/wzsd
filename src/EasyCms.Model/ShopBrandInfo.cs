using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyCms.Model
{
    /// <summary>
    /// 品牌信息
    /// </summary>  
    public partial class ShopBrandInfo : BaseEntity
    {
        public static Column _ = new Column("ShopBrandInfo");

        public ShopBrandInfo()
        {
            this.TableName = "ShopBrandInfo";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private string _Meta_Description;

        private string _Meta_Keywords;

        private string _Logo;

        private string _CompanyUrl;

        private string _Description;

        private int _OrderNo;

        private string _Theme;

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
        ///  检索拼音,
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
        ///  品牌名称,
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
        ///  页面关键词,
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
        ///  品牌图片,
        /// </summary>

        [DbProperty(MapingColumnName = "Logo", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Logo
        {
            get
            {
                return this._Logo;
            }
            set
            {
                this.OnPropertyChanged("Logo", this._Logo, value);
                this._Logo = value;
            }
        }

        /// <summary>
        ///  品牌官方地址,
        /// </summary>

        [DbProperty(MapingColumnName = "CompanyUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 300, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CompanyUrl
        {
            get
            {
                return this._CompanyUrl;
            }
            set
            {
                this.OnPropertyChanged("CompanyUrl", this._CompanyUrl, value);
                this._CompanyUrl = value;
            }
        }

        /// <summary>
        ///  品牌介绍,
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
        ///  皮肤,
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

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                Code = new PropertyItem("Code", tableName);

                Name = new PropertyItem("Name", tableName);

                Meta_Description = new PropertyItem("Meta_Description", tableName);

                Meta_Keywords = new PropertyItem("Meta_Keywords", tableName);

                Logo = new PropertyItem("Logo", tableName);

                CompanyUrl = new PropertyItem("CompanyUrl", tableName);

                Description = new PropertyItem("Description", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);

                Theme = new PropertyItem("Theme", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 检索拼音,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 品牌名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 页面描述,
            /// </summary> 
            public PropertyItem Meta_Description = null;
            /// <summary>
            /// 页面关键词,
            /// </summary> 
            public PropertyItem Meta_Keywords = null;
            /// <summary>
            /// 品牌图片,
            /// </summary> 
            public PropertyItem Logo = null;
            /// <summary>
            /// 品牌官方地址,
            /// </summary> 
            public PropertyItem CompanyUrl = null;
            /// <summary>
            /// 品牌介绍,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 显示顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
            /// <summary>
            /// 皮肤,
            /// </summary> 
            public PropertyItem Theme = null;
        }
        #endregion
    }

}
