using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Common
{
    public class AuthorCheckAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           

        }
    }

    public class MutilResponseAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var viewresult = filterContext.Result as ViewResult;

            if (viewresult == null)
            {
                return;

            }

            if (request.IsJsonRequest())
            {
                filterContext.Result = new JsonResult { Data = viewresult.Model };
            }
            else if (request.IsAjaxRequest())
            {
                //使用partialview
                filterContext.Result = new PartialViewResult
                {
                    TempData = viewresult.TempData,
                    ViewData = viewresult.ViewData,
                    ViewName = viewresult.ViewName
                };
            }
        }
    }
}