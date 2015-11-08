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
    /// token信息
    /// </summary>  
    [JsonObject]
    public partial class TokenInfo : BaseEntity
    {
        public static Column _ = new Column("TokenInfo");

        public TokenInfo()
        {
            this.TableName = "TokenInfo";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private DateTime _CreateTime;

        private DateTime _LastTime;

        private int _Duration;

        private DateTime _OutTime;

        private string _UserID;

        private string _DeviceID;

        #endregion

        #region 属性

        /// <summary>
        ///  主键Token,
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
        ///  创建时间,
        /// </summary>

        [DbProperty(MapingColumnName = "CreateTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        /// <summary>
        ///  最后更新时间,
        /// </summary>

        [DbProperty(MapingColumnName = "LastTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime LastTime
        {
            get
            {
                return this._LastTime;
            }
            set
            {
                this.OnPropertyChanged("LastTime", this._LastTime, value);
                this._LastTime = value;
            }
        }

        /// <summary>
        ///  持续时间（秒）,
        /// </summary>

        [DbProperty(MapingColumnName = "Duration", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Duration
        {
            get
            {
                return this._Duration;
            }
            set
            {
                this.OnPropertyChanged("Duration", this._Duration, value);
                this._Duration = value;
            }
        }

        /// <summary>
        ///  预计过期时间,
        /// </summary>

        [DbProperty(MapingColumnName = "OutTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime OutTime
        {
            get
            {
                return this._OutTime;
            }
            set
            {
                this.OnPropertyChanged("OutTime", this._OutTime, value);
                this._OutTime = value;
            }
        }

        /// <summary>
        ///  用户ID,
        /// </summary>

        [DbProperty(MapingColumnName = "UserID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                this.OnPropertyChanged("UserID", this._UserID, value);
                this._UserID = value;
            }
        }

        /// <summary>
        ///  设备ID,
        /// </summary>

        [DbProperty(MapingColumnName = "DeviceID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string DeviceID
        {
            get
            {
                return this._DeviceID;
            }
            set
            {
                this.OnPropertyChanged("DeviceID", this._DeviceID, value);
                this._DeviceID = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                CreateTime = new PropertyItem("CreateTime", tableName);

                LastTime = new PropertyItem("LastTime", tableName);

                Duration = new PropertyItem("Duration", tableName);

                OutTime = new PropertyItem("OutTime", tableName);

                UserID = new PropertyItem("UserID", tableName);

                DeviceID = new PropertyItem("DeviceID", tableName);


            }
            /// <summary>
            /// 主键Token,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 创建时间,
            /// </summary> 
            public PropertyItem CreateTime = null;
            /// <summary>
            /// 最后更新时间,
            /// </summary> 
            public PropertyItem LastTime = null;
            /// <summary>
            /// 持续时间（秒）,
            /// </summary> 
            public PropertyItem Duration = null;
            /// <summary>
            /// 预计过期时间,
            /// </summary> 
            public PropertyItem OutTime = null;
            /// <summary>
            /// 用户ID,
            /// </summary> 
            public PropertyItem UserID = null;
            /// <summary>
            /// 设备ID,
            /// </summary> 
            public PropertyItem DeviceID = null;
        }
        #endregion
    }
}
