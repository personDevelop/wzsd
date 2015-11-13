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
    public class CouponRuleDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = "";
            Dal.Delete("CouponRule", "ID", id, out error);
            return error;

        }

        public int Save(CouponRule item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<CouponRule>().Select(CouponRule._.ID, CouponRule._.Name).OrderBy(CouponRule._.CreateDate.Desc).ToDataTable();
            }
            else
                return Dal.From<CouponRule>().OrderBy(CouponRule._.CreateDate.Desc)

                    .ToDataTable();
        }
        public bool Exit(string ID, string RecordStatus, string name)
        {
            WhereClip where = CouponRule._.Name == name;

            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && CouponRule._.ID != ID;

            }
            return !Dal.Exists<CouponRule>(where);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<CouponRule>().Select(CouponRule._.ID, CouponRule._.Name).OrderBy(CouponRule._.CreateDate.Desc).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<CouponRule>().OrderBy(CouponRule._.CreateDate.Desc)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public CouponRule GetEntity(string id)
        {

            return Dal.Find<CouponRule>(id);
        }




        public DataTable GetCoupon(string host, bool isAll = false)
        {
            WhereClip where = new WhereClip();
            if (isAll)
            {
                where = CouponRule._.IsEnable == true;
            }
            return Dal.From<CouponRule>().Join<AttachFile>(CouponRule._.ImageUrl == AttachFile._.RefID, JoinType.leftJoin)

                .Select(CouponRule._.ID, CouponRule._.Name, CouponRule._.JE,
                new ExpressionClip("case when QxLx=0 then '时间范围'  else   '固定天数' end ").Alias("QxLx")
                , CouponRule._.StartDate, CouponRule._.EndDate, CouponRule._.QXTS,
                new ExpressionClip("case when CouponType=0 then '普通优惠券' when CouponType=1 then '积分兑换优惠券' else '系统派发优惠券' end ").Alias("CouponTypeName"),
                CouponRule._.CouponType, AttachFile.GetFilePath(host))
                .Where(where)
                .ToDataTable();


        }

        internal List<CouponAccount> GetValidCouponList(List<OrderItem> orderItemlist, string accountID)
        {
            List<CouponAccount> result = new List<CouponAccount>();
            UpdateCoupon();
            List<string> productIdList = orderItemlist.Select(p => p.ProductID).ToList();
            //获取当前时间内该会员所有可用的优惠券
            List<CouponAccount> list = Dal.From<CusomerAndCoupon>()

                .Join<CouponRule>(CusomerAndCoupon._.CouponID == CouponRule._.ID)

                .Where(CusomerAndCoupon._.CustomerID == accountID && CouponRule._.IsEnable == true && CusomerAndCoupon._.IsOutDate == false && CusomerAndCoupon._.HaveCount > 0)
                .Select(CusomerAndCoupon._.ID, CouponRule._.Name, CusomerAndCoupon._.CardValue, CusomerAndCoupon._.HaveCount,
               CouponRule._.MinPrice, CouponRule._.IsCanCombie,
                CouponRule._.ProductId, CouponRule._.ProductSku, CouponRule._.CategoryId)
                .OrderBy(CouponRule._.StartDate).ToDataTable()
                .ToList<CouponAccount>();
            foreach (CouponAccount item in list)
            {
                if (!string.IsNullOrWhiteSpace(item.ProductSku))
                {  //先检测 SKU
                    if (orderItemlist.Exists(p => p.Sku == item.ProductSku))
                    {
                        //包含该种商品
                        foreach (OrderItem order in orderItemlist.Where(p => p.Sku == item.ProductSku))
                        {
                            if (
                               (order.BuyCount * order.SalePrice < item.MinPrice && item.MinPrice > 0))
                            {

                            }
                            else
                            {
                                //满足 
                                //然后检测当前订单内是否存在不满足的SKU
                                if (!orderItemlist.Exists(p => p.Sku != item.ProductSku))
                                {
                                    result.Add(item);
                                }


                            }

                        }
                    }
                    else
                    { continue; }


                }
                else
                    if (!string.IsNullOrWhiteSpace(item.ProductId))
                    {
                        //检测商品
                        if (orderItemlist.Exists(p => p.ProductID == item.ProductId))
                        {
                            //包含该种商品
                            foreach (OrderItem order in orderItemlist.Where(p => p.ProductID == item.ProductId))
                            {
                                if (order.BuyCount * order.SalePrice < item.MinPrice && item.MinPrice > 0)
                                {

                                }
                                else
                                    //然后检测当前订单内是否存在不满足的商品ID
                                    if (!orderItemlist.Exists(p => p.ProductID != item.ProductId))
                                    {
                                        result.Add(item);
                                    }

                            }
                        }
                        else
                        { continue; }
                    }

                    else
                        if (!string.IsNullOrWhiteSpace(item.CategoryId))
                        {
                            //检测分类
                            string[] products = Dal.From<ShopProductCategory>().Where(ShopProductCategory._.CategoryID == item.CategoryId
                                   && ShopProductCategory._.ProductID.In(productIdList)).Select(ShopProductCategory._.ProductID).ToSinglePropertyArray();
                            if (products != null && products.Length > 0)
                            {

                                foreach (OrderItem order in orderItemlist.Where(p => products.Contains(p.ProductID)))
                                {
                                    if (order.BuyCount * order.SalePrice < item.MinPrice && item.MinPrice > 0)
                                    {

                                    }
                                    else
                                        //然后检测当前订单内是否存在不满足的商品ID
                                        if (!orderItemlist.Exists(p => !products.Contains(p.ProductID)))
                                        {
                                            result.Add(item);
                                        }

                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            //适合所有商品的优惠券,这个算在总订单里
                            //包含该种商品
                            //计算总个数 和总金额
                            decimal totalPrice = orderItemlist.Sum(p => p.SalePrice);
                            if (totalPrice < item.MinPrice && item.MinPrice > 0)
                            {

                            }
                            else
                                result.Add(item);
                        }

            }


            return result;
        }

        private void UpdateCoupon()
        {
            //先更新过期日期小于今天的为无效
            CusomerAndCoupon updateCoupon = new CusomerAndCoupon() { RecordStatus = StatusType.update, IsOutDate = true };
            updateCoupon.Where = CusomerAndCoupon._.EndDate < DateTime.Now;
            Dal.Submit(updateCoupon);
        }

        internal bool CheckValid(List<string> listCoupon)
        {
            UpdateCoupon();
            if (Dal.Exists<CusomerAndCoupon>(CusomerAndCoupon._.ID.In(listCoupon) && CusomerAndCoupon._.IsOutDate == true))
            {
                return false;
            }
            return true;
        }

        public DataTable GetSendRecordList(int pagenum, int pagesize, ref int recordCount)
        {
            int pageCount = 0;
            return Dal.From<SendCoupon>().OrderBy(SendCoupon._.CreateTime.Desc).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public SendCoupon GetSendReordeEntity(string id)
        {
            return Dal.Find<SendCoupon>(id);
        }

        public string DeleteSendRecord(string id)
        {
            string error = "";
            Dal.Delete("SendCoupon", "ID", id, out error);
            return error;
        }

        public int SaveSendRecord(SendCoupon item)
        {
            return Dal.Submit(item);
        }

        public bool Send(string id, out string err)
        {
            CouponRule cr = null;
            err = string.Empty;
            bool isSuccess = false;
            SendCoupon s = GetSendReordeEntity(id);
            if (s == null)
            {
                err = "没找到对应的发放规则";
            }
            else if (string.IsNullOrWhiteSpace(s.CouponID))
            {
                err = "请选择要发放的优惠券";
            }
            else if (!CheckValid(new List<string>() { s.CouponID }))
            {
                err = "要发放的优惠券已经过期了";
            }
            else if (s.Status == DjStatus.生效)
            {
                err = "当前优惠券已经发放过了";
            }
            else if (s.SendCount < 1)
            {
                err = "发放个数必须大于0";
            }
            else
            {
                cr = GetEntity(s.CouponID);
                string[] userId = null;
                WhereClip where = ManagerUserInfo._.IsManager == false && ManagerUserInfo._.Status == (int)UserStatus.正常;
                switch (s.SendType)
                {
                    case SendCouponType.全员发放:
                        //获取人员
                        userId = Dal.From<ManagerUserInfo>().Where(where).Select(ManagerUserInfo._.ID)
                            .ToSinglePropertyArray();
                        break;
                    case SendCouponType.用户等级:
                        if (string.IsNullOrEmpty(s.AccountOrder))
                        {
                            err = "会员等级不能为空";
                        }
                        else
                        {
                            //获取人员
                            userId = Dal.From<AccountRange>().Where(AccountRange._.RangeID == s.AccountOrder).Select(AccountRange._.AccountID)
                                .ToSinglePropertyArray();
                        }
                        break;
                    case SendCouponType.注册时间:
                        if (!s.StartRegistTime.HasValue && !s.EndRegistTime.HasValue)
                        {
                            err = "注册开始和截止时间必须提供其中一个";
                        }
                        else if (s.StartRegistTime.HasValue && s.EndRegistTime.HasValue && s.EndRegistTime < s.StartRegistTime)
                        {
                            err = "注册开截止时间必须大于开始时间";
                        }
                        else
                        {
                            if (s.StartRegistTime.HasValue)
                            {
                                where = where && ManagerUserInfo._.CreateDate >= s.StartRegistTime.Value.Date;
                            }
                            if (s.EndRegistTime.HasValue)
                            {
                                where = where && ManagerUserInfo._.CreateDate < s.EndRegistTime.Value.Date.AddDays(1);
                            }
                            //获取人员
                            userId = Dal.From<ManagerUserInfo>().Where(where).Select(ManagerUserInfo._.ID)
                                .ToSinglePropertyArray();
                        }
                        break;
                    case SendCouponType.购买次数:
                        if (s.MaxBuyCount == 0 && s.MinBuyCount == 0)
                        {
                            err = "最少和最多购买次数必须提供其中一个";
                        }
                        else if (s.MaxBuyCount > 0 && s.MinBuyCount > 0 && s.MaxBuyCount < s.MinBuyCount)
                        {
                            err = "最多购买次数必须大于最少购买次数";
                        }
                        else
                        {
                            DataTable dt = Dal.From<ShopOrder>().Where(ShopOrder._.OrderStatus != (int)OrderStatus.拒收 && ShopOrder._.OrderStatus != (int)OrderStatus.取消订单 && ShopOrder._.OrderStatus != (int)OrderStatus.商家已收货等待退款 && ShopOrder._.OrderStatus != (int)OrderStatus.退货取货中 && ShopOrder._.OrderStatus != (int)OrderStatus.退货完成 && ShopOrder._.OrderStatus != (int)OrderStatus.作废).GroupBy(ShopOrder._.MemberID).Select(ShopOrder._.MemberID, ShopOrder._.ID.Count().Alias("orderCount"))
                                  .ToDataTable();
                            string whereStr = string.Empty;
                            if (s.MinBuyCount > 0)
                            {
                                whereStr = " orderCount>=" + s.MinBuyCount;
                            }
                            if (s.MaxBuyCount > 0)
                            {
                                if (whereStr.Length > 0)
                                {
                                    whereStr += " and ";
                                }
                                whereStr = " orderCount<=" + s.MaxBuyCount;
                            }
                            userId = dt.Select(whereStr).AsQueryable().Select(d => d.Field<string>("MemberID")).ToArray();
                        }
                        break;
                    default:
                        break;
                }
                if (string.IsNullOrWhiteSpace(err))
                {
                    if (userId == null || userId.Length == 0)
                    {
                        err = "未找到符合条件的会员";
                    }
                    else
                    {
                        List<BaseEntity> saveList = new List<BaseEntity>();
                        foreach (var item in userId)
                        {
                            CusomerAndCoupon action = new CusomerAndCoupon()
                                    {

                                        ID = Guid.NewGuid().ToString(),
                                        Code = GetMaxNo(cr.PreName ?? "Q"),
                                        CustomerID = item,
                                        CouponID = cr.ID,
                                        HaveCount = s.SendCount,
                                        HasDate = DateTime.Now,
                                        CardValue = cr.JE,
                                        EndDate = cr.EndDate,
                                        HaveType = RuleType.系统派送,
                                        SendID = id
                                    };
                            saveList.Add(action);
                        }
                        s.Status = DjStatus.生效;
                        saveList.Add(s);
                        SessionFactory dal = null;
                        IDbTransaction tr = Dal.BeginTransaction(out dal);
                        try
                        {
                            dal.SubmitNew(tr, ref dal, saveList);
                            dal.CommitTransaction(tr);
                            isSuccess = true;
                        }
                        catch (Exception)
                        {
                            dal.RollbackTransaction(tr);
                            throw;
                        }
                    }
                }
            }
            return isSuccess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="status">  1未使用 2 已使用 3 已过期 </param>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public DataTable GetMyCoupon(string host, string status, int pageIndex, string accountID)
        {
            int reocrdCount = 0;
            UpdateCoupon();
            if (status != "2")
            {


                DataTable dt = Dal.From<CusomerAndCoupon>().Join<CouponRule>(CouponRule._.ID == CusomerAndCoupon._.CouponID)
                       .Where(CusomerAndCoupon._.CustomerID == accountID).Select(
                       CusomerAndCoupon._.ID, CusomerAndCoupon._.CouponID, CusomerAndCoupon._.HaveCount, CusomerAndCoupon._.IsOutDate,
                       CusomerAndCoupon._.HasDate, CusomerAndCoupon._.EndDate, CusomerAndCoupon._.CardValue, CouponRule._.Name
                       ).OrderBy(CusomerAndCoupon._.HasDate).ToDataTable(20, pageIndex, ref reocrdCount, ref reocrdCount);
                if (status == "1")
                {
                    //未过期
                    return dt.Select("IsOutDate=0").CopyToDataTable();
                }
                else if (status == "3")
                {
                    //已过期
                    DataRow[] drs = dt.Select("IsOutDate=1");
                    if (drs.Length > 0)
                    {
                        return drs.CopyToDataTable();
                    }
                    else
                    {
                        return dt.Clone();
                    }
                }
                else if (status == "0")
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                //已使用
                return Dal.From<JFHistory>().Join<CusomerAndCoupon>(CusomerAndCoupon._.ID == JFHistory._.UserCouponID)
                        .Join<CouponRule>(CouponRule._.ID == CusomerAndCoupon._.CouponID)
                        .Where(JFHistory._.MemberID == accountID && JFHistory._.FX == (int)AddOrRemove.减少).Select(
                         JFHistory._.UserCouponID.Alias("ID"), JFHistory._.CouponID,
                         JFHistory._.JFCount.Alias("HaveCount"), CusomerAndCoupon._.IsOutDate,
                          CusomerAndCoupon._.HasDate, CusomerAndCoupon._.EndDate, CusomerAndCoupon._.CardValue,
                          CouponRule._.Name, JFHistory._.CreateDate).OrderBy(JFHistory._.CreateDate).ToDataTable(20, pageIndex, ref reocrdCount, ref reocrdCount);
            }
        }


    }


}
