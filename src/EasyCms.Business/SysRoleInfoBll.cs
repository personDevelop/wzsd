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
    public class SysRoleInfoBll
    {
        SysRoleInfoDal Dal = new SysRoleInfoDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(SysRoleInfo item)
        {
            return Dal.Save(item);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }

        public bool Exit(string ID, string ParentID, string RecordStatus, string val, bool IsCode)
        {
            return Dal.Exit(ID, ParentID, RecordStatus, val, IsCode);

        }


        public SysRoleInfo GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }


        public DataTable GetRoleClass()
        {

            return Dal.GetRoleClass();
        }

    }
}
