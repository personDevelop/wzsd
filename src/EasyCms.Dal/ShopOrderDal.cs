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

        public int Save(ShopOrder item, string userID, string username)
        {
            if (item.ChangedProperties != null && item.ChangedProperties.Count > 0 && item.ChangedProperties.ContainsKey("ExpressCompanyID"))
            {
                if (string.IsNullOrWhiteSpace(item.ExpressCompanyID))
                {
                    item.ExpressCompanyName = string.Empty;

                }
                else
                {
                    item.ExpressCompanyName = Dal.From<ShopExpress>().Where(ShopExpress._.ID == item.ExpressCompanyID).Select(ShopExpress._.Name).ToScalar() as string;

                }

            }
            ShopOrderAction orderAction = new ShopOrderAction()
            {

                ID = Guid.NewGuid().ToString(),
                ActionCode = ActionEnum.修改订单,
                ActionName = ActionEnum.修改订单.ToString(),
                UserId = userID,

                OrderId = item.ID,
                ActionDate = DateTime.Now,
                IsHideUser = true,
                Username = username
            };
            return Dal.Submit(orderAction, item);


        }



        public DataTable GetList(int pagenum, int pagesize, WhereClip where, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;

            return Dal.From<ShopOrder>().Where(where).OrderBy(ShopOrder._.CreateDate.Desc)

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
                    err = string.Format("您购买的第{0}条商品{1}已经没有货了,不能再购买了", i, v.Name, v.Stock);
                    break;
                }
                if (v.IsEnableSku)
                {
                    if (!v.IsSale)
                    {
                        err = string.Format("您购买的第{0}条商品{1}已下架,不能再购买了", i, v.Name);
                        break;
                    }

                }
                else
                {
                    if (v.SaleStatus != (int)ShopSaleStatus.上架)
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


            if (list.Exists(p => p.OrderType != 0))//只有普通购物才有促销和优惠券，团购、秒杀无优惠券和促销活动
            {

            }
            else
            {  //获取可用促销活动
                order.Promotion = new ShopPromotionDal().GetValidPromotionList(list, accuontID);
                //获取可用优惠券
                order.Coupon = new CouponRuleDal().GetValidCouponList(list, accuontID);
            }

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
        public string Submit(ShopOrderModel order, ManagerUserInfo accuont, out bool mustGenerSign, out string err)
        {
            #region MyRegion
            //前台传过来的订单总价格 实际是实际支付金额，不是订单总金额
            mustGenerSign = false;

            err = string.Empty;
            #region 判断是否满足货到付款
            if (!order.CashOnDelivery && string.IsNullOrWhiteSpace(order.PayTypeID))
            {
                err = "请选择在线付款方式";
                return null;

            }
            if (!order.CashOnDelivery && !string.IsNullOrWhiteSpace(order.PayTypeID))
            {
                mustGenerSign = true;
            }
            #endregion
            #region 检测地址对不对
            if (string.IsNullOrWhiteSpace(order.AddressID))
            {
                err = "请选择收件地址";
                return null;
            }
            ShopShippingAddress address = Dal.Find<ShopShippingAddress>(order.AddressID);
            if (address == null)
            {
                err = "您选择的收件地址不存在，请重新设置收件地址";
                return null;
            }
            string ShipRegion = Dal.From<AdministrativeRegions>().Where(AdministrativeRegions._.ID == address.RegionId).Select(AdministrativeRegions.PathName).ToScalar() as string;
            #endregion

            List<OrderItem> list = order.OrderItems;
            List<BaseEntity> Savelist = new List<BaseEntity>();
            List<ShopOrder> Orderlist = new List<ShopOrder>();
            //检测商品对不对
            if (list == null || list.Count == 0)
            {
                err = "请选择要购买的商品";
                return null;
            }

            Dictionary<string, int> activeID = new Dictionary<string, int>();//活动字典，拆分订单使用
            List<string> ListactiveID = new List<string>();//活动字典，拆分订单使用,只所以加这个，是因为Dictionary 不支持null
            List<string> listPromot = new List<string>();//活动规则ID集合
            List<string> listCoupon = new List<string>();//优惠券ID集合
            decimal productPrice = 0;


            #region 检测促销活动是否过期

            foreach (OrderItem item in list)
            {
                productPrice += item.SalePrice * item.BuyCount;
                if (string.IsNullOrWhiteSpace(item.OrderResId))
                {
                    if (!ListactiveID.Contains(item.OrderResId))
                    {
                        ListactiveID.Add(item.OrderResId);
                    }
                }
                else
                    if (!activeID.ContainsKey(item.OrderResId))
                    {
                        activeID.Add(item.OrderResId, item.OrderType);
                    }
                #region 废弃
                //if (item.Coupon != null)
                //{
                //    foreach (var promot in item.Coupon)
                //    {
                //        //检测促销活动是否过期

                //        if (!listCoupon.Contains(promot.ID))
                //        {
                //            listCoupon.Add(promot.ID);
                //        }
                //        decimal value = promot.CardValue * promot.UsingCount;
                //        //检测是否有超过使用比例,由于表结构没有支持该功能，暂时不实现了
                //        //if (true)
                //        //{

                //        //}
                //        CouponPrice += value;
                //        CusomerAndCoupon upcoupon = new CusomerAndCoupon() { RecordStatus = StatusType.update, Where = CusomerAndCoupon._.ID == promot.ID };
                //        ExpressionClip HaveCount = new ExpressionClip("HaveCount-@HaveCount");
                //        HaveCount.Parameters.Add("HaveCount", promot.UsingCount);
                //        upcoupon.SetModifiedProperty(CusomerAndCoupon._.HaveCount, HaveCount);
                //        ExpressionClip UsedCount = new ExpressionClip("UsedCount+@UsedCount");
                //        HaveCount.Parameters.Add("UsedCount", promot.UsingCount);
                //        upcoupon.SetModifiedProperty(CusomerAndCoupon._.UsedCount, UsedCount);
                //        Orderlist.Add(upcoupon);
                //    }
                //} 
                #endregion
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

            //判断是否满足货到付款
            #region MyRegion
            if (order.CashOnDelivery)
            {
                if (activeID.Count > 0)
                {
                    err = "促销类（团购、秒杀等）不支持货到付款";
                    return null;
                }

                if (order.OrderItems.Exists(p => p.IsVirtualProduct))
                {
                    err = "当前订单含有虚拟商品，不支持货到付款";
                    return null;
                }
            }
            else if (string.IsNullOrWhiteSpace(order.PayTypeID))
            {

                err = "请选择在线付款方式";
                return null;

            }
            #endregion

            #region 检测优惠券是否过期 并计算优惠券总额
            decimal CouponPrice = 0;
            if (order.Coupon != null)
            {
                order.Coupon = Dal.From<CusomerAndCoupon>().Where(CusomerAndCoupon._.ID == order.Coupon[0].ID)

                    .Select(CusomerAndCoupon._.ID, CusomerAndCoupon._.CardValue).ToDataTable().ToList<CouponAccount>();


                foreach (var promot in order.Coupon)
                {
                    //检测促销活动是否过期
                    if (!listCoupon.Contains(promot.ID))
                    {
                        listCoupon.Add(promot.ID);
                    }
                    if (promot.UsingCount == 0)
                    {
                        promot.UsingCount = 1;
                    }
                    CusomerAndCoupon upcoupon = new CusomerAndCoupon() { RecordStatus = StatusType.update, Where = CusomerAndCoupon._.ID == promot.ID };
                    ExpressionClip HaveCount = new ExpressionClip("HaveCount-@HaveCount");
                    HaveCount.Parameters.Add("HaveCount", promot.UsingCount);
                    upcoupon.SetModifiedProperty(CusomerAndCoupon._.HaveCount, HaveCount);
                    ExpressionClip UsedCount = new ExpressionClip("UsedCount+@UsedCount");
                    HaveCount.Parameters.Add("UsedCount", promot.UsingCount);
                    upcoupon.SetModifiedProperty(CusomerAndCoupon._.UsedCount, UsedCount);
                    Savelist.Add(upcoupon);
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


            //如果优惠金额大于订单金额，为了避免负数订单，将优惠金额设为订单金额相等
            if (productPrice - CouponPrice < 0)
            {
                //并设置优惠金额和实际优惠券相等
                CouponPrice = productPrice;

            }
            //开始计算订单支付总额  支付总额计算方式是，商品总额-优惠券总额+运费
            decimal totalPrice = productPrice - CouponPrice + order.Freight;
            if (totalPrice != order.TotalPrice)
            {
                err = "订单的金额[" + order.TotalPrice + "]和实际的金额(商品总额-优惠券总额+运费)[" + totalPrice + "]不符,请重新选择本次购物要使用的优惠券";
                return null;
            }
            #region 判断当前订单的优惠券金额是否超过系统设定的比例 ，只和订单金额比较，不算运费
            if (CouponPrice > 0)
            {
                decimal Allowpercent = new ParameterInfoDal().GetDecimalValue(StaticValue.CouponPercent);
                decimal percent = (CouponPrice * 100) / (productPrice);
                if (percent >= 100)
                {
                    if (Allowpercent < 100)
                    {
                        err = "您使用的优惠券超过系统允许的比例" + Allowpercent + "%，请重新选择使用的优惠券";
                        return null;
                    }
                }
                else if (percent > Allowpercent)
                {
                    err = "您使用的优惠券超过系统允许的比例" + Allowpercent + "%，请重新选择使用的优惠券";
                    return null;
                }
            }
            #endregion
            #endregion
            string orderNum = GetMaxNo("HQ");
            DateTime now = DateTime.Now;
            //开始判断是否拆单
            bool IsCf = ListactiveID.Count > 1;
            int OrderCount = 1;
            #region 先获取所有商品
            WhereClip where = View_ProductInfoBySkuid._.ID.In(list.Select(p => p.ProductID).ToArray());
            List<View_ProductInfoBySkuid> productList = Dal.From<View_ProductInfoBySkuid>().Join<ShopBrandInfo>(View_ProductInfoBySkuid._.BrandId == ShopBrandInfo._.ID, JoinType.leftJoin)
                     .Join<ShopProductType>(View_ProductInfoBySkuid._.TypeId == ShopProductType._.ID)
                     .Join<AttachFile>(View_ProductInfoBySkuid._.ID == AttachFile._.RefID, JoinType.leftJoin)
                 .Select(View_ProductInfoBySkuid._.ID.All, ShopBrandInfo._.Name.Alias("BrandName"), ShopProductType._.Name.Alias("ProductTypeName"),
                 AttachFile.GetFilePath("")).Where(where  //此处附件路径信息只是存储到数据库，所有不需要host
                 ).List<View_ProductInfoBySkuid>();
            #endregion
            //拆分成多个订单( 不用管是否是虚拟产品，这个在前台判断) 
            bool? IsFirst = null;
            ShopOrder firstOrder = null;
            foreach (var item in ListactiveID)
            {
                #region 生成订单  一个活动一个订单
                int val = 0;
                if (!string.IsNullOrWhiteSpace(item))
                {
                    val = activeID[item];

                }
                ShopOrder activeOrder = new ShopOrder()
                      {
                          ID = (OrderCount.ToString()).PadLeft(2, '0'),
                          OrderType = val,
                          OrderResId = item,
                          MemberID = accuont.ID,
                          MemberName = accuont.Name,
                          MemberEmail = accuont.Email,
                          MemberCallPhone = accuont.ContactPhone,
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


                activeOrder.RegionID = address.RegionId;
                activeOrder.ShipName = address.ShipName;
                activeOrder.ShipAddress = address.Address;
                activeOrder.ShipZip = address.Zipcode;
                activeOrder.ShipEmail = address.EmailAddress;
                activeOrder.ShipTel = address.CelPhone;
                activeOrder.ShipRegion = ShipRegion;
                #endregion
                #region 判断是否拆分
                if (IsCf)
                {
                    activeOrder.ID = orderNum + activeOrder.ID;
                    activeOrder.ParentID = orderNum;
                }
                else
                {
                    activeOrder.ID = orderNum;
                    activeOrder.ParentID = null;
                }
                #endregion
                //计算商品明细
                List<OrderItem> OrderResList = list.Where(p => p.OrderResId == item).ToList<OrderItem>();
                int orderItemNum = 1;
                decimal totalCostPrice = 0, totalmarketPrice = 0, totalsalePrice = 0;
                List<ShopOrderItem> handsales = new List<ShopOrderItem>();
                int i = 0;
                foreach (var productVar in OrderResList)
                {
                    i++;
                    #region 创建一个订单明细
                    View_ProductInfoBySkuid productItem = productList.FirstOrDefault(p => p.ID == productVar.ProductID && (p.SKUID == productVar.Sku || p.SKUID == null || p.SKUID == string.Empty));
                    if (productItem == null)
                    {
                        err = "您订购的第" + i + "条商品没有找到，或者已下架";
                        return null;
                    }

                    ShopOrderItem product = new ShopOrderItem()
                               {
                                   ID = Guid.NewGuid().ToString(),
                                   OrderID = activeOrder.ID,
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

                    if (product.Point > 0)
                    {

                        JFHistory jh = CreateJfHistory(accuont.ID, now, JFType.积分, RuleType.满额送积分, product.Point, activeOrder.ID,
                            product.ID, null, null);
                        Savelist.Add(jh);
                    }

                    #endregion
                    IsFirst = CoumputeRule(accuont.ID, Savelist, now, IsFirst, activeOrder, handsales, productVar.Promotion, product.ID);
                    product.CostPrice = productItem.CostPrice;
                    product.MarketPrice = productItem.MarketPrice;
                    product.Price = productItem.SalePrice;
                    totalCostPrice += productItem.CostPrice * product.Count;
                    totalmarketPrice += productItem.MarketPrice * product.Count;
                    totalsalePrice += productItem.SalePrice * product.Count;
                    product.TotalPrice = product.Price * product.Count;
                    product.Sequence = orderItemNum;
                    Savelist.Add(product);
                    orderItemNum++;
                }
                //计算订单促销规则
                IsFirst = CoumputeRule(accuont.ID, Savelist, now, IsFirst, activeOrder, handsales, order.Promotion);
                foreach (var handItem in handsales)
                {
                    handItem.Sequence = orderItemNum++;
                    Savelist.Add(handItem);
                }
                activeOrder.CostPrice = totalCostPrice;
                activeOrder.TotalPrice = totalsalePrice;

                if (activeOrder.TotalPrice >= CouponPrice)
                {
                    activeOrder.Discount = CouponPrice;

                }
                else
                {
                    activeOrder.Discount = activeOrder.TotalPrice;
                    CouponPrice -= activeOrder.TotalPrice;
                }
                if (activeOrder.Discount > 0)
                {
                    //设置优惠券使用记录，由于这个虽然有拆分订单，但是能保证 如果当前订单使用了优惠券，那基本能保证 优惠券都使用在了该订单上
                    foreach (string CouponAccountID in listCoupon)
                    {

                        Savelist.Add(CreateJfHistory(accuont.ID, now, JFType.优惠券, RuleType.使用优惠券, 1, activeOrder.ID, null, CouponAccountID, null, AddOrRemove.减少));
                    }
                }
                if (IsCf)
                {
                    if (OrderCount != 1)// 将其他订单的运费设为0 
                    {
                        activeOrder.FreightActual = 0;
                    }
                }
                activeOrder.PayMoney = activeOrder.TotalPrice + activeOrder.Freight - activeOrder.Discount;
                if (order.CashOnDelivery)
                {
                    activeOrder.ShipStatus = (int)ShipStatus.等待商家发货;
                    activeOrder.PayStatus = (int)PayStatus.未付款;
                    activeOrder.OrderStatus = (int)OrderStatus.等待商家发货;
                }
                else
                {
                    if (activeOrder.PayMoney <= 0)
                    {
                        activeOrder.PayStatus = (int)PayStatus.待商家确认;
                        activeOrder.ShipStatus = (int)ShipStatus.等待商家确认;
                        activeOrder.OrderStatus = (int)OrderStatus.等待商家确认;
                    }
                    else
                    {
                        activeOrder.PayStatus = (int)PayStatus.未付款;
                        activeOrder.ShipStatus = (int)ShipStatus.等待付款;
                        activeOrder.OrderStatus = (int)OrderStatus.等待付款;
                    }
                }
                if (firstOrder == null)
                {
                    firstOrder = activeOrder;
                }
                Savelist.Add(activeOrder);
                Orderlist.Add(activeOrder);
                ShopOrderAction orderAction = new ShopOrderAction()
                {

                    ID = Guid.NewGuid().ToString(),
                    ActionCode = ActionEnum.创建订单,
                    ActionName = ActionEnum.创建订单.ToString(),
                    OrderId = activeOrder.ID,
                    ActionDate = now
                };
                Savelist.Add(orderAction);
                OrderCount++;
            }
            if (IsCf)
            {
                //创建主订单
                ShopOrder mainOrder = firstOrder.Clone<ShopOrder>();
                mainOrder.ID = orderNum;
                mainOrder.Discount = Orderlist.Sum(p => p.Discount);
                mainOrder.TotalPrice = Orderlist.Sum(p => p.TotalPrice);
                mainOrder.CostPrice = Orderlist.Sum(p => p.CostPrice);
                mainOrder.FreightActual = Orderlist.Sum(p => p.FreightActual);
                mainOrder.PayMoney = Orderlist.Sum(p => p.PayMoney);
                if (order.CashOnDelivery)
                {
                    mainOrder.ShipStatus = (int)ShipStatus.等待商家发货;
                    mainOrder.PayStatus = (int)PayStatus.未付款;
                    mainOrder.OrderStatus = (int)OrderStatus.等待商家发货;
                }
                else
                {
                    if (mainOrder.PayMoney <= 0)
                    {
                        mainOrder.PayStatus = (int)PayStatus.待商家确认;
                        mainOrder.ShipStatus = (int)ShipStatus.等待商家确认;
                        mainOrder.OrderStatus = (int)OrderStatus.等待商家确认;
                    }
                    else
                    {
                        mainOrder.PayStatus = (int)PayStatus.未付款;
                        mainOrder.ShipStatus = (int)ShipStatus.等待付款;
                        mainOrder.OrderStatus = (int)OrderStatus.等待付款;
                    }
                }
                Savelist.Add(mainOrder);
                ShopOrderAction orderAction = new ShopOrderAction()
                {

                    ID = Guid.NewGuid().ToString(),
                    ActionCode = ActionEnum.创建订单,
                    ActionName = ActionEnum.创建订单.ToString(),
                    OrderId = orderNum,
                    ActionDate = now
                };
                Savelist.Add(orderAction);

            }
            SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                dal.SubmitNew(tr, ref dal, Savelist);
                dal.CommitTransaction(tr);

            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
                throw;
            }

            return orderNum;
        }

        private bool? CoumputeRule(string accuontID, List<BaseEntity> Orderlist, DateTime now, bool? IsFirst, ShopOrder realOrder, List<ShopOrderItem> handsales, List<ShopPromotionSimpal> PromotionList, string jFSouceSubID = null)
        {
            if (PromotionList != null)
            {
                List<ShopPromotion> listPromotion = new ShopPromotionDal().GetList(ShopPromotion._.ID.In(PromotionList.Select(p => p.ID).ToList()));
                //计算活动规则

                foreach (var pro in listPromotion)
                {
                    RuleType rt = pro.RuleTypeName.Phrase<RuleType>();
                    int sendCount = (int)pro.HandsaleCount;

                    if (rt != RuleType.首单免运费)
                    {
                        int hasSendCount = (int)pro.HasSendCount + sendCount;
                        if (pro.HandsaleMaxCount > 0)
                        {
                            if (hasSendCount > pro.HandsaleMaxCount)
                            {
                                sendCount = (int)pro.HandsaleMaxCount - hasSendCount;
                                if (sendCount == 0)
                                {
                                    sendCount = 1;//只要大于0就行，方便下面做一次性判断
                                }
                            }
                            else
                            {
                                sendCount = 0;
                            }
                        }
                        else
                        {
                            if (sendCount == 0)
                            {
                                sendCount = 1;//只要大于0就行，方便下面做一次性判断
                            }

                        }
                        pro.HasSendCount += sendCount;

                    }
                    else
                    {
                        if (sendCount == 0)
                        {
                            sendCount = 1;//只要大于0就行，方便下面做一次性判断
                        }

                    }

                    JFHistory jh = null;
                    ShopOrderItem handSaile = null;
                    if (sendCount > 0)
                    {
                        switch (rt)
                        {
                            case RuleType.满额送优惠券:

                                jh = CreateJfHistory(accuontID, now, JFType.优惠券, rt, sendCount, realOrder.ID, jFSouceSubID, pro.CouponID, pro.ID);
                                Orderlist.Add(jh);
                                Orderlist.Add(pro);

                                break;
                            case RuleType.满额送积分:
                                jh = CreateJfHistory(accuontID, now, JFType.积分, rt, sendCount, realOrder.ID, jFSouceSubID, null, pro.ID);
                                Orderlist.Add(pro);
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
                                        Count = sendCount,
                                        IsHandsel = true,
                                        HandselCount = sendCount,
                                        ProductTypeName = handproduct.ProductTypeName,
                                        BrandName = handproduct.BrandName,
                                        ShortDescription = handproduct.ShortDescription,
                                        Weight = handproduct.Weight,
                                        IsVirtualProduct = handproduct.IsVirtualProduct
                                    };
                                    handsales.Add(handSaile);
                                    jh = CreateJfHistory(accuontID, now, JFType.赠品, rt, sendCount, realOrder.ID, jFSouceSubID, handSaile.ProductSKU ?? handSaile.ProductID, pro.ID);
                                    Orderlist.Add(pro);

                                }

                                break;
                            case RuleType.满额免运费:
                                //这个由于目前运费统一是0，所以这个暂不处理
                                break;
                            case RuleType.首单送优惠券:
                                if (IsFirst == null)
                                {
                                    bool isHave = Dal.Exists<ShopOrder>(ShopOrder._.MemberID == accuontID);
                                    IsFirst = isHave == false;
                                }
                                if (IsFirst.Value)
                                {

                                    jh = CreateJfHistory(accuontID, now, JFType.优惠券, rt, sendCount, realOrder.ID, jFSouceSubID, pro.CouponID, pro.ID);
                                    Orderlist.Add(jh);
                                    Orderlist.Add(pro);
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
                                    jh = CreateJfHistory(accuontID, now, JFType.积分, rt, sendCount, realOrder.ID, jFSouceSubID, null, pro.ID);
                                    Orderlist.Add(jh);
                                    Orderlist.Add(pro);
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
                                        if (handproduct != null)
                                        {


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
                                                Count = sendCount,
                                                IsHandsel = true,
                                                HandselCount = sendCount,
                                                ProductTypeName = handproduct.ProductTypeName,
                                                BrandName = handproduct.BrandName,
                                                ShortDescription = handproduct.ShortDescription,
                                                Weight = handproduct.Weight,
                                                IsVirtualProduct = handproduct.IsVirtualProduct
                                            };


                                            handsales.Add(handSaile);
                                            Orderlist.Add(pro);
                                            jh = CreateJfHistory(accuontID, now, JFType.赠品, rt, sendCount, realOrder.ID, jFSouceSubID, handSaile.ProductSKU ?? handSaile.ProductID, pro.ID);
                                        }
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
                                    jh = CreateJfHistory(accuontID, now, JFType.其他, rt, sendCount, realOrder.ID, jFSouceSubID, null, pro.ID);
                                    Orderlist.Add(jh);

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
            }
            return IsFirst;
        }

        public JFHistory CreateJfHistory(string accountid, DateTime now, JFType jftype, RuleType rultType, decimal sendCount, string mainID, string mxid, string coupponIDoRProductID, string activityid, AddOrRemove addOrRemove = AddOrRemove.增加)
        {

            return new JFHistory()
            {
                ID = Guid.NewGuid().ToString(),
                CreateDate = now,
                MemberID = accountid,
                JFType = jftype,
                FX = addOrRemove,
                JFCount = sendCount,
                JFSouce = rultType,
                JFSouceMainID = mainID,
                JFSouceSubID = mxid,
                JFState = JFStatus.在途,
                CouponID = coupponIDoRProductID,//优惠券或者赠送商品的id 或skuid
                ActivityID = activityid
            };
        }
        public List<ShopOrder> GetMyOrder(string host, ManagerUserInfo user, int queryPage, string queryStatusStr, string otherWhere, out string err)
        {
            err = string.Empty;
            WhereClip where = ShopOrder._.MemberID == user.ID && ShopOrder._.HasDelete == false;

            if (!string.IsNullOrWhiteSpace(queryStatusStr))
            {
                int queryStatus = -1;
                if (int.TryParse(queryStatusStr, out queryStatus))
                {
                    if (queryStatus > -1)
                    {
                        where = where && ShopOrder._.OrderStatus == queryStatus;
                    }

                }
                else
                {
                    where = where && ShopOrder._.OrderStatus.In(queryStatusStr.Split(new char[] { ',' },
                         StringSplitOptions.RemoveEmptyEntries).ToArray());
                }
            }

            if (!string.IsNullOrWhiteSpace(otherWhere))
            {
                where = where && new WhereClip(otherWhere);
            }
            int recordcount = 0;
            int pageCount = 0;
            List<ShopOrder> list = Dal.From<ShopOrder>().Where(where)
                .Select(ShopOrder._.ID, ShopOrder._.ParentID, ShopOrder._.OrderType,
                ShopOrder._.OrderResId,
                ShopOrder._.PayTypeName,
                ShopOrder._.ExpressCompanyName,
                ShopOrder._.ShipOrderNum,
                ShopOrder._.FreightActual,
                ShopOrder._.ShipStatus,
                ShopOrder._.PayStatus,
                ShopOrder._.OrderStatus,
                ShopOrder._.CommentStatus,
                ShopOrder._.TotalPrice, ShopOrder._.CreateDate)
                .OrderBy(ShopOrder._.CreateDate.Desc).ToDataTable(20, queryPage, ref pageCount, ref recordcount).ToList<ShopOrder>();
            if (list.Count > 0)
            {
                List<string> orderIDS = list.Select(p => p.ID).ToList();
                List<ShopOrderItem> orderItems = Dal.From<ShopOrderItem>()
                    .Where(ShopOrderItem._.OrderID.In(orderIDS))
                    .Select(ShopOrderItem._.ID, ShopOrderItem._.OrderID, ShopOrderItem._.BrandName,
                    ShopOrderItem._.Count, ShopOrderItem._.HandselCount, ShopOrderItem._.IsHandsel,
                    ShopOrderItem._.IsVirtualProduct, ShopOrderItem._.MarketPrice,
                    ShopOrderItem._.Price, ShopOrderItem._.Preferential,
                    ShopOrderItem._.ProductID, ShopOrderItem._.ProductCode, ShopOrderItem._.ProductSKU,
                    ShopOrderItem._.ProductName, new ExpressionClip("'" + host + "'" + "+ProductThumb").Alias("ProductThumb"), ShopOrderItem._.TotalPrice,
                    ShopOrderItem._.Sequence).List<ShopOrderItem>();
                foreach (ShopOrder item in list)
                {
                    item.OrderItems = orderItems.Where(p => p.OrderID == item.ID).OrderBy(p => p.Sequence).ToList();
                }
            }
            return list;
        }

        public ShopOrder GetOrder(string host, string id, string userid, out string err)
        {
            err = string.Empty;
            WhereClip where = ShopOrder._.ID == id;
            ShopOrder order = Dal.From<ShopOrder>()

                .Where(where)
                .Select(ShopOrder._.ID, ShopOrder._.ParentID, ShopOrder._.OrderType,
                ShopOrder._.OrderResId,
                ShopOrder._.PayTypeName,
                ShopOrder._.ExpressCompanyName,
                ShopOrder._.ShipOrderNum,
                ShopOrder._.FreightActual,
                ShopOrder._.ShipStatus,
                ShopOrder._.PayStatus,
                ShopOrder._.OrderStatus,
                  ShopOrder._.IsInvoice,
                    ShopOrder._.InvoiceInfo,
                      ShopOrder._.InvoiceNote,
                ShopOrder._.CommentStatus, ShopOrder._.MemberID,
                ShopOrder._.TotalPrice, ShopOrder._.CreateDate,
                ShopOrder._.PayMoney, ShopOrder._.ShipRegion, ShopOrder._.ShipAddress, ShopOrder._.ShipTel, ShopOrder._.ShipName, ShopOrder._.Remark
                )
                .ToFirst<ShopOrder>();
            if (order == null)
            {
                err = "订单不存在";
            }
            else if (order.MemberID != userid)
            {
                err = "不是您的订单，您不能查看";
            }
            else
            {

                List<ShopOrderItem> orderItems = Dal.From<ShopOrderItem>()

                    .Where(ShopOrderItem._.OrderID == id)
                    .Select(ShopOrderItem._.ID, ShopOrderItem._.OrderID, ShopOrderItem._.BrandName,
                    ShopOrderItem._.Count, ShopOrderItem._.HandselCount, ShopOrderItem._.IsHandsel,
                    ShopOrderItem._.IsVirtualProduct, ShopOrderItem._.MarketPrice,
                    ShopOrderItem._.Price, ShopOrderItem._.Preferential, ShopOrderItem._.AttributeVal,
                     ShopOrderItem._.Unit, ShopOrderItem._.Remark, ShopOrderItem._.ProductTypeName,
                    ShopOrderItem._.ProductID, ShopOrderItem._.ProductCode, ShopOrderItem._.ProductSKU,
                    ShopOrderItem._.ProductName, new ExpressionClip("'" + host + "'" + "+ProductThumb").Alias("ProductThumb"), ShopOrderItem._.TotalPrice,
                    ShopOrderItem._.Sequence).List<ShopOrderItem>();

                order.OrderItems = orderItems;

                List<JFHistory> Alllist = Dal.From<JFHistory>().Where(JFHistory._.JFSouceMainID == id).List<JFHistory>();
                List<CouponRule> AllCoupon = new List<CouponRule>();
                List<ShopProductInfo> AllHandsalProducnt = new List<ShopProductInfo>();
                if (Alllist.Count > 0)
                {
                    List<string> whereList = Alllist.Where(p => p.FX == AddOrRemove.增加 && !string.IsNullOrWhiteSpace(p.CouponID) && p.JFSouce.ToString().Contains("优惠券")).Select(p => p.CouponID).ToList();
                    if (whereList.Count > 0)
                    {
                        AllCoupon = Dal.From<CouponRule>().Where(CouponRule._.ID.In(whereList)).List<CouponRule>();
                    }
                    whereList = Alllist.Where(p => !string.IsNullOrWhiteSpace(p.CouponID) && p.JFSouce.ToString().Contains("赠品")).Select(p => p.CouponID).ToList();
                    if (whereList.Count > 0)
                    {
                        AllHandsalProducnt = Dal.From<ShopProductInfo>().Where(ShopProductInfo._.ID.In(whereList)).Select(ShopProductInfo._.ID, ShopProductInfo._.Name).List<ShopProductInfo>();
                    }
                }


                //获取促销信息
                List<JFHistory> addList = Alllist.Where(p => p.FX == AddOrRemove.增加).ToList();
                List<string> promostionString = new List<string>();
                foreach (var item in addList)
                {
                    switch (item.JFSouce)
                    {
                        case RuleType.满额送优惠券:
                        case RuleType.首单送优惠券:
                        case RuleType.注册送优惠券:
                            //获取优惠券 金额  
                            if (AllCoupon.Exists(p => p.ID == item.CouponID))
                            {
                                promostionString.Add(item.JFSouce.ToString() + ",面值" + AllCoupon.Find(p => p.ID == item.CouponID).JE);
                            }
                            break;
                        case RuleType.满额送积分:
                        case RuleType.首单送积分:
                        case RuleType.注册送积分:

                            promostionString.Add(item.JFSouce.ToString() + ",数量" + item.JFCount);
                            break;
                        case RuleType.满额送赠品:
                        case RuleType.首单送赠品:
                            //获取赠品名称
                            if (AllHandsalProducnt.Exists(p => p.ID == item.CouponID))
                            {
                                promostionString.Add(item.JFSouce.ToString() + "," + AllHandsalProducnt.Find(p => p.ID == item.CouponID).Name);
                            }
                            break;
                        case RuleType.满额免运费:
                        case RuleType.首单免运费:
                        case RuleType.包邮:
                            promostionString.Add(item.JFSouce.ToString());
                            break;
                        case RuleType.其他:
                            break;
                        default:
                            break;
                    }
                }
                order.Promotion = promostionString;
                //获取使用的优惠券
                List<CouponRule> RemoveCoupon = new List<CouponRule>();

                List<string> whereStringList = Alllist.Where(p => p.FX == AddOrRemove.减少 && !string.IsNullOrWhiteSpace(p.CouponID) && p.JFSouce == RuleType.使用优惠券).Select(p => p.CouponID).ToList();
                if (whereStringList.Count > 0)
                {
                    RemoveCoupon = Dal.From<CouponRule>().Join<CusomerAndCoupon>(CouponRule._.ID == CusomerAndCoupon._.CouponID)
                        .Select(CouponRule._.Name).Where(
               CusomerAndCoupon._.ID.In(whereStringList)).List<CouponRule>();
                }

                List<string> CouponList = new List<string>();
                foreach (var item in RemoveCoupon)
                {
                    CouponList.Add("使用优惠券" + item.Name + "一张");
                }
                order.Coupon = CouponList;
            }
            return order;
        }

        public Dictionary<string, string> ExeAction(ActionEnum actionID, string wlgs, List<string> orderIDs, string userID, string username, out string err)
        {
            List<BaseEntity> list = new List<BaseEntity>();
            err = string.Empty;
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (orderIDs.Count == 0)
            {
                err = "请选择要" + actionID + "的订单";
            }
            else if (string.IsNullOrWhiteSpace(wlgs) && actionID == ActionEnum.发货)
            {
                err = "请选择物流公司";
            }
            else
            {

                //把当前的订单状态，发货状态、付款状态。付款方式查询出来
                Dictionary<string, ShopOrder> PublishIDS = new Dictionary<string, ShopOrder>();
                List<ShopOrder> orderList = Dal.From<ShopOrder>().Where(ShopOrder._.ID.In(orderIDs)).Select(ShopOrder._.ID, ShopOrder._.MemberID, ShopOrder._.PayTypeID,
                       ShopOrder._.PayStatus, ShopOrder._.ShipStatus, ShopOrder._.OrderStatus, ShopOrder._.PayMoney).List<ShopOrder>();
                OrderStatus changetToStatus = OrderStatus.等待付款;
                switch (actionID)
                {

                    case ActionEnum.发货:
                        changetToStatus = OrderStatus.已发货;
                        break;
                    case ActionEnum.签收:
                        changetToStatus = OrderStatus.完成;
                        break;
                    case ActionEnum.申请退货:
                        break;
                    case ActionEnum.不同意退货:
                        break;
                    case ActionEnum.同意退货:
                        break;
                    case ActionEnum.完成退货:
                        break;
                    case ActionEnum.完成退款:
                        break;
                    case ActionEnum.申请取消订单:
                        break;
                    case ActionEnum.取消订单:
                        break;
                    case ActionEnum.快递中转:
                        break;
                    case ActionEnum.导出订单:
                        break;
                    case ActionEnum.拒收:
                        changetToStatus = OrderStatus.拒收;
                        break;
                    case ActionEnum.作废:
                        changetToStatus = OrderStatus.作废;
                        break;
                    default:
                        break;
                }
                foreach (var item in orderIDs)
                {
                    string msg = string.Empty;

                    ShopOrder order = orderList.Find(p => p.ID == item);
                    switch (actionID)
                    {
                        case ActionEnum.创建订单:
                            break;
                        case ActionEnum.付款:
                            break;
                        case ActionEnum.发货:
                            int[] CanPublistStatus = new int[] { (int)OrderStatus.等待商家发货, (int)OrderStatus.等待商家确认 };
                            if (!string.IsNullOrWhiteSpace(order.PayTypeID))
                            {
                                if (order.PayStatus == (int)PayStatus.未付款)
                                {
                                    msg = "还没有付款，不能发货";
                                }
                            }
                            if (string.IsNullOrWhiteSpace(msg))
                            {


                                if (order.ShipStatus != (int)ShipStatus.等待商家发货)
                                {
                                    msg = "订单已发货，不能重复发货";
                                }
                                else if (!CanPublistStatus.Contains(order.OrderStatus))
                                {
                                    msg = "订单状态为【" + (OrderStatus)(order.OrderStatus) + "】,不能发货";
                                }


                            }
                            if (string.IsNullOrWhiteSpace(msg))
                            {
                                msg = "发货成功";
                                PublishIDS.Add(item, order);

                            }


                            break;
                        case ActionEnum.签收:
                            int[] NotCanQSStatus = new int[] { (int)OrderStatus.完成, (int)OrderStatus.发起退货申请,
                                (int)OrderStatus.退货完成, (int)OrderStatus.拒收, (int)OrderStatus.取消订单, (int)OrderStatus.商家不同意退换
                            , (int)OrderStatus.退货取货中, (int)OrderStatus.商家已收货等待退款, (int)OrderStatus.申请取消订单, (int)OrderStatus.退货完成, (int)OrderStatus.取消订单处理中, (int)OrderStatus.已收货, (int)OrderStatus.作废,(int)OrderStatus. 取消订单};


                            if (NotCanQSStatus.Contains(order.OrderStatus))
                            {
                                msg = "订单状态为【" + (OrderStatus)(order.OrderStatus) + "】,不能签收";
                            }
                            if (string.IsNullOrWhiteSpace(msg))
                            {
                                msg = "签收成功";
                                PublishIDS.Add(item, order);
                            }
                            //更改库存信息
                            List<ShopOrderItem> listItem = Dal.From<ShopOrderItem>().Where(ShopOrderItem._.OrderID.In(orderIDs)).Select(ShopOrderItem._.ID,
                                ShopOrderItem._.ProductID, ShopOrderItem._.ProductSKU, ShopOrderItem._.Count).List<ShopOrderItem>();
                            Dictionary<string, decimal> producntCount = new Dictionary<string, decimal>();
                            Dictionary<string, decimal> producntSkuCount = new Dictionary<string, decimal>();
                            foreach (var orderItem in listItem)
                            {
                                if (string.IsNullOrWhiteSpace(orderItem.ProductSKU))
                                {
                                    if (producntCount.ContainsKey(orderItem.ProductID))
                                    {
                                        producntCount[orderItem.ProductID] += orderItem.Count;
                                    }
                                    else
                                    {
                                        producntCount.Add(orderItem.ProductID, orderItem.Count);
                                    }
                                }
                                else
                                {
                                    if (producntSkuCount.ContainsKey(orderItem.ProductSKU))
                                    {
                                        producntSkuCount[orderItem.ProductSKU] += orderItem.Count;
                                    }
                                    else
                                    {
                                        producntSkuCount.Add(orderItem.ProductSKU, orderItem.Count);
                                    }
                                }

                            }

                            foreach (var pid in producntCount.Keys)
                            {
                                ShopProductInfo p = new ShopProductInfo() { RecordStatus = StatusType.update, Where = ShopProductInfo._.ID == pid };
                                ExpressionClip StockExpress = new ExpressionClip(ShopProductInfo._.Stock.ColumnName + "-" + producntCount[pid]);
                                p.SetModifiedProperty(ShopProductInfo._.Stock, StockExpress);
                                list.Add(p);

                            }
                            foreach (var pid in producntSkuCount.Keys)
                            {
                                ShopProductSKUInfo p = new ShopProductSKUInfo() { RecordStatus = StatusType.update, Where = ShopProductSKUInfo._.SKURelationID == pid };
                                ExpressionClip StockExpress = new ExpressionClip(ShopProductSKUInfo._.Stock.ColumnName + "-" + producntSkuCount[pid]);
                                p.SetModifiedProperty(ShopProductSKUInfo._.Stock, StockExpress);
                                list.Add(p);

                            }
                            break;
                        case ActionEnum.申请退货:
                            break;
                        case ActionEnum.不同意退货:
                            break;
                        case ActionEnum.同意退货:
                            break;
                        case ActionEnum.完成退货:
                            break;
                        case ActionEnum.完成退款:
                            break;
                        case ActionEnum.申请取消订单:
                            break;
                        case ActionEnum.取消订单:
                            break;
                        case ActionEnum.快递中转:
                            break;
                        case ActionEnum.导出订单:
                            break;
                        case ActionEnum.拒收:
                            int[] CanJSStatus = new int[] {  
                                (int)OrderStatus.等待商家发货, (int)OrderStatus.已发货 };


                            if (!CanJSStatus.Contains(order.OrderStatus))
                            {
                                msg = "订单状态为【" + (OrderStatus)(order.OrderStatus) + "】,不能拒收";
                            }
                            if (string.IsNullOrWhiteSpace(msg))
                            {
                                msg = "拒收成功";
                                PublishIDS.Add(item, order);
                            }

                            break;
                        case ActionEnum.作废:
                            int[] CanzfStatus = new int[] {  
                                (int)OrderStatus.拒收, (int)OrderStatus.取消订单 , (int)OrderStatus.退货完成 };

                            if (!CanzfStatus.Contains(order.OrderStatus))
                            {
                                msg = "订单状态为【" + (OrderStatus)(order.OrderStatus) + "】,不能作废";
                            }
                            if (string.IsNullOrWhiteSpace(msg))
                            {
                                msg = "作废成功";
                                PublishIDS.Add(item, order);
                            }
                            break;
                        default:
                            break;
                    }
                    result.Add(item, msg);
                }
                DateTime now = DateTime.Now;
                if (PublishIDS.Count > 0)
                {

                    string express = Dal.From<ShopExpress>().Where(ShopExpress._.ID == wlgs).Select(ShopExpress._.Name).ToScalar() as string;
                    ShopOrder update = new ShopOrder() { RecordStatus = StatusType.update, Where = ShopOrder._.ID.In(PublishIDS.Keys.ToList()) };
                    update.OrderStatus = (int)changetToStatus;
                    if (actionID == ActionEnum.发货)
                    {
                        update.ShipStatus = (int)ShipStatus.已发货;
                        update.ExpressCompanyID = wlgs;
                        update.ExpressCompanyName = express;
                        update.PublishDateTime = now;
                    }

                    list.Add(update);
                    //创建订单动作表
                    foreach (var item in PublishIDS.Keys)
                    {
                        ShopOrderAction orderAction = new ShopOrderAction()
                        {

                            ID = Guid.NewGuid().ToString(),
                            ActionCode = actionID,
                            ActionName = actionID.ToString(),
                            OrderId = item,
                            UserId = EasyCms.Session.CmsSession.GetUserID(),
                            Username = EasyCms.Session.CmsSession.GetUserName(),
                            ActionDate = now
                        };
                        if (actionID == ActionEnum.签收)
                        {
                            //兑现促销活动  主要是优惠券和积分

                            ParameterInfo buyGrowth = new ParameterInfoDal().GetEntity(StaticValue.GrowthValueBuy);
                            decimal val = decimal.Parse(buyGrowth.Value), val2 = decimal.Parse(buyGrowth.Value2);
                            int Gowthval = (int)(PublishIDS[item].PayMoney * (val2 / val));
                            new ManagerUserInfoDal().ChangeOrder(PublishIDS[item].MemberID, Gowthval);
                            List<JFHistory> listHistory = Dal.From<JFHistory>().Where(JFHistory._.JFSouceMainID == item).List<JFHistory>();
                            AccountRange accountRage = Dal.From<AccountRange>().Where(AccountRange._.ID == PublishIDS[item].MemberID).ToFirst<AccountRange>();
                            foreach (var jf in listHistory)
                            {
                                if (jf.JFState == JFStatus.在途)
                                {
                                    jf.JFState = JFStatus.完成;
                                    switch (jf.JFType)
                                    {
                                        case JFType.其他:
                                            break;
                                        case JFType.积分://积分,只会增加积分，不会减少
                                            if (accountRage != null)
                                            {
                                                if (jf.FX == 0)
                                                {
                                                    accountRage.JF += jf.JFCount;
                                                }
                                                else
                                                {
                                                    accountRage.JF -= jf.JFCount;
                                                }
                                            }
                                            break;
                                        case JFType.优惠券:
                                            if (jf.FX == AddOrRemove.增加)
                                            {
                                                //获取优惠券 并生成会员优惠券关系

                                                if (!string.IsNullOrWhiteSpace(jf.CouponID))
                                                {
                                                    CouponRule cr = Dal.Find<CouponRule>(jf.CouponID);
                                                    if (cr != null)
                                                    {
                                                        int sendCount = 0;
                                                        if (cr.MaxCount > 0 && cr.SendCount > cr.MaxCount)
                                                        {
                                                            jf.Remark = "优惠券已送完，不在赠送";

                                                        }
                                                        else
                                                        {
                                                            int sycount = cr.MaxCount - cr.SendCount;//剩余数量
                                                            if ((int)jf.JFCount > sycount)
                                                            {
                                                                sendCount = sycount;
                                                                cr.SendCount += sycount;
                                                                jf.Remark = "优惠券只剩余" + sycount;
                                                            }
                                                            else
                                                            {
                                                                sendCount = (int)jf.JFCount;
                                                                cr.SendCount += sendCount;
                                                            }

                                                        }
                                                        list.Add(cr);

                                                        CusomerAndCoupon cc = new CusomerAndCoupon()
                                                        {

                                                            ID = Guid.NewGuid().ToString(),
                                                            CardValue = cr.JE,
                                                            CustomerID = PublishIDS[item].MemberID,
                                                            CouponID = cr.ID,
                                                            HaveCount = sendCount,
                                                            HasDate = now,
                                                            Code = GetMaxNo(cr.PreName ?? "Q"),
                                                        };
                                                        if (cr.IsPwd)
                                                        {
                                                            cc.CardPwd = "123456";
                                                        }
                                                        if (cr.QxLx == 0)
                                                        {
                                                            //固定期限

                                                            cc.EndDate = cr.EndDate;


                                                        }
                                                        else
                                                        {
                                                            if (cr.IsCongZengSongKaiShi)
                                                            {
                                                                cr.EndDate = now.AddDays(cr.QXTS);
                                                            }
                                                            else { cc.EndDate = cr.EndDate; }

                                                        }
                                                        list.Add(cc);
                                                    }

                                                }

                                            }
                                            else
                                            {
                                                //使用优惠券，减少会员优惠券关系个数及状态
                                                if (!string.IsNullOrWhiteSpace(jf.CouponID))
                                                {
                                                    CouponRule cr = Dal.Find<CouponRule>(jf.CouponID);
                                                    if (cr != null)
                                                    {
                                                        CusomerAndCoupon ca = Dal.From<CusomerAndCoupon>().Where(CusomerAndCoupon._.CouponID == cr.ID

                                                            && CusomerAndCoupon._.IsOutDate == false && CusomerAndCoupon._.HaveCount >= jf.JFCount)
                                                            .ToFirst<CusomerAndCoupon>();
                                                        if (ca != null)
                                                        {
                                                            ca.HaveCount -= (int)jf.JFCount;
                                                            ca.UsedCount += (int)jf.JFCount;
                                                            list.Add(ca);
                                                        }


                                                    }
                                                }

                                            }
                                            break;
                                        case JFType.赠品:
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                if (accountRage != null)
                                {

                                    list.Add(accountRage);
                                }
                                list.Add(jf);
                            }


                        }
                        list.Add(orderAction);
                    }
                    SessionFactory dal;
                    IDbTransaction tr = Dal.BeginTransaction(out dal);
                    try
                    {
                        dal.SubmitNew(tr, ref dal, list);
                        dal.CommitTransaction(tr);
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

        public DataTable GetList(WhereClip where)
        {


            return Dal.From<ShopOrder>().Where(where).OrderBy(ShopOrder._.CreateDate.Desc)

                .ToDataTable();
        }

        public DataTable GetOrderStatus(string id, string accountID, out string err)
        {
            err = string.Empty;
            string orderAccount = Dal.From<ShopOrder>().Where(ShopOrder._.ID == id).Select(ShopOrder._.MemberID).ToScalar() as string;
            if (accountID.Equals(orderAccount))
            {
                return Dal.From<ShopOrderAction>().Where(ShopOrderAction._.OrderId == id).OrderBy(ShopOrderAction._.ActionDate)
                       .Select(ShopOrderAction._.ActionDate, ShopOrderAction._.ActionName, ShopOrderAction._.Remark, ShopOrderAction._.Username)
                       .ToDataTable();
            }
            else
            {
                err = "当前订单不是您的订单，不能查看订单状态";

                return null;
            }
        }

        public ShopOrder GetPayTypeEntity(string orderID)
        {
            return Dal.From<ShopOrder>().Select(ShopOrder._.PayTypeID).Where(ShopOrder._.ID == orderID).ToFirst<ShopOrder>();
        }

        public void PaySuccess(string orderID, string payJe)
        {

            ShopOrder order = Dal.From<ShopOrder>().Where(ShopOrder._.ID == orderID).Select(ShopOrder._.ID, ShopOrder._.PayStatus, ShopOrder._.PayMoney,
                ShopOrder._.OrderStatus).ToFirst<ShopOrder>();
            if (order.PayStatus == (int)PayStatus.未付款)
            {
                order.PayStatus = (int)PayStatus.已付款;
                OrderStatus oldOrderStatus = EnumPhrase.Phrase<OrderStatus>(order.OrderStatus);
                switch (oldOrderStatus)
                {
                    case OrderStatus.等待付款:
                    case OrderStatus.等待商家确认:
                        order.OrderStatus = (int)OrderStatus.等待商家发货;
                        break;
                    default:
                        break;
                }

                decimal payMoney = 0;
                if (decimal.TryParse(payJe, out payMoney))
                {
                    order.PayMoney = payMoney;
                }
                Dal.Submit(order);
                //生成订单动作日志
                ShopOrderAction orderAction = new ShopOrderAction()
                {

                    ID = Guid.NewGuid().ToString(),
                    ActionCode = ActionEnum.付款,
                    ActionName = ActionEnum.付款.ToString(),
                    Username = "支付宝",
                    OrderId = orderID,
                    ActionDate = DateTime.Now
                };
                Dal.Submit(orderAction);
            }
        }

        public int CancleOrder(string accountid, string orderid, out string error)
        {
            int result = 1;
            error = "取消成功";

            ShopOrder order = Dal.From<ShopOrder>().Select(ShopOrder._.ID, ShopOrder._.PayTypeID, ShopOrder._.PayStatus, ShopOrder._.ShipStatus, ShopOrder._.MemberID,
                ShopOrder._.RefundStatus, ShopOrder._.OrderStatus, ShopOrder._.IsReqCancle)
                  .Where(ShopOrder._.ID == orderid).ToFirst<ShopOrder>();

            if (order.MemberID != accountid)
            {
                error = "这不是您的订单，您不能取消";
                result = 0;
            }
            else
            {
                OrderStatus os = (OrderStatus)order.OrderStatus;
                switch (os)
                {
                    case OrderStatus.等待付款:
                    case OrderStatus.等待商家确认:
                    case OrderStatus.等待商家发货:

                        break;
                    case OrderStatus.已发货:
                    case OrderStatus.已收货:
                    case OrderStatus.取消退货:
                        error = "已提交客服人工处理,您也可以联系客服，给您带来不便敬请谅解";
                        result = 2;
                        break;
                    case OrderStatus.拒收:
                    case OrderStatus.作废:
                    case OrderStatus.发起退货申请:
                    case OrderStatus.商家不同意退换:
                    case OrderStatus.退货取货中:
                    case OrderStatus.商家已收货等待退款:
                    case OrderStatus.退货完成:
                    case OrderStatus.申请取消订单:
                    case OrderStatus.取消订单处理中:
                    case OrderStatus.取消订单:
                    case OrderStatus.完成:
                        error = "您的订单状态不能发起取消订单操作,您也可以联系客服，给您带来不便敬请谅解";
                        result = 0;
                        break;
                    default:
                        break;
                }
            }
            if (result == 1)
            {
                PayStatus ps = (PayStatus)order.PayStatus;
                if (ps != PayStatus.未付款)
                {
                    error = "已提交客服人工处理,您也可以联系客服，给您带来不便敬请谅解";
                    result = 2;
                }
            }
            if (result == 1)
            {
                //直接取消
                order.OrderStatus = (int)OrderStatus.取消订单;


            }
            else if (result == 2)
            {
                //人工干预
                order.IsReqCancle = true;
                order.ReqCancleOrderStatus = order.OrderStatus;
                order.OrderStatus = (int)OrderStatus.申请取消订单;
            }
            if (result > 0)
            {
                ActionEnum ae = ActionEnum.取消订单;
                if (result == 2)
                {
                    ae = ActionEnum.申请取消订单;
                }
                ShopOrderAction orderAction = new ShopOrderAction()
              {

                  ID = Guid.NewGuid().ToString(),
                  ActionCode = ae,
                  ActionName = ae.ToString(),
                  OrderId = orderid,
                  ActionDate = DateTime.Now,
                  Remark = error
              };
                Dal.Submit(orderAction, order);
            }
            return result;
        }

        /// <summary>
        /// 客户端主动发起的支付成功，只改成付款待确认
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool PaySuccess(string orderID, out string err)
        {
            err = string.Empty;
            bool result = true;
            ShopOrder order = Dal.From<ShopOrder>().Select(ShopOrder._.ID, ShopOrder._.PayStatus, ShopOrder._.OrderStatus).Where(ShopOrder._.ID == orderID).ToFirst<ShopOrder>();
            bool isChangeOrder = false;
            if (order.PayStatus == (int)PayStatus.未付款)
            {
                isChangeOrder = true;
                order.PayStatus = (int)PayStatus.待商家确认;

            }
            if (order.OrderStatus == (int)OrderStatus.等待付款)
            {
                isChangeOrder = true;
                order.OrderStatus = (int)OrderStatus.等待商家确认;

            }
            if (isChangeOrder)
            {
                Dal.Submit(order);
                ShopOrderAction orderAction = new ShopOrderAction()
                {

                    ID = Guid.NewGuid().ToString(),
                    ActionCode = ActionEnum.付款,
                    ActionName = ActionEnum.付款.ToString(),
                    OrderId = orderID,
                    ActionDate = DateTime.Now
                };
                Dal.Submit(orderAction);
            }
            return result;
        }

        public DataTable GetOrderDetail(string id)
        {
            return Dal.From<ShopOrderItem>().Where(ShopOrderItem._.OrderID == id)
                .Select(ShopOrderItem._.ProductCode,
ShopOrderItem._.ProductName,
ShopOrderItem._.AttributeVal,
ShopOrderItem._.ProductThumb,
ShopOrderItem._.Count,
ShopOrderItem._.IsHandsel,
ShopOrderItem._.ReturnCount,
ShopOrderItem._.Price,
ShopOrderItem._.TotalPrice,
ShopOrderItem._.ReturnMoney,
ShopOrderItem._.ProductTypeName,
ShopOrderItem._.BrandName,
ShopOrderItem._.Weight).ToDataTable();
        }

        public DataTable getDataTable(WhereClip where)
        {

            return Dal.From<ShopOrder>().Where(where).OrderBy(ShopOrder._.CreateDate.Desc)

                .ToDataTable();
        }

        public DataTable GetCanReturnDetail(string host, string orderID)
        {
            //   err = string.Empty;
            //string accoutnID=   Dal.From<ShopOrder>().Where(ShopOrder._.ID == orderID
            //       ).Select(ShopOrder._.MemberID).ToScalar() as string;
            //if (!accoutnID.Equals(userID))
            //{
            //    err = "当前订单不是您的订单，您不能退回";
            //}
            return Dal.From<ShopOrderItem>()

                .Where(ShopOrderItem._.OrderID == orderID)

                .Select(ShopOrderItem._.ID, ShopOrderItem._.OrderID, ShopOrderItem._.ProductID, ShopOrderItem._.ProductSKU,
            new ExpressionClip("ProductName+AttributeVal").Alias("ProductName"), ShopOrderItem._.Count, ShopOrderItem._.Price,
             new ExpressionClip("'" + host + "'" + "+ProductThumb").Alias("ProductThumb"), ShopOrderItem._.ReturnCount,
                 new ExpressionClip("Count-ReturnCount").Alias("CanReturnCount")
                )
                .OrderBy(ShopOrderItem._.Sequence.Desc)

                .ToDataTable();
        }

        public ShopReturnOrder GetReturnOrder(string host, string orderid, string userid, out string err)
        {
            err = string.Empty;
            WhereClip where = ShopReturnOrder._.ID == orderid;
            ShopReturnOrder order = Dal.From<ShopReturnOrder>()

                .Where(where)
                .Select(ShopReturnOrder._.ID, ShopReturnOrder._.OrderId, ShopReturnOrder._.CreatedDate,
                ShopReturnOrder._.Description, ShopReturnOrder._.UserId,
                ShopReturnOrder._.ReturnType,
                ShopReturnOrder._.Status,
                ShopReturnOrder._.RefuseReason)
                .ToFirst<ShopReturnOrder>();
            if (order == null)
            {
                err = "退货单不存在";
            }
            else if (order.UserId != userid)
            {
                err = "不是您的退货单，您不能查看";
            }
            else
            {

                List<ShopReturnOrderItem> orderItems = Dal.From<ShopReturnOrderItem>()

                    .Where(ShopReturnOrderItem._.ReturnOrderId == orderid)
                    .Select(ShopReturnOrderItem._.ID, ShopReturnOrderItem._.OrderId, ShopReturnOrderItem._.ReturnOrderId,
                    ShopReturnOrderItem._.SaleCount, ShopReturnOrderItem._.RequestQuantity, ShopReturnOrderItem._.ReturnCount,
                    ShopReturnOrderItem._.SellPrice,
                  ShopReturnOrderItem._.ProductCode,
                    ShopReturnOrderItem._.Name, new ExpressionClip("'" + host + "'" + "+ThumbnailsUrl").Alias("ThumbnailsUrl")).List<ShopReturnOrderItem>();

            }
            return order;
        }

        public List<ShopReturnOrder> GetMyReturnOrders(string host, ManagerUserInfo user, int queryPage, string queryStatusStr, string otherWhere, out string err)
        {
            err = string.Empty;
            WhereClip where = ShopReturnOrder._.UserId == user.ID && ShopReturnOrder._.HasDelete == false;

            if (!string.IsNullOrWhiteSpace(queryStatusStr))
            {
                int queryStatus = -1;
                if (int.TryParse(queryStatusStr, out queryStatus))
                {
                    if (queryStatus > -1)
                    {
                        where = where && ShopReturnOrder._.Status == queryStatus;
                    }

                }
                else
                {
                    where = where && ShopReturnOrder._.Status.In(queryStatusStr.Split(new char[] { ',' },
                         StringSplitOptions.RemoveEmptyEntries).ToArray());
                }
            }

            if (!string.IsNullOrWhiteSpace(otherWhere))
            {
                where = where && new WhereClip(otherWhere);
            }
            int recordcount = 0;
            int pageCount = 0;
            List<ShopReturnOrder> list = Dal.From<ShopReturnOrder>().Where(where)
                .Select(ShopReturnOrder._.ID, ShopReturnOrder._.OrderId, ShopReturnOrder._.CreatedDate,
                ShopReturnOrder._.Description,
                ShopReturnOrder._.ReturnType,
                ShopReturnOrder._.Status,
               ShopReturnOrder._.ReturnMoney.Alias("TotalPrice"),
                ShopReturnOrder._.RefuseReason)
                .OrderBy(ShopReturnOrder._.CreatedDate.Desc).ToDataTable(20, queryPage, ref pageCount, ref recordcount).ToList<ShopReturnOrder>();
            if (list.Count > 0)
            {
                List<string> orderIDS = list.Select(p => p.ID).ToList();
                List<ShopReturnOrderItem> orderItems = Dal.From<ShopReturnOrderItem>()
                    .Where(ShopReturnOrderItem._.ReturnOrderId.In(orderIDS))
                    .Select(ShopReturnOrderItem._.ID, ShopReturnOrderItem._.OrderId, ShopReturnOrderItem._.ReturnOrderId,
                    ShopReturnOrderItem._.SaleCount, ShopReturnOrderItem._.RequestQuantity, ShopReturnOrderItem._.ReturnCount,
                    ShopReturnOrderItem._.SellPrice,  
                  ShopReturnOrderItem._.ProductCode,
                    ShopReturnOrderItem._.Name, new ExpressionClip("'" + host + "'" + "+ThumbnailsUrl").Alias("ThumbnailsUrl")
                    ).List<ShopReturnOrderItem>();
                foreach (ShopReturnOrder item in list)
                {
                    item.OrderItems = orderItems.Where(p => p.ReturnOrderId == item.ID).OrderBy(p => p.ProductCode).ToList();
                }
            }
            return list;
        }
    }


}
