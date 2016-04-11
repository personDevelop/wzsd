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
    /// 帮助内容
    /// </summary>  
    [JsonObject]
    public partial class HelpContent : BaseEntity
    {
        public static Column _ = new Column("HelpContent");

        public HelpContent()
        {
            this.TableName = "HelpContent";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private string _CategoryID;

        private string _ContentHtml;

        private int _OrderNo;

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
        ///  分类,
        /// </summary>

        [DbProperty(MapingColumnName = "CategoryID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CategoryID
        {
            get
            {
                return this._CategoryID;
            }
            set
            {
                this.OnPropertyChanged("CategoryID", this._CategoryID, value);
                this._CategoryID = value;
            }
        }

        /// <summary>
        ///  内容Html,
        /// </summary>

        [DbProperty(MapingColumnName = "ContentHtml", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ContentHtml
        {
            get
            {
                return this._ContentHtml;
            }
            set
            {
                this.OnPropertyChanged("ContentHtml", this._ContentHtml, value);
                this._ContentHtml = value;
            }
        }

        /// <summary>
        ///  序号,
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
                this.OnPropertyChanged("OrderNo", this._OrderNo, value);
                this._OrderNo = value;
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

                CategoryID = new PropertyItem("CategoryID", tableName);

                ContentHtml = new PropertyItem("ContentHtml", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);


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
            /// 分类,
            /// </summary> 
            public PropertyItem CategoryID = null;
            /// <summary>
            /// 内容Html,
            /// </summary> 
            public PropertyItem ContentHtml = null;
            /// <summary>
            /// 序号,
            /// </summary> 
            public PropertyItem OrderNo = null;
        }
        #endregion
    }

    public partial class HelpContent
    {
        [NotDbCol]
        public string CategoryName { get; set; }
    }
}
