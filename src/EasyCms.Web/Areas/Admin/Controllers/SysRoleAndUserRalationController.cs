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
    public class SysRoleAndUserRalationController : Controller
    {
        SysRoleAndUserRalationBll bll = new SysRoleAndUserRalationBll();
        //
        // GET: /Admin/SysRoleAndUserRalation/
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult AddRolePerson(string ID)
        {
            ViewBag.RoleID = ID;
            return View();
        }
        public string GetForAddPersonList(string RoleID)
        {
            System.Data.DataTable dt = bll.GetForAddPersonList(RoleID);

            string result = JsonWithDataTable.Serialize(dt);

            return result;

        }

        public JsonResult AddPersonToRole(string roleID, List<string> personIDS)
        {
            string msg = bll.AddPersonToRole(roleID, personIDS);
            if (string.IsNullOrWhiteSpace(msg))
            {
                return "添加成功".FormatJsonResult();

            }
            else
                return msg.FormatErrorJsonResult();

        }
        public string GetRolePersonList(int pagenum, int pagesize, string roleID)
        {
            int recordCount = 0;


            System.Data.DataTable dt = bll.GetRolePersonList(pagenum.PhrasePageIndex(), pagesize, roleID, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }

        //
        // POST: /Admin/SysRoleAndUserRalation/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            SysRoleAndUserRalation p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    //p = bll.GetEntity(collection["ID"]);
                    p.BindForm<SysRoleAndUserRalation>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<SysRoleAndUserRalation>();

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
                    p = new SysRoleAndUserRalation();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/CouponRule/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }

    }
}
