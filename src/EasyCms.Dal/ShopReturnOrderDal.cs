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

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;

            return Dal.From<ShopReturnOrder>().ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);


        }



        public ShopReturnOrder GetEntity(string id)
        {

            return Dal.Find<ShopReturnOrder>(id);
        }
    }


}
