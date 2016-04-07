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
    /// 友情链接 
    /// </summary>  
    [JsonObject]
    public partial class FriendlyLink : BaseEntity
    {
        public static Column _ = new Column("FriendlyLink");

        public FriendlyLink()
        {
            this.TableName = "FriendlyLink";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Name;

        private string _LinkAlt;

        private string _LinkUrl;

        private string _LogoUrl;

        private int _OrderNo;

        private string _GroupTag;

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
        ///  链接名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  链接提示,
        /// </summary>

        [DbProperty(MapingColumnName = "LinkAlt", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = true, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string LinkAlt
        {
            get
            {
                return this._LinkAlt;
            }
            set
            {
                this.OnPropertyChanged("LinkAlt", this._LinkAlt, value);
                this._LinkAlt = value;
            }
        }

        /// <summary>
        ///  链接地址,
        /// </summary>

        [DbProperty(MapingColumnName = "LinkUrl", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string LinkUrl
        {
            get
            {
                return this._LinkUrl;
            }
            set
            {
                this.OnPropertyChanged("LinkUrl", this._LinkUrl, value);
                this._LinkUrl = value;
            }
        }

        /// <summary>
        ///  Logo地址,
        /// </summary>

        [DbProperty(MapingColumnName = "LogoUrl", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string LogoUrl
        {
            get
            {
                return this._LogoUrl;
            }
            set
            {
                this.OnPropertyChanged("LogoUrl", this._LogoUrl, value);
                this._LogoUrl = value;
            }
        }

        /// <summary>
        ///  排序,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderNo", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int OrderNo
        {
            get
            {
                return this._OrderNo;
            }
            set
            {
                this.OnPropertyChanged("Order", this._OrderNo, value);
                this._OrderNo = value;
            }
        }

        /// <summary>
        ///  分组标识,可以对友情链接进行分组
        /// </summary>

        [DbProperty(MapingColumnName = "GroupTag", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string GroupTag
        {
            get
            {
                return this._GroupTag;
            }
            set
            {
                this.OnPropertyChanged("GroupTag", this._GroupTag, value);
                this._GroupTag = value;
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

                LinkAlt = new PropertyItem("LinkAlt", tableName);

                LinkUrl = new PropertyItem("LinkUrl", tableName);

                LogoUrl = new PropertyItem("LogoUrl", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);

                GroupTag = new PropertyItem("GroupTag", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 链接名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 链接提示,
            /// </summary> 
            public PropertyItem LinkAlt = null;
            /// <summary>
            /// 链接地址,
            /// </summary> 
            public PropertyItem LinkUrl = null;
            /// <summary>
            /// Logo地址,
            /// </summary> 
            public PropertyItem LogoUrl = null;
            /// <summary>
            /// 排序,
            /// </summary> 
            public PropertyItem OrderNo = null;
            /// <summary>
            /// 分组标识,可以对友情链接进行分组
            /// </summary> 
            public PropertyItem GroupTag = null;
        }
        #endregion
    }

    public partial class FriendlyLink
    {
        [NotDbCol]
        public string GroupTagName { get; set; }

    }
}
