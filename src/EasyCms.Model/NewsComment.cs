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
    /// 新闻评论
    /// </summary>  
    [JsonObject]
    public partial class NewsComment : BaseEntity
    {
        public static Column _ = new Column("NewsComment");

        public NewsComment()
        {
            this.TableName = "NewsComment";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ContentId;

        private string _CreatedUserID;

        private string _Description;

        private DateTime _CreatedDate;

        private string _ParentID;

        private DjStatus _State;

        private string _ClassCode;

        private bool _IsAnony;

        private string _NewsName;

        private string _UserName;

        #endregion

        #region 属性

        /// <summary>
        ///  ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 1, ColumnDefaultValue = "")]

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
        ///  新闻ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ContentId", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ContentId
        {
            get
            {
                return this._ContentId;
            }
            set
            {
                this.OnPropertyChanged("ContentId", this._ContentId, value);
                this._ContentId = value;
            }
        }

        /// <summary>
        ///  会员ID,
        /// </summary>

        [DbProperty(MapingColumnName = "CreatedUserID", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CreatedUserID
        {
            get
            {
                return this._CreatedUserID;
            }
            set
            {
                this.OnPropertyChanged("CreatedUserID", this._CreatedUserID, value);
                this._CreatedUserID = value;
            }
        }

        /// <summary>
        ///  评论内容,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this.OnPropertyChanged("Description", this._Description, value);
                this._Description = value;
            }
        }

        /// <summary>
        ///  评论时间,
        /// </summary>

        [DbProperty(MapingColumnName = "CreatedDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "(getdate())")]

        public DateTime CreatedDate
        {
            get
            {
                return this._CreatedDate;
            }
            set
            {
                this.OnPropertyChanged("CreatedDate", this._CreatedDate, value);
                this._CreatedDate = value;
            }
        }

        /// <summary>
        ///  父评论ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ParentID", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {
                this.OnPropertyChanged("ParentID", this._ParentID, value);
                this._ParentID = value;
            }
        }

        /// <summary>
        ///  状态,0未审核，1审核，2 审核不通过
        /// </summary>

        [DbProperty(MapingColumnName = "State", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DjStatus State
        {
            get
            {
                return this._State;
            }
            set
            {
                this.OnPropertyChanged("State", this._State, value);
                this._State = value;
            }
        }

        /// <summary>
        ///  分级码,
        /// </summary>

        [DbProperty(MapingColumnName = "ClassCode", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 400, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ClassCode
        {
            get
            {
                return this._ClassCode;
            }
            set
            {
                this.OnPropertyChanged("ClassCode", this._ClassCode, value);
                this._ClassCode = value;
            }
        }

        /// <summary>
        ///  是否匿名,
        /// </summary>

        [DbProperty(MapingColumnName = "IsAnony", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsAnony
        {
            get
            {
                return this._IsAnony;
            }
            set
            {
                this.OnPropertyChanged("IsAnony", this._IsAnony, value);
                this._IsAnony = value;
            }
        }

        /// <summary>
        ///  新闻名称,
        /// </summary>
        [NotDbCol]

        [DbProperty(MapingColumnName = "NewsName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string NewsName
        {
            get
            {
                return this._NewsName;
            }
            set
            {
                this.OnPropertyChanged("NewsName", this._NewsName, value);
                this._NewsName = value;
            }
        }

        /// <summary>
        ///  会员名称,
        /// </summary>
        [NotDbCol]

        [DbProperty(MapingColumnName = "UserName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this.OnPropertyChanged("UserName", this._UserName, value);
                this._UserName = value;
            }
        }

        #endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                ContentId = new PropertyItem("ContentId", tableName);

                CreatedUserID = new PropertyItem("CreatedUserID", tableName);

                Description = new PropertyItem("Description", tableName);

                CreatedDate = new PropertyItem("CreatedDate", tableName);

                ParentID = new PropertyItem("ParentID", tableName);

                State = new PropertyItem("State", tableName);

                ClassCode = new PropertyItem("ClassCode", tableName);

                IsAnony = new PropertyItem("IsAnony", tableName);

                NewsName = new PropertyItem("NewsName", tableName);

                UserName = new PropertyItem("UserName", tableName);


            }
            /// <summary>
            /// ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 新闻ID,
            /// </summary> 
            public PropertyItem ContentId = null;
            /// <summary>
            /// 会员ID,
            /// </summary> 
            public PropertyItem CreatedUserID = null;
            /// <summary>
            /// 评论内容,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 评论时间,
            /// </summary> 
            public PropertyItem CreatedDate = null;
            /// <summary>
            /// 父评论ID,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 状态,0未审核，1审核，2 审核不通过
            /// </summary> 
            public PropertyItem State = null;
            /// <summary>
            /// 分级码,
            /// </summary> 
            public PropertyItem ClassCode = null;
            /// <summary>
            /// 是否匿名,
            /// </summary> 
            public PropertyItem IsAnony = null;
            /// <summary>
            /// 新闻名称,
            /// </summary> 
            public PropertyItem NewsName = null;
            /// <summary>
            /// 会员名称,
            /// </summary> 
            public PropertyItem UserName = null;
        }
        #endregion
    }
    public partial class NewsComment
    {
        
        [NotDbCol]
        public NewsComment CurrentNewsComment { get; set; }

        [NotDbCol]
        public string LastReply { get; set; }
    }
}
