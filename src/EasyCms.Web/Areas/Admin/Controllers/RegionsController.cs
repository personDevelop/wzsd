using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using EasyCms.Web.Common;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class RegionsController : Controller
    {
        AdministrativeRegionsBll bll = new AdministrativeRegionsBll();
        //
        // GET: /Admin/AdministrativeRegions/
        public ActionResult Index()
        {

            return View();
        }
        public string GetList(int parentID = 0)
        {
            System.Data.DataTable dt = bll.GetList(parentID, false);
            return JsonWithDataTable.Serialize(dt);

        }

        public string GetListForSelecte(int parentID = 0)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(parentID, true);
            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;
        }
        public string CheckRepeat(int ID, int ParentID, string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID, ParentID, RecordStatus, val, IsCode).ToString().ToLower();

        }
        //
        // POST: /Admin/AdministrativeRegions/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            AdministrativeRegions p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<AdministrativeRegions>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<AdministrativeRegions>();

                }


                bll.Save(p);
                TempData.Add("IsSuccess", "保存成功");
                ModelState.Clear();


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/AdministrativeRegions/Edit/5
        public ActionResult Edit(string id)
        {

            AdministrativeRegions p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new AdministrativeRegions();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/AdministrativeRegions/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
