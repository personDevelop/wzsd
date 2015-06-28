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
    public class ShopProductTypeBll
    {
        ShopProductTypeDal Dal = new ShopProductTypeDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopProductType item, List<string> brandList)
        {
            return Dal.Save(item, brandList);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount, IsForSelected);
        }
        public bool Exit(string ID, string RecordStatus, string val, bool IsCode)
        {
            return Dal.Exit(ID, RecordStatus, val, IsCode);

        }

        public ShopProductType GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

        public List<ShopProductType> GetListWithBrand(string brandid, StatusType statusType)
        {
            return Dal.GetListWithBrand(brandid, statusType);
        }
        public List<ShopBrandInfo> GetListWithProductType(string ptid, StatusType statusType)
        {
            return Dal.GetListWithProductType(ptid, statusType);
        }

        public DataTable GetAttrList(  string ptypeid, bool isGg )
        {
            return Dal.GetAttrList(  ptypeid, isGg );
        }

        public ShopExtendInfo GetShopExtendInfo(string id)
        {
            return Dal.GetShopExtendInfo(id);
        }

        public int SaveShopExtendInfo(ShopExtendInfo p)
        {
            return Dal.SaveShopExtendInfo(p);
        }

        public DataTable GetValList(string attriID, int page, int pagesize, ref int recordCount)
        {
            return Dal.GetValList(attriID, page, pagesize, ref   recordCount);
        }

        public ShopExtendInfoValue GetAttrVal(string p)
        {
            return Dal.GetAttrVal(p);
        }

        public int SaveAttrVal(ShopExtendInfoValue p)
        {
            return Dal.SaveAttrVal(p);
        }

        public ShopExtendInfoValue GetAttrEntity(string id)
        {
            return Dal.GetAttrEntity(id);
        }

        public int DeleteAttrVal(string id)
        {
            return Dal.DeleteAttrVal(id);
        }

        public int Save(List<ShopExtendInfoValue> list)
        {
            return Dal.Save(list);
        }
    }
}
