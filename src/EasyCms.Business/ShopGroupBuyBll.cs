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
    public class ShopActivityBll
    {
        ShopActivityDal Dal = new ShopActivityDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopGroupBuy item)
        {
            return Dal.Save(item);
        }


        public DataTable GetList(string name, int pagenum, int pagesize, ref int recordCount)
        {
            return Dal.GetList(name, pagenum, pagesize, ref recordCount);

        }

        public DataTable GetShopCountDownList(string name, int pagenum, int pagesize, ref int recordCount)
        {
            return Dal.GetShopCountDownList(name, pagenum, pagesize, ref recordCount);
        }

        public ShopGroupBuy GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }


   
        public string RemoveIDProduct(string RlationProductIDs )
        {
            return Dal.RemoveIDProduct(RlationProductIDs );

        }
        public string RemoveIDTime(string RlationTimeIDs)
        {
            return Dal.RemoveIDTime(RlationTimeIDs);

        }
        public DataTable GetSubList(string activityID)
        {
       
            return Dal.GetSubList(activityID );
        }

        public ShopCountDown GetShopCountDownEntity(string activityID)
        {
            return Dal.GetShopCountDownEntity(activityID);
        }

        public string SaveShopCountProducnt(ShopCountProducnt p)
        {
            return Dal.SaveShopCountProducnt(p);
        }
        public ShopCountProducnt GetShopCountProducnt(string id)
        {
            return Dal.GetShopCountProducnt(id);
        }

        public string IsQyOrStop(string id, int opcode)
        {
            return Dal.IsQyOrStop(id, opcode);
        }

        public string SaveShopCountDown(ShopCountDown p)
        {
            return Dal.SaveShopCountDown(p);
        }

        public string DeleteShopCountDown(string id)
        {
            return Dal.DeleteShopCountDown(id);
        }

        public string IsQyOrStopCuoutDown(string id, int opcode)
        {
            return Dal.IsQyOrStopCuoutDown(id,   opcode);
        }

        public ShopCountDownTime GetShopCountTime(string id)
        {
            return Dal.GetShopCountTime(id );
        }

        public string SaveShopCountDownTime(ShopCountDownTime p)
        {
            return Dal.SaveShopCountDownTime(p);
        }

        public string RemoveIDTimeByActivityID(string ActivityID)
        {
            return Dal.RemoveIDTimeByActivityID(ActivityID);
        }

        public DataTable GetSubTimeList(string ActivityID)
        {
            return Dal.GetSubTimeList(ActivityID);
        }
    }
}
