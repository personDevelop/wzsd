using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportData.OldEntity
{
 
     public partial class OldUser : BaseEntity
    {
       
       
        #region 私有变量

        private int _id;

        private string _username;

        private string _password;

        private string _email;

        private string _head_ico;

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
        ///  username,
        /// </summary>

        [DbProperty(MapingColumnName = "username", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string username
        {
            get
            {
                return this._username;
            }
            set
            {
                this.OnPropertyChanged("username", this._username, value);


                this._username = value;
            }
        }

        /// <summary>
        ///  password,
        /// </summary>

        [DbProperty(MapingColumnName = "password", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 32, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string password
        {
            get
            {
                return this._password;
            }
            set
            {
                this.OnPropertyChanged("password", this._password, value);


                this._password = value;
            }
        }

        /// <summary>
        ///  email,
        /// </summary>

        [DbProperty(MapingColumnName = "email", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 250, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string email
        {
            get
            {
                return this._email;
            }
            set
            {
                this.OnPropertyChanged("email", this._email, value);


                this._email = value;
            }
        }

        /// <summary>
        ///  head_ico,
        /// </summary>

        [DbProperty(MapingColumnName = "head_ico", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 250, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string head_ico
        {
            get
            {
                return this._head_ico;
            }
            set
            {
                this.OnPropertyChanged("head_ico", this._head_ico, value);


                this._head_ico = value;
            }
        }

        #endregion


        #region 私有变量

        private int _user_id;

        private string _true_name;

        private string _telephone;

        private string _mobile;

        private string _area;

        private string _contact_addr;

        private string _qq;

        private string _msn;

        private int _sex;

        private DateTime? _birthday;

        private int? _group_id;

        private int _exp;

        private int _point;

        private string _message_ids;

        private DateTime _time;

        private string _zip;

        private int _status;

        private string _prop;

        private decimal _balance;

        private DateTime? _last_login;

        private string _custom;

        #endregion

        #region 属性

        /// <summary>
        ///  user_id,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "user_id", DbTypeString = "int", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  true_name,
        /// </summary>

        [DbProperty(MapingColumnName = "true_name", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string true_name
        {
            get
            {
                return this._true_name;
            }
            set
            {
                this.OnPropertyChanged("true_name", this._true_name, value);


                this._true_name = value;
            }
        }

        /// <summary>
        ///  telephone,
        /// </summary>

        [DbProperty(MapingColumnName = "telephone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string telephone
        {
            get
            {
                return this._telephone;
            }
            set
            {
                this.OnPropertyChanged("telephone", this._telephone, value);


                this._telephone = value;
            }
        }

        /// <summary>
        ///  mobile,
        /// </summary>

        [DbProperty(MapingColumnName = "mobile", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  area,
        /// </summary>

        [DbProperty(MapingColumnName = "area", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string area
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
        ///  contact_addr,
        /// </summary>

        [DbProperty(MapingColumnName = "contact_addr", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 250, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string contact_addr
        {
            get
            {
                return this._contact_addr;
            }
            set
            {
                this.OnPropertyChanged("contact_addr", this._contact_addr, value);


                this._contact_addr = value;
            }
        }

        /// <summary>
        ///  qq,
        /// </summary>

        [DbProperty(MapingColumnName = "qq", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 15, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public string qq
        {
            get
            {
                return this._qq;
            }
            set
            {
                this.OnPropertyChanged("qq", this._qq, value);


                this._qq = value;
            }
        }

        /// <summary>
        ///  msn,
        /// </summary>

        [DbProperty(MapingColumnName = "msn", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 250, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public string msn
        {
            get
            {
                return this._msn;
            }
            set
            {
                this.OnPropertyChanged("msn", this._msn, value);


                this._msn = value;
            }
        }

        /// <summary>
        ///  sex,
        /// </summary>

        [DbProperty(MapingColumnName = "sex", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((1))")]

        public int sex
        {
            get
            {
                return this._sex;
            }
            set
            {
                this.OnPropertyChanged("sex", this._sex, value);


                this._sex = value;
            }
        }

        /// <summary>
        ///  birthday,
        /// </summary>

        [DbProperty(MapingColumnName = "birthday", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? birthday
        {
            get
            {
                return this._birthday;
            }
            set
            {
                this.OnPropertyChanged("birthday", this._birthday, value);


                this._birthday = value;
            }
        }

        /// <summary>
        ///  group_id,
        /// </summary>

        [DbProperty(MapingColumnName = "group_id", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public int? group_id
        {
            get
            {
                return this._group_id;
            }
            set
            {
                this.OnPropertyChanged("group_id", this._group_id, value);


                this._group_id = value;
            }
        }

        /// <summary>
        ///  exp,
        /// </summary>

        [DbProperty(MapingColumnName = "exp", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]

        public int exp
        {
            get
            {
                return this._exp;
            }
            set
            {
                this.OnPropertyChanged("exp", this._exp, value);


                this._exp = value;
            }
        }

        /// <summary>
        ///  point,
        /// </summary>

        [DbProperty(MapingColumnName = "point", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0))")]

        public int point
        {
            get
            {
                return this._point;
            }
            set
            {
                this.OnPropertyChanged("point", this._point, value);


                this._point = value;
            }
        }

        /// <summary>
        ///  message_ids,
        /// </summary>

        [DbProperty(MapingColumnName = "message_ids", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public string message_ids
        {
            get
            {
                return this._message_ids;
            }
            set
            {
                this.OnPropertyChanged("message_ids", this._message_ids, value);


                this._message_ids = value;
            }
        }

        /// <summary>
        ///  time,
        /// </summary>

        [DbProperty(MapingColumnName = "time", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime time
        {
            get
            {
                return this._time;
            }
            set
            {
                this.OnPropertyChanged("time", this._time, value);


                this._time = value;
            }
        }

        /// <summary>
        ///  zip,
        /// </summary>

        [DbProperty(MapingColumnName = "zip", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 10, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

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
        ///  status,
        /// </summary>

        [DbProperty(MapingColumnName = "status", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((1))")]

        public int status
        {
            get
            {
                return this._status;
            }
            set
            {
                this.OnPropertyChanged("status", this._status, value);


                this._status = value;
            }
        }

        /// <summary>
        ///  prop,
        /// </summary>

        [DbProperty(MapingColumnName = "prop", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public string prop
        {
            get
            {
                return this._prop;
            }
            set
            {
                this.OnPropertyChanged("prop", this._prop, value);


                this._prop = value;
            }
        }

        /// <summary>
        ///  balance,
        /// </summary>

        [DbProperty(MapingColumnName = "balance", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "((0.00))")]

        public decimal balance
        {
            get
            {
                return this._balance;
            }
            set
            {
                this.OnPropertyChanged("balance", this._balance, value);


                this._balance = value;
            }
        }

        /// <summary>
        ///  last_login,
        /// </summary>

        [DbProperty(MapingColumnName = "last_login", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public DateTime? last_login
        {
            get
            {
                return this._last_login;
            }
            set
            {
                this.OnPropertyChanged("last_login", this._last_login, value);


                this._last_login = value;
            }
        }

        /// <summary>
        ///  custom,
        /// </summary>

        [DbProperty(MapingColumnName = "custom", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(NULL)")]

        public string custom
        {
            get
            {
                return this._custom;
            }
            set
            {
                this.OnPropertyChanged("custom", this._custom, value);


                this._custom = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                user_id = new PropertyItem("user_id", tableName);

                true_name = new PropertyItem("true_name", tableName);

                telephone = new PropertyItem("telephone", tableName);

                mobile = new PropertyItem("mobile", tableName);

                area = new PropertyItem("area", tableName);

                contact_addr = new PropertyItem("contact_addr", tableName);

                qq = new PropertyItem("qq", tableName);

                msn = new PropertyItem("msn", tableName);

                sex = new PropertyItem("sex", tableName);

                birthday = new PropertyItem("birthday", tableName);

                group_id = new PropertyItem("group_id", tableName);

                exp = new PropertyItem("exp", tableName);

                point = new PropertyItem("point", tableName);

                message_ids = new PropertyItem("message_ids", tableName);

                time = new PropertyItem("time", tableName);

                zip = new PropertyItem("zip", tableName);

                status = new PropertyItem("status", tableName);

                prop = new PropertyItem("prop", tableName);

                balance = new PropertyItem("balance", tableName);

                last_login = new PropertyItem("last_login", tableName);

                custom = new PropertyItem("custom", tableName);

                id = new PropertyItem("id", tableName);

                username = new PropertyItem("username", tableName);

                password = new PropertyItem("password", tableName);

                email = new PropertyItem("email", tableName);

                head_ico = new PropertyItem("head_ico", tableName);
            }
            /// <summary>
            /// user_id,
            /// </summary> 
            public PropertyItem user_id = null;
            /// <summary>
            /// true_name,
            /// </summary> 
            public PropertyItem true_name = null;
            /// <summary>
            /// telephone,
            /// </summary> 
            public PropertyItem telephone = null;
            /// <summary>
            /// mobile,
            /// </summary> 
            public PropertyItem mobile = null;
            /// <summary>
            /// area,
            /// </summary> 
            public PropertyItem area = null;
            /// <summary>
            /// contact_addr,
            /// </summary> 
            public PropertyItem contact_addr = null;
            /// <summary>
            /// qq,
            /// </summary> 
            public PropertyItem qq = null;
            /// <summary>
            /// msn,
            /// </summary> 
            public PropertyItem msn = null;
            /// <summary>
            /// sex,
            /// </summary> 
            public PropertyItem sex = null;
            /// <summary>
            /// birthday,
            /// </summary> 
            public PropertyItem birthday = null;
            /// <summary>
            /// group_id,
            /// </summary> 
            public PropertyItem group_id = null;
            /// <summary>
            /// exp,
            /// </summary> 
            public PropertyItem exp = null;
            /// <summary>
            /// point,
            /// </summary> 
            public PropertyItem point = null;
            /// <summary>
            /// message_ids,
            /// </summary> 
            public PropertyItem message_ids = null;
            /// <summary>
            /// time,
            /// </summary> 
            public PropertyItem time = null;
            /// <summary>
            /// zip,
            /// </summary> 
            public PropertyItem zip = null;
            /// <summary>
            /// status,
            /// </summary> 
            public PropertyItem status = null;
            /// <summary>
            /// prop,
            /// </summary> 
            public PropertyItem prop = null;
            /// <summary>
            /// balance,
            /// </summary> 
            public PropertyItem balance = null;
            /// <summary>
            /// last_login,
            /// </summary> 
            public PropertyItem last_login = null;
            /// <summary>
            /// custom,
            /// </summary> 
            public PropertyItem custom = null;

            /// <summary>
            /// id,
            /// </summary> 
            public PropertyItem id = null;
            /// <summary>
            /// username,
            /// </summary> 
            public PropertyItem username = null;
            /// <summary>
            /// password,
            /// </summary> 
            public PropertyItem password = null;
            /// <summary>
            /// email,
            /// </summary> 
            public PropertyItem email = null;
            /// <summary>
            /// head_ico,
            /// </summary> 
            public PropertyItem head_ico = null;
        }
        #endregion
    }
}
