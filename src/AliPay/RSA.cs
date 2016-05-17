using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using AliPayCommon;

namespace AliPayPcClient
{
    /// <summary>
    /// 类名：RSAFromPkcs8
    /// 功能：RSA解密、签名、验签
    /// 详细：该类对Java生成的密钥进行解密和签名以及验签专用类，不需要修改
    /// 版本：2.0
    /// 修改日期：2011-05-10
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// </summary>
    public sealed class RSAFromPkcs8ForPc : RSAFromPkcs8ForMoblie
    {
        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="content">需要签名的内容</param>
        /// <param name="privateKey">私钥</param>
        /// <param name="input_charset">编码格式</param>
        /// <returns></returns>
        public override string sign(string data, string privateKey, string charset)
        {
            privateKey = privateKey.Replace("\r\n", "").Replace(" ", "").Trim();
            byte[] dataBytes = Convert.FromBase64String(privateKey);
            RSACryptoServiceProvider rsaCsp = DecodeRSAPrivateKey(dataBytes);//这个和mobiel的不一样
            
            dataBytes = Encoding.GetEncoding(charset).GetBytes(data);


            byte[] signatureBytes = rsaCsp.SignData(dataBytes, "SHA1");

            return Convert.ToBase64String(signatureBytes);
        }

    }
}
