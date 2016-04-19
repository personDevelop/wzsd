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
    /// 抢购活动时间段
    /// </summary>  
    [JsonObject]
    public partial class ShopCountDownTime : BaseEntity
    {
        public static Column _ = new Column("ShopCountDownTime");

        public ShopCountDownTime()
        {
            this.TableName = "ShopCountDownTime";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private DateTime _StartDate;

        private DateTime _EndDate;

        private int _WeekOrDay;

        private string _ActivityID;

        private LoopType _LoopType;

        private DateTime? _StaticDate;

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
        ///  开始时间,
        /// </summary>

        [DbProperty(MapingColumnName = "StartDate", DbTypeString = "time", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime StartDate
        {
            get
            {
                return this._StartDate;
            }
            set
            {
                this.OnPropertyChanged("StartDate", this._StartDate, value);
                this._StartDate = value;
            }
        }

        /// <summary>
        ///  结束时间,
        /// </summary>

        [DbProperty(MapingColumnName = "EndDate", DbTypeString = "time", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime EndDate
        {
            get
            {
                return this._EndDate;
            }
            set
            {
                this.OnPropertyChanged("EndDate", this._EndDate, value);
                this._EndDate = value;
            }
        }

        /// <summary>
        ///  周数或天数,每周多天之间用逗号间隔，例如周一,周二
        /// </summary>

        [DbProperty(MapingColumnName = "WeekOrDay", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int WeekOrDay
        {
            get
            {
                return this._WeekOrDay;
            }
            set
            {
                this.OnPropertyChanged("WeekOrDay", this._WeekOrDay, value);
                this._WeekOrDay = value;
            }
        }

        /// <summary>
        ///  活动ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ActivityID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ActivityID
        {
            get
            {
                return this._ActivityID;
            }
            set
            {
                this.OnPropertyChanged("ActivityID", this._ActivityID, value);
                this._ActivityID = value;
            }
        }

        /// <summary>
        ///  轮训类型,
        /// </summary>

        [DbProperty(MapingColumnName = "LoopType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public LoopType LoopType
        {
            get
            {
                return this._LoopType;
            }
            set
            {
                this.OnPropertyChanged("LoopType", this._LoopType, value);
                this._LoopType = value;
            }
        }

        /// <summary>
        ///  固定日期,
        /// </summary>

        [DbProperty(MapingColumnName = "StaticDate", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? StaticDate
        {
            get
            {
                return this._StaticDate;
            }
            set
            {
                this.OnPropertyChanged("StaticDate", this._StaticDate, value);
                this._StaticDate = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                StartDate = new PropertyItem("StartDate", tableName);

                EndDate = new PropertyItem("EndDate", tableName);

                WeekOrDay = new PropertyItem("WeekOrDay", tableName);

                ActivityID = new PropertyItem("ActivityID", tableName);

                LoopType = new PropertyItem("LoopType", tableName);

                StaticDate = new PropertyItem("StaticDate", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 开始时间,
            /// </summary> 
            public PropertyItem StartDate = null;
            /// <summary>
            /// 结束时间,
            /// </summary> 
            public PropertyItem EndDate = null;
            /// <summary>
            /// 周数或天数,每周多天之间用逗号间隔，例如周一,周二
            /// </summary> 
            public PropertyItem WeekOrDay = null;
            /// <summary>
            /// 活动ID,
            /// </summary> 
            public PropertyItem ActivityID = null;
            /// <summary>
            /// 轮训类型,
            /// </summary> 
            public PropertyItem LoopType = null;
            /// <summary>
            /// 固定日期,
            /// </summary> 
            public PropertyItem StaticDate = null;
        }
        #endregion
    }
}
