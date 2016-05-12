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
    /// 广告位置表
    /// </summary>  
    [JsonObject]
    public partial class AdPositon : BaseEntity
    {
        public static Column _ = new Column("AdPositon");

        public AdPositon()
        {
            this.TableName = "AdPositon";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private string _Width;

        private string _Height;

        private AdType _AdType;

        private AdShowType _ShowType;

        private bool _IsEnable;

        private int _ShowNums;

        private string _Note;

        private string _CallCode;

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
        ///  宽度,
        /// </summary>

        [DbProperty(MapingColumnName = "Width", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Width
        {
            get
            {
                return this._Width;
            }
            set
            {
                this.OnPropertyChanged("Width", this._Width, value);
                this._Width = value;
            }
        }

        /// <summary>
        ///  高度,
        /// </summary>

        [DbProperty(MapingColumnName = "Height", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Height
        {
            get
            {
                return this._Height;
            }
            set
            {
                this.OnPropertyChanged("Height", this._Height, value);
                this._Height = value;
            }
        }

        /// <summary>
        ///  广告类型,
        /// </summary>

        [DbProperty(MapingColumnName = "AdType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AdType AdType
        {
            get
            {
                return this._AdType;
            }
            set
            {
                this.OnPropertyChanged("AdType", this._AdType, value);
                this._AdType = value;
            }
        }

        /// <summary>
        ///  显示方式,
        /// </summary>

        [DbProperty(MapingColumnName = "ShowType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public AdShowType ShowType
        {
            get
            {
                return this._ShowType;
            }
            set
            {
                this.OnPropertyChanged("ShowType", this._ShowType, value);
                this._ShowType = value;
            }
        }

        /// <summary>
        ///  开启,
        /// </summary>

        [DbProperty(MapingColumnName = "IsEnable", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsEnable
        {
            get
            {
                return this._IsEnable;
            }
            set
            {
                this.OnPropertyChanged("IsEnable", this._IsEnable, value);
                this._IsEnable = value;
            }
        }

        /// <summary>
        ///  显示数量,
        /// </summary>

        [DbProperty(MapingColumnName = "ShowNums", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ShowNums
        {
            get
            {
                return this._ShowNums;
            }
            set
            {
                this.OnPropertyChanged("ShowNums", this._ShowNums, value);
                this._ShowNums = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  代码,
        /// </summary>

        [DbProperty(MapingColumnName = "CallCode", DbTypeString = "ntext", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string CallCode
        {
            get
            {
                return this._CallCode;
            }
            set
            {
                this.OnPropertyChanged("CallCode", this._CallCode, value);
                this._CallCode = value;
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

                Width = new PropertyItem("Width", tableName);

                Height = new PropertyItem("Height", tableName);

                AdType = new PropertyItem("AdType", tableName);

                ShowType = new PropertyItem("ShowType", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                ShowNums = new PropertyItem("ShowNums", tableName);

                Note = new PropertyItem("Note", tableName);

                CallCode = new PropertyItem("CallCode", tableName);


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
            /// 宽度,
            /// </summary> 
            public PropertyItem Width = null;
            /// <summary>
            /// 高度,
            /// </summary> 
            public PropertyItem Height = null;
            /// <summary>
            /// 广告类型,
            /// </summary> 
            public PropertyItem AdType = null;
            /// <summary>
            /// 显示方式,
            /// </summary> 
            public PropertyItem ShowType = null;
            /// <summary>
            /// 开启,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 显示数量,
            /// </summary> 
            public PropertyItem ShowNums = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 代码,
            /// </summary> 
            public PropertyItem CallCode = null;
        }
        #endregion
    }
}
