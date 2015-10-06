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
    /// 功能权限表
    /// </summary>  
    [JsonObject]
    public partial class FunctionRight : BaseEntity
    {
        public static Column _ = new Column("FunctionRight");

        public FunctionRight()
        {
            this.TableName = "FunctionRight";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _RoleID;

        private string _FunID;

        private string _MenuID;

        private bool _IsVisble;

        private bool _IsEnable;

        private int _RoleType;

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
        ///  角色ID,
        /// </summary>

        [DbProperty(MapingColumnName = "RoleID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RoleID
        {
            get
            {
                return this._RoleID;
            }
            set
            {
                this.OnPropertyChanged("RoleID", this._RoleID, value);
                this._RoleID = value;
            }
        }

        /// <summary>
        ///  功能ID,
        /// </summary>

        [DbProperty(MapingColumnName = "FunID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string FunID
        {
            get
            {
                return this._FunID;
            }
            set
            {
                this.OnPropertyChanged("FunID", this._FunID, value);
                this._FunID = value;
            }
        }

        /// <summary>
        ///  菜单ID,
        /// </summary>

        [DbProperty(MapingColumnName = "MenuID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string MenuID
        {
            get
            {
                return this._MenuID;
            }
            set
            {
                this.OnPropertyChanged("MenuID", this._MenuID, value);
                this._MenuID = value;
            }
        }

        /// <summary>
        ///  可见,
        /// </summary>

        [DbProperty(MapingColumnName = "IsVisble", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsVisble
        {
            get
            {
                return this._IsVisble;
            }
            set
            {
                this.OnPropertyChanged("IsVisble", this._IsVisble, value);
                this._IsVisble = value;
            }
        }

        /// <summary>
        ///  可用,
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
        ///  角色类型,0系统管理角色、1会员等级
        /// </summary>

        [DbProperty(MapingColumnName = "RoleType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int RoleType
        {
            get
            {
                return this._RoleType;
            }
            set
            {
                this.OnPropertyChanged("RoleType", this._RoleType, value);
                this._RoleType = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                RoleID = new PropertyItem("RoleID", tableName);

                FunID = new PropertyItem("FunID", tableName);

                MenuID = new PropertyItem("MenuID", tableName);

                IsVisble = new PropertyItem("IsVisble", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                RoleType = new PropertyItem("RoleType", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 角色ID,
            /// </summary> 
            public PropertyItem RoleID = null;
            /// <summary>
            /// 功能ID,
            /// </summary> 
            public PropertyItem FunID = null;
            /// <summary>
            /// 菜单ID,
            /// </summary> 
            public PropertyItem MenuID = null;
            /// <summary>
            /// 可见,
            /// </summary> 
            public PropertyItem IsVisble = null;
            /// <summary>
            /// 可用,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 角色类型,0系统管理角色、1会员等级
            /// </summary> 
            public PropertyItem RoleType = null;
        }
        #endregion
    }
}
