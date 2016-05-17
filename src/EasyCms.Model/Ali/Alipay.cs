using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using EasyCms.Model.Ali;
using Sharp.Common;
namespace EasyCms.Model
{
    /// <summary>
    /// 把所有数组值以 key= "value"进行组合，之后用“&”字符连接起来，支持无序
    ///例如： partner="2088101568358171"&seller_id="xxx@alipay.com"&out_trade_no="0819145412-6177"&subject=" 测 试 "&body=" 测 试 测 试
    ///"&total_fee="0.01"&notify_url="http://notify.msp.hk/notify.htm"&service="mobile.securitypay.pay"&payment_type="1"&_input_charset="utf-8"&it_b_pay=
    ///"30m"&sign="lBBK%2F0w5LOajrMrji7DUgEqNjIhQbidR13GovA5r3TgIbNqv231yC1NksLd
    ///w%2Ba3JnfHXoXuet6XNNHtn7VE%2BeCoRO1O%2BR1KugLrQEZMtG5jmJIe2pbjm%2F3kb%2Fu
    ///GkpG%2BwYQYI51%2BhA3YBbvZHVQBYveBqK%2Bh8mUyb7GM1HxWs9k4%3D"&sign_type="RSA"
    /// </summary>
    public class Alipay
    {


        #region 基本参数
        /// <summary>
        /// 接口名称
        /// </summary>
        public string service
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
        /// // 页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
        /// = "http://商户网关地址/create_direct_pay_by_user-CSHARP-UTF-8/return_url.aspx";
        /// </summary>
        public static string return_url { get { return "m.alipay.com"; }  } 

        /// <summary>
        /// 授权令牌  可空
        /// 开放平台返回的包含账户信息的 token（授权令牌，商户在一定时间内对支付宝某些服务的访问权限）。
        /// 通过授权登录后获取的alipay_open_id，作为该参数的 value，登录授权账户即会为支付账户
        /// </summary>
        public string extern_token { get; set; }
        #endregion


        public string GenerSign(string privatkey)
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
            list.Add(string.Format("return_url=\"{0}\"", return_url));
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

    public class AliPayConfig
    {
        public string Partner { get; set; }
        public string PublicKey { get; set; }

        public string SecretKey { get; set; }

        public string input_charset = "utf-8";
        public string sign_type = "RSA";

        //支付宝消息验证地址
        public string Https_veryfy_url = "https://mapi.alipay.com/gateway.do?service=notify_verify&";

    }
    /// <summary>
    /// 服务器异步通知
    /// 支付宝对商户的请求数据处理完成后， 会将处理的结果数据通过服务器主动通知的
    ///方式通知给商户网站。这些处理结果数据就是服务器异步通知参数
    /// </summary>
    public class AliAsynchNotify
    {
        public static AliAsynchNotify Phrase(SortedDictionary<string, string> keyvalue)
        {
            AliAsynchNotify notify = new AliAsynchNotify();
            foreach (KeyValuePair<string, string> item in keyvalue)
            {
                foreach (PropertyInfo pro in props)
                {
                    if (pro.Name == item.Key)
                    {
                        pro.SetValue(notify, item.Value, null);
                        break;
                    }
                }
            }
            return notify;

        }
        public static System.Reflection.PropertyInfo[] props = typeof(AliAsynchNotify).GetProperties(System.Reflection.BindingFlags.CreateInstance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        #region 基本参数
        /// <summary>
        /// 通知的发送时间。
        ///格式为 yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string notify_time { get; set; }

        /// <summary>
        /// 通知类型 例如trade_status_sync
        /// </summary>
        public string notify_type { get; set; }
        /// <summary>
        /// 通知校验 ID
        /// </summary>
        public string notify_id { get; set; }

        /// <summary>
        /// 签名方式 固定取值为 RSA
        /// </summary>
        public string sign_type { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
        #endregion

        #region 业务参数
        /// <summary>
        /// 商户网站唯一订单号
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string subject { get; set; }


        /// <summary>
        /// 支付类型 支付类型。默认值为：1（商品购买）
        /// </summary>
        public string payment_type { get; set; }
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string trade_no { get; set; }


        /// <summary>
        /// 交易状态
        /// </summary>
        public string trade_status { get; set; }
        /// <summary>
        ///卖家支付宝用户号卖家支付宝账号对应的支付宝唯一用户号。以 2088 开头的纯 16 位数字
        /// </summary>
        public string seller_id { get; set; }


        /// <summary>
        /// 卖家支付宝账号
        /// </summary>
        public string seller_email { get; set; }
        /// <summary>
        ///买家支付宝用户号支付宝账号对应的支付宝唯一用户号。以 2088 开头的纯 16 位数字
        /// </summary>
        public string buyer_id { get; set; }


        /// <summary>
        /// 买家支付宝账号
        /// </summary>
        public string buyer_emai { get; set; }
        /// <summary>
        ///交易金额
        /// </summary>
        public string total_fee { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public string quantity { get; set; }
        /// <summary>
        ///商品单价
        /// </summary>
        public string price { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string body { get; set; }
        /// <summary>
        ///交易创建时间  2013-08-22 14:45:23
        /// </summary>
        public string gmt_create { get; set; }
        /// <summary>
        /// 交易付款时间   2013-08-22 14:45:23
        /// </summary>
        public string gmt_payment { get; set; }
        /// <summary>
        ///是否调整总价 (N)
        /// </summary>
        public string is_total_fee_adjust { get; set; }
        /// <summary>
        /// 是否使用红包买家 (N)
        /// </summary>
        public string use_coupon { get; set; }
        /// <summary>
        ///折扣 支付宝系统会把 discount 的值加到交易金额上，如果有折扣，
        ///本参数为负数，单位为元
        /// </summary>
        public string discount { get; set; }

        /// <summary>
        /// 退款状态
        /// </summary>
        public string refund_status { get; set; }
        /// <summary>
        ///退款时间
        /// </summary>
        public string gmt_refund { get; set; }
        #endregion


    }


    /// <summary>
    /// 支付状态
    /// </summary>
    public enum AliPayStatus
    {
        订单支付失败 = 4000,
        用户中途取消 = 6001,
        网络连接出错 = 6002,
        正在处理中 = 8000,
        支付成功 = 9000,

    }
    /// <summary>
    /// 交易状态
    /// </summary>
    public enum AliTradeStatus
    {
        /// <summary>
        /// WAIT_BUYER_PAY
        /// </summary>
        WAIT_BUYER_PAY,
        /// <summary>
        ///1.在指定时间段内未支付时关闭的交易；
        ///2.在交易完成全额退款成功时关闭的交易。
        /// </summary>
        TRADE_CLOSED,
        /// <summary>
        /// 交易成功，且可对该交易做操作，如：多级分润、退款等。
        /// </summary>
        TRADE_SUCCESS,
        /// <summary>
        /// 交易成功且结束，即不可再做任何操作。
        /// </summary>
        TRADE_FINISHED
    }
    /// <summary>
    /// 退款状态
    /// </summary>
    public enum AliReturnStatus
    {
        /// <summary>
        /// 退款成功：全额退款情况：trade_status= TRADE_CLOSED，而
        ///refund_status=REFUND_SUCCESS
        ///非全额退款情况：trade_status= TRADE_SUCCESS，
        ///而 refund_status=REFUND_SUCCESS
        /// </summary>
        REFUND_SUCCESS,

        /// <summary>
        /// 退款关闭
        /// </summary>
        REFUND_CLOSED
    }
}
