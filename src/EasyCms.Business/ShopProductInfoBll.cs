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

        public int Save(ShopProductInfo item, List<BaseEntity> list, List<ShopProductAttributes> spa, List<ShopProductSKU> listSku, List<ShopProductSKUInfo> listSkuInfo, List<int> StationModeList)
        {
            return Dal.Save(item, list, spa, listSku, listSkuInfo,   StationModeList);
        }

      
        public DataTable GetList(string categoryID, string Name, int pagenum, int pagesize, ref int recordCount )
        {
            return Dal.GetList(  categoryID, Name, pagenum, pagesize, ref   recordCount );
        }
        public DataTable GetRelationList(string productID, bool IsHasRelation, string categoryID, string Name, int pagenum, int pagesize, ref int recordCount)
        {

            return Dal.GetRelationList(productID,   IsHasRelation, categoryID, Name, pagenum, pagesize, ref recordCount);
        }

        public string AddRelation(string productID, string RlationProductIDs, bool isDoubleRelation)
        {
            return Dal.AddRelation(productID, RlationProductIDs, isDoubleRelation);
        }

        public string RemoveRelation(string productID, string RlationProductIDs )
        {
            return Dal.RemoveRelation(productID, RlationProductIDs );
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



        public ShopSaleProductInfo GetSaleEntity(string id, string host)
        {
            return Dal.GetSaleEntity(id, host);
        }

        public DataTable GetProductsByCategory(string categoryID, int pageindex, string orderby, string host, ref int pageCount, ref int recordCount)
        {
            return Dal.GetProductsByCategory(categoryID, pageindex, orderby, host, ref   pageCount, ref   recordCount);
        }
        public DataTable GetTravalList(string categoryID, int pageindex, string orderby, string host, ref int pageCount, ref int recordCount)
        {
            return Dal.GetTravalList(categoryID, pageindex, orderby, host, ref   pageCount, ref   recordCount);
        }

        public DataTable GetProductByWhere(WhereClip where, int pageNum, string host, ref int pageCount, ref int recordCount)
        {
            return Dal.GetProductByWhere(where, pageNum, host, ref   pageCount, ref   recordCount);
        }

        public int SaveStation(ShopProductStationMode s)
        {
            return Dal.SaveStation(s);
        }

        public DataTable GetProductsByStation(int id, int pageIndex, int pageSize, string host, ref int pagecount, ref int recordCount)
        {
            return Dal.GetProductsByStation(id, pageIndex, pageSize, host, ref   pagecount, ref   recordCount);
        }
        public DataTable GetProductsByStation(string categoryid, int pageIndex, int pageSize, string host, ref int pagecount, ref int recordCount)
        {
            return Dal.GetProductsByStation(categoryid, pageIndex, pageSize, host, ref   pagecount, ref   recordCount);
        }
        public int DeleteStation(string StationID)
        {
            return Dal.DeleteStation(StationID);
        }

        public DataSet GetProductsByMutilStation(string id, int pagesize, string host, out string error)
        {
            return Dal.GetProductsByMutilStation(id, pagesize, host, out   error);
        }

        public List<ShopExtendWithValue> GetProductGgInfo(string id, out string error)
        {
            return Dal.GetProductGgInfo(id, out   error);
        }

        public DataTable GetProductSkuInfo(string id, out string err)
        {
            return Dal.GetProductSkuInfo(id, out   err);
        }

        public string IsSJOperator(string ids, int opcode)
        {
            return Dal.IsSJOperator(ids, opcode);
        }

        public DataTable GetSkuByProductID(string id, out string err)
        {
            return Dal.GetSkuByProductID(id, out   err);
        }

        public DataTable GetProduct(int pageIndex, int pagesize, ref int pagecount, ref int recordCount)
        {
            return Dal.GetProduct(pageIndex, pagesize, ref   pagecount, ref   recordCount);
        }

        public DataTable GetProductsBySearchKey(string searchKey, int pageIndex, string other, string host, ref int pagecount, ref int recordCount)
        {
            return Dal.GetProductsBySearchKey(searchKey, pageIndex, other, host, ref   pagecount, ref   recordCount);
        }

        public int AccCommentCount(string ProductId, int CommentCount)
        {
            return Dal.AccCommentCount(ProductId,   CommentCount);
         
        }

        public ProductLink GetProductLink(string id, string host)
        {
            return Dal.GetProductLink(id, host);
        }

        public ShopCountProducnt GetShopCountProducnt(string shopCountProducntID)
        {
            throw new NotImplementedException();
        }

        public void SaveShopCountProducnt(ShopCountProducnt p)
        {
            throw new NotImplementedException();
        }
    }
}
