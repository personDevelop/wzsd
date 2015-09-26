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
    public class RangeDictDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = "";
            Dal.Delete("RangeDict", "ID", id, out error);
            return error;
        }

        public int Save(RangeDict item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<RangeDict>().Select(RangeDict._.ID, RangeDict._.RankLevel, RangeDict._.Name).OrderBy(RangeDict._.RankLevel).ToDataTable();
            }
            else
                return Dal.From<RangeDict>().OrderBy(RangeDict._.RankLevel).ToDataTable();
        }
        public bool Exit(string ID,  string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = RangeDict._.RankLevel == val;
            }
            else
            {
                where = RangeDict._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && RangeDict._.ID != ID;

            }
            return !Dal.Exists<RangeDict>(where);
        }
     
       
        public RangeDict GetEntity(string id)
        {
            return Dal.Find<RangeDict>(id);
        }





    }
 
}
