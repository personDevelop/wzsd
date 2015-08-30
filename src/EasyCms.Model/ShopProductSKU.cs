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
    /// 商品库存量单位
    /// </summary>  
    [JsonObject]
    public partial class ShopProductSKU : BaseEntity
    {
        public static Column _ = new Column("ShopProductSKU");

        public ShopProductSKU()
        {
            this.TableName = "ShopProductSKU";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _AttributeId;

        private string _ValueId;

        private string _ImageID;

        private string _ValueStr;

        private string _ProductId;

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
        ///  规格ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "AttributeId", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string AttributeId
        {
            get
            {
                return this._AttributeId;
            }
            set
            {
                this.OnPropertyChanged("AttributeId", this._AttributeId, value);
                this._AttributeId = value;
            }
        }

        /// <summary>
        ///  规则值ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ValueId", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ValueId
        {
            get
            {
                return this._ValueId;
            }
            set
            {
                this.OnPropertyChanged("ValueId", this._ValueId, value);
                this._ValueId = value;
            }
        }

        /// <summary>
        ///  图片ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ImageID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ImageID
        {
            get
            {
                return this._ImageID;
            }
            set
            {
                this.OnPropertyChanged("ImageID", this._ImageID, value);
                this._ImageID = value;
            }
        }

        /// <summary>
        ///  值信息,
        /// </summary>

        [DbProperty(MapingColumnName = "ValueStr", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ValueStr
        {
            get
            {
                return this._ValueStr;
            }
            set
            {
                this.OnPropertyChanged("ValueStr", this._ValueStr, value);
                this._ValueStr = value;
            }
        }

        /// <summary>
        ///  商品ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ProductId", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                AttributeId = new PropertyItem("AttributeId", tableName);

                ValueId = new PropertyItem("ValueId", tableName);

                ImageID = new PropertyItem("ImageID", tableName);

                ValueStr = new PropertyItem("ValueStr", tableName);

                ProductId = new PropertyItem("ProductId", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 规格ID,
            /// </summary> 
            public PropertyItem AttributeId = null;
            /// <summary>
            /// 规则值ID,
            /// </summary> 
            public PropertyItem ValueId = null;
            /// <summary>
            /// 图片ID,
            /// </summary> 
            public PropertyItem ImageID = null;
            /// <summary>
            /// 值信息,
            /// </summary> 
            public PropertyItem ValueStr = null;
            /// <summary>
            /// 商品ID,
            /// </summary> 
            public PropertyItem ProductId = null;
        }
        #endregion
    }
    
}
