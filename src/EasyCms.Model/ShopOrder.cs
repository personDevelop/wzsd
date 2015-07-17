﻿using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace EasyCms.Model
{
    /// <summary>
    /// 订单主表
    /// </summary>  
    [JsonObject]
    public partial class ShopOrder : BaseEntity
    {
        public static Column _ = new Column("ShopOrder");

        public ShopOrder()
        {
            this.TableName = "ShopOrder";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _ParentID;

        private DateTime _CreateDate;

        private DateTime _UpdateDate;

        private string _MemberID;

        private string _MemberName;

        private string _MemberEmail;

        private string _MemberCallPhone;

        private int _RegionID;

        private string _ShipRegion;

        private string _ShipAddress;

        private string _ShipZip;

        private string _ShipName;

        private string _ShipTel;

        private string _ShipEmail;

        private string _ShipModeID;

        private string _ShipModeName;

        private decimal _Freight;

        private decimal _FreightAdjust;

        private decimal _FreightActual;

        private decimal _Weight;

        private int _ShipStatus;

        private string _ShipOrderNum;

        private string _ExpressCompanyID;

        private string _ExpressCompanyName;

        private string _PayTypeID;

        private string _PayTypeName;

        private string _PayTypeGateWay;

        private int _PayStatus;

        private int _RefundStatus;

        private decimal _TotalPrice;

        private decimal _OrderPoint;

        private bool _IsInvoice;

        private string _InvoiceInfo;

        private decimal _CostPrice;

        private decimal _Discount;

        private decimal _DiscountOrderPrice;

        private decimal _PayMoney;

        private int _OrderType;

        private string _OrderResId;

        private int _OrderStatus;

        private string _SellerID;

        private string _SellerName;

        private string _SellerEmail;

        private string _SellerPhone;

        private string _SupplierID;

        private string _SupplierName;

        private string _OrderIP;

        private bool _CommentStatus;

        private bool _HasChildren;

        private bool _IsFreeShiping;

        private string _Remark;

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
        ///  订单编号,
        /// </summary>

        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this.OnPropertyChanged("Code", this._Code, value);
                this._Code = value;
            }
        }

        /// <summary>
        ///  主订单ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ParentID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = true, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {
                this.OnPropertyChanged("ParentID", this._ParentID, value);
                this._ParentID = value;
            }
        }

        /// <summary>
        ///  创建日期,
        /// </summary>

        [DbProperty(MapingColumnName = "CreateDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime CreateDate
        {
            get
            {
                return this._CreateDate;
            }
            set
            {
                this.OnPropertyChanged("CreateDate", this._CreateDate, value);
                this._CreateDate = value;
            }
        }

        /// <summary>
        ///  最后修改日期,
        /// </summary>

        [DbProperty(MapingColumnName = "UpdateDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime UpdateDate
        {
            get
            {
                return this._UpdateDate;
            }
            set
            {
                this.OnPropertyChanged("UpdateDate", this._UpdateDate, value);
                this._UpdateDate = value;
            }
        }

        /// <summary>
        ///  会员ID,
        /// </summary>

        [DbProperty(MapingColumnName = "MemberID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string MemberID
        {
            get
            {
                return this._MemberID;
            }
            set
            {
                this.OnPropertyChanged("MemberID", this._MemberID, value);
                this._MemberID = value;
            }
        }

        /// <summary>
        ///  会员姓名,
        /// </summary>

        [DbProperty(MapingColumnName = "MemberName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string MemberName
        {
            get
            {
                return this._MemberName;
            }
            set
            {
                this.OnPropertyChanged("MemberName", this._MemberName, value);
                this._MemberName = value;
            }
        }

        /// <summary>
        ///  会员Email,
        /// </summary>

        [DbProperty(MapingColumnName = "MemberEmail", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string MemberEmail
        {
            get
            {
                return this._MemberEmail;
            }
            set
            {
                this.OnPropertyChanged("MemberEmail", this._MemberEmail, value);
                this._MemberEmail = value;
            }
        }

        /// <summary>
        ///  会员电话,
        /// </summary>

        [DbProperty(MapingColumnName = "MemberCallPhone", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string MemberCallPhone
        {
            get
            {
                return this._MemberCallPhone;
            }
            set
            {
                this.OnPropertyChanged("MemberCallPhone", this._MemberCallPhone, value);
                this._MemberCallPhone = value;
            }
        }

        /// <summary>
        ///  地区ID,
        /// </summary>

        [DbProperty(MapingColumnName = "RegionID", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int RegionID
        {
            get
            {
                return this._RegionID;
            }
            set
            {
                this.OnPropertyChanged("RegionID", this._RegionID, value);
                this._RegionID = value;
            }
        }

        /// <summary>
        ///  地区名称,
        /// </summary>

        [DbProperty(MapingColumnName = "ShipRegion", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShipRegion
        {
            get
            {
                return this._ShipRegion;
            }
            set
            {
                this.OnPropertyChanged("ShipRegion", this._ShipRegion, value);
                this._ShipRegion = value;
            }
        }

        /// <summary>
        ///  详细地址,
        /// </summary>

        [DbProperty(MapingColumnName = "ShipAddress", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 300, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShipAddress
        {
            get
            {
                return this._ShipAddress;
            }
            set
            {
                this.OnPropertyChanged("ShipAddress", this._ShipAddress, value);
                this._ShipAddress = value;
            }
        }

        /// <summary>
        ///  邮编,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ShipZip", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShipZip
        {
            get
            {
                return this._ShipZip;
            }
            set
            {
                this.OnPropertyChanged("ShipZip", this._ShipZip, value);
                this._ShipZip = value;
            }
        }

        /// <summary>
        ///  收件人,
        /// </summary>

        [DbProperty(MapingColumnName = "ShipName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShipName
        {
            get
            {
                return this._ShipName;
            }
            set
            {
                this.OnPropertyChanged("ShipName", this._ShipName, value);
                this._ShipName = value;
            }
        }

        /// <summary>
        ///  收件电话,
        /// </summary>

        [DbProperty(MapingColumnName = "ShipTel", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShipTel
        {
            get
            {
                return this._ShipTel;
            }
            set
            {
                this.OnPropertyChanged("ShipTel", this._ShipTel, value);
                this._ShipTel = value;
            }
        }

        /// <summary>
        ///  收件邮箱,
        /// </summary>

        [DbProperty(MapingColumnName = "ShipEmail", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShipEmail
        {
            get
            {
                return this._ShipEmail;
            }
            set
            {
                this.OnPropertyChanged("ShipEmail", this._ShipEmail, value);
                this._ShipEmail = value;
            }
        }

        /// <summary>
        ///  配送方式ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ShipModeID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShipModeID
        {
            get
            {
                return this._ShipModeID;
            }
            set
            {
                this.OnPropertyChanged("ShipModeID", this._ShipModeID, value);
                this._ShipModeID = value;
            }
        }

        /// <summary>
        ///  配送方式,
        /// </summary>

        [DbProperty(MapingColumnName = "ShipModeName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShipModeName
        {
            get
            {
                return this._ShipModeName;
            }
            set
            {
                this.OnPropertyChanged("ShipModeName", this._ShipModeName, value);
                this._ShipModeName = value;
            }
        }

        /// <summary>
        ///  运费,
        /// </summary>

        [DbProperty(MapingColumnName = "Freight", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Freight
        {
            get
            {
                return this._Freight;
            }
            set
            {
                this.OnPropertyChanged("Freight", this._Freight, value);
                this._Freight = value;
            }
        }

        /// <summary>
        ///  优惠调整运费,
        /// </summary>

        [DbProperty(MapingColumnName = "FreightAdjust", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal FreightAdjust
        {
            get
            {
                return this._FreightAdjust;
            }
            set
            {
                this.OnPropertyChanged("FreightAdjust", this._FreightAdjust, value);
                this._FreightAdjust = value;
            }
        }

        /// <summary>
        ///  实际运费,
        /// </summary>

        [DbProperty(MapingColumnName = "FreightActual", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal FreightActual
        {
            get
            {
                return this._FreightActual;
            }
            set
            {
                this.OnPropertyChanged("FreightActual", this._FreightActual, value);
                this._FreightActual = value;
            }
        }

        /// <summary>
        ///  重量,
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
        ///  物流状态,
        /// </summary>

        [DbProperty(MapingColumnName = "ShipStatus", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ShipStatus
        {
            get
            {
                return this._ShipStatus;
            }
            set
            {
                this.OnPropertyChanged("ShipStatus", this._ShipStatus, value);
                this._ShipStatus = value;
            }
        }

        /// <summary>
        ///  物流运单号,
        /// </summary>

        [DbProperty(MapingColumnName = "ShipOrderNum", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ShipOrderNum
        {
            get
            {
                return this._ShipOrderNum;
            }
            set
            {
                this.OnPropertyChanged("ShipOrderNum", this._ShipOrderNum, value);
                this._ShipOrderNum = value;
            }
        }

        /// <summary>
        ///  快递公司ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ExpressCompanyID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ExpressCompanyID
        {
            get
            {
                return this._ExpressCompanyID;
            }
            set
            {
                this.OnPropertyChanged("ExpressCompanyID", this._ExpressCompanyID, value);
                this._ExpressCompanyID = value;
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
        ///  付款方式ID,
        /// </summary>

        [DbProperty(MapingColumnName = "PayTypeID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PayTypeID
        {
            get
            {
                return this._PayTypeID;
            }
            set
            {
                this.OnPropertyChanged("PayTypeID", this._PayTypeID, value);
                this._PayTypeID = value;
            }
        }

        /// <summary>
        ///  付款方式,
        /// </summary>

        [DbProperty(MapingColumnName = "PayTypeName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PayTypeName
        {
            get
            {
                return this._PayTypeName;
            }
            set
            {
                this.OnPropertyChanged("PayTypeName", this._PayTypeName, value);
                this._PayTypeName = value;
            }
        }

        /// <summary>
        ///  付款网关,
        /// </summary>

        [DbProperty(MapingColumnName = "PayTypeGateWay", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PayTypeGateWay
        {
            get
            {
                return this._PayTypeGateWay;
            }
            set
            {
                this.OnPropertyChanged("PayTypeGateWay", this._PayTypeGateWay, value);
                this._PayTypeGateWay = value;
            }
        }

        /// <summary>
        ///  付款状态,
        /// </summary>

        [DbProperty(MapingColumnName = "PayStatus", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int PayStatus
        {
            get
            {
                return this._PayStatus;
            }
            set
            {
                this.OnPropertyChanged("PayStatus", this._PayStatus, value);
                this._PayStatus = value;
            }
        }

        /// <summary>
        ///  退款状态,
        /// </summary>

        [DbProperty(MapingColumnName = "RefundStatus", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int RefundStatus
        {
            get
            {
                return this._RefundStatus;
            }
            set
            {
                this.OnPropertyChanged("RefundStatus", this._RefundStatus, value);
                this._RefundStatus = value;
            }
        }

        /// <summary>
        ///  订单总价格,
        /// </summary>

        [DbProperty(MapingColumnName = "TotalPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal TotalPrice
        {
            get
            {
                return this._TotalPrice;
            }
            set
            {
                this.OnPropertyChanged("TotalPrice", this._TotalPrice, value);
                this._TotalPrice = value;
            }
        }

        /// <summary>
        ///  订单积分,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderPoint", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal OrderPoint
        {
            get
            {
                return this._OrderPoint;
            }
            set
            {
                this.OnPropertyChanged("OrderPoint", this._OrderPoint, value);
                this._OrderPoint = value;
            }
        }

        /// <summary>
        ///  发票,
        /// </summary>

        [DbProperty(MapingColumnName = "IsInvoice", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsInvoice
        {
            get
            {
                return this._IsInvoice;
            }
            set
            {
                this.OnPropertyChanged("IsInvoice", this._IsInvoice, value);
                this._IsInvoice = value;
            }
        }

        /// <summary>
        ///  发票填写客户名称,
        /// </summary>

        [DbProperty(MapingColumnName = "InvoiceInfo", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string InvoiceInfo
        {
            get
            {
                return this._InvoiceInfo;
            }
            set
            {
                this.OnPropertyChanged("InvoiceInfo", this._InvoiceInfo, value);
                this._InvoiceInfo = value;
            }
        }

        /// <summary>
        ///  成本价,
        /// </summary>

        [DbProperty(MapingColumnName = "CostPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal CostPrice
        {
            get
            {
                return this._CostPrice;
            }
            set
            {
                this.OnPropertyChanged("CostPrice", this._CostPrice, value);
                this._CostPrice = value;
            }
        }

        /// <summary>
        ///  折扣,
        /// </summary>

        [DbProperty(MapingColumnName = "Discount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this.OnPropertyChanged("Discount", this._Discount, value);
                this._Discount = value;
            }
        }

        /// <summary>
        ///  折扣后金额,
        /// </summary>

        [DbProperty(MapingColumnName = "DiscountOrderPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal DiscountOrderPrice
        {
            get
            {
                return this._DiscountOrderPrice;
            }
            set
            {
                this.OnPropertyChanged("DiscountOrderPrice", this._DiscountOrderPrice, value);
                this._DiscountOrderPrice = value;
            }
        }

        /// <summary>
        ///  实际金额,
        /// </summary>

        [DbProperty(MapingColumnName = "PayMoney", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal PayMoney
        {
            get
            {
                return this._PayMoney;
            }
            set
            {
                this.OnPropertyChanged("PayMoney", this._PayMoney, value);
                this._PayMoney = value;
            }
        }

        /// <summary>
        ///  订单类型,0，普通，1促销，2团购
        /// </summary>

        [DbProperty(MapingColumnName = "OrderType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int OrderType
        {
            get
            {
                return this._OrderType;
            }
            set
            {
                this.OnPropertyChanged("OrderType", this._OrderType, value);
                this._OrderType = value;
            }
        }

        /// <summary>
        ///  订单对应的类型ID,团购、促销ID
        /// </summary>

        [DbProperty(MapingColumnName = "OrderResId", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string OrderResId
        {
            get
            {
                return this._OrderResId;
            }
            set
            {
                this.OnPropertyChanged("OrderResId", this._OrderResId, value);
                this._OrderResId = value;
            }
        }

        /// <summary>
        ///  订单状态,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderStatus", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int OrderStatus
        {
            get
            {
                return this._OrderStatus;
            }
            set
            {
                this.OnPropertyChanged("OrderStatus", this._OrderStatus, value);
                this._OrderStatus = value;
            }
        }

        /// <summary>
        ///  卖家ID,
        /// </summary>

        [DbProperty(MapingColumnName = "SellerID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SellerID
        {
            get
            {
                return this._SellerID;
            }
            set
            {
                this.OnPropertyChanged("SellerID", this._SellerID, value);
                this._SellerID = value;
            }
        }

        /// <summary>
        ///  卖家,
        /// </summary>

        [DbProperty(MapingColumnName = "SellerName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SellerName
        {
            get
            {
                return this._SellerName;
            }
            set
            {
                this.OnPropertyChanged("SellerName", this._SellerName, value);
                this._SellerName = value;
            }
        }

        /// <summary>
        ///  卖家邮箱,
        /// </summary>

        [DbProperty(MapingColumnName = "SellerEmail", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SellerEmail
        {
            get
            {
                return this._SellerEmail;
            }
            set
            {
                this.OnPropertyChanged("SellerEmail", this._SellerEmail, value);
                this._SellerEmail = value;
            }
        }

        /// <summary>
        ///  卖家电话,
        /// </summary>

        [DbProperty(MapingColumnName = "SellerPhone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SellerPhone
        {
            get
            {
                return this._SellerPhone;
            }
            set
            {
                this.OnPropertyChanged("SellerPhone", this._SellerPhone, value);
                this._SellerPhone = value;
            }
        }

        /// <summary>
        ///  供应商ID,
        /// </summary>

        [DbProperty(MapingColumnName = "SupplierID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SupplierID
        {
            get
            {
                return this._SupplierID;
            }
            set
            {
                this.OnPropertyChanged("SupplierID", this._SupplierID, value);
                this._SupplierID = value;
            }
        }

        /// <summary>
        ///  供应商名称,
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
        ///  订单IP,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderIP", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string OrderIP
        {
            get
            {
                return this._OrderIP;
            }
            set
            {
                this.OnPropertyChanged("OrderIP", this._OrderIP, value);
                this._OrderIP = value;
            }
        }

        /// <summary>
        ///  评论状态,
        /// </summary>

        [DbProperty(MapingColumnName = "CommentStatus", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool CommentStatus
        {
            get
            {
                return this._CommentStatus;
            }
            set
            {
                this.OnPropertyChanged("CommentStatus", this._CommentStatus, value);
                this._CommentStatus = value;
            }
        }

        /// <summary>
        ///  有拆分的子单,
        /// </summary>

        [DbProperty(MapingColumnName = "HasChildren", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool HasChildren
        {
            get
            {
                return this._HasChildren;
            }
            set
            {
                this.OnPropertyChanged("HasChildren", this._HasChildren, value);
                this._HasChildren = value;
            }
        }

        /// <summary>
        ///  免运费,
        /// </summary>

        [DbProperty(MapingColumnName = "IsFreeShiping", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsFreeShiping
        {
            get
            {
                return this._IsFreeShiping;
            }
            set
            {
                this.OnPropertyChanged("IsFreeShiping", this._IsFreeShiping, value);
                this._IsFreeShiping = value;
            }
        }

        /// <summary>
        ///  订单说明,
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

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                Code = new PropertyItem("Code", tableName);

                ParentID = new PropertyItem("ParentID", tableName);

                CreateDate = new PropertyItem("CreateDate", tableName);

                UpdateDate = new PropertyItem("UpdateDate", tableName);

                MemberID = new PropertyItem("MemberID", tableName);

                MemberName = new PropertyItem("MemberName", tableName);

                MemberEmail = new PropertyItem("MemberEmail", tableName);

                MemberCallPhone = new PropertyItem("MemberCallPhone", tableName);

                RegionID = new PropertyItem("RegionID", tableName);

                ShipRegion = new PropertyItem("ShipRegion", tableName);

                ShipAddress = new PropertyItem("ShipAddress", tableName);

                ShipZip = new PropertyItem("ShipZip", tableName);

                ShipName = new PropertyItem("ShipName", tableName);

                ShipTel = new PropertyItem("ShipTel", tableName);

                ShipEmail = new PropertyItem("ShipEmail", tableName);

                ShipModeID = new PropertyItem("ShipModeID", tableName);

                ShipModeName = new PropertyItem("ShipModeName", tableName);

                Freight = new PropertyItem("Freight", tableName);

                FreightAdjust = new PropertyItem("FreightAdjust", tableName);

                FreightActual = new PropertyItem("FreightActual", tableName);

                Weight = new PropertyItem("Weight", tableName);

                ShipStatus = new PropertyItem("ShipStatus", tableName);

                ShipOrderNum = new PropertyItem("ShipOrderNum", tableName);

                ExpressCompanyID = new PropertyItem("ExpressCompanyID", tableName);

                ExpressCompanyName = new PropertyItem("ExpressCompanyName", tableName);

                PayTypeID = new PropertyItem("PayTypeID", tableName);

                PayTypeName = new PropertyItem("PayTypeName", tableName);

                PayTypeGateWay = new PropertyItem("PayTypeGateWay", tableName);

                PayStatus = new PropertyItem("PayStatus", tableName);

                RefundStatus = new PropertyItem("RefundStatus", tableName);

                TotalPrice = new PropertyItem("TotalPrice", tableName);

                OrderPoint = new PropertyItem("OrderPoint", tableName);

                IsInvoice = new PropertyItem("IsInvoice", tableName);

                InvoiceInfo = new PropertyItem("InvoiceInfo", tableName);

                CostPrice = new PropertyItem("CostPrice", tableName);

                Discount = new PropertyItem("Discount", tableName);

                DiscountOrderPrice = new PropertyItem("DiscountOrderPrice", tableName);

                PayMoney = new PropertyItem("PayMoney", tableName);

                OrderType = new PropertyItem("OrderType", tableName);

                OrderResId = new PropertyItem("OrderResId", tableName);

                OrderStatus = new PropertyItem("OrderStatus", tableName);

                SellerID = new PropertyItem("SellerID", tableName);

                SellerName = new PropertyItem("SellerName", tableName);

                SellerEmail = new PropertyItem("SellerEmail", tableName);

                SellerPhone = new PropertyItem("SellerPhone", tableName);

                SupplierID = new PropertyItem("SupplierID", tableName);

                SupplierName = new PropertyItem("SupplierName", tableName);

                OrderIP = new PropertyItem("OrderIP", tableName);

                CommentStatus = new PropertyItem("CommentStatus", tableName);

                HasChildren = new PropertyItem("HasChildren", tableName);

                IsFreeShiping = new PropertyItem("IsFreeShiping", tableName);

                Remark = new PropertyItem("Remark", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 订单编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 主订单ID,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CreateDate = null;
            /// <summary>
            /// 最后修改日期,
            /// </summary> 
            public PropertyItem UpdateDate = null;
            /// <summary>
            /// 会员ID,
            /// </summary> 
            public PropertyItem MemberID = null;
            /// <summary>
            /// 会员姓名,
            /// </summary> 
            public PropertyItem MemberName = null;
            /// <summary>
            /// 会员Email,
            /// </summary> 
            public PropertyItem MemberEmail = null;
            /// <summary>
            /// 会员电话,
            /// </summary> 
            public PropertyItem MemberCallPhone = null;
            /// <summary>
            /// 地区ID,
            /// </summary> 
            public PropertyItem RegionID = null;
            /// <summary>
            /// 地区名称,
            /// </summary> 
            public PropertyItem ShipRegion = null;
            /// <summary>
            /// 详细地址,
            /// </summary> 
            public PropertyItem ShipAddress = null;
            /// <summary>
            /// 邮编,
            /// </summary> 
            public PropertyItem ShipZip = null;
            /// <summary>
            /// 收件人,
            /// </summary> 
            public PropertyItem ShipName = null;
            /// <summary>
            /// 收件电话,
            /// </summary> 
            public PropertyItem ShipTel = null;
            /// <summary>
            /// 收件邮箱,
            /// </summary> 
            public PropertyItem ShipEmail = null;
            /// <summary>
            /// 配送方式ID,
            /// </summary> 
            public PropertyItem ShipModeID = null;
            /// <summary>
            /// 配送方式,
            /// </summary> 
            public PropertyItem ShipModeName = null;
            /// <summary>
            /// 运费,
            /// </summary> 
            public PropertyItem Freight = null;
            /// <summary>
            /// 优惠调整运费,
            /// </summary> 
            public PropertyItem FreightAdjust = null;
            /// <summary>
            /// 实际运费,
            /// </summary> 
            public PropertyItem FreightActual = null;
            /// <summary>
            /// 重量,
            /// </summary> 
            public PropertyItem Weight = null;
            /// <summary>
            /// 物流状态,
            /// </summary> 
            public PropertyItem ShipStatus = null;
            /// <summary>
            /// 物流运单号,
            /// </summary> 
            public PropertyItem ShipOrderNum = null;
            /// <summary>
            /// 快递公司ID,
            /// </summary> 
            public PropertyItem ExpressCompanyID = null;
            /// <summary>
            /// 快递公司名称,
            /// </summary> 
            public PropertyItem ExpressCompanyName = null;
            /// <summary>
            /// 付款方式ID,
            /// </summary> 
            public PropertyItem PayTypeID = null;
            /// <summary>
            /// 付款方式,
            /// </summary> 
            public PropertyItem PayTypeName = null;
            /// <summary>
            /// 付款网关,
            /// </summary> 
            public PropertyItem PayTypeGateWay = null;
            /// <summary>
            /// 付款状态,
            /// </summary> 
            public PropertyItem PayStatus = null;
            /// <summary>
            /// 退款状态,
            /// </summary> 
            public PropertyItem RefundStatus = null;
            /// <summary>
            /// 订单总价格,
            /// </summary> 
            public PropertyItem TotalPrice = null;
            /// <summary>
            /// 订单积分,
            /// </summary> 
            public PropertyItem OrderPoint = null;
            /// <summary>
            /// 发票,
            /// </summary> 
            public PropertyItem IsInvoice = null;
            /// <summary>
            /// 发票填写客户名称,
            /// </summary> 
            public PropertyItem InvoiceInfo = null;
            /// <summary>
            /// 成本价,
            /// </summary> 
            public PropertyItem CostPrice = null;
            /// <summary>
            /// 折扣,
            /// </summary> 
            public PropertyItem Discount = null;
            /// <summary>
            /// 折扣后金额,
            /// </summary> 
            public PropertyItem DiscountOrderPrice = null;
            /// <summary>
            /// 实际金额,
            /// </summary> 
            public PropertyItem PayMoney = null;
            /// <summary>
            /// 订单类型,0，普通，1促销，2团购
            /// </summary> 
            public PropertyItem OrderType = null;
            /// <summary>
            /// 订单对应的类型ID,团购、促销ID
            /// </summary> 
            public PropertyItem OrderResId = null;
            /// <summary>
            /// 订单状态,
            /// </summary> 
            public PropertyItem OrderStatus = null;
            /// <summary>
            /// 卖家ID,
            /// </summary> 
            public PropertyItem SellerID = null;
            /// <summary>
            /// 卖家,
            /// </summary> 
            public PropertyItem SellerName = null;
            /// <summary>
            /// 卖家邮箱,
            /// </summary> 
            public PropertyItem SellerEmail = null;
            /// <summary>
            /// 卖家电话,
            /// </summary> 
            public PropertyItem SellerPhone = null;
            /// <summary>
            /// 供应商ID,
            /// </summary> 
            public PropertyItem SupplierID = null;
            /// <summary>
            /// 供应商名称,
            /// </summary> 
            public PropertyItem SupplierName = null;
            /// <summary>
            /// 订单IP,
            /// </summary> 
            public PropertyItem OrderIP = null;
            /// <summary>
            /// 评论状态,
            /// </summary> 
            public PropertyItem CommentStatus = null;
            /// <summary>
            /// 有拆分的子单,
            /// </summary> 
            public PropertyItem HasChildren = null;
            /// <summary>
            /// 免运费,
            /// </summary> 
            public PropertyItem IsFreeShiping = null;
            /// <summary>
            /// 订单说明,
            /// </summary> 
            public PropertyItem Remark = null;
        }
        #endregion
    }
}