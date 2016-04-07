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

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, ref recordCount, IsForSelected);
        }
        

        public DataTable GetListByParentId(string parentId)
        {
            return Dal.GetListByParentId(parentId);

        }
        public NewsComment GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

 


    }
}
