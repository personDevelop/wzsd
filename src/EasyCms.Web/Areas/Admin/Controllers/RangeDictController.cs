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
    public class RangeDictController : Controller
    {
        RangeDictBll bll = new RangeDictBll();
        //
        // GET: /Admin/RangeDict/
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
        // POST: /Admin/RangeDict/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            RangeDict p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<RangeDict>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<RangeDict>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }

                }
                //获取商品类型
                p.HasService = string.Empty; 
                string key = "hasService";
                foreach (string item in collection.Keys)
                {
                    if (item.StartsWith(key))
                    {
                        string ptID = item.Substring(key.Length);
                        if (!string.IsNullOrWhiteSpace(ptID))
                        {
                            if (!string.IsNullOrWhiteSpace(p.HasService))
                            {
                                p.HasService += ",";
                            }
                            p.HasService += ptID;
                            
                        }

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
                    p = new RangeDict();

                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/RangeDict/Edit/5
        public ActionResult Edit(string id)
        {

            RangeDict p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new RangeDict();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/RangeDict/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
