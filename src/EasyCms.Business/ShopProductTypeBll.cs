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

        public DataTable GetAttrList(int pagenum, int pagesize, string ptypeid, bool isGg, ref int recordCount)
        {
            return Dal.GetAttrList(pagenum, pagesize, ptypeid, isGg, ref   recordCount);
        }
    }
}
