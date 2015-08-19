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
    public class ShopPromotionBll
    {
        ShopPromotionDal Dal = new ShopPromotionDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopPromotion item)
        {
            return Dal.Save(item);
        }
 
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount, IsForSelected);
        }
       
 
        public ShopPromotion GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

  

    }
}
