using System.Web.Mvc;

namespace EasyCms.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}/{other}",
                new { controller = "Index", action = "Index", id = UrlParameter.Optional , other = UrlParameter.Optional}
                 , namespaces: new string[] { "EasyCms.Web.Areas.Admin.Controllers" }
            );
             
        }
    }
}