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
    /// 关联商品
    /// </summary>  
    [JsonObject]
    public partial class ShopRalationProduct : BaseEntity
    {
        public static Column _ = new Column("ShopRalationProduct");

        public ShopRalationProduct()
        {
            this.TableName = "ShopRalationProduct";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ProductID;

        private string _RlationProductID;

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
        ///  商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  关联商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "RlationProductID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RlationProductID
        {
            get
            {
                return this._RlationProductID;
            }
            set
            {
                this.OnPropertyChanged("RlationProductID", this._RlationProductID, value);
                this._RlationProductID = value;
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

                RlationProductID = new PropertyItem("RlationProductID", tableName);


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
            /// 关联商品ID,
            /// </summary> 
            public PropertyItem RlationProductID = null;
        }
        #endregion
    }
}
