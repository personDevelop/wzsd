using EasyCms.Business;
using EasyCms.Model.ViewModel;
using EasyCms.Web.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class FunctionRightController : Controller
    {
        //
        // GET: /Admin/FunctionRight/
        public ActionResult Index()
        {
            return View();
        }
        public string GetRoleOrMemberOrderList(int id)
        {
            DataTable dt = new FunctionRightBll().GetRoleOrMemberOrderList(id);
            return JsonWithDataTable.Serialize(dt);
        }

        public string GetRightList(string roleID, bool isAll, int sqtype)
        {
           
            DataTable dt = new FunctionRightBll().GetRightList(roleID, isAll, sqtype);
            return JsonWithDataTable.Serialize(dt);
        }
        [HttpPost]
        public JsonResult SaveRight(SaveModel saveModel)
        {

            string result = new FunctionRightBll().SaveRight(saveModel);
            if (string.IsNullOrWhiteSpace(result))
            {
                return Json(new { IsSuccess=true,Msg="授权成功" });
            }
            else 
            return    Json(new { IsSuccess=false,Msg=result });
        }

    }
}