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
    /// 支付方式
    /// </summary>  
    [JsonObject]
    public partial class ShopPaymentTypes : BaseEntity
    {
        public static Column _ = new Column("ShopPaymentTypes");

        public ShopPaymentTypes()
        {
            this.TableName = "ShopPaymentTypes";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Name;

        private string _DrivePath;

        private string _Gateway;

        private string _MerchantCode;

        private string _EmailAddress;

        private string _SecretKey;

        private string _SecondKey;

        private string _Password;

        private string _Partner;

        private bool _IsEnable;

        private int _DisplaySequence;

        private decimal _Charge;

        private bool _IsPercent;

        private bool _AllowRecharge;

        private string _Logo;

        private string _Description;

        #endregion

        #region 属性

        /// <summary>
        ///  主键ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = true, StepSize = 1, ColumnDefaultValue = "")]

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
        ///  接口类型,1是支持电脑,2是支持手机，多个值之间用|隔开
        /// </summary>

        [DbProperty(MapingColumnName = "DrivePath", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(N'|1|')")]

        public string DrivePath
        {
            get
            {
                return this._DrivePath;
            }
            set
            {
                this.OnPropertyChanged("DrivePath", this._DrivePath, value);
                this._DrivePath = value;
            }
        }

        /// <summary>
        ///  支付接口编号,
        /// </summary>

        [DbProperty(MapingColumnName = "Gateway", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 400, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Gateway
        {
            get
            {
                return this._Gateway;
            }
            set
            {
                this.OnPropertyChanged("Gateway", this._Gateway, value);
                this._Gateway = value;
            }
        }

        /// <summary>
        ///  商户号,
        /// </summary>

        [DbProperty(MapingColumnName = "MerchantCode", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 600, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string MerchantCode
        {
            get
            {
                return this._MerchantCode;
            }
            set
            {
                this.OnPropertyChanged("MerchantCode", this._MerchantCode, value);
                this._MerchantCode = value;
            }
        }

        /// <summary>
        ///  商户邮箱,
        /// </summary>

        [DbProperty(MapingColumnName = "EmailAddress", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 510, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string EmailAddress
        {
            get
            {
                return this._EmailAddress;
            }
            set
            {
                this.OnPropertyChanged("EmailAddress", this._EmailAddress, value);
                this._EmailAddress = value;
            }
        }

        /// <summary>
        ///  商户密钥,
        /// </summary>

        [DbProperty(MapingColumnName = "SecretKey", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 4000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SecretKey
        {
            get
            {
                return this._SecretKey;
            }
            set
            {
                this.OnPropertyChanged("SecretKey", this._SecretKey, value);
                this._SecretKey = value;
            }
        }

        /// <summary>
        ///  第二密钥,
        /// </summary>

        [DbProperty(MapingColumnName = "SecondKey", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 4000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SecondKey
        {
            get
            {
                return this._SecondKey;
            }
            set
            {
                this.OnPropertyChanged("SecondKey", this._SecondKey, value);
                this._SecondKey = value;
            }
        }

        /// <summary>
        ///  密码,
        /// </summary>

        [DbProperty(MapingColumnName = "Password", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 4000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this.OnPropertyChanged("Password", this._Password, value);
                this._Password = value;
            }
        }

        /// <summary>
        ///  合作伙伴,
        /// </summary>

        [DbProperty(MapingColumnName = "Partner", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 600, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Partner
        {
            get
            {
                return this._Partner;
            }
            set
            {
                this.OnPropertyChanged("Partner", this._Partner, value);
                this._Partner = value;
            }
        }

        /// <summary>
        ///  启用,
        /// </summary>

        [DbProperty(MapingColumnName = "IsEnable", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsEnable
        {
            get
            {
                return this._IsEnable;
            }
            set
            {
                this.OnPropertyChanged("IsEnable", this._IsEnable, value);
                this._IsEnable = value;
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
        ///  手续费,
        /// </summary>

        [DbProperty(MapingColumnName = "Charge", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Charge
        {
            get
            {
                return this._Charge;
            }
            set
            {
                this.OnPropertyChanged("Charge", this._Charge, value);
                this._Charge = value;
            }
        }

        /// <summary>
        ///  是否按百分比收费,
        /// </summary>

        [DbProperty(MapingColumnName = "IsPercent", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsPercent
        {
            get
            {
                return this._IsPercent;
            }
            set
            {
                this.OnPropertyChanged("IsPercent", this._IsPercent, value);
                this._IsPercent = value;
            }
        }

        /// <summary>
        ///  是否支持在线充值 ,
        /// </summary>

        [DbProperty(MapingColumnName = "AllowRecharge", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool AllowRecharge
        {
            get
            {
                return this._AllowRecharge;
            }
            set
            {
                this.OnPropertyChanged("AllowRecharge", this._AllowRecharge, value);
                this._AllowRecharge = value;
            }
        }

        /// <summary>
        ///  支付logo,
        /// </summary>

        [DbProperty(MapingColumnName = "Logo", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 510, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Logo
        {
            get
            {
                return this._Logo;
            }
            set
            {
                this.OnPropertyChanged("Logo", this._Logo, value);
                this._Logo = value;
            }
        }

        /// <summary>
        ///  描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "text", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

                DrivePath = new PropertyItem("DrivePath", tableName);

                Gateway = new PropertyItem("Gateway", tableName);

                MerchantCode = new PropertyItem("MerchantCode", tableName);

                EmailAddress = new PropertyItem("EmailAddress", tableName);

                SecretKey = new PropertyItem("SecretKey", tableName);

                SecondKey = new PropertyItem("SecondKey", tableName);

                Password = new PropertyItem("Password", tableName);

                Partner = new PropertyItem("Partner", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                DisplaySequence = new PropertyItem("DisplaySequence", tableName);

                Charge = new PropertyItem("Charge", tableName);

                IsPercent = new PropertyItem("IsPercent", tableName);

                AllowRecharge = new PropertyItem("AllowRecharge", tableName);

                Logo = new PropertyItem("Logo", tableName);

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
            /// 接口类型,1是支持电脑,2是支持手机，多个值之间用|隔开
            /// </summary> 
            public PropertyItem DrivePath = null;
            /// <summary>
            /// 支付接口编号,
            /// </summary> 
            public PropertyItem Gateway = null;
            /// <summary>
            /// 商户号,
            /// </summary> 
            public PropertyItem MerchantCode = null;
            /// <summary>
            /// 商户邮箱,
            /// </summary> 
            public PropertyItem EmailAddress = null;
            /// <summary>
            /// 商户密钥,
            /// </summary> 
            public PropertyItem SecretKey = null;
            /// <summary>
            /// 第二密钥,
            /// </summary> 
            public PropertyItem SecondKey = null;
            /// <summary>
            /// 密码,
            /// </summary> 
            public PropertyItem Password = null;
            /// <summary>
            /// 合作伙伴,
            /// </summary> 
            public PropertyItem Partner = null;
            /// <summary>
            /// 启用,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 显示顺序,
            /// </summary> 
            public PropertyItem DisplaySequence = null;
            /// <summary>
            /// 手续费,
            /// </summary> 
            public PropertyItem Charge = null;
            /// <summary>
            /// 是否按百分比收费,
            /// </summary> 
            public PropertyItem IsPercent = null;
            /// <summary>
            /// 是否支持在线充值 ,
            /// </summary> 
            public PropertyItem AllowRecharge = null;
            /// <summary>
            /// 支付logo,
            /// </summary> 
            public PropertyItem Logo = null;
            /// <summary>
            /// 描述,
            /// </summary> 
            public PropertyItem Description = null;
        }
        #endregion
    }

    public partial class ShopPaymentTypes
    {
        protected override void OnCreate()
        {
            this.IsEnable = true;
        }
    }
}
