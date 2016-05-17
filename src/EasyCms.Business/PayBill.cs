using AliPayCommon;
using EasyCms.Dal;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCms.Business
{
    public class PayBill
    {
        public AliPayConfig GetAliPayConfig(string orderID, out string error)
        {
            AliPayConfig result = null;
            error = string.Empty;
            ShopOrder order = new ShopOrderDal().GetPayTypeEntity(orderID);
            if (order == null)
            {
                error = "没有找到相应的订单" + orderID;

            }
            else
            {
                if (string.IsNullOrWhiteSpace(order.PayTypeID))
                {
                    error = "没有找到相应的订单付款方式" + orderID;
                }
                else
                {
                    ShopPaymentTypes ptype = new ShopPaymentTypesDal().GetEntity(order.PayTypeID);
                    if (ptype == null)
                    {
                        error = "没有找到相应的付款方式" + order.PayTypeID;
                    }
                    else
                    {
                        result = new AliPayConfig()
                        {
                            Partner = ptype.Partner,
                            PublicKey = ptype.PublicKey,
                            SecretKey = ptype.SecretKey
                        };


                    }

                }
            }
            return result;
        }
    }
}
