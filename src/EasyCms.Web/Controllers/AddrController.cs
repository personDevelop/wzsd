using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Controllers
{
    public class AddrController : Controller
    {
        // GET: Addr
        public ActionResult Index(string addrID)
        {
            ShopShippingAddress ssar = null;
            if (!string.IsNullOrWhiteSpace(addrID) )
            {
                ssar = new ShopShippingAddressBll().GetEntity(addrID);
            }
            if (ssar==null)
            {
                ssar = new ShopShippingAddress();
            }
            return View(ssar);
        }

        public ActionResult Save(ShopShippingAddress addr)
        {
            return View();
        }
    }
}