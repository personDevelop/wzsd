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
            return CommonDal.UpdatePath<ShopConsult>(Dal, item, ShopConsult._.ID, ShopConsult._.ParentID, ParameterInfo._.ClassCode, null, null, null);



        }



        public DataTable GetListByProductID(string productID, int order, int pagenum, int pagesize, ref int recordCount,
            ref int goodCount, ref int middleCount, ref int badCount)
        {

            int pageCount = 0;
            WhereClip where = ShopConsult._.ProductId == productID && ShopConsult._.Status != (int)CommentStatus.屏蔽;
            
            return Dal.From<ShopConsult>()
                .Join<ManagerUserInfo>(ShopConsult._.UserId == ManagerUserInfo._.ID)
                .Where(where)
                .Select(ShopConsult._.ID, ShopConsult._.ReviewText, 
                  
                  ShopConsult._.CreatedDate, new ExpressionClip("case when IsManager=1   then NickyName when IsAnony =1 then '匿名' when NickyName is null or NickyName ='' then name else  NickyName end").Alias("Name")
                ).OrderBy(ShopConsult._.CreatedDate.Desc)
                .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }


        public DataTable GetList(int pagenum, int pagesize, WhereClip where, ref int recordCount)
        {

            int pageCount = 0;

            return Dal.From<ShopConsult>()
                .Join<ManagerUserInfo>(ShopConsult._.UserId == ManagerUserInfo._.ID)
                 .Join<ShopProductInfo>(ShopProductInfo._.ID == ShopConsult._.ProductId)
                .Where(where)
                .Select(ShopConsult._.ID, ShopConsult._.ReviewText, ShopConsult._.ParentID, ShopConsult._.Status,
                ShopProductInfo._.Name.Alias("ProductName"),
                  ShopConsult._.CreatedDate, ManagerUserInfo._.Code, ManagerUserInfo._.Name, ManagerUserInfo._.IsManager
                ).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public ShopConsult GetEntity(string id)
        {
            ShopConsult sr = Dal.From<ShopConsult>()
                  .Join<ManagerUserInfo>(ShopConsult._.UserId == ManagerUserInfo._.ID)
                   .Join<ShopProductInfo>(ShopProductInfo._.ID == ShopConsult._.ProductId)
                  
                  .Where(ShopConsult._.ID == id)
                  .Select(ShopConsult._.ID.All,
              ShopProductInfo._.Name.Alias("ProductName"),
                     ManagerUserInfo._.Name.Alias("UserName")   
                  ).ToFirst<ShopConsult>();

            List<ShopConsult> lastReplay = Dal.From<ShopConsult>()
                    .Join<ManagerUserInfo>(ShopConsult._.UserId == ManagerUserInfo._.ID)

                      .Where(ShopConsult._.ParentID == id).Select(ManagerUserInfo._.Name.Alias("UserName"), ShopConsult._.ReviewText,
                      ShopConsult._.CreatedDate).List<ShopConsult>();
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
