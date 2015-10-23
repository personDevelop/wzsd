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
    public class ShopReturnOrderDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("ShopReturnOrder", "ID", id, out error);
            return error;
        }

        public int Save(ShopReturnOrder item)
        {
            return 1;

        }

        public DataTable GetList(int pageIndex, int pagesize, WhereClip where, ref int recordCount)
        {
            int pageCount = 0;

            return Dal.From<ShopReturnOrder>().Where(where).OrderBy(ShopReturnOrder._.CreatedDate.Desc)

                .ToDataTable(pagesize, pageIndex, ref pageCount, ref recordCount);

        }



        public ShopReturnOrder GetEntity(string id)
        {

            return Dal.Find<ShopReturnOrder>(id);
        }



        public DataTable GetReturnDetail(string returnOrderNo)
        {
            return Dal.From<ShopReturnOrderItem>().Where(ShopReturnOrderItem._.ReturnOrderId == returnOrderNo).ToDataTable();
        }
    }


}
