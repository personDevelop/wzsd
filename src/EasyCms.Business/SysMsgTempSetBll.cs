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
    public class SysMsgTempSetBll
    {
        SysMsgTempSetDal Dal = new SysMsgTempSetDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(SysMsgTempSet item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList( )
        {
            return Dal.GetList( );
        }
       
        public bool Exit(string ID, string RecordStatus, int sendType, bool IsManager)
        {
            return Dal.Exit(ID, RecordStatus, sendType, IsManager);

        }

       
        public SysMsgTempSet GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }
         


    }
}
