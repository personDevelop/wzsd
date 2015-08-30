﻿using EasyCms.Model;
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
    public class ShopProductInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            return "";
        }

        public int Save(ShopProductInfo item, List<BaseEntity> list, List<ShopProductAttributes> spas, List<ShopProductSKU> listSku, List<ShopProductSKUInfo> listSkuInfo)
        {
            List<string> deleteShopProductAttributesIDS = new List<string>();
            foreach (ShopProductAttributes spa in spas)
            {
                if (string.IsNullOrEmpty(spa.ValueId))
                {
                    //直接填写类型属性
                    ShopProductAttributes oldspa = Dal.Find<ShopProductAttributes>(ShopProductAttributes._.ProductId == item.ID && ShopProductAttributes._.AttributeId == spa.AttributeId);
                    if (oldspa == null)
                    {
                        //未保存过该属性值
                        string valid = Guid.NewGuid().ToString();
                        ShopExtendInfoValue spev = new ShopExtendInfoValue()
                        {
                            AttributeId = spa.AttributeId,
                            DisplaySequence = 0,
                            ValueStr = spa.ValueStr,
                            ID = valid
                        };
                        list.Add(spev);
                        spa.ValueId = valid;
                    }
                    else
                    {
                        ShopExtendInfoValue spev = Dal.Find<ShopExtendInfoValue>(oldspa.ValueId);
                        spev.ValueStr = spa.ValueStr;
                        list.Add(spev);
                        spa.RecordStatus = StatusType.other;//不再处理该条数据
                    }
                }
                else
                { deleteShopProductAttributesIDS.Add(spa.ValueId); }
            }
            item.IsEnableSku = listSkuInfo.Count > 0;
            //处理sku信息，保留skuid不变化
            if (item.RecordStatus == StatusType.update && item.IsEnableSku)
            {
                //获取其旧的sku信息
                List<ShopProductSKUInfo> oldSkuInfoList = Dal.From<ShopProductSKUInfo>().Where(ShopProductSKUInfo._.ProductId == item.ID).List<ShopProductSKUInfo>();
                foreach (ShopProductSKUInfo newSku in listSkuInfo)
                {
                    if (oldSkuInfoList.Exists(p => p.Name == newSku.Name))
                    {
                        ShopProductSKUInfo oldSku = oldSkuInfoList.Find(p => p.Name == newSku.Name);
                        newSku.ID = oldSku.ID;
                    }
                }

            }
            SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                dal.Delete<ShopProductCategory>(ShopProductCategory._.ProductID == item.ID, tr);
                if (deleteShopProductAttributesIDS.Count > 0)
                {
                    dal.Delete<ShopProductAttributes>(ShopProductAttributes._.ProductId == item.ID && ShopProductAttributes._.ValueId.In(deleteShopProductAttributesIDS), tr);
                }
                if (item.RecordStatus == StatusType.update)
                {
                    dal.Delete<ShopProductSKUInfo>(ShopProductSKUInfo._.ProductId == item.ID, tr);
                    dal.Delete<ShopProductSKU>(ShopProductSKU._.ProductId == item.ID, tr);
                }
                dal.SubmitNew(tr, ref dal, item);
                dal.SubmitNew(tr, ref dal, list);
                dal.SubmitNew(tr, ref dal, spas);
                dal.SubmitNew(tr, ref dal, listSku);
                dal.SubmitNew(tr, ref dal, listSkuInfo);
                dal.CommitTransaction(tr);
                return 1;
            }
            catch (Exception ex)
            {
                dal.RollbackTransaction(tr);
                throw;
                return -1;
            }


        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<ShopProductInfo>().Select(ShopProductInfo._.ID, ShopProductInfo._.BrandId, ShopProductInfo._.Code, ShopProductInfo._.Name).OrderBy(ShopProductInfo._.AddedDate.Desc).ToDataTable();
            }
            else
                return Dal.From<ShopProductInfo>().OrderBy(ShopProductInfo._.AddedDate.Desc).ToDataTable();
        }

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<ShopProductInfo>().Select(ShopProductInfo._.ID, ShopProductInfo._.BrandId, ShopProductInfo._.Code, ShopProductInfo._.Name)
                    .OrderBy(ShopProductInfo._.AddedDate.Desc).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<ShopProductInfo>()
                    .Join<ShopProductType>(ShopProductType._.ID == ShopProductInfo._.TypeId, JoinType.leftJoin)
                    .Join<ShopBrandInfo>(ShopBrandInfo._.ID == ShopProductInfo._.BrandId, JoinType.leftJoin)
                    .Select(ShopProductInfo._.ID.All, ShopProductType._.Name.Alias("TypeName"), ShopBrandInfo._.Name.Alias("BrandName"))
                    .OrderBy(ShopProductInfo._.AddedDate.Desc)
                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public ShopProductInfo GetEntity(string id)
        {
            ShopProductInfo p = Dal.Find<ShopProductInfo>(id);
            List<ShopCategory> list = Dal.From<ShopCategory>().Join<ShopProductCategory>(ShopCategory._.ID == ShopProductCategory._.CategoryID && ShopProductCategory._.ProductID == p.ID)
                   .Select(ShopCategory._.ID, ShopCategory._.Name).List<ShopCategory>();
            foreach (ShopCategory item in list)
            {
                if (!string.IsNullOrWhiteSpace(p.ShopCategoryID))
                {
                    p.ShopCategoryID += ",";
                    p.ShopCategoryName += ",";
                }
                p.ShopCategoryID += item.ID;
                p.ShopCategoryName += item.Name;
            }
            return p;
        }

        public bool Exit(string ID, string RecordStatus, string val)
        {
            WhereClip where = ShopProductInfo._.Code == val;

            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopProductInfo._.ID != ID;

            }
            return !Dal.Exists<ShopProductInfo>(where);
        }

        public DataTable GetAttrWithProdcutVal(string ptypeid, string productID)
        {
            return Dal.From<ShopExtendInfo>().Join<ShopExtendInfoValue>(ShopExtendInfo._.ID == ShopExtendInfoValue._.AttributeId).Join
                    <ShopProductAttributes>(ShopExtendInfo._.ID == ShopProductAttributes._.AttributeId
              && ShopProductAttributes._.ValueId == ShopExtendInfoValue._.ID && ShopProductAttributes._.ProductId == productID, JoinType.leftJoin)
              .Select(ShopExtendInfo._.ID, ShopExtendInfo._.Name, ShopExtendInfo._.ShowType
              , ShopExtendInfoValue._.ID.Alias("ExtendInfoValueID"), ShopExtendInfoValue._.ValueStr, ShopExtendInfoValue._.DisplaySequence,
           new ExpressionClip(" case when ShopProductAttributes.ValueId is null then 0 else 1 end HasValue"))

              .Where(ShopProductAttributes._.ProductId == productID && ShopExtendInfo._.ProductTypeID == ptypeid && ShopExtendInfo._.UsageMode < 2)

              .OrderBy(ShopExtendInfo._.ID, ShopExtendInfo._.DisplayOrder, ShopExtendInfoValue._.DisplaySequence).ToDataTable();
        }



        public DataSet GetGgWithProdcutVal(string ptypeid, string productID)
        {

            DataSet ds =
              Dal.From<ShopExtendInfo>().Join<ShopExtendInfoValue>(ShopExtendInfo._.ID == ShopExtendInfoValue._.AttributeId, JoinType.leftJoin)
                .Join<ShopProductSKU>(ShopExtendInfoValue._.ID == ShopProductSKU._.ValueId && ShopProductSKU._.ProductId == productID, JoinType.leftJoin)
             .Select(ShopExtendInfo._.ID.All,
              ShopExtendInfoValue._.ID.Alias("ExtendInfoValueID"), ShopExtendInfoValue._.ValueStr, ShopExtendInfoValue._.DisplaySequence, ShopExtendInfoValue._.ImageID, ShopExtendInfoValue._.Note,
               new ExpressionClip(" case when ShopProductSKU.ID is null then 0 else 1 end HasValue"))
             .Where(ShopExtendInfo._.ProductTypeID == ptypeid && ShopExtendInfo._.UsageMode > 1)
             .OrderBy(ShopExtendInfo._.ID, ShopExtendInfo._.DisplayOrder, ShopExtendInfoValue._.DisplaySequence).Distinct()
             .ToDataSet();
            string tempTable = "temp" + Guid.NewGuid().ToString().Replace("-", "");
            Dictionary<string, object> dic = new Dictionary<string, object>();
            Dal.FromStoredProcedure("PIVOTRowConvertCol").AddInputParameter("tableName", "ShopProductSKU,ShopExtendInfo,ShopExtendInfoValue")
                       .AddInputParameter("groupColumn", "ShopProductSKU.ID SKUID")
                       .AddInputParameter("pivotgroupColumn", "SKUID")
                       .AddInputParameter("row2column", "ShopExtendInfo.Name")
                       .AddInputParameter("pivotrow2column", "Name")
                       .AddInputParameter("row2columnValue", "ShopExtendInfoValue.AttributeId+'|'+ShopExtendInfoValue.id+'|'+ShopExtendInfoValue.ValueStr as ValueStr")
                        .AddInputParameter("pivotrow2columnValue", "ValueStr")
                         .AddInputParameter("sql_where", "where  ShopExtendInfo.ProductTypeID='" + ptypeid + "' and ShopProductSKU.ProductId='" + productID + "'  and ShopProductSKU.ValueId = ShopExtendInfoValue.ID and ShopExtendInfoValue.AttributeId =  ShopExtendInfo.ID")
                           .AddInputParameter("orderby", "DisplayOrder")
                           .AddInputParameter("tempTableName", tempTable)
                           .AddOutputParameter("result", 1, DbType.Int32)
                      .ToScalar(out dic);
            if (((int)dic["result"]) > 0)
            {


                DataTable dt = Dal.FromCustomSql("select " + tempTable + @".*,  SKU AS 商品编号, SalePrice AS 售价, MarketPrice AS 市场价, CostPrice AS 成本价, Weight AS 重量, Stock AS 库存, MaxAlertStock AS 最大库存, 
                      MinAlertStock AS 最低库存, IsSale AS 上架, IsDefault AS 默认商品
 from " + tempTable + " join ShopProductSKUInfo on SKURelationID=SKUID where ProductId='"
                      + productID + "'  order by OrderNo").ToDataTable();
                dt.TableName = tempTable;

                ds.Tables.Add(dt.Copy());

                //删除临时表
                Dal.FromCustomSql("drop table " + tempTable).ExecuteNonQuery();
            }
            return ds;

        }

        public ShopSaleProductInfo GetSaleEntity(string id, string host)
        {
            ShopSaleProductInfo p = Dal.From<ShopProductInfo>()
                .Join<ShopProductType>(ShopProductInfo._.TypeId == ShopProductType._.ID)
                .Where(ShopProductInfo._.ID == id && ShopProductInfo._.SaleStatus == 1).ToFirst<ShopSaleProductInfo>();
            if (p != null)
            {

                //获取其图像
                p.dtImg = Dal.From<AttachFile>().Where(AttachFile._.RefID == p.ID).Select(AttachFile.GetFilePath(host)).OrderBy(AttachFile._.OrderNo).ToDataTable();
                //获取其扩张属性
                p.dtAttr = Dal.From<ShopExtendInfo>().Join<ShopProductAttributes>(ShopProductAttributes._.AttributeId == ShopExtendInfo._.ID && ShopProductAttributes._.ProductId == id)
                    .Join<ShopExtendInfoValue>(ShopProductAttributes._.ValueId == ShopExtendInfoValue._.ID)
                    .Select(
                    ShopExtendInfo._.Name.Alias("AttrName"), ShopExtendInfoValue._.ValueStr.Alias("AttrValue")).ToDataTable();
                //获取其价格
                if (p.IsEnableSku)
                {
                    object maxPrice = Dal.Max<ShopProductSKUInfo>(ShopProductSKUInfo._.ProductId == p.ID, ShopProductSKUInfo._.SalePrice);
                    object minPrice = Dal.Min<ShopProductSKUInfo>(ShopProductSKUInfo._.ProductId == p.ID, ShopProductSKUInfo._.SalePrice);
                    string maxPriceStr = string.Empty;
                    string minPriceStr = string.Empty;
                    if (!(maxPrice is DBNull))
                    {
                        maxPriceStr = maxPrice.ToString();
                    }
                    if (!(minPrice is DBNull))
                    {
                        minPriceStr = minPrice.ToString();
                    }
                    if (maxPriceStr == minPriceStr)
                    {
                        p.PriceRange = minPriceStr;
                    }
                    else
                    {
                        p.PriceRange = minPriceStr + "-" + maxPriceStr;
                    }
                    //获取其默认规格
                    ShopProductSKUInfo defaultSku = Dal.Find<ShopProductSKUInfo>
                        (ShopProductSKUInfo._.ProductId == p.ID && ShopProductSKUInfo._.IsDefault == true);
                    if (defaultSku != null)
                    {
                        p.SalePrice = defaultSku.SalePrice;
                        p.DefaultSkuID = defaultSku.ID;
                        List<ShopProductSKU> listGg = Dal.From<ShopProductSKU>()
                            .Join<ShopExtendInfo>(ShopExtendInfo._.ID == ShopProductSKU._.AttributeId)
                              .Join<ShopExtendInfoValue>(ShopExtendInfoValue._.ID == ShopProductSKU._.ValueId)
                            .Where(ShopProductSKU._.ID == defaultSku.SKURelationID).OrderBy(ShopExtendInfo._.DisplayOrder)
                            .Select(ShopProductSKU._.AttributeId, ShopProductSKU._.ValueId, ShopExtendInfoValue._.ValueStr)
                            .List<ShopProductSKU>();
                        string result = string.Empty;
                        string names = string.Empty;
                        foreach (var item in listGg)
                        {
                            if (!string.IsNullOrWhiteSpace(result))
                            {
                                result += "|";
                                names += " ";
                            }
                            //result += item.AttributeId + "|" + item.ValueId;
                            result += item.ValueId;
                            names += item.ValueStr;
                        }
                        p.DefaultGgVals = result;
                        p.DefaultGgText = names;
                    }

                }
                else
                {
                    p.PriceRange = p.SalePrice.ToString();
                }

                #region 单独分出接口来
                ////获取其规格

                //p.dtGg = Dal.From<ShopProductSKU>().Join<ShopExtendInfo>(ShopProductSKU._.AttributeId == ShopExtendInfo._.ID)
                //    .Join<ShopExtendInfoValue>(ShopExtendInfoValue._.AttributeId == ShopExtendInfo._.ID)
                //    .Select(ShopProductSKU._.AttributeId, ShopExtendInfo._.Name, ShopExtendInfoValue._.ID.Alias("GGValID"), ShopExtendInfoValue._.ValueStr).Where(ShopProductSKU._.ProductId == id)
                //    .Distinct().ToDataTable();

                //p.dtSku = Dal.From<ShopProductSKUInfo>().Join<ShopProductSKU>(ShopProductSKUInfo._.SKURelationID == ShopProductSKU._.ID)
                //    .Join<ShopExtendInfo>(ShopProductSKU._.AttributeId == ShopExtendInfo._.ID)
                //  .Join<ShopExtendInfoValue>(ShopExtendInfoValue._.AttributeId == ShopExtendInfo._.ID && ShopProductSKU._.ValueId == ShopExtendInfoValue._.ID)
                //  .Select(ShopProductSKU._.AttributeId, ShopExtendInfo._.Name, ShopExtendInfoValue._.ID.Alias("GGValID"), ShopExtendInfoValue._.ValueStr, ShopProductSKUInfo._.SKU, ShopProductSKUInfo._.SalePrice, ShopProductSKUInfo._.MarketPrice, ShopProductSKUInfo._.Stock, ShopProductSKUInfo._.Weight).Where(ShopProductSKU._.ProductId == id)
                //  .Distinct().ToDataTable();

                ////获取其关联商品
                //p.dtRelation = Dal.From<ShopProductInfo>().Join<ShopRalationProduct>(ShopProductInfo._.ID == ShopRalationProduct._.RlationProductID)
                //    .Join<AttachFile>(ShopProductInfo._.ID == AttachFile._.RefID && AttachFile._.OrderNo == 0, JoinType.leftJoin)
                //    .Where(ShopRalationProduct._.ProductID == id)

                //    .Select(ShopProductInfo._.ID, ShopProductInfo._.Name, ShopProductInfo._.Code, AttachFile.GetFilePath(host))
                //    .ToDataTable();
                //获取其评价 
                #endregion
            }
            return p;
        }
        private string[] getCategorys(string categoryid)
        {
            return Dal.From<ShopCategory>().Where(ShopCategory._.ClassCode.Contains(categoryid)).Select(ShopCategory._.ID).ToSinglePropertyArray();



        }
        public DataTable GetProductsByCategory(string categoryID, int pageindex, string orderbystr, string host, ref int pageCount, ref int recordCount)
        {
            OrderByClip orderby = ShopProductInfo._.SaleNum.Desc;
            if (!string.IsNullOrWhiteSpace(orderbystr))
            {
                orderby = new OrderByClip(orderbystr);
            }

            DataTable dt = Dal.From<ShopProductCategory>().Join<ShopProductInfo>(
         ShopProductCategory._.ProductID == ShopProductInfo._.ID)
         .Join<ShopCategory>(ShopCategory._.ID == ShopProductCategory._.CategoryID)
         .Join<ShopBrandInfo>(ShopBrandInfo._.ID == ShopProductInfo._.BrandId, JoinType.leftJoin)
         .Join<ShopProductType>(ShopProductType._.ID == ShopProductInfo._.TypeId, JoinType.leftJoin)
         .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 1, JoinType.leftJoin)
         .Select(ShopProductInfo._.ID, ShopProductCategory._.CategoryID, ShopCategory._.Name.Alias("CategoryName"), ShopProductInfo._.BrandId, ShopProductInfo._.TypeId, ShopProductInfo._.Code, ShopProductInfo._.Name, ShopProductInfo._.SKU, ShopProductInfo._.SaleCounts, ShopProductInfo._.SalePrice, ShopProductInfo._.MarketPrice, ShopBrandInfo._.Name.Alias("BrandName"), ShopProductType._.Name.Alias("TypeName"), AttachFile.GetFilePath(host))
         .OrderBy(orderby)

         .Where(ShopProductCategory._.CategoryID.In(getCategorys(categoryID)))
         .ToDataTable(20, pageindex, ref pageCount, ref recordCount);
            return dt;
        }

        public DataTable GetProductByWhere(WhereClip where, int pageNum, string host, ref int pageCount, ref int recordCount)
        {
            return
                Dal.From<ShopProductInfo>().Join<ShopProductCategory>(ShopProductInfo._.ID == ShopProductCategory._.ProductID)
                .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 1)
                .Where(where).Select(ShopProductInfo._.ID, ShopProductInfo._.Code, ShopProductInfo._.Name, ShopProductInfo._.SalePrice, ShopProductInfo._.MarketPrice, AttachFile.GetFilePath(host)).ToDataTable(20, pageNum, ref pageCount, ref recordCount);
        }

        public int SaveStation(ShopProductStationMode s)
        {

            return Dal.Submit(s);
        }

        public DataTable GetProductsByStation(int id, int pageIndex, int pageSize, string host, ref int pagecount, ref int recordCount)
        {
            return
               Dal.From<ShopProductInfo>().Join<ShopProductStationMode>(ShopProductInfo._.ID == ShopProductStationMode._.ProductID)
               .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 1)
               .Where(ShopProductStationMode._.StationMode == id).Select(ShopProductStationMode._.ID.Alias("StationID"), ShopProductInfo._.ID, ShopProductStationMode._.OrderNo, ShopProductInfo._.Code, ShopProductInfo._.Name, ShopProductInfo._.SalePrice, ShopProductInfo._.MarketPrice, AttachFile.GetFilePath(host))
               .OrderBy(ShopProductStationMode._.OrderNo.Desc)
               .ToDataTable(pageSize, pageIndex, ref pagecount, ref recordCount);
        }

        public DataTable GetProductsByStation(string cateogryid, int pageIndex, int pageSize, string host, ref int pagecount, ref int recordCount)
        {
            return
               Dal.From<ShopProductInfo>().Join<ShopProductStationMode>(ShopProductInfo._.ID == ShopProductStationMode._.ProductID)
               .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 1)
               .Where(ShopProductStationMode._.StationMode == (int)StationMode.分类首页推荐 && ShopProductCategory._.CategoryID.In(getCategorys(cateogryid))).Select(ShopProductStationMode._.ID.Alias("StationID"), ShopProductInfo._.ID, ShopProductStationMode._.OrderNo, ShopProductInfo._.Code, ShopProductInfo._.Name, ShopProductInfo._.SalePrice, ShopProductInfo._.MarketPrice, AttachFile.GetFilePath(host))
               .OrderBy(ShopProductStationMode._.OrderNo.Desc)
               .ToDataTable(pageSize, pageIndex, ref pagecount, ref recordCount);
        }

        public int DeleteStation(string StationID)
        {
            return Dal.Delete<ShopProductStationMode>(StationID);
        }

        public DataSet GetProductsByMutilStation(string id, int pagesize, string host, out string error)
        {
            error = string.Empty;
            string[] station = id.Split(new char[] { ',', ' ', ';', '，', '；' }, StringSplitOptions.RemoveEmptyEntries);
            DataSet ds = new DataSet();
            if (station.Length == 0)
            { error = "必须提供商品展示位置参数"; return null; }
            else
            {
                int[] intstation = new int[station.Length];
                for (int i = 0; i < station.Length; i++)
                {
                    int tem = 0;
                    if (int.TryParse(station[i], out tem))
                    {
                        intstation[i] = tem;
                        DataTable dt = GetProductsByStation(tem, 1, pagesize, host, ref tem, ref tem).Copy();
                        dt.TableName = "Table" + i;
                        ds.Tables.Add(dt);
                    }
                    else
                    {
                        error = string.Format("第{0}个位置参数{1}不正确", i + 1, station[i]); return null;
                    }
                }

                return ds;



            }

        }

        public List<ShopExtendWithValue> GetProductGgInfo(string id, out string err)
        {
            err = string.Empty;
            ShopProductInfo product = Dal.From<ShopProductInfo>().Where(ShopProductInfo._.ID == id).Select(ShopProductInfo._.TypeId, ShopProductInfo._.SaleStatus, ShopProductInfo._.IsEnableSku).ToFirst<ShopProductInfo>();
            if (product == null || product.SaleStatus != 1)
            {
                err = "当前商品可能已下架";
                return null;
            }
            else
                if (!product.IsEnableSku)
                {
                    err = "当前商品没启用SKU";
                    return null;

                }
                else
                {

                    DataTable dtGg = Dal.From<ShopProductSKU>().Join<ShopExtendInfo>(ShopProductSKU._.AttributeId == ShopExtendInfo._.ID)
                         .Join<ShopExtendInfoValue>(ShopExtendInfoValue._.AttributeId == ShopExtendInfo._.ID)

                         .Select(ShopProductSKU._.AttributeId,
                         ShopExtendInfo._.Name,
                         ShopExtendInfoValue._.ID.Alias("GGValID"), ShopExtendInfoValue._.ValueStr, ShopExtendInfo._.DisplayOrder, ShopExtendInfoValue._.DisplaySequence).
                         Where(ShopProductSKU._.ProductId == id).OrderBy(ShopProductSKU._.AttributeId, ShopExtendInfo._.DisplayOrder, ShopExtendInfoValue._.DisplaySequence)
                         .Distinct().ToDataTable();

                    List<ShopExtendWithValue> gglist = new List<ShopExtendWithValue>();

                    foreach (DataRow item in dtGg.Rows)
                    {
                        string attid = item["AttributeId"] as string;
                        if (!gglist.Exists(p => p.AttributeId == attid))
                        {
                            gglist.Add(item.ToFirst<ShopExtendWithValue>());
                        }
                    }

                    DataTable dtvalue = new DataTable();
                    dtvalue.Columns.Add("GGValID");
                    dtvalue.Columns.Add("ValueStr");
                    dtvalue.AcceptChanges();
                    foreach (ShopExtendWithValue item in gglist)
                    {
                        item.Values = dtvalue.Clone();
                        var data = from dt in dtGg.AsEnumerable()
                                   where dt.Field<string>("AttributeId") == item.AttributeId
                                   select dt;
                        foreach (var row in data)
                        {
                            DataRow dr = item.Values.NewRow();
                            dr["GGValID"] = row.Field<string>("GGValID");
                            dr["ValueStr"] = row.Field<string>("ValueStr");
                            item.Values.AddRow(dr);
                        }
                        item.Values.AcceptChanges();
                    }
                    return gglist;
                }
        }

        public DataTable GetProductSkuInfo(string productID, out string err)
        {
            err = string.Empty;
            ShopProductInfo product = Dal.From<ShopProductInfo>().Where(ShopProductInfo._.ID == productID).Select(ShopProductInfo._.TypeId, ShopProductInfo._.SaleStatus, ShopProductInfo._.IsEnableSku).ToFirst<ShopProductInfo>();
            if (product == null || product.SaleStatus != 1)
            {
                err = "当前商品可能已下架";
                return null;
            }
            else
                if (!product.IsEnableSku)
                {
                    err = "当前商品没启用SKU";
                    return null;

                }
                else
                {
                    DataTable dt = Dal.From<ShopProductSKUInfo>().Where(ShopProductSKUInfo._.ProductId == productID).OrderBy(ShopProductSKUInfo._.OrderNo)
                           .Select(ShopProductSKUInfo._.ID.Alias("SkuID"), ShopProductSKUInfo._.IsSale, ShopProductSKUInfo._.MarketPrice, ShopProductSKUInfo._.SalePrice, ShopProductSKUInfo._.SKU, ShopProductSKUInfo._.SKURelationID
                           , ShopProductSKUInfo._.Stock).ToDataTable();

                    DataTable dtSku = Dal.From<ShopProductSKU>().Where(ShopProductSKU._.ProductId == productID)
                        .Join<ShopExtendInfo>(ShopExtendInfo._.ID == ShopProductSKU._.AttributeId).Join<ShopExtendInfoValue>(ShopProductSKU._.ValueId == ShopExtendInfoValue._.ID)
                        .OrderBy(ShopProductSKU._.AttributeId, ShopExtendInfo._.DisplayOrder, ShopExtendInfoValue._.DisplaySequence)
                        .Select(ShopProductSKU._.ID, ShopProductSKU._.AttributeId, ShopProductSKU._.ValueId).ToDataTable();
                    DataColumn dcAttrVal = new DataColumn("AttriVal");
                    dt.Columns.Add(dcAttrVal);
                    foreach (DataRow item in dt.Rows)
                    {
                        var query = from dr in dtSku.AsEnumerable() where (dr.Field<string>("ID") == item["SKURelationID"] as string) select dr.Field<string>("ValueId");
                        string resut = string.Empty;
                        foreach (var oneval in query)
                        {
                            if (!string.IsNullOrWhiteSpace(resut))
                            {
                                resut += "|";
                            }
                            resut += oneval;
                        }
                        item["AttriVal"] = resut;

                    }
                    dt.Columns.Remove("SKURelationID");
                    dt.AcceptChanges();
                    return dt;
                }
        }

        public string IsSJOperator(string ids, int opcode)
        {
            string err = string.Empty;

            try
            {
                ShopProductInfo p = new ShopProductInfo();
                p.RecordStatus = StatusType.update;
                p.Where = ShopProductInfo._.ID.In(ids.Split(';')) && ShopProductInfo._.SaleStatus != opcode;
                p.SaleStatus = opcode;
                Dal.Submit(p);
                err = "操作成功";
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            return err;
        }

        public DataTable GetSkuByProductID(string productID, out string err)
        {
            err = string.Empty;
            ShopProductInfo product = Dal.From<ShopProductInfo>().Where(ShopProductInfo._.ID == productID).Select(ShopProductInfo._.SaleStatus, ShopProductInfo._.IsEnableSku).ToFirst<ShopProductInfo>();
            if (product == null || product.SaleStatus != 1)
            {
                err = "当前商品可能已下架";
                return null;
            }
            else
                if (!product.IsEnableSku)
                {
                    err = "当前商品没启用SKU";
                    return null;

                }
                else
                {
                    DataTable dt = Dal.From<ShopProductSKUInfo>().Where(ShopProductSKUInfo._.ProductId == productID
                        && ShopProductSKUInfo._.IsSale == true

                        ).OrderBy(ShopProductSKUInfo._.OrderNo)
                           .Select(ShopProductSKUInfo._.ID.Alias("SkuID"), ShopProductSKUInfo._.IsSale, ShopProductSKUInfo._.MarketPrice, ShopProductSKUInfo._.SalePrice, ShopProductSKUInfo._.SKU, ShopProductSKUInfo._.SKURelationID
                           , ShopProductSKUInfo._.Stock).ToDataTable();

                    DataTable dtSku = Dal.From<ShopProductSKU>().Where(ShopProductSKU._.ProductId == productID)
                        .Join<ShopExtendInfo>(ShopExtendInfo._.ID == ShopProductSKU._.AttributeId).Join<ShopExtendInfoValue>(ShopProductSKU._.ValueId == ShopExtendInfoValue._.ID)
                        .OrderBy(ShopProductSKU._.AttributeId, ShopExtendInfo._.DisplayOrder, ShopExtendInfoValue._.DisplaySequence)
                        .Select(ShopProductSKU._.ID, ShopExtendInfoValue._.ValueStr).ToDataTable();
                    DataColumn dcAttrVal = new DataColumn("AttriVal");
                    dt.Columns.Add(dcAttrVal);
                    foreach (DataRow item in dt.Rows)
                    {
                        var query = from dr in dtSku.AsEnumerable() where (dr.Field<string>("ID") == item["SKURelationID"] as string) select dr.Field<string>("ValueStr");
                        string resut = string.Empty;
                        foreach (var oneval in query)
                        {
                            if (!string.IsNullOrWhiteSpace(resut))
                            {
                                resut += "   ";
                            }
                            resut += oneval;
                        }
                        item["AttriVal"] = resut;

                    }
                    dt.Columns.Remove("SKURelationID");
                    dt.AcceptChanges();
                    return dt;
                }
        }

        public DataTable GetProduct(int pageIndex, int pagesize, ref int pagecount, ref int recordCount)
        {

            return Dal.From<ShopProductInfo>().Select(ShopProductInfo._.ID, ShopProductInfo._.Code, ShopProductInfo._.Name
                , ShopProductInfo._.MarketPrice
                , ShopProductInfo._.SalePrice).ToDataTable(pagesize, pageIndex, ref pagecount, ref recordCount);
        }

        public DataTable GetProductsBySearchKey(string searchKey, int pageIndex, string orderbystr, string host, ref int pagecount, ref int recordCount)
        {

            OrderByClip orderby = ShopProductInfo._.SaleNum.Desc;
            if (!string.IsNullOrWhiteSpace(orderbystr))
            {
                orderby = new OrderByClip(orderbystr);
            }
            WhereClip searchWhere = new WhereClip();
            searchWhere = ShopProductInfo._.SaleStatus == 1;

            searchWhere = searchWhere && (ShopProductInfo._.Name.Contains(searchKey) || ShopProductInfo._.ShortDescription.Contains(searchKey)
                || ShopCategory._.Name.Contains(searchKey) || ShopCategory._.Description.Contains(searchKey)
                || ShopBrandInfo._.Name.Contains(searchKey)
                || ShopProductType._.Name.Contains(searchKey)
                  );
            DataTable dt = Dal.From<ShopProductCategory>().Join<ShopProductInfo>(
         ShopProductCategory._.ProductID == ShopProductInfo._.ID)
         .Join<ShopCategory>(ShopCategory._.ID == ShopProductCategory._.CategoryID)
         .Join<ShopBrandInfo>(ShopBrandInfo._.ID == ShopProductInfo._.BrandId, JoinType.leftJoin)
         .Join<ShopProductType>(ShopProductType._.ID == ShopProductInfo._.TypeId, JoinType.leftJoin)
         .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 1, JoinType.leftJoin)
         .Select(ShopProductInfo._.ID, ShopProductCategory._.CategoryID, ShopCategory._.Name.Alias("CategoryName"), ShopProductInfo._.BrandId, ShopProductInfo._.TypeId, ShopProductInfo._.Code, ShopProductInfo._.Name, ShopProductInfo._.SKU, ShopProductInfo._.SaleCounts, ShopProductInfo._.SalePrice, ShopProductInfo._.MarketPrice, ShopBrandInfo._.Name.Alias("BrandName"), ShopProductType._.Name.Alias("TypeName"), AttachFile.GetFilePath(host))
         .OrderBy(orderby)
         .Where(searchWhere)
         .ToDataTable(20, pageIndex, ref pagecount, ref recordCount);
            return dt;
        }
    }



}
