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
    public class ManagerUserInfoBll
    {
        ManagerUserInfoDal Dal = new ManagerUserInfoDal();
        public string Delete(string id)
        {

            return Dal.Delete(id);
        }

        public int Save(ManagerUserInfo item)
        {
            return Dal.Save(item);
        }

        public string Regist(ManagerUserInfo item)
        { return string.Empty; }

        public ManagerUserInfo Login(string code, string pwd, out string error)
        {
            error = string.Empty;
            ManagerUserInfo item = Dal.GetEntityByCode(code);
            if (item == null)
            {
                error = "账号不存在！";

            }
            else if (pwd.EncryptSHA1() != item.Pwd)
            {

                error = "密码不正确！";
                item = null;
            }
            else if (item.Status != 1)
            {

                error = "账号不允许登陆！";
                item = null;
            }
            return item;
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount, IsForSelected);
        }
        public bool Exit(string ID, string ParentID, string RecordStatus, string val)
        {
            return Dal.Exit(ID, ParentID, RecordStatus, val);

        }


        public ManagerUserInfo GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }





        public string Regist(RegistModel registModel)
        {
           return Dal.Regist(  registModel);
        }


      
    }
}
