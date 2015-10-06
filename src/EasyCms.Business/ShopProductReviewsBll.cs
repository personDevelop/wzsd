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
            return Dal.GetListByProductID(productID, pagenum, pagesize, ref   recordCount );
        }
          

    }
}
