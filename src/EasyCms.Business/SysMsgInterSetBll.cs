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
    public class SysMsgInterSetBll
    {
        SysMsgInterSetDal Dal = new SysMsgInterSetDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(SysMsgInterSet item)
        {
            return Dal.Save(item);
        }


        public DataTable GetList()
        {
            return Dal.GetList();
        }
        public bool Exit(string ID, string RecordStatus, string val)
        {
            return Dal.Exit(ID, RecordStatus, val);

        }


        public SysMsgInterSet GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }




        public SysMsgInterSet GetEnableService(SendTool st)
        {

            return Dal.GetEnableService(st);
        }

        public int Save(MsgSendLog s)
        {
            return Dal.Save(s);
        }

        public DataTable GetViewLogList(int pagenum, int pagesize, ref int recordCount)
        {
            return Dal.GetViewLogList(  pagenum,   pagesize, ref   recordCount);
        }
    }

}
