using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class AdPositonController : Controller
    {
        AdPositonBll bll = new AdPositonBll();
        //
        // GET: /Admin/AdPositon/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum + 1, pagesize, ref recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }
        public string GetListForSelecte( )
        {
          
            System.Data.DataTable dt = bll.GetList ( true);
            string result = JsonWithDataTable.Serialize(dt);
            
            return result;
        }
        public string CheckRepeat(string ID,   string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID,   RecordStatus, val, IsCode).ToString().ToLower();

        }
        //
        // POST: /Admin/AdPositon/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            AdPositon p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<AdPositon>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<AdPositon>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                     
                }
                bll.Save(p);
                if (TempData.ContainsKey("IsSuccess"))
                {
                    TempData.Add("IsSuccess", "保存成功");

                }
                else
                {
                    TempData["IsSuccess"] = "保存成功";
                }
                ModelState.Clear();
                if (collection["IsContinueAdd"] == "1")
                {
                    p = new AdPositon();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/AdPositon/Edit/5
        public ActionResult Edit(string id)
        {

            AdPositon p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new AdPositon();
                p.IsEnable = true;
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/AdPositon/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
