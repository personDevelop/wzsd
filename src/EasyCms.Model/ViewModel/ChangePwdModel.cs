using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model.ViewModel
{
    public class ChangePwdModel
    {
        public string OldPwd { get; set; }

        public string NewPwd { get; set; }


        public string ValidCode { get; set; }

    }

    public class ResetPwdModel
    {

        /// <summary>
        /// 支持账号、手机号、邮箱
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        ///  手机短信,
        ///邮箱,
        ///手机和短信
        /// </summary>
        public ValidType VaryType { get; set; }
    }
    public class ResetPwdPostModel
    {
        /// <summary>
        /// 支持账号、手机号、邮箱
        /// </summary>
        public string Account { get; set; }
        public string NewPwd { get; set; }
        public string ConfirmNewPwd { get; set; }

        public ValidType VaryType { get; set; }

        /// <summary>
        /// 手机号或邮箱接收到的值
        /// </summary>
        public string ValidCode { get; set; }
         

    }
}
