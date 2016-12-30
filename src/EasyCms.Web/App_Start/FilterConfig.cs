using System.Web;
using System.Web.Mvc;
using EasyCms.Web.Common;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Sharp.Common;
using EasyCms.Session;
using EasyCms.Business;
using EasyCms.Model;
using System;

namespace EasyCms.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            filters.Add(new HandlerException());
            filters.Add(new FilterAuthorAttribute());
            filters.Add(new ActionExe());

        }
    }


    /// <summary>
    /// 权限控制判断 
    /// 执行顺序1.OnAuthorization 2.AuthorizeCore，3.HandleUnauthorizedRequest
    /// </summary>
    public class FilterAuthorAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        string error = string.Empty;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            
            try
            {
                string area = string.Empty, controler = string.Empty, action = string.Empty;
                string[] s = httpContext.Request.Url.Segments;
                if (httpContext.Request.ApplicationPath.Length == 1)
                {
                    if (s.Length > 1)
                    {
                        area = s[1].Replace("/", "");
                    }
                    if (s.Length > 2)
                    {
                        controler = s[2].Replace("/", "");
                    }
                    if (s.Length > 3)
                    {
                        action = s[3].Replace("/", "");
                    }
                }
                else
                {
                    //有虚拟目录
                    if (s.Length > 2)
                    {
                        area = s[2].Replace("/", "");
                    }
                    if (s.Length > 3)
                    {
                        controler = s[3].Replace("/", "");
                    }
                    if (s.Length > 4)
                    {
                        action = s[4].Replace("/", "");
                    }
                }


                string err = string.Empty;
              
                bool result = CmsSessionExtend.CheckRight(area, controler, action, false, out err);

                error = err;
                return result;
            }
            catch (Exception e)
            {
               ( SharpLogService.LogClientInstance as ILog).Write(e);
                //   string ip = HttpContext.Current.Request.Params["server.RemoteIpAddress"] as string;
                throw;
            }
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            //HandlerException.RedirectError(filterContext, error);

        }
        protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            return base.OnCacheAuthorization(httpContext);
        }
    }
    /// <summary>
    /// 拦截MVC异常
    /// </summary>
    public class HandlerException : FilterAttribute, IExceptionFilter
    {

        public void OnException(ExceptionContext filterContext)
        {
            try
            {
              
                string area = string.Empty, controler = string.Empty, actionName = string.Empty;
                foreach (var item in filterContext.RouteData.DataTokens.Keys)
                {
                    if (item == "area")
                    {
                        area = filterContext.RouteData.DataTokens[item] as string;
                        break;
                    }
                }
                
                foreach (var item in filterContext.RouteData.Values.Keys)
                {
                    if (item == "controller")
                    {
                        controler = filterContext.RouteData.Values[item] as string;

                    }
                    else if (item == "action")
                    {
                        actionName = filterContext.RouteData.Values[item] as string;
                    }
                }
               
                string err = string.Empty;
                FunctionInfo f = FunctionInfoBll.FindFunc(area, controler, actionName, out err);
                string context = "";
                string funcID = string.Empty;
                if (f == null)
                {
                    context = filterContext.RequestContext.HttpContext.Request.Url.ToString();
                }
                else
                {
                    funcID = f.ID;
                }
                string accountid = CmsSession.GetUserID();//获取accountID
                (SharpLogService.LogClientInstance as ILog).Write( filterContext.Exception, accountid+ funcID+ context);
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {

                    filterContext.HttpContext.Response.StatusCode = 500;
                    filterContext.ExceptionHandled = true;
                    filterContext.Result = filterContext.Exception.FormatExceptionJsonResult();
                }
                else
                {
                    filterContext.HttpContext.Response.StatusCode = 500;
                    filterContext.ExceptionHandled = true;
                    filterContext.Result = new ViewResult() { ViewName = "Error" };
                    (SharpLogService.LogClientInstance as ILog).Write( "发生错误Error2" + area + controler + actionName);
                }


            }
            catch (Exception e)
            {
                (SharpLogService.LogClientInstance as ILog).Write("发生错误Error异常" );
                (SharpLogService.LogClientInstance as ILog).Write(e);
                throw;
            }
        }

        //public static void RedirectError(dynamic filterContext, string error)
        //{
        //    HttpStatusCodeResult resulxt = new HttpStatusCodeResult(500, error);
        //    RedirectResult v = new RedirectResult();
        //    v.TempData["error"] = error;
        //    v.ViewName = "error";
        //    filterContext.Result = resulxt;
        //}

    }

    public class ActionExe : System.Web.Mvc.ActionFilterAttribute
    {
        // 摘要: 
        //     在执行操作方法后由 ASP.NET MVC 框架调用。
        //
        // 参数: 
        //   filterContext:
        //     筛选器上下文。
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            base.OnActionExecuted(filterContext);


        }
        //
        // 摘要: 
        //     在执行操作方法之前由 ASP.NET MVC 框架调用。
        //
        // 参数: 
        //   filterContext:
        //     筛选器上下文。
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (new ParameterInfoBll().GetValue(StaticValue.IsRecordOper) == "1")
            {


                string area = string.Empty;
                foreach (string item in ((System.Web.Mvc.ControllerContext)(filterContext)).RouteData.DataTokens.Keys)
                {
                    if (item == "area")
                    {
                        area = ((System.Web.Mvc.ControllerContext)(filterContext)).RouteData.DataTokens[item] as string;
                        break;
                    }
                }
                string controler = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string action = filterContext.ActionDescriptor.ActionName;
                string userid = CmsSession.GetUserID();
                string error = string.Empty;
                FunctionInfoBll.WriteLog(userid, area, controler, action);
            }
            base.OnActionExecuting(filterContext);

        }
        //
        // 摘要: 
        //     在执行操作结果后由 ASP.NET MVC 框架调用。
        //
        // 参数: 
        //   filterContext:
        //     筛选器上下文。
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {


            base.OnResultExecuted(filterContext);

        }
        //
        // 摘要: 
        //     在执行操作结果之前由 ASP.NET MVC 框架调用。
        //
        // 参数: 
        //   filterContext:
        //     筛选器上下文。
        public override void OnResultExecuting(ResultExecutingContext filterContext) { base.OnResultExecuting(filterContext); }
    }

}
