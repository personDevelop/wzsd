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
    /// 在线客服
    /// </summary>  
    [JsonObject]
    public partial class OnLineUser : BaseEntity
    {
        public static Column _ = new Column("OnLineUser");

        public OnLineUser()
        {
            this.TableName = "OnLineUser";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _KfType;

        private string _Name;

        private string _KfQQ;

        private string _KFNumber;

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
        ///  客服类型,
        /// </summary>

        [DbProperty(MapingColumnName = "KfType", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string KfType
        {
            get
            {
                return this._KfType;
            }
            set
            {
                this.OnPropertyChanged("KfType", this._KfType, value);
                this._KfType = value;
            }
        }

        /// <summary>
        ///  客服名称,
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
        ///  客服qq号,
        /// </summary>

        [DbProperty(MapingColumnName = "KfQQ", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string KfQQ
        {
            get
            {
                return this._KfQQ;
            }
            set
            {
                this.OnPropertyChanged("KfQQ", this._KfQQ, value);
                this._KfQQ = value;
            }
        }

        /// <summary>
        ///  客服其他工作号,
        /// </summary>

        [DbProperty(MapingColumnName = "KFNumber", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string KFNumber
        {
            get
            {
                return this._KFNumber;
            }
            set
            {
                this.OnPropertyChanged("KFNumber", this._KFNumber, value);
                this._KFNumber = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                KfType = new PropertyItem("KfType", tableName);

                Name = new PropertyItem("Name", tableName);

                KfQQ = new PropertyItem("KfQQ", tableName);

                KFNumber = new PropertyItem("KFNumber", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 客服类型,
            /// </summary> 
            public PropertyItem KfType = null;
            /// <summary>
            /// 客服名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 客服qq号,
            /// </summary> 
            public PropertyItem KfQQ = null;
            /// <summary>
            /// 客服其他工作号,
            /// </summary> 
            public PropertyItem KFNumber = null;
        }
        #endregion
    }
}
