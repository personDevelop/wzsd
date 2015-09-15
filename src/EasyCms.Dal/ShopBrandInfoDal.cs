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
    public class ShopBrandInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = "";
            Dal.Delete("ShopBrandInfo", "ID", id, out error);
            return error;
        }

        public int Save(ShopBrandInfo item, List<string> producTypeList)
        {
            SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                dal.Delete<ShopProductTypeAndBrand>(ShopProductTypeAndBrand._.BrandId == item.ID, tr);
                if (producTypeList.Count > 0)
                {
                    List<ShopProductTypeAndBrand> list = new List<ShopProductTypeAndBrand>();
                    foreach (var ptid in producTypeList)
                    {


                        ShopProductTypeAndBrand ptb = new ShopProductTypeAndBrand();
                        ptb.ID = Guid.NewGuid().ToString();
                        ptb.BrandId = item.ID;
                        ptb.ProductTypeId = ptid;
                        list.Add(ptb);
                    }
                    dal.SubmitNew(tr, ref dal, list);
                }
                dal.SubmitNew(ref dal, item);
                dal.CommitTransaction(tr);
                return 1;
            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
                return -1;

            }


        }

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<ShopBrandInfo>().Select(ShopBrandInfo._.ID, ShopBrandInfo._.Name).OrderBy(ShopBrandInfo._.OrderNo).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<ShopBrandInfo>().OrderBy(ShopBrandInfo._.OrderNo)
                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public bool Exit(string ID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = ShopBrandInfo._.Code == val;
            }
            else
            {
                where = ShopBrandInfo._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopBrandInfo._.ID != ID;

            }
            return !Dal.Exists<ShopBrandInfo>(where);
        }

        public ShopBrandInfo GetEntity(string id)
        {
            return Dal.Find<ShopBrandInfo>(id);

        }



    }

}
