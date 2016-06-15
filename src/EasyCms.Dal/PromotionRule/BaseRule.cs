using EasyCms.Model;
using Sharp.Common;
using Sharp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCms.Dal.PromotionRule
{
    public class BaseRule
    {
        public object Context { get; set; }

        public ManagerUserInfo UserInfo { get; set; }


        public object OtherPara { get; set; }
        public object OtherPara2 { get; set; }
        
        public object ReturnResult { get; set; }

        public bool Run(ActionPlatform plat, ActionEvent actionevent)
        {
            switch (actionevent)
            {
                case ActionEvent.注册:
                case ActionEvent.评价:
                case ActionEvent.评论:
                    return RunRegist(plat, actionevent);

                case ActionEvent.购物:
                case ActionEvent.首单:
                    return RunBuy(plat, actionevent);
                default:
                    break;
            }
            return true;
        }
        protected bool RunBuy(ActionPlatform plat, ActionEvent actionevent)
        {
            Sharp.Data.SessionFactory Dal = Sharp.Data.SessionFactory.Default;
            ShopOrder order = Context as ShopOrder;
            List<ShopPromotionSimpal> promotionUseList = OtherPara as List<ShopPromotionSimpal>;
             
            List<ShopPromotion> list = new ShopPromotionDal().GetValidPromotionList(plat, actionevent);
            
            List<BaseEntity> tempList = OtherPara2 as List<BaseEntity>;
            List<ShopOrderItem> handsales =new  List<ShopOrderItem>();
            foreach (var item in list)
            {
                if (item.ActionPlatform != ActionPlatform.全部 && item.ActionPlatform != plat)
                {
                    continue;
                }

                if (item.ActionEvent == ActionEvent.首单)
                {
                    //判断当前订单是否是首单
                    string oldOrderID = Dal.From<ShopOrder>().Where(ShopOrder._.MemberID == order.MemberID).Select(ShopOrder._.ID).ToScalar() as string;

                    if (string.IsNullOrWhiteSpace(oldOrderID))
                    {

                    }
                    else
                    {
                        continue;
                    }
                }
                if (promotionUseList != null && !promotionUseList.Exists(p=>p.ID==item.ID) )
                {
                    continue;
                }
                JFHistory jf = new JFHistory()
                {
                    ID = Guid.NewGuid().ToString(),
                    ActivityID = order.OrderResId,
                    CreateDate = DateTime.Now,
                    FX = AddOrRemove.增加,
                    JFCount = item.HandsaleCount,
                    JFSouce = (RuleType)((int)item.ActionEvent),
                    JFSouceMainID = order.ID,
                    JFState = JFStatus.在途,
                    JFSouceSubID = "",
                    JFType = item.ActionType,
                    MemberID = order.MemberID,
                    Remark = plat.ToString() + actionevent + item.ActionType,

                };
                tempList.Add(jf);
                AccountRange ar = null;
                switch (item.ActionType)
                {
                    case ActionType.优惠券:
                        jf.CouponID = item.CouponID;
                        CouponRule cr = new CouponRuleDal().GetSimpleEntity(item.CouponID);
                        CusomerAndCoupon cc = new CusomerAndCoupon()
                        {

                            ID = Guid.NewGuid().ToString(),
                            CardPwd = string.Empty,
                            Code = new BaseManager().GetMaxNo(string.IsNullOrWhiteSpace(cr.PreName) ? "Q" : cr.PreName),
                            CouponID = item.CouponID,
                            CustomerID = UserInfo.ID,
                            HasDate = DateTime.Now,
                            HaveCount = Convert.ToInt32(item.HandsaleCount),
                            EndDate = null,
                            HaveType = jf.JFSouce,
                            IsOutDate = false,
                            CardValue = cr.JE,
                        };
                        cr.SendCount += cc.HaveCount;
                        if (cr.MaxCount > 0 && cr.SendCount >= cr.MaxCount)
                        {
                            cr.Status = 1;
                        }
                        jf.UserCouponID = cc.ID;
                        if (cr.IsCongZengSongKaiShi)
                        {
                            cc.EndDate = cc.HasDate.AddDays(cr.QXTS);
                        }
                        else
                        {
                            cc.EndDate = cc.EndDate;
                        }
                        cr.SendCount += cc.HaveCount;
                        if (cr.MaxCount > 0 && cr.SendCount >= cr.MaxCount)
                        {
                            cr.Status = 1;
                            cc.IsOutDate = true;
                        }
                        if (cr.EndDate.HasValue && cr.EndDate.Value < DateTime.Now)
                        {
                            cr.Status = 1;
                            cc.IsOutDate = true;
                        }
                        if (cc.EndDate < DateTime.Now)
                        {
                            cc.IsOutDate = true;
                        }
                        tempList.Add(cc);
                        tempList.Add(cr);
                        break;
                    case ActionType.积分:
                        ar = new AccountRange() { Where = AccountRange._.AccountID == UserInfo.ID, RecordStatus = StatusType.update };
                        ExpressionClip JF = new ExpressionClip("JF+@JF");
                        JF.Parameters.Add("JF", item.HandsaleCount);
                        ar.SetModifiedProperty(AccountRange._.JF, JF);
                        tempList.Add(ar);
                        break;
                    case ActionType.现金:

                        decimal blacnse = Convert.ToDecimal(Dal.From<ManagerUserInfo>().Where(ManagerUserInfo._.ID == UserInfo.ID).Select(ManagerUserInfo._.Balance).ToScalar());
                        UserInfo.Balance += item.HandsaleCount;
                       
                        AccuontMoneyLog ml = new AccuontMoneyLog()
                        {
                            Amount = item.HandsaleCount,
                            Balance = UserInfo.Balance,
                            ID = Guid.NewGuid().ToString(),
                            Note = plat.ToString() + actionevent + item.ActionType,
                            OpMoneyEvent = OpEvent.充值,
                            OpStatus = OpStatus.成功,
                            OpTime = DateTime.Now,
                            OpType = AddOrRemove.增加,
                            OpUserID = UserInfo.ID,
                            UserID = UserInfo.ID
                        };
                        tempList.Add(ml);
                        tempList.Add(UserInfo);
                        break;
                    case ActionType.经验值:
                        ar = new AccountRange() { Where = AccountRange._.AccountID == UserInfo.ID, RecordStatus = StatusType.update };
                        ExpressionClip GrowthValue = new ExpressionClip("GrowthValue+@GrowthValue");
                        GrowthValue.Parameters.Add("GrowthValue", item.HandsaleCount);
                        ar.SetModifiedProperty(AccountRange._.GrowthValue, GrowthValue);
                        tempList.Add(ar);
                        break;
                    case ActionType.商品:

                        if (!string.IsNullOrWhiteSpace(item.HandsaleProductId))
                        { 
                            View_ProductInfoBySkuid handproduct = Dal.From<View_ProductInfoBySkuid>().Join<ShopBrandInfo>(View_ProductInfoBySkuid._.BrandId == ShopBrandInfo._.ID, JoinType.leftJoin)
           .Join<ShopProductType>(View_ProductInfoBySkuid._.TypeId == ShopProductType._.ID, JoinType.leftJoin)
           .Join<AttachFile>(View_ProductInfoBySkuid._.ID == AttachFile._.RefID, JoinType.leftJoin)
       .Select(View_ProductInfoBySkuid._.ID.All, ShopBrandInfo._.Name.Alias("BrandName"), ShopProductType._.Name.Alias("ProductTypeName"),
       AttachFile.GetThumbnaifilePath("")).Where(View_ProductInfoBySkuid._.ID == item.HandsaleProductId && View_ProductInfoBySkuid._.SKUID == item.HandsaleProductSKUID
       ).ToFirst<View_ProductInfoBySkuid>();

                            ShopOrderItem handSaile = new ShopOrderItem()
                            {
                                ID = Guid.NewGuid().ToString(),
                                OrderID = order.ID,
                                ProductID = item.HandsaleProductId,
                                ProductSKU = item.HandsaleProductSKUID,
                                ProductType = handproduct.TypeId,
                                ProductCode = handproduct.Code,
                                ProductName = handproduct.Name,
                                AttributeVal = handproduct.SKUName,
                                ProductThumb = handproduct.FilePath,
                                Unit = handproduct.Unit,
                                Count = item.HandsaleCount,
                                IsHandsel = true,
                                HandselCount = 0,
                                ProductTypeName = handproduct.ProductTypeName,
                                BrandName = handproduct.BrandName,
                                ShortDescription = handproduct.ShortDescription,
                                Weight = handproduct.Weight,
                                IsVirtualProduct = handproduct.IsVirtualProduct
                            };
                            handsales.Add(handSaile); 
                        }
                        break;

                    case ActionType.打折扣:
                        //这个不合适，可以在订单的价格上修改，这个后续再说
                        break;
                    case ActionType.免运费:
                          order.Freight = 0;
                        break;
                    default:
                        break;
                }

            }



            ReturnResult = handsales;
            return true;
        }

        public bool RunRegist(ActionPlatform plat, ActionEvent actionevent)
        {
            List<BaseEntity> tempList = new List<BaseEntity>();
            List<ShopPromotion> list = new ShopPromotionDal().GetValidPromotionList(plat, actionevent);

            foreach (var item in list)
            {
                if (item.ActionPlatform != ActionPlatform.全部 && item.ActionPlatform != plat)
                {
                    continue;
                }
                JFHistory jf = new JFHistory()
                {
                    ID = Guid.NewGuid().ToString(),
                    ActivityID = "",
                    CreateDate = DateTime.Now,
                    FX = AddOrRemove.增加,
                    JFCount = item.HandsaleCount,
                    JFSouce = (RuleType)((int)item.ActionEvent),
                    JFSouceMainID = UserInfo.ID,
                    JFState = JFStatus.完成,
                    JFSouceSubID = "",
                    JFType = item.ActionType,
                    MemberID = UserInfo.ID,
                    Remark = plat.ToString() + actionevent + item.ActionType,

                };
                tempList.Add(jf);
                AccountRange ar = null;
                switch (item.ActionType)
                {
                    case ActionType.优惠券:
                        jf.CouponID = item.CouponID;
                        CouponRule cr = new CouponRuleDal().GetSimpleEntity(item.CouponID);
                        CusomerAndCoupon cc = new CusomerAndCoupon()
                        {

                            ID = Guid.NewGuid().ToString(),
                            CardPwd = string.Empty,
                            Code = new BaseManager().GetMaxNo(string.IsNullOrWhiteSpace(cr.PreName) ? "Q" : cr.PreName),
                            CouponID = item.CouponID,
                            CustomerID = UserInfo.ID,
                            HasDate = DateTime.Now,
                            HaveCount = Convert.ToInt32(item.HandsaleCount),
                            EndDate = null,
                            HaveType = jf.JFSouce,
                            IsOutDate = false,
                            CardValue = cr.JE,
                        };
                        cr.SendCount += cc.HaveCount;
                        if (cr.MaxCount > 0 && cr.SendCount >= cr.MaxCount)
                        {
                            cr.Status = 1;
                        }
                        jf.UserCouponID = cc.ID;
                        if (cr.IsCongZengSongKaiShi)
                        {
                            cc.EndDate = cc.HasDate.AddDays(cr.QXTS);
                        }
                        else
                        {
                            cc.EndDate = cc.EndDate;
                        }
                        cr.SendCount += cc.HaveCount;
                        if (cr.MaxCount > 0 && cr.SendCount >= cr.MaxCount)
                        {
                            cr.Status = 1;
                            cc.IsOutDate = true;
                        }
                        if (cr.EndDate.HasValue && cr.EndDate.Value < DateTime.Now)
                        {
                            cr.Status = 1;
                            cc.IsOutDate = true;
                        }
                        if (cc.EndDate < DateTime.Now)
                        {
                            cc.IsOutDate = true;
                        }
                        tempList.Add(cc);
                        tempList.Add(cr);
                        break;
                    case ActionType.积分:
                        ar = new AccountRange() { Where = AccountRange._.AccountID == UserInfo.ID, RecordStatus = StatusType.update };
                        ExpressionClip JF = new ExpressionClip("JF+@JF");
                        JF.Parameters.Add("JF", item.HandsaleCount);
                        ar.SetModifiedProperty(AccountRange._.JF, JF);
                        tempList.Add(ar);
                        break;
                    case ActionType.现金:

                        decimal blacnse = Convert.ToDecimal(Sharp.Data.SessionFactory.Default.From<ManagerUserInfo>().Where(ManagerUserInfo._.ID == UserInfo.ID).Select(ManagerUserInfo._.Balance).ToScalar());
                        UserInfo.Balance += item.HandsaleCount;
                        AccuontMoneyLog ml = new AccuontMoneyLog()
                        {
                            Amount = item.HandsaleCount,
                            Balance = UserInfo.Balance,
                            ID = Guid.NewGuid().ToString(),
                            Note = plat.ToString() + actionevent + item.ActionType,
                            OpMoneyEvent = OpEvent.充值,
                            OpStatus = OpStatus.成功,
                            OpTime = DateTime.Now,
                            OpType = AddOrRemove.增加,
                            OpUserID = UserInfo.ID,
                            UserID = UserInfo.ID
                        };
                        tempList.Add(ml);
                        tempList.Add(UserInfo);
                        break;
                    case ActionType.经验值:
                        ar = new AccountRange() { Where = AccountRange._.AccountID == UserInfo.ID, RecordStatus = StatusType.update };
                        ExpressionClip GrowthValue = new ExpressionClip("GrowthValue+@GrowthValue");
                        GrowthValue.Parameters.Add("GrowthValue", item.HandsaleCount);
                        ar.SetModifiedProperty(AccountRange._.GrowthValue, GrowthValue);
                        tempList.Add(ar);
                        break;
                    case ActionType.商品:
                    case ActionType.打折扣:
                    case ActionType.免运费:
                    default:
                        break;
                }
            }
            Sharp.Data.SessionFactory.Default.Submit(tempList);
            return true;

        }

        public List<ShopPromotionSimpal> GetValidPromotionList(ActionPlatform plat, ActionEvent actionevent)
        {
            SessionFactory Dal = new BaseManager().Dal;
            List<BaseEntity> tempList = new List<BaseEntity>();
            List<ShopPromotionSimpal> result = new List<ShopPromotionSimpal>();
            ShopOrderModel  order = Context as ShopOrderModel;
            List<ShopPromotion> list = new ShopPromotionDal().GetValidPromotionList(plat, actionevent);
            List<ShopPromotion> ShopPromotionlist = new List<ShopPromotion>();
            foreach (var item in list)
            {
                bool isFixed = false;
                #region 基本过滤
                if (item.HandsaleCount <= 0)
                {
                    continue;
                }
                if (item.ActionPlatform != ActionPlatform.全部 && item.ActionPlatform != plat)
                {
                    continue;
                }
                if (item.ActionEvent == ActionEvent.首单)
                {
                    //判断当前订单是否是首单
                    string oldOrderID = Sharp.Data.SessionFactory.Default.From<ShopOrder>().Where(ShopOrder._.MemberID == UserInfo.ID).Select(ShopOrder._.ID).ToScalar() as string;

                    if (string.IsNullOrWhiteSpace(oldOrderID))
                    {
                        isFixed = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (item.HandsaleMaxCount > 0 && (item.HandsaleMaxCount - item.HasSendCount) <item.HandsaleCount)
                {

                    item.ActionStatus = AcitivyStatus.完成;
                    tempList.Add(item);
                    continue;

                }
                #endregion
               
                if (!isFixed && string.IsNullOrWhiteSpace(item.BuySKUID)&& string.IsNullOrWhiteSpace(item.BuyProductId) && string.IsNullOrWhiteSpace(item.BuyCategoryId))
                {
                    if (item.HandsaleMaxCount > 0 && (item.HandsaleMaxCount - item.HasSendCount) < item.HandsaleCount)
                    {

                        item.ActionStatus = AcitivyStatus.完成;
                        tempList.Add(item);
                        continue;

                    }
                     
                    isFixed = true;
                }
                #region 商品过滤
                if (!string.IsNullOrWhiteSpace(item.BuySKUID))
                {
                    if (!order.OrderItems.Exists(p => p.Sku == item.BuySKUID))
                    {
                        continue;
                    }
                    IEnumerable<OrderItem> ielist = order.OrderItems.Where(p => p.Sku == item.BuySKUID);
                    foreach (OrderItem orderitem in ielist)
                    {
                        if ((orderitem.BuyCount < item.BuyCount && item.BuyCount > 0) ||
                           (orderitem.BuyCount * orderitem.SalePrice < item.MinPrice && item.MinPrice > 0))
                        {

                        }
                        else
                        {
                            isFixed = true;
                            break;
                        }

                    }
                }


                if (!isFixed && !string.IsNullOrWhiteSpace(item.BuyProductId))
                {
                    if (!order.OrderItems.Exists(p => p.ProductID == item.BuyProductId))
                    {
                        continue;
                    }
                    IEnumerable<OrderItem> ielist = order.OrderItems.Where(p => p.ProductID == item.BuyProductId);
                    //包含该种商品
                    foreach (OrderItem orderitem in ielist)
                    {
                        if ((orderitem.BuyCount < item.BuyCount && item.BuyCount > 0) ||
                         (orderitem.BuyCount * orderitem.SalePrice < item.MinPrice && item.MinPrice > 0))
                        {

                        }
                        else
                        {
                            isFixed = true;
                            break;
                        }
                    }
                }

                if (!isFixed && !string.IsNullOrWhiteSpace(item.BuyCategoryId))
                {
                    //检测分类
                    List<string> productIdList = order.OrderItems.Select(p => p.ProductID).ToList();
                    string classcode = Dal.From<ShopCategory>().Where(ShopCategory._.ID == item.BuyCategoryId
                          ).Select(ShopCategory._.ClassCode).ToScalar() as string;
                    string[] categoryProductids = Dal.From<ShopCategory>().Join<ShopProductCategory>(ShopCategory._.ID == ShopProductCategory._.CategoryID)


                          .Where(ShopCategory._.ClassCode.StartsWith(classcode) && ShopProductCategory._.ProductID.In(productIdList)).Select(ShopCategory._.ID).ToSinglePropertyArray();
                    if (categoryProductids != null && categoryProductids.Length > 0)
                    {


                        IEnumerable<OrderItem> ielist = order.OrderItems.Where(p => p.ProductID == item.BuyProductId);
                        //包含该种商品
                        foreach (OrderItem orderitem in ielist)
                        {
                            if (categoryProductids.Contains(orderitem.ProductID))
                            {
                                if ((orderitem.BuyCount < item.BuyCount && item.BuyCount > 0) ||
                               (orderitem.BuyCount * orderitem.SalePrice < item.MinPrice && item.MinPrice > 0))
                                {

                                }
                                {
                                    isFixed = true;
                                    break;
                                }
                            }


                        }
                    }
                    else
                    {
                        continue;
                    }

                }
                #endregion
                if (isFixed)
                {
                    ShopPromotionlist.Add(item);
                }
            }
            foreach (var item in ShopPromotionlist)
            {
                #region MyRegion
                switch (item.ActionType)
                {
                    case ActionType.优惠券:
                        if (!string.IsNullOrWhiteSpace(item.CouponID))
                        {
                            CouponRule cr = new CouponRuleDal().GetSimpleEntity(item.CouponID);
                            result.Add(new ShopPromotionSimpal() { ID = item.ID, HandsaleCouponName = cr.Name, Name = "【送优惠券】："   + cr.Name+item.HandsaleCount+"张" });
                        }
                        break;
                    case ActionType.积分:
                        result.Add(new ShopPromotionSimpal() { ID = item.ID, Name = "【送积分】：" + item.HandsaleCount  });
                        break;
                    case ActionType.现金:
                        result.Add(new ShopPromotionSimpal() { ID = item.ID, Name = "【送现金】：" + item.HandsaleCount+"元" });
                        break;
                    case ActionType.经验值:
                        result.Add(new ShopPromotionSimpal() { ID = item.ID, Name = "【送经验值】：" + item.HandsaleCount });
                        break;
                    case ActionType.打折扣:
                        result.Add(new ShopPromotionSimpal() { ID = item.ID, Name = "【赠品】：" +  item.HandsaleCount +"折优惠"});
                        break;
                    case ActionType.商品:
                        if (!string.IsNullOrWhiteSpace(item.HandsaleProductId))
                        {


                            string producntName = Dal.From<ShopProductInfo>().Where(ShopProductInfo._.ID == item.HandsaleProductId).Select(ShopProductInfo._.Name).ToScalar() as string;
                            result.Add(new ShopPromotionSimpal() { ID = item.ID, HandsaleProductName = producntName, Name = "【赠品】："+item.HandsaleCount+"个 " + producntName });
                        }
                        break;
                    case ActionType.免运费:
                        result.Add(new ShopPromotionSimpal() { ID = item.ID, Name = item.ActionType.ToString() });
                        break;
                    default:
                        break;
                }
                #endregion
            }


            return result;
        }


        
    }
}
