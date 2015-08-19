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
    /// 积分规则
    /// </summary>  
    [JsonObject]
    public partial class RedeemRules : BaseEntity
    {
        public static Column _ = new Column("RedeemRules");

        public RedeemRules()
        {
            this.TableName = "RedeemRules";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _RuleType;

        private string _Name;

        private int _BaseNum;

        private int _ReleNum;

        private decimal _BL;

        private bool _IsEnable;

        private string _Remark;

        private int _ComputeType;

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
        ///  类型,直接存文字，商品金钱转积分换算，商品积分转金钱换算，订单金钱转积分换算，订单积分转金钱换算，注册增积分
        /// </summary>

        [DbProperty(MapingColumnName = "RuleType", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string RuleType
        {
            get
            {
                return this._RuleType;
            }
            set
            {
                this.OnPropertyChanged("RuleType", this._RuleType, value);
                this._RuleType = value;
            }
        }

        /// <summary>
        ///  规则名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  基数,
        /// </summary>

        [DbProperty(MapingColumnName = "BaseNum", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int BaseNum
        {
            get
            {
                return this._BaseNum;
            }
            set
            {
                this.OnPropertyChanged("BaseNum", this._BaseNum, value);
                this._BaseNum = value;
            }
        }

        /// <summary>
        ///  兑换数值,
        /// </summary>

        [DbProperty(MapingColumnName = "ReleNum", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ReleNum
        {
            get
            {
                return this._ReleNum;
            }
            set
            {
                this.OnPropertyChanged("ReleNum", this._ReleNum, value);
                this._ReleNum = value;
            }
        }

        /// <summary>
        ///  不能超过商品单价比例,
        /// </summary>

        [DbProperty(MapingColumnName = "BL", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal BL
        {
            get
            {
                return this._BL;
            }
            set
            {
                this.OnPropertyChanged("BL", this._BL, value);
                this._BL = value;
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
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Remark", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this.OnPropertyChanged("Remark", this._Remark, value);
                this._Remark = value;
            }
        }

        /// <summary>
        ///  计算方式,0 按比例，1 按定额
        /// </summary>

        [DbProperty(MapingColumnName = "ComputeType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int ComputeType
        {
            get
            {
                return this._ComputeType;
            }
            set
            {
                this.OnPropertyChanged("ComputeType", this._ComputeType, value);
                this._ComputeType = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                RuleType = new PropertyItem("RuleType", tableName);

                Name = new PropertyItem("Name", tableName);

                BaseNum = new PropertyItem("BaseNum", tableName);

                ReleNum = new PropertyItem("ReleNum", tableName);

                BL = new PropertyItem("BL", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                Remark = new PropertyItem("Remark", tableName);

                ComputeType = new PropertyItem("ComputeType", tableName);


            }
            /// <summary>
            /// ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 类型,直接存文字，商品金钱转积分换算，商品积分转金钱换算，订单金钱转积分换算，订单积分转金钱换算，注册增积分
            /// </summary> 
            public PropertyItem RuleType = null;
            /// <summary>
            /// 规则名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 基数,
            /// </summary> 
            public PropertyItem BaseNum = null;
            /// <summary>
            /// 兑换数值,
            /// </summary> 
            public PropertyItem ReleNum = null;
            /// <summary>
            /// 不能超过商品单价比例,
            /// </summary> 
            public PropertyItem BL = null;
            /// <summary>
            /// 启用,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Remark = null;
            /// <summary>
            /// 计算方式,0 按比例，1 按定额
            /// </summary> 
            public PropertyItem ComputeType = null;
        }
        #endregion
    }

    public partial class RedeemRules
    {
        protected override void OnCreate()
        {
            this.IsEnable = true;
        }
    }
    }
