using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model.ViewModel
{ /// <summary>
    ///  用户表,主要是前端展示用
    /// </summary> 
    [Newtonsoft.Json.JsonObject]
    public class AccountModel
    {
        #region 属性
        /// <summary>
        ///  用户ID,
        /// </summary> 
        public string ID
        {
            get;
            set;
        }

        /// <summary>
        ///  编号,
        /// </summary> 
        public string Code
        {
            get;
            set;
        }



        /// <summary>
        ///  姓名,
        /// </summary> 
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///  Email,
        /// </summary> 
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        ///  QQ,
        /// </summary> 
        public string QQ
        {
            get;
            set;
        }

        /// <summary>
        ///  头像,
        /// </summary> 
        public string Photo
        {
            get;
            set;
        }

        /// <summary>
        ///  昵称,
        /// </summary> 
        public string NickyName
        {
            get;
            set;
        }

        /// <summary>
        ///  个性签名,
        /// </summary> 
        public string Signature
        {
            get;
            set;
        }

        /// <summary>
        ///  身份证,
        /// </summary> 
        public string IDNumber
        {
            get;
            set;
        }

        /// <summary>
        ///  生日,
        /// </summary> 
        public DateTime? Birthday
        {
            get;
            set;
        }

        /// <summary>
        ///  性别,
        /// </summary> 
        public int Sex
        {
            get;
            set;
        }

        /// <summary>
        ///  联系手机,
        /// </summary> 
        public string ContactPhone
        {
            get;
            set;
        }



        /// <summary>
        ///  创建日期,
        /// </summary> 
        public DateTime CreateDate
        {
            get;
            set;
        }

        /// <summary>
        ///  最后修改日期,
        /// </summary> 
        public DateTime LastModifyDate
        {
            get;
            set;
        }



        /// <summary>
        ///  状态,
        /// </summary> 
        public int Status
        {
            get;
            set;
        }

        /// <summary>
        ///  备注,
        /// </summary> 
        public string Note
        {
            get;
            set;
        }


        /// <summary>
        ///  成长值,
        /// </summary> 
        public int GrowthValue
        {
            get;
            set;
        }
        /// <summary>
        ///  等级名称,
        /// </summary> 
        public string RangeName
        {
            get;
            set;
        }
        /// <summary>
        ///  积分,
        /// </summary> 
        public decimal JF
        {
            get;
            set;
        }

        /// <summary>
        ///  等级可享有的服务,
        /// </summary> 
        [JsonIgnore]
        public string HasService
        {
            get;
            set;
        }
        /// <summary>
        ///  等级可享有的服务,
        /// </summary> 

        public List<AccountService> AccountService
        {
            get;
            set;
        }
        /// <summary>
        ///  等级图标,
        /// </summary> 
        public string RangeImg
        {
            get;
            set;
        }

        #endregion

    }

    [Newtonsoft.Json.JsonObject]
    public class AccountService
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }

    }
}
