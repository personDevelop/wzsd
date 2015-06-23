using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms 
{
    public class BaseControler : Controller
    { 
        /// <summary>
        /// 通用权限控制
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //filterContext.Result = new HttpNotFoundResult(); 
            
            base.OnAuthorization(filterContext);
        }
        protected override void HandleUnknownAction(string actionName)
        {
            Response.Redirect("~/error.htm", true);
        }
    }
}