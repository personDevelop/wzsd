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
    public class ShopPaymentTypesDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {

            string error = "";
            Dal.Delete("ShopPaymentTypes", "ID", id, out error);
            return error;
        }

        public int Save(ShopPaymentTypes item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<ShopPaymentTypes>().Select(ShopPaymentTypes._.ID, ShopPaymentTypes._.Name).OrderBy(ShopPaymentTypes._.DisplaySequence).ToDataTable();
            }
            else
            {

                DataTable dt = Dal.From<ShopPaymentTypes>().OrderBy(ShopPaymentTypes._.DisplaySequence).ToDataTable();

                return dt;
            }

        }
        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = ShopPaymentTypes._.Name == val;
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopPaymentTypes._.ID != ID;

            }
            return !Dal.Exists<ShopPaymentTypes>(where);
        }

        public ShopPaymentTypes GetEntity(string id)
        {
            return Dal.Find<ShopPaymentTypes>(id);
        }




        public DataTable GetPayType()
        {
            return Dal.From<ShopPaymentTypes>().Where(ShopPaymentTypes._.IsEnable == true && ShopPaymentTypes._.DrivePath.Contains("1"))
                .OrderBy(ShopPaymentTypes._.DisplaySequence)
                .Select(ShopPaymentTypes._.ID, ShopPaymentTypes._.Gateway, ShopPaymentTypes._.MerchantCode,
               ShopPaymentTypes._.SecretKey, ShopPaymentTypes._.Partner, 
                ShopPaymentTypes._.ShortName).ToDataTable();
        }

        internal string GetPayTypeName(string payTypeID, bool isCashOnDelivery)
        {
            if (isCashOnDelivery)
            {
                return "货到付款";
            }
            return Dal.From<ShopPaymentTypes>().Where(ShopPaymentTypes._.ID == payTypeID).Select(ShopPaymentTypes._.Name)
                .ToScalar() as string;
        }
    }

}
