using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Controllers
{
    public class HelpController : Controller
    {
        // GET: Help
        public ActionResult Index(string id)
        {
            HelpContent hc = null;
            HelpContentBll bll = new HelpContentBll();
            if (string.IsNullOrWhiteSpace(id))
            {
                hc = bll.GetFirst();
            }
            else
            {
                hc = bll.GetEntity(id);
            }
            return View(hc);
        }
    }
}