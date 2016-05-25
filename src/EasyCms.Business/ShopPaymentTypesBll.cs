using EasyCms.Dal;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common;
using EasyCms.Model.Ali;

namespace EasyCms.Business
{
    public class ShopPaymentTypesBll
    {
        ShopPaymentTypesDal Dal = new ShopPaymentTypesDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopPaymentTypes item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }

        public bool Exit(string ID, string ParentID, string RecordStatus, string val, bool IsCode)
        {
            return Dal.Exit(ID, ParentID, RecordStatus, val, IsCode);

        }

        public ShopPaymentTypes GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }



        public DataTable GetPayTypeForSelecte(string ShippingModeId)
        {
            return Dal.GetPayTypeForSelecte(ShippingModeId);
        }

        public DataTable GetPayType(int type)
        {
            return Dal.GetPayType(type);
        }


        public bool GenerPayPara(string orderID, out string error)
        {

            return Dal.GenerPayPara(orderID, out   error);
        }

        public bool GenerPayPara(PayPara payPara, out string error)
        {

            return Dal.GenerPayPara(payPara, out   error);
        }

        public string PayByPc(string orderID, out string msg)
        {
            return Dal.PayByPc(orderID, out msg);
        }
    }
}
