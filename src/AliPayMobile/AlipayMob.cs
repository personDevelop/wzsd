using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection; 
using Sharp.Common;
using AliPayCommon;

namespace AliPayMobileClient
{
    /// <summary>
    /// 把所有数组值以 key= "value"进行组合，之后用“&”字符连接起来，支持无序
    ///例如： partner="2088101568358171"&seller_id="xxx@alipay.com"&out_trade_no="0819145412-6177"&subject=" 测 试 "&body=" 测 试 测 试
    ///"&total_fee="0.01"&notify_url="http://notify.msp.hk/notify.htm"&service="mobile.securitypay.pay"&payment_type="1"&_input_charset="utf-8"&it_b_pay=
    ///"30m"&sign="lBBK%2F0w5LOajrMrji7DUgEqNjIhQbidR13GovA5r3TgIbNqv231yC1NksLd
    ///w%2Ba3JnfHXoXuet6XNNHtn7VE%2BeCoRO1O%2BR1KugLrQEZMtG5jmJIe2pbjm%2F3kb%2Fu
    ///GkpG%2BwYQYI51%2BhA3YBbvZHVQBYveBqK%2Bh8mUyb7GM1HxWs9k4%3D"&sign_type="RSA"
    /// </summary>
    public class AlipayMob: BaseAlipay
    { 
        #region 基本参数
        /// <summary>
        /// 接口名称
        /// </summary>
        public override  string service
        {
            get { return "mobile.securitypay.pay"; }

        }  
        /// <summary>
        /// 标识客户端  可空 
        /// </summary>
        public string app_id { get; set; }

        /// <summary>
        /// 客户端来源 标识客户端来源。 参数值内容约定如下：
        /// appenv=”system=客户端平台名^version=业务系统版本”，例如：
        /// appenv=”system=iphone^version=3.0.1.2”appenv=”system=ipad^version=4.0.1.1”
        /// </summary>
        public string appenv { get; set; }
        #endregion
         

        
    }

   
}


  
