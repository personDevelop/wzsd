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
                return Dal.From<CouponRule>().Select(CouponRule._.ID, CouponRule._.Name).OrderBy(CouponRule._.CreateDate.Desc)

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
                return Dal.From<CouponRule>().Select(CouponRule._.ID, CouponRule._.Name).OrderBy(CouponRule._.CreateDate.Desc)

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
                .OrderBy(CouponRule._.StartDate)
                .List<CouponAccount>();
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
    }


}
