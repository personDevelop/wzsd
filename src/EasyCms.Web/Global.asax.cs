using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;


namespace EasyCms.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            RouteTable.Routes.RouteExistingFiles = false;
            ModelBinders.Binders.DefaultBinder = new JsonModelBinder();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            ViewEngines.Engines.Add(new WebFormViewEngine());
        }
        //protected void Application_Start()
        //{
        //    RouteTable.Routes.RouteExistingFiles = false;
        //    ModelBinders.Binders.DefaultBinder = new JsonModelBinder();
        //    AreaRegistration.RegisterAllAreas();

        //    // WebApiConfig.Register(GlobalConfiguration.Configuration);
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //    AuthConfig.RegisterAuth();
        //    ViewEngines.Engines.Clear();
        //    ViewEngines.Engines.Add(new RazorViewEngine());
        //    ViewEngines.Engines.Add(new WebFormViewEngine());
        //}
    }
}
