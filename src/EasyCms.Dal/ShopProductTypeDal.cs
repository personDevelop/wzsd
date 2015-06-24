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

        public int Save(ShopProductType item)
        {
            return Dal.Submit(item);

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
        public bool Exit(string ID,  string RecordStatus, string val, bool IsCode)
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

         

    }

}
