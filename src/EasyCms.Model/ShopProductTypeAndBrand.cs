using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyCms.Model
{
    /// <summary>
    /// 商品类型品牌关联表
    /// </summary>  
    public partial class ShopProductTypeAndBrand : BaseEntity
    {
        public static Column _ = new Column("ShopProductTypeAndBrand");

        public ShopProductTypeAndBrand()
        {
            this.TableName = "ShopProductTypeAndBrand";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ProductTypeId;

        private string _BrandId;

        #endregion

        #region 属性

        /// <summary>
        ///  主键ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  商品类型ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductTypeId", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductTypeId
        {
            get
            {
                return this._ProductTypeId;
            }
            set
            {
                this.OnPropertyChanged("ProductTypeId", this._ProductTypeId, value);
                this._ProductTypeId = value;
            }
        }

        /// <summary>
        ///  品牌ID,
        /// </summary>

        [DbProperty(MapingColumnName = "BrandId", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BrandId
        {
            get
            {
                return this._BrandId;
            }
            set
            {
                this.OnPropertyChanged("BrandId", this._BrandId, value);
                this._BrandId = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                ProductTypeId = new PropertyItem("ProductTypeId", tableName);

                BrandId = new PropertyItem("BrandId", tableName);


            }
            /// <summary>
            /// 主键ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 商品类型ID,
            /// </summary> 
            public PropertyItem ProductTypeId = null;
            /// <summary>
            /// 品牌ID,
            /// </summary> 
            public PropertyItem BrandId = null;
        }
        #endregion
    }
}
