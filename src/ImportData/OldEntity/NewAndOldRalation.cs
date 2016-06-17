using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportData.OldEntity
{
    /// <summary>
    /// NewAndOldRalation
    /// </summary>  

    /// <summary>
    /// NewAndOldRalation
    /// </summary>  

    public partial class NewAndOldRalation : BaseEntity
    {
        public static Column _ = new Column("NewAndOldRalation");

        public NewAndOldRalation()
        {
            this.TableName = "NewAndOldRalation";
            OnCreate();
        }


        #region 私有变量

        private string _NewID;

        private int _OldID;

        private RalationType _RalationType;

        private string _OtherInfo;

        #endregion

        #region 属性

        /// <summary>
        ///  NewID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "NewID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string NewID
        {
            get
            {
                return this._NewID;
            }
            set
            {
                this.OnPropertyChanged("NewID", this._NewID, value);


                this._NewID = value;
            }
        }

        /// <summary>
        ///  OldID,
        /// </summary>

        [DbProperty(MapingColumnName = "OldID", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int OldID
        {
            get
            {
                return this._OldID;
            }
            set
            {
                this.OnPropertyChanged("OldID", this._OldID, value);


                this._OldID = value;
            }
        }

        /// <summary>
        ///  RalationType,
        /// </summary>

        [DbProperty(MapingColumnName = "RalationType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public RalationType RalationType
        {
            get
            {
                return this._RalationType;
            }
            set
            {
                this.OnPropertyChanged("RalationType", this._RalationType, value);


                this._RalationType = value;
            }
        }

        /// <summary>
        ///  其他辅助,
        /// </summary>

        [DbProperty(MapingColumnName = "OtherInfo", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string OtherInfo
        {
            get
            {
                return this._OtherInfo;
            }
            set
            {
                this.OnPropertyChanged("OtherInfo", this._OtherInfo, value);


                this._OtherInfo = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                NewID = new PropertyItem("NewID", tableName);

                OldID = new PropertyItem("OldID", tableName);

                RalationType = new PropertyItem("RalationType", tableName);

                OtherInfo = new PropertyItem("OtherInfo", tableName);


            }
            /// <summary>
            /// NewID,
            /// </summary> 
            public PropertyItem NewID = null;
            /// <summary>
            /// OldID,
            /// </summary> 
            public PropertyItem OldID = null;
            /// <summary>
            /// RalationType,
            /// </summary> 
            public PropertyItem RalationType = null;
            /// <summary>
            /// 其他辅助,
            /// </summary> 
            public PropertyItem OtherInfo = null;
        }
        #endregion
    }



    public enum RalationType
    {

        会员,
        地址,
        订单,
        商品
    }

}
