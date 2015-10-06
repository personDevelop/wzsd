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
    public class SysRoleAndUserRalationBll
    {
        SysRoleAndUserRalationDal Dal = new SysRoleAndUserRalationDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(SysRoleAndUserRalation item)
        {
            return Dal.Save(item);
        }



        public DataTable GetRolePersonList(int pagenum, int pagesize, string roleID, ref int recordCount)
        {
            return Dal.GetRolePersonList(  pagenum,   pagesize,   roleID, ref   recordCount);
        }

        public DataTable GetForAddPersonList(string RoleID)
        {
            return Dal.GetForAddPersonList(RoleID);
        }

        public string AddPersonToRole(string roleID, List<string> personIDS)
        {
            return Dal.AddPersonToRole(  roleID,  personIDS);
        }
    }
}
