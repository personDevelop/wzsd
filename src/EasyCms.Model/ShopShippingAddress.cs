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
    /// 收件人地址
    /// </summary>  
    [JsonObject]
    public partial class ShopShippingAddress : BaseEntity
    {
        public static Column _ = new Column("ShopShippingAddress");

        public ShopShippingAddress()
        {
            this.TableName = "ShopShippingAddress";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private int _RegionId;

        private string _UserId;

        private string _ShipName;

        private string _Address;

        private string _Zipcode;

        private string _EmailAddress;

        private string _TelPhone;

        private string _CelPhone;

        private bool _IsDefault;

        private decimal _Latitude;

        private decimal _Longitude;

        private string _Remark;

        private bool _IsDelete;

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
        ///  地区ID,
        /// </summary>

        [DbProperty(MapingColumnName = "RegionId", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int RegionId
        {
            get
            {
                return this._RegionId;
            }
            set
            {
                this.OnPropertyChanged("RegionId", this._RegionId, value);


                this._RegionId = value;
            }
        }

        /// <summary>
        ///  用户ID,
        /// </summary>

        [DbProperty(MapingColumnName = "UserId", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  收件人姓名,
        /// </summary>

        [DbProperty(MapingColumnName = "ShipName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  详细地址,
        /// </summary>

        [DbProperty(MapingColumnName = "Address", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 600, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this.OnPropertyChanged("Address", this._Address, value);


                this._Address = value;
            }
        }

        /// <summary>
        ///  邮编,
        /// </summary>

        [DbProperty(MapingColumnName = "Zipcode", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 40, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Zipcode
        {
            get
            {
                return this._Zipcode;
            }
            set
            {
                this.OnPropertyChanged("Zipcode", this._Zipcode, value);


                this._Zipcode = value;
            }
        }

        /// <summary>
        ///  邮箱,
        /// </summary>

        [DbProperty(MapingColumnName = "EmailAddress", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  固定电话,
        /// </summary>

        [DbProperty(MapingColumnName = "TelPhone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string TelPhone
        {
            get
            {
                return this._TelPhone;
            }
            set
            {
                this.OnPropertyChanged("TelPhone", this._TelPhone, value);


                this._TelPhone = value;
            }
        }

        /// <summary>
        ///  收件人电话,
        /// </summary>

        [DbProperty(MapingColumnName = "CelPhone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CelPhone
        {
            get
            {
                return this._CelPhone;
            }
            set
            {
                this.OnPropertyChanged("CelPhone", this._CelPhone, value);


                this._CelPhone = value;
            }
        }

        /// <summary>
        ///  是否默认,
        /// </summary>

        [DbProperty(MapingColumnName = "IsDefault", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]

        public bool IsDefault
        {
            get
            {
                return this._IsDefault;
            }
            set
            {
                this.OnPropertyChanged("IsDefault", this._IsDefault, value);


                this._IsDefault = value;
            }
        }

        /// <summary>
        ///  纬度,
        /// </summary>

        [DbProperty(MapingColumnName = "Latitude", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 6, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Latitude
        {
            get
            {
                return this._Latitude;
            }
            set
            {
                this.OnPropertyChanged("Latitude", this._Latitude, value);


                this._Latitude = value;
            }
        }

        /// <summary>
        ///  经度,
        /// </summary>

        [DbProperty(MapingColumnName = "Longitude", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 6, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal Longitude
        {
            get
            {
                return this._Longitude;
            }
            set
            {
                this.OnPropertyChanged("Longitude", this._Longitude, value);


                this._Longitude = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Remark", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 2000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  是否删除,
        /// </summary>

        [DbProperty(MapingColumnName = "IsDelete", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsDelete
        {
            get
            {
                return this._IsDelete;
            }
            set
            {
                this.OnPropertyChanged("IsDelete", this._IsDelete, value);


                this._IsDelete = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                RegionId = new PropertyItem("RegionId", tableName);

                UserId = new PropertyItem("UserId", tableName);

                ShipName = new PropertyItem("ShipName", tableName);

                Address = new PropertyItem("Address", tableName);

                Zipcode = new PropertyItem("Zipcode", tableName);

                EmailAddress = new PropertyItem("EmailAddress", tableName);

                TelPhone = new PropertyItem("TelPhone", tableName);

                CelPhone = new PropertyItem("CelPhone", tableName);

                IsDefault = new PropertyItem("IsDefault", tableName);

                Latitude = new PropertyItem("Latitude", tableName);

                Longitude = new PropertyItem("Longitude", tableName);

                Remark = new PropertyItem("Remark", tableName);

                IsDelete = new PropertyItem("IsDelete", tableName);


            }
            /// <summary>
            /// 主键ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 地区ID,
            /// </summary> 
            public PropertyItem RegionId = null;
            /// <summary>
            /// 用户ID,
            /// </summary> 
            public PropertyItem UserId = null;
            /// <summary>
            /// 收件人姓名,
            /// </summary> 
            public PropertyItem ShipName = null;
            /// <summary>
            /// 详细地址,
            /// </summary> 
            public PropertyItem Address = null;
            /// <summary>
            /// 邮编,
            /// </summary> 
            public PropertyItem Zipcode = null;
            /// <summary>
            /// 邮箱,
            /// </summary> 
            public PropertyItem EmailAddress = null;
            /// <summary>
            /// 固定电话,
            /// </summary> 
            public PropertyItem TelPhone = null;
            /// <summary>
            /// 收件人电话,
            /// </summary> 
            public PropertyItem CelPhone = null;
            /// <summary>
            /// 是否默认,
            /// </summary> 
            public PropertyItem IsDefault = null;
            /// <summary>
            /// 纬度,
            /// </summary> 
            public PropertyItem Latitude = null;
            /// <summary>
            /// 经度,
            /// </summary> 
            public PropertyItem Longitude = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Remark = null;
            /// <summary>
            /// 是否删除,
            /// </summary> 
            public PropertyItem IsDelete = null;
        }
        #endregion
    }


    public partial class ShopShippingAddress
    {
        /// <summary>
        /// 地址路径的父子id  格式 父ID|子ID
        /// </summary>
        [NotDbCol]
        public string FullPath { get; set; }

        /// <summary>
        /// 地址路径的父子名称  格式 父名称|子名称
        /// </summary>
        [NotDbCol]
        public string PathName { get; set; }

    }
}
