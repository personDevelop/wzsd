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

            string error = "";
            Dal.Delete("ShopShippingAddress", "ID", id, out error);
            return error;
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
                        AdministrativeRegions._.FullPath,
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
                          AdministrativeRegions._.FullPath,
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


        public bool UserDelete(string accountid, string id, out string err)
        {
            err = string.Empty;
            bool result = false;
            ShopOrder order = Dal.From<ShopOrder>().Where(ShopOrder._.ID == id).Select(ShopOrder._.ID, ShopOrder._.MemberID
                , ShopOrder._.OrderStatus, ShopOrder._.HasDelete).ToFirst<ShopOrder>();
            if (order.MemberID != accountid)
            {
                err = "不是您的订单，您不能删除";
            }
            else if (order.HasDelete)
            {
                err = "您的订单已经删除，无须再次删除";
            }
            else
            {
                OrderStatus os = order.OrderStatus.Phrase<OrderStatus>();
                switch (os)
                {
                    case OrderStatus.等待付款:
                    case OrderStatus.等待商家确认:
                    case OrderStatus.等待商家发货:
                    case OrderStatus.已发货:
                    case OrderStatus.已收货:
                    case OrderStatus.发起退货申请:
                    case OrderStatus.退货取货中:
                    case OrderStatus.商家已收货等待退款:
                    case OrderStatus.申请取消订单:
                    case OrderStatus.取消订单处理中:
                    default:
                        err = "您的订单正在处理中，不能删除";
                        break;
                    case OrderStatus.拒收:
                    case OrderStatus.作废:
                    case OrderStatus.商家不同意退换:
                    case OrderStatus.退货完成:
                    case OrderStatus.取消退货:
                    case OrderStatus.取消订单:
                    case OrderStatus.完成:
                        order.HasDelete = true;
                        Dal.Submit(order);
                        result = true; 
                        break;
                }
            }
            return result;
        }
    }

}
