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
    public class MemberOrderController : Controller
    {
        MemberOrderBll bll = new MemberOrderBll();
        //
        // GET: /Admin/MemberOrder/
        public ActionResult Index()
        {

            return View();
        }
        public string GetList()
        {
            System.Data.DataTable dt = bll.GetList();
            return JsonWithDataTable.Serialize(dt);

        }
        
        public string GetListForSelecte()
        {
         
            System.Data.DataTable dt = bll.GetList(true);
            string result = JsonWithDataTable.Serialize(dt);
            
            return result;
        }
        public string CheckRepeat(string ID, string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID, RecordStatus, val, IsCode).ToString().ToLower();

        }
        //
        // POST: /Admin/MemberOrder/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            MemberOrder p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<MemberOrder>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<MemberOrder>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }

                }
                bll.Save(p);
                TempData.Add("IsSuccess", "保存成功");
                ModelState.Clear();
                if (collection["IsContinueAdd"] == "1")
                {
                    p = new MemberOrder();

                } 


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/MemberOrder/Edit/5
        public ActionResult Edit(string id)
        {

            MemberOrder p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new MemberOrder();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/MemberOrder/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
