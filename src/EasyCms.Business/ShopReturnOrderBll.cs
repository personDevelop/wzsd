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
    public class ShopReturnOrderBll
    {
        ShopReturnOrderDal Dal = new ShopReturnOrderDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopReturnOrder item)
        {
            return Dal.Save(item);
        }

       



        public ShopReturnOrder GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

        public DataTable GetList(int pageIndex, int pagesize, WhereClip where, ref int recordCount)
        {
            return Dal.GetList(pageIndex,   pagesize,   where, ref   recordCount);
        }

        public DataTable GetReturnDetail(string returnOrderNo)
        {
            return Dal.GetReturnDetail(returnOrderNo);
        }
    }
}
