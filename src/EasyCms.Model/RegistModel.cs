using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common; 
using System.ComponentModel;

namespace EasyCms.Model
{
    public class RegistModel
    {
        /// <summary>
        /// 手机号  客户端注册要求填写手机号 以方便接收验证码
        /// </summary>
        [DisplayName("手机号")]
        public string TelPhone { get; set; }
        /// <summary>
        /// 网站用户注册需要填写邮箱
        /// </summary>
        [DisplayName("Email")]
        public string Email { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        public string UserNo { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        public string Pwd { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        [DisplayName("确认密码")]
        public string ComfirmPwd { get; set; }


        /// <summary>
        /// 验证码  手机端注册是手机短信验证码  网站注册是图片验证码
        /// </summary>
        [DisplayName("验证码")]
        public string VaryCode { get; set; }

        /// <summary>
        /// 是否同意用户协议
        /// </summary>
        [DisplayName("是否同意用户协议")]
        public bool IsAgree { get; set; }


        public  bool IsPc { get; set; }
    }
    
    public class LoginModel
    {

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")] 
        public string Pwd { get; set; }

        [DisplayName("自动登录")]
        public bool RememberMe { get; set; }
        public bool IsPc { get; set; }

        [DisplayName("验证码")]
        public string VaryCode { get; set; }

        /// <summary>
        /// 登陆时间戳
        /// </summary>
        public string TimeStamp { get; set; }

        /// <summary>
        /// DeviceID
        /// </summary>
        public string DeviceID { get; set; }


        public string GenerateToken()
        {
            this.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string source = this.Account + "|" + this.Pwd + "|" + this.TimeStamp + "|" + this.DeviceID;
            string token = source.EncryptSHA1();
            token = System.Web.HttpUtility.UrlEncode(token, Encoding.UTF8);
            //Class1.list.Add(token);

            return token;

        }

        public static bool ValidToken(string token, string userno, string deviceID)
        {
            return CacheContainer.GetCache(userno + deviceID) as string == token;
        }
        static int cachTime = 60 * 60 * 24 * 7;//缓存一周
        public static void AddToken(string token, string userno, string deviceID, ManagerUserInfo userInfo, out TokenInfo tokenEntity, bool isCreate = true)
        {
            userInfo.DeviceNo = deviceID;
            DateTime now = DateTime.Now;
            if (isCreate)
            {


                tokenEntity = new TokenInfo()
                {
                    ID = token,
                    DeviceID = deviceID,
                    UserID = userInfo.ID, 
                    CreateTime = now,
                    LastTime = now,
                    Duration = cachTime,
                    OutTime = now.AddSeconds(cachTime)
                };
            }
            else
            {
                tokenEntity = null;
            }
            CacheContainer.AddCache(userno + deviceID, token, cachTime);
            CacheContainer.AddCache(token, userInfo, cachTime);

        }


        public static bool RemoveToken(string token, ManagerUserInfo userInfo, out string msg)
        {
            msg = String.Empty;

            CacheContainer.RemoveCache(userInfo.Code + userInfo.DeviceNo);
            CacheContainer.RemoveCache(token);
            return true;

        }
        public static ManagerUserInfo GetCachUserInfo(string token, bool IsResetCach = true)
        {
            ManagerUserInfo o = CacheContainer.GetCache(token) as ManagerUserInfo;
            if (o != null && IsResetCach)
            {
                CacheContainer.AddCache(token, o, cachTime);
                CacheContainer.AddCache(o.ContactPhone + o.DeviceNo, token, cachTime);
            }
            return o;
        }
    }

   
}
