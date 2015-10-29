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
    public class SysMsgTempSetDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("SysMsgTempSet", "ID", id, out error);
            return error;
        }

        public int Save(SysMsgTempSet item)
        {
          return   Dal.Submit(item);

        }


        public bool Exit(string ID, string RecordStatus, int sendType, bool IsManager)
        {
            WhereClip where = SysMsgTempSet._.SendType == sendType && SysMsgTempSet._.IsManager == IsManager;

            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && SysMsgTempSet._.ID != ID;

            }
            return !Dal.Exists<SysMsgTempSet>(where);
        }
        public DataTable GetList()
        {

            return Dal.From<SysMsgTempSet>().ToDataTable();

        }

        public SysMsgTempSet GetEntity(string id)
        {


            return Dal.Find<SysMsgTempSet>(id);
        }




    }


}
