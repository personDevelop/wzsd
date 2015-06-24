using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace EasyCms.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "EasyCmsApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
           
            config.Routes.MapHttpRoute(
              name: "ApiWithAction",
              routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional  });
           
        }
    }
}
