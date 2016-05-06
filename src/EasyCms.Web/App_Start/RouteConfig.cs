using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace EasyCms.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{other}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional, other = RouteParameter.Optional }
            );
            routes.MapRoute(
            name: "ApiWithWeb",
            url: "api/{controller}/{action}/{id}/{pageIndex}/{other}",
          defaults: new { id = RouteParameter.Optional, pageIndex = RouteParameter.Optional, other = RouteParameter.Optional });


        }
    }
}
