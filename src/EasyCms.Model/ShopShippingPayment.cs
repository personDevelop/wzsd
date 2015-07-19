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
    /// 配送支付关联表
    /// </summary>  
   [JsonObject]
   public partial class ShopShippingPayment : BaseEntity
    {
        public static Column _ = new Column("ShopShippingPayment");

        public ShopShippingPayment()
        {
            this.TableName = "ShopShippingPayment";
  OnCreate();
        }
      

        #region 私有变量
		
		private string_ID;
		
		private string_ShippingModeId;
		
		private string_PaymentModeId;
		  
		#endregion

        #region 属性
		
		/// <summary>
        ///  主键ID,
        /// </summary>
		
		[PrimaryKey]  
		[DbProperty(MapingColumnName = "ID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength =  36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
       
        public string  ID
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
        ///  配送方式ID,
        /// </summary>
		 
		[DbProperty(MapingColumnName = "ShippingModeId", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength =  36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
       
        public string  ShippingModeId
        {
            get
            {
                return this._ShippingModeId;
            }
            set
            { 
				this.OnPropertyChanged("ShippingModeId", this._ShippingModeId, value);
                this._ShippingModeId = value;
            }
        }
		
		/// <summary>
        ///  支付方式ID,
        /// </summary>
		 
		[DbProperty(MapingColumnName = "PaymentModeId", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength =  36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
       
        public string  PaymentModeId
        {
            get
            {
                return this._PaymentModeId;
            }
            set
            { 
				this.OnPropertyChanged("PaymentModeId", this._PaymentModeId, value);
                this._PaymentModeId = value;
            }
        }
		  
		#endregion

        #region 列定义 
        public class Column
        {
            public Column(string tableName)
            {
			
			ID= new PropertyItem("ID", tableName);
			
			ShippingModeId= new PropertyItem("ShippingModeId", tableName);
			
			PaymentModeId= new PropertyItem("PaymentModeId", tableName);
			
          
            }
			 /// <summary>
            /// 主键ID,
            /// </summary> 
            public PropertyItem ID = null; 
			 /// <summary>
            /// 配送方式ID,
            /// </summary> 
            public PropertyItem ShippingModeId = null; 
			 /// <summary>
            /// 支付方式ID,
            /// </summary> 
            public PropertyItem PaymentModeId = null; 
			 }
			#endregion
    } 
}
