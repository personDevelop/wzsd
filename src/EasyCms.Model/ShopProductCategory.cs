using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyCms.Model
{
    /// <summary>
    /// 商品分类关联表
    /// </summary>  
    [JsonObject]
    public partial class ShopProductCategory : BaseEntity
    {
        public static Column _ = new Column("ShopProductCategory");

        public ShopProductCategory()
        {
            this.TableName = "ShopProductCategory";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _CategoryID;

        private string _ProductID;

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
        ///  商品分类ID,
        /// </summary>

        [DbProperty(MapingColumnName = "CategoryID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CategoryID
        {
            get
            {
                return this._CategoryID;
            }
            set
            {
                this.OnPropertyChanged("CategoryID", this._CategoryID, value);
                this._CategoryID = value;
            }
        }

        /// <summary>
        ///  商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                CategoryID = new PropertyItem("CategoryID", tableName);

                ProductID = new PropertyItem("ProductID", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 商品分类ID,
            /// </summary> 
            public PropertyItem CategoryID = null;
            /// <summary>
            /// 商品ID,
            /// </summary> 
            public PropertyItem ProductID = null;
        }
        #endregion
    }
}
