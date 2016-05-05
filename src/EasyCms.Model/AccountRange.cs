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
    /// 会员等级
    /// </summary>  
    [JsonObject]
    public partial class AccountRange : BaseEntity
    {
        public static Column _ = new Column("AccountRange");

        public AccountRange()
        {
            this.TableName = "AccountRange";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _AccountID;

        private string _RangeID;

        private DateTime _GetRangeTime;

        private int _GrowthValue;

        private decimal _JF;

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
        ///  账户ID,
        /// </summary>

        [DbProperty(MapingColumnName = "AccountID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string AccountID
        {
            get
            {
                return this._AccountID;
            }
            set
            {
                this.OnPropertyChanged("AccountID", this._AccountID, value);
                this._AccountID = value;
            }
        }

        /// <summary>
        ///  等级ID,
        /// </summary>

        [DbProperty(MapingColumnName = "RangeID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RangeID
        {
            get
            {
                return this._RangeID;
            }
            set
            {
                this.OnPropertyChanged("RangeID", this._RangeID, value);
                this._RangeID = value;
            }
        }

        /// <summary>
        ///  获得时间,
        /// </summary>

        [DbProperty(MapingColumnName = "GetRangeTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime GetRangeTime
        {
            get
            {
                return this._GetRangeTime;
            }
            set
            {
                this.OnPropertyChanged("GetRangeTime", this._GetRangeTime, value);
                this._GetRangeTime = value;
            }
        }

        /// <summary>
        ///  当前成长值,系统根据等级期限自动减少
        /// </summary>

        [DbProperty(MapingColumnName = "GrowthValue", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int GrowthValue
        {
            get
            {
                return this._GrowthValue;
            }
            set
            {
                this.OnPropertyChanged("GrowthValue", this._GrowthValue, value);
                this._GrowthValue = value;
            }
        }

        /// <summary>
        ///  会员积分,主动兑换或其他活动时才会减少
        /// </summary>

        [DbProperty(MapingColumnName = "JF", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal JF
        {
            get
            {
                return this._JF;
            }
            set
            {
                this.OnPropertyChanged("JF", this._JF, value);
                this._JF = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                AccountID = new PropertyItem("AccountID", tableName);

                RangeID = new PropertyItem("RangeID", tableName);

                GetRangeTime = new PropertyItem("GetRangeTime", tableName);

                GrowthValue = new PropertyItem("GrowthValue", tableName);

                JF = new PropertyItem("JF", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 账户ID,
            /// </summary> 
            public PropertyItem AccountID = null;
            /// <summary>
            /// 等级ID,
            /// </summary> 
            public PropertyItem RangeID = null;
            /// <summary>
            /// 获得时间,
            /// </summary> 
            public PropertyItem GetRangeTime = null;
            /// <summary>
            /// 当前成长值,系统根据等级期限自动减少
            /// </summary> 
            public PropertyItem GrowthValue = null;
            /// <summary>
            /// 会员积分,主动兑换或其他活动时才会减少
            /// </summary> 
            public PropertyItem JF = null;
        }
        #endregion
    }

    public partial class AccountRange
    {
        [NotDbCol]
        public RangeDict RangDict { get; set; }
    }
}
