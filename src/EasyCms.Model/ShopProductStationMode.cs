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
    /// 商品位置设置
    /// </summary>  
    [JsonObject]
    public partial class ShopProductStationMode : BaseEntity
    {
        public static Column _ = new Column("ShopProductStationMode");

        public ShopProductStationMode()
        {
            this.TableName = "ShopProductStationMode";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ProductID;

        private int _OrderNo;

        private int _StationMode;

        private string _StationModeName;

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
        ///  商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this.OnPropertyChanged("ProductID", this._ProductID, value);
                this._ProductID = value;
            }
        }

        /// <summary>
        ///  顺序,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderNo", DbTypeString = "int", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        /// <summary>
        ///  位置类型,首页，需要推荐的商品，需要热卖的商品 需要特价的商品 最新商品推荐等等
        /// </summary>

        [DbProperty(MapingColumnName = "StationMode", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int StationMode
        {
            get
            {
                return this._StationMode;
            }
            set
            {
                this.OnPropertyChanged("StationMode", this._StationMode, value);
                this._StationMode = value;
            }
        }

        /// <summary>
        ///  位置类型名称,
        /// </summary>

        [DbProperty(MapingColumnName = "StationModeName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string StationModeName
        {
            get
            {
                return this._StationModeName;
            }
            set
            {
                this.OnPropertyChanged("StationModeName", this._StationModeName, value);
                this._StationModeName = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                ProductID = new PropertyItem("ProductID", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);

                StationMode = new PropertyItem("StationMode", tableName);

                StationModeName = new PropertyItem("StationModeName", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 商品ID,
            /// </summary> 
            public PropertyItem ProductID = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
            /// <summary>
            /// 位置类型,首页，需要推荐的商品，需要热卖的商品 需要特价的商品 最新商品推荐等等
            /// </summary> 
            public PropertyItem StationMode = null;
            /// <summary>
            /// 位置类型名称,
            /// </summary> 
            public PropertyItem StationModeName = null;
        }
        #endregion
    }

}
