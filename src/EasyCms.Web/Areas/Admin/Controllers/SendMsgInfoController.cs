using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using EasyCms.Web.Common;
using EasyCms.Session;
using MsgService;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class SendMsgInfoController : Controller
    {
        SendMsgInfoBll bll = new SendMsgInfoBll();
        //
        // GET: /Admin/SendMsgInfo/
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

        //
        // POST: /Admin/SendMsgInfo/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            SendMsgInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<SendMsgInfo>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<SendMsgInfo>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                        p.CreateName = CmsSession.GetUserName();
                    }
                    p.CreateTime = DateTime.Now;
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
                    p = new SendMsgInfo();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/SendMsgInfo/Edit/5
        public ActionResult Edit(string id)
        {

            SendMsgInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new SendMsgInfo();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/SendMsgInfo/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
        [HttpPost]
        //
        // GET: /Admin/SendMsgInfo/Delete/5
        public string Send(string id)
        {
            return MsgFactory.SendMsg(id);
        }

    }
}
