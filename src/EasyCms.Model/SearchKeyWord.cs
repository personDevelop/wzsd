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
    /// 搜索关键字
    /// </summary>  
    [JsonObject]
    public partial class SearchKeyWord : BaseEntity
    {
        public static Column _ = new Column("SearchKeyWord");

        public SearchKeyWord()
        {
            this.TableName = "SearchKeyWord";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _SKey;

        private bool _IsHot;

        private int _SearchCount;

        private DateTime? _LastTime;

        private int _OrderNo;

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
        ///  关键字,
        /// </summary>

        [DbProperty(MapingColumnName = "SKey", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SKey
        {
            get
            {
                return this._SKey;
            }
            set
            {
                this.OnPropertyChanged("SKey", this._SKey, value);
                this._SKey = value;
            }
        }

        /// <summary>
        ///  是否热门,
        /// </summary>

        [DbProperty(MapingColumnName = "IsHot", DbTypeString = "bit", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsHot
        {
            get
            {
                return this._IsHot;
            }
            set
            {
                this.OnPropertyChanged("IsHot", this._IsHot, value);
                this._IsHot = value;
            }
        }

        /// <summary>
        ///  搜索次数,
        /// </summary>

        [DbProperty(MapingColumnName = "SearchCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int SearchCount
        {
            get
            {
                return this._SearchCount;
            }
            set
            {
                this.OnPropertyChanged("SearchCount", this._SearchCount, value);
                this._SearchCount = value;
            }
        }

        /// <summary>
        ///  最后搜索时间,
        /// </summary>

        [DbProperty(MapingColumnName = "LastTime", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? LastTime
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

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                SKey = new PropertyItem("SKey", tableName);

                IsHot = new PropertyItem("IsHot", tableName);

                SearchCount = new PropertyItem("SearchCount", tableName);

                LastTime = new PropertyItem("LastTime", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 关键字,
            /// </summary> 
            public PropertyItem SKey = null;
            /// <summary>
            /// 是否热门,
            /// </summary> 
            public PropertyItem IsHot = null;
            /// <summary>
            /// 搜索次数,
            /// </summary> 
            public PropertyItem SearchCount = null;
            /// <summary>
            /// 最后搜索时间,
            /// </summary> 
            public PropertyItem LastTime = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
        }
        #endregion
    }

}
