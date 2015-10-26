using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCms.Model.ViewModel
{

    /// <summary>
    /// 管理员用户表
    /// </summary>  
    public class UserInfo
    { 
        #region 属性
        /// <summary>
        ///  主键ID,
        /// </summary> 
        public string ID
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
        ///  生日,
        /// </summary> 
        public string Birthday
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

              

        #endregion


    }

}
