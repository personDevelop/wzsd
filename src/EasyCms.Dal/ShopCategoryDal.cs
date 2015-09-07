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
            return "";
            //if (string.IsNullOrWhiteSpace(id))
            //{
            //    return "要删除的参数值不能为空";
            //}
            //int state = (int)Dal.From<ShopCategory>().Select(ShopCategory._.State).ToScalar();
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
            //Eixt = Dal.Exists<ShopCategory>(ShopCategory._.ParentID == id);
            //if (Eixt)
            //{
            //    return "当前新闻分类下含有子分类 ,不能删除";
            //}
            //int i = Dal.Delete<ShopCategory>(id);
            //if (i == 0)
            //{
            //    return "删除失败";
            //}
            //else
            //{
            //    return "成功删除分类";
            //}
        }

        public int Save(ShopCategory item)
        {
            return CommonDal.UpdatePath<ShopCategory>(Dal, item, ShopCategory._.ID, ShopCategory._.ParentID, ShopCategory._.ClassCode, ShopCategory._.OrderNo, ShopCategory._.Depth, ShopCategory._.IsMx);

        }
     
        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<ShopCategory>().Select(ShopCategory._.ID, ShopCategory._.ParentID, ShopCategory._.Code, ShopCategory._.Name).OrderBy(ShopCategory._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<ShopCategory>().OrderBy(ShopCategory._.OrderNo).ToDataTable();
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



        public DataTable GetAppEntity(string id, string host)
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

        public string GetClassCode(string categoryID)
        {
            return Dal.From<ShopCategory>().Where(ShopCategory._.ID == categoryID).Select(ShopCategory._.ClassCode).ToScalar() as string;
        }
    }


}
