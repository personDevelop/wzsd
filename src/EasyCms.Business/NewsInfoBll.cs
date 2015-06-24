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
    public class NewsInfoBll
    {
        NewsInfoDal Dal = new NewsInfoDal();
        public DataTable GetNews()
        {

            return Dal.GetNews();

        }
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(NewsInfo item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount, IsForSelected);
        }


        public NewsInfo GetEntity(string id, string host)
        {
            return Dal.GetEntity(id, host);
        }

        public NewsInfo GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }


        public DataTable GetAppNews(int page, string host)
        {
            return Dal.GetAppNews(page, host);
        }
    }
}
