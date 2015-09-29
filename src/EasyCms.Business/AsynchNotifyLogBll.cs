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
    public class AsynchNotifyLogBll
    {
        AsynchNotifyLogDal Dal = new AsynchNotifyLogDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(AsynchNotifyLog item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(int pagenum, int pagesize, ref int recordCount)
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount);
        }
        public bool Exit(string notifyid, string tradeStatus)
        {
            return Dal.Exit(notifyid, tradeStatus);

        }

       
        public AsynchNotifyLog GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }

         


    }
}
