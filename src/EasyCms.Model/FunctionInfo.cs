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
    /// 功能菜单
    /// </summary>  
    [JsonObject]
    public partial class FunctionInfo : BaseEntity
    {
        public static Column _ = new Column("FunctionInfo");

        public FunctionInfo()
        {
            this.TableName = "FunctionInfo";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private FunctionType _FuncType;

        private string _Image;

        private AccessType _AccessType;

        private string _URL;

        private string _CallArea;

        private string _CallControler;

        private string _CallAction;

        private bool _Enable;

        private bool _Visible;

        private bool _MultilInstance;

        private string _ShowText;

        private string _ParentID;

        private string _ClassCode;

        private int _OrderNo;

        private bool _IsMustNot;

        private bool _IsMust;

        private string _Description;

        private int _Js;

        private bool _IsAnony;

        private bool _IsRecord;

        #endregion

        #region 属性

        /// <summary>
        ///  主键,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  编码,
        /// </summary>

        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  功能类型,后台菜单、网站导航、API、其它
        /// </summary>

        [DbProperty(MapingColumnName = "FuncType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public FunctionType FuncType
        {
            get
            {
                return this._FuncType;
            }
            set
            {
                this.OnPropertyChanged("FuncType", this._FuncType, value);
                this._FuncType = value;
            }
        }

        /// <summary>
        ///  图标,
        /// </summary>

        [DbProperty(MapingColumnName = "Image", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                this.OnPropertyChanged("Image", this._Image, value);
                this._Image = value;
            }
        }

        /// <summary>
        ///  功能访问类型,0层级模块,1普通模块,2MVC功能,3API、4URL功能,5其它
        /// </summary>

        [DbProperty(MapingColumnName = "AccessType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AccessType AccessType
        {
            get
            {
                return this._AccessType;
            }
            set
            {
                this.OnPropertyChanged("AccessType", this._AccessType, value);
                this._AccessType = value;
            }
        }

        /// <summary>
        ///  网址,web：对应页面URL
        /// </summary>

        [DbProperty(MapingColumnName = "URL", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string URL
        {
            get
            {
                return this._URL;
            }
            set
            {
                this.OnPropertyChanged("URL", this._URL, value);
                this._URL = value;
            }
        }

        /// <summary>
        ///  域,mvc时对应的区域，可以为空
        /// </summary>

        [DbProperty(MapingColumnName = "CallArea", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CallArea
        {
            get
            {
                return this._CallArea;
            }
            set
            {
                this.OnPropertyChanged("CallArea", this._CallArea, value);
                this._CallArea = value;
            }
        }

        /// <summary>
        ///  控制器,mvc时对应的控制器
        /// </summary>

        [DbProperty(MapingColumnName = "CallControler", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CallControler
        {
            get
            {
                return this._CallControler;
            }
            set
            {
                this.OnPropertyChanged("CallControler", this._CallControler, value);
                this._CallControler = value;
            }
        }

        /// <summary>
        ///  动作,mvc对应的动作
        /// </summary>

        [DbProperty(MapingColumnName = "CallAction", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CallAction
        {
            get
            {
                return this._CallAction;
            }
            set
            {
                this.OnPropertyChanged("CallAction", this._CallAction, value);
                this._CallAction = value;
            }
        }

        /// <summary>
        ///  启用,
        /// </summary>

        [DbProperty(MapingColumnName = "Enable", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool Enable
        {
            get
            {
                return this._Enable;
            }
            set
            {
                this.OnPropertyChanged("Enable", this._Enable, value);
                this._Enable = value;
            }
        }

        /// <summary>
        ///  可见,
        /// </summary>

        [DbProperty(MapingColumnName = "Visible", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool Visible
        {
            get
            {
                return this._Visible;
            }
            set
            {
                this.OnPropertyChanged("Visible", this._Visible, value);
                this._Visible = value;
            }
        }

        /// <summary>
        ///  是否多开,
        /// </summary>

        [DbProperty(MapingColumnName = "MultilInstance", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool MultilInstance
        {
            get
            {
                return this._MultilInstance;
            }
            set
            {
                this.OnPropertyChanged("MultilInstance", this._MultilInstance, value);
                this._MultilInstance = value;
            }
        }

        /// <summary>
        ///  窗口显示的名称,给窗口Text属性用
        /// </summary>

        [DbProperty(MapingColumnName = "ShowText", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShowText
        {
            get
            {
                return this._ShowText;
            }
            set
            {
                this.OnPropertyChanged("ShowText", this._ShowText, value);
                this._ShowText = value;
            }
        }

        /// <summary>
        ///  父对象,
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

        [DbProperty(MapingColumnName = "ClassCode", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  必定不展示的权限,一般给设计人员使用的功能
        /// </summary>

        [DbProperty(MapingColumnName = "IsMustNot", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]

        public bool IsMustNot
        {
            get
            {
                return this._IsMustNot;
            }
            set
            {
                this.OnPropertyChanged("IsMustNot", this._IsMustNot, value);
                this._IsMustNot = value;
            }
        }

        /// <summary>
        ///  基本必备功能,不用设置权限也会使用的基本功能,或者表示可匿名方法
        /// </summary>

        [DbProperty(MapingColumnName = "IsMust", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]

        public bool IsMust
        {
            get
            {
                return this._IsMust;
            }
            set
            {
                this.OnPropertyChanged("IsMust", this._IsMust, value);
                this._IsMust = value;
            }
        }

        /// <summary>
        ///  功能模块描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 4000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  级数,
        /// </summary>

        [DbProperty(MapingColumnName = "Js", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Js
        {
            get
            {
                return this._Js;
            }
            set
            {
                this.OnPropertyChanged("Js", this._Js, value);
                this._Js = value;
            }
        }

        /// <summary>
        ///  允许匿名登录,
        /// </summary>

        [DbProperty(MapingColumnName = "IsAnony", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsAnony
        {
            get
            {
                return this._IsAnony;
            }
            set
            {
                this.OnPropertyChanged("IsAnony", this._IsAnony, value);
                this._IsAnony = value;
            }
        }

        /// <summary>
        ///  记录操作日志,
        /// </summary>

        [DbProperty(MapingColumnName = "IsRecord", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsRecord
        {
            get
            {
                return this._IsRecord;
            }
            set
            {
                this.OnPropertyChanged("IsRecord", this._IsRecord, value);
                this._IsRecord = value;
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

                FuncType = new PropertyItem("FuncType", tableName);

                Image = new PropertyItem("Image", tableName);

                AccessType = new PropertyItem("AccessType", tableName);

                URL = new PropertyItem("URL", tableName);

                CallArea = new PropertyItem("CallArea", tableName);

                CallControler = new PropertyItem("CallControler", tableName);

                CallAction = new PropertyItem("CallAction", tableName);

                Enable = new PropertyItem("Enable", tableName);

                Visible = new PropertyItem("Visible", tableName);

                MultilInstance = new PropertyItem("MultilInstance", tableName);

                ShowText = new PropertyItem("ShowText", tableName);

                ParentID = new PropertyItem("ParentID", tableName);

                ClassCode = new PropertyItem("ClassCode", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);

                IsMustNot = new PropertyItem("IsMustNot", tableName);

                IsMust = new PropertyItem("IsMust", tableName);

                Description = new PropertyItem("Description", tableName);

                Js = new PropertyItem("Js", tableName);

                IsAnony = new PropertyItem("IsAnony", tableName);

                IsRecord = new PropertyItem("IsRecord", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 编码,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 功能类型,后台菜单、网站导航、API、其它
            /// </summary> 
            public PropertyItem FuncType = null;
            /// <summary>
            /// 图标,
            /// </summary> 
            public PropertyItem Image = null;
            /// <summary>
            /// 功能访问类型,0层级模块,1普通模块,2MVC功能,3API、4URL功能,5其它
            /// </summary> 
            public PropertyItem AccessType = null;
            /// <summary>
            /// 网址,web：对应页面URL
            /// </summary> 
            public PropertyItem URL = null;
            /// <summary>
            /// 域,mvc时对应的区域，可以为空
            /// </summary> 
            public PropertyItem CallArea = null;
            /// <summary>
            /// 控制器,mvc时对应的控制器
            /// </summary> 
            public PropertyItem CallControler = null;
            /// <summary>
            /// 动作,mvc对应的动作
            /// </summary> 
            public PropertyItem CallAction = null;
            /// <summary>
            /// 启用,
            /// </summary> 
            public PropertyItem Enable = null;
            /// <summary>
            /// 可见,
            /// </summary> 
            public PropertyItem Visible = null;
            /// <summary>
            /// 是否多开,
            /// </summary> 
            public PropertyItem MultilInstance = null;
            /// <summary>
            /// 窗口显示的名称,给窗口Text属性用
            /// </summary> 
            public PropertyItem ShowText = null;
            /// <summary>
            /// 父对象,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 分级码,
            /// </summary> 
            public PropertyItem ClassCode = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
            /// <summary>
            /// 必定不展示的权限,一般给设计人员使用的功能
            /// </summary> 
            public PropertyItem IsMustNot = null;
            /// <summary>
            /// 基本必备功能,不用设置权限也会使用的基本功能,或者表示可匿名方法
            /// </summary> 
            public PropertyItem IsMust = null;
            /// <summary>
            /// 功能模块描述,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 级数,
            /// </summary> 
            public PropertyItem Js = null;
            /// <summary>
            /// 允许匿名登录,
            /// </summary> 
            public PropertyItem IsAnony = null;
            /// <summary>
            /// 记录操作日志,
            /// </summary> 
            public PropertyItem IsRecord = null;
        }
        #endregion
    }

    public partial class FunctionInfo
    {
        protected override void OnCreate()
        {
            Enable = Visible = IsRecord = true;
        }
        [NotDbCol]
        public string ParentName { get; set; }
    }
}
