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
    /// 角色人员关系表
    /// </summary>  
    [JsonObject]
    public partial class SysRoleAndUserRalation : BaseEntity
    {
        public static Column _ = new Column("SysRoleAndUserRalation");

        public SysRoleAndUserRalation()
        {
            this.TableName = "SysRoleAndUserRalation";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _UserId;

        private string _RoleId;

        private bool _IsDefault;

        #endregion

        #region 属性

        /// <summary>
        ///  ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  用户Id,
        /// </summary>

        [DbProperty(MapingColumnName = "UserId", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  角色ID,
        /// </summary>

        [DbProperty(MapingColumnName = "RoleId", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RoleId
        {
            get
            {
                return this._RoleId;
            }
            set
            {
                this.OnPropertyChanged("RoleId", this._RoleId, value);
                this._RoleId = value;
            }
        }

        /// <summary>
        ///  默认,
        /// </summary>

        [DbProperty(MapingColumnName = "IsDefault", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsDefault
        {
            get
            {
                return this._IsDefault;
            }
            set
            {
                this.OnPropertyChanged("IsDefault", this._IsDefault, value);
                this._IsDefault = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                UserId = new PropertyItem("UserId", tableName);

                RoleId = new PropertyItem("RoleId", tableName);

                IsDefault = new PropertyItem("IsDefault", tableName);


            }
            /// <summary>
            /// ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 用户Id,
            /// </summary> 
            public PropertyItem UserId = null;
            /// <summary>
            /// 角色ID,
            /// </summary> 
            public PropertyItem RoleId = null;
            /// <summary>
            /// 默认,
            /// </summary> 
            public PropertyItem IsDefault = null;
        }
        #endregion
    }
}
