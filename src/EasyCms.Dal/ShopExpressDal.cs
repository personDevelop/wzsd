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
    public class ShopExpressDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;

            Dal.Delete("ShopExpress", "ID", id, out error);
            return error;
        }

        public int Save(ShopExpress item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<ShopExpress>().Select(ShopExpress._.ID, ShopExpress._.Code, ShopExpress._.Name)
                    .Where(ShopExpress._.IsEnable == true)

                    .OrderBy(ShopExpress._.Code).ToDataTable();
            }
            else
                return Dal.From<ShopExpress>().Where(ShopExpress._.IsEnable == true).OrderBy(ShopExpress._.Code).ToDataTable();
        }
        public bool Exit(string ID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = ShopExpress._.Code == val;
            }
            else
            {
                where = ShopExpress._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopExpress._.ID != ID;

            }
            return !Dal.Exists<ShopExpress>(where);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<ShopExpress>().Select(ShopExpress._.ID, ShopExpress._.Code, ShopExpress._.Name).OrderBy(ShopExpress._.Code).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<ShopExpress>().OrderBy(ShopExpress._.Code)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public ShopExpress GetEntity(string id)
        {
            return Dal.Find<ShopExpress>(id);
        }


    }


}
