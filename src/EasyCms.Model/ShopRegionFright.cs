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
    /// 地区运费
    /// </summary>  
    [JsonObject]
    public partial class ShopRegionFright : BaseEntity
    {
        public static Column _ = new Column("ShopRegionFright");

        public ShopRegionFright()
        {
            this.TableName = "ShopRegionFright";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ShippingModeId;

        private int _RegionID;

        private decimal _RegionPrice;

        private decimal _RegionAddPrice;

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
        ///  配送方式ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ShippingModeId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShippingModeId
        {
            get
            {
                return this._ShippingModeId;
            }
            set
            {
                this.OnPropertyChanged("ShippingModeId", this._ShippingModeId, value);
                this._ShippingModeId = value;
            }
        }

        /// <summary>
        ///  地区ID,
        /// </summary>

        [DbProperty(MapingColumnName = "RegionID", DbTypeString = "int", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int RegionID
        {
            get
            {
                return this._RegionID;
            }
            set
            {
                this.OnPropertyChanged("RegionID", this._RegionID, value);
                this._RegionID = value;
            }
        }

        /// <summary>
        ///  起重费用,
        /// </summary>

        [DbProperty(MapingColumnName = "RegionPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal RegionPrice
        {
            get
            {
                return this._RegionPrice;
            }
            set
            {
                this.OnPropertyChanged("RegionPrice", this._RegionPrice, value);
                this._RegionPrice = value;
            }
        }

        /// <summary>
        ///  超重费用,
        /// </summary>

        [DbProperty(MapingColumnName = "RegionAddPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal RegionAddPrice
        {
            get
            {
                return this._RegionAddPrice;
            }
            set
            {
                this.OnPropertyChanged("RegionAddPrice", this._RegionAddPrice, value);
                this._RegionAddPrice = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                ShippingModeId = new PropertyItem("ShippingModeId", tableName);

                RegionID = new PropertyItem("RegionID", tableName);

                RegionPrice = new PropertyItem("RegionPrice", tableName);

                RegionAddPrice = new PropertyItem("RegionAddPrice", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 配送方式ID,
            /// </summary> 
            public PropertyItem ShippingModeId = null;
            /// <summary>
            /// 地区ID,
            /// </summary> 
            public PropertyItem RegionID = null;
            /// <summary>
            /// 起重费用,
            /// </summary> 
            public PropertyItem RegionPrice = null;
            /// <summary>
            /// 超重费用,
            /// </summary> 
            public PropertyItem RegionAddPrice = null;
        }
        #endregion
    }
}
