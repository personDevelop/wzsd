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
    public class ManagerUserInfoDal : Sharp.Data.BaseManager
    {
        public string Delete(string id)
        {

            string error = "";
            Dal.Delete("ManagerUserInfo", "ID", id, out error);
            return error;


        }

        public int Save(ManagerUserInfo item)
        {
            return Dal.Submit(item);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            if (IsForSelected)
            {
                return Dal.From<ManagerUserInfo>().Select(ManagerUserInfo._.ID, ManagerUserInfo._.Code, ManagerUserInfo._.Name).OrderBy(ManagerUserInfo._.Code).ToDataTable();
            }
            else
                return Dal.From<ManagerUserInfo>().OrderBy(ManagerUserInfo._.Code).ToDataTable();
        }
        public bool Exit(string ID, string parentID, string RecordStatus, string val)
        {
            WhereClip where = ManagerUserInfo._.Name == val;

            if (RecordStatus == StatusType.update.ToString())
            {
                where = where && ManagerUserInfo._.ID != ID;
            }
            return !Dal.Exists<ManagerUserInfo>(where);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            int pageCount = 0;
            if (IsForSelected)
            {
                return Dal.From<ManagerUserInfo>().Select(ManagerUserInfo._.ID, ManagerUserInfo._.Code, ManagerUserInfo._.Name).OrderBy(ManagerUserInfo._.Code).ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
            }
            else
                return Dal.From<ManagerUserInfo>().OrderBy(ManagerUserInfo._.Code)
                    .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);
        }

        public ManagerUserInfo GetEntity(string id)
        {
            return Dal.Find<ManagerUserInfo>(id);
        }
        public ManagerUserInfo GetEntityByCode(string code)
        {
            return Dal.From<ManagerUserInfo>().Where(ManagerUserInfo._.Code == code).ToFirst<ManagerUserInfo>();
        }



        public string Regist(RegistModel registModel)
        {
            if (Dal.Exists<ManagerUserInfo>(ManagerUserInfo._.Code == registModel.TelPhone))
            {
                return "当前手机号已注册过";
            }
            else
            {
                ManagerUserInfo user = new ManagerUserInfo()
                {
                    ID = Guid.NewGuid().ToString(),
                    Code = registModel.TelPhone,
                    Name = registModel.TelPhone,
                    ContactPhone = registModel.TelPhone,
                    NickyName = registModel.NiceName,
                    Pwd = registModel.Pwd.EncryptSHA1(),
                    CreateDate = DateTime.Now,
                    LastModifyDate = DateTime.Now,
                    StatusChangeDate = DateTime.Now,
                    Status = 1
                };
                try
                {
                    Dal.Submit(user);
                    return "注册成功";
                }
                catch (Exception ex)
                {

                    return "注册失败" + ex.Message;
                }

            }
        }
    }


}
