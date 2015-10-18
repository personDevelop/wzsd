using EasyCms.Model;
using Sharp.Common;
using Sharp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Dal
{
    public class ShopProductReviewsDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            string[] ids = id.Split(',');
            foreach (var item in ids)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    Dal.Delete("ShopProductReviews", "ID", item, out error);
                }
            }
            return error;
        }

        public int Save(ShopProductReviews item)
        {
            if (!string.IsNullOrWhiteSpace(item.OrderId))
            {
                ShopOrder order = new ShopOrder() { RecordStatus = StatusType.update, Where = ShopOrder._.ID == item.OrderId };
                order.CommentStatus = true;
                Dal.Submit(order);
            }
            return CommonDal.UpdatePath<ShopProductReviews>(Dal, item, ShopProductReviews._.ID, ShopProductReviews._.ParentID, ParameterInfo._.ClassCode, null, null, null);



        }



        public DataTable GetListByProductID(string productID, int pagenum, int pagesize, ref int recordCount,
            ref int goodCount, ref int middleCount, ref int badCount)
        {
            int pageCount = 0;
            goodCount = Dal.Count<ShopProductReviews>(ShopProductReviews._.ProductId == productID && ShopProductReviews._.CommentOrder == CommentOrder.好评, ShopProductReviews._.ID, false);
            middleCount = Dal.Count<ShopProductReviews>(ShopProductReviews._.ProductId == productID && ShopProductReviews._.CommentOrder == CommentOrder.中评, ShopProductReviews._.ID, false);
            badCount = Dal.Count<ShopProductReviews>(ShopProductReviews._.ProductId == productID && ShopProductReviews._.CommentOrder == CommentOrder.差评, ShopProductReviews._.ID, false);
            return Dal.From<ShopProductReviews>()
                .Join<ManagerUserInfo>(ShopProductReviews._.UserId == ManagerUserInfo._.ID)
                .Where(ShopProductReviews._.ProductId == productID && ShopProductReviews._.Status == (int)DjStatus.生效)
                .Select(ShopProductReviews._.ID, ShopProductReviews._.ReviewText,
                  ShopProductReviews._.CreatedDate, new ExpressionClip("case when IsManager=1   then NickyName when IsAnony =1 then '匿名' else name  end").Alias("Name")
                )
                .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }


        public DataTable GetList(int pagenum, int pagesize, WhereClip where, ref int recordCount)
        {


            int pageCount = 0;

            return Dal.From<ShopProductReviews>()
                .Join<ManagerUserInfo>(ShopProductReviews._.UserId == ManagerUserInfo._.ID)
                 .Join<ShopProductInfo>(ShopProductInfo._.ID == ShopProductReviews._.ProductId)
                .Where(where)
                .Select(ShopProductReviews._.ID, ShopProductReviews._.ReviewText, ShopProductReviews._.ProductId
                , ShopProductReviews._.hasReply,
                ShopProductReviews._.UserId, ShopProductReviews._.ParentID, ShopProductReviews._.Status, ShopProductReviews._.OrderId, ShopProductInfo._.Name.Alias("ProductName"),
                  ShopProductReviews._.CreatedDate, ManagerUserInfo._.Code, ManagerUserInfo._.Name, ManagerUserInfo._.IsManager
                ).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public ShopProductReviews GetEntity(string id)
        {
            ShopProductReviews sr = Dal.From<ShopProductReviews>()
                  .Join<ManagerUserInfo>(ShopProductReviews._.UserId == ManagerUserInfo._.ID)
                   .Join<ShopProductInfo>(ShopProductInfo._.ID == ShopProductReviews._.ProductId)
                   .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 1, JoinType.leftJoin)
                  .Where(ShopProductReviews._.ID == id)
                  .Select(ShopProductReviews._.ID.All,
              ShopProductInfo._.Name.Alias("ProductName"),
                    ManagerUserInfo._.Code, ManagerUserInfo._.Name.Alias("UserName"), ManagerUserInfo._.IsManager, AttachFile.GetFilePath("", "ProductImg")
                  ).ToFirst<ShopProductReviews>();
            sr.Images = Dal.From<AttachFile>().Where(AttachFile._.RefID == sr.ImagesID).Select(AttachFile.GetFilePath("", "Images"))
                .ToSinglePropertyArray();
            List<ShopProductReviews> lastReplay = Dal.From<ShopProductReviews>()
                    .Join<ManagerUserInfo>(ShopProductReviews._.UserId == ManagerUserInfo._.ID)

                      .Where(ShopProductReviews._.ParentID == id).Select(ManagerUserInfo._.Name.Alias("UserName"), ShopProductReviews._.ReviewText,
                      ShopProductReviews._.CreatedDate).List<ShopProductReviews>();
            string reply = string.Empty;

            foreach (var item in lastReplay)
            {
                if (!string.IsNullOrWhiteSpace(reply))
                {
                    reply += "<br/>";

                }
                reply
                    += item.UserName + " " + item.CreatedDate.ToString("yyyy-MM-dd HH:mm") + "<br/>" + item.ReviewText;
            }
            sr.LastReply = reply;
            return sr;
        }

        public string Approve(string shopCommentID, bool isPass)
        {
            string[] ids = shopCommentID.Split(',');
            ShopProductReviews p = new ShopProductReviews();
            p.Where = ShopProductReviews._.ID.In(ids);
            p.RecordStatus = StatusType.update;
            if (isPass)
            {
                p.Status = (int)DjStatus.生效;

            }
            else
            { p.Status = (int)DjStatus.审批退回; }
            Dal.Submit(p);
            return string.Empty;
        }

        public int Reply(ShopProductReviews p)
        {
            int i = Save(p.CurrentReply);
            i += Dal.Submit(p);
            return i;
        }

        public string BachReply(string userid, string id, string replyText)
        {
            string[] ids = id.Split(',');
            if (ids == null || ids.Length == 0)
            {
                return "请选择要回复的评论";
            }
            else if (string.IsNullOrWhiteSpace(replyText))
            {
                return "请输入回复内容";

            }
            else
            {

                List<ShopProductReviews> list = Dal.From<ShopProductReviews>().Where(ShopProductReviews._.ID.In(ids)).List<ShopProductReviews>();
                foreach (var item in list)
                {
                    item.hasReply = true;
                    ShopProductReviews p = new ShopProductReviews()
                    {
                        ID = Guid.NewGuid().ToString(),
                        UserId = userid,
                        ProductId = item.ProductId,
                        SKUID = item.SKUID,
                        CreatedDate = DateTime.Now,
                        ParentID = item.ID,
                        Status = (int)DjStatus.生效,
                        OrderId = item.OrderId,
                        ReviewText = replyText
                    };
                    Save(p);
                    Dal.Submit(item);
                }
                return "批量回复成功";

            }
        }
    }

}
