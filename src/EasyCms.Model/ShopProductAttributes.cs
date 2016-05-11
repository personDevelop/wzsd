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
    /// 商品属性值(是供设置规格时，加载已经勾选的时候用)
    /// </summary>  
    [JsonObject]
    public partial class ShopProductAttributes : BaseEntity
    {
        public static Column _ = new Column("ShopProductAttributes");

        public ShopProductAttributes()
        {
            this.TableName = "ShopProductAttributes";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ProductId;

        private string _AttributeId;

        private string _ValueId;

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
        ///  编号,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductId", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  名称,
        /// </summary>

        [DbProperty(MapingColumnName = "AttributeId", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  对应值ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ValueId", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                ProductId = new PropertyItem("ProductId", tableName);

                AttributeId = new PropertyItem("AttributeId", tableName);

                ValueId = new PropertyItem("ValueId", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 编号,
            /// </summary> 
            public PropertyItem ProductId = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem AttributeId = null;
            /// <summary>
            /// 对应值ID,
            /// </summary> 
            public PropertyItem ValueId = null;
        }
        #endregion
    }

    public partial class ShopProductAttributes
    {
        [NotDbCol]
        public string ValueStr { get; set; }
        [NotDbCol]
        public string AttrName { get; set; }


        [NotDbCol]
        public string FilePath { get; set; }



    }
}
