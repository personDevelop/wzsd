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
    public class ShopShippingTypeDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("ShopShippingType", "ID", id, out error);
            return error;
        }

        public int Save(ShopShippingType item, List<string> producTypeList, List<ShopRegionFright> list)
        {

            /*先删支付方式关联表  
             再删地区表
             */
            if (string.IsNullOrWhiteSpace(item.ID))
            {
                item.ID = Guid.NewGuid().ToString();
            }
            ShopShippingPayment Deletessp = new ShopShippingPayment() { RecordStatus = StatusType.delete, Where = ShopShippingPayment._.ShippingModeId == item.ID };

            List<ShopShippingPayment> sspList = new List<ShopShippingPayment>();
            foreach (var producType in producTypeList)
            {
                sspList.Add(new ShopShippingPayment() { ID = Guid.NewGuid().ToString(), PaymentModeId = producType, ShippingModeId = item.ID });
            }
            ShopRegionFright Deletesrf = new ShopRegionFright() { RecordStatus = StatusType.delete, Where = ShopRegionFright._.ShippingModeId == item.ID };


            foreach (var producType in list)
            {
                producType.ID = Guid.NewGuid().ToString();
                producType.ShippingModeId = item.ID;
                if (producType.RegionID == 0)
                {
                    throw new Exception("地区必填");
                }
            }
            IDbTransaction tr = null;
            Sharp.Data.SessionFactory dal = null;
            try
            {
                

                tr = Dal.BeginTransaction(out dal);
                dal.SubmitNew(tr,ref dal, item );
                dal.SubmitNew(tr, ref dal, Deletessp);
                dal.SubmitNew(tr, ref dal, Deletesrf);
                dal.SubmitNew(tr, ref dal, sspList);
                dal.SubmitNew(tr, ref dal, list);
                dal.CommitTransaction(tr);
                return 1;

            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
                throw;
            }

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<ShopShippingType>().Select(ShopShippingType._.ID,   ShopShippingType._.Name ).OrderBy(ShopShippingType._.DisplaySequence).ToDataTable();
            }
            else
                return Dal.From<ShopShippingType>().OrderBy(ShopShippingType._.DisplaySequence).ToDataTable();
        }
        public bool Exit(string ID,  string RecordStatus, string val )
        {
            WhereClip where =  ShopShippingType._.Name == val;
           
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopShippingType._.ID != ID;

            }
            return !Dal.Exists<ShopShippingType>(where);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount )
        {
            int pageCount = 0;
            
                return Dal.From<ShopShippingType>(  ).OrderBy(ShopShippingType._.DisplaySequence)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }
       
        public ShopShippingType GetEntity(string id)
        {
         
            return Dal.Find<ShopShippingType>(id);
        }


       

        public DataTable GetShopRegionFrightList(string Modleid)
        {
            return Dal.From<ShopRegionFright>().Join<AdministrativeRegions>(ShopRegionFright._.RegionID == AdministrativeRegions._.ID)


                .Where(ShopRegionFright._.ShippingModeId == Modleid).OrderBy(ShopRegionFright._.RegionID)

                .Select(ShopRegionFright._.ID.All, AdministrativeRegions._.Name.Alias("RegionName")).ToDataTable();
        }
    }

     
}
