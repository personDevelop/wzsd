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



        public DataTable GetReturnDetail(string host, string returnOrderNo)
        {

            return Dal.From<ShopReturnOrderItem>()
                .Select(
ShopReturnOrderItem._.ProductCode,
ShopReturnOrderItem._.Name,
new ExpressionClip("'" + host + "'" + "+ThumbnailsUrl").Alias("ThumbnailsUrl"),

 ShopReturnOrderItem._.AttributeDesc,
ShopReturnOrderItem._.SaleCount,
ShopReturnOrderItem._.RequestQuantity,
ShopReturnOrderItem._.SellPrice)
                .Where(ShopReturnOrderItem._.ReturnOrderId == returnOrderNo).ToDataTable();
        }
        public DataTable GetReturnRoute(string returnOrderNo, bool isShowHide = true)
        {
            WhereClip where = ShopOrderAction._.OrderId == returnOrderNo;
            if (!isShowHide)
            {
                where = where && ShopOrderAction._.IsHideUser == false;
            }
            return Dal.From<ShopOrderAction>()
                .Select(
ShopOrderAction._.Username,
ShopOrderAction._.ActionDate,
 ShopOrderAction._.Remark,
ShopOrderAction._.ActionName,
ShopOrderAction._.ReturnOrderID)
                .Where(where).ToDataTable();
        }

        public bool ReturnOrder(string accountid, ShopReturnOrder ro, out string error)
        {
            bool result = false;
            error = string.Empty;
            //先获取其订单状态
            ShopOrder order = Dal.Find<ShopOrder>(ro.OrderId);
            if (order == null)
            {
                error = "没有查到相应的订单 ";
            }
            else
                if (order.MemberID != accountid)
                {
                    error = "不是您的订单，您不能退回";

                }
                else if (ro.ReturnType == ReturnType.部分退 && ro.OrderItems.Count == 0)
                {
                    error = "部分退货时请标明退回的具体商品和退回数量";
                }
                else
                {

                    UserDjStatus os = order.RefundStatus;
                    bool isCanReturn = false;
                    switch (os)
                    {
                        case UserDjStatus.无:
                        case UserDjStatus.已取消:
                            order.HasReturn = true;
                            order.RefundStatus = UserDjStatus.等待审核;
                            isCanReturn = true;
                            break;
                        case UserDjStatus.等待审核:
                        case UserDjStatus.审批不通过:
                        case UserDjStatus.取货中:
                        case UserDjStatus.等待退款:
                        case UserDjStatus.已完成:
                        default:
                            error = "您的订单状态[" + os + "]，您不能退回";
                            break;
                    }
                    if (isCanReturn)
                    {
                        //生成退货单单号
                        #region MyRegion
                        ro.ID = GetMaxNo("THQ");
                        ro.UserId = accountid;
                        ro.UserName = order.MemberName;
                        ro.CreatedDate = DateTime.Now;
                        ro.PickRegionID = order.RegionID;
                        ro.PickRegion = order.ShipRegion;
                        ro.PickAddress = order.ShipAddress;
                        ro.PickZipCode = order.ShipZip;
                        ro.PickTelPhone = order.ShipTel;
                        ro.PickEmail = order.ShipEmail;
                        ro.ShippingModeId = order.OrderResId;
                        ro.ReturnTrueName = ro.UserName;
                        ro.ContactName = ro.ContactName;
                        ro.ContactPhone = ro.ContactPhone;
                        ro.Status = UserDjStatus.等待审核;
                        ro.LogisticStatus = LogisticStatus.无;
                        ro.ReturnMoneyStatus = ReturnMoneyStatus.无;
                        ro.IsShopReviceGood = true;
                        decimal je = 0;
                        List<ShopOrderItem> list = Dal.From<ShopOrderItem>().Where(ShopOrderItem._.OrderID == ro.OrderId).OrderBy(ShopOrderItem._.Sequence).List<ShopOrderItem>();
                        if (ro.OrderItems == null)
                        {
                            ro.OrderItems = new List<ShopReturnOrderItem>();
                        }
                        if (ro.OrderItems.Count == 0)
                        {
                            //整单退 
                            foreach (var item in list)
                            {
                                ShopReturnOrderItem detail = new ShopReturnOrderItem()
                                {
                                    ID = Guid.NewGuid().ToString(),
                                    ReturnOrderId = ro.ID,
                                    OrderId = ro.OrderId,
                                    OrderItemId = item.ID,
                                    ProductId = item.ProductID,
                                    SKUID = item.ProductSKU,
                                    Name = item.ProductName,
                                    ThumbnailsUrl = item.ProductThumb,
                                    Description = item.ShortDescription,
                                    SaleCount = item.Count,
                                    RequestQuantity = item.Count,
                                    ReturnCount = item.Count,
                                    CostPrice = item.CostPrice,
                                    SellPrice = item.Price,
                                    AttributeDesc = item.AttributeVal
                                };
                                ro.OrderItems.Add(detail);
                            }
                            if (order.PayMoney > 0)
                            {
                                je = order.PayMoney;
                            }
                            else
                            {
                                je = order.TotalPrice - order.Discount - order.Freight;
                            }

                        }
                        else
                        {

                            //部分退
                            foreach (var item in ro.OrderItems)
                            {
                                ShopOrderItem detail = list.Find(p => p.ProductID == item.ProductId && item.SKUID == p.ProductSKU);
                                item.ID = Guid.NewGuid().ToString();
                                item.ReturnOrderId = ro.ID;
                                item.OrderId = ro.OrderId;
                                item.OrderItemId = detail.ID;
                                item.Name = detail.ProductName;
                                item.ProductCode = detail.ProductCode;
                                item.ThumbnailsUrl = detail.ProductThumb;
                                item.Description = detail.ShortDescription;
                                item.SaleCount = detail.Count;
                                item.ReturnCount = item.RequestQuantity;
                                item.CostPrice = detail.CostPrice;
                                item.SellPrice = detail.Price;
                                item.AttributeDesc = detail.AttributeVal;
                                item.ReturnPrice = item.SellPrice * item.RequestQuantity;
                                je += item.ReturnPrice;
                                if (item.RequestQuantity > item.SaleCount)
                                {
                                    error = "请求退货数量不能大于购买数量";
                                    return false;
                                }
                            }
                        }
                        ro.RequestReturnMoney =
                         ro.ReturnMoney = je;
                        #endregion
                        //生成退货单 修改原订单  //生成订单动作表
                        List<BaseEntity> savelist = new List<BaseEntity>();
                        savelist.Add(order); savelist.Add(ro); savelist.AddRange(ro.OrderItems);
                        savelist.Add(new ShopOrderAction()
                        {
                            ID = Guid.NewGuid().ToString(),
                            ActionCode = ActionEnum.申请退货,
                            ActionDate = DateTime.Now,
                            ActionName = ActionEnum.申请退货.ToString(),
                            OrderId = order.ID,
                            ReturnOrderID = ro.ID,
                            UserId = order.MemberID,
                            Username = order.MemberName
                        });
                        savelist.Add(new ShopOrderAction()
                        {
                            ID = Guid.NewGuid().ToString(),
                            ActionCode = ActionEnum.申请退货,
                            ActionDate = DateTime.Now,
                            ActionName = ActionEnum.申请退货.ToString(),
                            OrderId = ro.ID,
                            ReturnOrderID = order.ID,
                            UserId = order.MemberID,
                            Username = order.MemberName
                        });
                        SessionFactory dal = null;
                        IDbTransaction tr = null;
                        try
                        {

                            tr = Dal.BeginTransaction(out dal);
                            dal.SubmitNew(tr, ref dal, savelist);
                            dal.CommitTransaction(tr);
                            result = true;
                            error = ro.ID;
                        }
                        catch (Exception)
                        {
                            dal.RollbackTransaction(tr);
                            throw;
                        }
                    }
                }
            return result;
        }

        public bool ExeAction(ActionEnum ae, string userid, string userName, string id, string ReturnMoney, string IsShopReviceGood, string RefuseReason, string ContactName, string PickTelPhone, string PickAddress, string PickRegionID, out string err)
        {
            err = string.Empty;
            ShopReturnOrder ro = Dal.From<ShopReturnOrder>().Where(ShopReturnOrder._.ID == id).Select(ShopReturnOrder._.ID, ShopReturnOrder._.OrderId, ShopReturnOrder._.Status, ShopReturnOrder._.LogisticStatus, ShopReturnOrder._.ReturnMoneyStatus, ShopReturnOrder._.PickAddress, ShopReturnOrder._.PickRegion, ShopReturnOrder._.PickRegionID, ShopReturnOrder._.PickTelPhone, ShopReturnOrder._.RefuseReason, ShopReturnOrder._.ContactName, ShopReturnOrder._.IsShopReviceGood, ShopReturnOrder._.Remark, ShopReturnOrder._.ReturnMoney).ToFirst<ShopReturnOrder>();
            ShopOrder updateOrder = new ShopOrder();
            updateOrder.ID = ro.OrderId;
            updateOrder.RecordStatus = StatusType.update;
            ro.ID = id;
            ro.RecordStatus = StatusType.update;
            decimal returnMoney = 0;
            bool isrecive = false;
            int addreseid = 0;
            switch (ae)
            {
                case ActionEnum.不同意退货:
                    if (ro.Status != UserDjStatus.等待审核)
                    {
                        err = "当前单据不允许审核";
                        return false;
                    }
                    ro.RefuseReason = RefuseReason;
                    ro.Status = UserDjStatus.审批不通过;
                    updateOrder.RefundStatus = UserDjStatus.审批不通过;
                    break;
                case ActionEnum.同意退货:
                    if (ro.Status != UserDjStatus.等待审核)
                    {
                        err = "当前单据不允许审核";
                        return false;
                    }
                    ro.Status = UserDjStatus.取货中;
                    ro.LogisticStatus = LogisticStatus.取货中;
                    updateOrder.RefundStatus = UserDjStatus.取货中;
                    if (decimal.TryParse(ReturnMoney, out returnMoney))
                    {
                        ro.ReturnMoney = returnMoney;
                    }

                    if (bool.TryParse(IsShopReviceGood, out isrecive))
                    {
                        ro.IsShopReviceGood = isrecive;
                    }
                    ro.ContactName = ContactName;
                    ro.PickTelPhone = PickTelPhone;
                    ro.PickAddress = PickAddress;
                    if (int.TryParse(PickRegionID, out addreseid))
                    {
                        ro.PickRegionID = addreseid;
                    }
                    break;
                case ActionEnum.完成取货:
                    if (ro.Status != UserDjStatus.取货中)
                    {
                        err = "当前单据不允许取货";
                        return false;
                    }
                    ro.Status = UserDjStatus.等待退款;
                    ro.LogisticStatus = LogisticStatus.取货完成;
                    ro.ReturnMoneyStatus = ReturnMoneyStatus.退款中;
                    updateOrder.RefundStatus = UserDjStatus.等待退款;
                    break;

                case ActionEnum.完成退款:

                    if (ro.Status != UserDjStatus.等待退款)
                    {
                        err = "当前单据不允许退款";
                        return false;
                    }
                    ro.Status = UserDjStatus.已完成;
                    ro.ReturnMoneyStatus = ReturnMoneyStatus.退款完成;
                    updateOrder.RefundStatus = UserDjStatus.已完成;
                    if (decimal.TryParse(ReturnMoney, out returnMoney))
                    {
                        ro.ReturnMoney = returnMoney;
                    }
                    break;
            }
            ShopOrderAction sa = new ShopOrderAction()
              {
                  ID = Guid.NewGuid().ToString(),
                  ActionCode = ae,
                  ActionDate = DateTime.Now,
                  ActionName = ae.ToString(),
                  OrderId = id,
                  UserId = userid,
                  Username = userName
              };
            SessionFactory dal = null;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                dal.SubmitNew(tr, ref dal, ro, sa, updateOrder);
                dal.CommitTransaction(tr);
                return true;
            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
                throw;
            }



        }
    }


}
