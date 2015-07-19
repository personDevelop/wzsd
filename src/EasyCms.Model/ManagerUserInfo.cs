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
    /// 管理员用户表
    /// </summary>  
    [JsonObject]
    public partial class ManagerUserInfo : BaseEntity
    {
        public static Column _ = new Column("ManagerUserInfo");

        public ManagerUserInfo()
        {
            this.TableName = "ManagerUserInfo";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Pwd;

        private string _Name;

        private string _Email;

        private string _QQ;

        private string _Photo;

        private string _NickyName;

        private string _Signature;

        private string _IDNumber;

        private DateTime? _Birthday;

        private int _Sex;

        private string _ContactPhone;

        private bool _IsManager;

        private DateTime _CreateDate;

        private DateTime _LastModifyDate;

        private DateTime _StatusChangeDate;

        private int _Status;

        private string _Note;

        #endregion

        #region 属性

        /// <summary>
        ///  用户ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  编号,
        /// </summary>

        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  密码,
        /// </summary>

        [DbProperty(MapingColumnName = "Pwd", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Pwd
        {
            get
            {
                return this._Pwd;
            }
            set
            {
                this.OnPropertyChanged("Pwd", this._Pwd, value);
                this._Pwd = value;
            }
        }

        /// <summary>
        ///  姓名,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  Email,
        /// </summary>

        [DbProperty(MapingColumnName = "Email", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this.OnPropertyChanged("Email", this._Email, value);
                this._Email = value;
            }
        }

        /// <summary>
        ///  QQ,
        /// </summary>

        [DbProperty(MapingColumnName = "QQ", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string QQ
        {
            get
            {
                return this._QQ;
            }
            set
            {
                this.OnPropertyChanged("QQ", this._QQ, value);
                this._QQ = value;
            }
        }

        /// <summary>
        ///  头像,
        /// </summary>

        [DbProperty(MapingColumnName = "Photo", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Photo
        {
            get
            {
                return this._Photo;
            }
            set
            {
                this.OnPropertyChanged("Photo", this._Photo, value);
                this._Photo = value;
            }
        }

        /// <summary>
        ///  昵称,
        /// </summary>

        [DbProperty(MapingColumnName = "NickyName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string NickyName
        {
            get
            {
                return this._NickyName;
            }
            set
            {
                this.OnPropertyChanged("NickyName", this._NickyName, value);
                this._NickyName = value;
            }
        }

        /// <summary>
        ///  个性签名,
        /// </summary>

        [DbProperty(MapingColumnName = "Signature", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Signature
        {
            get
            {
                return this._Signature;
            }
            set
            {
                this.OnPropertyChanged("Signature", this._Signature, value);
                this._Signature = value;
            }
        }

        /// <summary>
        ///  身份证,
        /// </summary>

        [DbProperty(MapingColumnName = "IDNumber", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string IDNumber
        {
            get
            {
                return this._IDNumber;
            }
            set
            {
                this.OnPropertyChanged("IDNumber", this._IDNumber, value);
                this._IDNumber = value;
            }
        }

        /// <summary>
        ///  生日,
        /// </summary>

        [DbProperty(MapingColumnName = "Birthday", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? Birthday
        {
            get
            {
                return this._Birthday;
            }
            set
            {
                this.OnPropertyChanged("Birthday", this._Birthday, value);
                this._Birthday = value;
            }
        }

        /// <summary>
        ///  性别,
        /// </summary>

        [DbProperty(MapingColumnName = "Sex", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Sex
        {
            get
            {
                return this._Sex;
            }
            set
            {
                this.OnPropertyChanged("Sex", this._Sex, value);
                this._Sex = value;
            }
        }

        /// <summary>
        ///  联系手机,
        /// </summary>

        [DbProperty(MapingColumnName = "ContactPhone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  是否是后台管理员,
        /// </summary>

        [DbProperty(MapingColumnName = "IsManager", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsManager
        {
            get
            {
                return this._IsManager;
            }
            set
            {
                this.OnPropertyChanged("IsManager", this._IsManager, value);
                this._IsManager = value;
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

        [DbProperty(MapingColumnName = "LastModifyDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime LastModifyDate
        {
            get
            {
                return this._LastModifyDate;
            }
            set
            {
                this.OnPropertyChanged("LastModifyDate", this._LastModifyDate, value);
                this._LastModifyDate = value;
            }
        }

        /// <summary>
        ///  状态变更日期,
        /// </summary>

        [DbProperty(MapingColumnName = "StatusChangeDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime StatusChangeDate
        {
            get
            {
                return this._StatusChangeDate;
            }
            set
            {
                this.OnPropertyChanged("StatusChangeDate", this._StatusChangeDate, value);
                this._StatusChangeDate = value;
            }
        }

        /// <summary>
        ///  状态,
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

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 2000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

                Code = new PropertyItem("Code", tableName);

                Pwd = new PropertyItem("Pwd", tableName);

                Name = new PropertyItem("Name", tableName);

                Email = new PropertyItem("Email", tableName);

                QQ = new PropertyItem("QQ", tableName);

                Photo = new PropertyItem("Photo", tableName);

                NickyName = new PropertyItem("NickyName", tableName);

                Signature = new PropertyItem("Signature", tableName);

                IDNumber = new PropertyItem("IDNumber", tableName);

                Birthday = new PropertyItem("Birthday", tableName);

                Sex = new PropertyItem("Sex", tableName);

                ContactPhone = new PropertyItem("ContactPhone", tableName);

                IsManager = new PropertyItem("IsManager", tableName);

                CreateDate = new PropertyItem("CreateDate", tableName);

                LastModifyDate = new PropertyItem("LastModifyDate", tableName);

                StatusChangeDate = new PropertyItem("StatusChangeDate", tableName);

                Status = new PropertyItem("Status", tableName);

                Note = new PropertyItem("Note", tableName);


            }
            /// <summary>
            /// 用户ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 密码,
            /// </summary> 
            public PropertyItem Pwd = null;
            /// <summary>
            /// 姓名,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// Email,
            /// </summary> 
            public PropertyItem Email = null;
            /// <summary>
            /// QQ,
            /// </summary> 
            public PropertyItem QQ = null;
            /// <summary>
            /// 头像,
            /// </summary> 
            public PropertyItem Photo = null;
            /// <summary>
            /// 昵称,
            /// </summary> 
            public PropertyItem NickyName = null;
            /// <summary>
            /// 个性签名,
            /// </summary> 
            public PropertyItem Signature = null;
            /// <summary>
            /// 身份证,
            /// </summary> 
            public PropertyItem IDNumber = null;
            /// <summary>
            /// 生日,
            /// </summary> 
            public PropertyItem Birthday = null;
            /// <summary>
            /// 性别,
            /// </summary> 
            public PropertyItem Sex = null;
            /// <summary>
            /// 联系手机,
            /// </summary> 
            public PropertyItem ContactPhone = null;
            /// <summary>
            /// 是否是后台管理员,
            /// </summary> 
            public PropertyItem IsManager = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CreateDate = null;
            /// <summary>
            /// 最后修改日期,
            /// </summary> 
            public PropertyItem LastModifyDate = null;
            /// <summary>
            /// 状态变更日期,
            /// </summary> 
            public PropertyItem StatusChangeDate = null;
            /// <summary>
            /// 状态,
            /// </summary> 
            public PropertyItem Status = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
        }
        #endregion
    }

    public partial class ManagerUserInfo
    {
        protected override void OnCreate()
        {
            CreateDate = LastModifyDate = StatusChangeDate = DateTime.Now;
        }
    }

}
