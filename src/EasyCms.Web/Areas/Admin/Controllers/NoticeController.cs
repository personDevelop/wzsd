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
    public class NoticeController : Controller
    {
        NoticeBll bll = new NoticeBll();
        //
        // GET: /Admin/Notice/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum + 1, pagesize, ref recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = string.Format("{{\"total\":\"{0}\",\"data\":{1}}}", recordCount, result);
           
            return result;

        }
        public string GetListForSelecte(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum, pagesize, ref recordCount, true);
            string result = JsonWithDataTable.Serialize(dt);
            result = string.Format("{{\"total\":\"{0}\",\"data\":{1}}}", recordCount, result);
            return result;
        }
      
        //
        // POST: /Admin/Notice/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            Notice p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<Notice>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<Notice>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                    p.CreateDate = DateTime.Now;
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
                    p = new Notice();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/Notice/Edit/5
        public ActionResult Edit(string id)
        {

            Notice p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new Notice();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/Notice/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }

        [HttpPost]
        //
        // GET: /Admin/Notice/Delete/5
        public string ChangeStatus(string id,int  stat )
        {
            return bll.Publish(id,stat);
        }

       
    }
}
