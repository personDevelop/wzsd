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
    public class ShopShoppingCartsBll
    {
        ShopShoppingCartsDal Dal = new ShopShoppingCartsDal();
        public string Delete(string[] ids)
        {

            return Dal.Delete(ids);
        }

        public int Save(ShopShoppingCarts item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(string userID)
        {
            return Dal.GetList(userID);
        }
       
 
        public ShopShoppingCarts GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }





        public DataTable GetCardInfo(List<string> productIDS, List<string> SKUIDS, string host)
        {

            return Dal.GetCardInfo( productIDS,  SKUIDS,   host);
        }

        public ShopShoppingCarts GetEntity(WhereClip whereClip)
        {
            return Dal.GetEntity(whereClip);
        }

        public List<ShopCardInfo> GetMyCards(string userID)
        {
            return Dal.GetMyCards(userID);
        }
        public List<ShopShoppingCarts> GetMyDBCards(string userID)
        {
            return Dal.GetMyDBCards(userID);
        }
        public int Delete(WhereClip where)
        {
            return Dal.Delete(where);
        }

        public int Save(List<ShopShoppingCarts> cardList)
        {
            return Dal.Save(cardList);
        }
    }
}
