using Newtonsoft.Json;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model
{
    /// <summary>
    /// 会员等级变更历史
    /// </summary>  
    [JsonObject]
    public partial class AccuountRangeChange : BaseEntity
    {
        public static Column _ = new Column("AccuountRangeChange");

        public AccuountRangeChange()
        {
            this.TableName = "AccuountRangeChange";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _PriRangeID;

        private string _CurrentRangeID;

        private DateTime _ChangeTime;

        private int _ChangeingValue;

        private int _ChangedValue;

        #endregion

        #region 属性

        /// <summary>
        ///  主键,
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
        ///  前一个等级,
        /// </summary>

        [DbProperty(MapingColumnName = "PriRangeID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PriRangeID
        {
            get
            {
                return this._PriRangeID;
            }
            set
            {
                this.OnPropertyChanged("PriRangeID", this._PriRangeID, value);
                this._PriRangeID = value;
            }
        }

        /// <summary>
        ///  变为等级,
        /// </summary>

        [DbProperty(MapingColumnName = "CurrentRangeID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CurrentRangeID
        {
            get
            {
                return this._CurrentRangeID;
            }
            set
            {
                this.OnPropertyChanged("CurrentRangeID", this._CurrentRangeID, value);
                this._CurrentRangeID = value;
            }
        }

        /// <summary>
        ///  变化时间,
        /// </summary>

        [DbProperty(MapingColumnName = "ChangeTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime ChangeTime
        {
            get
            {
                return this._ChangeTime;
            }
            set
            {
                this.OnPropertyChanged("ChangeTime", this._ChangeTime, value);
                this._ChangeTime = value;
            }
        }

        /// <summary>
        ///  变化时的成长值,
        /// </summary>

        [DbProperty(MapingColumnName = "ChangeingValue", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ChangeingValue
        {
            get
            {
                return this._ChangeingValue;
            }
            set
            {
                this.OnPropertyChanged("ChangeingValue", this._ChangeingValue, value);
                this._ChangeingValue = value;
            }
        }

        /// <summary>
        ///  变化后的成长值,
        /// </summary>

        [DbProperty(MapingColumnName = "ChangedValue", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ChangedValue
        {
            get
            {
                return this._ChangedValue;
            }
            set
            {
                this.OnPropertyChanged("ChangedValue", this._ChangedValue, value);
                this._ChangedValue = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                PriRangeID = new PropertyItem("PriRangeID", tableName);

                CurrentRangeID = new PropertyItem("CurrentRangeID", tableName);

                ChangeTime = new PropertyItem("ChangeTime", tableName);

                ChangeingValue = new PropertyItem("ChangeingValue", tableName);

                ChangedValue = new PropertyItem("ChangedValue", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 前一个等级,
            /// </summary> 
            public PropertyItem PriRangeID = null;
            /// <summary>
            /// 变为等级,
            /// </summary> 
            public PropertyItem CurrentRangeID = null;
            /// <summary>
            /// 变化时间,
            /// </summary> 
            public PropertyItem ChangeTime = null;
            /// <summary>
            /// 变化时的成长值,
            /// </summary> 
            public PropertyItem ChangeingValue = null;
            /// <summary>
            /// 变化后的成长值,
            /// </summary> 
            public PropertyItem ChangedValue = null;
        }
        #endregion
    }


}
