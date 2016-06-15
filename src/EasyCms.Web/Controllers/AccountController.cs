using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Session;
using EmailService;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public ActionResult Login(LoginModel model, string returnUrl, bool isJson = false)
        {
            string jsonerror = string.Empty;
            if (model.VaryCode.ToLower() != Session["ValidateCode"].ToString().ToLower())
            {
                jsonerror = "验证码不正确.";
                ModelState.AddModelError("", "验证码不正确.");
            }
            if (string.IsNullOrWhiteSpace(model.Account))
            {
                ModelState.AddModelError("UserNo", "请输入登录账号.");
                jsonerror += "<br/>请输入登录账号.";
            }

            if (string.IsNullOrWhiteSpace(model.Pwd))
            {
                ModelState.AddModelError("Password", "请输入密码.");
                jsonerror += "<br/>请输入密码.";
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
                    AddCardProduct(Request, user.ID);
                    if (!isJson)
                    {

                        if (!string.IsNullOrWhiteSpace(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("", "default");

                        }
                    }
                }
                else
                {
                    jsonerror += "<br/>" + error;
                    ModelState.AddModelError("", error);
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            if (isJson)
            {
                if (ModelState.IsValid)
                {
                    return Json(new { result = true, Msg = jsonerror });
                }
                else
                {
                    return Json(new { result = false, Msg = jsonerror });

                }
            }
            else
                return View(model);
        }

        

        private void AddCardProduct(HttpRequestBase request, string userid)
        {  //还没有登录，从cookie获取

            List<CookieCard> list = new List<CookieCard>();
            bool isHasCookie = false;
            string cookieValue = string.Empty;
            //先判断cookie里是否已有该商品，如果有则数量加1，
            foreach (string item in request.Cookies.Keys)
            {
                if (item == StaticValue.CardCookieName)
                {
                    isHasCookie = true;
                    cookieValue = Request.Cookies[item].Value;
                    break;
                }
            }
            if (isHasCookie)
            {
                cookieValue = HttpUtility.UrlDecode(cookieValue, Encoding.UTF8);
                list = JsonWithDataTable.Deserialize(cookieValue, typeof(List<CookieCard>)) as List<CookieCard>;
                ShopProductInfoBll bll = new ShopProductInfoBll();
                ShopShoppingCartsBll cartsBll = new ShopShoppingCartsBll();
                List<ShopShoppingCarts> cardList = cartsBll.GetMyDBCards(userid);
                foreach (var item in list)
                {
                    if (cardList.Exists(p => p.ProductId == item.ProductId && item.SKU == p.SKU))
                    {
                        cardList.Find(p => p.ProductId == item.ProductId && item.SKU == p.SKU).Quantity += item.Quantity;
                    }
                    else
                    {
                        ShopShoppingCarts sc = null;
                        switch (item.BuyType)
                        {
                            case ShopBuyType.普通购物:
                            case ShopBuyType.赠品: 

                                //获取商品名称
                                sc = bll.GetDbCardProduct(item.ProductId, item.SKU); 
                                sc.ActivityID = item.ActivityID; 
                                sc.Quantity = item.Quantity; 
                                sc.ID = item.ID;
                                sc.UserId = userid;
                                break;
                            case ShopBuyType.套餐:
                                //暂时未实现套餐功能，可以用新建商品的方式 临时弄成套餐
                                break;
                            case ShopBuyType.团购:
                            case ShopBuyType.秒杀:
                                //这两种不加入购物车，直接购买
                                continue;

                            default:
                                break;
                        }
                        if (sc != null)
                        {
                            cardList.Add(sc);
                        }
                    }

                }
               
                cartsBll.Save(cardList);

            }
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
                string error = bll.Regist(model, ActionPlatform.商城网站);
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


        /// <summary>
        /// 判断用户是否已登录 web版本
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserIsLogin()
        {
            string userid = CmsSession.GetUserID();
            if (string.IsNullOrWhiteSpace(userid))
            {
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = false
                };
            }
            else
            {
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = true
                };
            }
        }
        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult FindPwd()
        {
            return View();

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult FindPwd(FindPwdModel model)
        {
            ManagerUserInfoBll bll = new ManagerUserInfoBll();
            string sessionValidateCode = Session["ValidateCode"] as string;
            if (string.IsNullOrWhiteSpace(sessionValidateCode))
            {
                ModelState.AddModelError("VaryCode", "验证码已失效，请重新获取.");
            }
            if (ModelState.IsValid && model.VaryCode.ToLower() != sessionValidateCode)
            {
                ModelState.AddModelError("VaryCode", "验证码不正确.");
            }

            if (string.IsNullOrWhiteSpace(model.Account))
            {
                ModelState.AddModelError("Account", "请输入用户名或邮箱.");
            }
            else
            {
                string error = null;
                ManagerUserInfo user = bll.GetUserInfo(model.Account, out error);
                if (string.IsNullOrWhiteSpace(error))
                {
                    if (string.IsNullOrWhiteSpace(user.Email))
                    {
                        return View("Error", new MessageModel("对不起，您的账号在注册时没有填写邮箱账号,请联系客服帮您找回密码", error, ShowMsgType.error));
                    }
                    else
                         if (!Sharp.Common.CheckValid.IsEmail(user.Email))
                    {
                        return View("Error", new MessageModel("对不起，您的账号在注册时填写的不是正确的邮箱账号,请联系客服帮您找回密码", error, ShowMsgType.error));
                    }
                    DateTime now = DateTime.Now;
                    string varifyCode = Guid.NewGuid().ToString();
                    string content = GetMsgInfo(now, varifyCode);
                    SendEmail.SendMsg(CmsSessionExtend.WebSite.EmailServer,
                        CmsSessionExtend.WebSite.EmailPort, CmsSessionExtend.WebSite.EmailUser,
                        CmsSessionExtend.WebSite.EmailPwd, user.Email, "红七商城找回密码", content, ref error);

                    EasyCms.Model.FindPwd m = new Model.FindPwd()
                    {
                        ID = varifyCode,
                        EmailOrTel = model.Account,
                        SendTime = now,
                        EndTime = now.AddMinutes(30),
                        UserID = user.ID,
                        Target = SendMsgType.找回密码,
                        VariyCode = varifyCode,
                        VaryType = ValidType.邮箱
                    };
                    bll.Save(m);
                    string email = user.Email.EncriptEmail();

                    return View("Error", new MessageModel("提交申请成功", "您的申请已成功受理，重置信息已发送到您注册时的邮箱【" + email + "】中，请在30分钟内到邮箱激活重置密码", ShowMsgType.success));
                }
                else
                {
                    return View("Error", new MessageModel("提交申请失败", error, ShowMsgType.error));

                }

            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单

            return View(model);
        }
        private string GetMsgInfo(DateTime now, string varifyCode)
        {

            string url = CmsSessionExtend.WebSite.WebSiteUrlWithHttp + "/account/ResetPwd/" + varifyCode;
            string content = @"<p style='text-align: left; text-indent: 0em;'>
    <span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; font-size: 14px;'>尊敬的<span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; line-height: 16px;'>红七</span>商城会员,您好：&nbsp;<br/>&nbsp; &nbsp; &nbsp;<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;您于(<span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; line-height: 16px;'>" + now.ToString("yyyy-MM-dd HH:mm:ss") + @"</span>)通过</span><a href='" + CmsSessionExtend.WebSite.WebSiteUrlWithHttp + @"' target='_self' style='text-decoration: underline; font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; font-size: 14px;'><span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; font-size: 14px;'>红七商城</span></a><span style='font-size: 14px;'><span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; font-size: 20px;'>，<span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; font-size: 14px;'>找回密码。<span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; line-height: 16px;'>&nbsp;本链接<span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; line-height: 16px; color: rgb(247, 150, 70);'><strong>30</strong>分钟</span>内有效</span></span><span style='font-size: 20px; font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; line-height: 16px;'>。</span><br/><span style='font-size: 20px; font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; line-height: 1em;'> &nbsp; &nbsp;<span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; line-height: 1em; font-size: 14px;'>&nbsp;请点击一下</span></span></span><span style='line-height: 1em; font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; font-size: 16px;'><a href='" + url + @"' target='_self'>重置密码</a><span style='line-height: 1em; font-family: 微软雅黑, &#39;Microsoft YaHei&#39;;'>链接，重置您的密码！</span></span></span><br/>
</p>
<p style='text-align: left; text-indent: 0em;'>
    <span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; font-size: 14px;'>&nbsp; &nbsp; &nbsp; &nbsp; 如果您的浏览器打不开此链接，请复制下面的网址到浏览器中打开</span>
</p>
<p style='text-align: left; text-indent: 0em;'>
    <span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; font-size: 14px;'>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span><a href='" + url + @"' target='_self' title='" + url + @"' style='line-height: 16px; white-space: normal; text-decoration: underline; font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; font-size: 14px;'><span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; font-size: 14px;'>&nbsp;" + url + @"</span></a>
</p>
<p style='text-align: left; text-indent: 0em;'>
    <span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; font-size: 14px;'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</span>
</p>
<p style='text-align: left; text-indent: 0em;'>
    <span style='font-family: 微软雅黑, &#39;Microsoft YaHei&#39;; font-size: 14px;'>&nbsp; &nbsp; &nbsp; 本邮件是由系统发送，不需要回复&nbsp;</span>
</p>
<p>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
</p>
<p>
    <span style='line-height: 16px;'>---------------------</span>--------------------------------------------------- &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
</p>
<p>
    <span style='font-size: 14px;'>红七商城</span>
</p>
<p>
    <a href='" + CmsSessionExtend.WebSite.WebSiteUrlWithHttp + @"' target='_self' title='" + CmsSessionExtend.WebSite.WebSiteUrlWithHttp + @"' style='font-size: 14px; text-decoration: underline;'><span style='font-size: 14px;'>" + CmsSessionExtend.WebSite.WebSiteUrlWithHttp + @"</span></a><br/>
</p>
<p>
    <span style='font-size: 14px;'>" + now.ToString("yyyy-MM-dd HH:mm:ss") + @"</span>
</p>
<p>
    <br/>
</p>";

            return content;
        }




        [AllowAnonymous]
        public ActionResult ResetPwd(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return View("Error", new MessageModel("重置密码失败", "您好，您的重置密码链接已失效,请重新申请找回密码", ShowMsgType.error));
            }
            ManagerUserInfoBll bll = new ManagerUserInfoBll();

            EasyCms.Model.FindPwd fp = bll.GetFindPwdRecord(id);
            if (fp == null)
            {
                return View("Error", new MessageModel("重置密码失败", "您好，您的重置密码链接已失效,请重新申请找回密码。", ShowMsgType.error));
            }
            else
            {
                if (DateTime.Now > fp.EndTime)
                {
                    return View("Error", new MessageModel("重置密码失败", "您好，您的重置密码链接已失效,请重新申请找回密码,并在30分钟内重置密码。", ShowMsgType.error));
                }
                else
                {
                    return View(new ResetPwdModelPC() { FindPwdID = id });
                }
            }

        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPwd(ResetPwdModelPC model)
        {
            ManagerUserInfoBll bll = new ManagerUserInfoBll();
            if (model.VaryCode.ToLower() != Session["ValidateCode"].ToString().ToLower())
            {
                ModelState.AddModelError("VaryCode", "验证码不正确.");
            }

            if (string.IsNullOrWhiteSpace(model.Account))
            {
                ModelState.AddModelError("Account", "请输入用户名");
            }
            if (string.IsNullOrWhiteSpace(model.Pwd))
            {
                ModelState.AddModelError("Password", "请输入密码.");
            }
            if (string.IsNullOrWhiteSpace(model.ComfirmPwd))
            {
                ModelState.AddModelError("ConfrimPwd", "请再次输入密码.");
            }
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(model.Pwd) && model.Pwd != model.ComfirmPwd)
            {
                ModelState.AddModelError("ConfrimPwd", "两次输入密码不一致.");
            }
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.FindPwdID))
                {
                    return View("Error", new MessageModel("重置密码失败", "您好，您的重置密码链接已失效,请重新申请找回密码", ShowMsgType.error));

                }
                else
                {
                    EasyCms.Model.FindPwd fp = bll.GetFindPwdRecord(model.FindPwdID);
                    if (fp == null)
                    {
                        return View("Error", new MessageModel("重置密码失败", "您好，您的重置密码链接已失效,请重新申请找回密码。", ShowMsgType.error));
                    }
                    else if (fp.Code.ToLower() != model.Account.ToLower())
                    {
                        ModelState.AddModelError("Account", "用户名不正确");
                    }
                    else
                    {
                        if (DateTime.Now > fp.EndTime)
                        {
                            return View("Error", new MessageModel("重置密码失败", "您好，您的重置密码链接已失效,请重新申请找回密码,并在30分钟内重置密码。", ShowMsgType.error));
                        }
                        else
                        {

                            ManagerUserInfo user = new ManagerUserInfo()
                            {
                                ID = fp.UserID,
                                RecordStatus = Sharp.Common.StatusType.update,
                                Pwd = model.Pwd.EncryptSHA1()
                            };
                            bll.Save(user);

                            return View("Error", new MessageModel("密码重置成功", "您的密码已重置成功,请用新密码登录商城", ShowMsgType.success));

                        }
                    }

                }

            }
            return View(model);

        }


        public ActionResult MyOrder()
        {
            string userid = CmsSession.GetUserID();
            if (string.IsNullOrWhiteSpace(userid))
            {
                return View("Login");
            }
            else
            {
                return View();
            }
        }
    }
}