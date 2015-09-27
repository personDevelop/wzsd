using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Model.ViewModel;
using EasyCms.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace EasyCms.Web.API
{
    public class UserApiController : BaseAPIControl
    {
        [HttpPost]
        public HttpResponseMessage GetValiCode([FromBody] ValiCodeModel valiCodeModel)
        {
            try
            {
                var resp = new HttpResponseMessage(HttpStatusCode.OK);
                bool isSuccess = true;
                string code = "2222";//生成验证码StaticValue.GeneratoRandom();
                Sharp.Common.CacheContainer.AddCache(valiCodeModel.TelNo, code, 60 * 2);//有效期2分钟
                //通过手机发送出去
                string msgInfo = string.Format("您注册【我在山东】的验证码为{0}，请于{1}分钟内正确输入验证码", code, 2);
                //SendMsg(valiCodeModel.TelNo, msgInfo);
                return "获取成功".FormatSuccess();

            }
            catch (Exception ex)
            {
                return ex.Format();

            }
        }
        // GET api/userapi/5
        public HttpResponseMessage Login([FromBody]LoginModel loginModel)
        {
            try
            {
                string msg = string.Empty;
                bool isSuccess = false;
                string token = string.Empty;
                if (string.IsNullOrWhiteSpace(loginModel.Account))
                {
                    msg = "登录账号不能为空";
                }
                else if (string.IsNullOrWhiteSpace(loginModel.Pwd))
                {
                    msg = "登录密码不能为空";
                }
                else
                {
                    ManagerUserInfo user = new ManagerUserInfoBll().Login(loginModel.Account, loginModel.Pwd, out msg);

                    isSuccess = user != null;
                    if (isSuccess)
                    {

                        token = loginModel.GenerateToken();
                        LoginModel.AddToken(token, loginModel.Account, loginModel.DeviceID, user);
                    }
                }
                if (isSuccess)
                {
                    return token.FormatSuccess();
                }
                else
                {
                    return msg.FormatError();
                }

            }
            catch (Exception ex)
            {
                return ex.Format();

            }
        }

        // POST api/userapi
        [HttpPost]
        public HttpResponseMessage Regist([FromBody]RegistModel registModel)
        {
            //检验验证码是否正确，
            try
            {
                string msg = string.Empty;
                if (string.IsNullOrWhiteSpace(registModel.Pwd))
                {
                    msg = "密码不能为空";
                }
                else
                    if (string.IsNullOrWhiteSpace(registModel.ComfirmPwd))
                    {
                        msg = "确认密码不能为空";
                    }
                    else
                        if (!registModel.Pwd.Equals(registModel.ComfirmPwd))
                        {
                            msg = "确认密码和密码不相同";
                        }
                        else
                            if (string.IsNullOrWhiteSpace(registModel.TelPhone))
                            {
                                msg = "手机号不能为空";
                            }
                            else
                                if (string.IsNullOrWhiteSpace(registModel.TelVaiCode))
                                {
                                    msg = "手机验证码不能为空";
                                }
                                else
                                    if (!Sharp.Common.CacheContainer.Contains(registModel.TelPhone))
                                    {
                                        msg = "请先获取手机验证码";
                                    }
                                    else
                                        if (!Sharp.Common.CacheContainer.GetCache(registModel.TelPhone).Equals(registModel.TelVaiCode))
                                        {
                                            msg = "验证码不正确";
                                        }
                                        else
                                        {
                                            if (string.IsNullOrWhiteSpace(registModel.NiceName))
                                            {
                                                registModel.NiceName = registModel.TelPhone;
                                            }
                                            msg = new ManagerUserInfoBll().Regist(registModel);
                                        }


                return msg.FormatError();
            }
            catch (Exception ex)
            {
                return ex.Format();

            }

        }


        public HttpResponseMessage GetMySelf()
        {
            string userid = Request.GetAccountID();
            string err;
            AccountModel user = new ManagerUserInfoBll().GetMySelf(userid, host, out   err);
            if (!string.IsNullOrWhiteSpace(err))
            {
                return err.FormatError();

            }
            else
            {
                return user.FormatObj();
            }
        }

        public HttpResponseMessage ChangePwd([FromBody]ChangePwdModel changePwd)
        {//检验验证码是否正确，
            string msg = string.Empty;
            if (string.IsNullOrWhiteSpace(changePwd.ValidCode))
            {
                msg = "手机验证码不能为空";
            }
            else
            {

                string tel = Request.GetAccount().ContactPhone;
                if (string.IsNullOrWhiteSpace(tel))
                {
                    msg = "您还没有维护您的手机号码";
                }
                else
                {
                    if (!Sharp.Common.CacheContainer.Contains(tel))
                    {
                        msg = "请先获取手机验证码";
                    }
                    else
                        if (!Sharp.Common.CacheContainer.GetCache(tel).Equals(changePwd.ValidCode))
                        {
                            msg = "验证码不正确";
                        }
                        else
                        {
                            msg = new ManagerUserInfoBll().ChangePwd(Request.GetAccountID(), changePwd);
                        }

                }

            }
            if (string.IsNullOrWhiteSpace(msg))
            {
                //清空token
                LoginModel.RemoveToken(Request.GetToken(), Request.GetAccount());

                return "修改成功，请重新用新密码登录".FormatSuccess();
            }
            else
            {

                return msg.FormatError();
            }


        }
    }
}
