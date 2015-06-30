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
    public class ShopProductInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            return "";
        }

        public int Save(ShopProductInfo item, List<BaseEntity> list, List<ShopProductAttributes> spas)
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
            SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                dal.Delete<ShopProductCategory>(ShopProductCategory._.ProductID == item.ID, tr);
                if (deleteShopProductAttributesIDS.Count > 0)
                {
                    dal.Delete<ShopProductAttributes>(ShopProductAttributes._.ProductId == item.ID && ShopProductAttributes._.ValueId.In(deleteShopProductAttributesIDS), tr);
                }
                dal.SubmitNew(ref dal, item);
                dal.SubmitNew(list, ref dal);
                dal.SubmitNew(spas, ref dal);
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
                return Dal.From<ShopProductInfo>().OrderBy(ShopProductInfo._.AddedDate.Desc)
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
            return Dal.From<ShopExtendInfo>().Join<ShopExtendInfoValue>(ShopExtendInfo._.ID == ShopExtendInfoValue._.AttributeId, JoinType.leftJoin).Join
                    <ShopProductAttributes>(ShopExtendInfo._.ID == ShopProductAttributes._.AttributeId
              && ShopProductAttributes._.ValueId == ShopExtendInfoValue._.ID && ShopProductAttributes._.ProductId == productID, JoinType.leftJoin)
              .Select(ShopExtendInfo._.ID, ShopExtendInfo._.Name, ShopExtendInfo._.ShowType
              , ShopExtendInfoValue._.ID.Alias("ExtendInfoValueID"), ShopExtendInfoValue._.ValueStr, ShopExtendInfoValue._.DisplaySequence,
           new ExpressionClip(" case when ShopProductAttributes.ValueId is null then 0 else 1 end HasValue"))

              .Where(ShopExtendInfo._.ProductTypeID == ptypeid && ShopExtendInfo._.UsageMode < 2)

              .OrderBy(ShopExtendInfo._.DisplayOrder, ShopExtendInfoValue._.DisplaySequence).ToDataTable();
        }



        public DataTable GetGgWithProdcutVal(string ptypeid, string productID)
        {

            return Dal.From<ShopExtendInfo>().Join<ShopExtendInfoValue>(ShopExtendInfo._.ID == ShopExtendInfoValue._.AttributeId)
             .Select(ShopExtendInfo._.ID.All,
              ShopExtendInfoValue._.ID.Alias("ExtendInfoValueID"), ShopExtendInfoValue._.ValueStr, ShopExtendInfoValue._.DisplaySequence, ShopExtendInfoValue._.ImageID, ShopExtendInfoValue._.Note
          )
             .Where(ShopExtendInfo._.ProductTypeID == ptypeid && ShopExtendInfo._.UsageMode > 1)

             .OrderBy(ShopExtendInfo._.DisplayOrder, ShopExtendInfoValue._.DisplaySequence).ToDataTable();
        }
    }


}
