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
    /// App设置
    /// </summary>  
    [JsonObject]
    public partial class AppSet : BaseEntity
    {
        public static Column _ = new Column("AppSet");

        public AppSet()
        {
            this.TableName = "AppSet";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private string _Logo;

        private string _CopyRight;

        private string _Contactor;

        private string _LoginImg;

        private int _LoginImgVersion;

        #endregion

        #region 属性

        /// <summary>
        ///  主键,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  Logo,
        /// </summary>

        [DbProperty(MapingColumnName = "Logo", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Logo
        {
            get
            {
                return this._Logo;
            }
            set
            {
                this.OnPropertyChanged("Logo", this._Logo, value);
                this._Logo = value;
            }
        }

        /// <summary>
        ///  版权信息,
        /// </summary>

        [DbProperty(MapingColumnName = "CopyRight", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CopyRight
        {
            get
            {
                return this._CopyRight;
            }
            set
            {
                this.OnPropertyChanged("CopyRight", this._CopyRight, value);
                this._CopyRight = value;
            }
        }

        /// <summary>
        ///  联系信息,
        /// </summary>

        [DbProperty(MapingColumnName = "Contactor", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Contactor
        {
            get
            {
                return this._Contactor;
            }
            set
            {
                this.OnPropertyChanged("Contactor", this._Contactor, value);
                this._Contactor = value;
            }
        }

        /// <summary>
        ///  启动页图片,
        /// </summary>

        [DbProperty(MapingColumnName = "LoginImg", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string LoginImg
        {
            get
            {
                return this._LoginImg;
            }
            set
            {
                this.OnPropertyChanged("LoginImg", this._LoginImg, value);
                this._LoginImg = value;
            }
        }

        /// <summary>
        ///  版本,
        /// </summary>

        [DbProperty(MapingColumnName = "LoginImgVersion", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int LoginImgVersion
        {
            get
            {
                return this._LoginImgVersion;
            }
            set
            {
                this.OnPropertyChanged("LoginImgVersion", this._LoginImgVersion, value);
                this._LoginImgVersion = value;
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

                Name = new PropertyItem("Name", tableName);

                Logo = new PropertyItem("Logo", tableName);

                CopyRight = new PropertyItem("CopyRight", tableName);

                Contactor = new PropertyItem("Contactor", tableName);

                LoginImg = new PropertyItem("LoginImg", tableName);

                LoginImgVersion = new PropertyItem("LoginImgVersion", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// Logo,
            /// </summary> 
            public PropertyItem Logo = null;
            /// <summary>
            /// 版权信息,
            /// </summary> 
            public PropertyItem CopyRight = null;
            /// <summary>
            /// 联系信息,
            /// </summary> 
            public PropertyItem Contactor = null;
            /// <summary>
            /// 启动页图片,
            /// </summary> 
            public PropertyItem LoginImg = null;
            /// <summary>
            /// 版本,
            /// </summary> 
            public PropertyItem LoginImgVersion = null;
        }
        #endregion
    }
}
