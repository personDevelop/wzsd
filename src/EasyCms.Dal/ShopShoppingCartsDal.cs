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
    public class ShopShoppingCartsDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {

            int i = Dal.Delete<ShopShoppingCarts>(id);
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除分类";
            }
        }

        public int Save(ShopShoppingCarts item)
        {
            return Dal.Submit(item);
        }

        public DataTable GetList(string userID)
        {

            return Dal.From<ShopShoppingCarts>().Where(ShopShoppingCarts._.UserId == userID).OrderBy(ShopShoppingCarts._.AddTime).ToDataTable();
        }


        public ShopShoppingCarts GetEntity(string id)
        {
            return Dal.Find<ShopShoppingCarts>(id);
        }
    }

}
