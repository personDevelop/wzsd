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
    public class SendMsgInfoBll
    {
        SendMsgInfoDal Dal = new SendMsgInfoDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(SendMsgInfo item)
        {
            return Dal.Save(item);
        }

        
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount )
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount );
        }
         
        public SendMsgInfo GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }





        public List<SendMsgInfo> GetList(WhereClip where)
        {
            return Dal.GetList(where);
        }
    }
}
