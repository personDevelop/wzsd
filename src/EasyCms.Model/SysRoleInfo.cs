using Newtonsoft.Json;
using Sharp.Common;
using System.Runtime.Serialization;

namespace EasyCms.Model
{
    /// <summary>
    /// 角色表
    /// </summary> 
    [JsonObject]
    public partial class SysRoleInfo : BaseEntity
    {
        public static Column _ = new Column("SysRoleInfo");

        public SysRoleInfo()
        {
            this.TableName = "SysRoleInfo";
            OnCreate();
        }
         

        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private bool _Enable;

        private string _Note;

        private string _RoleClass;

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
        ///  可用,
        /// </summary>

        [DbProperty(MapingColumnName = "Enable", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 1, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
         
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
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
         
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
        ///  角色分类,
        /// </summary>

        [DbProperty(MapingColumnName = "RoleClass", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
         
        public string RoleClass
        {
            get
            {
                return this._RoleClass;
            }
            set
            {
                this.OnPropertyChanged("RoleClass", this._RoleClass, value);
                this._RoleClass = value;
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

                Enable = new PropertyItem("Enable", tableName);

                Note = new PropertyItem("Note", tableName);

                RoleClass = new PropertyItem("RoleClass", tableName);


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
            /// 可用,
            /// </summary> 
            public PropertyItem Enable = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 角色分类,
            /// </summary> 
            public PropertyItem RoleClass = null;
        }
        #endregion
    }
    public partial class SysRoleInfo
    {
        protected override void OnCreate()
        {
            Enable = true;
        }
    }
}
