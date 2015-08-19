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
    public class ShopPromotionDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {

            int i = Dal.Delete<ShopPromotion>(id);
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除促销活动";
            }
        }

        public int Save(ShopPromotion item)
        {

            Dal.Submit(item);

            return 1;


        }


        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<ShopPromotion>().OrderBy(ShopPromotion._.StartDate.Desc).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<ShopPromotion>().OrderBy(ShopPromotion._.StartDate.Desc)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public ShopPromotion GetEntity(string id)
        {

            return Dal.Find<ShopPromotion>(id);
        }




    }


}
