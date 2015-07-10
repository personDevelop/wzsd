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
    public class SysRoleInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return "要删除的参数值不能为空";
            }

            return "删除失败";

        }

        public int Save(SysRoleInfo item)
        {
            return Dal.Submit(item);

        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<SysRoleInfo>().Select(SysRoleInfo._.ID, SysRoleInfo._.Code, SysRoleInfo._.Name, SysRoleInfo._.RoleClass).OrderBy(SysRoleInfo._.Code).ToDataTable();
            }
            else
                return Dal.From<SysRoleInfo>().OrderBy(SysRoleInfo._.Code).ToDataTable();
        }
        public bool Exit(string ID, string parentID, string RecordStatus, string val, bool IsCode)
        {
            WhereClip where = null;

            if (IsCode)
            {
                where = SysRoleInfo._.Code == val;
            }
            else
            {
                where = SysRoleInfo._.Name == val;
            }
            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && SysRoleInfo._.ID != ID;

            }
            return !Dal.Exists<SysRoleInfo>(where);
        }

        public SysRoleInfo GetEntity(string id)
        {
            return Dal.Find<SysRoleInfo>(id);
        }





        public DataTable GetRoleClass()
        {
            return Dal.From<SysRoleInfo>().Select(SysRoleInfo._.RoleClass).Distinct().OrderBy(SysRoleInfo._.RoleClass).ToDataTable();
        }
    }


}
