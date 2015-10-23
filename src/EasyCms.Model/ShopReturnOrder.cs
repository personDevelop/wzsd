using Newtonsoft.Json;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCms.Model
{
    /// <summary>
    /// 商品退单
    /// </summary>  
    [JsonObject]
    public partial class ShopReturnOrder : BaseEntity
    {
        public static Column _ = new Column("ShopReturnOrder");

        public ShopReturnOrder()
        {
            this.TableName = "ShopReturnOrder";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _OrderId;

        private string _UserId;

        private string _UserName;

        private DateTime _CreatedDate;

        private string _SupplierId;

        private string _SupplierName;

        private decimal _ActualSalesTotal;

        private decimal _Amount;

        private decimal _AmountAdjusted;

        private int _ServiceType;

        private string _Credential;

        private string _Description;

        private string _ImageUrl;

        private int _ReturnType;

        private int _PickRegionID;

        private string _PickRegion;

        private string _PickAddress;

        private string _PickZipCode;

        private string _PickTelPhone;

        private string _PickEmail;

        private string _ShippingModeId;

        private string _ShippingModeName;

        private int _ShipOrderNumber;

        private string _ExpressCompanyName;

        private string _ExpressCompanyAbb;

        private string _ReturnTrueName;

        private string _ReturnBankName;

        private string _ReturnCard;

        private int _ReturnCardType;

        private string _ContactName;

        private string _ContactPhone;

        private UserDjStatus _Status;

        private LogisticStatus _LogisticStatus;

        private string _RefuseReason;

        private string _Remark;

        private ReturnMoneyStatus _ReturnMoneyStatus;

        private decimal _ReturnMoney;

        private bool _IsShopReviceGood;

        private decimal _RequestReturnMoney;

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
        ///  原订单ID,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string OrderId
        {
            get
            {
                return this._OrderId;
            }
            set
            {
                this.OnPropertyChanged("OrderId", this._OrderId, value);
                this._OrderId = value;
            }
        }

        /// <summary>
        ///  会员ID,
        /// </summary>

        [DbProperty(MapingColumnName = "UserId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                this.OnPropertyChanged("UserId", this._UserId, value);
                this._UserId = value;
            }
        }

        /// <summary>
        ///  会员名称,
        /// </summary>

        [DbProperty(MapingColumnName = "UserName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this.OnPropertyChanged("UserName", this._UserName, value);
                this._UserName = value;
            }
        }

        /// <summary>
        ///  创建日期,
        /// </summary>

        [DbProperty(MapingColumnName = "CreatedDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime CreatedDate
        {
            get
            {
                return this._CreatedDate;
            }
            set
            {
                this.OnPropertyChanged("CreatedDate", this._CreatedDate, value);
                this._CreatedDate = value;
            }
        }

        /// <summary>
        ///  商家ID,
        /// </summary>

        [DbProperty(MapingColumnName = "SupplierId", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  商家名称,
        /// </summary>

        [DbProperty(MapingColumnName = "SupplierName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SupplierName
        {
            get
            {
                return this._SupplierName;
            }
            set
            {
                this.OnPropertyChanged("SupplierName", this._SupplierName, value);
                this._SupplierName = value;
            }
        }

        /// <summary>
        ///  实际销售数量,
        /// </summary>

        [DbProperty(MapingColumnName = "ActualSalesTotal", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal ActualSalesTotal
        {
            get
            {
                return this._ActualSalesTotal;
            }
            set
            {
                this.OnPropertyChanged("ActualSalesTotal", this._ActualSalesTotal, value);
                this._ActualSalesTotal = value;
            }
        }

        /// <summary>
        ///  请求退货数量,
        /// </summary>

        [DbProperty(MapingColumnName = "Amount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Amount
        {
            get
            {
                return this._Amount;
            }
            set
            {
                this.OnPropertyChanged("Amount", this._Amount, value);
                this._Amount = value;
            }
        }

        /// <summary>
        ///  批准退货数量,
        /// </summary>

        [DbProperty(MapingColumnName = "AmountAdjusted", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal AmountAdjusted
        {
            get
            {
                return this._AmountAdjusted;
            }
            set
            {
                this.OnPropertyChanged("AmountAdjusted", this._AmountAdjusted, value);
                this._AmountAdjusted = value;
            }
        }

        /// <summary>
        ///  服务类型,0退货，1换货
        /// </summary>

        [DbProperty(MapingColumnName = "ServiceType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ServiceType
        {
            get
            {
                return this._ServiceType;
            }
            set
            {
                this.OnPropertyChanged("ServiceType", this._ServiceType, value);
                this._ServiceType = value;
            }
        }

        /// <summary>
        ///  凭据,
        /// </summary>

        [DbProperty(MapingColumnName = "Credential", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Credential
        {
            get
            {
                return this._Credential;
            }
            set
            {
                this.OnPropertyChanged("Credential", this._Credential, value);
                this._Credential = value;
            }
        }

        /// <summary>
        ///  顾客描述退货原因,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  用户上传的商品瑕疵图片,
        /// </summary>

        [DbProperty(MapingColumnName = "ImageUrl", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ImageUrl
        {
            get
            {
                return this._ImageUrl;
            }
            set
            {
                this.OnPropertyChanged("ImageUrl", this._ImageUrl, value);
                this._ImageUrl = value;
            }
        }

        /// <summary>
        ///  退货类型,退货类型0 整单退 1 部分退
        /// </summary>

        [DbProperty(MapingColumnName = "ReturnType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ReturnType
        {
            get
            {
                return this._ReturnType;
            }
            set
            {
                this.OnPropertyChanged("ReturnType", this._ReturnType, value);
                this._ReturnType = value;
            }
        }

        /// <summary>
        ///  接地区ID,
        /// </summary>

        [DbProperty(MapingColumnName = "PickRegionID", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int PickRegionID
        {
            get
            {
                return this._PickRegionID;
            }
            set
            {
                this.OnPropertyChanged("PickRegionID", this._PickRegionID, value);
                this._PickRegionID = value;
            }
        }

        /// <summary>
        ///  接地区名称,
        /// </summary>

        [DbProperty(MapingColumnName = "PickRegion", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PickRegion
        {
            get
            {
                return this._PickRegion;
            }
            set
            {
                this.OnPropertyChanged("PickRegion", this._PickRegion, value);
                this._PickRegion = value;
            }
        }

        /// <summary>
        ///  接详细地址,
        /// </summary>

        [DbProperty(MapingColumnName = "PickAddress", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PickAddress
        {
            get
            {
                return this._PickAddress;
            }
            set
            {
                this.OnPropertyChanged("PickAddress", this._PickAddress, value);
                this._PickAddress = value;
            }
        }

        /// <summary>
        ///  邮编,
        /// </summary>

        [DbProperty(MapingColumnName = "PickZipCode", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 10, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PickZipCode
        {
            get
            {
                return this._PickZipCode;
            }
            set
            {
                this.OnPropertyChanged("PickZipCode", this._PickZipCode, value);
                this._PickZipCode = value;
            }
        }

        /// <summary>
        ///  电话,
        /// </summary>

        [DbProperty(MapingColumnName = "PickTelPhone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PickTelPhone
        {
            get
            {
                return this._PickTelPhone;
            }
            set
            {
                this.OnPropertyChanged("PickTelPhone", this._PickTelPhone, value);
                this._PickTelPhone = value;
            }
        }

        /// <summary>
        ///  邮箱Email,
        /// </summary>

        [DbProperty(MapingColumnName = "PickEmail", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PickEmail
        {
            get
            {
                return this._PickEmail;
            }
            set
            {
                this.OnPropertyChanged("PickEmail", this._PickEmail, value);
                this._PickEmail = value;
            }
        }

        /// <summary>
        ///  销售模式ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ShippingModeId", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  销售模式名称,
        /// </summary>

        [DbProperty(MapingColumnName = "ShippingModeName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShippingModeName
        {
            get
            {
                return this._ShippingModeName;
            }
            set
            {
                this.OnPropertyChanged("ShippingModeName", this._ShippingModeName, value);
                this._ShippingModeName = value;
            }
        }

        /// <summary>
        ///  订单数量,
        /// </summary>

        [DbProperty(MapingColumnName = "ShipOrderNumber", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ShipOrderNumber
        {
            get
            {
                return this._ShipOrderNumber;
            }
            set
            {
                this.OnPropertyChanged("ShipOrderNumber", this._ShipOrderNumber, value);
                this._ShipOrderNumber = value;
            }
        }

        /// <summary>
        ///  快递公司名称,
        /// </summary>

        [DbProperty(MapingColumnName = "ExpressCompanyName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ExpressCompanyName
        {
            get
            {
                return this._ExpressCompanyName;
            }
            set
            {
                this.OnPropertyChanged("ExpressCompanyName", this._ExpressCompanyName, value);
                this._ExpressCompanyName = value;
            }
        }

        /// <summary>
        ///  快递公司,
        /// </summary>

        [DbProperty(MapingColumnName = "ExpressCompanyAbb", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ExpressCompanyAbb
        {
            get
            {
                return this._ExpressCompanyAbb;
            }
            set
            {
                this.OnPropertyChanged("ExpressCompanyAbb", this._ExpressCompanyAbb, value);
                this._ExpressCompanyAbb = value;
            }
        }

        /// <summary>
        ///  退款用户名称,
        /// </summary>

        [DbProperty(MapingColumnName = "ReturnTrueName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ReturnTrueName
        {
            get
            {
                return this._ReturnTrueName;
            }
            set
            {
                this.OnPropertyChanged("ReturnTrueName", this._ReturnTrueName, value);
                this._ReturnTrueName = value;
            }
        }

        /// <summary>
        ///  退款银行名称,
        /// </summary>

        [DbProperty(MapingColumnName = "ReturnBankName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ReturnBankName
        {
            get
            {
                return this._ReturnBankName;
            }
            set
            {
                this.OnPropertyChanged("ReturnBankName", this._ReturnBankName, value);
                this._ReturnBankName = value;
            }
        }

        /// <summary>
        ///  退款银行卡号,
        /// </summary>

        [DbProperty(MapingColumnName = "ReturnCard", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ReturnCard
        {
            get
            {
                return this._ReturnCard;
            }
            set
            {
                this.OnPropertyChanged("ReturnCard", this._ReturnCard, value);
                this._ReturnCard = value;
            }
        }

        /// <summary>
        ///  退款银行卡类型,
        /// </summary>

        [DbProperty(MapingColumnName = "ReturnCardType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ReturnCardType
        {
            get
            {
                return this._ReturnCardType;
            }
            set
            {
                this.OnPropertyChanged("ReturnCardType", this._ReturnCardType, value);
                this._ReturnCardType = value;
            }
        }

        /// <summary>
        ///  联系人,
        /// </summary>

        [DbProperty(MapingColumnName = "ContactName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ContactName
        {
            get
            {
                return this._ContactName;
            }
            set
            {
                this.OnPropertyChanged("ContactName", this._ContactName, value);
                this._ContactName = value;
            }
        }

        /// <summary>
        ///  联系电话,
        /// </summary>

        [DbProperty(MapingColumnName = "ContactPhone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ContactPhone
        {
            get
            {
                return this._ContactPhone;
            }
            set
            {
                this.OnPropertyChanged("ContactPhone", this._ContactPhone, value);
                this._ContactPhone = value;
            }
        }

        /// <summary>
        ///  状态,
        /// </summary>

        [DbProperty(MapingColumnName = "Status", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public UserDjStatus Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this.OnPropertyChanged("Status", this._Status, value);
                this._Status = value;
            }
        }

        /// <summary>
        ///  物流状态,
        /// </summary>

        [DbProperty(MapingColumnName = "LogisticStatus", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public LogisticStatus LogisticStatus
        {
            get
            {
                return this._LogisticStatus;
            }
            set
            {
                this.OnPropertyChanged("LogisticStatus", this._LogisticStatus, value);
                this._LogisticStatus = value;
            }
        }

        /// <summary>
        ///  拒绝原因,
        /// </summary>

        [DbProperty(MapingColumnName = "RefuseReason", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RefuseReason
        {
            get
            {
                return this._RefuseReason;
            }
            set
            {
                this.OnPropertyChanged("RefuseReason", this._RefuseReason, value);
                this._RefuseReason = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Remark", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this.OnPropertyChanged("Remark", this._Remark, value);
                this._Remark = value;
            }
        }

        /// <summary>
        ///  退款状态,
        /// </summary>

        [DbProperty(MapingColumnName = "ReturnMoneyStatus", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public ReturnMoneyStatus ReturnMoneyStatus
        {
            get
            {
                return this._ReturnMoneyStatus;
            }
            set
            {
                this.OnPropertyChanged("ReturnMoneyStatus", this._ReturnMoneyStatus, value);
                this._ReturnMoneyStatus = value;
            }
        }

        /// <summary>
        ///  退款金额,
        /// </summary>

        [DbProperty(MapingColumnName = "ReturnMoney", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal ReturnMoney
        {
            get
            {
                return this._ReturnMoney;
            }
            set
            {
                this.OnPropertyChanged("ReturnMoney", this._ReturnMoney, value);
                this._ReturnMoney = value;
            }
        }

        /// <summary>
        ///  是否需要商家取货,
        /// </summary>

        [DbProperty(MapingColumnName = "IsShopReviceGood", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsShopReviceGood
        {
            get
            {
                return this._IsShopReviceGood;
            }
            set
            {
                this.OnPropertyChanged("IsShopReviceGood", this._IsShopReviceGood, value);
                this._IsShopReviceGood = value;
            }
        }

        /// <summary>
        ///  应退金额,
        /// </summary>

        [DbProperty(MapingColumnName = "RequestReturnMoney", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal RequestReturnMoney
        {
            get
            {
                return this._RequestReturnMoney;
            }
            set
            {
                this.OnPropertyChanged("RequestReturnMoney", this._RequestReturnMoney, value);
                this._RequestReturnMoney = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                OrderId = new PropertyItem("OrderId", tableName);

                UserId = new PropertyItem("UserId", tableName);

                UserName = new PropertyItem("UserName", tableName);

                CreatedDate = new PropertyItem("CreatedDate", tableName);

                SupplierId = new PropertyItem("SupplierId", tableName);

                SupplierName = new PropertyItem("SupplierName", tableName);

                ActualSalesTotal = new PropertyItem("ActualSalesTotal", tableName);

                Amount = new PropertyItem("Amount", tableName);

                AmountAdjusted = new PropertyItem("AmountAdjusted", tableName);

                ServiceType = new PropertyItem("ServiceType", tableName);

                Credential = new PropertyItem("Credential", tableName);

                Description = new PropertyItem("Description", tableName);

                ImageUrl = new PropertyItem("ImageUrl", tableName);

                ReturnType = new PropertyItem("ReturnType", tableName);

                PickRegionID = new PropertyItem("PickRegionID", tableName);

                PickRegion = new PropertyItem("PickRegion", tableName);

                PickAddress = new PropertyItem("PickAddress", tableName);

                PickZipCode = new PropertyItem("PickZipCode", tableName);

                PickTelPhone = new PropertyItem("PickTelPhone", tableName);

                PickEmail = new PropertyItem("PickEmail", tableName);

                ShippingModeId = new PropertyItem("ShippingModeId", tableName);

                ShippingModeName = new PropertyItem("ShippingModeName", tableName);

                ShipOrderNumber = new PropertyItem("ShipOrderNumber", tableName);

                ExpressCompanyName = new PropertyItem("ExpressCompanyName", tableName);

                ExpressCompanyAbb = new PropertyItem("ExpressCompanyAbb", tableName);

                ReturnTrueName = new PropertyItem("ReturnTrueName", tableName);

                ReturnBankName = new PropertyItem("ReturnBankName", tableName);

                ReturnCard = new PropertyItem("ReturnCard", tableName);

                ReturnCardType = new PropertyItem("ReturnCardType", tableName);

                ContactName = new PropertyItem("ContactName", tableName);

                ContactPhone = new PropertyItem("ContactPhone", tableName);

                Status = new PropertyItem("Status", tableName);

                LogisticStatus = new PropertyItem("LogisticStatus", tableName);

                RefuseReason = new PropertyItem("RefuseReason", tableName);

                Remark = new PropertyItem("Remark", tableName);

                ReturnMoneyStatus = new PropertyItem("ReturnMoneyStatus", tableName);

                ReturnMoney = new PropertyItem("ReturnMoney", tableName);

                IsShopReviceGood = new PropertyItem("IsShopReviceGood", tableName);

                RequestReturnMoney = new PropertyItem("RequestReturnMoney", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 原订单ID,
            /// </summary> 
            public PropertyItem OrderId = null;
            /// <summary>
            /// 会员ID,
            /// </summary> 
            public PropertyItem UserId = null;
            /// <summary>
            /// 会员名称,
            /// </summary> 
            public PropertyItem UserName = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CreatedDate = null;
            /// <summary>
            /// 商家ID,
            /// </summary> 
            public PropertyItem SupplierId = null;
            /// <summary>
            /// 商家名称,
            /// </summary> 
            public PropertyItem SupplierName = null;
            /// <summary>
            /// 实际销售数量,
            /// </summary> 
            public PropertyItem ActualSalesTotal = null;
            /// <summary>
            /// 请求退货数量,
            /// </summary> 
            public PropertyItem Amount = null;
            /// <summary>
            /// 批准退货数量,
            /// </summary> 
            public PropertyItem AmountAdjusted = null;
            /// <summary>
            /// 服务类型,0退货，1换货
            /// </summary> 
            public PropertyItem ServiceType = null;
            /// <summary>
            /// 凭据,
            /// </summary> 
            public PropertyItem Credential = null;
            /// <summary>
            /// 顾客描述退货原因,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 用户上传的商品瑕疵图片,
            /// </summary> 
            public PropertyItem ImageUrl = null;
            /// <summary>
            /// 退货类型,退货类型0 整单退 1 部分退
            /// </summary> 
            public PropertyItem ReturnType = null;
            /// <summary>
            /// 接地区ID,
            /// </summary> 
            public PropertyItem PickRegionID = null;
            /// <summary>
            /// 接地区名称,
            /// </summary> 
            public PropertyItem PickRegion = null;
            /// <summary>
            /// 接详细地址,
            /// </summary> 
            public PropertyItem PickAddress = null;
            /// <summary>
            /// 邮编,
            /// </summary> 
            public PropertyItem PickZipCode = null;
            /// <summary>
            /// 电话,
            /// </summary> 
            public PropertyItem PickTelPhone = null;
            /// <summary>
            /// 邮箱Email,
            /// </summary> 
            public PropertyItem PickEmail = null;
            /// <summary>
            /// 销售模式ID,
            /// </summary> 
            public PropertyItem ShippingModeId = null;
            /// <summary>
            /// 销售模式名称,
            /// </summary> 
            public PropertyItem ShippingModeName = null;
            /// <summary>
            /// 订单数量,
            /// </summary> 
            public PropertyItem ShipOrderNumber = null;
            /// <summary>
            /// 快递公司名称,
            /// </summary> 
            public PropertyItem ExpressCompanyName = null;
            /// <summary>
            /// 快递公司,
            /// </summary> 
            public PropertyItem ExpressCompanyAbb = null;
            /// <summary>
            /// 退款用户名称,
            /// </summary> 
            public PropertyItem ReturnTrueName = null;
            /// <summary>
            /// 退款银行名称,
            /// </summary> 
            public PropertyItem ReturnBankName = null;
            /// <summary>
            /// 退款银行卡号,
            /// </summary> 
            public PropertyItem ReturnCard = null;
            /// <summary>
            /// 退款银行卡类型,
            /// </summary> 
            public PropertyItem ReturnCardType = null;
            /// <summary>
            /// 联系人,
            /// </summary> 
            public PropertyItem ContactName = null;
            /// <summary>
            /// 联系电话,
            /// </summary> 
            public PropertyItem ContactPhone = null;
            /// <summary>
            /// 状态,
            /// </summary> 
            public PropertyItem Status = null;
            /// <summary>
            /// 物流状态,
            /// </summary> 
            public PropertyItem LogisticStatus = null;
            /// <summary>
            /// 拒绝原因,
            /// </summary> 
            public PropertyItem RefuseReason = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Remark = null;
            /// <summary>
            /// 退款状态,
            /// </summary> 
            public PropertyItem ReturnMoneyStatus = null;
            /// <summary>
            /// 退款金额,
            /// </summary> 
            public PropertyItem ReturnMoney = null;
            /// <summary>
            /// 是否需要商家取货,
            /// </summary> 
            public PropertyItem IsShopReviceGood = null;
            /// <summary>
            /// 应退金额,
            /// </summary> 
            public PropertyItem RequestReturnMoney = null;
        }
        #endregion
    }

    public partial class ShopReturnOrder
    {

        [NotDbCol]
        public List<ShopReturnOrderItem> OrderItems { get; set; }
    }

}
