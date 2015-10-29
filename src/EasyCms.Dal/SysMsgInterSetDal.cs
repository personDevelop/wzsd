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
    public class SysMsgInterSetDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("SysMsgInterSet", "ID", id, out error);
            return error;
        }

        public int Save(SysMsgInterSet item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList( )
        {

            return Dal.From<SysMsgInterSet>().ToDataTable();

        }
        public bool Exit(string ID, string RecordStatus, string val )
        {
            WhereClip where = SysMsgInterSet._.Name == val;

            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && SysMsgInterSet._.ID != ID;

            }
            return !Dal.Exists<SysMsgInterSet>(where);
        }
      

        public SysMsgInterSet GetEntity(string id)
        {
            return Dal.Find<SysMsgInterSet>(id);
        }




    }


}
