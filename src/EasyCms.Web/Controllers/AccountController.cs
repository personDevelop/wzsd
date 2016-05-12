using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Login(string msg, string returnUrl)
        {
            LoginModel model = new LoginModel() { IsPc = true };
            ViewResult vr = View(model);
            ViewBag.Msg = msg;
            return vr;
        }

        // GET: Login
        public ActionResult LoginBox(string msg, string returnUrl)
        {
            LoginModel model = new LoginModel() { IsPc = true };
            ViewResult vr = View(model);
            ViewBag.Msg = msg;
            return vr;
        }
        // GET: Login
        public ActionResult Dialog
            (string msg, string returnUrl)
        {
            LoginModel model = new LoginModel() { IsPc = true };
            ViewResult vr = View(model);
            ViewBag.Msg = msg;
            return vr;
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (model.VaryCode.ToLower() != Session["ValidateCode"].ToString().ToLower())
            {
                ModelState.AddModelError("", "验证码不正确.");
            }
            if (string.IsNullOrWhiteSpace(model.Account))
            {
                ModelState.AddModelError("UserNo", "请输入登录账号.");
            }

            if (string.IsNullOrWhiteSpace(model.Pwd))
            {
                ModelState.AddModelError("Password", "请输入密码.");
            }

            if (ModelState.IsValid)
            {
                string error;
                ManagerUserInfoBll bll = new ManagerUserInfoBll();
                ManagerUserInfo user = bll.Login(model.Account, model.Pwd, out error);
                if (user != null && string.IsNullOrWhiteSpace(error))
                {
                    //SignInAsync(user, model.RememberMe);
                    AccountRange role = bll.GetAccountRange(user.ID);
                    EasyCms.Session.CmsSession.AddUser(user, role);
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("", "default");

                    }
                }
                else
                {
                    ModelState.AddModelError("", error);
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单

            return View(model);
        }

        public ActionResult LogOut(string returnUrl)
        {


            EasyCms.Session.CmsSession.LogOut();
            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("", "default");

            }

        }

        //private void  SignInAsync(ManagerUserInfo user, bool isPersistent)
        //{
        //    //AuthenticationManager.s(DefaultAuthenticationTypes.ExternalCookie);
        //    //var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        //    //AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        //}

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Regist(RegistModel model, string returnUrl)
        {
            ManagerUserInfoBll bll = new ManagerUserInfoBll();
            if (model.VaryCode.ToLower() != Session["ValidateCode"].ToString().ToLower())
            {
                ModelState.AddModelError("VaryCode", "验证码不正确.");
            }
            if (!model.IsAgree)
            {
                ModelState.AddModelError("IsAgree", "请勾选同意《用户注册协议》.");
            }
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                ModelState.AddModelError("Email", "请输入邮箱.");
            }
            else
            {
                if (!Sharp.Common.CheckValid.IsEmail(model.Email))
                {
                    ModelState.AddModelError("Email", "请输入正确的邮箱格式.");
                }
                else
                    if (!bll.CheckRepeat(model.Email, false))
                    {
                        ModelState.AddModelError("Email", "当前邮箱已被注册.");
                    }
            }
            if (string.IsNullOrWhiteSpace(model.UserNo))
            {
                ModelState.AddModelError("UserNo", "请输入登录账号.");
            }
            else
            {
                if (!bll.CheckRepeat(model.UserNo, true))
                {
                    ModelState.AddModelError("UserNo", "当前登录账号已被注册.");
                }
            }
            if (string.IsNullOrWhiteSpace(model.Pwd))
            {
                ModelState.AddModelError("Password", "请输入密码.");
            }
            if (string.IsNullOrWhiteSpace(model.ComfirmPwd))
            {
                ModelState.AddModelError("ConfrimPwd", "请再次输入密码.");
            }
            if (!string.IsNullOrWhiteSpace(model.Pwd) && model.Pwd != model.ComfirmPwd)
            {

                ModelState.AddModelError("ConfrimPwd", "两次输入密码不一致.");
            }
            if (ModelState.IsValid)
            {
                string error = bll.Regist(model);
                if (string.IsNullOrWhiteSpace(error))
                {

                    return RedirectToAction("Login", new { msg = "1" });
                }
                else
                {
                    ModelState.AddModelError("All", error);
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单

            return View(model);
        }



        public ActionResult Regist(string returnUrl)
        {
            return View(new RegistModel() { IsAgree = true, IsPc = true });
        }

        public string CheckRepeat(string val, bool IsCode)
        {
            string result = new ManagerUserInfoBll().CheckRepeat(val, IsCode).ToString().ToLower();
            return result;

        }
        public ActionResult Contact()
        {

            return View();
        }


    }
}