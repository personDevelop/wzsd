using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AliPay
{
   
   // <summary>
    /// 类名：Config   这个类 可以用实体数据库获取的方式代替
    /// 功能：基础配置类
    /// 详细：设置帐户有关信息及返回路径
    /// 版本：3.4
    /// 修改日期：2016-03-08
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// </summary>
    public class AlipayConfig
    {

        //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        // 合作身份者ID，签约账号，以2088开头由16位纯数字组成的字符串，查看地址：https://b.alipay.com/order/pidAndKey.htm
        //public static string partner = "";

        // 收款支付宝账号，以2088开头由16位纯数字组成的字符串，一般情况下收款账号就是签约账号
        //public static string seller_id = partner;

        //商户的私钥文件路径,原始格式，RSA公私钥生成：https://doc.open.alipay.com/doc2/detail.htm?spm=a219a.7629140.0.0.nBDxfy&treeId=58&articleId=103242&docType=1
        public static string private_key = HttpRuntime.AppDomainAppPath.ToString() + "key\\rsa_private_key.pem";

        //支付宝的公钥文件路径，查看地址：https://b.alipay.com/order/pidAndKey.htm 
        public static string alipay_public_key = HttpRuntime.AppDomainAppPath.ToString() + "key\\alipay_public_key.pem";

        // 服务器异步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数,必须外网可以正常访问
        //public static string notify_url = "http://商户网关地址/create_direct_pay_by_user-CSHARP-UTF-8/notify_url.aspx";

        // 页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
        //public static string return_url = "http://商户网关地址/create_direct_pay_by_user-CSHARP-UTF-8/return_url.aspx";

        // 签名方式
        public static string sign_type = "RSA";

        // 调试用，创建TXT日志文件夹路径，见AlipayCore.cs类中的LogResult(string sWord)打印方法。
        public static string log_path = HttpRuntime.AppDomainAppPath.ToString() + "log\\";

        // 字符编码格式 目前支持 gbk 或 utf-8
        //public static string input_charset = "utf-8";

        // 支付类型 ，无需修改
        //public static string payment_type = "1";

        // 调用的接口名，无需修改
        //public static string service = "create_direct_pay_by_user";

        //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑


        //↓↓↓↓↓↓↓↓↓↓请在这里配置防钓鱼信息，如果没开通防钓鱼功能，请忽视不要填写 ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        //防钓鱼时间戳  若要使用请调用类文件submit中的Query_timestamp函数
        public static string anti_phishing_key = "";

        //客户端的IP地址 非局域网的外网IP地址，如：221.0.0.1
        public static string exter_invoke_ip = "";

        //↑↑↑↑↑↑↑↑↑↑请在这里配置防钓鱼信息，如果没开通防钓鱼功能，请忽视不要填写 ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

    }
}
