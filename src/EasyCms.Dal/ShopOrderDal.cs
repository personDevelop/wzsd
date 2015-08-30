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




        public ShopOrderModel CreateOrder(List<OrderItem> list, out string err)
        {
            err = string.Empty;
            List<OrderItem> listActivty = list.Where(p => p.OrderType > 0 && !string.IsNullOrWhiteSpace(p.OrderResId)).ToList();
            foreach (var item in listActivty)
            {
                //对应参与活动的商品 查看其是否已过期,后续做完商品促销活动后再补充

            }
            //获取商品较详细信息 
            List<View_ProductInfoBySkuid> orderItemList = GetProductWithOrder(list, out err);
            return new ShopOrderModel();

        }
        /// <summary>
        /// 检测是否还在
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<View_ProductInfoBySkuid> GetProductWithOrder(List<OrderItem> list, out string err)
        {
            err = string.Empty;
            List<View_ProductInfoBySkuid> Viewlist = new List<View_ProductInfoBySkuid>();
            int i = 1;
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
                    err = string.Format("您购买的第{0}条商品{1}已下架", i, v.Name);
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

                Viewlist.Add(v);
                i++;

            }
            return Viewlist;

        }
    }


}
