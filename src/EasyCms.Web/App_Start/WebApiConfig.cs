using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Routing;
using System.Web.Script.Serialization;
using EasyCms.Web.Common;
using Sharp.Common;
using EasyCms.Model;
using System.Web.Http.Controllers;
using EasyCms.Business;
using System.Web;
using System.Web.Http.WebHost;
using EasyCms;
using EasyCms.Session;
namespace EasyCms.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           config.Filters.Add(new ExceptionFilter());
            config.Filters.Add(new FilterApiAuthorAttribute());
            config.Filters.Add(new ActionFilter());
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
              name: "ApiWithAction",
              routeTemplate: "api/{controller}/{action}/{id}/{pageIndex}/{other}",
            defaults: new { id = RouteParameter.Optional, pageIndex = RouteParameter.Optional, other = RouteParameter.Optional });

        }

        public static HttpResponseMessage ToJson(this ApiController control, Object obj)
        {
            String str;
            if (obj is String || obj is Char)
            {
                str = obj.ToString();
            }
            else
            {
                var serializer = new JavaScriptSerializer();
                str = serializer.Serialize(obj);
            }
            var result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

    }

    public class ActionFilter : ActionFilterAttribute
    {
        // 摘要: 
        //     在调用操作方法之后发生。
        //
        // 参数: 
        //   actionExecutedContext:
        //     操作执行的上下文。
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

        }
        //
        // 摘要: 
        //     在调用操作方法之前发生。
        //
        // 参数: 
        //   actionContext:
        //     操作上下文。
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (new ParameterInfoBll().GetValue(StaticValue.IsRecordOper) == "1")
            {
                string area = ((actionContext.ControllerContext.RouteData).Route).RouteTemplate;// 获取域 （api/{controller}/{action}/{id}/{pageIndex}/{other}）
                area = area.Substring(0, area.IndexOf('/'));
                string controler = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
                string action = actionContext.ActionDescriptor.ActionName;
                string userid = CmsSession.GetUserID();
                string error = string.Empty;
                FunctionInfoBll.WriteLog(userid, area, controler, action);
            }

            base.OnActionExecuting(actionContext);
        }
    }
    /// <summary>
    /// 权限判断 
    /// 执行顺序1.OnAuthorization 2.IsAuthorized，3.HandleUnauthorizedRequest
    /// </summary>
    /// </summary>
    public class FilterApiAuthorAttribute : AuthorizeAttribute
    {
        // 摘要: 
        //     处理授权失败的请求。
        //
        // 参数: 
        //   actionContext:
        //     上下文。
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {

            //actionContext.Response = "当前用户角色或等级不允许执行该接口".FormatError();

        }
        //
        // 摘要: 
        //     指示指定的控件是否已获得授权。
        //
        // 参数: 
        //   actionContext:
        //     上下文。
        //
        // 返回结果: 
        //     如果控件已获得授权，则为 true；否则为 false。
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string routeTemplate = ((actionContext.ControllerContext.RouteData).Route).RouteTemplate;// 获取域 （api/{controller}/{action}/{id}/{pageIndex}/{other}）
            routeTemplate = routeTemplate.Substring(0, routeTemplate.IndexOf('/'));
            string controler = actionContext.ControllerContext.ControllerDescriptor.ControllerName;// 获取控制器
            string action = actionContext.ActionDescriptor.ActionName;//  获取action


            string error = string.Empty;
            bool result = CmsSessionExtend.CheckRight(routeTemplate, controler, action, true, out error, actionContext.Request);
            if (!result)
            {
                actionContext.Response = error.FormatError(); ;
            }
            return result;


        }
        //
        // 摘要: 
        //     为操作授权时调用。
        //
        // 参数: 
        //   actionContext:
        //     上下文。
        //
        // 异常: 
        //   System.ArgumentNullException:
        //     上下文参数为 null。
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
        }
    }
    /// <summary>
    /// 拦截api的异常
    /// </summary>
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            string routeTemplate = ((actionExecutedContext.ActionContext.ControllerContext.RouteData).Route).RouteTemplate;// 获取域 （api/{controller}/{action}/{id}/{pageIndex}/{other}）
            routeTemplate = routeTemplate.Substring(0, routeTemplate.IndexOf('/'));
            string controler = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;// 获取控制器
            string action = actionExecutedContext.ActionContext.ActionDescriptor.ActionName; ;//  获取action
            string userid = string.Empty;
            ManagerUserInfo account = actionExecutedContext.Request.GetAccount(false);
            if (account == null)
            {
                //再试着看看是否是后台管理员使用
                userid = CmsSession.GetUserID();
            }
            else
            {
                userid = account.ID;

            }
            string err;
            FunctionInfo f = FunctionInfoBll.FindFunc(routeTemplate, controler, action, out err);
            string context = "";
            string funcID = string.Empty;
            if (f != null)
            {
                funcID = f.ID;

            }
            else
            {
                context = actionExecutedContext.Request.RequestUri.ToString();
            }
            SharpLogService.LogClientInstance.WriteException(actionExecutedContext.Exception, userid, funcID, context);
            actionExecutedContext.Response = actionExecutedContext.Exception.Format();
        }

    }

}
