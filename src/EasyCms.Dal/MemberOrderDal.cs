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
    public class MemberOrderDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        { 
                return "删除失败"; 
        }

        public int Save(MemberOrder item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<MemberOrder>().Select(MemberOrder._.ID, MemberOrder._.Code, MemberOrder._.Name).OrderBy(MemberOrder._.Code).ToDataTable();
            }
            else
                return Dal.From<MemberOrder>().OrderBy(MemberOrder._.Code).ToDataTable();
        }
        public bool Exit(string ID,  string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = MemberOrder._.Code == val;
            }
            else
            {
                where = MemberOrder._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && MemberOrder._.ID != ID;

            }
            return !Dal.Exists<MemberOrder>(where);
        }
     
       
        public MemberOrder GetEntity(string id)
        {
            return Dal.Find<MemberOrder>(id);
        }





    }
 
}
