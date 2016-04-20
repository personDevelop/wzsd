using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Session;
using EasyCms.Web.Common;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class ShopConsultController : Controller
    {
        //
        // GET: /Admin/ShopComment/
        public ActionResult Index()
        {
            return View();
        }

        public string GetList(int pagenum, int pagesize, string StartDate, string EndDate, string QryDjStatus, string ShopProduct, bool OnlyWebUser, string QryCommentOrder)
        {

            int recordCount = 0;
            WhereClip where = new WhereClip();

            DateTime start = DateTime.Now;

            if (StartDate.TryPhrase("yyyy-MM-dd", out start))
            {
                where = where && ShopConsult._.CreatedDate >= start;
            }
            if (EndDate.TryPhrase("yyyy-MM-dd", out start))
            {
                where = where && ShopConsult._.CreatedDate < start.AddDays(1);
            }
            if (!string.IsNullOrWhiteSpace(ShopProduct))
            {
                where = where && ShopProductInfo._.Name.Contains(ShopProduct);
            }
            if (!string.IsNullOrWhiteSpace(QryDjStatus))
            {
                string[] ps = QryDjStatus.Split(',');
                if (!ps.Contains(""))
                {
                    where = where && ShopConsult._.Status.In(ps);
                }

            }
            //if (!string.IsNullOrWhiteSpace(QryCommentOrder))
            //{
            //    string[] ps = QryCommentOrder.Split(',');
            //    if (!ps.Contains(""))
            //    {
            //        where = where && ShopConsult._.CommentOrder.In(ps);
            //    }

            //}
            if (OnlyWebUser)
            {
                where = where && ManagerUserInfo._.IsManager == false;
            }
            System.Data.DataTable dt = new ShopConsultBll().GetList(pagenum + 1, pagesize, where, ref recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }

        public ActionResult Edit(string id)
        {

            ShopConsult p = null;
            if (!string.IsNullOrWhiteSpace(id))
            {
                p = new ShopConsultBll().GetEntity(id);
            }
            else
            {

                p = new ShopConsult();
            }

            return View("Edit", p);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopConsult p = new ShopConsult();
            ShopConsultBll bll = new ShopConsultBll();
            try
            {
                string SubmitActionType = collection["SubmitActionType"];
                string shopCommentID = collection["ID"];
                p = bll.GetEntity(shopCommentID);

                string error = string.Empty;
                switch (SubmitActionType)
                {
                    case "0":
                        //审批不通过
                        error = bll.Approve(shopCommentID, false);
                        if (string.IsNullOrWhiteSpace(error))
                        {
                            p.Status = CommentStatus.屏蔽;
                            error = "审批成功";
                        }
                        break;
                    case "1":
                        //审批 通过
                        error = bll.Approve(shopCommentID, true);
                        if (string.IsNullOrWhiteSpace(error))
                        {
                            p.Status = CommentStatus.已回复;
                            error = "审批成功";
                        }

                        break;
                    case "2":
                        //答复
                        string ReplyID = collection["ReplyID"];
                        if (string.IsNullOrWhiteSpace(ReplyID))
                        {
                            //p.CurrentReply = new ShopConsult()
                            //{
                            //    ID = Guid.NewGuid().ToString(),
                            //    UserId = CmsSession.GetUserID(),
                            //    ProductId = p.ProductId,
                            //    SKUID = p.SKUID,
                            //    CreatedDate = DateTime.Now,
                            //    ParentID = shopCommentID,
                            //    Status = DjStatus.生效,
                            //    OrderId = p.OrderId
                            //};
                        }
                        else
                        {
                            //p.CurrentReply = bll.GetEntity(ReplyID);
                        }
                        //p.CurrentReply.ReviewText = collection["ReviewText"];
                        //p.hasReply = true;
                        //bll.Reply(p);
                        error = "回复成功";
                        break;
                    default:
                        error = "无效动作";
                        break;
                }
                if (TempData.ContainsKey("IsSuccess"))
                {
                    TempData["IsSuccess"] = error;
                }
                else
                {
                    TempData.Add("IsSuccess", error);
                }

            }
            catch (Exception ex)
            {
                new LogBll().WriteException(ex);
                ModelState.AddModelError("error", ex.Message);


            }
            return View("Edit", p);
        }
        [HttpPost]
        public string ApprovalPass(string id)
        {
            //审批通过
            string error = new ShopConsultBll().Approve(id, true);
            if (string.IsNullOrWhiteSpace(error))
            {

                error = "审批成功";
            }
            return error;

        }
        [HttpPost]
        public string ApprovalNotPass(string id)
        {
            //审批不通过

            string error = new ShopConsultBll().Approve(id, false);
            if (string.IsNullOrWhiteSpace(error))
            {

                error = "审批成功";
            }
            return error;
        }
        [HttpPost]
        public string Delete(string id)
        {
            return new ShopConsultBll().Delete(id);
        }

        public string BachReply(string id, string other)
        {
            return new ShopConsultBll().BachReply(CmsSession.GetUserID(), id, other);
        }

    }
}