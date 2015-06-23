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
    public class ShopBrandInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            return "";
            //if (string.IsNullOrWhiteSpace(id))
            //{
            //    return "要删除的参数值不能为空";
            //}
            //int state = (int)Dal.From<ShopBrandInfo>().Select(ShopBrandInfo._.State).ToScalar();
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
            //Eixt = Dal.Exists<ShopBrandInfo>(ShopBrandInfo._.ParentID == id);
            //if (Eixt)
            //{
            //    return "当前新闻分类下含有子分类 ,不能删除";
            //}
            //int i = Dal.Delete<ShopBrandInfo>(id);
            //if (i == 0)
            //{
            //    return "删除失败";
            //}
            //else
            //{
            //    return "成功删除分类";
            //}
        }

        public int Save(ShopBrandInfo item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<ShopBrandInfo>().Select(ShopBrandInfo._.ID,  ShopBrandInfo._.Code, ShopBrandInfo._.Name ).OrderBy(ShopBrandInfo._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<ShopBrandInfo>().OrderBy(ShopBrandInfo._.OrderNo).ToDataTable();
        }
        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = ShopBrandInfo._.Code == val;
            }
            else
            {
                where = ShopBrandInfo._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ShopBrandInfo._.ID != ID;

            }
            return !Dal.Exists<ShopBrandInfo>(where);
        }
 
        public ShopBrandInfo GetEntity(string id)
        {
            WhereClip where = new WhereClip("a.id=@id");
            where.Parameters.Add("id", id);

            return Dal.From<ShopBrandInfo>("a").Join<ShopBrandInfo>("b", new WhereClip("a.ParentID=b.ID"), JoinType.leftJoin)
                .Select(new ExpressionClip("a.*,b.Name ParentName"))
                .Where(where)
                .ToFirst<ShopBrandInfo>();
        }

 

    }
     
}
