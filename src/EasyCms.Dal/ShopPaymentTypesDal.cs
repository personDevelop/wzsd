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

            int i = Dal.Delete<ShopPaymentTypes>(id);
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除分类";
            }
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



    }

}
