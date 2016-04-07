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
    public class FriendlyLinkTypeController : Controller
    {
        FriendlyLinkTypeBll bll = new FriendlyLinkTypeBll();
        //
        // GET: /Admin/FriendlyLinkType/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(  )
        {
          
            System.Data.DataTable dt = bll.GetList( );

            string result = JsonWithDataTable.Serialize(dt); 
            return result;

        }
     
        public string CheckRepeat(string ID,   string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID,  RecordStatus, val, IsCode).ToString().ToLower();

        }
        //
        // POST: /Admin/FriendlyLinkType/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            FriendlyLinkType p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<FriendlyLinkType>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<FriendlyLinkType>();

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
                    p = new FriendlyLinkType();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/FriendlyLinkType/Edit/5
        public ActionResult Edit(string id)
        {

            FriendlyLinkType p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new FriendlyLinkType();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/FriendlyLinkType/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
