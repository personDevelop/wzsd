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
    /// 公告
    /// </summary>  
    [JsonObject]
    public partial class Notice : BaseEntity
    {
        public static Column _ = new Column("Notice");

        public Notice()
        {
            this.TableName = "Notice";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _NoticeTitle;

        private string _Contents;

        private DateTime? _PublishTime;

        private DateTime _CreateDate;

        private DjStatus _DjStatus;

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
        ///  标题,
        /// </summary>

        [DbProperty(MapingColumnName = "NoticeTitle", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string NoticeTitle
        {
            get
            {
                return this._NoticeTitle;
            }
            set
            {
                this.OnPropertyChanged("NoticeTitle", this._NoticeTitle, value);
                this._NoticeTitle = value;
            }
        }

        /// <summary>
        ///  内容,
        /// </summary>

        [DbProperty(MapingColumnName = "Contents", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = true, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Contents
        {
            get
            {
                return this._Contents;
            }
            set
            {
                this.OnPropertyChanged("Contents", this._Contents, value);
                this._Contents = value;
            }
        }

        /// <summary>
        ///  发布时间,
        /// </summary>

        [DbProperty(MapingColumnName = "PublishTime", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime? PublishTime
        {
            get
            {
                return this._PublishTime;
            }
            set
            {
                this.OnPropertyChanged("PublishTime", this._PublishTime, value);
                this._PublishTime = value;
            }
        }

        /// <summary>
        ///  创建时间,
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
        ///  状态,
        /// </summary>

        [DbProperty(MapingColumnName = "DjStatus", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DjStatus DjStatus
        {
            get
            {
                return this._DjStatus;
            }
            set
            {
                this.OnPropertyChanged("DjStatus", this._DjStatus, value);
                this._DjStatus = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                NoticeTitle = new PropertyItem("NoticeTitle", tableName);

                Contents = new PropertyItem("Contents", tableName);

                PublishTime = new PropertyItem("PublishTime", tableName);

                CreateDate = new PropertyItem("CreateDate", tableName);

                DjStatus = new PropertyItem("DjStatus", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 标题,
            /// </summary> 
            public PropertyItem NoticeTitle = null;
            /// <summary>
            /// 内容,
            /// </summary> 
            public PropertyItem Contents = null;
            /// <summary>
            /// 发布时间,
            /// </summary> 
            public PropertyItem PublishTime = null;
            /// <summary>
            /// 创建时间,
            /// </summary> 
            public PropertyItem CreateDate = null;
            /// <summary>
            /// 状态,
            /// </summary> 
            public PropertyItem DjStatus = null;
        }
        #endregion
    }
}
