using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCms.Model.ViewModel
{
    public class AppException
    {
        public string Info { get; set; }

        /// <summary>
        /// 可以存储一些系统相关信息
        /// </summary>
        public string ExtInfo { get; set; }

        /// <summary>
        /// 如果有的话，发送当前登录人的信息
        /// </summary>
        public string Token { get; set; }
    }
}
