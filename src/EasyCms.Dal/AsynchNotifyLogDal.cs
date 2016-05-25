using AliPayCommon;
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
    public class AsynchNotifyLogDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("AsynchNotifyLog", "ID", id, out error);
            return error;
        }

        public int Save(AsynchNotifyLog item)
        {
            return Dal.Submit(item);

        }

        public bool Exit(string notifyid, string tradeStatus)
        {
            WhereClip where = AsynchNotifyLog._.TradeNo == notifyid && AsynchNotifyLog._.TradeStatus == tradeStatus;

            return Dal.Exists<AsynchNotifyLog>(where);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount)
        {
            int pageCount = 0;

            return Dal.From<AsynchNotifyLog>().OrderBy(AsynchNotifyLog._.TradeNo, AsynchNotifyLog._.CreateTime)
                .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public AsynchNotifyLog GetEntity(string id)
        {
            return Dal.Find<AsynchNotifyLog>(id);
        }




    }

}
