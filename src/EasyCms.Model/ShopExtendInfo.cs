using Newtonsoft.Json;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyCms.Model
{

    /// <summary>
    /// 扩展属性
    /// </summary>  
    [JsonObject]
    public partial class ShopExtendInfo : BaseEntity
    {
        public static Column _ = new Column("ShopExtendInfo");

        public ShopExtendInfo()
        {
            this.TableName = "ShopExtendInfo";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _FullName;

        private string _Name;

        private string _UnitText;

        private AttrShowType _ShowType;

        private int _DisplayOrder;

        private string _CategoryID;

        private bool _UseAttrImg;

        private bool _UseDefineImg;

        private UsageMode _UsageMode;

        private bool _IsCanSearch;

        private string _ValInfo;

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
        ///  全称,全称不能重复
        /// </summary>

        [DbProperty(MapingColumnName = "FullName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string FullName
        {
            get
            {
                return this._FullName;
            }
            set
            {
                this.OnPropertyChanged("FullName", this._FullName, value);
                this._FullName = value;
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
        ///  单位,
        /// </summary>

        [DbProperty(MapingColumnName = "UnitText", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UnitText
        {
            get
            {
                return this._UnitText;
            }
            set
            {
                this.OnPropertyChanged("UnitText", this._UnitText, value);
                this._UnitText = value;
            }
        }

        /// <summary>
        ///  展示方式,单选、多选、文本
        /// </summary>

        [DbProperty(MapingColumnName = "ShowType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AttrShowType ShowType
        {
            get
            {
                return this._ShowType;
            }
            set
            {
                this.OnPropertyChanged("ShowType", this._ShowType, value);
                this._ShowType = value;
            }
        }

        /// <summary>
        ///  显示顺序,
        /// </summary>

        [DbProperty(MapingColumnName = "DisplayOrder", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int DisplayOrder
        {
            get
            {
                return this._DisplayOrder;
            }
            set
            {
                this.OnPropertyChanged("DisplayOrder", this._DisplayOrder, value);
                this._DisplayOrder = value;
            }
        }

        /// <summary>
        ///  分类ID,
        /// </summary>

        [DbProperty(MapingColumnName = "CategoryID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CategoryID
        {
            get
            {
                return this._CategoryID;
            }
            set
            {
                this.OnPropertyChanged("CategoryID", this._CategoryID, value);
                this._CategoryID = value;
            }
        }

        /// <summary>
        ///  使用属性图标,
        /// </summary>

        [DbProperty(MapingColumnName = "UseAttrImg", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool UseAttrImg
        {
            get
            {
                return this._UseAttrImg;
            }
            set
            {
                this.OnPropertyChanged("UseAttrImg", this._UseAttrImg, value);
                this._UseAttrImg = value;
            }
        }

        /// <summary>
        ///  自定义图标,
        /// </summary>

        [DbProperty(MapingColumnName = "UseDefineImg", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool UseDefineImg
        {
            get
            {
                return this._UseDefineImg;
            }
            set
            {
                this.OnPropertyChanged("UseDefineImg", this._UseDefineImg, value);
                this._UseDefineImg = value;
            }
        }

        /// <summary>
        ///  使用模式,0:系统扩展属性，1 用户自定义属性，2系统规格，3用户自定义规格,
        /// </summary>

        [DbProperty(MapingColumnName = "UsageMode", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public UsageMode UsageMode
        {
            get
            {
                return this._UsageMode;
            }
            set
            {
                this.OnPropertyChanged("UsageMode", this._UsageMode, value);
                this._UsageMode = value;
            }
        }

        /// <summary>
        ///  作为筛选项,
        /// </summary>

        [DbProperty(MapingColumnName = "IsCanSearch", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsCanSearch
        {
            get
            {
                return this._IsCanSearch;
            }
            set
            {
                this.OnPropertyChanged("IsCanSearch", this._IsCanSearch, value);
                this._IsCanSearch = value;
            }
        }

        /// <summary>
        ///  对应的值,
        /// </summary>

        [DbProperty(MapingColumnName = "ValInfo", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 4000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ValInfo
        {
            get
            {
                return this._ValInfo;
            }
            set
            {
                this.OnPropertyChanged("ValInfo", this._ValInfo, value);
                this._ValInfo = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                FullName = new PropertyItem("FullName", tableName);

                Name = new PropertyItem("Name", tableName);

                UnitText = new PropertyItem("UnitText", tableName);

                ShowType = new PropertyItem("ShowType", tableName);

                DisplayOrder = new PropertyItem("DisplayOrder", tableName);

                CategoryID = new PropertyItem("CategoryID", tableName);

                UseAttrImg = new PropertyItem("UseAttrImg", tableName);

                UseDefineImg = new PropertyItem("UseDefineImg", tableName);

                UsageMode = new PropertyItem("UsageMode", tableName);

                IsCanSearch = new PropertyItem("IsCanSearch", tableName);

                ValInfo = new PropertyItem("ValInfo", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 全称,全称不能重复
            /// </summary> 
            public PropertyItem FullName = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 单位,
            /// </summary> 
            public PropertyItem UnitText = null;
            /// <summary>
            /// 展示方式,单选、多选、文本
            /// </summary> 
            public PropertyItem ShowType = null;
            /// <summary>
            /// 显示顺序,
            /// </summary> 
            public PropertyItem DisplayOrder = null;
            /// <summary>
            /// 分类ID,
            /// </summary> 
            public PropertyItem CategoryID = null;
            /// <summary>
            /// 使用属性图标,
            /// </summary> 
            public PropertyItem UseAttrImg = null;
            /// <summary>
            /// 自定义图标,
            /// </summary> 
            public PropertyItem UseDefineImg = null;
            /// <summary>
            /// 使用模式,0:系统扩展属性，1 用户自定义属性，2系统规格，3用户自定义规格,
            /// </summary> 
            public PropertyItem UsageMode = null;
            /// <summary>
            /// 作为筛选项,
            /// </summary> 
            public PropertyItem IsCanSearch = null;
            /// <summary>
            /// 对应的值,
            /// </summary> 
            public PropertyItem ValInfo = null;
        }
        #endregion
    }


    public partial class ShopExtendInfo
    {
        /// <summary>
        ///  分类名称
        /// </summary> 
        [NotDbCol]
        public string CategoryName
        {
            get;
            set;
        }

        /// <summary>
        ///  新增时传递规格值用
        /// </summary> 
        [NotDbCol]
        public string Vals
        {
            get;
            set;
        }
    }
    [JsonObject]
    public class ShopExtendWithValue
    {
        #region 属性
        /// <summary>
        ///  主键,
        /// </summary> 
        public string AttributeId
        {
            get;
            set;
        }

        /// <summary>
        ///  名称,
        /// </summary> 
        public string Name
        {
            get;
            set;
        }
        public DataTable Values { get; set; }
        #endregion
        public override bool Equals(object obj)
        {
            if (obj is ShopExtendWithValue)
            {


                return this.AttributeId == (obj as ShopExtendWithValue).AttributeId;
            } return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }



    }
}
