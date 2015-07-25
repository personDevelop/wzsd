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

        private string _Description;

        private DateTime _CreatedDate;

        private string _CreatedUserID;

        private int _ReplyCount;

        private string _ParentID;

        private string _TypeID;

        private int _State;

        private bool _IsRead;

        private string _CreatedNickName;

        #endregion

        #region 属性

        /// <summary>
        ///  ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 1, ColumnDefaultValue = "")]

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

        [DbProperty(MapingColumnName = "ContentId", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  评论内容,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 4000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  会员ID,
        /// </summary>

        [DbProperty(MapingColumnName = "CreatedUserID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  回复次数,
        /// </summary>

        [DbProperty(MapingColumnName = "ReplyCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ReplyCount
        {
            get
            {
                return this._ReplyCount;
            }
            set
            {
                this.OnPropertyChanged("ReplyCount", this._ReplyCount, value);
                this._ReplyCount = value;
            }
        }

        /// <summary>
        ///  父评论ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ParentID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  类型ID,
        /// </summary>

        [DbProperty(MapingColumnName = "TypeID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this.OnPropertyChanged("TypeID", this._TypeID, value);
                this._TypeID = value;
            }
        }

        /// <summary>
        ///  状态,0未审核，1审核，2 审核不通过
        /// </summary>

        [DbProperty(MapingColumnName = "State", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int State
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
        ///  已读,
        /// </summary>

        [DbProperty(MapingColumnName = "IsRead", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsRead
        {
            get
            {
                return this._IsRead;
            }
            set
            {
                this.OnPropertyChanged("IsRead", this._IsRead, value);
                this._IsRead = value;
            }
        }

        /// <summary>
        ///  评论人昵称,
        /// </summary>

        [DbProperty(MapingColumnName = "CreatedNickName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 400, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CreatedNickName
        {
            get
            {
                return this._CreatedNickName;
            }
            set
            {
                this.OnPropertyChanged("CreatedNickName", this._CreatedNickName, value);
                this._CreatedNickName = value;
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

                Description = new PropertyItem("Description", tableName);

                CreatedDate = new PropertyItem("CreatedDate", tableName);

                CreatedUserID = new PropertyItem("CreatedUserID", tableName);

                ReplyCount = new PropertyItem("ReplyCount", tableName);

                ParentID = new PropertyItem("ParentID", tableName);

                TypeID = new PropertyItem("TypeID", tableName);

                State = new PropertyItem("State", tableName);

                IsRead = new PropertyItem("IsRead", tableName);

                CreatedNickName = new PropertyItem("CreatedNickName", tableName);


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
            /// 评论内容,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 评论时间,
            /// </summary> 
            public PropertyItem CreatedDate = null;
            /// <summary>
            /// 会员ID,
            /// </summary> 
            public PropertyItem CreatedUserID = null;
            /// <summary>
            /// 回复次数,
            /// </summary> 
            public PropertyItem ReplyCount = null;
            /// <summary>
            /// 父评论ID,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 类型ID,
            /// </summary> 
            public PropertyItem TypeID = null;
            /// <summary>
            /// 状态,0未审核，1审核，2 审核不通过
            /// </summary> 
            public PropertyItem State = null;
            /// <summary>
            /// 已读,
            /// </summary> 
            public PropertyItem IsRead = null;
            /// <summary>
            /// 评论人昵称,
            /// </summary> 
            public PropertyItem CreatedNickName = null;
        }
        #endregion
    }
}
