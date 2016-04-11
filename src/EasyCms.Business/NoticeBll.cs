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
    public class NoticeBll
    {
        NoticeDal Dal = new NoticeDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(Notice item)
        {
            return Dal.Save(item);
        }

        
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = true)
        {
            return Dal.GetList(pagenum, pagesize, ref recordCount, IsForSelected);
        }
     
        public Notice GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

        

        public string Publish(string id, int stat)
        {
           return Dal.Publish(id,stat);
        }
    }
}
