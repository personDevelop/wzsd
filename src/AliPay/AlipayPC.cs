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
        public string privatkey=string.Empty;
        //支付宝网关地址（新）
        private static string GATEWAY_NEW = "https://mapi.alipay.com/gateway.do?";
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
            this.privatkey = privatkey;
            SortedDictionary<string, string> list = new SortedDictionary<string, string>();
            list.Add("service", service);
            list.Add("partner", partner);
            list.Add("_input_charset", _input_charset);
            list.Add("notify_url", notify_url);
            list.Add("out_trade_no", out_trade_no);
            list.Add("subject", subject);
            list.Add("payment_type", payment_type);
            list.Add("seller_id", seller_id);
            list.Add("total_fee", total_fee);
            list.Add("it_b_pay", it_b_pay);
            list.Add("body", body);
            list.Add("return_url", return_url);
            Dictionary<string, string> dicPara = new Dictionary<string, string>();
            dicPara =  BuildRequestPara(list);
    
            
            StringBuilder sbHtml = new StringBuilder();

            sbHtml.AppendFormat("<form id='alipaysubmit' name='alipaysubmit' action='{0}_input_charset={1}' method='{2}'>", GATEWAY_NEW, _input_charset, "get");

            foreach (KeyValuePair<string, string> temp in dicPara)
            {
                sbHtml.AppendFormat("<input type='hidden' name='{0}' value='{1}'/>", temp.Key, temp.Value);
            }

            //submit按钮控件请不要含有name属性
            sbHtml.AppendFormat("<input type='submit' value='{0}' style='display:none;'></form>", "确认");

            sbHtml.Append("<script>document.forms['alipaysubmit'].submit();</script>");

            return sbHtml.ToString();
        }

        private   Dictionary<string, string> BuildRequestPara(SortedDictionary<string, string> sParaTemp)
        {
            //待签名请求参数数组
            Dictionary<string, string> sPara = new Dictionary<string, string>();
            //签名结果
            string mysign = "";

            //过滤签名参数数组
            sPara = Core.FilterPara(sParaTemp);

            //获得签名结果
            mysign = BuildRequestMysign(sPara);

            //签名结果与签名方式加入请求提交参数组中
            sPara.Add("sign", mysign);
            sPara.Add("sign_type", sign_type);

            return sPara;
        }
        // <summary>
        /// 生成请求时的签名
        /// </summary>
        /// <param name="sPara">请求给支付宝的参数数组</param>
        /// <returns>签名结果</returns>
        private   string BuildRequestMysign(Dictionary<string, string> sPara)
        {
            //把数组所有元素，按照“参数=参数值”的模式用“&”字符拼接成字符串
            string prestr = Core.CreateLinkString(sPara);

            //把最终的字符串签名，获得签名结果
            string mysign = "";
            switch (sign_type)
            {
                case "RSA":
                    mysign =new  RSAFromPkcs8ForPc().sign(prestr, privatkey, _input_charset);
                    break;
                default:
                    mysign = "";
                    break;
            }

            return mysign;
        }
    }
     
}



