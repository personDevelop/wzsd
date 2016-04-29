using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Web.Common;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class LogOperController : Controller
    {
        LogBll bll = new LogBll();
        //
        // GET: /Admin/LogOper/
        public ActionResult Index()
        {
            return View();
        }

        public string GetList(int pagenum, int pagesize, string StartDate, string EndDate, string QryLogType, bool isApp)
        {
            int recordCount = 0;
            WhereClip where = new WhereClip();

            DateTime start = DateTime.Now;
            if (isApp)
            {
                where = where && T_Log._.ModleNameSource == "APP";
            }
            if (StartDate.TryPhrase("yyyy-MM-dd", out start))
            {
                where = where && T_Log._.CrateDate >= start;
            }
            if (EndDate.TryPhrase("yyyy-MM-dd", out start))
            {
                where = where && T_Log._.CrateDate < start.AddDays(1);
            }
            if (!string.IsNullOrWhiteSpace(QryLogType))
            {
                string[] ps = QryLogType.Split(',');
                if (!ps.Contains(""))
                {
                    where = where && T_Log._.msgOrder.In(ps);
                }

            }
           
            System.Data.DataTable dt = bll.GetList(pagenum.PhrasePageIndex(), pagesize, where, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }

        [HttpPost]
        //
        // GET: /Admin/NewsInfo/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}