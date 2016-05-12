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
    public class ManagerUserInfoController : Controller
    {
        ManagerUserInfoBll bll = new ManagerUserInfoBll();
        //
        // GET: /Admin/ManagerUserInfo/
        public ActionResult Index()
        {

            return View();
        }
        //
        // GET: /Admin/ManagerUserInfo/
        public ActionResult ManagerIndex()
        {

            return View();
        }
        public string GetList()
        {
            System.Data.DataTable dt = bll.GetList();
            return JsonWithDataTable.Serialize(dt);

        }

        public string GetListForManager(int pagenum, int pagesize, string UserCode, string UserName, string UserStatus)
        {
            int recordCount = 0;
            WhereClip where = new WhereClip();
            if (!string.IsNullOrWhiteSpace(UserCode))
            {
                where = ManagerUserInfo._.Code.StartsWith(UserCode);
            }
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                where = where && ManagerUserInfo._.Name.StartsWith(UserName);
            }
            if (!string.IsNullOrWhiteSpace(UserStatus))
            {
                string[] ps = UserStatus.Split(',');
                if (!ps.Contains(""))
                {
                    where = where && ManagerUserInfo._.Status.In(ps);
                }

            }
            where = where && ManagerUserInfo._.IsManager == true;
            System.Data.DataTable dt = bll.GetListForAccount(pagenum.PhrasePageIndex(), pagesize, where, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }
        public string GetListForAccount(int pagenum, int pagesize, string UserCode, string UserName, string UserStatus)
        {
            int recordCount = 0;
            WhereClip where = new WhereClip();
            if (!string.IsNullOrWhiteSpace(UserCode))
            {
                where = ManagerUserInfo._.Code.StartsWith(UserCode);
            }
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                where = where && ManagerUserInfo._.Name.StartsWith(UserName);
            }
            if (!string.IsNullOrWhiteSpace(UserStatus))
            {
                string[] ps = UserStatus.Split(',');
                if (!ps.Contains(""))
                {
                    where = where && ManagerUserInfo._.Status.In(ps);
                }

            }
            where = where && ManagerUserInfo._.IsManager == false;
            System.Data.DataTable dt = bll.GetListForAccount(pagenum.PhrasePageIndex(), pagesize, where, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }
        public string GetListForSelecte(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum.PhrasePageIndex(), pagesize, ref   recordCount, true);
            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;
        }
        public string CheckRepeat(string ID, string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID, RecordStatus, val, IsCode).ToString().ToLower();

        }
        //
        // POST: /Admin/ManagerUserInfo/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ManagerUserInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<ManagerUserInfo>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ManagerUserInfo>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();

                    }
                    p.Pwd = "123456".EncryptSHA1();

                }
                p.IsManager = true;
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
                    p = new ManagerUserInfo();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/ManagerUserInfo/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.NewIndex = "ManagerIndex";
            ManagerUserInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ManagerUserInfo();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ManagerUserInfo/Delete/5
        public string ChangeStatus(string id, UserStatus status)
        {
            return bll.ChangeStatus(id, status);
        }


        public ActionResult SearchAccount()
        {

            return View("SearchAccount");
        }
    }
}
