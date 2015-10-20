using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sharp.Common;
namespace 接口测试
{
    public partial class frm签名测试 : Form
    {
        public frm签名测试()
        {
            InitializeComponent();
        }
        string publickey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDzOqfNunFxFtCZPlq7fO/jWwjqmTvAooVBB4y87BizSZ9dl/F7FpAxYc6MmX2TqivCvvORXgdlYdFWAhzXOnIUv9OGG///WPLe9TMs9kIwAZ/APUXauvC01oFLnYkzwPlAh0tQ1Au9arTE/OG1V1dKgf8BXHLPhKL4BmGBEUZBtQIDAQAB";
        string privatekey = "MIICeQIBADANBgkqhkiG9w0BAQEFAASCAmMwggJfAgEAAoGBAPM6p826cXEW0Jk+Wrt87+NbCOqZO8CihUEHjLzsGLNJn12X8XsWkDFhzoyZfZOqK8K+85FeB2Vh0VYCHNc6chS/04Yb//9Y8t71Myz2QjABn8A9Rdq68LTWgUudiTPA+UCHS1DUC71qtMT84bVXV0qB/wFccs+EovgGYYERRkG1AgMBAAECgYEA2PmnPdgnYKnolfvQ9tXiLaBFGPpvGk4grz0r6FB5TF7N4rErwxECunq0xioaowK4HPc40qHd2SvkkWQ7FCjYIDsnMk1oOhxNKn0J3FG0n5Cg1/dFai4eoXHs/nKn3SVZ8YZC1T2cMtN2srectLqNqhB8aQEe8xmykyUlUpg/qmECQQD9vkwjUotG5oUUrOj6etcB4WcdyyH0FtThKgyoJUDwgBv6lGGzWyFJEREvp47IgV+FgC7zeP2mL4MhgnD3tNCZAkEA9WRrjOLBNc379XZpoDsH7rZjobVvhnTrEuRDx/whqZ+vk64EPrEW81XYh647bAbJlFn2jPhY+IUHkrxFEFT/fQJBAMoLNOULXQtfkqgb5odMONeue0Ul8itB4tBHgzyALW1TFPQ6InGGJsLfbCfd67uMCFts7fXAaXhibK/KBdm3iEECQQChwVAjzlUN4nnzk9qMhFz2PcPvFGovd2J9UXpcmRaXeWuDLXIe4Rz/ydaxmWgSDWdTIvoicpIzP31+fBwKZ/0BAkEAy0bh4weKmYF29//rK0sxmY8RtqkQeFrwWbqx1daa1w0DfWlNSvy47zyW1G5/AdZU6JSpXxlxdlM/HSDw+v7kcA==";

