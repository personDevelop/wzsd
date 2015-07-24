using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace EasyCms
{
    public static class CmsSession
    {
        public const string UserID = "UserID";
        public const string UserInfo = "UserInfo";
        public const string RoleID = "RoleID";
        public const string RoleInfo = "RoleInfo";
        public const string test = "s";

        public static string GetUserID(this HttpSessionStateBase session)
        {
            string userid = session[UserID] as string;
            return userid ?? "root";
        }
        public static string GetRoleID(this HttpSessionStateBase session)
        {
            return session[RoleID] as string;
        }
        public static string MapPathCms(this HttpServerUtility server, string path)
        {
            if (!path.StartsWith("/") && !path.StartsWith("~"))
            {
                path = "/" + path;
            }
            if (!path.StartsWith("~"))
            {
                path = "~" + path;
            }
            return server.MapPath(path);
        }


        public static string GetAccountID(this HttpRequestMessage Request)
        {
            string token = Request.GetToken();
            if (string.IsNullOrWhiteSpace(token))
            {
                return string.Empty;
            }
            else
            {
                ManagerUserInfo user = LoginModel.GetCachUserInfo(token);
                if (user != null)
                {
                    return user.ID;
                }

            }
            return string.Empty;


        }
        public static string GetToken(this HttpRequestMessage Request)
        {
            string result = null;
            ClientEnum clientType = ClientEnum.PC;
            var cookie = Request.Headers.GetCookies("t").FirstOrDefault();
            if (cookie != null)
            {
                result = cookie["t"].Value;
                clientType = ClientEnum.Android;

            }
            else
            {
                result = (Request.Headers.GetValues("t")).FirstOrDefault();
                if (string.IsNullOrWhiteSpace(result))
                {
                    result = null;
                }
                else
                {
                    clientType = ClientEnum.IOS;
                }
            }
            if (!string.IsNullOrWhiteSpace(result))
            {
                ManagerUserInfo user = LoginModel.GetCachUserInfo(result);
                if (user != null)
                {
                    user.ClientType = (int)clientType;

                }
            }
            return result;
        }

    }
}