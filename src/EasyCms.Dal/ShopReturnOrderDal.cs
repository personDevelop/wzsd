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



        public DataTable GetReturnDetail(string returnOrderNo)
        {
            return Dal.From<ShopReturnOrderItem>().Where(ShopReturnOrderItem._.ReturnOrderId == returnOrderNo).ToDataTable();
        }

        public int ReturnOrder(string accountid, ShopReturnOrder ro, out string error)
        {
            int result = 0;
            error = string.Empty;
            //先获取其订单状态
            ShopOrder order = Dal.Find<ShopOrder>(ro.OrderId);
            if (order.MemberID != accountid)
            {
                error = "不是您的订单，您不能退回";

            }
            else
            {
                OrderStatus os = (OrderStatus)order.OrderStatus;
                if (os != OrderStatus.完成 || os != OrderStatus.已发货 || os != OrderStatus.已收货)
                {
                    error = "您的订单状态为"+os+"，您不能退回";
                }else
                {}

            }
            return result;
        }
    }


}
