using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EasyCms.Session
{
    public class CmsSession
    {
        public const string UserID = "UserID";
        public const string UserName = "UserName";
        public const string UserInfo = "UserInfo";
        public const string RoleID = "RoleID";
        public const string RoleInfo = "RoleInfo";

        public dynamic GetUser()
        {

            return Session[UserInfo];
        }

        public dynamic GeValue(string key)
        {

            return Session[key];
        }

        public static System.Web.SessionState.HttpSessionState Session { get; set; }

        public static string GetUserID()
        {
            string userid = Session[UserID] as string;
            return userid;
        }
        public static string GetUserName()
        {
            string userid = Session[UserName] as string;
            return userid;

        }
        public static string GetRoleID()
        {
            return Session[RoleID] as string;
        }


    }
}
