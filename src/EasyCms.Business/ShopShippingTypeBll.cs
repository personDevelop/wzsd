using EasyCms.Dal;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common;
using AliPayCommon;

namespace EasyCms.Business
{
    public class ShopShippingTypeBll
    {
        ShopShippingTypeDal Dal = new ShopShippingTypeDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopShippingType item, List<string> producTypeList, List<ShopRegionFright> list)
        {
            return Dal.Save(item, producTypeList, list);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount)
        {
            return Dal.GetList(pagenum, pagesize, ref recordCount);
        }
        public bool Exit(string ID, string RecordStatus, string val)
        {
            return Dal.Exit(ID, RecordStatus, val);

        }


        public ShopShippingType GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }



        public DataTable GetShopRegionFrightList(string modleid)
        {
            return Dal.GetShopRegionFrightList(modleid);
        }

        public AliPayConfig GetPayType(string orderID, out string error)
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
