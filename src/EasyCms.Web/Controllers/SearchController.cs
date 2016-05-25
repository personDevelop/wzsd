using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(string id)
        {
            ViewBag.SearchText = id;
            return View( );
        }
    }
}