using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class ShopProductStationModeController : Controller
    {
        //
        // GET: /Admin/ShopProductStationMode/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateStationOrderNo(int station, string StationID, int newvalue )
        {
            ShopProductInfoBll bll = new ShopProductInfoBll();
            string msg = bll.UpdateStationOrderNo(  station,   StationID,   newvalue );
            if (string.IsNullOrWhiteSpace(msg))
            {
                return Json(new { IsSuccess = true, msg = "更新成功" });
            } else
            {
                return Json(new { IsSuccess = false, msg = msg });
            }
           
        }

    }
}