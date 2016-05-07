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

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class CouponSendRecordController : Controller
    {
        CouponRuleBll bll = new CouponRuleBll();
        //
        // GET: /Admin/SendCoupon/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetSendRecordList(pagenum.PhrasePageIndex(), pagesize, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }


        //
        // POST: /Admin/SendCoupon/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            SendCoupon p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetSendReordeEntity(collection["ID"]);
                    p.BindForm<SendCoupon>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<SendCoupon>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                        p.CreateTime = DateTime.Now;
                    }
                    p.SendUserID = Session.GetUserID() ?? "root";
                    p.SendUserName = CmsSession.GetUserName();
                }
                bll.SaveSendRecord(p);
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
                    p = new SendCoupon();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/SendCoupon/Edit/5
        public ActionResult Edit(string id)
        {

            SendCoupon p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new SendCoupon();
            }
            else
                p = bll.GetSendReordeEntity(id);
            return View("Edit", p);
        }

        //
        // GET: /Admin/SendCoupon/Edit/5
        public ActionResult Send(string id)
        {
            string err;
            bool issuccess = bll.Send(id, out err);
            if (issuccess)
            {
                return "发送成功".FormatJsonResult();
            }
            else
            {

                return err.FormatErrorJsonResult();
            }
        }

        [HttpPost]
        //
        // GET: /Admin/SendCoupon/Delete/5
        public string Delete(string id)
        {
            return bll.DeleteSendRecord(id);
        }
    }
}
