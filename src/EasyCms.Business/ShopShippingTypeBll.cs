using EasyCms.Dal;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common;

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
            return Dal.Save(item,   producTypeList,  list);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount )
        {
            return Dal.GetList(pagenum, pagesize, ref recordCount );
        }
        public bool Exit(string ID,  string RecordStatus, string val )
        {
            return Dal.Exit(ID,   RecordStatus, val );

        }

       
        public ShopShippingType GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

 

        public DataTable GetShopRegionFrightList(string modleid)
        {
            return Dal.GetShopRegionFrightList(modleid);
        }

       
    }
}
