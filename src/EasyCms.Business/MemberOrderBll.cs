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
    public class RangeDictBll
    {
        RangeDictDal Dal = new RangeDictDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(RangeDict item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
       
        public bool Exit(string ID,  string RecordStatus, string val, bool IsCode)
        {
            return Dal.Exit(ID,   RecordStatus, val, IsCode);

        }
 
        public RangeDict GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }




 
        public RangeDict GetAccountRange(string accountID)
        {
            return Dal.GetAccountRange(accountID);
        }
    }
}
