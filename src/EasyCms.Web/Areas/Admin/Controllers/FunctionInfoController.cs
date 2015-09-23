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
    public class FunctionInfoController : Controller
    {
        FunctionInfoBll bll = new FunctionInfoBll();
        //
        // GET: /Admin/FunctionInfo/
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
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(true);
            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;
        }


        public string GetParentMoudle( )
        {
             
            System.Data.DataTable dt = bll.GetParentMoudle( );

            return JsonWithDataTable.Serialize(dt);

        }
        public string CheckRepeat(string ID, string ParentID, string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID, ParentID, RecordStatus, val, IsCode).ToString().ToLower();

        }
        //
        // POST: /Admin/FunctionInfo/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            FunctionInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<FunctionInfo>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<FunctionInfo>();

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
                    TempData["IsSuccess"] = "保存成功";

                }
                else
                {
                    TempData.Add("IsSuccess", "保存成功");
                }
                ModelState.Clear();
                if (collection["IsContinueAdd"] == "1")
                {
                    p = new FunctionInfo();

                } 

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
           
            return View("Edit", p);
        }

        //
        // GET: /Admin/FunctionInfo/Edit/5
        public ActionResult Edit(string id)
        {

            FunctionInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new FunctionInfo();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/FunctionInfo/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
