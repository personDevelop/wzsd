using EasyCms.Dal;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common;

namespace EasyCms.Business
{
    public class ShopProductReviewsBll
    {
        ShopProductReviewsDal Dal = new ShopProductReviewsDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopProductReviews item)
        {
            return Dal.Save(item);
        }


        public DataTable GetListByProductID(string productID, int pagenum, int pagesize, ref int recordCount)
        {
            return Dal.GetListByProductID(productID, pagenum, pagesize, ref   recordCount);
        }



        public DataTable GetList(int pagenum, int pagesize, WhereClip where, ref int recordCount)
        {
            return Dal.GetList(pagenum, pagesize, where, ref   recordCount);
        }

        public ShopProductReviews GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

        public string Approve(string shopCommentID, bool isPass)
        {
            return Dal.Approve(shopCommentID, isPass);
        }

        public int Reply(ShopProductReviews p)
        {
            return Dal.Reply(p);
        }

        public string BachReply(string userid,string id, string replyText)
        {
            return Dal.BachReply(userid, id, replyText);
        }
    }
}
