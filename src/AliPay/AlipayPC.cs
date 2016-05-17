using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection; 
using Sharp.Common;
using AliPayCommon;

namespace AliPayPcClient
{
    /// <summary>
    /// 把所有数组值以 key= "value"进行组合，之后用“&”字符连接起来，支持无序
    ///例如： partner="2088101568358171"&seller_id="xxx@alipay.com"&out_trade_no="0819145412-6177"&subject=" 测 试 "&body=" 测 试 测 试
    ///"&total_fee="0.01"&notify_url="http://notify.msp.hk/notify.htm"&service="mobile.securitypay.pay"&payment_type="1"&_input_charset="utf-8"&it_b_pay=
    ///"30m"&sign="lBBK%2F0w5LOajrMrji7DUgEqNjIhQbidR13GovA5r3TgIbNqv231yC1NksLd
    ///w%2Ba3JnfHXoXuet6XNNHtn7VE%2BeCoRO1O%2BR1KugLrQEZMtG5jmJIe2pbjm%2F3kb%2Fu
    ///GkpG%2BwYQYI51%2BhA3YBbvZHVQBYveBqK%2Bh8mUyb7GM1HxWs9k4%3D"&sign_type="RSA"
    /// </summary>
    public class AlipayPC : BaseAlipay
    {
         
        /// <summary>
        /// 接口名称
        /// </summary>
        public override  string service
        {
            get { return "create_direct_pay_by_user"; }

        }
         public string return_url { get; set; }

        //↓↓↓↓↓↓↓↓↓↓请在这里配置防钓鱼信息，如果没开通防钓鱼功能，请忽视不要填写 ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        //防钓鱼时间戳  若要使用请调用类文件submit中的Query_timestamp函数
        public static string anti_phishing_key = "";

        //客户端的IP地址 非局域网的外网IP地址，如：221.0.0.1
        public static string exter_invoke_ip = "";

        //↑↑↑↑↑↑↑↑↑↑请在这里配置防钓鱼信息，如果没开通防钓鱼功能，请忽视不要填写 ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
        public override string GenerSign(string privatkey)
        {
            List<string> list = new List<string>();
            list.Add(string.Format("service=\"{0}\"", service));
            list.Add(string.Format("partner=\"{0}\"", partner));
            list.Add(string.Format("_input_charset=\"{0}\"", _input_charset));
            list.Add(string.Format("notify_url=\"{0}\"", notify_url));
            list.Add(string.Format("out_trade_no=\"{0}\"", out_trade_no));
            list.Add(string.Format("subject=\"{0}\"", subject));
            list.Add(string.Format("payment_type=\"{0}\"", payment_type));
            list.Add(string.Format("seller_id=\"{0}\"", seller_id));
            list.Add(string.Format("total_fee=\"{0}\"", total_fee));
            list.Add(string.Format("it_b_pay=\"{0}\"", it_b_pay));
            list.Add(string.Format("body=\"{0}\"", body));
            list.Add(string.Format("return_url=\"{0}\"", "m.alipay.com"));
            string result = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0)
                {
                    result += "&";
                }
                result += list[i];
            }
            string sign = RSAFromPkcs8.sign(result, privatkey, _input_charset);
            sign = System.Web.HttpUtility.UrlEncode(sign, Encoding.UTF8);
            result = result + "&sign=\"" + sign + "\"&sign_type=\"RSA\"";
            result = result.EncryptDEC();//加密
            return result;
        }
    }

   
}


  
