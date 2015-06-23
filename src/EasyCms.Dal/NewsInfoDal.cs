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

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<NewsInfo>().Join<NewsCategory>(NewsInfo._.ClassID == NewsCategory._.ID, JoinType.leftJoin).Select(NewsInfo._.ID, NewsInfo._.ClassID, NewsInfo._.NewsTitle, NewsCategory._.Name.Alias("ClassName")).OrderBy(NewsInfo._.Sequence).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<NewsInfo>().Join<NewsCategory>(NewsInfo._.ClassID == NewsCategory._.ID, JoinType.leftJoin).Select(NewsInfo._.ID.All, NewsCategory._.Name.Alias("ClassName")).OrderBy(NewsInfo._.Sequence)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }


        public NewsInfo GetEntity(string id)
        {
            return Dal.Find<NewsInfo>(id);
        }





        public DataTable GetAppNews(int page)
        { //新闻id，定标题，简介，缩略图，新闻url 
            int pagecount = 0;
            return Dal.From<NewsInfo>().Join<AttachFile>(NewsInfo._.ImageUrl == AttachFile._.RefID, JoinType.leftJoin)
                .Select(NewsInfo._.ID, NewsInfo._.NewsTitle, NewsInfo._.Summary, AttachFile._.FilePath, new ExpressionClip("'/api/app/getNew/'+ NewsInfo.id as Url"))
                .OrderBy(NewsInfo._.LastEditDate.Desc).ToDataTable(20, page, ref pagecount, ref pagecount);
        }
    }


}
