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
    /// 配送方式与物流公司关联表
    /// </summary>  
    [JsonObject]
    public partial class ShopShipExpress : BaseEntity
    {
        public static Column _ = new Column("ShopShipExpress");

        public ShopShipExpress()
        {
            this.TableName = "ShopShipExpress";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ShippingModeId;

        private string _ExpressID;

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
        ///  物流公司ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ExpressID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ExpressID
        {
            get
            {
                return this._ExpressID;
            }
            set
            {
                this.OnPropertyChanged("ExpressID", this._ExpressID, value);
                this._ExpressID = value;
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

                ExpressID = new PropertyItem("ExpressID", tableName);


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
            /// 物流公司ID,
            /// </summary> 
            public PropertyItem ExpressID = null;
        }
        #endregion
    }
}
