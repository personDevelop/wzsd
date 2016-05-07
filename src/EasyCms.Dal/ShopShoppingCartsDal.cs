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

        public List<ShopCardInfo> GetMyCards(string userID)
        {
            List<ShopCardInfo> resultList = new List<ShopCardInfo>();
            List<ShopShoppingCarts> list= Dal.From<ShopShoppingCarts>().Where(ShopShoppingCarts._.UserId == userID)
                .OrderBy(ShopShoppingCarts._.AddTime)
                .List<ShopShoppingCarts>();
           
            foreach (var item in list)
            {
                ShopCardInfo sc = new ShopCardInfo() { ActivityID=item.ActivityID, AddTime=item.AddTime.ToString("yyyy-MM-dd HH:mm:ss"),
                 BuyType=item.ItemType,  Name=item.Name, ProductId=item.ProductId, Quantity=item.Quantity,
                 SalePrice= item.SellPrice, SKU=item.SKU};


                
                ShopProductInfo p = Dal.From<ShopProductInfo>().Where(ShopProductInfo._.ID == item.ProductId)
                    .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 0, JoinType.leftJoin)

                    .Select(  ShopProductInfo._.SaleStatus, ShopProductInfo._.Stock, ShopProductInfo._.SalePrice, AttachFile.GetThumbnaifilePath("", "ThumbImgUrl")).ToFirst<ShopProductInfo>();
               
                sc.ThumbImgUrl = p.ThumbImgUrl;
                sc.Stock = p.Stock;
                sc.IsSale = p.SaleStatus == 1;
                sc.Name = p.Name;
                sc.SalePrice = p.SalePrice;
                if (!string.IsNullOrWhiteSpace(item.SKU))
                {
                    ShopProductSKUInfo skup = Dal.From<ShopProductSKUInfo>().Where(ShopProductSKUInfo._.ID == item.SKU).Select(ShopProductSKUInfo._.ID, ShopProductSKUInfo._.SalePrice, ShopProductSKUInfo._.Stock, ShopProductSKUInfo._.IsSale, ShopProductSKUInfo._.Name).ToFirst<ShopProductSKUInfo>();

                    sc.GuiGeInfo = skup.Name;
                    
                    sc.Stock = skup.Stock;
                    sc.IsSale = skup.IsSale;
                    sc.SalePrice = skup.SalePrice;
                } 
                resultList.Add(sc);
            }

            return resultList;
        }

        public ShopShoppingCarts GetEntity(WhereClip whereClip)
        {
            return Dal.Find<ShopShoppingCarts>(whereClip);
        }
    }

}
