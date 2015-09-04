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
    public class ShopOrderDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            ShopOrder order = new ShopOrder();
            order.ID = id;
            order.RecordStatus = StatusType.update;
            order.HasDelete = true;
            int i = Dal.Submit(order);
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除分类";
            }
        }

        public int Save(ShopOrder item)
        {
            return Dal.Submit(item);


        }



        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;

            return Dal.From<ShopOrder>().OrderBy(ShopOrder._.CreateDate.Desc)

                .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public ShopOrder GetEntity(string id)
        {
            return Dal.Find<ShopOrder>(id);

        }




        public ShopOrderModel CreateOrder(ShopOrderModel order, string host, string accuontID, out string err)
        {
            List<OrderItem> list = order.OrderItems;
            err = string.Empty;
            List<OrderItem> listActivty = list.Where(p => p.OrderType > 0 && !string.IsNullOrWhiteSpace(p.OrderResId)).ToList();
            foreach (var item in listActivty)
            {
                //对应参与活动的商品 查看其是否已过期,后续做完商品促销活动后再补充
                throw new Exception("还没有设置团购功能");
            }
            //获取商品较详细信息 
            GetProductWithOrder(order, host, accuontID, out err);

            return order;

        }
        /// <summary>
        /// 检测是否还在
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private ShopOrderModel GetProductWithOrder(ShopOrderModel order, string host, string accuontID, out string err)
        {
            err = string.Empty;
            List<OrderItem> list = order.OrderItems;
            if (list == null || list.Count == 0)
            {
                err = "请选择要购买的商品";
                return null;
            }
            int i = 1;
            List<string> productIdList = list.Select(p => p.ProductID).ToList();

            foreach (var item in list)
            {
                View_ProductInfoBySkuid v = null;
                if (string.IsNullOrWhiteSpace(item.Sku))
                {
                    v = Dal.Find<View_ProductInfoBySkuid>(View_ProductInfoBySkuid._.ID == item.ProductID && View_ProductInfoBySkuid._.IsEnableSku == false);
                }
                else
                {
                    v = Dal.Find<View_ProductInfoBySkuid>(View_ProductInfoBySkuid._.SKUID == item.Sku);
                }
                if (v == null)
                {
                    err = string.Format("您购买的第{0}条商品已下架", i);
                    break;
                }
                if (v.Stock < -10000000)
                {
                    //-10000000是个大约的负数，可以尽量的小
                    //不控制库存
                }
                else if (v.Stock < item.BuyCount)
                {
                    err = string.Format("您购买的第{0}条商品{1}库存{2},不能再购买了", i, v.Name, v.Stock);
                    break;
                }
                if (v.IsEnableSku)
                {
                    if (v.SaleStatus != (int)ShopSaleStatus.上架)
                    {
                        err = string.Format("您购买的第{0}条商品{1}已下架,不能再购买了", i, v.Name);
                        break;
                    }
                }
                else
                {
                    if (!v.IsSale)
                    {
                        err = string.Format("您购买的第{0}条商品{1}已下架,不能再购买了", i, v.Name);
                        break;
                    }
                }
                item.IsVirtualProduct = v.IsVirtualProduct;
                item.ProductName = v.Name;
                if (!string.IsNullOrEmpty(v.SKUName))
                {
                    item.ProductName += "  " + v.SKUName;
                }
                item.SalePrice = v.SalePrice;
                item.MarketPrice = v.MarketPrice;
                if (!string.IsNullOrEmpty(v.SKUCode))
                {
                    item.ProductCode = v.SKUCode;
                }
                else
                {
                    item.ProductCode = v.Code;

                }
                item.Point = (int)v.Points;
                i++;

            }
            //获取默认第一张图片
            List<SimpalFile> fileList = new AttachFileDal().GetFiles(host, productIdList);
            foreach (var item in list)
            {
                SimpalFile sf = fileList.FirstOrDefault(p => p.RefID == item.ProductID);
                if (sf != null)
                {
                    item.ImgPath = sf.WebFilePath;
                }
            }

            //获取可用促销活动

            order.Promotion = new ShopPromotionDal().GetValidPromotionList(list, accuontID);
            //获取可用优惠券
            order.Coupon = new CouponRuleDal().GetValidCouponList(list);
            return order;

        }

        /// <summary>
        /// 提交订单
        /// 根据订单 获取其参与的促销活动信息，优惠券信息，  商品明细， 及商品明细的促销活动信息，及使用的优惠券  计算总价格和订单总额是否一样，如果不一样，则返回客户确认
        /// 开始根据活动规则 拆分订单，拆分原则是 一个营销活动一个订单（比如团购 秒杀）
        /// </summary>
        /// <param name="order"></param>
        /// <param name="accuontID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public string Submit(ShopOrderModel order, ManagerUserInfo accuont, out string err)
        {
            string result = null;
            //先检测商品对不对
            err = string.Empty;
            List<OrderItem> list = order.OrderItems;
            List<BaseEntity> Orderlist = new List<BaseEntity>();
            if (list == null || list.Count == 0)
            {
                err = "请选择要购买的商品";
                return null;
            }
            Dictionary<string, int> activeID = new Dictionary<string, int>();//活动字典，拆分订单使用
            List<string> listPromot = new List<string>();//活动规则ID集合
            List<string> listCoupon = new List<string>();//优惠券ID集合
            decimal productPrice = 0;
            decimal CouponPrice = 0;
            #region 检测促销活动是否过期

            foreach (OrderItem item in list)
            {
                productPrice += item.SalePrice * item.BuyCount;
                if (!activeID.ContainsKey(item.OrderResId))
                {
                    activeID.Add(item.OrderResId, item.OrderType);
                }
                if (item.Coupon != null)
                {
                    foreach (var promot in item.Coupon)
                    {
                        //检测促销活动是否过期

                        if (!listCoupon.Contains(promot.ID))
                        {
                            listCoupon.Add(promot.ID);
                        }
                        decimal value = promot.CardValue * promot.UsingCount;
                        //检测是否有超过使用比例,由于表结构没有支持该功能，暂时不实现了
                        //if (true)
                        //{

                        //}
                        CouponPrice += value;
                        CusomerAndCoupon upcoupon = new CusomerAndCoupon() { RecordStatus = StatusType.update, Where = CusomerAndCoupon._.ID == promot.ID };
                        ExpressionClip HaveCount = new ExpressionClip("HaveCount-@HaveCount");
                        HaveCount.Parameters.Add("HaveCount", promot.UsingCount);
                        upcoupon.SetModifiedProperties(CusomerAndCoupon._.HaveCount, HaveCount); 
                        ExpressionClip UsedCount = new ExpressionClip("UsedCount+@UsedCount");
                        HaveCount.Parameters.Add("UsedCount", promot.UsingCount);
                        upcoupon.SetModifiedProperties(CusomerAndCoupon._.UsedCount, UsedCount);
                        Orderlist.Add(upcoupon);
                    }
                }
                if (item.Promotion != null)
                {

                    foreach (var promot in item.Promotion)
                    {
                        //检测促销活动是否过期
                        if (!listPromot.Contains(promot.ID))
                        {
                            listPromot.Add(promot.ID);
                        }
                    }
                }
            }
            if (order.Promotion != null)
            {
                foreach (var promot in order.Promotion)
                {
                    //检测促销活动是否过期
                    if (!listPromot.Contains(promot.ID))
                    {
                        listPromot.Add(promot.ID);
                    }
                }
            }
            if (listPromot.Count > 0)
            {
                bool IsValue = new ShopPromotionDal().CheckValid(listPromot);
                if (!IsValue)
                {
                    err = "您选择的促销活动已过期,请返回购物车重新选购商品";
                    return null;
                }

            }
            #endregion


            #region 检测优惠券是否过期 并计算优惠券总额

            if (order.Coupon != null)
            {
                foreach (var promot in order.Coupon)
                {
                    //检测促销活动是否过期
                    if (!listCoupon.Contains(promot.ID))
                    {
                        listCoupon.Add(promot.ID);
                    }
                    decimal value = promot.CardValue * promot.UsingCount;
                    //检测是否有超过使用比例,由于表结构没有支持该功能，暂时不实现了
                    //if (true)
                    //{

                    //}
                    CouponPrice += value;
                }
            }
            if (listCoupon.Count > 0)
            {
                bool IsValue = new CouponRuleDal().CheckValid(listCoupon);
                if (!IsValue)
                {
                    err = "您选择的优惠券已过期或余额不足,请返回购物车重新选购商品";
                    return null;
                }
            }
            #endregion

            //开始计算订单总额  总额计算方式是，商品总额-优惠券总额+运费
            decimal totalPrice = productPrice + order.Freight - CouponPrice;
            if (totalPrice != order.TotalPrice)
            {
                err = "订单的金额和实际的金额不符,请重新选择本次购物要使用的优惠券";
                return null;
            }

            string orderNum = GetMaxNo("HQ");
            DateTime now = DateTime.Now;
            //开始判断是否拆单
            bool IsCf = activeID.Count > 1;
            int OrderCount = 1;
            //先获取所有商品
            WhereClip where = View_ProductInfoBySkuid._.ID.In(list.Select(p => p.ProductID).ToArray());
            List<View_ProductInfoBySkuid> productList = Dal.From<View_ProductInfoBySkuid>().Join<ShopBrandInfo>(View_ProductInfoBySkuid._.BrandId == ShopBrandInfo._.ID, JoinType.leftJoin)
                     .Join<ShopProductType>(View_ProductInfoBySkuid._.TypeId == ShopProductType._.ID)
                     .Join<AttachFile>(View_ProductInfoBySkuid._.ID == AttachFile._.RefID, JoinType.leftJoin)
                 .Select(View_ProductInfoBySkuid._.ID.All, ShopBrandInfo._.Name.Alias("BrandName"), ShopProductType._.Name.Alias("ProductTypeName"),
                 AttachFile.GetFilePath("")).Where(where
                 ).List<View_ProductInfoBySkuid>();
            //拆分成多个订单( 不用管是否是虚拟产品，这个再前台判断) 
            bool? IsFirst = null;
            foreach (var item in activeID)
            {
                ShopOrder realOrder = new ShopOrder()
                {
                    ID = (OrderCount.ToString()).PadLeft(2, '0'),
                    OrderType = item.Value,
                    OrderResId = item.Key,
                    MemberID = accuont.ID,
                    MemberName = accuont.Name,
                    MemberEmail = accuont.Email,
                    MemberCallPhone = accuont.ContactPhone,
                    RegionID = order.AddressID,
                    PayTypeID = order.PayTypeID,
                    PayTypeName = new ShopPaymentTypesDal().GetPayTypeName(order.PayTypeID, order.CashOnDelivery),
                    IsFreeShiping = order.Freight == 0,
                    Freight = order.Freight,
                    FreightAdjust = 0,
                    FreightActual = order.Freight,
                    Remark = order.Remark,
                    IsInvoice = order.IsInvoice,
                    InvoiceInfo = order.InvoiceInfo,
                    CreateDate = now,
                    UpdateDate = now,
                    ClientType = accuont.ClientType,
                    InvoiceNote = order.InvoiceNote
                };
                if (IsCf)
                {
                    realOrder.ID = orderNum + realOrder.ID;
                    realOrder.ParentID = orderNum;

                }
                else
                {
                    realOrder.ID = orderNum;
                    realOrder.ParentID = null;
                }
                if (order.CashOnDelivery)
                {
                    realOrder.ShipStatus = (int)OrderStatus.等待商家发货;
                    realOrder.PayStatus = (int)PayStatus.未付款;
                    realOrder.OrderStatus = (int)OrderStatus.等待商家发货;
                }
                else
                {
                    realOrder.ShipStatus = (int)OrderStatus.等待付款;
                    realOrder.PayStatus = (int)PayStatus.未付款;
                    realOrder.OrderStatus = (int)OrderStatus.等待付款;
                }
                //计算商品明细
                List<OrderItem> OrderResList = list.Where(p => p.OrderResId == item.Key).ToList<OrderItem>();
                int orderItemNum = 1;
                decimal totalCostPrice = 0, totalmarketPrice = 0, totalsalePrice = 0, totalyhqPrice = 0;
                List<ShopOrderItem> handsales = new List<ShopOrderItem>();
                foreach (var productVar in OrderResList)
                {
                    View_ProductInfoBySkuid productItem = productList.FirstOrDefault(p => p.ID == productVar.ProductID && p.SKUID == productVar.Sku);

                    ShopOrderItem product = new ShopOrderItem()
                    {
                        ID = Guid.NewGuid().ToString(),
                        OrderID = realOrder.ID,
                        ProductID = productItem.ID,
                        ProductSKU = productItem.SKUID,
                        ProductType = productItem.TypeId,
                        ProductCode = productItem.Code,
                        ProductName = productItem.Name,
                        AttributeVal = productItem.SKUName,
                        ProductThumb = productItem.FilePath,
                        Unit = productItem.Unit,
                        Count = productVar.BuyCount,
                        IsHandsel = false,
                        HandselCount = 0,
                        ReturnCount = 0,
                        ReturnMoney = 0,
                        UseJf = 0,
                        ProductTypeName = productItem.ProductTypeName,
                        BrandName = productItem.BrandName,
                        ShortDescription = productItem.ShortDescription,
                        Weight = productItem.Weight,
                        IsVirtualProduct = productItem.IsVirtualProduct,
                        Point = productItem.Points

                    };
                    if (productVar.Coupon != null)
                    {
                        product.Preferential = productVar.Coupon.Sum(p => p.CardValue * p.UsingCount);

                    }
                    if (product.Point > 0)
                    {
                        JFHistory jh = new JFHistory()
                        {
                            ID = Guid.NewGuid().ToString(),
                            CreateDate = now,
                            MemberID = accuont.ID,
                            JFType = 0,
                            FX = 0,
                            JFCount = product.Point,
                            JFSouce = JFType.购物.ToString(),
                            JFSouceMainID = realOrder.ID,
                            JFSouceSubID = product.ID,
                            JFState = (int)JFStatus.在途
                        };
                        Orderlist.Add(jh);
                    }

                    IsFirst = CoumputeRule(accuont.ID, Orderlist, now, IsFirst, realOrder, handsales, productVar.Promotion, product.ID);
                    product.CostPrice = productItem.CostPrice;
                    product.MarketPrice = productItem.MarketPrice;
                    product.Price = productItem.SalePrice;
                    totalCostPrice += productItem.CostPrice * product.Count;
                    totalmarketPrice += productItem.MarketPrice * product.Count;
                    totalsalePrice += productItem.SalePrice * product.Count;
                    totalyhqPrice += product.Preferential;
                    product.TotalPrice = product.Price * product.Count - product.Preferential;
                    product.Sequence = orderItemNum;
                    Orderlist.Add(product);
                    orderItemNum++;
                }
                //计算订单促销规则
                IsFirst = CoumputeRule(accuont.ID, Orderlist, now, IsFirst, realOrder, handsales, order.Promotion);
                foreach (var handItem in handsales)
                {
                    handItem.Sequence = orderItemNum++;
                    Orderlist.Add(handItem);
                }
                realOrder.CostPrice = totalCostPrice; //拆分时另算 
                realOrder.Discount = totalyhqPrice;//拆分时另算 
                realOrder.TotalPrice = totalPrice + order.Freight;//拆分时另算 
                realOrder.PayMoney = totalPrice + order.Freight;//拆分时另算 
                if (IsCf)
                {
                    realOrder.OrderPoint = 0;//根据规则计算 

                }
                else
                {
                    realOrder.OrderPoint = 0;//根据规则计算 

                }
                Orderlist.Add(realOrder);
                OrderCount++;
            }

            return result;
        }

        private bool? CoumputeRule(string accuontID, List<BaseEntity> Orderlist, DateTime now, bool? IsFirst, ShopOrder realOrder, List<ShopOrderItem> handsales, List<ShopPromotionSimpal> PromotionList, string jFSouceSubID = null)
        {
            if (PromotionList != null)
            {
                List<ShopPromotion> listPromotion = new ShopPromotionDal().GetList(ShopPromotion._.ID.In(PromotionList.Select(p => p.ID).ToList()));
                //计算活动规则

                foreach (var pro in listPromotion)
                {

                    JFHistory jh = null;
                    ShopOrderItem handSaile = null;
                    switch (pro.RuleTypeName.Phrase<RuleType>())
                    {
                        case RuleType.满额送优惠券:
                            jh = new JFHistory()
                            {
                                ID = Guid.NewGuid().ToString(),
                                CreateDate = now,
                                MemberID = accuontID,
                                JFType = 1,
                                FX = 0,
                                JFCount = pro.HandsaleCount,
                                JFSouce = JFType.购物.ToString(),
                                JFSouceMainID = realOrder.ID,
                                JFSouceSubID = jFSouceSubID,
                                JFState = (int)JFStatus.在途,
                                CouponID = pro.CouponID,
                                ActivityID = pro.ID
                            };
                            Orderlist.Add(jh);

                            break;
                        case RuleType.满额送积分:
                            jh = new JFHistory()
                            {
                                ID = Guid.NewGuid().ToString(),
                                CreateDate = now,
                                MemberID = accuontID,
                                JFType = 0,
                                FX = 0,
                                JFCount = pro.HandsaleCount,
                                JFSouce = JFType.购物.ToString(),
                                JFSouceMainID = realOrder.ID,
                                JFSouceSubID = jFSouceSubID,
                                JFState = (int)JFStatus.在途,
                                ActivityID = pro.ID
                            };
                            Orderlist.Add(jh);
                            break;
                        case RuleType.满额送赠品:
                            if (!string.IsNullOrWhiteSpace(pro.HandsaleProductId))
                            {


                                View_ProductInfoBySkuid handproduct = Dal.From<View_ProductInfoBySkuid>().Join<ShopBrandInfo>(View_ProductInfoBySkuid._.BrandId == ShopBrandInfo._.ID, JoinType.leftJoin)
               .Join<ShopProductType>(View_ProductInfoBySkuid._.TypeId == ShopProductType._.ID)
               .Join<AttachFile>(View_ProductInfoBySkuid._.ID == AttachFile._.RefID, JoinType.leftJoin)
           .Select(View_ProductInfoBySkuid._.ID.All, ShopBrandInfo._.Name.Alias("BrandName"), ShopProductType._.Name.Alias("ProductTypeName"),
           AttachFile.GetFilePath("")).Where(View_ProductInfoBySkuid._.ID == pro.HandsaleProductId && View_ProductInfoBySkuid._.SKUID == pro.HandsaleProductSKUID
           ).ToFirst<View_ProductInfoBySkuid>();
                                handSaile = new ShopOrderItem()
                                {
                                    ID = Guid.NewGuid().ToString(),
                                    OrderID = realOrder.ID,
                                    ProductID = pro.HandsaleProductId,
                                    ProductSKU = pro.HandsaleProductSKUID,
                                    ProductType = handproduct.TypeId,
                                    ProductCode = handproduct.Code,
                                    ProductName = handproduct.Name,
                                    AttributeVal = handproduct.SKUName,
                                    ProductThumb = handproduct.FilePath,
                                    Unit = handproduct.Unit,
                                    Count = pro.HandsaleCount,
                                    IsHandsel = true,
                                    HandselCount = pro.HandsaleCount,
                                    ProductTypeName = handproduct.ProductTypeName,
                                    BrandName = handproduct.BrandName,
                                    ShortDescription = handproduct.ShortDescription,
                                    Weight = handproduct.Weight,
                                    IsVirtualProduct = handproduct.IsVirtualProduct
                                };
                                handsales.Add(handSaile);
                            }
                            break;
                        case RuleType.满额免运费:
                            break;
                        case RuleType.首单送优惠券:
                            if (IsFirst == null)
                            {
                                bool isHave = Dal.Exists<ShopOrder>(ShopOrder._.MemberID == accuontID);
                                IsFirst = isHave == false;
                            }
                            if (IsFirst.Value)
                            {


                                jh = new JFHistory()
                                {
                                    ID = Guid.NewGuid().ToString(),
                                    CreateDate = now,
                                    MemberID = accuontID,
                                    JFType = 1,
                                    FX = 0,
                                    JFCount = pro.HandsaleCount,
                                    JFSouce = JFType.购物.ToString(),
                                    JFSouceMainID = realOrder.ID,
                                    JFSouceSubID = jFSouceSubID,
                                    JFState = (int)JFStatus.在途,
                                    CouponID = pro.CouponID,
                                    ActivityID = pro.ID
                                };
                                Orderlist.Add(jh);
                            }
                            break;
                        case RuleType.首单送积分:
                            if (IsFirst == null)
                            {
                                bool isHave = Dal.Exists<ShopOrder>(ShopOrder._.MemberID == accuontID);
                                IsFirst = isHave == false;
                            }
                            if (IsFirst.Value)
                            {
                                jh = new JFHistory()
                                {
                                    ID = Guid.NewGuid().ToString(),
                                    CreateDate = now,
                                    MemberID = accuontID,
                                    JFType = 0,
                                    FX = 0,
                                    JFCount = pro.HandsaleCount,
                                    JFSouce = JFType.购物.ToString(),
                                    JFSouceMainID = realOrder.ID,
                                    JFSouceSubID = jFSouceSubID,
                                    JFState = (int)JFStatus.在途,
                                    ActivityID = pro.ID
                                };
                                Orderlist.Add(jh);
                            }
                            break;
                        case RuleType.首单送赠品:
                            if (!string.IsNullOrWhiteSpace(pro.HandsaleProductId))
                            {
                                if (IsFirst == null)
                                {
                                    bool isHave = Dal.Exists<ShopOrder>(ShopOrder._.MemberID == accuontID);
                                    IsFirst = isHave == false;
                                }
                                if (IsFirst.Value)
                                {

                                    View_ProductInfoBySkuid handproduct = Dal.From<View_ProductInfoBySkuid>().Join<ShopBrandInfo>(View_ProductInfoBySkuid._.BrandId == ShopBrandInfo._.ID, JoinType.leftJoin)
                   .Join<ShopProductType>(View_ProductInfoBySkuid._.TypeId == ShopProductType._.ID)
                   .Join<AttachFile>(View_ProductInfoBySkuid._.ID == AttachFile._.RefID, JoinType.leftJoin)
               .Select(View_ProductInfoBySkuid._.ID.All, ShopBrandInfo._.Name.Alias("BrandName"), ShopProductType._.Name.Alias("ProductTypeName"),
               AttachFile.GetFilePath("")).Where(View_ProductInfoBySkuid._.ID == pro.HandsaleProductId && View_ProductInfoBySkuid._.SKUID == pro.HandsaleProductSKUID
               ).ToFirst<View_ProductInfoBySkuid>();
                                    handSaile = new ShopOrderItem()
                                    {
                                        ID = Guid.NewGuid().ToString(),
                                        OrderID = realOrder.ID,
                                        ProductID = pro.HandsaleProductId,
                                        ProductSKU = pro.HandsaleProductSKUID,
                                        ProductType = handproduct.TypeId,
                                        ProductCode = handproduct.Code,
                                        ProductName = handproduct.Name,
                                        AttributeVal = handproduct.SKUName,
                                        ProductThumb = handproduct.FilePath,
                                        Unit = handproduct.Unit,
                                        Count = pro.HandsaleCount,
                                        IsHandsel = true,
                                        HandselCount = pro.HandsaleCount,
                                        ProductTypeName = handproduct.ProductTypeName,
                                        BrandName = handproduct.BrandName,
                                        ShortDescription = handproduct.ShortDescription,
                                        Weight = handproduct.Weight,
                                        IsVirtualProduct = handproduct.IsVirtualProduct
                                    };
                                    handsales.Add(handSaile);
                                }
                            }
                            break;
                        case RuleType.首单免运费:
                            if (IsFirst == null)
                            {
                                bool isHave = Dal.Exists<ShopOrder>(ShopOrder._.MemberID == accuontID);
                                IsFirst = isHave == false;
                            }
                            if (IsFirst.Value)
                            {
                                realOrder.Freight = 0;
                            }
                            break;
                        case RuleType.注册送优惠券:
                            break;
                        case RuleType.注册送积分:
                            break;
                        case RuleType.包邮:
                            break;
                        default:
                            break;
                    }
                }
            }
            return IsFirst;
        }
    }


}
