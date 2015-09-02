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
    public class ShopShippingAddressDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {

            int i = Dal.Delete<ShopShippingAddress>(id);
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除";
            }
        }

        public string Save(ShopShippingAddress item)
        {

            /*如果是新增的   
             如果是默认的，则先将以前的默认地址取消
             */
            IDbTransaction tr = null;
            Sharp.Data.SessionFactory dal = null;
            try
            {
                if (string.IsNullOrWhiteSpace(item.ID))
                {
                    item.ID = Guid.NewGuid().ToString();

                }
                item.IsDefault = true;
                ShopShippingAddress s = new ShopShippingAddress();
                s.RecordStatus = StatusType.update;
                s.Where = ShopShippingAddress._.UserId == item.UserId;
                s.IsDefault = false;

                if (dal == null)
                {
                    tr = Dal.BeginTransaction(out dal);
                }
                tr = Dal.BeginTransaction(out dal);
                dal.SubmitNew(tr, ref dal, s, item);
                dal.CommitTransaction(tr);
                return "操作成功";

            }
            catch (Exception ex)
            {
                dal.RollbackTransaction(tr);
                return "操作失败" + ex.Message;
            }

        }

        public DataTable GetList(string userID, bool IsDefault)
        {
            if (IsDefault)
            {
                return Dal.From<ShopShippingAddress>().Where(ShopShippingAddress._.UserId == userID && ShopShippingAddress._.IsDefault == IsDefault).ToDataTable(1);
            }
            else
                return Dal.From<ShopShippingAddress>().Where(ShopShippingAddress._.UserId == userID).ToDataTable();

        }

        public DataTable GetShopAddressForShow(string userID, bool IsDefault)
        {
            if (IsDefault)
            {
                return Dal.From<ShopShippingAddress>()
                    .Join<AdministrativeRegions>(ShopShippingAddress._.RegionId == AdministrativeRegions._.ID)
                    .Select(ShopShippingAddress._.ID,
                    ShopShippingAddress._.RegionId,
                    ShopShippingAddress._.ShipName,
                    ShopShippingAddress._.CelPhone,
                        ShopShippingAddress._.IsDefault,
                     new ExpressionClip("replace (path,'/','') + Address").Alias("Address"))
                    .Where(ShopShippingAddress._.UserId == userID && ShopShippingAddress._.IsDefault == IsDefault).ToDataTable(1);
            }
            else
                return Dal.From<ShopShippingAddress>()
                    .Join<AdministrativeRegions>(ShopShippingAddress._.RegionId == AdministrativeRegions._.ID)
                    .Select(ShopShippingAddress._.ID,
                    ShopShippingAddress._.RegionId,
                    ShopShippingAddress._.ShipName,
                    ShopShippingAddress._.CelPhone,
                        ShopShippingAddress._.IsDefault,
                     new ExpressionClip("replace (path,'/','') + Address").Alias("Address"))
                    .Where(ShopShippingAddress._.UserId == userID).ToDataTable();

        }
        public ShopShippingAddress GetEntity(string id)
        {
            return Dal.Find<ShopShippingAddress>(id);

        }





        public string SetDefault(string id)
        {
            SessionFactory dal = null;
            IDbTransaction tr = null;
            try
            {
                ShopShippingAddress s = GetEntity(id);
                s.Where = ShopShippingAddress._.UserId == s.UserId;
                s.IsDefault = false;
                ShopShippingAddress setdefalt = new ShopShippingAddress();
                setdefalt.ID = id;
                setdefalt.RecordStatus = StatusType.update;
                setdefalt.IsDefault = true;

                tr = Dal.BeginTransaction(out dal);
                dal.SubmitNew(tr, ref dal, s, setdefalt);
                dal.CommitTransaction(tr);
                return "操作成功";
            }
            catch (Exception ex)
            {
                if (dal != null && tr != null)
                {
                    dal.RollbackTransaction(tr);
                }

                return "操作失败";
            }
        }
    }

}
