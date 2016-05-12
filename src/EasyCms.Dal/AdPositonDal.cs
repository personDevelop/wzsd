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
    public class AdPositonDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("AdPositon", "ID", id, out error);
            return error;
        }

        public int Save(AdPositon item)
        {
            return Dal.Submit(item);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<AdPositon>().
                    Select(AdPositon._.ID,  AdPositon._.Code, AdPositon._.Name, AdPositon._.AdType,AdPositon._.Width,AdPositon._.Height)
                    .Where(AdPositon._.IsEnable==true)
                    .OrderBy(AdPositon._.Code).ToDataTable();
            }
            else
                return Dal.From<AdPositon>().OrderBy(AdPositon._.Code).ToDataTable();
        }
        public bool Exit(string ID,  string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = AdPositon._.Code == val;
            }
            else
            {
                where = AdPositon._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && AdPositon._.ID != ID;

            }
            return !Dal.Exists<AdPositon>(where);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<AdPositon>().Select(AdPositon._.ID, AdPositon._.Code, AdPositon._.Name, AdPositon._.AdType).OrderBy(AdPositon._.Code).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<AdPositon>() .OrderBy(AdPositon._.Code).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }
        
        public AdPositon GetEntity(string id)
        {
        
            return Dal.Find<AdPositon>(id);
        }


       

    }

   
}
