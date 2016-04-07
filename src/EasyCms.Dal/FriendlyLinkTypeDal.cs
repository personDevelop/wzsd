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
    public class FriendlyLinkTypeDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("FriendlyLinkType", "ID", id, out error);
            return error;
        }

        public int Save(FriendlyLinkType item)
        {
            return Dal.Submit(item); 
        }

        public DataTable GetList( )
        { 
                return Dal.From<FriendlyLinkType>().OrderBy(FriendlyLinkType._.Code).ToDataTable();
        }
        public bool Exit(string ID,   string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = FriendlyLinkType._.Code == val;
            }
            else
            {
                where = FriendlyLinkType._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && FriendlyLinkType._.ID != ID;

            }
            return !Dal.Exists<FriendlyLinkType>(where);
        }
         
        public FriendlyLinkType GetEntity(string id)
        { 

            return Dal.Find<FriendlyLinkType>(id);
        }

 
         


    }

  
}
