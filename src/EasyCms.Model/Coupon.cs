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
    /// 优惠券管理
    /// </summary>  
  [JsonObject]
    public partial class Coupon : BaseEntity
    {
        public static Column _ = new Column("Coupon");

        public Coupon()
        {
            this.TableName = "Coupon";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _Name;

        private decimal _JE;

        private string _QxLx;

        private DateTime _StartDate;

        private DateTime _EndDate;

        private bool _IsCongZengSongKaiShi;

        private int _QXTS;

        private bool _IsEnable;

        private DateTime _CreateDate;

        private string _Createor;

        private DateTime _ModifyDate;

        private string _Modifor;

        private string _Note;

        #endregion

        #region 属性

        /// <summary>
        ///  ID,
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
        ///  优惠券名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 400, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  金额,
        /// </summary>

        [DbProperty(MapingColumnName = "JE", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal JE
        {
            get
            {
                return this._JE;
            }
            set
            {
                this.OnPropertyChanged("JE", this._JE, value);
                this._JE = value;
            }
        }

        /// <summary>
        ///  期限类型,固定期限范围，规定天数
        /// </summary>

        [DbProperty(MapingColumnName = "QxLx", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 40, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string QxLx
        {
            get
            {
                return this._QxLx;
            }
            set
            {
                this.OnPropertyChanged("QxLx", this._QxLx, value);
                this._QxLx = value;
            }
        }

        /// <summary>
        ///  开始时间,
        /// </summary>

        [DbProperty(MapingColumnName = "StartDate", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime StartDate
        {
            get
            {
                return this._StartDate;
            }
            set
            {
                this.OnPropertyChanged("StartDate", this._StartDate, value);
                this._StartDate = value;
            }
        }

        /// <summary>
        ///  结束时间,
        /// </summary>

        [DbProperty(MapingColumnName = "EndDate", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime EndDate
        {
            get
            {
                return this._EndDate;
            }
            set
            {
                this.OnPropertyChanged("EndDate", this._EndDate, value);
                this._EndDate = value;
            }
        }

        /// <summary>
        ///  从赠送开始计算时间,
        /// </summary>

        [DbProperty(MapingColumnName = "IsCongZengSongKaiShi", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsCongZengSongKaiShi
        {
            get
            {
                return this._IsCongZengSongKaiShi;
            }
            set
            {
                this.OnPropertyChanged("IsCongZengSongKaiShi", this._IsCongZengSongKaiShi, value);
                this._IsCongZengSongKaiShi = value;
            }
        }

        /// <summary>
        ///  期限天数,
        /// </summary>

        [DbProperty(MapingColumnName = "QXTS", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int QXTS
        {
            get
            {
                return this._QXTS;
            }
            set
            {
                this.OnPropertyChanged("QXTS", this._QXTS, value);
                this._QXTS = value;
            }
        }

        /// <summary>
        ///  启用,
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
        ///  创建日期,
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
        ///  创建人,
        /// </summary>

        [DbProperty(MapingColumnName = "Createor", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 40, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Createor
        {
            get
            {
                return this._Createor;
            }
            set
            {
                this.OnPropertyChanged("Createor", this._Createor, value);
                this._Createor = value;
            }
        }

        /// <summary>
        ///  修改日期,
        /// </summary>

        [DbProperty(MapingColumnName = "ModifyDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime ModifyDate
        {
            get
            {
                return this._ModifyDate;
            }
            set
            {
                this.OnPropertyChanged("ModifyDate", this._ModifyDate, value);
                this._ModifyDate = value;
            }
        }

        /// <summary>
        ///  修改人,
        /// </summary>

        [DbProperty(MapingColumnName = "Modifor", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 40, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Modifor
        {
            get
            {
                return this._Modifor;
            }
            set
            {
                this.OnPropertyChanged("Modifor", this._Modifor, value);
                this._Modifor = value;
            }
        }

        /// <summary>
        ///  备注,
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

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                Name = new PropertyItem("Name", tableName);

                JE = new PropertyItem("JE", tableName);

                QxLx = new PropertyItem("QxLx", tableName);

                StartDate = new PropertyItem("StartDate", tableName);

                EndDate = new PropertyItem("EndDate", tableName);

                IsCongZengSongKaiShi = new PropertyItem("IsCongZengSongKaiShi", tableName);

                QXTS = new PropertyItem("QXTS", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                CreateDate = new PropertyItem("CreateDate", tableName);

                Createor = new PropertyItem("Createor", tableName);

                ModifyDate = new PropertyItem("ModifyDate", tableName);

                Modifor = new PropertyItem("Modifor", tableName);

                Note = new PropertyItem("Note", tableName);


            }
            /// <summary>
            /// ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 优惠券名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 金额,
            /// </summary> 
            public PropertyItem JE = null;
            /// <summary>
            /// 期限类型,固定期限范围，规定天数
            /// </summary> 
            public PropertyItem QxLx = null;
            /// <summary>
            /// 开始时间,
            /// </summary> 
            public PropertyItem StartDate = null;
            /// <summary>
            /// 结束时间,
            /// </summary> 
            public PropertyItem EndDate = null;
            /// <summary>
            /// 从赠送开始计算时间,
            /// </summary> 
            public PropertyItem IsCongZengSongKaiShi = null;
            /// <summary>
            /// 期限天数,
            /// </summary> 
            public PropertyItem QXTS = null;
            /// <summary>
            /// 启用,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CreateDate = null;
            /// <summary>
            /// 创建人,
            /// </summary> 
            public PropertyItem Createor = null;
            /// <summary>
            /// 修改日期,
            /// </summary> 
            public PropertyItem ModifyDate = null;
            /// <summary>
            /// 修改人,
            /// </summary> 
            public PropertyItem Modifor = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
        }
        #endregion
    }

}
