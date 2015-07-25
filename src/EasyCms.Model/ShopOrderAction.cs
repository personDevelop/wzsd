﻿using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace EasyCms.Model
{
    /// <summary>
    /// 订单动作记录
    /// </summary>  
    [JsonObject]
    public partial class ShopOrderAction : BaseEntity
    {
        public static Column _ = new Column("ShopOrderAction");

        public ShopOrderAction()
        {
            this.TableName = "ShopOrderAction";
            OnCreate();
        }


        #region 私有变量

        private string _ID;

        private string _OrderId;

        private string _UserId;

        private string _Username;

        private string _ActionCode;

        private DateTime _ActionDate;

        private string _Remark;

        private string _ActionName;

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
        ///  订单ID,
        /// </summary>

        [DbProperty(MapingColumnName = "OrderId", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string OrderId
        {
            get
            {
                return this._OrderId;
            }
            set
            {
                this.OnPropertyChanged("OrderId", this._OrderId, value);
                this._OrderId = value;
            }
        }

        /// <summary>
        ///  操作人ID,
        /// </summary>

        [DbProperty(MapingColumnName = "UserId", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                this.OnPropertyChanged("UserId", this._UserId, value);
                this._UserId = value;
            }
        }

        /// <summary>
        ///  操作人,
        /// </summary>

        [DbProperty(MapingColumnName = "Username", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string Username
        {
            get
            {
                return this._Username;
            }
            set
            {
                this.OnPropertyChanged("Username", this._Username, value);
                this._Username = value;
            }
        }

        /// <summary>
        ///  操作编号,
        /// </summary>

        [DbProperty(MapingColumnName = "ActionCode", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ActionCode
        {
            get
            {
                return this._ActionCode;
            }
            set
            {
                this.OnPropertyChanged("ActionCode", this._ActionCode, value);
                this._ActionCode = value;
            }
        }

        /// <summary>
        ///  操作时间,
        /// </summary>

        [DbProperty(MapingColumnName = "ActionDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public DateTime ActionDate
        {
            get
            {
                return this._ActionDate;
            }
            set
            {
                this.OnPropertyChanged("ActionDate", this._ActionDate, value);
                this._ActionDate = value;
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
        ///  操作名称,
        /// </summary>

        [DbProperty(MapingColumnName = "ActionName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]

        public string ActionName
        {
            get
            {
                return this._ActionName;
            }
            set
            {
                this.OnPropertyChanged("ActionName", this._ActionName, value);
                this._ActionName = value;
            }
        }

        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                OrderId = new PropertyItem("OrderId", tableName);

                UserId = new PropertyItem("UserId", tableName);

                Username = new PropertyItem("Username", tableName);

                ActionCode = new PropertyItem("ActionCode", tableName);

                ActionDate = new PropertyItem("ActionDate", tableName);

                Remark = new PropertyItem("Remark", tableName);

                ActionName = new PropertyItem("ActionName", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 订单ID,
            /// </summary> 
            public PropertyItem OrderId = null;
            /// <summary>
            /// 操作人ID,
            /// </summary> 
            public PropertyItem UserId = null;
            /// <summary>
            /// 操作人,
            /// </summary> 
            public PropertyItem Username = null;
            /// <summary>
            /// 操作编号,
            /// </summary> 
            public PropertyItem ActionCode = null;
            /// <summary>
            /// 操作时间,
            /// </summary> 
            public PropertyItem ActionDate = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Remark = null;
            /// <summary>
            /// 操作名称,
            /// </summary> 
            public PropertyItem ActionName = null;
        }
        #endregion
    }
}