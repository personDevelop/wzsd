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
    public class ShopProductTypeDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = "";
            Dal.Delete("ShopProductType", "ID", id, out error);
            return error;
        }
        public string DeleteExtend(string id)
        {
            string error = "";
            Dal.Delete("ShopExtendInfo", "ID", id, out error);
            return error;
        }

        public string DeleteExtendValue(string id)
        {
            string error = "";
            Dal.Delete("ShopExtendInfoValue", "ID", id, out error);
            return error;
        }
        public int Save(ShopProductType item, List<string> brandList)
        {
            SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                dal.Delete<ShopProductTypeAndBrand>(ShopProductTypeAndBrand._.ProductTypeId == item.ID, tr);
                if (brandList.Count > 0)
                {
                    List<ShopProductTypeAndBrand> list = new List<ShopProductTypeAndBrand>();
                    foreach (var ptid in brandList)
                    {
                        ShopProductTypeAndBrand ptb = new ShopProductTypeAndBrand();
                        ptb.ID = Guid.NewGuid().ToString();
                        ptb.ProductTypeId = item.ID;
                        ptb.BrandId = ptid;
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

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<ShopProductType>().Select(ShopProductType._.ID, ShopProductType._.Name).OrderBy(ShopProductType._.Code).ToDataTable();
            }
            else
                return Dal.From<ShopProductType>().OrderBy(ShopProductType._.Code).ToDataTable();
        }
        public bool Exit(string ID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = ShopProductType._.Code == val;
            }
            else
            {
                where = ShopProductType._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopProductType._.ID != ID;

            }
            return !Dal.Exists<ShopProductType>(where);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<ShopProductType>().Select(ShopProductType._.ID, ShopProductType._.Name).OrderBy(ShopProductType._.Code).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<ShopProductType>().OrderBy(ShopProductType._.Code)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public ShopProductType GetEntity(string id)
        {
            return Dal.Find<ShopProductType>(id);
        }




        public List<ShopProductType> GetListWithBrand(string brandID, StatusType statusType)
        {
            if (statusType == StatusType.add)
            {
                return Dal.From<ShopProductType>().OrderBy(ShopProductType._.Code).List<ShopProductType>();
            }
            else
            {
                return Dal.From<ShopProductType>().Join<ShopProductTypeAndBrand>(ShopProductType._.ID == ShopProductTypeAndBrand._.ProductTypeId
                    && ShopProductTypeAndBrand._.BrandId == brandID, JoinType.leftJoin)
                    .Select(ShopProductType._.ID.All, new ExpressionClip(" CASE WHEN ShopProductTypeAndBrand.ID IS NULL THEN 0 ELSE 1 END  IsSelected")).List<ShopProductType>();
            }
        }

        public List<ShopBrandInfo> GetListWithProductType(string ptid, StatusType statusType)
        {
            if (statusType == StatusType.add)
            {
                return Dal.From<ShopBrandInfo>().OrderBy(ShopBrandInfo._.OrderNo).List<ShopBrandInfo>();
            }
            else
            {
                return Dal.From<ShopBrandInfo>().Join<ShopProductTypeAndBrand>(ShopBrandInfo._.ID == ShopProductTypeAndBrand._.BrandId
                    && ShopProductTypeAndBrand._.ProductTypeId == ptid, JoinType.leftJoin)
                    .Select(ShopBrandInfo._.ID.All, new ExpressionClip(" CASE WHEN ShopProductTypeAndBrand.ID IS NULL THEN 0 ELSE 1 END  IsSelected")).List<ShopBrandInfo>();
            }
        }

        public DataTable GetAttrList(string host, string ptypeid, bool isGg)
        {

            WhereClip where = ShopExtendInfo._.ProductTypeID == ptypeid;
            if (isGg)
            {
                where = where && ShopExtendInfo._.UsageMode > 1;
            }
            else
            {
                where = where && ShopExtendInfo._.UsageMode < 2;
            }
            DataTable dt = Dal.From<ShopExtendInfo>().Where(where).OrderBy(ShopExtendInfo._.DisplayOrder)
                     .ToDataTable();
            if (dt.Rows.Count > 0)
            {
                //加载规格值
                dt.Columns.Add("Vals");
                List<string> extendID = new List<string>();
                var qry = dt.AsEnumerable();
                extendID = (from d in qry select d.Field<string>("ID")).ToList<string>();
                DataTable dtvals = Dal.From<ShopExtendInfoValue>().Join<AttachFile>(ShopExtendInfoValue._.ImageID == AttachFile._.RefID, JoinType.leftJoin)
                    .Where(ShopExtendInfoValue._.AttributeId.In(extendID)).Select(ShopExtendInfoValue._.AttributeId, ShopExtendInfoValue._.ValueStr,
                    ShopExtendInfoValue._.Note,
                    ShopExtendInfoValue._.ImageID, AttachFile.GetFilePath(host)).OrderBy(ShopExtendInfoValue._.DisplaySequence).ToDataTable();
                foreach (DataRow item in dt.Rows)
                {
                    string temp = "";
                    string attriID = item["ID"] as string;
                    DataRow[] drs = dtvals.Select("AttributeId='" + attriID + "'");
                    foreach (DataRow itemVal in drs)
                    {
                        string splitStr = ",";
                        string temResult = "";
                        string img = itemVal["FilePath"] as string;
                        if (string.IsNullOrWhiteSpace(img))
                        {
                            temResult = itemVal["ValueStr"] as string;
                        }
                        else
                        {
                            splitStr = "&nbsp;&nbsp;";
                            //是图片
                            temResult = string.Format("<img src='{0}' width='16px' height='16px' alt='{1}' />", itemVal["FilePath"], itemVal["ValueStr"]);

                        }

                        if (!string.IsNullOrWhiteSpace(temp))
                        {
                            temp += splitStr;
                        }
                        temp += temResult;
                    }
                    item["Vals"] = temp;
                }
            }
            dt.AcceptChanges();
            return dt;
        }

        public int SaveShopExtendInfo(ShopExtendInfo p)
        {
            return Dal.Submit(p);
        }

        public ShopExtendInfo GetShopExtendInfo(string id)
        {
            return Dal.Find<ShopExtendInfo>(id);
        }

        public int Save(List<ShopExtendInfoValue> list)
        {
            int count = Dal.Count<ShopExtendInfoValue>(ShopExtendInfoValue._.AttributeId == list[0].AttributeId, ShopExtendInfoValue._.ID, false);
            foreach (var item in list)
            {
                item.DisplaySequence = count++ + 1;

            }
            return Dal.Submit(list);
        }

        public DataTable GetValList(string host, string attriID)
        {

            DataTable dt = Dal.From<ShopExtendInfoValue>().Join<AttachFile>(ShopExtendInfoValue._.ImageID == AttachFile._.RefID, JoinType.leftJoin)
                .Select(ShopExtendInfoValue._.ID, ShopExtendInfoValue._.AttributeId, ShopExtendInfoValue._.DisplaySequence, ShopExtendInfoValue._.ImageID, ShopExtendInfoValue._.Note,


                ShopExtendInfoValue._.ValueStr, AttachFile.GetFilePath(host))
                .Where(ShopExtendInfoValue._.AttributeId == attriID)
                .OrderBy(ShopExtendInfoValue._.DisplaySequence)
                .ToDataTable();
            foreach (DataRow item in dt.Rows)
            {
                string img = item["FilePath"] as string;
                if (!string.IsNullOrWhiteSpace(img))
                {
                    item["ValueStr"] = string.Format("<img src='{0}' width='16px' height='16px' alt='{1}' />", item["FilePath"], item["ValueStr"]);

                }
            }
            dt.AcceptChanges();
            return dt;
        }

        public ShopExtendInfoValue GetAttrVal(string id)
        {
            return Dal.Find<ShopExtendInfoValue>(id);
        }

        public int SaveAttrVal(ShopExtendInfoValue p)
        {
            return Dal.Submit(p);
        }

        public ShopExtendInfoValue GetAttrEntity(string id)
        {
            return GetAttrVal(id);
        }

        public int DeleteAttrVal(string id, out string error)
        {
            error = string.Empty;
            return Dal.Delete("ShopExtendInfoValue", "ID", id, out error);

        }

        public bool Exit(string ID, string AttributeId, string RecordStatus, string val)
        {
            WhereClip where = ShopExtendInfoValue._.AttributeId == AttributeId
                && ShopExtendInfoValue._.ValueStr == val;

            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopExtendInfoValue._.ID != ID;

            }
            return !Dal.Exists<ShopExtendInfoValue>(where);
        }

      
    }

}
