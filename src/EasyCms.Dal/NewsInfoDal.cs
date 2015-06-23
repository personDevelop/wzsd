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
    public class NewsInfoDal : Sharp.Data.BaseManager
    {
        public DataTable GetNews()
        {

            return Dal.From<NewsInfo>().ToDataTable();

        }
        public string Delete(string id)
        {

            int i = Dal.Delete<NewsInfo>(id);
            if (i == 0)
            {
                return "删除失败";
            }
            else
            {
                return "成功删除";
            }
        }

        public int Save(NewsInfo item)
        {

            return Dal.Submit(item);

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<NewsInfo>().Join<NewsCategory>(NewsInfo._.ClassID == NewsCategory._.ID, JoinType.leftJoin).Select(NewsInfo._.ID, NewsInfo._.ClassID, NewsInfo._.NewsTitle, NewsCategory._.Name.Alias("ClassName")).OrderBy(NewsInfo._.Sequence).ToDataTable();
            }
            else
                return Dal.From<NewsInfo>().Join<NewsCategory>(NewsInfo._.ClassID == NewsCategory._.ID, JoinType.leftJoin).Select(NewsInfo._.ID.All, NewsCategory._.Name.Alias("ClassName")).OrderBy(NewsInfo._.Sequence).ToDataTable();
        }


        public NewsInfo GetEntity(string id)
        {
            return Dal.Find<NewsInfo>(id);
        }




    }


}
