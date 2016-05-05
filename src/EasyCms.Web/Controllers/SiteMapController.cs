using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Controllers
{
    public class SiteMapController : Controller
    {
        // GET: SiteMap
        public ActionResult Index()
        {
            return View();
        }
    }
}