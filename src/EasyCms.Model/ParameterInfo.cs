using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model
{
    /// <summary>
    /// 参数表实体
    /// </summary> 

    public partial class ParameterInfo : BaseEntity
    {
        public static Column _ = new Column("ParameterInfo");

        public ParameterInfo()
        {
            this.TableName = "ParameterInfo";
            OnCreate();
        }

        #region 私有变量
        private string _ID;
        private string _ParentID;
        private string _Code;
        private string _Name;
        private string _Value;
        private string _Value2;
        private string _ClassCode;
        private bool _IsDetails;
        private int _Series;
        private bool _IsSystem;
        private bool _IsEdit;
        private bool _IsDelete;
        private bool _IsEnable;
        private string _Note;
        private int _OrderNo;
        private string _V1Type;
        private string _V2Type;
        private string _Img1;
        private string _Img2;
        private string _Img3;
        private string _Value3;
        private string _V3Type;
        private string _V4Type;
        private string _Value4;
        private string _V5Type;
        private string _Value5;
        private bool _IsCanHasLeaf;
        private string _V1Note;
        private string _V2Note;
        private string _V3Note;
        private string _V4Note;
        private string _V5Note;

        #endregion

        #region 属性
        /// <summary>
        /// 主键,
        /// </summary>
        [PrimaryKey]

        [DbProperty(MapingColumnName = "ID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        /// 父ID,
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
        /// 编码,
        /// </summary>


        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        /// 名称,
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
        /// 对应值,
        /// </summary>


        [DbProperty(MapingColumnName = "Value", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Value
        {
            get
            {
                return this._Value;
            }
            set
            {

                this.OnPropertyChanged("Value", this._Value, value);
                this._Value = value;
            }
        }
        /// <summary>
        /// 对应值2,
        /// </summary>


        [DbProperty(MapingColumnName = "Value2", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Value2
        {
            get
            {
                return this._Value2;
            }
            set
            {

                this.OnPropertyChanged("Value2", this._Value2, value);
                this._Value2 = value;
            }
        }
        /// <summary>
        /// 分级码,
        /// </summary>


        [DbProperty(MapingColumnName = "ClassCode", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        /// 明细,
        /// </summary>


        [DbProperty(MapingColumnName = "IsDetails", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsDetails
        {
            get
            {
                return this._IsDetails;
            }
            set
            {

                this.OnPropertyChanged("IsDetails", this._IsDetails, value);
                this._IsDetails = value;
            }
        }
        /// <summary>
        /// 级数,
        /// </summary>


        [DbProperty(MapingColumnName = "Series", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int Series
        {
            get
            {
                return this._Series;
            }
            set
            {

                this.OnPropertyChanged("Series", this._Series, value);
                this._Series = value;
            }
        }
        /// <summary>
        /// 系统参数,分类用，后续会分出两个维护界面，一个供开发人员使用，一个供用户使用
        /// </summary>


        [DbProperty(MapingColumnName = "IsSystem", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsSystem
        {
            get
            {
                return this._IsSystem;
            }
            set
            {

                this.OnPropertyChanged("IsSystem", this._IsSystem, value);
                this._IsSystem = value;
            }
        }
        /// <summary>
        /// 可编辑,
        /// </summary>


        [DbProperty(MapingColumnName = "IsEdit", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsEdit
        {
            get
            {
                return this._IsEdit;
            }
            set
            {

                this.OnPropertyChanged("IsEdit", this._IsEdit, value);
                this._IsEdit = value;
            }
        }
        /// <summary>
        /// 可删除,
        /// </summary>


        [DbProperty(MapingColumnName = "IsDelete", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsDelete
        {
            get
            {
                return this._IsDelete;
            }
            set
            {

                this.OnPropertyChanged("IsDelete", this._IsDelete, value);
                this._IsDelete = value;
            }
        }
        /// <summary>
        /// 可用,
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
        /// 备注,
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
        /// 顺序,
        /// </summary>


        [DbProperty(MapingColumnName = "OrderNo", DbTypeString = "Int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        /// <summary>
        /// 值1类型,
        /// </summary>


        [DbProperty(MapingColumnName = "V1Type", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string V1Type
        {
            get
            {
                return this._V1Type;
            }
            set
            {

                this.OnPropertyChanged("V1Type", this._V1Type, value);
                this._V1Type = value;
            }
        }
        /// <summary>
        /// 值2类型,
        /// </summary>


        [DbProperty(MapingColumnName = "V2Type", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string V2Type
        {
            get
            {
                return this._V2Type;
            }
            set
            {

                this.OnPropertyChanged("V2Type", this._V2Type, value);
                this._V2Type = value;
            }
        }
        /// <summary>
        /// 图片1,
        /// </summary>


        [DbProperty(MapingColumnName = "Img1", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Img1
        {
            get
            {
                return this._Img1;
            }
            set
            {

                this.OnPropertyChanged("Img1", this._Img1, value);
                this._Img1 = value;
            }
        }
        /// <summary>
        /// 图片2,
        /// </summary>


        [DbProperty(MapingColumnName = "Img2", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Img2
        {
            get
            {
                return this._Img2;
            }
            set
            {

                this.OnPropertyChanged("Img2", this._Img2, value);
                this._Img2 = value;
            }
        }
        /// <summary>
        /// 图片3,
        /// </summary>


        [DbProperty(MapingColumnName = "Img3", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Img3
        {
            get
            {
                return this._Img3;
            }
            set
            {

                this.OnPropertyChanged("Img3", this._Img3, value);
                this._Img3 = value;
            }
        }
        /// <summary>
        /// 值3,
        /// </summary>


        [DbProperty(MapingColumnName = "Value3", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Value3
        {
            get
            {
                return this._Value3;
            }
            set
            {

                this.OnPropertyChanged("Value3", this._Value3, value);
                this._Value3 = value;
            }
        }
        /// <summary>
        /// 值3类型,
        /// </summary>


        [DbProperty(MapingColumnName = "V3Type", DbTypeString = "NVarChar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string V3Type
        {
            get
            {
                return this._V3Type;
            }
            set
            {

                this.OnPropertyChanged("V3Type", this._V3Type, value);
                this._V3Type = value;
            }
        }
        /// <summary>
        /// 值4类型,
        /// </summary>


        [DbProperty(MapingColumnName = "V4Type", DbTypeString = "NVarChar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string V4Type
        {
            get
            {
                return this._V4Type;
            }
            set
            {

                this.OnPropertyChanged("V4Type", this._V4Type, value);
                this._V4Type = value;
            }
        }
        /// <summary>
        /// 值4,
        /// </summary>


        [DbProperty(MapingColumnName = "Value4", DbTypeString = "NVarChar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Value4
        {
            get
            {
                return this._Value4;
            }
            set
            {

                this.OnPropertyChanged("Value4", this._Value4, value);
                this._Value4 = value;
            }
        }
        /// <summary>
        /// 值5类型,
        /// </summary>


        [DbProperty(MapingColumnName = "V5Type", DbTypeString = "NVarChar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string V5Type
        {
            get
            {
                return this._V5Type;
            }
            set
            {

                this.OnPropertyChanged("V5Type", this._V5Type, value);
                this._V5Type = value;
            }
        }
        /// <summary>
        /// 值5,
        /// </summary>


        [DbProperty(MapingColumnName = "Value5", DbTypeString = "NVarChar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Value5
        {
            get
            {
                return this._Value5;
            }
            set
            {

                this.OnPropertyChanged("Value5", this._Value5, value);
                this._Value5 = value;
            }
        }
        /// <summary>
        /// 可有叶子节点,
        /// </summary>


        [DbProperty(MapingColumnName = "IsCanHasLeaf", DbTypeString = "Bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public bool IsCanHasLeaf
        {
            get
            {
                return this._IsCanHasLeaf;
            }
            set
            {

                this.OnPropertyChanged("IsCanHasLeaf", this._IsCanHasLeaf, value);
                this._IsCanHasLeaf = value;
            }
        }
        /// <summary>
        /// 值1说明,
        /// </summary>


        [DbProperty(MapingColumnName = "V1Note", DbTypeString = "NVarChar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string V1Note
        {
            get
            {
                return this._V1Note;
            }
            set
            {

                this.OnPropertyChanged("V1Note", this._V1Note, value);
                this._V1Note = value;
            }
        }
        /// <summary>
        /// 值2说明,
        /// </summary>


        [DbProperty(MapingColumnName = "V2Note", DbTypeString = "NVarChar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string V2Note
        {
            get
            {
                return this._V2Note;
            }
            set
            {

                this.OnPropertyChanged("V2Note", this._V2Note, value);
                this._V2Note = value;
            }
        }
        /// <summary>
        /// 值3说明,
        /// </summary>


        [DbProperty(MapingColumnName = "V3Note", DbTypeString = "NVarChar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string V3Note
        {
            get
            {
                return this._V3Note;
            }
            set
            {

                this.OnPropertyChanged("V3Note", this._V3Note, value);
                this._V3Note = value;
            }
        }
        /// <summary>
        /// 值4说明,
        /// </summary>


        [DbProperty(MapingColumnName = "V4Note", DbTypeString = "NVarChar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string V4Note
        {
            get
            {
                return this._V4Note;
            }
            set
            {

                this.OnPropertyChanged("V4Note", this._V4Note, value);
                this._V4Note = value;
            }
        }
        /// <summary>
        /// 值5说明,
        /// </summary>


        [DbProperty(MapingColumnName = "V5Note", DbTypeString = "NVarChar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string V5Note
        {
            get
            {
                return this._V5Note;
            }
            set
            {

                this.OnPropertyChanged("V5Note", this._V5Note, value);
                this._V5Note = value;
            }
        }


        #endregion

        #region 列定义

        public class Column
        {
            public Column(string tableName)
            {
                ID = new PropertyItem("ID", tableName);
                ParentID = new PropertyItem("ParentID", tableName);
                Code = new PropertyItem("Code", tableName);
                Name = new PropertyItem("Name", tableName);
                Value = new PropertyItem("Value", tableName);
                Value2 = new PropertyItem("Value2", tableName);
                ClassCode = new PropertyItem("ClassCode", tableName);
                IsDetails = new PropertyItem("IsDetails", tableName);
                Series = new PropertyItem("Series", tableName);
                IsSystem = new PropertyItem("IsSystem", tableName);
                IsEdit = new PropertyItem("IsEdit", tableName);
                IsDelete = new PropertyItem("IsDelete", tableName);
                IsEnable = new PropertyItem("IsEnable", tableName);
                Note = new PropertyItem("Note", tableName);
                OrderNo = new PropertyItem("OrderNo", tableName);
                V1Type = new PropertyItem("V1Type", tableName);
                V2Type = new PropertyItem("V2Type", tableName);
                Img1 = new PropertyItem("Img1", tableName);
                Img2 = new PropertyItem("Img2", tableName);
                Img3 = new PropertyItem("Img3", tableName);
                Value3 = new PropertyItem("Value3", tableName);
                V3Type = new PropertyItem("V3Type", tableName);
                V4Type = new PropertyItem("V4Type", tableName);
                Value4 = new PropertyItem("Value4", tableName);
                V5Type = new PropertyItem("V5Type", tableName);
                Value5 = new PropertyItem("Value5", tableName);
                IsCanHasLeaf = new PropertyItem("IsCanHasLeaf", tableName);
                V1Note = new PropertyItem("V1Note", tableName);
                V2Note = new PropertyItem("V2Note", tableName);
                V3Note = new PropertyItem("V3Note", tableName);
                V4Note = new PropertyItem("V4Note", tableName);
                V5Note = new PropertyItem("V5Note", tableName);

            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 父ID,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 编码,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 对应值,
            /// </summary> 
            public PropertyItem Value = null;
            /// <summary>
            /// 对应值2,
            /// </summary> 
            public PropertyItem Value2 = null;
            /// <summary>
            /// 分级码,
            /// </summary> 
            public PropertyItem ClassCode = null;
            /// <summary>
            /// 明细,
            /// </summary> 
            public PropertyItem IsDetails = null;
            /// <summary>
            /// 级数,
            /// </summary> 
            public PropertyItem Series = null;
            /// <summary>
            /// 系统参数,分类用，后续会分出两个维护界面，一个供开发人员使用，一个供用户使用
            /// </summary> 
            public PropertyItem IsSystem = null;
            /// <summary>
            /// 可编辑,
            /// </summary> 
            public PropertyItem IsEdit = null;
            /// <summary>
            /// 可删除,
            /// </summary> 
            public PropertyItem IsDelete = null;
            /// <summary>
            /// 可用,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
            /// <summary>
            /// 值1类型,
            /// </summary> 
            public PropertyItem V1Type = null;
            /// <summary>
            /// 值2类型,
            /// </summary> 
            public PropertyItem V2Type = null;
            /// <summary>
            /// 图片1,
            /// </summary> 
            public PropertyItem Img1 = null;
            /// <summary>
            /// 图片2,
            /// </summary> 
            public PropertyItem Img2 = null;
            /// <summary>
            /// 图片3,
            /// </summary> 
            public PropertyItem Img3 = null;
            /// <summary>
            /// 值3,
            /// </summary> 
            public PropertyItem Value3 = null;
            /// <summary>
            /// 值3类型,
            /// </summary> 
            public PropertyItem V3Type = null;
            /// <summary>
            /// 值4类型,
            /// </summary> 
            public PropertyItem V4Type = null;
            /// <summary>
            /// 值4,
            /// </summary> 
            public PropertyItem Value4 = null;
            /// <summary>
            /// 值5类型,
            /// </summary> 
            public PropertyItem V5Type = null;
            /// <summary>
            /// 值5,
            /// </summary> 
            public PropertyItem Value5 = null;
            /// <summary>
            /// 可有叶子节点,
            /// </summary> 
            public PropertyItem IsCanHasLeaf = null;
            /// <summary>
            /// 值1说明,
            /// </summary> 
            public PropertyItem V1Note = null;
            /// <summary>
            /// 值2说明,
            /// </summary> 
            public PropertyItem V2Note = null;
            /// <summary>
            /// 值3说明,
            /// </summary> 
            public PropertyItem V3Note = null;
            /// <summary>
            /// 值4说明,
            /// </summary> 
            public PropertyItem V4Note = null;
            /// <summary>
            /// 值5说明,
            /// </summary> 
            public PropertyItem V5Note = null;


        }
        #endregion
    }
    public partial class ParameterInfo : IConvertible
    {
        public override string ToString()
        {
            return this.Name;
        }
        protected override void OnCreate()
        {
           
            IsSystem = IsEdit = IsEnable = IsCanHasLeaf = true;
        }
        [NotDbCol]
        public string ParentName { get; set; }
        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return this;
        }
        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return this.Name;
        }



        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }
}
