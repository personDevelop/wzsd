﻿using Newtonsoft.Json;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model
{
    /// <summary>
    /// 积分历史记录表
    /// </summary>  
    [JsonObject]
    public partial class JFHistory : BaseEntity
    {
        public static Column _ = new Column("JFHistory");

        public JFHistory()
        {
            this.TableName = "JFHistory";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _MemberID;

        private int _FX;

        private string _JFSouce;

        private string _JFSouceMainID;

        private string _JFSouceSubID;

        private decimal _JFCount;

        private int _JFState;

        private DateTime _CreateDate;

        #endregion

        #region 属性

        /// <summary>
        ///  ID,
        /// </summary>

        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

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
        ///  会员ID,
        /// </summary>

        [DbProperty(MapingColumnName = "MemberID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string MemberID
        {
            get
            {
                return this._MemberID;
            }
            set
            {
                this.OnPropertyChanged("MemberID", this._MemberID, value);
                this._MemberID = value;
            }
        }

        /// <summary>
        ///  方向,0,增加，1减少
        /// </summary>

        [DbProperty(MapingColumnName = "FX", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int FX
        {
            get
            {
                return this._FX;
            }
            set
            {
                this.OnPropertyChanged("FX", this._FX, value);
                this._FX = value;
            }
        }

        /// <summary>
        ///  积分来源,参照积分类型，购物送积分，购物使用积分减少，注册送积分
        /// </summary>

        [DbProperty(MapingColumnName = "JFSouce", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 40, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string JFSouce
        {
            get
            {
                return this._JFSouce;
            }
            set
            {
                this.OnPropertyChanged("JFSouce", this._JFSouce, value);
                this._JFSouce = value;
            }
        }

        /// <summary>
        ///  积分来源主表ID,购物送的积分 则存购物ID,退单时用
        /// </summary>

        [DbProperty(MapingColumnName = "JFSouceMainID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string JFSouceMainID
        {
            get
            {
                return this._JFSouceMainID;
            }
            set
            {
                this.OnPropertyChanged("JFSouceMainID", this._JFSouceMainID, value);
                this._JFSouceMainID = value;
            }
        }

        /// <summary>
        ///  积分来源子表ID,购物送的则存对应的子明细ID,退单时用
        /// </summary>

        [DbProperty(MapingColumnName = "JFSouceSubID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string JFSouceSubID
        {
            get
            {
                return this._JFSouceSubID;
            }
            set
            {
                this.OnPropertyChanged("JFSouceSubID", this._JFSouceSubID, value);
                this._JFSouceSubID = value;
            }
        }

        /// <summary>
        ///  积分数量,
        /// </summary>

        [DbProperty(MapingColumnName = "JFCount", DbTypeString = "decimal", ColumnIsNull = false, IsUnique = false, ColumnLength = 9, ColumnJingDu = 2, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public decimal JFCount
        {
            get
            {
                return this._JFCount;
            }
            set
            {
                this.OnPropertyChanged("JFCount", this._JFCount, value);
                this._JFCount = value;
            }
        }

        /// <summary>
        ///  积分状态,0 在途，1 完成
        /// </summary>

        [DbProperty(MapingColumnName = "JFState", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public int JFState
        {
            get
            {
                return this._JFState;
            }
            set
            {
                this.OnPropertyChanged("JFState", this._JFState, value);
                this._JFState = value;
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

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                MemberID = new PropertyItem("MemberID", tableName);

                FX = new PropertyItem("FX", tableName);

                JFSouce = new PropertyItem("JFSouce", tableName);

                JFSouceMainID = new PropertyItem("JFSouceMainID", tableName);

                JFSouceSubID = new PropertyItem("JFSouceSubID", tableName);

                JFCount = new PropertyItem("JFCount", tableName);

                JFState = new PropertyItem("JFState", tableName);

                CreateDate = new PropertyItem("CreateDate", tableName);


            }
            /// <summary>
            /// ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 会员ID,
            /// </summary> 
            public PropertyItem MemberID = null;
            /// <summary>
            /// 方向,0,增加，1减少
            /// </summary> 
            public PropertyItem FX = null;
            /// <summary>
            /// 积分来源,参照积分类型，购物送积分，购物使用积分减少，注册送积分
            /// </summary> 
            public PropertyItem JFSouce = null;
            /// <summary>
            /// 积分来源主表ID,购物送的积分 则存购物ID,退单时用
            /// </summary> 
            public PropertyItem JFSouceMainID = null;
            /// <summary>
            /// 积分来源子表ID,购物送的则存对应的子明细ID,退单时用
            /// </summary> 
            public PropertyItem JFSouceSubID = null;
            /// <summary>
            /// 积分数量,
            /// </summary> 
            public PropertyItem JFCount = null;
            /// <summary>
            /// 积分状态,0 在途，1 完成
            /// </summary> 
            public PropertyItem JFState = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CreateDate = null;
        }
        #endregion
    }

}