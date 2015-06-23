using System;
using System.Collections.Generic;
using System.Linq;
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
            return userid??"root";
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
    }
}