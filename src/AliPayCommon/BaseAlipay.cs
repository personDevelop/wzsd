using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;

namespace AliPayCommon
{
   public  class BaseAlipay
    { 
            #region 基本参数
            /// <summary>
            /// 接口名称
            /// </summary>
            public virtual string service
            {
                get { return "mobile.securitypay.pay"; }

            }
            /// <summary>
            /// 合作者身份 ID
            /// </summary>
            public string partner { get; set; }


            /// <summary>
            /// 参数编码字符集
            /// </summary>
            public string _input_charset { get { return "utf-8"; } }
            /// <summary>
            /// 签名类型，目前仅支持 RSA
            /// </summary>
            public string sign_type { get { return "RSA"; } }

            /// <summary>
            /// sign
            /// </summary>
            public string sign { get; set; }

            /// <summary>
            /// 服务器异步通知页面路径,支付宝服务器主动通知商户网站里指定的页面 http 路径
            /// </summary>
            public string notify_url { get; set; } 
            
            #endregion

            #region 业务参数
            /// <summary>
            /// 商户网站唯一订单号
            /// </summary>
            public string out_trade_no { get; set; }
            /// <summary>
            /// 商品名称 商品的标题/交易标题/订单标题/订单关键字等。该参数最长为 128 个汉字
            /// </summary>
            public string subject { get; set; }
            /// <summary>
            /// 支付类型 默认值为：1（商品购买）。
            /// </summary>
            public string payment_type { get { return "1"; } }
            /// <summary>
            /// 卖家支付宝账号,卖家支付宝账号 （邮箱或手机号码格式） 或其对应的支付宝唯一用户号（以 2088 开头的纯 16 位数字）
            /// </summary>
            public string seller_id { get; set; }
            /// <summary>
            /// 总金额  该笔订单的资金总额， 单位为RMB-Yuan。取值范围为[0.01，100000000.00]，精确到小数点后两位。
            /// </summary>
            public string total_fee { get; set; }
            /// <summary>
            /// 商品详情 512 对一笔交易的具体描述信息。
            /// 如果是多种商品， 请将商品描
            /// 述字符串累加传给 body。
            /// </summary>
            public string body { get; set; }

            string it_pay = "30m";
            /// <summary>
            /// 未付款交易的超时时间  默认30m
            /// 设置未付款交易的超时时间，
            /// 一旦超时， 该笔交易就会自动被关闭。
            ///    当用户输入支付密码、 点击确认付款后 （即创建支付宝交易后）开始计时。
            /// 取值范围：1m～15d，或者使用绝对时间（示例格式：2014-06-13 16:00:00）。m-分钟，h-小时，d-天，
            ///     1c-当天（无论交易何时创建，都在 0 点关闭）。
            /// 该参数数值不接受小数点， 如1.5h，可转换为 90m。
            /// </summary>
            public string it_b_pay { get { return it_pay; } set { it_pay = value; } }


            /// <summary>
            /// 授权令牌  可空
            /// 开放平台返回的包含账户信息的 token（授权令牌，商户在一定时间内对支付宝某些服务的访问权限）。
            /// 通过授权登录后获取的alipay_open_id，作为该参数的 value，登录授权账户即会为支付账户
            /// </summary>
            public string extern_token { get; set; }
            #endregion


            public virtual string GenerSign(string privatkey)
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
                string sign = new RSAFromPkcs8ForMoblie().sign(result, privatkey, _input_charset);
                sign = System.Web.HttpUtility.UrlEncode(sign, Encoding.UTF8);
                result = result + "&sign=\"" + sign + "\"&sign_type=\"RSA\"";
                result = result.EncryptDEC();//加密
                return result;
            }
        }
     
}
