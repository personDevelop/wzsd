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

            int i = Dal.Delete<ShopPromotion>(id);
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除促销活动";
            }
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
                .Join<RedeemRules>(ShopPromotion._.RuleID == RedeemRules._.ID)
                .Select(ShopPromotion._.ID.All, RedeemRules._.Name.Alias("RuleName"))
                .OrderBy(ShopPromotion._.StartDate.Desc)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public ShopPromotion GetEntity(string id)
        {

            return Dal.Find<ShopPromotion>(id);
        }





        public List<ShopPromotionSimpal> GetValidPromotionList(List<OrderItem> orderItemlist, string accuontID)
        {
            List<ShopPromotionSimpal> result = new List<ShopPromotionSimpal>();
            UpdatePromotion();
            List<string> productIdList = orderItemlist.Select(p => p.ProductID).ToList();
            //获取当前时间所有可用的促销活动
            List<ShopPromotion> list = Dal.From<ShopPromotion>()

                .Join<RedeemRules>(ShopPromotion._.RuleID == RedeemRules._.ID)
                .Join<ParameterInfo>(RedeemRules._.RuleType == ParameterInfo._.ID)
                .Where(ShopPromotion._.IsEnable == true && RedeemRules._.IsEnable == true && ParameterInfo._.IsEnable == true
                && ShopPromotion._.StartDate < DateTime.Now)
                .Select(ShopPromotion._.ID.All, RedeemRules._.Name.Alias("RuleName"), ParameterInfo._.Code.Alias("RuleTypeCode"), ParameterInfo._.Name.Alias("RuleTypeName"))

                .List<ShopPromotion>();
            bool? IsFirst = null;
            foreach (ShopPromotion item in list)
            {
                if (item.RuleTypeName.StartsWith("注册"))
                {
                    continue;

                }
                if (item.RuleTypeName.StartsWith("首单"))
                {
                    if (IsFirst == null)
                    {
                        bool isHave = Dal.Exists<ShopOrder>(ShopOrder._.MemberID == accuontID);
                        IsFirst = isHave == false;
                    }
                    if (!IsFirst.Value)
                    {
                        continue;
                    }
                }
                if (!string.IsNullOrWhiteSpace(item.BuySKUID))
                {  //先检测 SKU
                    if (orderItemlist.Exists(p => p.Sku == item.BuySKUID))
                    {
                        //包含该种商品
                        foreach (OrderItem order in orderItemlist.Where(p => p.Sku == item.BuySKUID))
                        {
                            if ((order.BuyCount < item.BuyCount && item.BuyCount > 0) ||
                               (order.BuyCount * order.SalePrice < item.MinPrice && item.MinPrice > 0))
                            {

                            }
                            else
                            { //满足
                                order.AddPromotion(item);
                            }

                        }
                    }
                    else
                    { continue; }


                }
                else
                    if (!string.IsNullOrWhiteSpace(item.BuyProductId))
                    {
                        //检测商品
                        if (orderItemlist.Exists(p => p.ProductID == item.BuyProductId))
                        {
                            //包含该种商品
                            foreach (OrderItem order in orderItemlist.Where(p => p.ProductID == item.BuyProductId))
                            {
                                if ((order.BuyCount < item.BuyCount && item.BuyCount > 0) ||
                                 (order.BuyCount * order.SalePrice < item.MinPrice && item.MinPrice > 0))
                                {

                                }
                                else
                                    order.AddPromotion(item);

                            }
                        }
                        else
                        { continue; }
                    }

                    else
                        if (!string.IsNullOrWhiteSpace(item.BuyCategoryId))
                        {
                            //检测分类
                            string[] products = Dal.From<ShopProductCategory>().Where(ShopProductCategory._.CategoryID == item.BuyCategoryId
                                   && ShopProductCategory._.ProductID.In(productIdList)).Select(ShopProductCategory._.ProductID).ToSinglePropertyArray();
                            if (products != null && products.Length > 0)
                            {

                                foreach (OrderItem order in orderItemlist.Where(p => products.Contains(p.ProductID)))
                                {
                                    if ((order.BuyCount < item.BuyCount && item.BuyCount > 0) ||
                                        (order.BuyCount * order.SalePrice < item.MinPrice && item.MinPrice > 0))
                                    {

                                    }
                                    else
                                        order.AddPromotion(item);

                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            //适合所有商品的促销活动,这个算在总订单里
                            //包含该种商品
                            //计算总个数 和总金额
                            decimal totalPrice = orderItemlist.Sum(p => p.SalePrice);
                            decimal totalCount = orderItemlist.Sum(p => p.BuyCount);



                            if ((totalCount < item.BuyCount && item.BuyCount > 0) ||
                                      (totalPrice < item.MinPrice && item.MinPrice > 0))
                            {

                            }
                            else
                                result.Add(new ShopPromotionSimpal() { ID = item.ID, Name = item.RuleName, HandsaleProductName = item.HandProductName, HandsaleCouponName = item.CouponName });


                        }

            }


            return result;
        }

        private void UpdatePromotion()
        {
            //先更新过期日期小于今天的为无效
            ShopPromotion updatePromotion = new ShopPromotion() { RecordStatus = StatusType.update, ActionStatus = (int)ValidEnum.无效 };
            updatePromotion.Where = ShopPromotion._.EndDate < DateTime.Now;
            Dal.Submit(updatePromotion);
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
