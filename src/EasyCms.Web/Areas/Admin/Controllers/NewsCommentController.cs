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
    public class NewsCommentController : Controller 
    {
        //
        // GET: /Admin/ShopComment/
        public ActionResult Index()
        {
            return View();
        }

        public string GetList(int pagenum, int pagesize, string StartDate, string EndDate, string QryDjStatus, string ShopProduct, bool OnlyWebUser)
        {

            int recordCount = 0;
            WhereClip where = new WhereClip();

            DateTime start = DateTime.Now;

            if (StartDate.TryPhrase("yyyy-MM-dd", out start))
            {
                where = where && NewsComment._.CreatedDate >= start;
            }
            if (EndDate.TryPhrase("yyyy-MM-dd", out start))
            {
                where = where && NewsComment._.CreatedDate < start.AddDays(1);
            }
            if (!string.IsNullOrWhiteSpace(ShopProduct))
            {
                where = where && NewsInfo._.NewsTitle.Contains(ShopProduct);
            }
            if (!string.IsNullOrWhiteSpace(QryDjStatus))
            {
                string[] ps = QryDjStatus.Split(',');
                if (!ps.Contains(""))
                {
                    where = where && NewsComment._.State.In(ps);
                }

            }

            if (OnlyWebUser)
            {
                where = where && ManagerUserInfo._.IsManager == false;
            }
            System.Data.DataTable dt = new NewsCommentBll().GetList(pagenum + 1, pagesize, where, ref recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }

        public ActionResult Edit(string id)
        {

            NewsComment p = null;
            if (!string.IsNullOrWhiteSpace(id))
            {
                p = new NewsCommentBll().GetEntity(id);
            }
            else
            {

                p = new NewsComment();
            }

            return View("Edit", p);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            NewsComment p = new NewsComment();
            NewsCommentBll bll = new NewsCommentBll();
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
                            p.State = DjStatus.审批不通过;
                            error = "审批不通过成功";
                        }
                        break;
                    default:
                        //答复
                        string ReplyID = collection["ReplyID"];
                        if (string.IsNullOrWhiteSpace(ReplyID))
                        {
                            p.CurrentNewsComment = new NewsComment()
                            {
                                ID = Guid.NewGuid().ToString(),
                                 CreatedUserID  = CmsSession.GetUserID(),
                                ContentId = p.ContentId,
                                CreatedDate = DateTime.Now,
                                ParentID = shopCommentID,
                                State =  DjStatus.生效,
                               
                            };
                        }
                        else
                        {
                            p.CurrentNewsComment = bll.GetEntity(ReplyID);
                        }
                        p.CurrentNewsComment.Description = collection["Description"];

                        bll.Reply(p);
                        error = "回复成功";
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
        public string ApprovalNotPass(string id)
        {
            //审批不通过

            string error = new NewsCommentBll().Approve(id, false);
            if (string.IsNullOrWhiteSpace(error))
            {

                error = "屏蔽成功";
            }
            return error;
        }
        [HttpPost]
        public string Delete(string id)
        {
            return new NewsCommentBll().Delete(id);
        }



    }
}
