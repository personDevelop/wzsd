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
            return "";
            if (string.IsNullOrWhiteSpace(id))
            {
                return "要删除的参数值不能为空";
            }
            //int state = (int)Dal.From<ShopProductType>().Select(ShopProductType._.State).ToScalar();
            //if (state == (int)CategoryState.审核通过)
            //{
            //    return "当前新闻分类已审核通过,不能删除";
            //}
            ////判断是否已被新闻引用过
            //bool Eixt = Dal.Exists<NewsInfo>(NewsInfo._.ClassID == id);
            //if (Eixt)
            //{
            //    return "当前新闻分类已被使用,不能删除";
            //}
            //Eixt = Dal.Exists<ShopProductType>(ShopProductType._.ParentID == id);
            //if (Eixt)
            //{
            //    return "当前新闻分类下含有子分类 ,不能删除";
            //}
            //int i = Dal.Delete<ShopProductType>(id);
            //if (i == 0)
            //{
            //    return "删除失败";
            //}
            //else
            //{
            //    return "成功删除分类";
            //}
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

        public DataTable GetAttrList(string ptypeid, bool isGg)
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
            return Dal.From<ShopExtendInfo>().Where(where).OrderBy(ShopExtendInfo._.DisplayOrder)
                     .ToDataTable();
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

        public DataTable GetValList(string attriID, int page, int pagesize, ref int recordCount)
        {
            int pageCount = 0;
            return Dal.From<ShopExtendInfoValue>().Where(ShopExtendInfoValue._.AttributeId == attriID).ToDataTable(pagesize, page, ref pageCount, ref recordCount);
        }

        public ShopExtendInfoValue GetAttrVal(string id)
        {
            return Dal.Find<ShopExtendInfoValue>(int.Parse(id));
        }

        public int SaveAttrVal(ShopExtendInfoValue p)
        {
            return Dal.Submit(p);
        }

        public ShopExtendInfoValue GetAttrEntity(string id)
        {
            return GetAttrVal(id);
        }

        public int DeleteAttrVal(string id)
        {
            return Dal.Delete<ShopExtendInfoValue>(int.Parse(id));
        }
    }

}
