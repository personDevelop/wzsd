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
            Dal.Delete("NewsComment", "ID", id, out error);
            return error;
        }

        public int Save(NewsComment item)
        {
            return Dal.Submit(item);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<NewsComment>().Select(NewsComment._.ID, NewsComment._.ParentID, NewsComment._.Description   ).OrderBy(NewsComment._.CreatedDate).ToDataTable();
            }
            else
                return Dal.From<NewsComment>().OrderBy(NewsComment._.CreatedDate).ToDataTable();
        }
    
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<NewsComment>().Select(NewsComment._.ID, NewsComment._.ParentID, NewsComment._.Description).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<NewsComment>().   OrderBy(NewsComment._.CreatedDate)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }
        public DataTable GetListByParentId(string parentId)
        {
            return Dal.From<NewsComment>().Where(NewsComment._.ParentID == parentId).OrderBy(NewsComment._.CreatedDate).ToDataTable();

        }
        public NewsComment GetEntity(string id)
        {
          
            return Dal.Find<NewsComment>(id);
        }
 

    }

     
}
