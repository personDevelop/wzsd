using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using System.Data;
using EasyCms.Web.Common;
using EasyCms.Session;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class NewsInfoController : BaseControler
    {
        NewsInfoBll bll = new NewsInfoBll();
        //
        // GET: /Admin/NewsInfo/
        public ActionResult Index()
        {

            return View();
        }
        public string GetList(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum.PhrasePageIndex(), pagesize, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }
        public string GetListForSelecte(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum, pagesize, ref   recordCount, true);
            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;
        }

        //
        // POST: /Admin/NewsInfo/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            NewsInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"] );
                    p.BindForm<NewsInfo>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<NewsInfo>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                    p.CreatedUserID = CmsSession.GetUserID() ?? "root";
                }
                bll.Save(p);
                if (TempData.ContainsKey("IsSuccess"))
                {
                    TempData["IsSuccess"] = "保存成功";

                }
                else
                {
                    TempData.Add("IsSuccess", "保存成功");
                }
                ModelState.Clear();
                if (collection["IsContinueAdd"] == "1")
                {
                    p = new NewsInfo();

                } 


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/NewsInfo/Edit/5
        public ActionResult Edit(string id)
        {

            NewsInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new NewsInfo();
            }
            else
                p = bll.GetEntity(id );
            return View("Edit", p);
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