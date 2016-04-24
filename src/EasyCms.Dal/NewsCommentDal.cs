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
    public class NewsCommentDal : Sharp.Data.BaseManager 
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            string[] ids = id.Split(',');
            foreach (var item in ids)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    Dal.Delete("NewsComment", "ID", item, out error);
                }
            }
            return error;
        }

        public int Save(NewsComment item)
        {
            return CommonDal.UpdatePath<NewsComment>(Dal, item, NewsComment._.ID, NewsComment._.ParentID, ParameterInfo._.ClassCode, null, null, null);



        }



        public DataTable GetListByNewsID(string newsID, int order, int pagenum, int pagesize, ref int recordCount,
            ref int goodCount, ref int middleCount, ref int badCount)
        {

            int pageCount = 0;
            WhereClip where = NewsComment._.ContentId == newsID && NewsComment._.State == DjStatus.生效;

            return Dal.From<NewsComment>()
                .Join<ManagerUserInfo>(NewsComment._.CreatedUserID == ManagerUserInfo._.ID,  JoinType.leftJoin)
                .Where(where)
                .Select(NewsComment._.ID, NewsComment._.Description,

                  NewsComment._.CreatedDate, new ExpressionClip("case when IsManager=1   then NickyName when IsAnony =1 then '匿名' when NickyName is null or NickyName ='' then name else  NickyName end").Alias("Name")
                ).OrderBy(NewsComment._.CreatedDate.Desc)
                .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }


        public DataTable GetList(int pagenum, int pagesize, WhereClip where, ref int recordCount)
        {

            int pageCount = 0;

            return Dal.From<NewsComment>()
              .Join<ManagerUserInfo>(NewsComment._.CreatedUserID == ManagerUserInfo._.ID, JoinType.leftJoin)
                 .Join<NewsInfo>(NewsInfo._.ID == NewsComment._.ContentId)
                .Where(where)
                .Select(NewsComment._.ID, NewsComment._.Description, NewsComment._.ParentID, NewsComment._.State,
                NewsInfo._.NewsTitle,
                  NewsComment._.CreatedDate, ManagerUserInfo._.Code, ManagerUserInfo._.Name, ManagerUserInfo._.IsManager
                ).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public NewsComment GetEntity(string id)
        {
            NewsComment sr = Dal.From<NewsComment>()
                 .Join<ManagerUserInfo>(NewsComment._.CreatedUserID == ManagerUserInfo._.ID, JoinType.leftJoin)
                   .Join<NewsInfo>(NewsInfo._.ID == NewsComment._.ContentId)

                  .Where(NewsComment._.ID == id)
                  .Select(NewsComment._.ID.All,
              NewsInfo._.NewsTitle.Alias("NewsName"),
                     ManagerUserInfo._.Name.Alias("UserName")
                  ).ToFirst<NewsComment>();

            List<NewsComment> lastReplay = Dal.From<NewsComment>()
                    .Join<ManagerUserInfo>(NewsComment._.CreatedUserID == ManagerUserInfo._.ID, JoinType.leftJoin)

                      .Where(NewsComment._.ParentID == id).Select(ManagerUserInfo._.Name.Alias("UserName"), NewsComment._.Description,
                      NewsComment._.CreatedDate).List<NewsComment>();
            string reply = string.Empty;

            foreach (var item in lastReplay)
            {
                if (!string.IsNullOrWhiteSpace(reply))
                {
                    reply += "<br/>";

                }
                reply
                    += item.UserName + " " + item.CreatedDate.ToString("yyyy-MM-dd HH:mm") + "<br/>" + item.Description;
            }
            sr.LastReply = reply;
            return sr;
        }

        public string Approve(string shopCommentID, bool isPass)
        {
            string[] ids = shopCommentID.Split(',');
            NewsComment p = new NewsComment();
            p.Where = NewsComment._.ID.In(ids);
            p.RecordStatus = StatusType.update;
            if (isPass)
            {
                p.State = DjStatus.生效;

            }
            else
            { p.State = DjStatus.审批不通过; }
            Dal.Submit(p);
            return string.Empty;
        }

        public int Reply(NewsComment p)
        {
            int i = Save(p.CurrentNewsComment);
            i += Dal.Submit(p);
            return i;
        }

     
      }


}
