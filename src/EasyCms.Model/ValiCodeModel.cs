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
        /// 类型区分  0,注册、1.登录、2.购物等
        /// </summary>
        public int TypeInfo { get; set; }
    }
}
