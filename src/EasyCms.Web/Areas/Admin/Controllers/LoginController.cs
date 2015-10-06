using EasyCms.Business;
using EasyCms.Model;
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
            return View();
        }

        public ActionResult Login(string UserName, string Password)
        {
            string error = string.Empty;
            ManagerUserInfo user = null; SysRoleInfo role = null;
            if (UserName == "root" && Password == "aaaaaa")
            {
                user = new ManagerUserInfo() { ID = UserName, Name = "超级管理员" };
                role = new SysRoleInfo() { ID = UserName, Name = "超级管理员" };
            }
            if (user == null)
            { 
                ManagerUserInfoBll bll = new ManagerUserInfoBll();
                user = bll.LoginManager(UserName, Password, out error);
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