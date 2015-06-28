using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyCms.Model
{
    /// <summary>
    /// 商品库存量关系
    /// </summary>  
    [JsonObject]
    public partial class ShopProducntSKURelation : BaseEntity
    {
        public static Column _ = new Column("ShopProducntSKURelation");

        public ShopProducntSKURelation()
        {
            this.TableName = "ShopProducntSKURelation";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _SKUID;

        private string _Name;

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
        ///  商品库存量单位ID,
        /// </summary>

        [DbProperty(MapingColumnName = "SKUID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  产品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnPropertyChanged("Name", this._Name, value);
                this._Name = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                SKUID = new PropertyItem("SKUID", tableName);

                Name = new PropertyItem("Name", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 商品库存量单位ID,
            /// </summary> 
            public PropertyItem SKUID = null;
            /// <summary>
            /// 产品ID,
            /// </summary> 
            public PropertyItem Name = null;
        }
        #endregion
    }
}
