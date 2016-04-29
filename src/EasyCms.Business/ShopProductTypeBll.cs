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
        public DataTable GetList(string Name, int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(  Name, pagenum, pagesize, ref   recordCount, IsForSelected);
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

        public DataTable GetAttrList(string host, string ptypeid, bool isGg)
        {
            return Dal.GetAttrList(host, ptypeid, isGg);
        }

        public string SaveExtendType(string iDs, string ptypeID)
        {
            return Dal.SaveExtendType(iDs,   ptypeID);
        }

        public string DeleteExtend(string id)
        {
            return Dal.DeleteExtend(id);
        }

        public List<ShopProductStationMode> GetStationMode(string productID, StatusType status)
        {
            return Dal.GetStationMode(  productID,   status);
        }

        public DataTable GetAllAttrList(string host, string ptypeid)
        {
            return Dal.GetAllAttrList(host, ptypeid,false,true);
        }
    }
}
