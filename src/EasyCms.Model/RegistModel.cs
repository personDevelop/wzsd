using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common;

namespace EasyCms.Model
{
    public class RegistModel
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NiceName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string TelPhone { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        public string ComfirmPwd { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string TelVaiCode { get; set; }
    }

    public class LoginModel
    {

        /// <summary>
        /// 手机号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

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
            return token;

        }

        public static bool ValidToken(string token, string userno, string deviceID)
        {
            return CacheContainer.GetCache(userno + deviceID) as string == token;
        }

        public static void AddToken(string token, string userno, string deviceID, ManagerUserInfo userInfo)
        {
            int cachTime = 60 * 60 * 24 * 7;//缓存一周
            CacheContainer.AddCache(userno + deviceID, token, cachTime);
            CacheContainer.AddCache(token, userInfo, cachTime);

        }

        public static ManagerUserInfo GetCachUserInfo(string token)
        {
            return CacheContainer.GetCache(token) as ManagerUserInfo;
        }
    }
}
