using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AliPayCommon
{
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
        public static  PropertyInfo[] props = typeof(AliAsynchNotify).GetProperties(BindingFlags.CreateInstance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
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
}
