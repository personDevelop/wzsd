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
            Dal.Delete("ShopProductReviews", "ID", id, out error);
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
          return   Dal.Submit(item);


        }



        public DataTable GetListByProductID(string productID, int pagenum, int pagesize, ref int recordCount)
        {
            int pageCount = 0;

            return Dal.From<ShopProductReviews>()
                .Join<ManagerUserInfo>(ShopProductReviews._.UserId == ManagerUserInfo._.ID)
                .Where(ShopProductReviews._.ProductId == productID && ShopProductReviews._.Status == (int)DjStatus.生效)
                .Select(ShopProductReviews._.ID, ShopProductReviews._.ReviewText,
                  ShopProductReviews._.CreatedDate, ManagerUserInfo._.Code, ManagerUserInfo._.Name
                )
                .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

    }

}
