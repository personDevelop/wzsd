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
        public const string UserIDKey = "UserID";
        public const string UserNameKey = "UserName";
        public const string UserInfoKey = "UserInfo";
        public const string RoleIDKey = "RoleID";
        public const string RoleNameKey = "RoleName";
        public const string RoleInfoKey = "RoleInfo";

        public static dynamic GetUser()
        {

            if (Session == null)
            {
                return null;
            }
            return Session[UserInfoKey];
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
            string userid = Session[UserIDKey] as string;
            return userid;
        }
        public static string GetUserName()
        {
            if (Session == null)
            {
                return null;
            }
            string userid = Session[UserNameKey] as string;
            return userid;

        }
        public static string GetRoleID()
        {
            if (Session == null)
            {
                return null;
            }
            return Session[RoleIDKey] as string;
        }

        public static string GetRoleName()
        {
            if (Session == null)
            {
                return null;
            }
            return Session[RoleNameKey] as string ;
        }



        public static void AddUser(dynamic user, dynamic role)
        {
            if (Session == null)
            {
                return  ;
            }
            Session[UserInfoKey] = user;
            Session[RoleInfoKey] = role;
            Session[UserIDKey] = user.ID;
            Session[RoleIDKey] = role.ID; 
            Session[UserNameKey] = user.Name;
            Session[RoleNameKey] = role.Name;
            
        }
    }
}
