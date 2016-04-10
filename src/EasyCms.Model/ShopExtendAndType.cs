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
    /// 商品类型和规格属性关联表
    /// </summary>  
    [JsonObject]
    public partial class ShopExtendAndType : BaseEntity
    {
        public static Column _ = new Column("ShopExtendAndType");

        public ShopExtendAndType()
        {
            this.TableName = "ShopExtendAndType";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _TypeID;

        private string _ExtendID;

        private int _OrderNo;

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
        ///  类型ID,
        /// </summary>

        [DbProperty(MapingColumnName = "TypeID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this.OnPropertyChanged("TypeID", this._TypeID, value);
                this._TypeID = value;
            }
        }

        /// <summary>
        ///  规格ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ExtendID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ExtendID
        {
            get
            {
                return this._ExtendID;
            }
            set
            {
                this.OnPropertyChanged("ExtendID", this._ExtendID, value);
                this._ExtendID = value;
            }
        }

        /// <summary>
        ///  顺序,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderNo", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                TypeID = new PropertyItem("TypeID", tableName);

                ExtendID = new PropertyItem("ExtendID", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 类型ID,
            /// </summary> 
            public PropertyItem TypeID = null;
            /// <summary>
            /// 规格ID,
            /// </summary> 
            public PropertyItem ExtendID = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
        }
        #endregion
    }
}
