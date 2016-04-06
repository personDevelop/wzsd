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

            string error = "";
            Dal.Delete("ShopShoppingCarts", "ID", id, out error);
            return error;
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

        public DataTable GetCardInfo(List<string> productIDS, List<string> SKUIDS, string host)
        {
            WhereClip where = View_ProductInfoBySkuid._.ID.In(productIDS);
            if (SKUIDS==null || SKUIDS.Count==0)
	{
		  where =where&& View_ProductInfoBySkuid._.SKUID == string.Empty;
            
            }else
            {
                where = where && (

                  View_ProductInfoBySkuid._.SKUID.In(SKUIDS) || View_ProductInfoBySkuid._.SKUID == string.Empty

                  );
            }

            return Dal.From<View_ProductInfoBySkuid>().Join<AttachFile>(View_ProductInfoBySkuid._.ID == AttachFile._.RefID && AttachFile._.OrderNo==1, JoinType.leftJoin)
                .Select(View_ProductInfoBySkuid._.ID.All, AttachFile.GetThumbnaifilePath(host))
                .Where( where )
                .ToDataTable();
        }
    }

}
