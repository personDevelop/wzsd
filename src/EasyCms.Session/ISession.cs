using EasyCms.Model;
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

        public static dynamic GetUser()
        {

            if (Session == null)
            {
                return null;
            }
            return Session[UserInfo];
        }

        public dynamic GeValue(string key)
        {
            if (Session == null)
            {
                return null;
            }

            return Session[key];
        }

        public static System.Web.SessionState.HttpSessionState Session { get; set; }

        public static string GetUserID()
        {
            if (Session == null)
            {
                return null;
            }
            string userid = Session[UserID] as string;
            return userid;
        }
        public static string GetUserName()
        {
            if (Session == null)
            {
                return null;
            }
            string userid = Session[UserName] as string;
            return userid;

        }
        public static string GetRoleID()
        {
            if (Session == null)
            {
                return null;
            }
            return Session[RoleID] as string;
        }




        public static void AddUser(dynamic user, dynamic role)
        {
            if (Session == null)
            {
                return  ;
            }
            Session[UserInfo] = user;
            Session[RoleInfo] = role;
            Session[UserID] = user.ID;
            Session[RoleID] = role.ID;
            Session[UserName] = user.Name;
        }
    }
}
