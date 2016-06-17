using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportData.OldEntity
{
    /// <summary>
    /// h7_address
    /// </summary>  
   
    public partial class h7_address : BaseEntity
    {
        public static Column _ = new Column("h7_address");

        public h7_address()
        {
            this.TableName = "h7_address";
            OnCreate();
        }


        #region 私有变量

        private int _id;

        private int _user_id;

        private string _accept_name;

        private string _zip;

        private string _telphone;

        private int? _country;

        private int _province;

        private int _city;

        private int _area;

        private string _address;

        private string _mobile;

        private int _Isdefault;

        #endregion

        #region 属性

        /// <summary>
        ///  id,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "id", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this.OnPropertyChanged("id", this._id, value);


                this._id = value;
            }
        }

        /// <summary>
        ///  user_id,
        /// </summary>

        [DbProperty(MapingColumnName = "user_id", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int user_id
        {
            get
            {
                return this._user_id;
            }
            set
            {
                this.OnPropertyChanged("user_id", this._user_id, value);


                this._user_id = value;
            }
        }

        /// <summary>
        ///  accept_name,
        /// </summary>

        [DbProperty(MapingColumnName = "accept_name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string accept_name
        {
            get
            {
                return this._accept_name;
            }
            set
            {
                this.OnPropertyChanged("accept_name", this._accept_name, value);


                this._accept_name = value;
            }
        }

        /// <summary>
        ///  zip,
        /// </summary>

        [DbProperty(MapingColumnName = "zip", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 6, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public string zip
        {
            get
            {
                return this._zip;
            }
            set
            {
                this.OnPropertyChanged("zip", this._zip, value);


                this._zip = value;
            }
        }

        /// <summary>
        ///  telphone,
        /// </summary>

        [DbProperty(MapingColumnName = "telphone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public string telphone
        {
            get
            {
                return this._telphone;
            }
            set
            {
                this.OnPropertyChanged("telphone", this._telphone, value);


                this._telphone = value;
            }
        }

        /// <summary>
        ///  country,
        /// </summary>

        [DbProperty(MapingColumnName = "country", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public int? country
        {
            get
            {
                return this._country;
            }
            set
            {
                this.OnPropertyChanged("country", this._country, value);


                this._country = value;
            }
        }

        /// <summary>
        ///  province,
        /// </summary>

        [DbProperty(MapingColumnName = "province", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int province
        {
            get
            {
                return this._province;
            }
            set
            {
                this.OnPropertyChanged("province", this._province, value);


                this._province = value;
            }
        }

        /// <summary>
        ///  city,
        /// </summary>

        [DbProperty(MapingColumnName = "city", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int city
        {
            get
            {
                return this._city;
            }
            set
            {
                this.OnPropertyChanged("city", this._city, value);


                this._city = value;
            }
        }

        /// <summary>
        ///  area,
        /// </summary>

        [DbProperty(MapingColumnName = "area", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int area
        {
            get
            {
                return this._area;
            }
            set
            {
                this.OnPropertyChanged("area", this._area, value);


                this._area = value;
            }
        }

        /// <summary>
        ///  address,
        /// </summary>

        [DbProperty(MapingColumnName = "address", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 250, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string address
        {
            get
            {
                return this._address;
            }
            set
            {
                this.OnPropertyChanged("address", this._address, value);


                this._address = value;
            }
        }

        /// <summary>
        ///  mobile,
        /// </summary>

        [DbProperty(MapingColumnName = "mobile", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public string mobile
        {
            get
            {
                return this._mobile;
            }
            set
            {
                this.OnPropertyChanged("mobile", this._mobile, value);


                this._mobile = value;
            }
        }

        /// <summary>
        ///  是否默认,
        /// </summary>

        [DbProperty(MapingColumnName = "default", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Isdefault
        {
            get
            {
                return this._Isdefault;
            }
            set
            {
                this.OnPropertyChanged("Isdefault", this._Isdefault, value);


                this._Isdefault = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                id = new PropertyItem("id", tableName);

                user_id = new PropertyItem("user_id", tableName);

                accept_name = new PropertyItem("accept_name", tableName);

                zip = new PropertyItem("zip", tableName);

                telphone = new PropertyItem("telphone", tableName);

                country = new PropertyItem("country", tableName);

                province = new PropertyItem("province", tableName);

                city = new PropertyItem("city", tableName);

                area = new PropertyItem("area", tableName);

                address = new PropertyItem("address", tableName);

                mobile = new PropertyItem("mobile", tableName);

                Isdefault = new PropertyItem("Isdefault", tableName);


            }
            /// <summary>
            /// id,
            /// </summary> 
            public PropertyItem id = null;
            /// <summary>
            /// user_id,
            /// </summary> 
            public PropertyItem user_id = null;
            /// <summary>
            /// accept_name,
            /// </summary> 
            public PropertyItem accept_name = null;
            /// <summary>
            /// zip,
            /// </summary> 
            public PropertyItem zip = null;
            /// <summary>
            /// telphone,
            /// </summary> 
            public PropertyItem telphone = null;
            /// <summary>
            /// country,
            /// </summary> 
            public PropertyItem country = null;
            /// <summary>
            /// province,
            /// </summary> 
            public PropertyItem province = null;
            /// <summary>
            /// city,
            /// </summary> 
            public PropertyItem city = null;
            /// <summary>
            /// area,
            /// </summary> 
            public PropertyItem area = null;
            /// <summary>
            /// address,
            /// </summary> 
            public PropertyItem address = null;
            /// <summary>
            /// mobile,
            /// </summary> 
            public PropertyItem mobile = null;
            /// <summary>
            /// 是否默认,
            /// </summary> 
            public PropertyItem Isdefault = null;
        }
        #endregion
    }

}
