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
    public class ShopCategoryDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = "";
            Dal.Delete("ShopCategory", "ID", id, out error);
            return error;
        }

        public int Save(ShopCategory item)
        {
            return CommonDal.UpdatePath<ShopCategory>(Dal, item, ShopCategory._.ID, ShopCategory._.ParentID, ShopCategory._.ClassCode, ShopCategory._.OrderNo, ShopCategory._.Depth, ShopCategory._.IsMx);

        }

        public List<ShopCategory> GetShowIndex(string host)
        {
     return       Dal.From<ShopCategory>().Join<AttachFile>(ShopCategory._.BigLogo == AttachFile._.RefID, JoinType.leftJoin)
                .Select(ShopCategory._.ID, ShopCategory._.Name, AttachFile.GetCompressionfilePath(host, "LogoUrl")).Where(ShopCategory._.Depth == 0 && ShopCategory._.IsShow == true)
                .OrderBy(ShopCategory._.OrderNo).List<ShopCategory>();
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<ShopCategory>().Select(ShopCategory._.ID, ShopCategory._.ParentID, ShopCategory._.AssociatedProductType, ShopCategory._.IsShow, ShopCategory._.PriceArea, ShopCategory._.Code, ShopCategory._.Name).OrderBy(ShopCategory._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<ShopCategory>().OrderBy(ShopCategory._.OrderNo).ToDataTable();
        }
        public List<ShopCategory> GetListWithNavi(string parentID, int maxLayer)
        {
            WhereClip where = null;

            if (string.IsNullOrWhiteSpace(parentID))
            {
                where = ShopCategory._.Depth < 3;
            }
            else
            {
                ShopCategory current = Dal.From<ShopCategory>().
                    Where(ShopCategory._.ID == parentID)
                    .Select(ShopCategory._.Depth, ShopCategory._.ClassCode).ToFirst<ShopCategory>();
                maxLayer += current.Depth;
                where = ShopCategory._.ClassCode.StartsWith(current.ClassCode) && ShopCategory._.Depth < maxLayer;
            }

            return Dal.From<ShopCategory>().Select(ShopCategory._.ID, ShopCategory._.ParentID,ShopCategory._.Name, ShopCategory._.HasIndex, ShopCategory._.GroupNo, ShopCategory._.IndexUrl, ShopCategory._.Depth).Where(where).OrderBy(ShopCategory._.OrderNo).List<ShopCategory>();
        }
     

        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = ShopCategory._.Code == val;
            }
            else
            {
                where = ShopCategory._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopCategory._.ID != ID;

            }
            return !Dal.Exists<ShopCategory>(where);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<ShopCategory>().Select(ShopCategory._.ID, ShopCategory._.Name).OrderBy(ShopCategory._.OrderNo).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<ShopCategory>().OrderBy(ShopCategory._.OrderNo)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }
        public DataTable GetListByParentId(string parentId)
        {
            return Dal.From<ShopCategory>().Where(ShopCategory._.ParentID == parentId).OrderBy(ShopCategory._.OrderNo).ToDataTable();

        }
        public ShopCategory GetEntity(string id)
        {
            WhereClip where = new WhereClip("a.id=@id");
            where.Parameters.Add("id", id);

            return Dal.From<ShopCategory>("a").Join<ShopCategory>("b", new WhereClip("a.ParentID=b.ID"), JoinType.leftJoin)
                .Select(new ExpressionClip("a.*,b.Name ParentName"))
                .Where(where)
                .ToFirst<ShopCategory>();
        }


        public System.Data.DataTable GetListByClassCode(string classCode)
        {
            return Dal.From<ShopCategory>().Where(ShopCategory._.ID != classCode && ShopCategory._.ClassCode.StartsWith(classCode)).OrderBy(ShopCategory._.OrderNo).ToDataTable();

        }

        public string[] GetNameByParentId(string parentId)
        {
            return Dal.From<ShopCategory>().Where(ShopCategory._.ParentID == parentId).OrderBy(ShopCategory._.OrderNo).Select(ShopCategory._.Name).ToSinglePropertyArray();
        }



        public DataTable GetAppEntityList(string id, string host)
        {
            WhereClip where = new WhereClip();
            if (string.IsNullOrWhiteSpace(id))
            {
                where = ShopCategory._.ParentID.IsNullOrEmpty();
            }
            else
            {
                where = ShopCategory._.ParentID == id;
            }
            DataTable dt = Dal.From<ShopCategory>()
                .Join<AttachFile>(ShopCategory._.SmallLogo == AttachFile._.RefID, JoinType.leftJoin)
                .Where(where).Select(ShopCategory._.ID, ShopCategory._.Code, ShopCategory._.Name, ShopCategory._.ClassCode, AttachFile.GetFilePath(host, "SmallLogo"))
                .OrderBy(ShopCategory._.OrderNo).ToDataTable();
            return dt;
        }
        public DataTable GetAppEntity(string id, string host)
        {
            WhereClip where = ShopCategory._.ID == id;
            
            DataTable dt = Dal.From<ShopCategory>()
                .Join<AttachFile>(ShopCategory._.SmallLogo == AttachFile._.RefID, JoinType.leftJoin)
                .Where(where).Select(ShopCategory._.ID, ShopCategory._.Code, ShopCategory._.Name, ShopCategory._.ClassCode, AttachFile.GetFilePath(host, "SmallLogo"))
                .OrderBy(ShopCategory._.OrderNo).ToDataTable();
            return dt;
        }
        public string[] GetClassCode(string categoryID)
        {
            string s= Dal.From<ShopCategory>().Where(ShopCategory._.ID == categoryID).Select(ShopCategory._.ClassCode).ToScalar() as string;
         return    Dal.From<ShopCategory>().Where(ShopCategory._.ClassCode.StartsWith(s)).Select(ShopCategory._.ID).ToSinglePropertyArray();
        }
    }


}