        private void button1_Click(object sender, EventArgs e)
        {
            /**RSA加密测试,RSA中的密钥对通过SSL工具生成，生成命令如下： 
            * 1 生成RSA私钥： 
            * openssl genrsa -out rsa_private_key.pem 1024 
            *2 生成RSA公钥 
            * openssl rsa -in rsa_private_key.pem -pubout -out rsa_public_key.pem 
            * 
            * 3 将RSA私钥转换成PKCS8格式 
            * openssl pkcs8 -topk8 -inform PEM -in rsa_private_key.pem -outform PEM -nocrypt -out rsa_pub_pk8.pem 
            * 
            * 直接打开rsa_private_key.pem和rsa_pub_pk8.pem文件就可以获取密钥对内容，获取密钥对内容组成字符串时，注意将换行符删除 
            * */


            try
            {
                //加密字符串  
                string data = textBox1.Text;

                Console.WriteLine("加密前字符串内容：" + data);
                //加密  
                string encrypteddata = RSAFromPkcs8.encryptData(data, publickey, "UTF-8");
                textBox2.Text = encrypteddata;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            //解密  
            string endata = textBox1.Text;// "LpnnvnfA72VnyjboX/OsCPO6FOFXeEnnsKkI7aAEQyVAPfCTfQ43ZYVZVqnADDPMW7VhBXJWyQMAGw2Fh9sS/XLHmO5XW94Yehci6JrJMynePgtIiDysjNA+UlgSTC/MlResNrBm/4MMSPvq0qLwScgpZDynhLsVZk+EQ6G8wgA=";
            string datamw = RSAFromPkcs8.decryptData(endata, privatekey, "UTF-8");
            textBox2.Text = datamw;
            //Console.WriteLine("静态加密后的字符串为：" + endata);
            //Console.WriteLine("解密后的字符串内容：" + datamw);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //签名  
            string signdata = textBox1.Text;//  "YB010000001441234567286038508081299";
            //Console.WriteLine("签名前的字符串内容：" + signdata);
            string sign = RSAFromPkcs8.sign(signdata, privatekey, "UTF-8");
            textBox2.Text = sign;
            //Console.WriteLine("签名后的字符串：" + sign);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string a="service=\"mobile.securitypay.pay\"&partner=\"2088511128054061\"&_input_charset=\"utf-8\"&notify_url=\"http://www.dflink.com.cn/notify.aspx\"&out_trade_no=\"HQ1510200011\"&subject=\"金立超强待机王\"&payment_type=\"1\"&seller_id=\"hong7tv@163.com\"&total_fee=\"0.01\"&it_b_pay=\"30m\"&body=\"金立超强待机王\"&return_url=\"m.alipay.com\"&sign=\"LicfVSOE6OvR53xvL2MZcfxxVZnKhPnZ1STfAfbjqDb5n1dhXHEkEKpR1MjcmjnJsghGmsI7CiIRQFrLdPTKk%2bbvek8hEris%2f5K3kywFdccLrRjKRv293Ui6PeGwU%2bgMrbLTUTr%2fBQe4nYAnFx4TbKfF%2fFXV161yz8dFPfmxs1E%3d\"&sign_type=\"RSA\"";
            string b = "service=\"mobile.securitypay.pay\"&partner=\"2088511128054061\"&_input_charset=\"utf-8\"&notify_url=\"http://www.dflink.com.cn/notify.aspx\"&out_trade_no=\"HQ1510200011\"&subject=\"金立超强待机王\"&payment_type=\"1\"&seller_id=\"hong7tv@163.com\"&total_fee=\"0.01\"&it_b_pay=\"30m\"&body=\"金立超强待机王\"&return_url=\"m.alipay.com\"&sign=\"LicfVSOE6OvR53xvL2MZcfxxVZnKhPnZ1STfAfbjqDb5n1dhXHEkEKpR1MjcmjnJsghGmsI7CiIRQFrLdPTKk%2bbvek8hEris%2f5K3kywFdccLrRjKRv293Ui6PeGwU%2bgMrbLTUTr%2fBQe4nYAnFx4TbKfF%2fFXV161yz8dFPfmxs1E%3d\"&sign_type=\"RSA\"";
            bool s = a == b;
            MessageBox.Show(s.ToString());
            textBox2.Text = textBox1.Text.EncryptDEC();// Encrypt(textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text.DecryptDEC();// DesDecrypt(textBox1.Text);
        }


        public static string sKey = "12345678";
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="pToDecrypt">要解密的以Base64</param>
        /// <param name="sKey">密钥，且必须为8位</param>
        /// <returns>已解密的字符串</returns>
        public static string DesDecrypt(string pToDecrypt)
        {
            //转义特殊字符
            pToDecrypt = pToDecrypt.Replace("-", "+");
            pToDecrypt = pToDecrypt.Replace("_", "/");
            pToDecrypt = pToDecrypt.Replace("~", "=");
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }

              /// <summary>
        /// 对字符串进行DES加密
        /// </summary>
        /// <param name="sourceString">待加密的字符串</param>
        /// <returns>加密后的BASE64编码的字符串</returns>
        public string Encrypt(string sourceString)
      {
         byte[] btKey = Encoding.UTF8.GetBytes(sKey);
         byte[] btIV = Encoding.UTF8.GetBytes(sKey);
          DESCryptoServiceProvider des = new DESCryptoServiceProvider();
          using (MemoryStream ms = new MemoryStream())
          {
              byte[] inData = Encoding.UTF8.GetBytes(sourceString);
              try
              {
                  using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write))
                  {
                      cs.Write(inData, 0, inData.Length);
                      cs.FlushFinalBlock();
                  }
 
                  return Convert.ToBase64String(ms.ToArray());
              }
              catch
              {
                  throw;
              }
          }
      }
        
       

    }
}
