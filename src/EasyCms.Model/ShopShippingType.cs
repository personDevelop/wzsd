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

        private string _ID;

        private string _Name;

        private PayType _PayType;

        private decimal _Weight;

        private decimal _AddWeight;

        private decimal _Price;

        private decimal _AddPrice;

        private FreightType _FreightType;

        private bool _IsDefaultFreight;

        private bool _IsCusotmPayType;

        private int _DisplaySequence;

        private string _SupplierId;

        private string _Description;

        #endregion

        #region 属性

        /// <summary>
        ///  主键ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 1, ColumnDefaultValue = "")]

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
        ///  付款类型,货到付款选择货到付款后顾客无需再选择支付方式
        /// </summary>

        [DbProperty(MapingColumnName = "PayType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public PayType PayType
        {
            get
            {
                return this._PayType;
            }
            set
            {
                this.OnPropertyChanged("PayType", this._PayType, value);
                this._PayType = value;
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
        ///  加价重量,根据重量来计算运费，当物品不足《首重重量》时，按照《首重费用》计算，超过部分按照《续重重量》和《续重费用》乘积来计算
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
        ///  地区运费类型,《统一地区运费》：全部的地区都使用默认的《重量设置》中的计费方式。《指定地区运费》：单独指定部分地区的运费 
        /// </summary>

        [DbProperty(MapingColumnName = "FreightType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public FreightType FreightType
        {
            get
            {
                return this._FreightType;
            }
            set
            {
                this.OnPropertyChanged("FreightType", this._FreightType, value);
                this._FreightType = value;
            }
        }

        /// <summary>
        ///  地区默认运费 ,注意：如果不开启此项，那么未设置的地区将无法送达！
        /// </summary>

        [DbProperty(MapingColumnName = "IsDefaultFreight", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsDefaultFreight
        {
            get
            {
                return this._IsDefaultFreight;
            }
            set
            {
                this.OnPropertyChanged("IsDefaultFreight", this._IsDefaultFreight, value);
                this._IsDefaultFreight = value;
            }
        }

        /// <summary>
        ///  是否指定支付方式,
        /// </summary>

        [DbProperty(MapingColumnName = "IsCusotmPayType", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsCusotmPayType
        {
            get
            {
                return this._IsCusotmPayType;
            }
            set
            {
                this.OnPropertyChanged("IsCusotmPayType", this._IsCusotmPayType, value);
                this._IsCusotmPayType = value;
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

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                Name = new PropertyItem("Name", tableName);

                PayType = new PropertyItem("PayType", tableName);

                Weight = new PropertyItem("Weight", tableName);

                AddWeight = new PropertyItem("AddWeight", tableName);

                Price = new PropertyItem("Price", tableName);

                AddPrice = new PropertyItem("AddPrice", tableName);

                FreightType = new PropertyItem("FreightType", tableName);

                IsDefaultFreight = new PropertyItem("IsDefaultFreight", tableName);

                IsCusotmPayType = new PropertyItem("IsCusotmPayType", tableName);

                DisplaySequence = new PropertyItem("DisplaySequence", tableName);

                SupplierId = new PropertyItem("SupplierId", tableName);

                Description = new PropertyItem("Description", tableName);


            }
            /// <summary>
            /// 主键ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 付款类型,货到付款选择货到付款后顾客无需再选择支付方式
            /// </summary> 
            public PropertyItem PayType = null;
            /// <summary>
            /// 起步重量,
            /// </summary> 
            public PropertyItem Weight = null;
            /// <summary>
            /// 加价重量,根据重量来计算运费，当物品不足《首重重量》时，按照《首重费用》计算，超过部分按照《续重重量》和《续重费用》乘积来计算
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
            /// 地区运费类型,《统一地区运费》：全部的地区都使用默认的《重量设置》中的计费方式。《指定地区运费》：单独指定部分地区的运费 
            /// </summary> 
            public PropertyItem FreightType = null;
            /// <summary>
            /// 地区默认运费 ,注意：如果不开启此项，那么未设置的地区将无法送达！
            /// </summary> 
            public PropertyItem IsDefaultFreight = null;
            /// <summary>
            /// 是否指定支付方式,
            /// </summary> 
            public PropertyItem IsCusotmPayType = null;
            /// <summary>
            /// 显示顺序,
            /// </summary> 
            public PropertyItem DisplaySequence = null;
            /// <summary>
            /// 关联商家,
            /// </summary> 
            public PropertyItem SupplierId = null;
            /// <summary>
            /// 描述,
            /// </summary> 
            public PropertyItem Description = null;
        }
        #endregion
    }
}
