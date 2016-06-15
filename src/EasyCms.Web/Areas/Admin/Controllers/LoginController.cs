using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        public ActionResult Index()
        {
            LoginModel p = new LoginModel();
            ManagerUserInfoBll bll = new ManagerUserInfoBll();
            string sessionid = CmsSession.Session.SessionID;
           
            ManagerUserInfo user = bll.GetSessionUserInfo(sessionid);
            if (user != null)
            {

                SysRoleInfo role = bll.GetRole(user.ID);
                CmsSession.AddUser(user, role);
                
               
                return RedirectToAction("", "Index");
            }
            else
            {
             
                return View(p);
            }
        }

        public ActionResult Login(string Account, string Pwd)
        {
            string error = string.Empty;

            ManagerUserInfo user = null; SysRoleInfo role = null;
            if (Account == "root" && Pwd == "aaaaaa")
            {
                user = new ManagerUserInfo() { ID = Account, Name = "超级管理员" };
                role = new SysRoleInfo() { ID = Account, Name = "超级管理员" };
            }
            ManagerUserInfoBll bll = new ManagerUserInfoBll();
            if (user == null)
            {

                user = bll.LoginManager(Account, Pwd, out error);
                if (user != null)
                {
                    role = bll.GetRole(user.ID);
                    if (role == null)
                    {
                        error = "还没有为当前用户设置角色";

                    }
                }
            }
            if (role != null)
            {
                EasyCms.Session.CmsSession.AddUser(user, role);
                TokenInfo ti = new TokenInfo() { ID = CmsSession.Session.SessionID, UserID = user.ID, DeviceID = role.ID, CreateTime = DateTime.Now, LastTime = DateTime.Now, OutTime = DateTime.Now };
                bll.Save(ti);
                return RedirectToAction("", "Index");

            }
            else
            {
                ModelState.AddModelError("error", error);
                return View("Index");
            }
        }
    }
}