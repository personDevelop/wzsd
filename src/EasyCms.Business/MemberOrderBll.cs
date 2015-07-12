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
    public class MemberOrderBll
    {
        MemberOrderDal Dal = new MemberOrderDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(MemberOrder item)
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
 
        public MemberOrder GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }


      


    }
}
