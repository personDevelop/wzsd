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
    /// 系统广告牌管理
    /// </summary>  
    [JsonObject]
    public partial class SystemBrandInfo : BaseEntity
    {
        public static Column _ = new Column("SystemBrandInfo");

        public SystemBrandInfo()
        {
            this.TableName = "SystemBrandInfo";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private BrandType _BrandType;

        private AppHandleTag _AppHandleTag;

        private string _ActionValue;

        private DateTime _CreateTime;

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
        ///  类型,
        /// </summary>

        [DbProperty(MapingColumnName = "BrandType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public BrandType BrandType
        {
            get
            {
                return this._BrandType;
            }
            set
            {
                this.OnPropertyChanged("BrandType", this._BrandType, value);
                this._BrandType = value;
            }
        }

        /// <summary>
        ///  动作类型,
        /// </summary>

        [DbProperty(MapingColumnName = "AppHandleTag", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AppHandleTag AppHandleTag
        {
            get
            {
                return this._AppHandleTag;
            }
            set
            {
                this.OnPropertyChanged("AppHandleTag", this._AppHandleTag, value);
                this._AppHandleTag = value;
            }
        }

        /// <summary>
        ///  附属的值,
        /// </summary>

        [DbProperty(MapingColumnName = "ActionValue", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ActionValue
        {
            get
            {
                return this._ActionValue;
            }
            set
            {
                this.OnPropertyChanged("ActionValue", this._ActionValue, value);
                this._ActionValue = value;
            }
        }

        /// <summary>
        ///  创建时间,
        /// </summary>

        [DbProperty(MapingColumnName = "CreateTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime CreateTime
        {
            get
            {
                return this._CreateTime;
            }
            set
            {
                this.OnPropertyChanged("CreateTime", this._CreateTime, value);
                this._CreateTime = value;
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

                BrandType = new PropertyItem("BrandType", tableName);

                AppHandleTag = new PropertyItem("AppHandleTag", tableName);

                ActionValue = new PropertyItem("ActionValue", tableName);

                CreateTime = new PropertyItem("CreateTime", tableName);


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
            /// 类型,
            /// </summary> 
            public PropertyItem BrandType = null;
            /// <summary>
            /// 动作类型,
            /// </summary> 
            public PropertyItem AppHandleTag = null;
            /// <summary>
            /// 附属的值,
            /// </summary> 
            public PropertyItem ActionValue = null;
            /// <summary>
            /// 创建时间,
            /// </summary> 
            public PropertyItem CreateTime = null;
        }
        #endregion
    }
}
