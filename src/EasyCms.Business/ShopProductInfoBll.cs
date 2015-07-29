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
    public class ShopProductInfoBll
    {
        ShopProductInfoDal Dal = new ShopProductInfoDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ShopProductInfo item, List<BaseEntity> list, List<ShopProductAttributes> spa, List<ShopProductSKU> listSku, List<ShopProductSKUInfo> listSkuInfo)
        {
            return Dal.Save(item, list, spa, listSku, listSkuInfo);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount, IsForSelected);
        }

        public ShopProductInfo GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }





        public bool Exit(string ID, string RecordStatus, string val)
        {
            return Dal.Exit(ID, RecordStatus, val);

        }

        public DataTable GetAttrWithProdcutVal(string ptypeid, string productID)
        {
            return Dal.GetAttrWithProdcutVal(ptypeid, productID);

        }



        public DataSet GetGgWithProdcutVal(string ptypeid, string productID)
        {
            return Dal.GetGgWithProdcutVal(ptypeid, productID);
        }



        public ShopProductInfo GetSaleEntity(string id,string host)
        {
            return Dal.GetSaleEntity(id,host);
        }

        public DataTable GetProductsByCategory(string categoryID, int pageindex,string orderby,string host, ref int pageCount, ref int recordCount)
        {
            return Dal.GetProductsByCategory(categoryID, pageindex, orderby, host, ref   pageCount, ref   recordCount);
        }

        public DataTable GetProductByWhere(WhereClip where, int pageNum,string host, ref int pageCount, ref int recordCount)
        {
            return Dal.GetProductByWhere(where, pageNum, host, ref   pageCount, ref   recordCount);
        }

        public int SaveStation(ShopProductStationMode s)
        {
            return Dal.SaveStation(s);
        }

        public DataTable GetProductsByStation(int id, int pageIndex, int pageSize, string host, ref int pagecount, ref int recordCount)
        {
            return Dal.GetProductsByStation(id, pageIndex, pageSize,host, ref   pagecount, ref   recordCount);
        }

        public int DeleteStation(string StationID)
        {
            return Dal.DeleteStation(StationID);
        }

        public DataSet GetProductsByMutilStation(string id, int pagesize, string host, out string error)
        {
            return Dal.GetProductsByMutilStation(id, pagesize,host, out   error);
        }
    }
}
