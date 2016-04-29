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
        public string DeleteAttrVal(string id, out string error)
        {
            error = string.Empty;
        string extendid=    Dal.From<ShopExtendInfoValue>().Where(ShopExtendInfoValue._.ID == id).Select(ShopExtendInfoValue._.AttributeId).ToScalar() as string;
              Dal.Delete("ShopExtendInfoValue", "ID", id, out error);
            List<SimpalShopExtendInfoValue> childValue = Dal.From<ShopExtendInfoValue>()
              .Join<AttachFile>(ShopExtendInfoValue._.ImageID == AttachFile._.RefID, JoinType.leftJoin)
              .Select(ShopExtendInfoValue._.ID, ShopExtendInfoValue._.ValueStr, AttachFile.GetThumbnaifilePath("", "ImgUrl"))
              .Where(ShopExtendInfoValue._.AttributeId == extendid)
              .OrderBy(ShopExtendInfoValue._.DisplaySequence).ToDataTable().ToList<SimpalShopExtendInfoValue>();
            ShopExtendInfo extendInfo = new ShopExtendInfo() { RecordStatus = StatusType.update, Where = ShopExtendInfo._.ID == extendid };

            if (childValue.Count > 0)
            {

                extendInfo.ValInfo = JsonWithDataTable.Serialize(childValue);
              
            }
            else
            {
                extendInfo.ValInfo = string.Empty;
            }
            Dal.Submit(extendInfo);
            return error;
        }

        public int Save(ShopExtendInfo item)
        {
            return Dal.Submit(item);

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

        public DataTable GetList(string categoryID, string name, string pTypeID, UsageMode usageMode, int pagenum, int pagesize, ref int recordCount)
        {
            DataTable dt = null;
            string sql = "select ExtendID from ShopExtendAndType where TypeID='" + "pTypeID" + "'";
            WhereClip where = new WhereClip(string.Format(" NOT EXISTS (select 1  from ShopExtendAndType where TypeID='{0}' AND ShopExtendInfo.ID=ExtendID)", pTypeID));

            where = where && (ShopExtendInfo._.Name.Contains(name) || ShopExtendInfo._.FullName.Contains(name));
            if (!string.IsNullOrWhiteSpace(categoryID))
                where = where && ShopExtendInfo._.CategoryID == categoryID;
            if ((int)usageMode > 1) where = where && ShopExtendInfo._.UsageMode > 1;
            else where = where && ShopExtendInfo._.UsageMode < 2;
            int pagecount = 0;
            dt = Dal.From<ShopExtendInfo>().Join<AttributeType>(ShopExtendInfo._.CategoryID == AttributeType._.ID)
                .Select(ShopExtendInfo._.ID.All, AttributeType._.Name.Alias("CategoryName"))
                  .OrderBy(ShopExtendInfo._.DisplayOrder)
                .Where(where).ToDataTable(pagesize, pagenum, ref pagecount, ref recordCount);
            return dt;
        }

        public bool Exit(string ID, string categoryID, string RecordStatus, string val)
        {
            WhereClip where = ShopExtendInfo._.CategoryID == categoryID;


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



        public DataTable GetList(string categoryID, string name, int pagenum, int pagesize, ref int recordCount)
        {
            DataTable dt = null;

            WhereClip where = (ShopExtendInfo._.Name.Contains(name) || ShopExtendInfo._.FullName.Contains(name));
            if (!string.IsNullOrWhiteSpace(categoryID))
                where = where && ShopExtendInfo._.CategoryID == categoryID;
            int pagecount = 0;
            dt = Dal.From<ShopExtendInfo>().Join<AttributeType>(ShopExtendInfo._.CategoryID == AttributeType._.ID)
                .Select(ShopExtendInfo._.ID.All, AttributeType._.Name.Alias("CategoryName"))
                .OrderBy(ShopExtendInfo._.DisplayOrder)
                .Where(where).ToDataTable(pagesize, pagenum, ref pagecount, ref recordCount);

            return dt;
        }
        public ShopExtendInfo GetEntity(string id)
        {

            return Dal.Find<ShopExtendInfo>(id);
        }


        public string SaveAttrVal(ShopExtendInfoValue p)
        {
            List<BaseEntity> list = new List<BaseEntity>();
            list.Add(p);
            string result = string.Empty;
            if (p.RecordStatus == StatusType.add)
            {
                int count = Dal.Count<ShopExtendInfoValue>(ShopExtendInfoValue._.AttributeId == p.AttributeId, ShopExtendInfoValue._.ID, false);
                p.DisplaySequence = count;
                if (string.IsNullOrWhiteSpace(p.ImageID))
                {
                    string[] val = p.ValueStr.Split(new char[] { '，', ',','；',';'}, StringSplitOptions.RemoveEmptyEntries);
                    if (val.Length > 1)
                    {

                        for (int i = 0; i < val.Length; i++)
                        {
                            if (i == 0)
                            {
                                p.ValueStr = val[i];
                            }
                            else
                            {



                                list.Add(new ShopExtendInfoValue() { ID = Guid.NewGuid().ToString(), AttributeId = p.AttributeId,
                                    DisplaySequence = count + i, ImageID = p.ImageID, Note = p.Note, ValueStr = val[i] 
                                });
                            }
                            
                        }
                    }
                    
                }
                
            }
            Dal.Submit(list);

            List<SimpalShopExtendInfoValue> childValue = Dal.From<ShopExtendInfoValue>()
                .Join<AttachFile>(ShopExtendInfoValue._.ImageID == AttachFile._.RefID, JoinType.leftJoin)
                .Select(ShopExtendInfoValue._.ID, ShopExtendInfoValue._.ValueStr, AttachFile.GetThumbnaifilePath("", "ImgUrl"))
                .Where(ShopExtendInfoValue._.AttributeId == p.AttributeId)
                .OrderBy(ShopExtendInfoValue._.DisplaySequence).ToDataTable().ToList<SimpalShopExtendInfoValue>();

            if (childValue.Count > 0)
            {
                ShopExtendInfo extendInfo = new ShopExtendInfo() { RecordStatus = StatusType.update, Where = ShopExtendInfo._.ID == p.AttributeId };

                extendInfo.ValInfo = JsonWithDataTable.Serialize(childValue);
                Dal.Submit(extendInfo);
            }

            return result;
        }


    }


}
