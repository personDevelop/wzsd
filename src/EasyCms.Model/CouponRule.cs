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
    /// 优惠券管理
    /// </summary>  
    [JsonObject]
    public partial class CouponRule : BaseEntity
    {
        public static Column _ = new Column("CouponRule");

        public CouponRule()
        {
            this.TableName = "CouponRule";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Name;

        private int _CouponType;

        private string _ClassId;

        private int _SendCount;

        private string _PreName;

        private int _CpLength;

        private bool _IsPwd;

        private decimal _JE;

        private int _NeedPoint;

        private int _QxLx;

        private bool _IsCongZengSongKaiShi;

        private DateTime? _StartDate;

        private DateTime? _EndDate;

        private int _QXTS;

        private string _CategoryId;

        private string _ProductId;

        private string _ProductSku;

        private string _ImageUrl;

        private decimal _MinPrice;

        private decimal _MaxPrice;

        private bool _IsEnable;

        private DateTime _CreateDate;

        private string _Createor;

        private string _SupplierId;

        private int _Status;

        private string _Note;

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
        ///  优惠券名称,
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
        ///  优惠券类型,0普通优惠券，1兑换优惠券，2赠送优惠券
        /// </summary>

        [DbProperty(MapingColumnName = "CouponType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int CouponType
        {
            get
            {
                return this._CouponType;
            }
            set
            {
                this.OnPropertyChanged("CouponType", this._CouponType, value);
                this._CouponType = value;
            }
        }

        /// <summary>
        ///  优惠券分类,
        /// </summary>

        [DbProperty(MapingColumnName = "ClassId", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ClassId
        {
            get
            {
                return this._ClassId;
            }
            set
            {
                this.OnPropertyChanged("ClassId", this._ClassId, value);
                this._ClassId = value;
            }
        }

        /// <summary>
        ///  生成数量,
        /// </summary>

        [DbProperty(MapingColumnName = "SendCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int SendCount
        {
            get
            {
                return this._SendCount;
            }
            set
            {
                this.OnPropertyChanged("SendCount", this._SendCount, value);
                this._SendCount = value;
            }
        }

        /// <summary>
        ///  优惠券前缀,
        /// </summary>

        [DbProperty(MapingColumnName = "PreName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 5, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PreName
        {
            get
            {
                return this._PreName;
            }
            set
            {
                this.OnPropertyChanged("PreName", this._PreName, value);
                this._PreName = value;
            }
        }

        /// <summary>
        ///  优惠券卡号长度,
        /// </summary>

        [DbProperty(MapingColumnName = "CpLength", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int CpLength
        {
            get
            {
                return this._CpLength;
            }
            set
            {
                this.OnPropertyChanged("CpLength", this._CpLength, value);
                this._CpLength = value;
            }
        }

        /// <summary>
        ///  需要密码,
        /// </summary>

        [DbProperty(MapingColumnName = "IsPwd", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsPwd
        {
            get
            {
                return this._IsPwd;
            }
            set
            {
                this.OnPropertyChanged("IsPwd", this._IsPwd, value);
                this._IsPwd = value;
            }
        }

        /// <summary>
        ///  面值,
        /// </summary>

        [DbProperty(MapingColumnName = "JE", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal JE
        {
            get
            {
                return this._JE;
            }
            set
            {
                this.OnPropertyChanged("JE", this._JE, value);
                this._JE = value;
            }
        }

        /// <summary>
        ///  需要积分,
        /// </summary>

        [DbProperty(MapingColumnName = "NeedPoint", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int NeedPoint
        {
            get
            {
                return this._NeedPoint;
            }
            set
            {
                this.OnPropertyChanged("NeedPoint", this._NeedPoint, value);
                this._NeedPoint = value;
            }
        }

        /// <summary>
        ///  期限类型,固定期限范围，规定天数
        /// </summary>

        [DbProperty(MapingColumnName = "QxLx", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int QxLx
        {
            get
            {
                return this._QxLx;
            }
            set
            {
                this.OnPropertyChanged("QxLx", this._QxLx, value);
                this._QxLx = value;
            }
        }

        /// <summary>
        ///  从获取开始计算时间,
        /// </summary>

        [DbProperty(MapingColumnName = "IsCongZengSongKaiShi", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsCongZengSongKaiShi
        {
            get
            {
                return this._IsCongZengSongKaiShi;
            }
            set
            {
                this.OnPropertyChanged("IsCongZengSongKaiShi", this._IsCongZengSongKaiShi, value);
                this._IsCongZengSongKaiShi = value;
            }
        }

        /// <summary>
        ///  有效时间起,
        /// </summary>

        [DbProperty(MapingColumnName = "StartDate", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? StartDate
        {
            get
            {
                return this._StartDate;
            }
            set
            {
                this.OnPropertyChanged("StartDate", this._StartDate, value);
                this._StartDate = value;
            }
        }

        /// <summary>
        ///  有效时间止,
        /// </summary>

        [DbProperty(MapingColumnName = "EndDate", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? EndDate
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
        ///  期限天数,
        /// </summary>

        [DbProperty(MapingColumnName = "QXTS", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int QXTS
        {
            get
            {
                return this._QXTS;
            }
            set
            {
                this.OnPropertyChanged("QXTS", this._QXTS, value);
                this._QXTS = value;
            }
        }

        /// <summary>
        ///  商品分类,
        /// </summary>

        [DbProperty(MapingColumnName = "CategoryId", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CategoryId
        {
            get
            {
                return this._CategoryId;
            }
            set
            {
                this.OnPropertyChanged("CategoryId", this._CategoryId, value);
                this._CategoryId = value;
            }
        }

        /// <summary>
        ///  商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductId", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  商品SKUID,
        /// </summary>

        [DbProperty(MapingColumnName = "ProductSku", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProductSku
        {
            get
            {
                return this._ProductSku;
            }
            set
            {
                this.OnPropertyChanged("ProductSku", this._ProductSku, value);
                this._ProductSku = value;
            }
        }

        /// <summary>
        ///  图片,
        /// </summary>

        [DbProperty(MapingColumnName = "ImageUrl", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  最低消费金额,
        /// </summary>

        [DbProperty(MapingColumnName = "MinPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal MinPrice
        {
            get
            {
                return this._MinPrice;
            }
            set
            {
                this.OnPropertyChanged("MinPrice", this._MinPrice, value);
                this._MinPrice = value;
            }
        }

        /// <summary>
        ///  最大消费金额,
        /// </summary>

        [DbProperty(MapingColumnName = "MaxPrice", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 15, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal MaxPrice
        {
            get
            {
                return this._MaxPrice;
            }
            set
            {
                this.OnPropertyChanged("MaxPrice", this._MaxPrice, value);
                this._MaxPrice = value;
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
        ///  创建人,
        /// </summary>

        [DbProperty(MapingColumnName = "Createor", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Createor
        {
            get
            {
                return this._Createor;
            }
            set
            {
                this.OnPropertyChanged("Createor", this._Createor, value);
                this._Createor = value;
            }
        }

        /// <summary>
        ///  提供电商,
        /// </summary>

        [DbProperty(MapingColumnName = "SupplierId", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  状态,0生效,1失效
        /// </summary>

        [DbProperty(MapingColumnName = "Status", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Status
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
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Note
        {
            get
            {
                return this._Note;
            }
            set
            {
                this.OnPropertyChanged("Note", this._Note, value);
                this._Note = value;
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

                CouponType = new PropertyItem("CouponType", tableName);

                ClassId = new PropertyItem("ClassId", tableName);

                SendCount = new PropertyItem("SendCount", tableName);

                PreName = new PropertyItem("PreName", tableName);

                CpLength = new PropertyItem("CpLength", tableName);

                IsPwd = new PropertyItem("IsPwd", tableName);

                JE = new PropertyItem("JE", tableName);

                NeedPoint = new PropertyItem("NeedPoint", tableName);

                QxLx = new PropertyItem("QxLx", tableName);

                IsCongZengSongKaiShi = new PropertyItem("IsCongZengSongKaiShi", tableName);

                StartDate = new PropertyItem("StartDate", tableName);

                EndDate = new PropertyItem("EndDate", tableName);

                QXTS = new PropertyItem("QXTS", tableName);

                CategoryId = new PropertyItem("CategoryId", tableName);

                ProductId = new PropertyItem("ProductId", tableName);

                ProductSku = new PropertyItem("ProductSku", tableName);

                ImageUrl = new PropertyItem("ImageUrl", tableName);

                MinPrice = new PropertyItem("MinPrice", tableName);

                MaxPrice = new PropertyItem("MaxPrice", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                CreateDate = new PropertyItem("CreateDate", tableName);

                Createor = new PropertyItem("Createor", tableName);

                SupplierId = new PropertyItem("SupplierId", tableName);

                Status = new PropertyItem("Status", tableName);

                Note = new PropertyItem("Note", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 优惠券名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 优惠券类型,0普通优惠券，1兑换优惠券，2赠送优惠券
            /// </summary> 
            public PropertyItem CouponType = null;
            /// <summary>
            /// 优惠券分类,
            /// </summary> 
            public PropertyItem ClassId = null;
            /// <summary>
            /// 生成数量,
            /// </summary> 
            public PropertyItem SendCount = null;
            /// <summary>
            /// 优惠券前缀,
            /// </summary> 
            public PropertyItem PreName = null;
            /// <summary>
            /// 优惠券卡号长度,
            /// </summary> 
            public PropertyItem CpLength = null;
            /// <summary>
            /// 需要密码,
            /// </summary> 
            public PropertyItem IsPwd = null;
            /// <summary>
            /// 面值,
            /// </summary> 
            public PropertyItem JE = null;
            /// <summary>
            /// 需要积分,
            /// </summary> 
            public PropertyItem NeedPoint = null;
            /// <summary>
            /// 期限类型,固定期限范围，规定天数
            /// </summary> 
            public PropertyItem QxLx = null;
            /// <summary>
            /// 从获取开始计算时间,
            /// </summary> 
            public PropertyItem IsCongZengSongKaiShi = null;
            /// <summary>
            /// 有效时间起,
            /// </summary> 
            public PropertyItem StartDate = null;
            /// <summary>
            /// 有效时间止,
            /// </summary> 
            public PropertyItem EndDate = null;
            /// <summary>
            /// 期限天数,
            /// </summary> 
            public PropertyItem QXTS = null;
            /// <summary>
            /// 商品分类,
            /// </summary> 
            public PropertyItem CategoryId = null;
            /// <summary>
            /// 商品ID,
            /// </summary> 
            public PropertyItem ProductId = null;
            /// <summary>
            /// 商品SKUID,
            /// </summary> 
            public PropertyItem ProductSku = null;
            /// <summary>
            /// 图片,
            /// </summary> 
            public PropertyItem ImageUrl = null;
            /// <summary>
            /// 最低消费金额,
            /// </summary> 
            public PropertyItem MinPrice = null;
            /// <summary>
            /// 最大消费金额,
            /// </summary> 
            public PropertyItem MaxPrice = null;
            /// <summary>
            /// 启用,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CreateDate = null;
            /// <summary>
            /// 创建人,
            /// </summary> 
            public PropertyItem Createor = null;
            /// <summary>
            /// 提供电商,
            /// </summary> 
            public PropertyItem SupplierId = null;
            /// <summary>
            /// 状态,0生效,1失效
            /// </summary> 
            public PropertyItem Status = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
        }
        #endregion
    }

    public partial class CouponRule
    {
        protected override void OnCreate()
        {
            IsEnable = true;
            SendCount = 10000;
            CpLength = 10;
            IsCongZengSongKaiShi = true;
            CreateDate = DateTime.Now;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddMonths(3);
            JE = 100;
        }
        [NotDbCol]
        public string ShopCategoryName { get; set; }

        [NotDbCol]
        public string ShopName { get; set; }
        [NotDbCol]
        public string ShopSkuCode { get; set; }
        
    }
}
