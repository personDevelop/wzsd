using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportData.OldEntity
{
    /// <summary>
    /// h7_user
    /// </summary>  
     
    public partial class h7_user : BaseEntity
    {
        public static Column _ = new Column("h7_user");

        public h7_user()
        {
            this.TableName = "h7_user";
            OnCreate();
        }


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

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                id = new PropertyItem("id", tableName);

                username = new PropertyItem("username", tableName);

                password = new PropertyItem("password", tableName);

                email = new PropertyItem("email", tableName);

                head_ico = new PropertyItem("head_ico", tableName);


            }
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
