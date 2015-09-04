using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EasyCms.Model
{
    /// <summary>
    /// 附件表
    /// </summary>  
    public partial class AttachFile : BaseEntity
    {
        public static Column _ = new Column("AttachFile");

        public AttachFile()
        {
            this.TableName = "AttachFile";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _FileName;

        private long _FileSize;

        private string _FileExtName;

        private DateTime _UploadTime;

        private string _FilePath;

        private string _RefID;

        private string _RealFileName;

        private string _Note;

        private string _BigClass;

        private int _OrderNo;

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
        ///  文件名称,
        /// </summary>

        [DbProperty(MapingColumnName = "FileName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string FileName
        {
            get
            {
                return this._FileName;
            }
            set
            {
                this.OnPropertyChanged("FileName", this._FileName, value);
                this._FileName = value;
            }
        }

        /// <summary>
        ///  文件大小,
        /// </summary>

        [DbProperty(MapingColumnName = "FileSize", DbTypeString = "bigint", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public long FileSize
        {
            get
            {
                return this._FileSize;
            }
            set
            {
                this.OnPropertyChanged("FileSize", this._FileSize, value);
                this._FileSize = value;
            }
        }

        /// <summary>
        ///  文件扩展名,
        /// </summary>

        [DbProperty(MapingColumnName = "FileExtName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string FileExtName
        {
            get
            {
                return this._FileExtName;
            }
            set
            {
                this.OnPropertyChanged("FileExtName", this._FileExtName, value);
                this._FileExtName = value;
            }
        }

        /// <summary>
        ///  上传时间,
        /// </summary>

        [DbProperty(MapingColumnName = "UploadTime", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime UploadTime
        {
            get
            {
                return this._UploadTime;
            }
            set
            {
                this.OnPropertyChanged("UploadTime", this._UploadTime, value);
                this._UploadTime = value;
            }
        }

        /// <summary>
        ///  路径,
        /// </summary>

        [DbProperty(MapingColumnName = "FilePath", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string FilePath
        {
            get
            {
                return this._FilePath;
            }
            set
            {
                this.OnPropertyChanged("FilePath", this._FilePath, value);
                this._FilePath = value;
            }
        }

        /// <summary>
        ///  引用主键,
        /// </summary>

        [DbProperty(MapingColumnName = "RefID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RefID
        {
            get
            {
                return this._RefID;
            }
            set
            {
                this.OnPropertyChanged("RefID", this._RefID, value);
                this._RefID = value;
            }
        }

        /// <summary>
        ///  真实文件名,
        /// </summary>

        [DbProperty(MapingColumnName = "RealFileName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RealFileName
        {
            get
            {
                return this._RealFileName;
            }
            set
            {
                this.OnPropertyChanged("RealFileName", this._RealFileName, value);
                this._RealFileName = value;
            }
        }

        /// <summary>
        ///  说明,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  附件大类,image,vidio,file
        /// </summary>

        [DbProperty(MapingColumnName = "BigClass", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string BigClass
        {
            get
            {
                return this._BigClass;
            }
            set
            {
                this.OnPropertyChanged("BigClass", this._BigClass, value);
                this._BigClass = value;
            }
        }

        /// <summary>
        ///  顺序,
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

                FileName = new PropertyItem("FileName", tableName);

                FileSize = new PropertyItem("FileSize", tableName);

                FileExtName = new PropertyItem("FileExtName", tableName);

                UploadTime = new PropertyItem("UploadTime", tableName);

                FilePath = new PropertyItem("FilePath", tableName);

                RefID = new PropertyItem("RefID", tableName);

                RealFileName = new PropertyItem("RealFileName", tableName);

                Note = new PropertyItem("Note", tableName);

                BigClass = new PropertyItem("BigClass", tableName);

                OrderNo = new PropertyItem("OrderNo", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 文件名称,
            /// </summary> 
            public PropertyItem FileName = null;
            /// <summary>
            /// 文件大小,
            /// </summary> 
            public PropertyItem FileSize = null;
            /// <summary>
            /// 文件扩展名,
            /// </summary> 
            public PropertyItem FileExtName = null;
            /// <summary>
            /// 上传时间,
            /// </summary> 
            public PropertyItem UploadTime = null;
            /// <summary>
            /// 路径,
            /// </summary> 
            public PropertyItem FilePath = null;
            /// <summary>
            /// 引用主键,
            /// </summary> 
            public PropertyItem RefID = null;
            /// <summary>
            /// 真实文件名,
            /// </summary> 
            public PropertyItem RealFileName = null;
            /// <summary>
            /// 说明,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 附件大类,image,vidio,file
            /// </summary> 
            public PropertyItem BigClass = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
        }
        #endregion
    }

    public partial class AttachFile
    {
        public static ExpressionClip GetFilePath(string host, string alias = "FilePath")
        {
            if (string.IsNullOrWhiteSpace(host))
            {
                return AttachFile._.FilePath.SubString(1).Alias(alias);
            }
            return (new ExpressionClip("'" + host + "'") + AttachFile._.FilePath.SubString(1)).Alias(alias);

        }
    }
    public class SimpalFile
    {
        public string ID { get; set; }
        public string RefID { get; set; }


        public string FilePath { get; set; }
        public string WebFilePath { get { return FilePath.Replace("~", ""); } }


    }
}
