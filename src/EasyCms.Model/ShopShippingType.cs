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
    /// 配送方式
    /// </summary>  
    [JsonObject]
    public partial class ShopShippingType : BaseEntity
    {
        public static Column _ = new Column("ShopShippingType");

        public ShopShippingType()
        {
            this.TableName = "ShopShippingType";
            OnCreate();
        }


        #region 私有变量

        private string _ModeId;

        private string _Name;

        private decimal _Weight;

        private decimal _AddWeight;

        private decimal _Price;

        private decimal _AddPrice;

        private string _Description;

        private int _DisplaySequence;

        private string _ExpressID;

        private string _SupplierId;

        #endregion

        #region 属性

        /// <summary>
        ///  主键,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ModeId", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = true, StepSize = 1, ColumnDefaultValue = "")]

        public string ModeId
        {
            get
            {
                return this._ModeId;
            }
            set
            {
                this.OnPropertyChanged("ModeId", this._ModeId, value);
                this._ModeId = value;
            }
        }

        /// <summary>
        ///  名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        /// <summary>
        ///  起步重量,
        /// </summary>

        [DbProperty(MapingColumnName = "Weight", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Weight
        {
            get
            {
                return this._Weight;
            }
            set
            {
                this.OnPropertyChanged("Weight", this._Weight, value);
                this._Weight = value;
            }
        }

        /// <summary>
        ///  加价重量,
        /// </summary>

        [DbProperty(MapingColumnName = "AddWeight", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal AddWeight
        {
            get
            {
                return this._AddWeight;
            }
            set
            {
                this.OnPropertyChanged("AddWeight", this._AddWeight, value);
                this._AddWeight = value;
            }
        }

        /// <summary>
        ///  起步价,
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
        ///  加价,
        /// </summary>

        [DbProperty(MapingColumnName = "AddPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal AddPrice
        {
            get
            {
                return this._AddPrice;
            }
            set
            {
                this.OnPropertyChanged("AddPrice", this._AddPrice, value);
                this._AddPrice = value;
            }
        }

        /// <summary>
        ///  描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 4000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this.OnPropertyChanged("Description", this._Description, value);
                this._Description = value;
            }
        }

        /// <summary>
        ///  显示顺序,
        /// </summary>

        [DbProperty(MapingColumnName = "DisplaySequence", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int DisplaySequence
        {
            get
            {
                return this._DisplaySequence;
            }
            set
            {
                this.OnPropertyChanged("DisplaySequence", this._DisplaySequence, value);
                this._DisplaySequence = value;
            }
        }

        /// <summary>
        ///  物流公司ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ExpressID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        /// <summary>
        ///  关联商家,
        /// </summary>

        [DbProperty(MapingColumnName = "SupplierId", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((-1))")]

        public string SupplierId
        {
            get
            {
                return this._SupplierId;
            }
            set
            {
                this.OnPropertyChanged("SupplierId", this._SupplierId, value);
                this._SupplierId = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ModeId = new PropertyItem("ModeId", tableName);

                Name = new PropertyItem("Name", tableName);

                Weight = new PropertyItem("Weight", tableName);

                AddWeight = new PropertyItem("AddWeight", tableName);

                Price = new PropertyItem("Price", tableName);

                AddPrice = new PropertyItem("AddPrice", tableName);

                Description = new PropertyItem("Description", tableName);

                DisplaySequence = new PropertyItem("DisplaySequence", tableName);

                ExpressID = new PropertyItem("ExpressID", tableName);

                SupplierId = new PropertyItem("SupplierId", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ModeId = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 起步重量,
            /// </summary> 
            public PropertyItem Weight = null;
            /// <summary>
            /// 加价重量,
            /// </summary> 
            public PropertyItem AddWeight = null;
            /// <summary>
            /// 起步价,
            /// </summary> 
            public PropertyItem Price = null;
            /// <summary>
            /// 加价,
            /// </summary> 
            public PropertyItem AddPrice = null;
            /// <summary>
            /// 描述,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 显示顺序,
            /// </summary> 
            public PropertyItem DisplaySequence = null;
            /// <summary>
            /// 物流公司ID,
            /// </summary> 
            public PropertyItem ExpressID = null;
            /// <summary>
            /// 关联商家,
            /// </summary> 
            public PropertyItem SupplierId = null;
        }
        #endregion
    }
}
