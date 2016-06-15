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

            string error = "";
            Dal.Delete("ShopPromotion", "ID", id, out error);
            return error;
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
                return Dal.From<ShopPromotion>() 
                .OrderBy(ShopPromotion._.StartDate.Desc)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public ShopPromotion GetEntity(string id)
        {

            ShopPromotion obj= Dal.From<ShopPromotion>()
                 
                .Join<ShopCategory>(ShopCategory._.ID==ShopPromotion._.BuyCategoryId, JoinType.leftJoin)
                .Join<ShopProductInfo>(ShopProductInfo._.ID==ShopPromotion._.BuyProductId, JoinType.leftJoin)
                .Join<ShopProductSKUInfo>(ShopProductSKUInfo._.ID==ShopPromotion._.BuySKUID, JoinType.leftJoin)
                
                 .Select(ShopPromotion._.ID.All, ShopCategory._.Name.Alias("BuyCategoryName")
                 , ShopProductInfo._.Name.Alias("BuyProductName")
                , ShopProductSKUInfo._.SKU.Alias("BuySKUCode")
                 ).Where(ShopPromotion._.ID==id)
               .ToFirst<ShopPromotion>();
             
            if (!string.IsNullOrWhiteSpace(obj.HandsaleProductId))
            {
                obj.HandProductName = Dal.From<ShopProductInfo>().Where(ShopProductInfo._.ID == obj.HandsaleProductId).Select(ShopProductInfo._.Name).ToScalar() as string;
            }
              

                return obj;
        }


        public List<ShopPromotion> GetValidPromotionList(  ActionPlatform plat, ActionEvent actionevent)
        {
            
            UpdatePromotion(); 
            WhereClip where = ShopPromotion._.ActionStatus == (int)AcitivyStatus.进行中&& ShopPromotion._.ActionEvent==(int) actionevent;
            if (actionevent== ActionEvent.购物)
            {
                where = ShopPromotion._.ActionStatus == (int)AcitivyStatus.进行中 && ShopPromotion._.ActionEvent.In( (int)ActionEvent.购物, (int)ActionEvent.首单);
            }
            //获取当前时间所有可用的促销活动
            List<ShopPromotion> list = Dal.From<ShopPromotion>()  
                .Where(where) 
                .List<ShopPromotion>();  
            return list;
        }



      
        private void UpdatePromotion()
        {
            //先更新过期日期小于今天的为无效
            ShopPromotion updatePromotion = new ShopPromotion()
            {
                RecordStatus = StatusType.update,
                ActionStatus = AcitivyStatus.完成,
                Where = ShopPromotion._.ActionStatus== (int)AcitivyStatus.进行中  && ShopPromotion._.EndDate < DateTime.Now
            };
            Dal.Submit(updatePromotion);
            List<ShopPromotion> list = Dal.From<ShopPromotion>()
                .Select(ShopPromotion._.ID, ShopPromotion._.HandsaleCount, ShopPromotion._.HandsaleMaxCount, ShopPromotion._.HasSendCount
                 )
                .Where(ShopPromotion._.ActionStatus == (int)AcitivyStatus.进行中
                && ShopPromotion._.HandsaleMaxCount > 0
                ).List<ShopPromotion>();
            foreach (ShopPromotion item in list)
            {
                if ((item.HandsaleMaxCount - item.HasSendCount) <= item.HandsaleCount)
                {
                    item.ActionStatus = AcitivyStatus.完成;
                }

            }
            Dal.Submit(list);
        }

        internal bool CheckValid(List<string> listPromot)
        {
            UpdatePromotion();
            if (Dal.Exists<ShopPromotion>(ShopPromotion._.ID.In(listPromot) && ShopPromotion._.ActionStatus == (int)ValidEnum.无效))
            {
                return false;
            }
            return true;
        }

        internal List<ShopPromotion> GetList(WhereClip whereClip)
        {
            return Dal.From<ShopPromotion>().Where(whereClip).List<ShopPromotion>();
        }
    }


}
