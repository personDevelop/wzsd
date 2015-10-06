using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model
{
    public class ValiCodeModel
    {

        //[RegularExpression(@"^1[3458][0-9]{9}$", ErrorMessage = "手机号格式不正确")]
        public string TelNo { get; set; }
        /// <summary>
        /// 类型区分  
        /// </summary>
        public ValidCode TypeInfo { get; set; }

        /// <summary>
        /// 发送方式  
        /// </summary>
        public ValidType SendType { get; set; }
    }
}
