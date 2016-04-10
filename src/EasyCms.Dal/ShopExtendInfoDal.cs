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
    public class ShopExtendInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("ShopExtendInfo", "ID", id, out error);
            return error;
        }
        public int DeleteAttrVal(string id, out string error)
        {
            error = string.Empty;
            return Dal.Delete("ShopExtendInfoValue", "ID", id, out error);

        }
        
        public int Save(ShopExtendInfo item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<ShopExtendInfo>().Select(ShopExtendInfo._.ID,   ShopExtendInfo._.FullName, ShopExtendInfo._.Name ).OrderBy(ShopExtendInfo._.DisplayOrder).ToDataTable();
            }
            else
                return Dal.From<ShopExtendInfo>().OrderBy(ShopExtendInfo._.DisplayOrder).ToDataTable();
        }

        public DataTable GetValList(string host, string attriID)
        {

            DataTable dt = Dal.From<ShopExtendInfoValue>().Join<AttachFile>(ShopExtendInfoValue._.ImageID == AttachFile._.RefID, JoinType.leftJoin)
                .Select(ShopExtendInfoValue._.ID, ShopExtendInfoValue._.AttributeId, ShopExtendInfoValue._.DisplaySequence, ShopExtendInfoValue._.ImageID, ShopExtendInfoValue._.Note,


                ShopExtendInfoValue._.ValueStr, AttachFile.GetThumbnaifilePath(host))
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

        public DataTable GetList(string categoryID, string name, string fullName, string pTypeID, UsageMode usageMode, int pagenum, int pagesize, ref int recordCount)
        {
            DataTable dt = null;
            string sql = "select ExtendID from ShopExtendAndType where TypeID='"+"pTypeID"+"'";
            WhereClip where = new WhereClip(string.Format(" NOT EXISTS (select 1  from ShopExtendAndType where TypeID='{0}' AND ShopExtendInfo.ID=ExtendID)", pTypeID));

            where = where &&  ShopExtendInfo._.Name.Contains(name) && ShopExtendInfo._.FullName.Contains(fullName);
            if (!string.IsNullOrWhiteSpace(categoryID))
                where = where && ShopExtendInfo._.CategoryID == categoryID;
            if ((int)usageMode > 1) where = where && ShopExtendInfo._.UsageMode > 1;
            else where = where && ShopExtendInfo._.UsageMode < 2;
            int pagecount=0;
            dt = Dal.From<ShopExtendInfo>().Join<AttributeType>(ShopExtendInfo._.CategoryID==AttributeType._.ID)
                .Select(ShopExtendInfo._.ID.All,AttributeType._.Name.Alias("CategoryName"))
                .Where(where).ToDataTable(pagesize, pagenum, ref pagecount, ref recordCount);
            return dt;
        }

        public bool Exit(string ID, string categoryID, string RecordStatus, string val )
        {
            WhereClip where = ShopExtendInfo._.CategoryID==categoryID;

            
                where = where && ShopExtendInfo._.FullName == val;
            
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopExtendInfo._.ID != ID;

            }
            return !Dal.Exists<ShopExtendInfo>(where);
        }
        public bool ExitExtendInfoValue(string ID, string AttributeId, string RecordStatus, string val)
        {
            WhereClip where = ShopExtendInfoValue._.AttributeId == AttributeId
                && ShopExtendInfoValue._.ValueStr == val;

            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopExtendInfoValue._.ID != ID;

            }
            return !Dal.Exists<ShopExtendInfoValue>(where);
        }
        public ShopExtendInfoValue GetAttrVal(string valueID)
        {
            return Dal.Find<ShopExtendInfoValue>(valueID);
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

      

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            
                return Dal.From<ShopExtendInfo>().Join<AttributeType>(ShopExtendInfo._.CategoryID == AttributeType._.ID, 
                    JoinType.leftJoin).Select(ShopExtendInfo._.ID.All, AttributeType._.Name.Alias("CategoryName")   ).
                    OrderBy(ShopExtendInfo._.DisplayOrder).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            
        }
         public ShopExtendInfo GetEntity(string id)
        {
            
            return Dal.Find<ShopExtendInfo>(id) ;
        }


        public int SaveAttrVal(ShopExtendInfoValue p)
        {
            return Dal.Submit(p);
        }

     
    }

    
}
