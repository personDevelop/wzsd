using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportData.OldEntity
{
    /// <summary>
    /// h7_order
    /// </summary>  
    
    public partial class h7_order : BaseEntity
    {
        public static Column _ = new Column("h7_order");

        public h7_order()
        {
            this.TableName = "h7_order";
            OnCreate();
        }


        #region 私有变量

        private int _id;

        private string _order_no;

        private int _user_id;

        private int _pay_type;

        private int? _distribution;

        private int? _status;

        private int? _pay_status;

        private int? _distribution_status;

        private string _accept_name;

        private string _postcode;

        private string _telphone;

        private int? _country;

        private int? _province;

        private int? _city;

        private int? _area;

        private string _address;

        private string _mobile;

        private decimal? _payable_amount;

        private decimal _real_amount;

        private decimal _payable_freight;

        private decimal _real_freight;

        private DateTime? _pay_time;

        private DateTime? _send_time;

        private DateTime? _create_time;

        private DateTime? _completion_time;

        private int _invoice;

        private string _postscript;

        private string _note;

        private int? _if_del;

        private decimal _insured;

        private int? _if_insured;

        private decimal _pay_fee;

        private string _invoice_title;

        private decimal _taxes;

        private decimal _promotions;

        private decimal _discount;

        private decimal _order_amount;

        private string _if_print;

        private string _prop;

        private string _accept_time;

        private int _exp;

        private int _point;

        private int _type;

        private string _trade_no;

        #endregion

        #region 属性

        /// <summary>
        ///  id,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "id", DbTypeString = "int", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  order_no,
        /// </summary>

        [DbProperty(MapingColumnName = "order_no", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string order_no
        {
            get
            {
                return this._order_no;
            }
            set
            {
                this.OnPropertyChanged("order_no", this._order_no, value);


                this._order_no = value;
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
        ///  pay_type,
        /// </summary>

        [DbProperty(MapingColumnName = "pay_type", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int pay_type
        {
            get
            {
                return this._pay_type;
            }
            set
            {
                this.OnPropertyChanged("pay_type", this._pay_type, value);


                this._pay_type = value;
            }
        }

        /// <summary>
        ///  distribution,
        /// </summary>

        [DbProperty(MapingColumnName = "distribution", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int? distribution
        {
            get
            {
                return this._distribution;
            }
            set
            {
                this.OnPropertyChanged("distribution", this._distribution, value);


                this._distribution = value;
            }
        }

        /// <summary>
        ///  status,
        /// </summary>

        [DbProperty(MapingColumnName = "status", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int? status
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
        ///  pay_status,
        /// </summary>

        [DbProperty(MapingColumnName = "pay_status", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int? pay_status
        {
            get
            {
                return this._pay_status;
            }
            set
            {
                this.OnPropertyChanged("pay_status", this._pay_status, value);


                this._pay_status = value;
            }
        }

        /// <summary>
        ///  distribution_status,
        /// </summary>

        [DbProperty(MapingColumnName = "distribution_status", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int? distribution_status
        {
            get
            {
                return this._distribution_status;
            }
            set
            {
                this.OnPropertyChanged("distribution_status", this._distribution_status, value);


                this._distribution_status = value;
            }
        }

        /// <summary>
        ///  accept_name,
        /// </summary>

        [DbProperty(MapingColumnName = "accept_name", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  postcode,
        /// </summary>

        [DbProperty(MapingColumnName = "postcode", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 6, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string postcode
        {
            get
            {
                return this._postcode;
            }
            set
            {
                this.OnPropertyChanged("postcode", this._postcode, value);


                this._postcode = value;
            }
        }

        /// <summary>
        ///  telphone,
        /// </summary>

        [DbProperty(MapingColumnName = "telphone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        [DbProperty(MapingColumnName = "country", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        [DbProperty(MapingColumnName = "province", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int? province
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

        [DbProperty(MapingColumnName = "city", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int? city
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

        [DbProperty(MapingColumnName = "area", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int? area
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

        [DbProperty(MapingColumnName = "address", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 250, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  payable_amount,
        /// </summary>

        [DbProperty(MapingColumnName = "payable_amount", DbTypeString = "decimal", ColumnIsNull = true, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal? payable_amount
        {
            get
            {
                return this._payable_amount;
            }
            set
            {
                this.OnPropertyChanged("payable_amount", this._payable_amount, value);


                this._payable_amount = value;
            }
        }

        /// <summary>
        ///  real_amount,
        /// </summary>

        [DbProperty(MapingColumnName = "real_amount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal real_amount
        {
            get
            {
                return this._real_amount;
            }
            set
            {
                this.OnPropertyChanged("real_amount", this._real_amount, value);


                this._real_amount = value;
            }
        }

        /// <summary>
        ///  payable_freight,
        /// </summary>

        [DbProperty(MapingColumnName = "payable_freight", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal payable_freight
        {
            get
            {
                return this._payable_freight;
            }
            set
            {
                this.OnPropertyChanged("payable_freight", this._payable_freight, value);


                this._payable_freight = value;
            }
        }

        /// <summary>
        ///  real_freight,
        /// </summary>

        [DbProperty(MapingColumnName = "real_freight", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal real_freight
        {
            get
            {
                return this._real_freight;
            }
            set
            {
                this.OnPropertyChanged("real_freight", this._real_freight, value);


                this._real_freight = value;
            }
        }

        /// <summary>
        ///  pay_time,
        /// </summary>

        [DbProperty(MapingColumnName = "pay_time", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? pay_time
        {
            get
            {
                return this._pay_time;
            }
            set
            {
                this.OnPropertyChanged("pay_time", this._pay_time, value);


                this._pay_time = value;
            }
        }

        /// <summary>
        ///  send_time,
        /// </summary>

        [DbProperty(MapingColumnName = "send_time", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? send_time
        {
            get
            {
                return this._send_time;
            }
            set
            {
                this.OnPropertyChanged("send_time", this._send_time, value);


                this._send_time = value;
            }
        }

        /// <summary>
        ///  create_time,
        /// </summary>

        [DbProperty(MapingColumnName = "create_time", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? create_time
        {
            get
            {
                return this._create_time;
            }
            set
            {
                this.OnPropertyChanged("create_time", this._create_time, value);


                this._create_time = value;
            }
        }

        /// <summary>
        ///  completion_time,
        /// </summary>

        [DbProperty(MapingColumnName = "completion_time", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? completion_time
        {
            get
            {
                return this._completion_time;
            }
            set
            {
                this.OnPropertyChanged("completion_time", this._completion_time, value);


                this._completion_time = value;
            }
        }

        /// <summary>
        ///  invoice,
        /// </summary>

        [DbProperty(MapingColumnName = "invoice", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int invoice
        {
            get
            {
                return this._invoice;
            }
            set
            {
                this.OnPropertyChanged("invoice", this._invoice, value);


                this._invoice = value;
            }
        }

        /// <summary>
        ///  postscript,
        /// </summary>

        [DbProperty(MapingColumnName = "postscript", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string postscript
        {
            get
            {
                return this._postscript;
            }
            set
            {
                this.OnPropertyChanged("postscript", this._postscript, value);


                this._postscript = value;
            }
        }

        /// <summary>
        ///  note,
        /// </summary>

        [DbProperty(MapingColumnName = "note", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string note
        {
            get
            {
                return this._note;
            }
            set
            {
                this.OnPropertyChanged("note", this._note, value);


                this._note = value;
            }
        }

        /// <summary>
        ///  if_del,
        /// </summary>

        [DbProperty(MapingColumnName = "if_del", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int? if_del
        {
            get
            {
                return this._if_del;
            }
            set
            {
                this.OnPropertyChanged("if_del", this._if_del, value);


                this._if_del = value;
            }
        }

        /// <summary>
        ///  insured,
        /// </summary>

        [DbProperty(MapingColumnName = "insured", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal insured
        {
            get
            {
                return this._insured;
            }
            set
            {
                this.OnPropertyChanged("insured", this._insured, value);


                this._insured = value;
            }
        }

        /// <summary>
        ///  if_insured,
        /// </summary>

        [DbProperty(MapingColumnName = "if_insured", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int? if_insured
        {
            get
            {
                return this._if_insured;
            }
            set
            {
                this.OnPropertyChanged("if_insured", this._if_insured, value);


                this._if_insured = value;
            }
        }

        /// <summary>
        ///  pay_fee,
        /// </summary>

        [DbProperty(MapingColumnName = "pay_fee", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal pay_fee
        {
            get
            {
                return this._pay_fee;
            }
            set
            {
                this.OnPropertyChanged("pay_fee", this._pay_fee, value);


                this._pay_fee = value;
            }
        }

        /// <summary>
        ///  invoice_title,
        /// </summary>

        [DbProperty(MapingColumnName = "invoice_title", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string invoice_title
        {
            get
            {
                return this._invoice_title;
            }
            set
            {
                this.OnPropertyChanged("invoice_title", this._invoice_title, value);


                this._invoice_title = value;
            }
        }

        /// <summary>
        ///  taxes,
        /// </summary>

        [DbProperty(MapingColumnName = "taxes", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal taxes
        {
            get
            {
                return this._taxes;
            }
            set
            {
                this.OnPropertyChanged("taxes", this._taxes, value);


                this._taxes = value;
            }
        }

        /// <summary>
        ///  promotions,
        /// </summary>

        [DbProperty(MapingColumnName = "promotions", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal promotions
        {
            get
            {
                return this._promotions;
            }
            set
            {
                this.OnPropertyChanged("promotions", this._promotions, value);


                this._promotions = value;
            }
        }

        /// <summary>
        ///  discount,
        /// </summary>

        [DbProperty(MapingColumnName = "discount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal discount
        {
            get
            {
                return this._discount;
            }
            set
            {
                this.OnPropertyChanged("discount", this._discount, value);


                this._discount = value;
            }
        }

        /// <summary>
        ///  order_amount,
        /// </summary>

        [DbProperty(MapingColumnName = "order_amount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal order_amount
        {
            get
            {
                return this._order_amount;
            }
            set
            {
                this.OnPropertyChanged("order_amount", this._order_amount, value);


                this._order_amount = value;
            }
        }

        /// <summary>
        ///  if_print,
        /// </summary>

        [DbProperty(MapingColumnName = "if_print", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string if_print
        {
            get
            {
                return this._if_print;
            }
            set
            {
                this.OnPropertyChanged("if_print", this._if_print, value);


                this._if_print = value;
            }
        }

        /// <summary>
        ///  prop,
        /// </summary>

        [DbProperty(MapingColumnName = "prop", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  accept_time,
        /// </summary>

        [DbProperty(MapingColumnName = "accept_time", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 80, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string accept_time
        {
            get
            {
                return this._accept_time;
            }
            set
            {
                this.OnPropertyChanged("accept_time", this._accept_time, value);


                this._accept_time = value;
            }
        }

        /// <summary>
        ///  exp,
        /// </summary>

        [DbProperty(MapingColumnName = "exp", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        [DbProperty(MapingColumnName = "point", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  type,
        /// </summary>

        [DbProperty(MapingColumnName = "type", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this.OnPropertyChanged("type", this._type, value);


                this._type = value;
            }
        }

        /// <summary>
        ///  trade_no,
        /// </summary>

        [DbProperty(MapingColumnName = "trade_no", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 255, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string trade_no
        {
            get
            {
                return this._trade_no;
            }
            set
            {
                this.OnPropertyChanged("trade_no", this._trade_no, value);


                this._trade_no = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                id = new PropertyItem("id", tableName);

                order_no = new PropertyItem("order_no", tableName);

                user_id = new PropertyItem("user_id", tableName);

                pay_type = new PropertyItem("pay_type", tableName);

                distribution = new PropertyItem("distribution", tableName);

                status = new PropertyItem("status", tableName);

                pay_status = new PropertyItem("pay_status", tableName);

                distribution_status = new PropertyItem("distribution_status", tableName);

                accept_name = new PropertyItem("accept_name", tableName);

                postcode = new PropertyItem("postcode", tableName);

                telphone = new PropertyItem("telphone", tableName);

                country = new PropertyItem("country", tableName);

                province = new PropertyItem("province", tableName);

                city = new PropertyItem("city", tableName);

                area = new PropertyItem("area", tableName);

                address = new PropertyItem("address", tableName);

                mobile = new PropertyItem("mobile", tableName);

                payable_amount = new PropertyItem("payable_amount", tableName);

                real_amount = new PropertyItem("real_amount", tableName);

                payable_freight = new PropertyItem("payable_freight", tableName);

                real_freight = new PropertyItem("real_freight", tableName);

                pay_time = new PropertyItem("pay_time", tableName);

                send_time = new PropertyItem("send_time", tableName);

                create_time = new PropertyItem("create_time", tableName);

                completion_time = new PropertyItem("completion_time", tableName);

                invoice = new PropertyItem("invoice", tableName);

                postscript = new PropertyItem("postscript", tableName);

                note = new PropertyItem("note", tableName);

                if_del = new PropertyItem("if_del", tableName);

                insured = new PropertyItem("insured", tableName);

                if_insured = new PropertyItem("if_insured", tableName);

                pay_fee = new PropertyItem("pay_fee", tableName);

                invoice_title = new PropertyItem("invoice_title", tableName);

                taxes = new PropertyItem("taxes", tableName);

                promotions = new PropertyItem("promotions", tableName);

                discount = new PropertyItem("discount", tableName);

                order_amount = new PropertyItem("order_amount", tableName);

                if_print = new PropertyItem("if_print", tableName);

                prop = new PropertyItem("prop", tableName);

                accept_time = new PropertyItem("accept_time", tableName);

                exp = new PropertyItem("exp", tableName);

                point = new PropertyItem("point", tableName);

                type = new PropertyItem("type", tableName);

                trade_no = new PropertyItem("trade_no", tableName);


            }
            /// <summary>
            /// id,
            /// </summary> 
            public PropertyItem id = null;
            /// <summary>
            /// order_no,
            /// </summary> 
            public PropertyItem order_no = null;
            /// <summary>
            /// user_id,
            /// </summary> 
            public PropertyItem user_id = null;
            /// <summary>
            /// pay_type,
            /// </summary> 
            public PropertyItem pay_type = null;
            /// <summary>
            /// distribution,
            /// </summary> 
            public PropertyItem distribution = null;
            /// <summary>
            /// status,
            /// </summary> 
            public PropertyItem status = null;
            /// <summary>
            /// pay_status,
            /// </summary> 
            public PropertyItem pay_status = null;
            /// <summary>
            /// distribution_status,
            /// </summary> 
            public PropertyItem distribution_status = null;
            /// <summary>
            /// accept_name,
            /// </summary> 
            public PropertyItem accept_name = null;
            /// <summary>
            /// postcode,
            /// </summary> 
            public PropertyItem postcode = null;
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
            /// payable_amount,
            /// </summary> 
            public PropertyItem payable_amount = null;
            /// <summary>
            /// real_amount,
            /// </summary> 
            public PropertyItem real_amount = null;
            /// <summary>
            /// payable_freight,
            /// </summary> 
            public PropertyItem payable_freight = null;
            /// <summary>
            /// real_freight,
            /// </summary> 
            public PropertyItem real_freight = null;
            /// <summary>
            /// pay_time,
            /// </summary> 
            public PropertyItem pay_time = null;
            /// <summary>
            /// send_time,
            /// </summary> 
            public PropertyItem send_time = null;
            /// <summary>
            /// create_time,
            /// </summary> 
            public PropertyItem create_time = null;
            /// <summary>
            /// completion_time,
            /// </summary> 
            public PropertyItem completion_time = null;
            /// <summary>
            /// invoice,
            /// </summary> 
            public PropertyItem invoice = null;
            /// <summary>
            /// postscript,
            /// </summary> 
            public PropertyItem postscript = null;
            /// <summary>
            /// note,
            /// </summary> 
            public PropertyItem note = null;
            /// <summary>
            /// if_del,
            /// </summary> 
            public PropertyItem if_del = null;
            /// <summary>
            /// insured,
            /// </summary> 
            public PropertyItem insured = null;
            /// <summary>
            /// if_insured,
            /// </summary> 
            public PropertyItem if_insured = null;
            /// <summary>
            /// pay_fee,
            /// </summary> 
            public PropertyItem pay_fee = null;
            /// <summary>
            /// invoice_title,
            /// </summary> 
            public PropertyItem invoice_title = null;
            /// <summary>
            /// taxes,
            /// </summary> 
            public PropertyItem taxes = null;
            /// <summary>
            /// promotions,
            /// </summary> 
            public PropertyItem promotions = null;
            /// <summary>
            /// discount,
            /// </summary> 
            public PropertyItem discount = null;
            /// <summary>
            /// order_amount,
            /// </summary> 
            public PropertyItem order_amount = null;
            /// <summary>
            /// if_print,
            /// </summary> 
            public PropertyItem if_print = null;
            /// <summary>
            /// prop,
            /// </summary> 
            public PropertyItem prop = null;
            /// <summary>
            /// accept_time,
            /// </summary> 
            public PropertyItem accept_time = null;
            /// <summary>
            /// exp,
            /// </summary> 
            public PropertyItem exp = null;
            /// <summary>
            /// point,
            /// </summary> 
            public PropertyItem point = null;
            /// <summary>
            /// type,
            /// </summary> 
            public PropertyItem type = null;
            /// <summary>
            /// trade_no,
            /// </summary> 
            public PropertyItem trade_no = null;
        }
        #endregion
    }

}
