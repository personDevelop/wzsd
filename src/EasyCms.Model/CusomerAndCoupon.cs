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
    /// 会员优惠券关系表
    /// </summary>  
    [JsonObject]
    public partial class CusomerAndCoupon : BaseEntity
    {
        public static Column _ = new Column("CusomerAndCoupon");

        public CusomerAndCoupon()
        {
            this.TableName = "CusomerAndCoupon";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _CustomerID;

        private string _CouponID;

        private int _UsedCount;

        private bool _IsOutDate;

        private int _HaveCount;

        private DateTime _HasDate;

        private decimal _CardValue;

        private string _CardPwd;

        private DateTime _EndDate;

        private string _Remark;

        #endregion

        #region 属性

        /// <summary>
        ///  ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 16, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  会员ID,
        /// </summary>

        [DbProperty(MapingColumnName = "CustomerID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                this.OnPropertyChanged("CustomerID", this._CustomerID, value);
                this._CustomerID = value;
            }
        }

        /// <summary>
        ///  优惠券ID,
        /// </summary>

        [DbProperty(MapingColumnName = "CouponID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CouponID
        {
            get
            {
                return this._CouponID;
            }
            set
            {
                this.OnPropertyChanged("CouponID", this._CouponID, value);
                this._CouponID = value;
            }
        }

        /// <summary>
        ///  使用数量,
        /// </summary>

        [DbProperty(MapingColumnName = "UsedCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int UsedCount
        {
            get
            {
                return this._UsedCount;
            }
            set
            {
                this.OnPropertyChanged("UsedCount", this._UsedCount, value);
                this._UsedCount = value;
            }
        }

        /// <summary>
        ///  是否超期,
        /// </summary>

        [DbProperty(MapingColumnName = "IsOutDate", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsOutDate
        {
            get
            {
                return this._IsOutDate;
            }
            set
            {
                this.OnPropertyChanged("IsOutDate", this._IsOutDate, value);
                this._IsOutDate = value;
            }
        }

        /// <summary>
        ///  还拥有的数量,
        /// </summary>

        [DbProperty(MapingColumnName = "HaveCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int HaveCount
        {
            get
            {
                return this._HaveCount;
            }
            set
            {
                this.OnPropertyChanged("HaveCount", this._HaveCount, value);
                this._HaveCount = value;
            }
        }

        /// <summary>
        ///  拥有的时间,
        /// </summary>

        [DbProperty(MapingColumnName = "HasDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime HasDate
        {
            get
            {
                return this._HasDate;
            }
            set
            {
                this.OnPropertyChanged("HasDate", this._HasDate, value);
                this._HasDate = value;
            }
        }

        /// <summary>
        ///  优惠券面值,
        /// </summary>

        [DbProperty(MapingColumnName = "CardValue", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal CardValue
        {
            get
            {
                return this._CardValue;
            }
            set
            {
                this.OnPropertyChanged("CardValue", this._CardValue, value);
                this._CardValue = value;
            }
        }

        /// <summary>
        ///  优惠券密码,
        /// </summary>

        [DbProperty(MapingColumnName = "CardPwd", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CardPwd
        {
            get
            {
                return this._CardPwd;
            }
            set
            {
                this.OnPropertyChanged("CardPwd", this._CardPwd, value);
                this._CardPwd = value;
            }
        }

        /// <summary>
        ///  过期时间,
        /// </summary>

        [DbProperty(MapingColumnName = "EndDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime EndDate
        {
            get
            {
                return this._EndDate;
            }
            set
            {
                this.OnPropertyChanged("EndDate", this._EndDate, value);
                this._EndDate = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Remark", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

                CustomerID = new PropertyItem("CustomerID", tableName);

                CouponID = new PropertyItem("CouponID", tableName);

                UsedCount = new PropertyItem("UsedCount", tableName);

                IsOutDate = new PropertyItem("IsOutDate", tableName);

                HaveCount = new PropertyItem("HaveCount", tableName);

                HasDate = new PropertyItem("HasDate", tableName);

                CardValue = new PropertyItem("CardValue", tableName);

                CardPwd = new PropertyItem("CardPwd", tableName);

                EndDate = new PropertyItem("EndDate", tableName);

                Remark = new PropertyItem("Remark", tableName);


            }
            /// <summary>
            /// ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 会员ID,
            /// </summary> 
            public PropertyItem CustomerID = null;
            /// <summary>
            /// 优惠券ID,
            /// </summary> 
            public PropertyItem CouponID = null;
            /// <summary>
            /// 使用数量,
            /// </summary> 
            public PropertyItem UsedCount = null;
            /// <summary>
            /// 是否超期,
            /// </summary> 
            public PropertyItem IsOutDate = null;
            /// <summary>
            /// 还拥有的数量,
            /// </summary> 
            public PropertyItem HaveCount = null;
            /// <summary>
            /// 拥有的时间,
            /// </summary> 
            public PropertyItem HasDate = null;
            /// <summary>
            /// 优惠券面值,
            /// </summary> 
            public PropertyItem CardValue = null;
            /// <summary>
            /// 优惠券密码,
            /// </summary> 
            public PropertyItem CardPwd = null;
            /// <summary>
            /// 过期时间,
            /// </summary> 
            public PropertyItem EndDate = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Remark = null;
        }
        #endregion
    }


    public class CouponAccount : BaseEntity
    {
        /// <summary>
        /// 优惠券会员关系表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 优惠券面值
        /// </summary>
        public decimal CardValue { get; set; }

       /// <summary>
       /// 可合并使用
       /// </summary>
        public bool IsCanCombie { get; set; }
        
        /// <summary>
        /// 最低消费金额
        /// </summary>
        public decimal MinPrice { get; set; }

        /// <summary>
        /// 拥有的数量
        /// </summary>
        public decimal HaveCount { get; set; }


        /// <summary>
        /// 本次购物使用优惠券个数
        /// </summary>
        public decimal UsingCount { get; set; }
        public string CategoryId { get; set; }
        public string ProductId { get; set; }
        public string ProductSku { get; set; }



    }
}
