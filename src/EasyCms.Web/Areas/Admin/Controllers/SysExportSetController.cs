using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using System.Data;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class SysExportSetController : Controller
    {
        SysExportSetBll bll = new SysExportSetBll();
        //
        // GET: /Admin/SysExportSet/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum + 1, pagesize, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }

        public string CheckRepeat(string ID, string RecordStatus, string val)
        {
            return bll.Exit(ID, RecordStatus, val).ToString().ToLower();

        }
        //
        // POST: /Admin/SysExportSet/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(SysExportSet exportSet, List<SysExportMx> mxList)
        {

            bool isSuccess = true;
            string msg = "保存成功";
            try
            {
                if (string.IsNullOrWhiteSpace(exportSet.ID))
                {
                    exportSet.ID = Guid.NewGuid().ToString();
                }

                bll.Save(exportSet, mxList);
            }
            catch (Exception ex)
            {
                isSuccess = false;
                msg = ex.Message + ex.Source + ex.StackTrace;
            }
            if (isSuccess)
            {
                return exportSet.ID.FormatJsonResult();

            }
            else return msg.FormatErrorJsonResult();
        }

        //
        // GET: /Admin/SysExportSet/Edit/5
        public ActionResult Edit(string id)
        {

            SysExportSet p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new SysExportSet();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/SysExportSet/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }

        public ActionResult AddMx(string tableName)
        {
            DataTable dt = null;
            string err = "";
            bool isSuccess = true;
            try
            {
                dt = bll.AddMx(tableName);
            }
            catch (Exception ex)
            {

                err = ex.Message + ex.StackTrace + ex.Source;
                isSuccess = false;
            }
            if (isSuccess)
            {
                return JsonWithDataTable.Serialize(dt).FormatJsonResult();
            }
            else
            {
                return err.FormatErrorJsonResult();
            }


        }
        public string GetMxList(string id)
        {
            DataTable dt = bll.GetMxDataTable(id);
            return JsonWithDataTable.Serialize(dt);
        }


        public ActionResult GetFile(string filePath)
        {
            string path = Server.MapPath("~/Upload/Export/" + filePath);
            if (Request.Browser.Browser == "IE" && Request.Browser.MajorVersion < 9)
            {
                return File(path, "application/ms-excel", filePath);
            }
            else
            {
                return File(path, "application/ms-excel", filePath);
            }
        }
    }

}