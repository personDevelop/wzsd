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

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
         
 
        public NewsInfo GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

 

    }
}
