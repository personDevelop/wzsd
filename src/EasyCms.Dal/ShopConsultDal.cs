using EasyCms.Model;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EasyCms.Dal
{
  
   public class ShopConsultDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            string[] ids = id.Split(',');
            foreach (var item in ids)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    Dal.Delete("ShopConsult", "ID", item, out error);
                }
            }
            return error;
        }

        public int Save(ShopConsult item)
        {
            return 0;
            //if (!string.IsNullOrWhiteSpace(item.OrderId))
            //{
            //    ShopOrder order = new ShopOrder() { RecordStatus = StatusType.update, Where = ShopOrder._.ID == item.OrderId };
            //    order.CommentStatus = true;
            //    Dal.Submit(order);
            //    if (!string.IsNullOrWhiteSpace(item.ProductId))
            //    {
            //        ShopOrderItem orderitem = new ShopOrderItem()
            //        {
            //            RecordStatus = StatusType.update,
            //            Where = ShopOrderItem._.OrderID == item.OrderId
            //                && ShopOrderItem._.ProductID == item.ProductId,
            //            HasComment = true
            //        };
            //        Dal.Submit(orderitem);

            //        ShopProductInfo product = new ShopProductInfo() { ID = item.ProductId, RecordStatus = StatusType.update };
            //        ExpressionClip commentCount = new ExpressionClip("CommentCount+1");
            //        product.SetModifiedProperty(ShopProductInfo._.CommentCount, commentCount);
            //        ExpressionClip commentOrder = null;

            //        switch (item.CommentOrder)
            //        {
            //            case CommentOrder.无:
            //                break;
            //            case CommentOrder.差评:
            //                commentOrder = new ExpressionClip("BadCount+1");
            //                product.SetModifiedProperty(ShopProductInfo._.BadCount, commentOrder);
            //                break;
            //            case CommentOrder.中评:
            //                commentOrder = new ExpressionClip("MiddleCount+1");
            //                product.SetModifiedProperty(ShopProductInfo._.MiddleCount, commentOrder);
            //                break;
            //            case CommentOrder.好评:
            //                commentOrder = new ExpressionClip("GoodCount+1");
            //                product.SetModifiedProperty(ShopProductInfo._.GoodCount, commentOrder);
            //                break;
            //            default:
            //                break;
            //        }
            //        Dal.Submit(product);
            //    }
            //}
            //return CommonDal.UpdatePath<ShopConsult>(Dal, item, ShopConsult._.ID, ShopConsult._.ParentID, ParameterInfo._.ClassCode, null, null, null);



        }



        public DataTable GetListByProductID(string productID, int order, int pagenum, int pagesize, ref int recordCount,
            ref int goodCount, ref int middleCount, ref int badCount)
        {
            return null;
            //int pageCount = 0;
            //goodCount = Dal.Count<ShopConsult>(ShopConsult._.ProductId == productID && ShopConsult._.CommentOrder == CommentOrder.好评, ShopConsult._.ID, false);
            //middleCount = Dal.Count<ShopConsult>(ShopConsult._.ProductId == productID && ShopConsult._.CommentOrder == CommentOrder.中评, ShopConsult._.ID, false);
            //badCount = Dal.Count<ShopConsult>(ShopConsult._.ProductId == productID && ShopConsult._.CommentOrder == CommentOrder.差评, ShopConsult._.ID, false);
            //WhereClip where = ShopConsult._.ProductId == productID && ShopConsult._.Status == (int)DjStatus.生效;
            ////if (order > 0)
            ////{
            ////    where = ShopConsult._.CommentOrder == order;
            ////}
            //return Dal.From<ShopConsult>()
            //    .Join<ManagerUserInfo>(ShopConsult._.UserId == ManagerUserInfo._.ID)
            //    .Where(where)
            //    .Select(ShopConsult._.ID, ShopConsult._.ReviewText, ShopConsult._.CommentOrder,
            //     new ExpressionClip("case when CommentOrder=1   then '差评' when CommentOrder=2   then '中评' else '好评'  end").Alias("CommentOrderStr"),
            //      ShopConsult._.CreatedDate, new ExpressionClip("case when IsManager=1   then NickyName when IsAnony =1 then '匿名' when NickyName is null or NickyName ='' then name else  NickyName end").Alias("Name")
            //    ).OrderBy(ShopConsult._.CreatedDate.Desc)
            //    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }


        public DataTable GetList(int pagenum, int pagesize, WhereClip where, ref int recordCount)
        {
            return null;

            //int pageCount = 0;

            //return Dal.From<ShopConsult>()
            //    .Join<ManagerUserInfo>(ShopConsult._.UserId == ManagerUserInfo._.ID)
            //     .Join<ShopProductInfo>(ShopProductInfo._.ID == ShopConsult._.ProductId)
            //    .Where(where)
            //    .Select(ShopConsult._.ID, ShopConsult._.ReviewText, ShopConsult._.ProductId
            //    ,  
            //    ShopConsult._.UserId, ShopConsult._.ParentID, ShopConsult._.Status, ShopConsult._.OrderId, ShopProductInfo._.Name.Alias("ProductName"),
            //      ShopConsult._.CreatedDate, ManagerUserInfo._.Code, ManagerUserInfo._.Name, ManagerUserInfo._.IsManager
            //    ).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public ShopConsult GetEntity(string id)
        {
            ShopConsult sr = Dal.From<ShopConsult>()
                  .Join<ManagerUserInfo>(ShopConsult._.UserId == ManagerUserInfo._.ID)
                   .Join<ShopProductInfo>(ShopProductInfo._.ID == ShopConsult._.ProductId)
                   .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 1, JoinType.leftJoin)
                  .Where(ShopConsult._.ID == id)
                  .Select(ShopConsult._.ID.All,
              ShopProductInfo._.Name.Alias("ProductName"),
                    ManagerUserInfo._.Code, ManagerUserInfo._.Name.Alias("UserName"), ManagerUserInfo._.IsManager, AttachFile.GetFilePath("", "ProductImg")
                  ).ToFirst<ShopConsult>();
            
            List<ShopConsult> lastReplay = Dal.From<ShopConsult>()
                    .Join<ManagerUserInfo>(ShopConsult._.UserId == ManagerUserInfo._.ID)

                      .Where(ShopConsult._.ParentID == id).Select(ManagerUserInfo._.Name.Alias("UserName"), ShopConsult._.ReviewText,
                      ShopConsult._.CreatedDate).List<ShopConsult>();
            string reply = string.Empty;

            //foreach (var item in lastReplay)
            //{
            //    if (!string.IsNullOrWhiteSpace(reply))
            //    {
            //        reply += "<br/>";

            //    }
            //    reply
            //        += item.UserName + " " + item.CreatedDate.ToString("yyyy-MM-dd HH:mm") + "<br/>" + item.ReviewText;
            //}
            //sr.LastReply = reply;
            return sr;
        }

        public string Approve(string shopCommentID, bool isPass)
        {
            string[] ids = shopCommentID.Split(',');
            ShopConsult p = new ShopConsult();
            p.Where = ShopConsult._.ID.In(ids);
            p.RecordStatus = StatusType.update;
            if (isPass)
            {
                p.Status = CommentStatus.已回复;

            }
            else
            { p.Status = CommentStatus.屏蔽; }
            Dal.Submit(p);
            return string.Empty;
        }

        public int Reply(ShopConsult p)
        {
            int i = Save(p.CurrentShopConsult);
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

                List<ShopConsult> list = Dal.From<ShopConsult>().Where(ShopConsult._.ID.In(ids)).List<ShopConsult>();
                foreach (var item in list)
                {
                    
                    ShopConsult p = new ShopConsult()
                    {
                        ID = Guid.NewGuid().ToString(),
                        UserId = userid,
                        ProductId = item.ProductId, 
                        CreatedDate = DateTime.Now,
                        ParentID = item.ID,
                        Status = CommentStatus.正常,
                        
                        ReviewText = replyText
                    };
                    Save(p);
                    Dal.Submit(item);
                }
                return "批量回复成功";

            }
        }

        public DataTable GetCommentProduct(string host, string accountid, string orderID, int state, int pageIndex, int pageSize, ref int recordCount)
        {
            int pageCount = 0;
            WhereClip where = ShopOrder._.MemberID == accountid;
            if (!string.IsNullOrWhiteSpace(orderID))
            {
                where = where && ShopOrder._.ID == orderID;
            }
            if (state == 1)
            {
                where = where && ShopOrderItem._.HasComment == false;
            }
            else if (state == 2)
            {
                where = where && ShopOrderItem._.HasComment == true;
            }
            DataTable dt = Dal.From<ShopOrderItem>().Join<ShopOrder>(ShopOrderItem._.OrderID == ShopOrder._.ID)
                .Select(ShopOrderItem._.OrderID, ShopOrderItem._.ProductID, ShopOrder._.CreateDate, ShopOrderItem._.Price, ShopOrderItem._.ProductName, new ExpressionClip("'" + host + "'" + "+ProductThumb").Alias("ProductThumb"), ShopOrderItem._.HasComment)
                   .Where(where).OrderBy(ShopOrder._.CreateDate.Desc).ToDataTable(pageSize, pageIndex, ref pageCount, ref recordCount);


            return dt;

        }
    }
}
