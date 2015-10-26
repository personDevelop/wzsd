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
using System.Web;
using System.Web.Http;

namespace EasyCms.Web.API
{
    public class UserApiController : BaseAPIControl
    {
        [HttpPost]
        public HttpResponseMessage GetValiCode([FromBody] ValiCodeModel valiCodeModel)
        {

            return GetValucodeMethod(valiCodeModel);


        }

        private HttpResponseMessage GetValucodeMethod(ValiCodeModel valiCodeModel)
        {
            if (valiCodeModel.TypeInfo == ValidCode.无)
            {
                "请选择验证码的用途".FormatError();
            }

            string code = "2222";//生成验证码StaticValue.GeneratoRandom();
            Sharp.Common.CacheContainer.AddCache(valiCodeModel.TelNo + valiCodeModel.TypeInfo, code, 60 * 2);//有效期2分钟
            //通过手机发送出去
            string msgInfo = string.Format("您注册【我在山东】的验证码为{0}，请于{1}分钟内正确输入验证码", code, 2);
            string successMsg = "";
            switch (valiCodeModel.SendType)
            {
                case ValidType.手机短信:
                    //SendMsg(valiCodeModel.TelNo, msgInfo);
                    string nomsg = string.Empty;
                    if (StaticValue.GetEncriptContanct(valiCodeModel.TelNo, valiCodeModel.SendType, out nomsg))
                    {
                        successMsg = "验证码已发送到您的手机" + nomsg + "上,请查收";
                    }
                    else
                    {
                        successMsg = "已发送到您的手机上,请查收";
                    }
                    break;
                case ValidType.邮箱:
                    break;
                case ValidType.手机和邮箱:
                    //SendMsg(valiCodeModel.TelNo, msgInfo);
                    if (StaticValue.GetEncriptContanct(valiCodeModel.TelNo, valiCodeModel.SendType, out nomsg))
                    {
                        successMsg = "验证码已发送到您的Email" + nomsg + "上,请查收";
                    }
                    else
                    {
                        successMsg = "已发送到您的Email上,请查收";
                    }
                    break;
                default:
                    "不支持当前的验证方式".FormatError();
                    break;
            }

            return successMsg.FormatSuccess();
        }
        /// <summary>
        /// 此方法 客户端只传递用户账号，根据账号查找电话
        /// </summary>
        /// <param name="valiCodeModel"></param>
        /// <returns></returns> 
        [HttpPost]
        public HttpResponseMessage GetForgetValiCode([FromBody] ValiCodeModel valiCodeModel)
        {
            if (string.IsNullOrWhiteSpace(valiCodeModel.TelNo))
            {
                return "请输入您的账号".FormatError();
            }
            else
            {
                ManagerUserInfo user = new ManagerUserInfoBll().GeUserWithCodeOrTelOrEmail(valiCodeModel.TelNo);
                if (user == null)
                {
                    return "不存在该账号，请确认是否正确".FormatError();
                }
                else
                {
                    valiCodeModel.TypeInfo = ValidCode.忘记密码;
                    valiCodeModel.SendType = ValidType.手机短信;
                    //根据账号获取手机号
                    return GetValucodeMethod(valiCodeModel);
                }
            }




        }
        // GET api/userapi/5
        public HttpResponseMessage Login([FromBody]LoginModel loginModel)
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
            else if (string.IsNullOrWhiteSpace(loginModel.DeviceID))
            {
                msg = "当前设备不允许登陆，请联系系统管理员";
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

        // POST api/userapi
        [HttpPost]
        public HttpResponseMessage Regist([FromBody]RegistModel registModel)
        {
            //检验验证码是否正确，

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
                                if (!Sharp.Common.CacheContainer.Contains(registModel.TelPhone + ValidCode.注册))
                                {
                                    msg = "请先获取手机验证码";
                                }
                                else
                                    if (!Sharp.Common.CacheContainer.GetCache(registModel.TelPhone + ValidCode.注册).Equals(registModel.TelVaiCode))
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
                    if (!Sharp.Common.CacheContainer.Contains(tel + ValidCode.修改密码))
                    {
                        msg = "请先获取手机验证码";
                    }
                    else
                        if (!Sharp.Common.CacheContainer.GetCache(tel + ValidCode.修改密码).Equals(changePwd.ValidCode))
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
                LoginModel.RemoveToken(Request.GetToken(false), Request.GetAccount(false));

                return "修改成功，请重新用新密码登录".FormatSuccess();
            }
            else
            {

                return msg.FormatError();
            }


        }

        /// <summary>
        /// 选择忘记密码的验证方式
        /// </summary>
        /// <param name="changePwd"></param>
        /// <returns></returns>

        public HttpResponseMessage ResetPwd([FromBody]ResetPwdModel changePwd)
        {
            string value = string.Empty;
            bool result = new ManagerUserInfoBll().ResetPwd(changePwd, false, out value);
            return value.Format(result);
        }
        public HttpResponseMessage ResetPwdPost([FromBody]ResetPwdPostModel changePwd)
        {
            //检验验证码是否正确，
            string msg = string.Empty;
            if (string.IsNullOrWhiteSpace(changePwd.ValidCode))
            {
                msg = "验证码不能为空";
            }
            else
            {
                string key = "";
                ManagerUserInfo user = new ManagerUserInfoBll().GeUserWithCodeOrTelOrEmail(changePwd.Account);
                if (user == null)
                {
                    msg = "您的账户不存在";
                }
                else
                {
                    switch (changePwd.VaryType)
                    {
                        case ValidType.手机短信:
                            key = user.ContactPhone;
                            break;
                        case ValidType.邮箱:
                            key = user.Email;
                            break;
                        case ValidType.手机和邮箱:
                            msg = "暂时不支持该验证方式";
                            break;
                        default:
                            break;
                    }
                    if (string.IsNullOrWhiteSpace(key))
                    {
                        msg = "您还没有维护您的手机号码或邮箱";
                    }
                    else
                    {
                        key += ValidCode.忘记密码;
                        if (!Sharp.Common.CacheContainer.Contains(key))
                        {
                            msg = "请先获取手机验证码";
                        }
                        else
                            if (!Sharp.Common.CacheContainer.GetCache(key).Equals(changePwd.ValidCode))
                            {
                                msg = "验证码不正确";
                            }
                            else
                            {
                                msg = new ManagerUserInfoBll().ChangePwd(user.ID, changePwd);
                            }

                    }
                }
            }
            if (string.IsNullOrWhiteSpace(msg))
            {
                return "密码重置成功，请重新用新密码登录".FormatSuccess();
            }
            else
            {

                return msg.FormatError();
            }
        }

        [HttpPost]
        public HttpResponseMessage ModifyInfo([FromBody]UserInfo user)
        {
            //检验验证码是否正确，
            string msg = string.Empty;
            bool result = true;
            if (string.IsNullOrWhiteSpace(user.ContactPhone))
            {
                msg = "联系电话不能为空";
                result = false;

            }
            else if (string.IsNullOrWhiteSpace(user.Name))
            {
                msg = "姓名不能为空";
                result = false;
            }
            else
            {
                user.ID = Request.GetAccountID();
                result = new ManagerUserInfoBll().ModifyInfo(user, out msg);
            }
            return msg.Format(result);

        }

    }
}
