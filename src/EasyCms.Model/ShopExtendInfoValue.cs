using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyCms.Model
{
    /// <summary>
    /// 扩展属性值
    /// </summary>  
    public partial class ShopExtendInfoValue : BaseEntity
    {
        public static Column _ = new Column("ShopExtendInfoValue");

        public ShopExtendInfoValue()
        {
            this.TableName = "ShopExtendInfoValue";
            OnCreate();
        }


        #region 私有变量

        private long _ID;

        private string _AttributeId;

        private int _DisplaySequence;

        private string _ValueStr;

        private string _ImageID;

        private string _Note;

        #endregion

        #region 属性

        /// <summary>
        ///  主键,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "bigint", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = true, StepSize = 0, ColumnDefaultValue = "")]

        public long ID
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
        ///  扩展属性ID,
        /// </summary>

        [DbProperty(MapingColumnName = "AttributeId", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string AttributeId
        {
            get
            {
                return this._AttributeId;
            }
            set
            {
                this.OnPropertyChanged("AttributeId", this._AttributeId, value);
                this._AttributeId = value;
            }
        }

        /// <summary>
        ///  显示顺序,
        /// </summary>

        [DbProperty(MapingColumnName = "DisplaySequence", DbTypeString = "int", ColumnIsNull = false, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int DisplaySequence
        {
            get
            {
                return this._DisplaySequence;
            }
            set
            {
                this.OnPropertyChanged("DisplaySequence", this._DisplaySequence, value);
                this._DisplaySequence = value;
            }
        }

        /// <summary>
        ///  属性值,
        /// </summary>

        [DbProperty(MapingColumnName = "ValueStr", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ValueStr
        {
            get
            {
                return this._ValueStr;
            }
            set
            {
                this.OnPropertyChanged("ValueStr", this._ValueStr, value);
                this._ValueStr = value;
            }
        }

        /// <summary>
        ///  对应图片ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ImageID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 1, ColumnDefaultValue = "")]

        public string ImageID
        {
            get
            {
                return this._ImageID;
            }
            set
            {
                this.OnPropertyChanged("ImageID", this._ImageID, value);
                this._ImageID = value;
            }
        }

        /// <summary>
        ///  图片描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

                AttributeId = new PropertyItem("AttributeId", tableName);

                DisplaySequence = new PropertyItem("DisplaySequence", tableName);

                ValueStr = new PropertyItem("ValueStr", tableName);

                ImageID = new PropertyItem("ImageID", tableName);

                Note = new PropertyItem("Note", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 扩展属性ID,
            /// </summary> 
            public PropertyItem AttributeId = null;
            /// <summary>
            /// 显示顺序,
            /// </summary> 
            public PropertyItem DisplaySequence = null;
            /// <summary>
            /// 属性值,
            /// </summary> 
            public PropertyItem ValueStr = null;
            /// <summary>
            /// 对应图片ID,
            /// </summary> 
            public PropertyItem ImageID = null;
            /// <summary>
            /// 图片描述,
            /// </summary> 
            public PropertyItem Note = null;
        }
        #endregion
    }

}
