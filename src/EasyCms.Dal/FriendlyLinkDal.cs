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
    public class FriendlyLinkDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("FriendlyLink", "ID", id, out error);
            return error;
        }

        public int Save(FriendlyLink item)
        {

            return Dal.Submit(item); 
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<FriendlyLink>().Select(FriendlyLink._.ID,   FriendlyLink._.LinkAlt, FriendlyLink._.Name, FriendlyLink._.GroupTag).OrderBy(FriendlyLink._.GroupTag, FriendlyLink._.OrderNo).ToDataTable();
            }
            else
                return Dal.From<FriendlyLink>().OrderBy(FriendlyLink._.GroupTag, FriendlyLink._.OrderNo).ToDataTable();
        }
      
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<FriendlyLink>() .Select(FriendlyLink._.ID, FriendlyLink._.LinkAlt, FriendlyLink._.Name, FriendlyLink._.GroupTag ).OrderBy(FriendlyLink._.GroupTag, FriendlyLink._.OrderNo).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<FriendlyLink>()  .OrderBy(FriendlyLink._.GroupTag,FriendlyLink._.OrderNo)

                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }
      
        public FriendlyLink GetEntity(string id)
        {
          

            return Dal.Find<FriendlyLink>(id) ;
        }

 

    }
     
}
