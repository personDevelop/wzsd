﻿using EasyCms.Model;
using Sharp.Common;
using Sharp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCms.Model.ViewModel;

namespace EasyCms.Dal
{
    public class ShopProductInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = "";
            Dal.Delete("ShopProductInfo", "ID", id, out error);
            return error;
        }

        public int Save(ShopProductInfo item, List<BaseEntity> list, List<ShopProductAttributes> spas, List<ShopProductSKU> listSku, List<ShopProductSKUInfo> listSkuInfo, List<int> StationModeList)
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
            //处理推荐信息

            ShopProductStationMode deletestation = new ShopProductStationMode() { RecordStatus = StatusType.delete, Where = ShopProductStationMode._.ProductID == item.ID };
            List<ShopProductStationMode> listStationMode = new List<ShopProductStationMode>();
            listStationMode.Add(deletestation);
            if (StationModeList.Count > 0)
            {
                DataTable dt = Dal.From<ShopProductStationMode>().Select(ShopProductStationMode._.StationMode, ShopProductStationMode._.OrderNo.Max().Alias("OrderNo"))
                  .GroupBy(ShopProductStationMode._.StationMode).ToDataTable();
                Dictionary<int, int> stationOrderNum = new Dictionary<int, int>();

                foreach (DataRow dr in dt.Rows)
                {
                    stationOrderNum.Add((int)dr["StationMode"], (int)dr["OrderNo"]);
                }

                foreach (int staton in StationModeList)
                {
                    int orderno = 0;
                    if (stationOrderNum.ContainsKey(staton))
                    {
                        orderno = stationOrderNum[staton] + 1;

                    }
                    else
                    {
                        stationOrderNum.Add(staton, orderno);
                    }
                    listStationMode.Add(new ShopProductStationMode()
                    {
                        ID = Guid.NewGuid().ToString(),
                        ProductID = item.ID,
                        StationMode = staton,
                        OrderNo = orderno,
                        StationModeName = ((StationMode)staton).ToString()
                    });
                    stationOrderNum[staton] = orderno;

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
                dal.SubmitNew(tr, ref dal, listStationMode);
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

        public string UpdateStationOrderNo(int station, string stationID, int newvalue)
        {
            string result = string.Empty;
            int oldvalue = (int)Dal.From<ShopProductStationMode>().Where(ShopProductStationMode._.ID == stationID).Select(ShopProductStationMode._.OrderNo).ToScalar();
            if (newvalue == oldvalue)
            {
                return "顺序没变，不用修改";
            }
            else
            {
                ShopProductStationMode ssm = new ShopProductStationMode() { ID = stationID, RecordStatus = StatusType.update, OrderNo = newvalue };
                WhereClip where = ShopProductStationMode._.StationMode == station;
                ShopProductStationMode plssm = new ShopProductStationMode() { RecordStatus = StatusType.update };

                int cz = newvalue - oldvalue;
                if (cz > 0)
                {
                    // 7 /改成9   原来的9 变成8  8变成7  10 不变

                    plssm.Where = where && ShopProductStationMode._.OrderNo <= newvalue && ShopProductStationMode._.OrderNo > oldvalue;
                    ExpressionClip orderexp = new ExpressionClip("OrderNo-1 ");
                    plssm.SetModifiedProperty(ShopProductStationMode._.OrderNo, orderexp);
                }
                else
                {
                    //9//改成7  7 变8 8 变9
                    plssm.Where = where && ShopProductStationMode._.OrderNo >= newvalue && ShopProductStationMode._.OrderNo < oldvalue;
                    //顺序减1
                    ExpressionClip orderexp = new ExpressionClip("OrderNo+1 ");

                    plssm.SetModifiedProperty(ShopProductStationMode._.OrderNo, orderexp);
                }
                SessionFactory dal = null;
                IDbTransaction tr = Dal.BeginTransaction(out dal);
                try
                {
                    dal.SubmitNew(tr, ref dal, plssm, ssm);
                    dal.CommitTransaction(tr);
                }
                catch
                {
                    dal.RollbackTransaction(tr);
                    throw;
                }
                return result;
            }
        }

        public string UpdateOrderNo(string attacheID, string producntID)
        {
            List<AttachFile> list = Dal.From<AttachFile>().Where(AttachFile._.RefID == producntID)
                .OrderBy(AttachFile._.OrderNo)
                
                .List<AttachFile>();

            int i = 1;
            foreach (var item in list)
            {
                if (item.ID == attacheID)
                {
                    item.OrderNo = 0;
                }
                else
                {
                    item.OrderNo = i++;

                }

            }
            Dal.Submit(list);
            return string.Empty;
        }

        public DataSet GetList()
        {
           IDbCommand dt2 = Dal.From<ShopProductInfo>().Join<AttachFile>(ShopProductInfo._.ID == AttachFile._.RefID)
                .Select(AttachFile._.ID.Alias("fileID"), AttachFile.GetThumbnaifilePath(""), AttachFile._.RefID,AttachFile._.OrderNo).ToDbCommand();

            DataSet ds= Dal.From<ShopProductInfo>().Select(ShopProductInfo._.ID.All)
                .ToDataSet(dt2);
            return ds;
        }

        public ShopCardInfo GetProduct(string productId, string sKU)
        {
            ShopCardInfo sc = new ShopCardInfo();
            ShopProductInfo p = Dal.From<ShopProductInfo>().Where(ShopProductInfo._.ID == productId)
                .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 0, JoinType.leftJoin)

                .Select(ShopProductInfo._.ID, ShopProductInfo._.SaleStatus, ShopProductInfo._.Stock, ShopProductInfo._.SalePrice, ShopProductInfo._.Name, AttachFile.GetThumbnaifilePath("", "ThumbImgUrl")).ToFirst<ShopProductInfo>();
            sc.ProductId = productId;
            sc.ThumbImgUrl = p.ThumbImgUrl;
            sc.Stock = p.Stock;
            sc.IsSale = p.SaleStatus == 1;
            sc.Name = p.Name;
            sc.SalePrice = p.SalePrice;
            if (!string.IsNullOrWhiteSpace(sKU))
            {
                ShopProductSKUInfo skup = Dal.From<ShopProductSKUInfo>().Where(ShopProductSKUInfo._.ID == sKU).Select(ShopProductSKUInfo._.ID, ShopProductSKUInfo._.SalePrice, ShopProductSKUInfo._.Stock, ShopProductSKUInfo._.IsSale, ShopProductSKUInfo._.Name).ToFirst<ShopProductSKUInfo>();

                sc.GuiGeInfo = skup.Name;
                sc.SKU = sKU;
                sc.Stock = skup.Stock;
                sc.IsSale = skup.IsSale;
                sc.SalePrice = skup.SalePrice;
            }
            return sc;
        }


        public ShopShoppingCarts GetDbCardProduct(string productId, string sKU)
        {

            ShopProductInfo p = Dal.From<ShopProductInfo>().Where(ShopProductInfo._.ID == productId)
                .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 0, JoinType.leftJoin)

                .Select(ShopProductInfo._.ID, ShopProductInfo._.SaleStatus, ShopProductInfo._.Stock, ShopProductInfo._.SalePrice, ShopProductInfo._.Name, AttachFile.GetThumbnaifilePath("", "ThumbImgUrl")).ToFirst<ShopProductInfo>();
            ShopShoppingCarts sc = new ShopShoppingCarts()
            {
                ProductId = productId,

                ThumbnailsUrl = p.ThumbImgUrl,
                Name = p.Name,
                SellPrice = p.SalePrice,
                AddTime = DateTime.Now
            };



            if (!string.IsNullOrWhiteSpace(sKU))
            {
                ShopProductSKUInfo skup = Dal.From<ShopProductSKUInfo>().Where(ShopProductSKUInfo._.ID == sKU).Select(ShopProductSKUInfo._.ID, ShopProductSKUInfo._.SalePrice, ShopProductSKUInfo._.Stock, ShopProductSKUInfo._.IsSale, ShopProductSKUInfo._.Name).ToFirst<ShopProductSKUInfo>();

                sc.Name += " " + skup.Name;
                sc.SKU = sKU;

                sc.SellPrice = skup.SalePrice;
            }
            return sc;
        }

        public List<ShopCategory> GetLocationCateogryByCategoryID(string categoryID)
        {

            string classcode = Dal.From<ShopCategory>().Where(ShopCategory._.ID == categoryID).Select(ShopCategory._.ClassCode).ToScalar() as string;
            string[] classcodeArray = classcode.Split(';');
            return Dal.From<ShopCategory>().Where(ShopCategory._.ID.In(classcodeArray)).OrderBy(ShopCategory._.Depth).List<ShopCategory>();
        }

        public DataTable GetList(string categoryID, string Name, int pagenum, int pagesize, ref int recordCount)
        {
            WhereClip where = ShopProductInfo._.Name.Contains(Name) || ShopProductInfo._.Code.Contains(Name);
            QuerySection qry = Dal.From<ShopProductInfo>();
            if (!string.IsNullOrWhiteSpace(categoryID))
            {

                string[] classcode = new ShopCategoryDal().GetClassCode(categoryID);
                where = where && ShopProductCategory._.CategoryID.In(classcode);
                qry.Join<ShopProductCategory>(ShopProductInfo._.ID == ShopProductCategory._.ProductID);
            }
            int pageCount = 0;

            return qry
                .Join<ShopProductType>(ShopProductType._.ID == ShopProductInfo._.TypeId, JoinType.leftJoin)
                .Join<ShopBrandInfo>(ShopBrandInfo._.ID == ShopProductInfo._.BrandId, JoinType.leftJoin)
                .Where(where).
                Select(ShopProductInfo._.ID, ShopProductInfo._.Code, ShopProductInfo._.Name,
                ShopProductInfo._.AddedDate, ShopProductInfo._.CommentCount, ShopProductInfo._.CostPrice,
                ShopProductInfo._.DisplaySequence, ShopProductInfo._.MarketPrice, ShopProductInfo._.Points,
                ShopProductInfo._.SaleCounts, ShopProductInfo._.SaleDate, ShopProductInfo._.SaleNum, ShopProductInfo._.Stock,
                ShopProductInfo._.SalePrice, ShopProductInfo._.SaleStatus, ShopProductInfo._.SalesType,
                ShopProductInfo._.VistiCounts
                , ShopProductType._.Name.Alias("TypeName"), ShopBrandInfo._.Name.Alias("BrandName"))
                .OrderBy(ShopProductInfo._.AddedDate.Desc)
                .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public List<ListProduct> GetStationProductByProductID(StationMode station, string productID, int top = 5)
        {
            List<ListProduct> result = new List<ListProduct>();
            DataTable dt = null;
            WhereClip where = ShopProductInfo._.SaleStatus == 1 && ShopProductStationMode._.StationMode == (int)station;
            if (!string.IsNullOrWhiteSpace(productID))
            {
                //获取其分类
                string classcode = Dal.From<ShopCategory>().Join<ShopProductCategory>(ShopCategory._.ID == ShopProductCategory._.CategoryID &&
                     ShopProductCategory._.ProductID == productID).Select(ShopCategory._.ClassCode).ToScalar() as string;
                if (!string.IsNullOrWhiteSpace(classcode))
                {
                    string[] cateotryID = Dal.From<ShopCategory>().Where(ShopCategory._.ClassCode.StartsWith(classcode)).Select(ShopCategory._.ID)
                        .ToSinglePropertyArray();
                    dt = Dal.From<ShopProductStationMode>().Join<ShopProductInfo>(ShopProductStationMode._.ProductID == ShopProductInfo._.ID)
                            .Join<ShopProductCategory>(ShopProductCategory._.ProductID == productID)
                            .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 0)
                        .Where(ShopProductStationMode._.StationMode == (int)station && ShopProductCategory._.CategoryID.In(cateotryID))
                        .Select(ShopProductInfo._.ID, ShopProductInfo._.Name, ShopProductInfo._.SalePrice,
                       AttachFile.GetFilePath(""))
                       .Distinct()
                        .ToDataTable(top);
                    result = dt.ToList<ListProduct>();
                }
            }
            int hasCount = 0;
            if (dt != null)
            {
                hasCount = dt.Rows.Count;
            }
            int sycount = top - hasCount;
            if (sycount > 0)
            {
                if (result.Count > 0)
                {
                    where = where && !ShopProductInfo._.ID.In(result.Select(p => p.ID).ToList());
                }
                DataTable dt1 = Dal.From<ShopProductStationMode>().Join<ShopProductInfo>(ShopProductStationMode._.ProductID == ShopProductInfo._.ID)

                           .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 0)
                       .Where(where)
                       .Select(ShopProductInfo._.ID, ShopProductInfo._.Name, ShopProductInfo._.SalePrice,
                      AttachFile.GetFilePath(""))
                      .Distinct()
                       .ToDataTable(sycount);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    result.AddRange(dt1.ToList<ListProduct>());
                }
            }
            return result;

        }

        public List<ShopCategory> GetLocationCateogry(string productID)
        {
            string categoryID = Dal.From<ShopProductCategory>().Where(ShopProductCategory._.ProductID == productID).Select(ShopProductCategory._.CategoryID).ToScalar() as string;
            return GetLocationCateogryByCategoryID(categoryID);

        }

        public DataTable GetRelationList(string productID, bool IsHasRelation, string categoryID, string Name, int pagenum, int pagesize, ref int recordCount)
        {
            QuerySection qry = Dal.From<ShopProductInfo>();

            WhereClip where = ShopProductInfo._.SaleStatus == 1 && ShopProductInfo._.ID != productID && ShopProductInfo._.Name.Contains(Name) || ShopProductInfo._.Code.Contains(Name);
            string isNotStr = " not ";
            if (IsHasRelation) isNotStr = string.Empty;
            where = where && new WhereClip(string.Format(" {1} exists(SELECT 1 FROM ShopRalationProduct WHERE ProductID='{0}' AND RlationProductID=ShopProductInfo.ID)", productID, isNotStr));


            if (!string.IsNullOrWhiteSpace(categoryID))
            {
                string[] classcode = new ShopCategoryDal().GetClassCode(categoryID);
                where = ShopProductCategory._.CategoryID.In(classcode);
                qry.Join<ShopProductCategory>(ShopProductInfo._.ID == ShopProductCategory._.ProductID);
            }
            int pageCount = 0;

            return qry
                .Join<ShopProductType>(ShopProductType._.ID == ShopProductInfo._.TypeId, JoinType.leftJoin)
                .Join<ShopBrandInfo>(ShopBrandInfo._.ID == ShopProductInfo._.BrandId, JoinType.leftJoin)
                .Where(where).
                Select(ShopProductInfo._.ID, ShopProductInfo._.Code, ShopProductInfo._.Name,
                ShopProductInfo._.AddedDate, ShopProductInfo._.CommentCount, ShopProductInfo._.CostPrice,
                ShopProductInfo._.DisplaySequence, ShopProductInfo._.MarketPrice, ShopProductInfo._.Points,
                ShopProductInfo._.SaleCounts, ShopProductInfo._.SaleDate, ShopProductInfo._.SaleNum,
                ShopProductInfo._.SalePrice, ShopProductInfo._.SaleStatus, ShopProductInfo._.SalesType,
                ShopProductInfo._.VistiCounts
                , ShopProductType._.Name.Alias("TypeName"), ShopBrandInfo._.Name.Alias("BrandName"))
                .OrderBy(ShopProductInfo._.AddedDate.Desc)
                .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public string AddRelation(string productID, string RlationProductIDs, bool isDoubleRelation)
        {
            List<ShopRalationProduct> list = new List<ShopRalationProduct>();
            string[] ralationProductID = RlationProductIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in ralationProductID)
            {
                ShopRalationProduct pdelete = new ShopRalationProduct() { RecordStatus = StatusType.delete, Where = ShopRalationProduct._.ProductID == productID && ShopRalationProduct._.RlationProductID == item };
                ShopRalationProduct p = new ShopRalationProduct() { ID = Guid.NewGuid().ToString(), ProductID = productID, RlationProductID = item };
                list.Add(pdelete);
                list.Add(p);
                if (isDoubleRelation)
                {
                    ShopRalationProduct p1delete = new ShopRalationProduct() { RecordStatus = StatusType.delete, Where = ShopRalationProduct._.ProductID == item && ShopRalationProduct._.RlationProductID == productID };
                    list.Add(p1delete);
                    ShopRalationProduct p1 = new ShopRalationProduct() { ID = Guid.NewGuid().ToString(), ProductID = item, RlationProductID = productID };
                    list.Add(p1);
                }
            }
            Dal.Submit(list);
            return string.Empty;
        }

        public string RemoveRelation(string productID, string RlationProductIDs)
        {
            string[] ralationProductID = RlationProductIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            ShopRalationProduct deletera = new ShopRalationProduct()
            {
                RecordStatus = StatusType.delete,
                Where = ShopRalationProduct._.ProductID == productID && ShopRalationProduct._.RlationProductID.In(ralationProductID)
            };
            Dal.Submit(deletera);
            return string.Empty;
        }

        public ShopProductInfo GetEntity(string id)
        {
            ShopProductInfo p = Dal.From<ShopProductInfo>()
                 .Join<ShopBrandInfo>(ShopProductInfo._.BrandId == ShopBrandInfo._.ID, JoinType.leftJoin)
                   .Join<ShopProductType>(ShopProductInfo._.TypeId == ShopProductType._.ID, JoinType.leftJoin)
                   .Select(ShopProductInfo._.ID.All, ShopBrandInfo._.Name.Alias("BrandName"), ShopProductType._.Name.Alias("TypeName"))
                   .Where(ShopProductInfo._.ID == id)
                   .ToFirst<ShopProductInfo>();
            List<ShopCategory> list = Dal.From<ShopCategory>().
                Join<ShopProductCategory>(ShopCategory._.ID == ShopProductCategory._.CategoryID && ShopProductCategory._.ProductID == p.ID)

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
            DataTable dt =
              Dal.From<ShopExtendInfo>().Join<ShopExtendInfoValue>(ShopExtendInfo._.ID == ShopExtendInfoValue._.AttributeId).Join
                    <ShopProductAttributes>(ShopExtendInfo._.ID == ShopProductAttributes._.AttributeId
              && ShopProductAttributes._.ValueId == ShopExtendInfoValue._.ID && ShopProductAttributes._.ProductId == productID, JoinType.leftJoin)
              .Select(ShopExtendInfo._.ID, ShopExtendInfo._.Name, ShopExtendInfo._.ShowType
              , ShopExtendInfoValue._.ID.Alias("ExtendInfoValueID"), ShopExtendInfoValue._.ValueStr, ShopExtendInfoValue._.DisplaySequence,
           new ExpressionClip(" case when ShopProductAttributes.ValueId is null then 0 else 1 end HasValue"))
           .Join<ShopExtendAndType>(ShopExtendInfo._.ID == ShopExtendAndType._.ExtendID)
              .Where(ShopExtendAndType._.TypeID == ptypeid && ShopExtendInfo._.UsageMode < 2)

              .OrderBy(ShopExtendInfo._.ID, ShopExtendInfo._.DisplayOrder, ShopExtendInfoValue._.DisplaySequence).ToDataTable();

            if (dt == null || dt.Rows.Count == 0)
            {
                dt =
              Dal.From<ShopExtendInfo>().Join<ShopExtendInfoValue>(ShopExtendInfo._.ID == ShopExtendInfoValue._.AttributeId).Join
                    <ShopProductAttributes>(ShopExtendInfo._.ID == ShopProductAttributes._.AttributeId
              && ShopProductAttributes._.ValueId == ShopExtendInfoValue._.ID)
              .Select(ShopExtendInfo._.ID, ShopExtendInfo._.Name, ShopExtendInfo._.ShowType
              , ShopExtendInfoValue._.ID.Alias("ExtendInfoValueID"), ShopExtendInfoValue._.ValueStr, ShopExtendInfoValue._.DisplaySequence,
           new ExpressionClip(" case when ShopProductAttributes.ValueId is null then 0 else 1 end HasValue"))
           .Join<ShopExtendAndType>(ShopExtendInfo._.ID == ShopExtendAndType._.ExtendID)
               .Where(ShopExtendAndType._.TypeID == ptypeid && ShopProductAttributes._.ProductId.IsNullOrEmpty() && ShopExtendInfo._.UsageMode < 2)

              .OrderBy(ShopExtendInfo._.ID, ShopExtendInfo._.DisplayOrder, ShopExtendInfoValue._.DisplaySequence).ToDataTable();

            }
            return dt;
        }



        public DataSet GetGgWithProdcutVal(string ptypeid, string productID)
        {

            DataSet ds =
              Dal.From<ShopExtendInfo>().Join<ShopExtendInfoValue>(ShopExtendInfo._.ID == ShopExtendInfoValue._.AttributeId, JoinType.leftJoin)
                .Join<ShopProductSKU>(ShopExtendInfoValue._.ID == ShopProductSKU._.ValueId && ShopProductSKU._.ProductId == productID, JoinType.leftJoin)
             .Select(ShopExtendInfo._.ID, ShopExtendInfo._.CategoryID, ShopExtendInfo._.DisplayOrder, ShopExtendInfo._.FullName, ShopExtendInfo._.Name, ShopExtendInfo._.ShowType, ShopExtendInfo._.UnitText, ShopExtendInfo._.UsageMode, ShopExtendInfo._.UseAttrImg, ShopExtendInfo._.UseDefineImg,
              ShopExtendInfoValue._.ID.Alias("ExtendInfoValueID"), ShopExtendInfoValue._.ValueStr, ShopExtendInfoValue._.DisplaySequence, ShopExtendInfoValue._.ImageID, ShopExtendInfoValue._.Note,
               new ExpressionClip(" case when ShopProductSKU.ID is null then 0 else 1 end HasValue"))
               .Join<ShopExtendAndType>(ShopExtendInfo._.ID == ShopExtendAndType._.ExtendID)
              .Where(ShopExtendAndType._.TypeID == ptypeid && ShopExtendInfo._.UsageMode > 1)
             .OrderBy(ShopExtendInfo._.ID, ShopExtendInfo._.DisplayOrder, ShopExtendInfoValue._.DisplaySequence).Distinct()
             .ToDataSet();
            string tempTable = "temp" + Guid.NewGuid().ToString().Replace("-", "");
            Dictionary<string, object> dic = new Dictionary<string, object>();
            Dal.FromStoredProcedure("PIVOTRowConvertCol").AddInputParameter("tableName", "ShopProductSKU,ShopExtendAndType,ShopExtendInfo,ShopExtendInfoValue")
                       .AddInputParameter("groupColumn", "ShopProductSKU.ID SKUID")
                       .AddInputParameter("pivotgroupColumn", "SKUID")
                       .AddInputParameter("row2column", "ShopExtendInfo.Name")
                       .AddInputParameter("pivotrow2column", "Name")
                       .AddInputParameter("row2columnValue", "ShopExtendInfoValue.AttributeId+'|'+ShopExtendInfoValue.id+'|'+ShopExtendInfoValue.ValueStr as ValueStr")
                        .AddInputParameter("pivotrow2columnValue", "ValueStr")
                         .AddInputParameter("sql_where", string.Format("where  ShopExtendAndType.ExtendID=ShopExtendInfo.ID AND  ShopExtendAndType.TypeID='{0}' and ShopProductSKU.ProductId='{1}'  and ShopProductSKU.ValueId = ShopExtendInfoValue.ID and ShopExtendInfoValue.AttributeId =  ShopExtendInfo.ID", ptypeid, productID))
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
                .Join<ShopProductType>(ShopProductInfo._.TypeId == ShopProductType._.ID, JoinType.leftJoin)
                .Where(ShopProductInfo._.ID == id && ShopProductInfo._.SaleStatus == 1).ToFirst<ShopSaleProductInfo>();


            if (p != null)
            {

                //获取其图像
                p.dtImg = Dal.From<AttachFile>().Where(AttachFile._.RefID == p.ID).Select(AttachFile.GetCompressionfilePath(host)).OrderBy(AttachFile._.OrderNo).ToDataTable();
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
         .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 0, JoinType.leftJoin)
         .Select(ShopProductInfo._.ID, ShopProductCategory._.CategoryID, ShopCategory._.Name.Alias("CategoryName"), ShopProductInfo._.BrandId, ShopProductInfo._.TypeId,
         ShopProductInfo._.Code, ShopProductInfo._.Name, ShopProductInfo._.SKU, ShopProductInfo._.SaleCounts,
         ShopProductInfo._.GoodCount, ShopProductInfo._.MiddleCount, ShopProductInfo._.BadCount, ShopProductInfo._.CommentCount,
         ShopProductInfo._.SalePrice, ShopProductInfo._.MarketPrice, ShopBrandInfo._.Name.Alias("BrandName"),
         ShopProductType._.Name.Alias("TypeName"), AttachFile.GetThumbnaifilePath(host))
         .OrderBy(orderby)

         .Where(ShopProductInfo._.SaleStatus == 1 && ShopProductCategory._.CategoryID.In(getCategorys(categoryID)))
         .ToDataTable(20, pageindex, ref pageCount, ref recordCount);
            return dt;
        }
        public DataTable GetTravalList(string categoryID, int pageindex, string orderbystr, string host, ref int pageCount, ref int recordCount)
        {
            OrderByClip orderby = ShopProductInfo._.SaleNum.Desc;
            if (!string.IsNullOrWhiteSpace(orderbystr))
            {
                orderby = new OrderByClip(orderbystr);
            }

            DataTable dt = Dal.From<ShopProductCategory>().Join<ShopProductInfo>(
         ShopProductCategory._.ProductID == ShopProductInfo._.ID)
         .Join<ShopCategory>(ShopCategory._.ID == ShopProductCategory._.CategoryID)
         .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.VideoImg && AttachFile._.OrderNo == 0, JoinType.leftJoin)
         .Select(ShopProductInfo._.ID, ShopProductInfo._.VideoUrl,
         ShopProductInfo._.Code, ShopProductInfo._.Name, ShopProductInfo._.SKU, ShopProductInfo._.SaleCounts,
         ShopProductInfo._.GoodCount, ShopProductInfo._.MiddleCount, ShopProductInfo._.BadCount,
         ShopProductInfo._.SalePrice, ShopProductInfo._.MarketPrice,
          AttachFile.GetThumbnaifilePath(host))
         .OrderBy(orderby)
         .Where(ShopProductInfo._.SaleStatus == 1 && ShopProductCategory._.CategoryID.In(getCategorys(categoryID)))
         .ToDataTable(20, pageindex, ref pageCount, ref recordCount);
            var qry = from x in dt.AsEnumerable().Where(a => a.Field<string>("FilePath") == null)
                      select x.Field<string>("ID");
            List<string> noVidieoImg = qry.ToList();
            if (noVidieoImg.Count > 0)
            {
                DataTable dt1 = Dal.From<AttachFile>()
                    .Join<ShopProductInfo>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 0)
                    .Select(AttachFile._.RefID, AttachFile.GetThumbnaifilePath(host))
                      .Where(AttachFile._.RefID.In(noVidieoImg)).ToDataTable();
                foreach (DataRow item in dt1.Rows)
                {
                    foreach (DataRow item1 in dt.Rows)
                    {
                        if (item["RefID"] as string == item1["ID"] as string)
                        {
                            item1["FilePath"] = item["FilePath"];
                            break;
                        }

                    }
                }

            }

            return dt;
        }

        public DataTable GetProductByWhere(WhereClip where, int pageNum, string host, ref int pageCount, ref int recordCount)
        {
            return
                Dal.From<ShopProductInfo>().Join<ShopProductCategory>(ShopProductInfo._.ID == ShopProductCategory._.ProductID)
                .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 0)
                .Where(ShopProductInfo._.SaleStatus == 1 && where)
                .Select(ShopProductInfo._.ID, ShopProductInfo._.Code, ShopProductInfo._.Name,
                ShopProductInfo._.SalePrice, ShopProductInfo._.MarketPrice,
                AttachFile.GetThumbnaifilePath(host))
                .OrderBy(ShopProductInfo._.AddedDate.Desc)
                .ToDataTable(20, pageNum, ref pageCount, ref recordCount);
        }

        public int SaveStation(ShopProductStationMode s)
        {
            int orderNo = 0;
            object o = Dal.Max<ShopProductStationMode>(ShopProductStationMode._.StationMode == (int)s.StationMode, ShopProductStationMode._.OrderNo);
            if (o != DBNull.Value)
            {
                orderNo = (int)o;
            }
            
            s.OrderNo = orderNo + 1;
            return Dal.Submit(s);
        }

        public DataTable GetProductsByStation(int id, int pageIndex, int pageSize, string host, ref int pagecount, ref int recordCount)
        {
            return
               Dal.From<ShopProductInfo>().Join<ShopProductStationMode>(ShopProductInfo._.ID == ShopProductStationMode._.ProductID)
               .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 0)
               .Where(ShopProductInfo._.SaleStatus == 1 && ShopProductStationMode._.StationMode == id)
               .Select(ShopProductStationMode._.ID.Alias("StationID"), ShopProductInfo._.ID,
               ShopProductStationMode._.OrderNo, ShopProductInfo._.Code, ShopProductInfo._.Name, 
               ShopProductInfo._.SalePrice, ShopProductInfo._.MarketPrice, ShopProductInfo._.SaleCounts, AttachFile.GetCompressionfilePath(host))
               .OrderBy(ShopProductStationMode._.OrderNo.Desc)
               .ToDataTable(pageSize, pageIndex, ref pagecount, ref recordCount);
        }

        public DataTable GetProductsByStation(string cateogryid, StationMode stationMode, int pageIndex, int pageSize, string host, ref int pagecount, ref int recordCount)
        {
            return
               Dal.From<ShopProductInfo>().Join<ShopProductStationMode>(ShopProductInfo._.ID == ShopProductStationMode._.ProductID)
               .Join<ShopProductCategory>(ShopProductInfo._.ID == ShopProductCategory._.ProductID)
               .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 0)
               .Where(ShopProductInfo._.SaleStatus == 1 && ShopProductStationMode._.StationMode == (int)stationMode && ShopProductCategory._.CategoryID.In(getCategorys(cateogryid)))
               .Distinct()
               .Select(ShopProductStationMode._.ID.Alias("StationID"),

               ShopProductInfo._.ID, ShopProductStationMode._.OrderNo, ShopProductInfo._.Code,
               ShopProductInfo._.Name, ShopProductInfo._.SalePrice, ShopProductInfo._.MarketPrice, AttachFile.GetCompressionfilePath(host))
               .OrderBy(ShopProductStationMode._.OrderNo.Desc)
               .ToDataTable(pageSize, pageIndex, ref pagecount, ref recordCount);
        }

        public int DeleteStation(string StationID)
        {
            int count = 0;
            ShopProductStationMode ssm = Dal.Find<ShopProductStationMode>(StationID);
            ssm.Where = ShopProductStationMode._.StationMode == ssm.StationMode && ShopProductStationMode._.OrderNo > ssm.OrderNo;
            ExpressionClip orderexp = new ExpressionClip("OrderNo-1 ");

            ssm.SetModifiedProperty(ShopProductStationMode._.OrderNo, orderexp);
            SessionFactory dal = null;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                count = dal.SubmitNew(tr, ref dal, ssm);
                dal.Delete<ShopProductStationMode>(tr, StationID);
                dal.CommitTransaction(tr);
            }
            catch
            {
                dal.RollbackTransaction(tr);
                throw;
            }
            return count;
            
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
               );
            DataTable dt = Dal.From<ShopProductInfo>()
         .Join<ShopBrandInfo>(ShopBrandInfo._.ID == ShopProductInfo._.BrandId, JoinType.leftJoin)
         .Join<ShopProductType>(ShopProductType._.ID == ShopProductInfo._.TypeId, JoinType.leftJoin)
         .Join<AttachFile>(AttachFile._.RefID == ShopProductInfo._.ID && AttachFile._.OrderNo == 0, JoinType.leftJoin)
         .Select(ShopProductInfo._.ID, ShopProductInfo._.CommentCount, ShopProductInfo._.BrandId, ShopProductInfo._.TypeId, ShopProductInfo._.Code, ShopProductInfo._.Name, ShopProductInfo._.SKU, ShopProductInfo._.SaleCounts, ShopProductInfo._.SalePrice, ShopProductInfo._.MarketPrice, ShopBrandInfo._.Name.Alias("BrandName"), ShopProductType._.Name.Alias("TypeName"), AttachFile.GetThumbnaifilePath(host))
         .OrderBy(orderby)
         .Where(searchWhere)
         .ToDataTable(20, pageIndex, ref pagecount, ref recordCount);
            return dt;
        }

        public int AccCommentCount(string ProductId, int CommentCount)
        {
            ShopProductInfo p = new ShopProductInfo();
            p.ID = ProductId;
            p.RecordStatus = Sharp.Common.StatusType.update;
            ExpressionClip commentCount = new ExpressionClip(ShopProductInfo._.CommentCount.ColumnName + "+@CommentCount");
            commentCount.Parameters.Add("CommentCount", CommentCount);
            p.SetModifiedProperty(ShopProductInfo._.CommentCount, commentCount);
            return Dal.Submit(p);
        }

        public ProductLink GetProductLink(string id, string host)
        {
            ProductLink p = null;
            DataTable dt = Dal.From<ShopProductInfo>().Where(ShopProductInfo._.ID == id)
                .Join<AttachFile>(AttachFile._.ID == ShopProductInfo._.VideoImg, JoinType.leftJoin)
                .Select(ShopProductInfo._.ID, ShopProductInfo._.VideoUrl, ShopProductInfo._.Description, AttachFile.GetThumbnaifilePath(host)).ToDataTable();

            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                p = new ProductLink()
                {
                    ID = dr["ID"] as string,
                };
                bool Isjingtai = false;//如果使用静态
                if (Isjingtai)
                {
                    p.UrlStr = dr["Description"] as string;
                }
                else
                {
                    p.HtmlStr = dr["Description"] as string;
                    string key = "src=\"/upload/";
                    p.HtmlStr = p.HtmlStr.Replace("src=\"/Upload/", key);
                    if (p.HtmlStr.Contains(key))
                    {
                        p.HtmlStr = p.HtmlStr.Replace(key, key = "src=\"" + host + "/upload/");
                    }
                }
                string vidiourl = dr["VideoUrl"] as string;

                if (!string.IsNullOrWhiteSpace(vidiourl))
                {
                    string[] videoarry = vidiourl.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    p.VideoUrl = videoarry.ToList();
                }
                string FilePath = dr["FilePath"] as string;
                p.VideoImg = FilePath;

            }
            return p;
        }


        public ShopProductInfo GetWebEntity(string id, string sku, out string error)
        {
            error = string.Empty;
            ShopProductInfo p = Dal.From<ShopProductInfo>()
                .Join<ShopBrandInfo>(ShopProductInfo._.BrandId == ShopBrandInfo._.ID, JoinType.leftJoin)
                .Select(ShopProductInfo._.ID, ShopProductInfo._.Code, ShopProductInfo._.Name, ShopProductInfo._.MarketPrice, ShopProductInfo._.SalePrice, ShopProductInfo._.SaleStatus
                , ShopProductInfo._.Stock, ShopProductInfo._.Points, ShopProductInfo._.PCDescription, ShopProductInfo._.Weight
               , ShopProductInfo._.SaleDate, ShopProductInfo._.Unit
               , ShopProductInfo._.GoodCount, ShopProductInfo._.MiddleCount, ShopProductInfo._.BadCount, ShopProductInfo._.IsEnableSku
               , ShopBrandInfo._.Name.Alias("BrandName"))
                .Where(ShopProductInfo._.ID == id).ToFirst<ShopProductInfo>();
            if (p == null)
            {
                error = "商品不存在";

            }
            else if (p.SaleStatus != 1)
            {
                error = "商品已下架";
            }
            else
            {

                //获取其图像
                p.ImgPath = Dal.From<AttachFile>().Where(AttachFile._.RefID == p.ID).Select(AttachFile.GetFilePath("")).OrderBy(AttachFile._.OrderNo).ToSinglePropertyArray();
                //获取其扩张属性
                //获取其价格
                if (p.IsEnableSku)
                {
                    p.ShopProductAttr = Dal.From<ShopProductAttributes>().Join<ShopExtendInfo>(ShopExtendInfo._.ID == ShopProductAttributes._.AttributeId)
                           .Join<ShopExtendInfoValue>(ShopProductAttributes._.ValueId == ShopExtendInfoValue._.ID && ShopProductAttributes._.ProductId == id)
                           .Join<AttachFile>(!ShopExtendInfoValue._.ImageID.IsNullOrEmpty() && AttachFile._.RefID == ShopExtendInfoValue._.ImageID, JoinType.leftJoin)
                           .Select(ShopProductAttributes._.ID.All, ShopExtendInfo._.Name.Alias("AttrName"),
                           AttachFile.GetThumbnaifilePath(""), ShopExtendInfoValue._.ValueStr
                           ).List<ShopProductAttributes>();
                    p.ShopProductSKU = Dal.
                     From<ShopProductSKU>().

                     Join<ShopExtendInfo>(ShopProductSKU._.AttributeId == ShopExtendInfo._.ID)
                     .Join<ShopExtendInfoValue>(ShopExtendInfoValue._.AttributeId == ShopExtendInfo._.ID && ShopProductSKU._.ValueId == ShopExtendInfoValue._.ID)
                    .Join<AttachFile>(!ShopExtendInfoValue._.ImageID.IsNullOrEmpty() && AttachFile._.RefID == ShopExtendInfoValue._.ImageID, JoinType.leftJoin)
                     .Where(ShopProductSKU._.ProductId == id)
                      .Select(
                        //ShopProductSKU._.ID.Alias("SKUID"),
                        ShopExtendInfo._.ID.Alias("AttributeId"),
                       ShopExtendInfo._.Name.Alias("AttrName"),
                       ShopExtendInfo._.UseAttrImg,
                       ShopProductSKU._.ValueId, ShopExtendInfo._.DisplayOrder,
                   AttachFile.GetThumbnaifilePath(""),
                       ShopExtendInfoValue._.ValueStr, ShopExtendInfoValue._.DisplaySequence)
                       .OrderBy(ShopExtendInfo._.DisplayOrder, ShopExtendInfo._.ID, ShopExtendInfoValue._.DisplaySequence)
                       .Distinct().ToDataTable().ToList<ShopExtendAttr>();

                    List<ShopProductSKUInfo> SKUInfolist = Dal.From<ShopProductSKUInfo>()
                        .Select(ShopProductSKUInfo._.ID, ShopProductSKUInfo._.IsDefault,
                        ShopProductSKUInfo._.Weight, ShopProductSKUInfo._.SKURelationID
                        , ShopProductSKUInfo._.Stock, ShopProductSKUInfo._.MarketPrice,
                        ShopProductSKUInfo._.SalePrice, ShopProductSKUInfo._.IsSale
                         ).Where(ShopProductSKUInfo._.ProductId == id).List<ShopProductSKUInfo>();

                    List<ShopExtendAttr> valueList = Dal.
                      From<ShopProductSKU>().

                      Join<ShopExtendInfo>(ShopProductSKU._.AttributeId == ShopExtendInfo._.ID)
                      .Join<ShopExtendInfoValue>(ShopExtendInfoValue._.AttributeId == ShopExtendInfo._.ID &&
                      ShopProductSKU._.ValueId == ShopExtendInfoValue._.ID)
                      .Where(ShopProductSKU._.ProductId == id)
                       .Select(
                          ShopProductSKU._.ID.Alias("SKUID"),
                         ShopProductSKU._.AttributeId,
                        ShopProductSKU._.ValueId)
                        .OrderBy(ShopExtendInfo._.DisplayOrder, ShopExtendInfo._.ID)
                       .ToDataTable().ToList<ShopExtendAttr>();
                    foreach (var item in SKUInfolist)
                    {
                        if (!string.IsNullOrWhiteSpace(sku) && item.ID == sku)
                        {
                            SKUInfolist.Find(pd => pd.IsDefault).IsDefault = false;
                            item.IsDefault = true;
                        }
                        IEnumerable<ShopExtendAttr> attlist = valueList.Where(pp => pp.SKUID == item.SKURelationID);
                        string tem = string.Empty;
                        foreach (var dd in attlist)
                        {
                            tem += dd.ValueId + ";";
                        }
                        item.Valueids = tem;
                    }
                    p.SKUInfolist = SKUInfolist;
                    decimal maxPrice = SKUInfolist.Max(par => par.SalePrice);
                    decimal minPrice = SKUInfolist.Min(par => par.SalePrice);
                    if (maxPrice != minPrice)
                    {
                        p.SalePriceRange = string.Format("{0}-￥{1}", minPrice, maxPrice);
                    }
                    else
                        p.SalePriceRange = maxPrice + string.Empty;
                    maxPrice = SKUInfolist.Max(par => par.MarketPrice);
                    minPrice = SKUInfolist.Min(par => par.MarketPrice);
                    if (maxPrice != minPrice)
                    {
                        p.MarketPriceRange = string.Format("{0}-￥{1}", minPrice, maxPrice);
                    }
                    else
                        p.MarketPriceRange = maxPrice + string.Empty;

                }
                else
                {
                    p.SalePriceRange = p.SalePrice + string.Empty;
                    p.MarketPriceRange = p.MarketPrice + string.Empty;
                    p.SKUInfolist = new List<ShopProductSKUInfo>();
                    p.ShopProductSKU = new List<ShopExtendAttr>();
                }


            }
            return p;
        }
    }



}
