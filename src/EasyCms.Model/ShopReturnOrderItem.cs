using Newtonsoft.Json;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCms.Model
{
    /// <summary>
    /// 退货单明细
    /// </summary>  
    [JsonObject]
    public partial class ShopReturnOrderItem : BaseEntity
    {
        public static Column _ = new Column("ShopReturnOrderItem");

        public ShopReturnOrderItem()
        {
            this.TableName = "ShopReturnOrderItem";
            OnCreate();
        }


        #region 私有变量

        private string _ItemId;

        private string _ReturnOrderId;

        private string _OrderId;

        private string _OrderItemId;

        private string _ProductId;

        private string _SKUID;

        private string _Name;

        private string _ThumbnailsUrl;

        private string _Description;

        private int _Quantity;

        private decimal _CostPrice;

        private decimal _SellPrice;

        private decimal _ReturnPrice;

        private string _AttributeDesc;

        private string _Remark;

        private decimal _Weight;

        private decimal _Deduct;

        private int _Points;

        #endregion

        #region 属性

        /// <summary>
        ///  主键,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ItemId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = true, StepSize = 1, ColumnDefaultValue = "")]

        public string ItemId
        {
            get
            {
                return this._ItemId;
            }
            set
            {
                this.OnPropertyChanged("ItemId", this._ItemId, value);
                this._ItemId = value;
            }
        }

        /// <summary>
        ///  退货单ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ReturnOrderId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ReturnOrderId
        {
            get
            {
                return this._ReturnOrderId;
            }
            set
            {
                this.OnPropertyChanged("ReturnOrderId", this._ReturnOrderId, value);
                this._ReturnOrderId = value;
            }
        }

        /// <summary>
        ///  原订单ID,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  原订单明细ID,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderItemId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string OrderItemId
        {
            get
            {
                return this._OrderItemId;
            }
            set
            {
                this.OnPropertyChanged("OrderItemId", this._OrderItemId, value);
                this._OrderItemId = value;
            }
        }

        /// <summary>
        ///  商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  商品ISKU,
        /// </summary>

        [DbProperty(MapingColumnName = "SKUID", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  商品名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 400, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  商品缩略图地址,
        /// </summary>

        [DbProperty(MapingColumnName = "ThumbnailsUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 600, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ThumbnailsUrl
        {
            get
            {
                return this._ThumbnailsUrl;
            }
            set
            {
                this.OnPropertyChanged("ThumbnailsUrl", this._ThumbnailsUrl, value);
                this._ThumbnailsUrl = value;
            }
        }

        /// <summary>
        ///  描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  数量,
        /// </summary>

        [DbProperty(MapingColumnName = "Quantity", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this.OnPropertyChanged("Quantity", this._Quantity, value);
                this._Quantity = value;
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
        ///  销售价,
        /// </summary>

        [DbProperty(MapingColumnName = "SellPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal SellPrice
        {
            get
            {
                return this._SellPrice;
            }
            set
            {
                this.OnPropertyChanged("SellPrice", this._SellPrice, value);
                this._SellPrice = value;
            }
        }

        /// <summary>
        ///  返回价格,
        /// </summary>

        [DbProperty(MapingColumnName = "ReturnPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal ReturnPrice
        {
            get
            {
                return this._ReturnPrice;
            }
            set
            {
                this.OnPropertyChanged("ReturnPrice", this._ReturnPrice, value);
                this._ReturnPrice = value;
            }
        }

        /// <summary>
        ///  属性规格描述,
        /// </summary>

        [DbProperty(MapingColumnName = "AttributeDesc", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string AttributeDesc
        {
            get
            {
                return this._AttributeDesc;
            }
            set
            {
                this.OnPropertyChanged("AttributeDesc", this._AttributeDesc, value);
                this._AttributeDesc = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Remark", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  扣除金额（退货时商家一般会扣钱）,
        /// </summary>

        [DbProperty(MapingColumnName = "Deduct", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Deduct
        {
            get
            {
                return this._Deduct;
            }
            set
            {
                this.OnPropertyChanged("Deduct", this._Deduct, value);
                this._Deduct = value;
            }
        }

        /// <summary>
        ///  扣掉积分,
        /// </summary>

        [DbProperty(MapingColumnName = "Points", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Points
        {
            get
            {
                return this._Points;
            }
            set
            {
                this.OnPropertyChanged("Points", this._Points, value);
                this._Points = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ItemId = new PropertyItem("ItemId", tableName);

                ReturnOrderId = new PropertyItem("ReturnOrderId", tableName);

                OrderId = new PropertyItem("OrderId", tableName);

                OrderItemId = new PropertyItem("OrderItemId", tableName);

                ProductId = new PropertyItem("ProductId", tableName);

                SKUID = new PropertyItem("SKUID", tableName);

                Name = new PropertyItem("Name", tableName);

                ThumbnailsUrl = new PropertyItem("ThumbnailsUrl", tableName);

                Description = new PropertyItem("Description", tableName);

                Quantity = new PropertyItem("Quantity", tableName);

                CostPrice = new PropertyItem("CostPrice", tableName);

                SellPrice = new PropertyItem("SellPrice", tableName);

                ReturnPrice = new PropertyItem("ReturnPrice", tableName);

                AttributeDesc = new PropertyItem("AttributeDesc", tableName);

                Remark = new PropertyItem("Remark", tableName);

                Weight = new PropertyItem("Weight", tableName);

                Deduct = new PropertyItem("Deduct", tableName);

                Points = new PropertyItem("Points", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ItemId = null;
            /// <summary>
            /// 退货单ID,
            /// </summary> 
            public PropertyItem ReturnOrderId = null;
            /// <summary>
            /// 原订单ID,
            /// </summary> 
            public PropertyItem OrderId = null;
            /// <summary>
            /// 原订单明细ID,
            /// </summary> 
            public PropertyItem OrderItemId = null;
            /// <summary>
            /// 商品ID,
            /// </summary> 
            public PropertyItem ProductId = null;
            /// <summary>
            /// 商品ISKU,
            /// </summary> 
            public PropertyItem SKUID = null;
            /// <summary>
            /// 商品名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 商品缩略图地址,
            /// </summary> 
            public PropertyItem ThumbnailsUrl = null;
            /// <summary>
            /// 描述,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 数量,
            /// </summary> 
            public PropertyItem Quantity = null;
            /// <summary>
            /// 成本价,
            /// </summary> 
            public PropertyItem CostPrice = null;
            /// <summary>
            /// 销售价,
            /// </summary> 
            public PropertyItem SellPrice = null;
            /// <summary>
            /// 返回价格,
            /// </summary> 
            public PropertyItem ReturnPrice = null;
            /// <summary>
            /// 属性规格描述,
            /// </summary> 
            public PropertyItem AttributeDesc = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Remark = null;
            /// <summary>
            /// 重量,
            /// </summary> 
            public PropertyItem Weight = null;
            /// <summary>
            /// 扣除金额（退货时商家一般会扣钱）,
            /// </summary> 
            public PropertyItem Deduct = null;
            /// <summary>
            /// 扣掉积分,
            /// </summary> 
            public PropertyItem Points = null;
        }
        #endregion
    }

}
