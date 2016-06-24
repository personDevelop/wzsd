using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using EasyCms.Web.Common;
using EasyCms.Model.ViewModel;
using EasyCms.Session;

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
            System.Data.DataTable dt = bll.GetListForAccount(pagenum.PhrasePageIndex(), pagesize, where, ref recordCount);

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
            System.Data.DataTable dt = bll.GetListForAccount(pagenum.PhrasePageIndex(), pagesize, where, ref recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }
        public string GetListForSelecte(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum.PhrasePageIndex(), pagesize, ref recordCount, true);
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
        [HttpGet]
        public ActionResult ModifyPwd()
        {
            return View(new ChangePwdModel());
        }
        [HttpPost]
        public ActionResult ModifyPwd(ChangePwdModel pwd)
        {
            if (string.IsNullOrWhiteSpace(pwd.OldPwd))
            {
                ModelState.AddModelError("OldPwd", "旧密码不能为空");
            }
            if (string.IsNullOrWhiteSpace(pwd.NewPwd))
            {
                ModelState.AddModelError("NewPwd", "新密码不能为空");
            }
            if (string.IsNullOrWhiteSpace(pwd.ConfirmNewPwd))
            {
                ModelState.AddModelError("ConfirmNewPwd", "确认密码不能为空");
            }
            if (!pwd.ConfirmNewPwd.Equals(pwd.NewPwd))
            {
                ModelState.AddModelError("ConfirmNewPwd", "两次输入密码不一致");
            }
            if (ModelState.IsValid)
            {
                ManagerUserInfo user = CmsSession.GetUser() as ManagerUserInfo;
                if (pwd.OldPwd.EncryptSHA1() != user.Pwd)
                {
                    ModelState.AddModelError("OldPwd", "旧密码不正确");

                }
                else
                {
                   
                 string result=   bll.ChangePwd(user.ID, pwd);
                    if (string.IsNullOrWhiteSpace(result))
                    {
                        user.Pwd = pwd.NewPwd.EncryptSHA1();
                        if (TempData.ContainsKey("IsSuccess"))
                        {
                            TempData["IsSuccess"] = "修改成功";

                        }
                        else
                        {
                            TempData.Add("IsSuccess", "修改成功");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("OldPwd", result);
                    }

                }
            }
            if (!ModelState.IsValid)
            {
                if (TempData.ContainsKey("IsSuccess"))
                {
                    TempData["IsSuccess"] = "修改失败";

                }
                else
                {
                    TempData.Add("IsSuccess", "修改失败");
                }
            }
            return View(pwd);
        }
        public ActionResult CZ(string id)
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
        public ActionResult ReCharge(string id)
        {
            ViewBag.ChargeBanlance =0.00;
            ManagerUserInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ManagerUserInfo();
                ModelState.AddModelError("id", "请先选择会员");
            }
            else
                p = bll.GetEntity(id);
            return View( p);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveReCharge(FormCollection collection)
        {
            string ChargeBanlanceStr = collection["Recharge"];
            string id = collection["ID"];
            decimal charegeBanlance = 0;
            decimal.TryParse(ChargeBanlanceStr, out charegeBanlance); 
            ViewBag.ChargeBanlance = charegeBanlance;
           

            if (charegeBanlance <= 0)
            {
                ModelState.AddModelError("Recharge", "充值金额必须大于0");
            }
            else if (charegeBanlance >1000)
            {
                ModelState.AddModelError("Recharge", "充值金额最多1000");
            }else
                if (!string.IsNullOrWhiteSpace(id))
            {
               string err= bll.ReCharge(id, charegeBanlance, CmsSession.GetUserID());
                if (!string.IsNullOrWhiteSpace(err))
                {
                    ModelState.AddModelError("Recharge", err);
                }
            }
            ManagerUserInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ManagerUserInfo();
                ModelState.AddModelError("id", "请先选择会员");
            }
            else
                p = bll.GetEntity(id);

            return View("ReCharge", p);
        }

        public string GetAccuontMoneyLog(string id)
        {
            System.Data.DataTable dt = bll.GetAccuontMoneyLog(id);
            return JsonWithDataTable.Serialize(dt);

        }

    }
}
