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
    /// 抢购商品
    /// </summary>  
    [JsonObject]
    public partial class ShopCountProducnt : BaseEntity
    {
        public static Column _ = new Column("ShopCountProducnt");

        public ShopCountProducnt()
        {
            this.TableName = "ShopCountProducnt";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ProductId;

        private string _SKUID;

     

        private decimal _OldPrice;

        private decimal _Price;

        private string _ActivityID;

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
        ///  名称,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductId
        {
            get
            {
                return this._ProductId;
            }
            set
            {
                this.OnPropertyChanged("ProductId", this._ProductId, value);
                this._ProductId = value;
            }
        }

        /// <summary>
        ///  商品SKU,
        /// </summary>

        [DbProperty(MapingColumnName = "SKUID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SKUID
        {
            get
            {
                return this._SKUID;
            }
            set
            {
                this.OnPropertyChanged("SKUID", this._SKUID, value);
                this._SKUID = value;
            }
        }

       

        /// <summary>
        ///  原价格,
        /// </summary>

        [DbProperty(MapingColumnName = "OldPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal OldPrice
        {
            get
            {
                return this._OldPrice;
            }
            set
            {
                this.OnPropertyChanged("OldPrice", this._OldPrice, value);
                this._OldPrice = value;
            }
        }

        /// <summary>
        ///  活动价格,
        /// </summary>

        [DbProperty(MapingColumnName = "Price", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Price
        {
            get
            {
                return this._Price;
            }
            set
            {
                this.OnPropertyChanged("Price", this._Price, value);
                this._Price = value;
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

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                ProductId = new PropertyItem("ProductId", tableName);

                SKUID = new PropertyItem("SKUID", tableName);

               

                OldPrice = new PropertyItem("OldPrice", tableName);

                Price = new PropertyItem("Price", tableName);

                ActivityID = new PropertyItem("ActivityID", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem ProductId = null;
            /// <summary>
            /// 商品SKU,
            /// </summary> 
            public PropertyItem SKUID = null;
         
            /// <summary>
            /// 原价格,
            /// </summary> 
            public PropertyItem OldPrice = null;
            /// <summary>
            /// 活动价格,
            /// </summary> 
            public PropertyItem Price = null;
            /// <summary>
            /// 活动ID,
            /// </summary> 
            public PropertyItem ActivityID = null;
        }
        #endregion
    }

    public partial class ShopCountProducnt
    { /// <summary>
      ///  商品名称,
      /// </summary>

        [NotDbCol]
        public string ProductName
        {
            get ; 
            set ; 
        }

        [NotDbCol]
        public string SKUCode
        {
            get;
            set;
        }
    }
}
