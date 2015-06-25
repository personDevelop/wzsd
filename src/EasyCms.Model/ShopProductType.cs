using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyCms.Model
{
    /// <summary>
    /// 商品类型
    /// </summary>  
    public partial class ShopProductType : BaseEntity
    {
        public static Column _ = new Column("ShopProductType");

        public ShopProductType()
        {
            this.TableName = "ShopProductType";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

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
        ///  商品类型编号,
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
        ///  商品类型名称,
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
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

                Name = new PropertyItem("Name", tableName);

                Note = new PropertyItem("Note", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 商品类型编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 商品类型名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
        }
        #endregion
    }

    public partial class ShopProductType
    {
        /// <summary>
        /// 编辑品牌信息时用到
        /// </summary>
        [NotDbCol]
        public bool IsSelected { get; set; }
    }
}
