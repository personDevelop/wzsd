using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using System.Net.Http.Formatting;
using EasyCms.Session;
using EasyCms.Business;
using Sharp.Common;


namespace EasyCms.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SharpLogService.LogClientInstance = new LogBll();  //实例化日志实例   
            ModelBinders.Binders.DefaultBinder = new JsonModelBinder();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("json", "true", "application/json"));
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            ViewEngines.Engines.Add(new WebFormViewEngine());

            //删除xml的解析 当返回值是string 时 直接返回string不是json对象 
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

        }
        protected void Application_Error(object sender, EventArgs e)
        {
            //这里可以对所有错误信息 进行记录，但是目前只处理404错误，其他错误通过actionfilter处理
            //对于404错误，mvc
            //能处理域、control和action找不到的错误 
            //能处理api的control
            //不能处理api的action 找不到的时候拦截不到
            Exception ex = Server.GetLastError();
            
            if (ex is HttpException && (ex as HttpException).GetHttpCode() == 404)
            {
                string account = CmsSession.GetUserID();
                //找不到请求的错误。
                SharpLogService.LogClientInstance.WriteException(ex, account);
            }
        }


        protected void Session_Start()
        {
            CmsSession.Session = Session;
            DictionOrFilePathOperator.StartupPath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath+"bin\\";
        }


    }
}
