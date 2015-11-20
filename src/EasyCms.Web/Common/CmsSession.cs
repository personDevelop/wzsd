using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Session;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace EasyCms
{


    public static class CmsSessionExtend
    {


        public static string GetUserID(this HttpSessionStateBase session)
        {
            string userid = session[CmsSession.UserIDKey] as string;
            return userid ?? "root";
        }
        public static string GetUserID(this HttpSessionState session)
        {
            string userid = session[CmsSession.UserIDKey] as string;
            return userid ?? "root";
        }
        public static string GetRoleID(this HttpSessionStateBase session)
        {
            return session[CmsSession.RoleIDKey] as string;
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


        public static string GetAccountID(this HttpRequestMessage Request, bool isRecord = true)
        {

            ManagerUserInfo user = Request.GetAccount(isRecord);
            if (user != null)
            {
                return user.ID;
            }

            return string.Empty;


        }
        /// <summary>
        /// 这个是专门给客户端出现异常时调用的
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        internal static ManagerUserInfo GetAccount(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return null;
            }
            else
            {
                ManagerUserInfo user = LoginModel.GetCachUserInfo(token);
                return user;

            }
        }
        static ManagerUserInfoBll bll = new ManagerUserInfoBll();
        public static ManagerUserInfo GetAccount(this HttpRequestMessage Request, bool isRecord = true)
        {
            string token = Request.GetToken(isRecord);
            if (string.IsNullOrWhiteSpace(token))
            {
                //没有token
                return null;
            }
            else
            {
                ManagerUserInfo user = LoginModel.GetCachUserInfo(token);
                if (user == null)
                {
                    user = bll.GetUserByToken(token);
                    TokenInfo ti;
                    LoginModel.AddToken(token, user.Code, user.DeviceNo, user, out ti, false);
                }
                else
                    //更新数据库Token
                    bll.UpdateToken(token);
                return user;

            }


        }

        public static string GetToken(this HttpRequestMessage Request, bool isRecord = true)
        {
            string result = null;
            ClientEnum clientType = ClientEnum.PC;
            var cookie = Request.Headers.GetCookies("t").FirstOrDefault();
            if (cookie != null)
            {
                result = cookie["t"].Value;
                clientType = ClientEnum.Android;

            }
            else
            {
                try
                {
                    result = (Request.Headers.GetValues("t")).FirstOrDefault();
                    clientType = ClientEnum.IOS;
                }
                catch (Exception ex)
                {
                    if (isRecord)
                    {
                        LogService.LogClientInstance.WriteException(ex);
                    }
                }

            }
            if (!string.IsNullOrWhiteSpace(result))
            {
                ManagerUserInfo user = LoginModel.GetCachUserInfo(result, false);

                if (user != null)
                {
                    user.ClientType = (int)clientType;
                }
                else
                {
                    //这种情况说明result已过期了，或者传递的token不正确
                    // result = null;//先不清空，检测下是否是过期的问题，或者是乱码的问题，导致查不到
                }
            }
            return result;
        }

        public static bool CheckRight(string routeTemplate, string controler, string action, bool isApi, out string error, HttpRequestMessage request = null)
        {

            error = string.Empty;
            string roleid = string.Empty;
            bool result = false;
            FunctionInfo func = FunctionInfoBll.FindFunc(routeTemplate, controler, action, out error);
            if (func != null)
            {
                if (func.IsAnony)
                {
                    return true;
                }
                else
                {

                    if (isApi)
                    {
                        //先获取token,
                        ManagerUserInfo account = request.GetAccount(true);
                        if (account != null)
                        {
                            account.RangeDict = new RangeDictBll().GetAccountRange(account.ID);
                            if (account.RangeDict != null)
                            {
                                roleid = account.RangeDict.ID;
                            }

                        }
                    }
                    if (string.IsNullOrWhiteSpace(roleid))
                    {
                        //再试着看看是否是后台管理员使用
                        roleid = CmsSession.GetRoleID();
                    }
                    //获取当前会员等级
                    if (string.IsNullOrWhiteSpace(roleid))
                    {
                        result = false;
                        error = "您还没有登录,或登录信息过期，请重新登录";
                        if (isApi)
                        {
                            ////加载所有令牌信息
                            //string s = "当前令牌" + request.GetToken() + ",系统内所有令牌";
                            //foreach (var item in Class1.list)
                            //{
                            //    s += item + ";";
                            //}
                            //error += s;
                        }
                    }
                    else
                    {
                        if (func.IsMust)
                        {
                            return true;
                        }
                        else
                        {
                            if (roleid == "root")
                            {
                                return true;
                            }
                            List<FunctionRight> listRight = FunctionInfoBll.GetRightList();
                            if (listRight == null || listRight.Count == 0)
                            {
                                result = false;
                                error = "还没有设置权限";
                            }
                            else
                            {

                                if (listRight.Exists(p => p.RoleID == roleid && p.FunID == func.ID))
                                {
                                    FunctionRight fr = listRight.Find(p => p.RoleID == roleid && p.FunID == func.ID);
                                    if (!fr.IsEnable)
                                    {
                                        error = "您所在角色或等级" + roleid + "没有操作该功能的权限";
                                    }
                                    result = fr.IsEnable;

                                }
                                else
                                {
                                    error = string.Format("没找到对应的功能的授权信息，不能执行该操作【{0}】【{1}】【{2}】【{3}】", roleid, routeTemplate, controler, action);
                                    result = false;
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                if (error.StartsWith("没找到对应的功能") || string.IsNullOrWhiteSpace(error))
                {

                    //这种情况是由于某些接口不需要定义功能，这种情况下也就默认表名是匿名的，所有设置为true
                    result = true;
                }
                else
                    result = false;
            }
            if (!result)
            {
                new LogBll().WriteException(string.Format("角色【{0}】域【{1}】控制器【{2}】方法【{3}】错误信息【{4}】", roleid, routeTemplate, controler, action, error));
            }
            return result;
        }


    }
}