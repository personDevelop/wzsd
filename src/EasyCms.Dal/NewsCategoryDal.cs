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
    public class NewsCategoryDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return "要删除的参数值不能为空";
            }
            int state = (int)Dal.From<NewsCategory>().Select(NewsCategory._.State).ToScalar();
            if (state == (int)CategoryState.审核通过)
            {
                return "当前新闻分类已审核通过,不能删除";
            }
            string error = "";
            Dal.Delete("NewsCategory", "ID", id, out error);
            return error;
            ////判断是否已被新闻引用过
            //bool Eixt = Dal.Exists<NewsInfo>(NewsInfo._.ClassID == id);
            //if (Eixt)
            //{
            //    return "当前新闻分类已被使用,不能删除";
            //}
            //Eixt = Dal.Exists<NewsCategory>(NewsCategory._.ParentID == id);
            //if (Eixt)
            //{
            //    return "当前新闻分类下含有子分类 ,不能删除";
            //}
            //int i = Dal.Delete<NewsCategory>(id);
            //if (i == 0)
            //{
            //    return "删除失败";
            //}
            //else
            //{
            //    return "成功删除分类";
            //}
        }

        public int Save(NewsCategory item)
        {
            return CommonDal.UpdatePath<NewsCategory>(Dal, item, NewsCategory._.ID, NewsCategory._.ParentID, NewsCategory._.FJM, NewsCategory._.OrderNo, NewsCategory._.JS, null);

        }
       
        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<NewsCategory>().Select(NewsCategory._.ID, NewsCategory._.ParentID, NewsCategory._.Code, NewsCategory._.Name, NewsCategory._.AllowSubclass).OrderBy(NewsCategory._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<NewsCategory>().OrderBy(NewsCategory._.OrderNo).ToDataTable();
        }
        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = NewsCategory._.Code == val;
            }
            else
            {
                where = NewsCategory._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && NewsCategory._.ID != ID;

            }
            return !Dal.Exists<NewsCategory>(where);
        }

        public DataTable GetListByParentId(string parentId)
        {
            return Dal.From<NewsCategory>().Where(NewsCategory._.ParentID == parentId).OrderBy(NewsCategory._.OrderNo).ToDataTable();

        }
        public NewsCategory GetEntity(string id)
        {
            WhereClip where = new WhereClip("a.id=@id");
            where.Parameters.Add("id", id);

            return Dal.From<NewsCategory>("a").Join<NewsCategory>("b", new WhereClip("a.ParentID=b.ID"), JoinType.leftJoin)
                .Select(new ExpressionClip("a.*,b.Name ParentName"))
                .Where(where)
                .ToFirst<NewsCategory>();
        }


        public System.Data.DataTable GetListByFJM(string classCode)
        {
            return Dal.From<NewsCategory>().Where(NewsCategory._.ID != classCode && NewsCategory._.FJM.StartsWith(classCode)).OrderBy(NewsCategory._.OrderNo).ToDataTable();

        }

        public string[] GetNameByParentId(string parentId)
        {
            return Dal.From<NewsCategory>().Where(NewsCategory._.ParentID == parentId).OrderBy(NewsCategory._.OrderNo).Select(NewsCategory._.Name).ToSinglePropertyArray();
        }


    }

    public enum CategoryState
    {
        草稿,
        等待审核,
        审核通过
    }
}
