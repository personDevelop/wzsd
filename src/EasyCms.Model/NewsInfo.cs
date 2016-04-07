using Newtonsoft.Json;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model
{

    /// <summary>
    /// 新闻信息
    /// </summary>  
    [JsonObject]
    public partial class NewsInfo : BaseEntity
    {
        public static Column _ = new Column("NewsInfo");

        public NewsInfo()
        {
            this.TableName = "NewsInfo";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _ClassID;

        private string _NewsTitle;

        private string _SubTitle;

        private string _Summary;

        private string _Description;

        private string _PCDescription;

        private string _ImageUrl;

        private string _ThumbImageUrl;

        private string _NormalImageUrl;

        private DateTime _CreatedDate;

        private string _CreatedUserID;

        private string _LastEditUserID;

        private DateTime _LastEditDate;

        private string _LinkUrl;

        private int _PvCount;

        private int _State;

        private string _KeyWords;

        private int _Sequence;

        private bool _IsRecomend;

        private bool _IsHot;

        private bool _IsColor;

        private bool _IsTop;

        private string _Note;

        private int _TotalComment;

        private int _TotalSupport;

        private int _TotalFav;

        private int _TotalShare;

        private string _BeFrom;

        private string _Meta_Title;

        private string _Meta_Description;

        private string _Meta_Keywords;

        private string _SeoUrl;

        private string _SeoImageAlt;

        private string _SeoImageTitle;

        private string _StaticUrl;

        private bool _AllowPl;

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
        ///  分类ID,
        /// </summary>

        [DbProperty(MapingColumnName = "ClassID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ClassID
        {
            get
            {
                return this._ClassID;
            }
            set
            {
                this.OnPropertyChanged("ClassID", this._ClassID, value);
                this._ClassID = value;
            }
        }

        /// <summary>
        ///  标题,
        /// </summary>

        [DbProperty(MapingColumnName = "NewsTitle", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 300, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string NewsTitle
        {
            get
            {
                return this._NewsTitle;
            }
            set
            {
                this.OnPropertyChanged("NewsTitle", this._NewsTitle, value);
                this._NewsTitle = value;
            }
        }

        /// <summary>
        ///  副标题,
        /// </summary>

        [DbProperty(MapingColumnName = "SubTitle", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = true, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SubTitle
        {
            get
            {
                return this._SubTitle;
            }
            set
            {
                this.OnPropertyChanged("SubTitle", this._SubTitle, value);
                this._SubTitle = value;
            }
        }

        /// <summary>
        ///  简介,
        /// </summary>

        [DbProperty(MapingColumnName = "Summary", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Summary
        {
            get
            {
                return this._Summary;
            }
            set
            {
                this.OnPropertyChanged("Summary", this._Summary, value);
                this._Summary = value;
            }
        }

        /// <summary>
        ///  内容,
        /// </summary>

        [DbProperty(MapingColumnName = "Description", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  PC内容,
        /// </summary>

        [DbProperty(MapingColumnName = "PCDescription", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string PCDescription
        {
            get
            {
                return this._PCDescription;
            }
            set
            {
                this.OnPropertyChanged("PCDescription", this._PCDescription, value);
                this._PCDescription = value;
            }
        }

        /// <summary>
        ///  图片地址,
        /// </summary>

        [DbProperty(MapingColumnName = "ImageUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ImageUrl
        {
            get
            {
                return this._ImageUrl;
            }
            set
            {
                this.OnPropertyChanged("ImageUrl", this._ImageUrl, value);
                this._ImageUrl = value;
            }
        }

        /// <summary>
        ///  缩略图,
        /// </summary>

        [DbProperty(MapingColumnName = "ThumbImageUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ThumbImageUrl
        {
            get
            {
                return this._ThumbImageUrl;
            }
            set
            {
                this.OnPropertyChanged("ThumbImageUrl", this._ThumbImageUrl, value);
                this._ThumbImageUrl = value;
            }
        }

        /// <summary>
        ///  正常图片地址,
        /// </summary>

        [DbProperty(MapingColumnName = "NormalImageUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string NormalImageUrl
        {
            get
            {
                return this._NormalImageUrl;
            }
            set
            {
                this.OnPropertyChanged("NormalImageUrl", this._NormalImageUrl, value);
                this._NormalImageUrl = value;
            }
        }

        /// <summary>
        ///  创建日期,
        /// </summary>

        [DbProperty(MapingColumnName = "CreatedDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  创建人,
        /// </summary>

        [DbProperty(MapingColumnName = "CreatedUserID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  最后修改人,
        /// </summary>

        [DbProperty(MapingColumnName = "LastEditUserID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string LastEditUserID
        {
            get
            {
                return this._LastEditUserID;
            }
            set
            {
                this.OnPropertyChanged("LastEditUserID", this._LastEditUserID, value);
                this._LastEditUserID = value;
            }
        }

        /// <summary>
        ///  最后修改日期,
        /// </summary>

        [DbProperty(MapingColumnName = "LastEditDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime LastEditDate
        {
            get
            {
                return this._LastEditDate;
            }
            set
            {
                this.OnPropertyChanged("LastEditDate", this._LastEditDate, value);
                this._LastEditDate = value;
            }
        }

        /// <summary>
        ///  外部链接地址,
        /// </summary>

        [DbProperty(MapingColumnName = "LinkUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 300, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  PV数量,
        /// </summary>

        [DbProperty(MapingColumnName = "PvCount", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int PvCount
        {
            get
            {
                return this._PvCount;
            }
            set
            {
                this.OnPropertyChanged("PvCount", this._PvCount, value);
                this._PvCount = value;
            }
        }

        /// <summary>
        ///  状态,草稿0 1 带审核 2  发布
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
        ///  关键字,
        /// </summary>

        [DbProperty(MapingColumnName = "KeyWords", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string KeyWords
        {
            get
            {
                return this._KeyWords;
            }
            set
            {
                this.OnPropertyChanged("KeyWords", this._KeyWords, value);
                this._KeyWords = value;
            }
        }

        /// <summary>
        ///  顺序,
        /// </summary>

        [DbProperty(MapingColumnName = "Sequence", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Sequence
        {
            get
            {
                return this._Sequence;
            }
            set
            {
                this.OnPropertyChanged("Sequence", this._Sequence, value);
                this._Sequence = value;
            }
        }

        /// <summary>
        ///  推荐,
        /// </summary>

        [DbProperty(MapingColumnName = "IsRecomend", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsRecomend
        {
            get
            {
                return this._IsRecomend;
            }
            set
            {
                this.OnPropertyChanged("IsRecomend", this._IsRecomend, value);
                this._IsRecomend = value;
            }
        }

        /// <summary>
        ///  热点,
        /// </summary>

        [DbProperty(MapingColumnName = "IsHot", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsHot
        {
            get
            {
                return this._IsHot;
            }
            set
            {
                this.OnPropertyChanged("IsHot", this._IsHot, value);
                this._IsHot = value;
            }
        }

        /// <summary>
        ///  醒目,
        /// </summary>

        [DbProperty(MapingColumnName = "IsColor", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsColor
        {
            get
            {
                return this._IsColor;
            }
            set
            {
                this.OnPropertyChanged("IsColor", this._IsColor, value);
                this._IsColor = value;
            }
        }

        /// <summary>
        ///  置顶,
        /// </summary>

        [DbProperty(MapingColumnName = "IsTop", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsTop
        {
            get
            {
                return this._IsTop;
            }
            set
            {
                this.OnPropertyChanged("IsTop", this._IsTop, value);
                this._IsTop = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

        /// <summary>
        ///  评论总个数,
        /// </summary>

        [DbProperty(MapingColumnName = "TotalComment", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int TotalComment
        {
            get
            {
                return this._TotalComment;
            }
            set
            {
                this.OnPropertyChanged("TotalComment", this._TotalComment, value);
                this._TotalComment = value;
            }
        }

        /// <summary>
        ///  支持总个数,
        /// </summary>

        [DbProperty(MapingColumnName = "TotalSupport", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int TotalSupport
        {
            get
            {
                return this._TotalSupport;
            }
            set
            {
                this.OnPropertyChanged("TotalSupport", this._TotalSupport, value);
                this._TotalSupport = value;
            }
        }

        /// <summary>
        ///  点赞个数,
        /// </summary>

        [DbProperty(MapingColumnName = "TotalFav", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int TotalFav
        {
            get
            {
                return this._TotalFav;
            }
            set
            {
                this.OnPropertyChanged("TotalFav", this._TotalFav, value);
                this._TotalFav = value;
            }
        }

        /// <summary>
        ///  分析个数,
        /// </summary>

        [DbProperty(MapingColumnName = "TotalShare", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int TotalShare
        {
            get
            {
                return this._TotalShare;
            }
            set
            {
                this.OnPropertyChanged("TotalShare", this._TotalShare, value);
                this._TotalShare = value;
            }
        }

        /// <summary>
        ///  来源,
        /// </summary>

        [DbProperty(MapingColumnName = "BeFrom", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BeFrom
        {
            get
            {
                return this._BeFrom;
            }
            set
            {
                this.OnPropertyChanged("BeFrom", this._BeFrom, value);
                this._BeFrom = value;
            }
        }

        /// <summary>
        ///  页面标题,
        /// </summary>

        [DbProperty(MapingColumnName = "Meta_Title", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Meta_Title
        {
            get
            {
                return this._Meta_Title;
            }
            set
            {
                this.OnPropertyChanged("Meta_Title", this._Meta_Title, value);
                this._Meta_Title = value;
            }
        }

        /// <summary>
        ///  页面描述,
        /// </summary>

        [DbProperty(MapingColumnName = "Meta_Description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Meta_Description
        {
            get
            {
                return this._Meta_Description;
            }
            set
            {
                this.OnPropertyChanged("Meta_Description", this._Meta_Description, value);
                this._Meta_Description = value;
            }
        }

        /// <summary>
        ///  页面关键词,
        /// </summary>

        [DbProperty(MapingColumnName = "Meta_Keywords", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Meta_Keywords
        {
            get
            {
                return this._Meta_Keywords;
            }
            set
            {
                this.OnPropertyChanged("Meta_Keywords", this._Meta_Keywords, value);
                this._Meta_Keywords = value;
            }
        }

        /// <summary>
        ///  SeoURL地址,
        /// </summary>

        [DbProperty(MapingColumnName = "SeoUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SeoUrl
        {
            get
            {
                return this._SeoUrl;
            }
            set
            {
                this.OnPropertyChanged("SeoUrl", this._SeoUrl, value);
                this._SeoUrl = value;
            }
        }

        /// <summary>
        ///  SeoURL图片Alt,
        /// </summary>

        [DbProperty(MapingColumnName = "SeoImageAlt", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SeoImageAlt
        {
            get
            {
                return this._SeoImageAlt;
            }
            set
            {
                this.OnPropertyChanged("SeoImageAlt", this._SeoImageAlt, value);
                this._SeoImageAlt = value;
            }
        }

        /// <summary>
        ///  SeoURL图片Title,
        /// </summary>

        [DbProperty(MapingColumnName = "SeoImageTitle", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string SeoImageTitle
        {
            get
            {
                return this._SeoImageTitle;
            }
            set
            {
                this.OnPropertyChanged("SeoImageTitle", this._SeoImageTitle, value);
                this._SeoImageTitle = value;
            }
        }

        /// <summary>
        ///  静态URL,
        /// </summary>

        [DbProperty(MapingColumnName = "StaticUrl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string StaticUrl
        {
            get
            {
                return this._StaticUrl;
            }
            set
            {
                this.OnPropertyChanged("StaticUrl", this._StaticUrl, value);
                this._StaticUrl = value;
            }
        }

        /// <summary>
        ///  允许评论,
        /// </summary>

        [DbProperty(MapingColumnName = "AllowPl", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool AllowPl
        {
            get
            {
                return this._AllowPl;
            }
            set
            {
                this.OnPropertyChanged("AllowPl", this._AllowPl, value);
                this._AllowPl = value;
            }
        }

        /// <summary>
        ///  关联商品,
        /// </summary>

        [DbProperty(MapingColumnName = "ProducntID", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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

                ClassID = new PropertyItem("ClassID", tableName);

                NewsTitle = new PropertyItem("NewsTitle", tableName);

                SubTitle = new PropertyItem("SubTitle", tableName);

                Summary = new PropertyItem("Summary", tableName);

                Description = new PropertyItem("Description", tableName);

                PCDescription = new PropertyItem("PCDescription", tableName);

                ImageUrl = new PropertyItem("ImageUrl", tableName);

                ThumbImageUrl = new PropertyItem("ThumbImageUrl", tableName);

                NormalImageUrl = new PropertyItem("NormalImageUrl", tableName);

                CreatedDate = new PropertyItem("CreatedDate", tableName);

                CreatedUserID = new PropertyItem("CreatedUserID", tableName);

                LastEditUserID = new PropertyItem("LastEditUserID", tableName);

                LastEditDate = new PropertyItem("LastEditDate", tableName);

                LinkUrl = new PropertyItem("LinkUrl", tableName);

                PvCount = new PropertyItem("PvCount", tableName);

                State = new PropertyItem("State", tableName);

                KeyWords = new PropertyItem("KeyWords", tableName);

                Sequence = new PropertyItem("Sequence", tableName);

                IsRecomend = new PropertyItem("IsRecomend", tableName);

                IsHot = new PropertyItem("IsHot", tableName);

                IsColor = new PropertyItem("IsColor", tableName);

                IsTop = new PropertyItem("IsTop", tableName);

                Note = new PropertyItem("Note", tableName);

                TotalComment = new PropertyItem("TotalComment", tableName);

                TotalSupport = new PropertyItem("TotalSupport", tableName);

                TotalFav = new PropertyItem("TotalFav", tableName);

                TotalShare = new PropertyItem("TotalShare", tableName);

                BeFrom = new PropertyItem("BeFrom", tableName);

                Meta_Title = new PropertyItem("Meta_Title", tableName);

                Meta_Description = new PropertyItem("Meta_Description", tableName);

                Meta_Keywords = new PropertyItem("Meta_Keywords", tableName);

                SeoUrl = new PropertyItem("SeoUrl", tableName);

                SeoImageAlt = new PropertyItem("SeoImageAlt", tableName);

                SeoImageTitle = new PropertyItem("SeoImageTitle", tableName);

                StaticUrl = new PropertyItem("StaticUrl", tableName);

                AllowPl = new PropertyItem("AllowPl", tableName);

                ProducntID = new PropertyItem("ProducntID", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 分类ID,
            /// </summary> 
            public PropertyItem ClassID = null;
            /// <summary>
            /// 标题,
            /// </summary> 
            public PropertyItem NewsTitle = null;
            /// <summary>
            /// 副标题,
            /// </summary> 
            public PropertyItem SubTitle = null;
            /// <summary>
            /// 简介,
            /// </summary> 
            public PropertyItem Summary = null;
            /// <summary>
            /// 内容,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// PC内容,
            /// </summary> 
            public PropertyItem PCDescription = null;
            /// <summary>
            /// 图片地址,
            /// </summary> 
            public PropertyItem ImageUrl = null;
            /// <summary>
            /// 缩略图,
            /// </summary> 
            public PropertyItem ThumbImageUrl = null;
            /// <summary>
            /// 正常图片地址,
            /// </summary> 
            public PropertyItem NormalImageUrl = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CreatedDate = null;
            /// <summary>
            /// 创建人,
            /// </summary> 
            public PropertyItem CreatedUserID = null;
            /// <summary>
            /// 最后修改人,
            /// </summary> 
            public PropertyItem LastEditUserID = null;
            /// <summary>
            /// 最后修改日期,
            /// </summary> 
            public PropertyItem LastEditDate = null;
            /// <summary>
            /// 外部链接地址,
            /// </summary> 
            public PropertyItem LinkUrl = null;
            /// <summary>
            /// PV数量,
            /// </summary> 
            public PropertyItem PvCount = null;
            /// <summary>
            /// 状态,草稿0 1 带审核 2  发布
            /// </summary> 
            public PropertyItem State = null;
            /// <summary>
            /// 关键字,
            /// </summary> 
            public PropertyItem KeyWords = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem Sequence = null;
            /// <summary>
            /// 推荐,
            /// </summary> 
            public PropertyItem IsRecomend = null;
            /// <summary>
            /// 热点,
            /// </summary> 
            public PropertyItem IsHot = null;
            /// <summary>
            /// 醒目,
            /// </summary> 
            public PropertyItem IsColor = null;
            /// <summary>
            /// 置顶,
            /// </summary> 
            public PropertyItem IsTop = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 评论总个数,
            /// </summary> 
            public PropertyItem TotalComment = null;
            /// <summary>
            /// 支持总个数,
            /// </summary> 
            public PropertyItem TotalSupport = null;
            /// <summary>
            /// 点赞个数,
            /// </summary> 
            public PropertyItem TotalFav = null;
            /// <summary>
            /// 分析个数,
            /// </summary> 
            public PropertyItem TotalShare = null;
            /// <summary>
            /// 来源,
            /// </summary> 
            public PropertyItem BeFrom = null;
            /// <summary>
            /// 页面标题,
            /// </summary> 
            public PropertyItem Meta_Title = null;
            /// <summary>
            /// 页面描述,
            /// </summary> 
            public PropertyItem Meta_Description = null;
            /// <summary>
            /// 页面关键词,
            /// </summary> 
            public PropertyItem Meta_Keywords = null;
            /// <summary>
            /// SeoURL地址,
            /// </summary> 
            public PropertyItem SeoUrl = null;
            /// <summary>
            /// SeoURL图片Alt,
            /// </summary> 
            public PropertyItem SeoImageAlt = null;
            /// <summary>
            /// SeoURL图片Title,
            /// </summary> 
            public PropertyItem SeoImageTitle = null;
            /// <summary>
            /// 静态URL,
            /// </summary> 
            public PropertyItem StaticUrl = null;
            /// <summary>
            /// 允许评论,
            /// </summary> 
            public PropertyItem AllowPl = null;
            /// <summary>
            /// 关联商品,
            /// </summary> 
            public PropertyItem ProducntID = null;
        }
        #endregion
    }



    public partial class NewsInfo
    {
        protected override void OnCreate()
        {
            CreatedDate = LastEditDate = DateTime.Now;
            IsTop = IsColor = IsHot = IsRecomend = AllowPl = true;
        }
        [NotDbCol]
        public string ClassName { get; set; }

        [NotDbCol]
        public string ProductName { get; set; }
    }
     
}
