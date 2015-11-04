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
    public class SendMsgInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("SendMsgInfo", "ID", id, out error);
            return error;
        }

        public int Save(SendMsgInfo item)
        {
            return Dal.Submit(item);

        }
         
     
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount)
        {
            int pageCount = 0;

            return Dal.From<SendMsgInfo>().ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);

        }
        public SendMsgInfo GetEntity(string id)
        {
            return Dal.Find<SendMsgInfo>(id);

        }




        public List<SendMsgInfo> GetList(WhereClip where)
        {
            return Dal.From<SendMsgInfo>().Where(where).OrderBy(SendMsgInfo._.SendTool).List<SendMsgInfo>();
        }
    }


}
