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
    public class SysRoleAndUserRalationDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {
            string error = string.Empty;
            Dal.Delete("SysRoleAndUserRalation", "ID", id, out error);
            return error;
        }

        public int Save(SysRoleAndUserRalation item)
        {
            return Dal.Submit(item);

        }


           


        public DataTable GetRolePersonList(int pagenum, int pagesize, string roleID, ref int recordCount)
        {
            int pagecount = 0;
            return Dal.From<ManagerUserInfo>().Join<SysRoleAndUserRalation>(ManagerUserInfo._.ID == SysRoleAndUserRalation._.UserId && SysRoleAndUserRalation._.RoleId == roleID).Select(SysRoleAndUserRalation._.ID, ManagerUserInfo._.Code, ManagerUserInfo._.Name).ToDataTable(pagesize, pagenum, ref pagecount, ref recordCount);
        }

        public DataTable GetForAddPersonList(string RoleID)
        {
            string[] hasRolePersonID = Dal.From<SysRoleAndUserRalation>().Where(SysRoleAndUserRalation._.RoleId == RoleID).Select(SysRoleAndUserRalation._.UserId).ToSinglePropertyArray();
            WhereClip where =ManagerUserInfo._.IsManager==true&& ManagerUserInfo._.Status == (int)UserStatus.正常;
            if (hasRolePersonID != null && hasRolePersonID.Length > 0)
            {
                where = where && !ManagerUserInfo._.ID.In(hasRolePersonID);
            }

            return Dal.From<ManagerUserInfo>().Where(where).OrderBy(ManagerUserInfo._.Code)
                .Select(ManagerUserInfo._.ID, ManagerUserInfo._.Code, ManagerUserInfo._.Name)
                .ToDataTable();
        }

        public string AddPersonToRole(string roleID, List<string> personIDS)
        {
            List<SysRoleAndUserRalation> list = new List<SysRoleAndUserRalation>();
            foreach (var item in personIDS)
            {
                list.Add(new SysRoleAndUserRalation()
                {
                    ID = Guid.NewGuid().ToString(),
                    RoleId = roleID,
                    IsDefault = true,
                    UserId = item
                });
            }
            Dal.Submit(list);
            return string.Empty;
        }
    }

}
