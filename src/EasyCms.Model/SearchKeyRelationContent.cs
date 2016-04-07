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
    /// 搜索词关联内容
    /// </summary>  
    [JsonObject]
    public partial class SearchKeyRelationContent : BaseEntity
    {
        public static Column _ = new Column("SearchKeyRelationContent");

        public SearchKeyRelationContent()
        {
            this.TableName = "SearchKeyRelationContent";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _SKeyID;

        private string _ProducntID;

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
        ///  搜索词ID,
        /// </summary>

        [DbProperty(MapingColumnName = "SKeyID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SKeyID
        {
            get
            {
                return this._SKeyID;
            }
            set
            {
                this.OnPropertyChanged("SKeyID", this._SKeyID, value);
                this._SKeyID = value;
            }
        }

        /// <summary>
        ///  关联商品ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ProducntID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ProducntID
        {
            get
            {
                return this._ProducntID;
            }
            set
            {
                this.OnPropertyChanged("ProducntID", this._ProducntID, value);
                this._ProducntID = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                SKeyID = new PropertyItem("SKeyID", tableName);

                ProducntID = new PropertyItem("ProducntID", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 搜索词ID,
            /// </summary> 
            public PropertyItem SKeyID = null;
            /// <summary>
            /// 关联商品ID,
            /// </summary> 
            public PropertyItem ProducntID = null;
        }
        #endregion
    }
}
