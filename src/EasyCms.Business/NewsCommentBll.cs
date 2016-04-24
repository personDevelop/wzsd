using EasyCms.Dal;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common;

namespace EasyCms.Business
{
    public class NewsCommentBll
      
    {
        NewsCommentDal Dal = new NewsCommentDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(NewsComment item)
        {
            return Dal.Save(item);
        }


        public DataTable GetListByNewsID(string Newsid, int order, int pagenum, int pagesize, ref int recordCount, ref int goodCount, ref int middleCount, ref int badCount)
        {
            return Dal.GetListByNewsID(Newsid, order, pagenum, pagesize, ref recordCount, ref goodCount, ref middleCount, ref badCount);
        }



        public DataTable GetList(int pagenum, int pagesize, WhereClip where, ref int recordCount)
        {
            return Dal.GetList(pagenum, pagesize, where, ref recordCount);
        }

        public NewsComment GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

        public string Approve(string shopCommentID, bool isPass)
        {
            return Dal.Approve(shopCommentID, isPass);
        }

        public int Reply(NewsComment p)
        {
            return Dal.Reply(p);
        }



 
    }
}
