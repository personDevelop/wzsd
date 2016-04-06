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
            string error = "";
            Dal.Delete("NewsInfo", "ID", id, out error);
            return error;

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


        public NewsInfo GetEntity(string id, string host)
        {
            NewsInfo news = GetEntity(id);
            if (news != null)
            {
                if (!string.IsNullOrWhiteSpace(news.ImageUrl))
                {
                    AttachFile f = Dal.Find<AttachFile>(AttachFile._.RefID == news.ImageUrl);
                    if (f != null && !string.IsNullOrWhiteSpace(f.FilePath))
                    {
                        news.ImageUrl = host + f.FilePath.Replace("~", "");
                    }

                }
            }
            return news;
        }

        public NewsInfo GetEntity(string id)
        {

       return  Dal.From<NewsInfo>().Join<NewsCategory>(NewsInfo._.ClassID == NewsCategory._.ID)
                .Join<ShopProductInfo>(NewsInfo._.ProducntID==ShopProductInfo._.ID,  JoinType.leftJoin)
                .Select(NewsInfo._.ID.All, NewsCategory._.Name.Alias("ClassName"), ShopProductInfo._.Name.Alias("ProductName"))
                 .Where(NewsInfo._.ID == id).ToFirst<NewsInfo>(); 
        }



        public DataTable GetAppNews(int page, string host)
        { //新闻id，定标题，简介，缩略图，新闻url 
            int pagecount = 0;
            return Dal.From<NewsInfo>().Join<AttachFile>(NewsInfo._.ImageUrl == AttachFile._.RefID, JoinType.leftJoin)
                .Select(NewsInfo._.ID, NewsInfo._.NewsTitle, NewsInfo._.Summary, AttachFile.GetThumbnaifilePath(host), new ExpressionClip("'" + host + "/api/app/getNew/'+ NewsInfo.id as Url"))
                .OrderBy(NewsInfo._.LastEditDate.Desc).ToDataTable(20, page, ref pagecount, ref pagecount);
        }
    }


}
