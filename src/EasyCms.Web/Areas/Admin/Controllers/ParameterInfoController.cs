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
    public class ParameterInfoController : BaseControler
    {
        ParameterInfoBll bll = new ParameterInfoBll();
        //
        // GET: /Admin/ParameterInfo/
        public ActionResult Index()
        {

            return View();
        }
        public string GetList()
        {
            System.Data.DataTable dt = bll.GetList();
            return JsonWithDataTable.Serialize(dt);
            ;

        }
        public string GetListForSelecte()
        {
            System.Data.DataTable dt = bll.GetList(true);
            return JsonWithDataTable.Serialize(dt);
        }
        public string CheckRepeat(string ID, string ParentID, string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID, ParentID, RecordStatus, val, IsCode).ToString().ToLower();

        }
        //
        // POST: /Admin/ParameterInfo/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ParameterInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<ParameterInfo>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ParameterInfo>();

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


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }


        //
        // GET: /Admin/ParameterInfo/Edit/5
        public ActionResult Edit(string id)
        {

            ParameterInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ParameterInfo();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ParameterInfo/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }



        public string GetIdAndNameByParentId(string id)
        {
            System.Data.DataTable dt = bll.GetIdAndNameByParentId(id);
            return JsonWithDataTable.Serialize(dt);
            ;

        }
    }
}
