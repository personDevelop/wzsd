using EasyCms.Dal;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common;
using EasyCms.Model.ViewModel;

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

       

        public ManagerUserInfo Login(string code, string pwd, out string error)
        {

            return LoginBase(code, pwd, false, out error);
        }
        public ManagerUserInfo LoginManager(string code, string pwd, out string error)
        {
            return LoginBase(code, pwd, true, out error);
        }
        private ManagerUserInfo LoginBase(string code, string pwd, bool isManager, out string error)
        {
            error = string.Empty;
            ManagerUserInfo item = Dal.GetEntityByCode(code);
            if (item == null)
            {
                error = "账号不存在！";

            }
            else if (pwd.EncryptSHA1() != item.Pwd)
            {
                if (string.IsNullOrWhiteSpace(item.Pwd))
                {
                    item.Pwd = pwd.EncryptSHA1();
                    Dal.Save(item);
                }else
                { 
                error = "密码不正确！";
                item = null;
                }
            }
            else if (item.Status != UserStatus.正常)
            {

                error = "账号状态["+ item.Status + "]，不允许登陆！";
                item = null;
            }
            else if (isManager && !item.IsManager)
            {
                error = "会员账号不允许登陆后台管理系统！";
                item = null;
            }
            if (item != null)
            {
                item.LastModifyDate = DateTime.Now;
                Dal.Save(item);
                if (isManager)
                {

                }
                else
                {
                    //同时更新其等级 和成长值
                    //获取注册获得的成长值
                    ParameterInfo valPara = new ParameterInfoDal().GetEntity(StaticValue.GrowthValueLogin);
                    if (valPara != null)
                    {
                        int grothvalue = 0;
                        if (int.TryParse(valPara.Value, out grothvalue))
                        {
                            Dal.ChangeOrder(item.ID, grothvalue);
                        }
                    }

                }
            }
            return item;
        }

        public AccountRange GetAccountRange(string userID)
        {
            return Dal.GetAccountRange(  userID);
        }

        public DataTable GetList(bool IsForSelected = false)
        {
            return Dal.GetList(IsForSelected);
        }
        public DataTable GetList(int pagenum, int pagesize, ref int recordCount, bool IsForSelected = false)
        {
            return Dal.GetList(pagenum, pagesize, ref   recordCount, IsForSelected);
        }
        public bool Exit(string ID, string RecordStatus, string val, bool isCode)
        {

            return Dal.Exit(ID, RecordStatus, val, isCode);

        }


        public ManagerUserInfo GetEntity(string id)
        {
            return Dal.GetEntity(id);
        }





        public string Regist(RegistModel registModel, ActionPlatform plat)
        {
            return Dal.Regist(registModel,   plat);
        }




        public DataTable GetListForAccount(int pagenum, int pagesize, WhereClip where, ref int recordCount)
        {
            return Dal.GetListForAccount(pagenum, pagesize, where, ref   recordCount);
        }

        public string ChangeStatus(string id, UserStatus status)
        {
            return Dal.ChangeStatus(id, status);
        }

        public AccountModel GetMySelf(string userid, string host, out string err)
        {
            return Dal.GetMySelf(userid, host, out   err);
        }

        public string ChangePwd(string userid, ChangePwdModel changePwd)
        {
            return Dal.ChangePwd(userid, changePwd);
        }

        public SysRoleInfo GetRole(string userid)
        {
            return Dal.GetRole(userid);
        }

        public bool CheckRepeat(string val, bool isCode)
        {
            return Dal.CheckRepeat(val,   isCode);
        }

        public ManagerUserInfo GeUserWithCodeOrTelOrEmail(string usercodeOrTelOrEmail)
        {
            return Dal.GeUserWithCodeOrTelOrEmail(usercodeOrTelOrEmail);
        }
        public bool ResetPwd(ResetPwdModel changePwd, bool isManager, out string value)
        {
            return Dal.ResetPwd(changePwd, isManager, out   value);
        }

        public string ChangePwd(string userid, ResetPwdPostModel changePwd)
        {
            return Dal.ChangePwd(userid, changePwd);
        }

        public bool ModifyInfo(UserInfo user, out string msg)
        {
            return Dal.ModifyInfo(user, out msg);
        }



        public List<string> GetTelNo(WhereClip where)
        {
            return Dal.GetTelNo(where);
        }

        public List<string> GetTelNoWithOrder(WhereClip where)
        {
            return Dal.GetTelNoWithOrder(where);
        }

        public List<string> GetTelNoWithBuyCount(int MinBuyCount, int MaxBuyCount)
        {
            return Dal.GetTelNoWithBuyCount(MinBuyCount, MaxBuyCount);
        }

        public int Save(TokenInfo ti)
        {
            return Dal.Save(ti);
        }
        public int UpdateToken(string token)
        {
            return Dal.UpdateToken(token);
        }
        public int RemoveToken(string token)
        {
            return Dal.RemoveToken(token);
        }
        public ManagerUserInfo GetSessionUserInfo(string token)
        {
            return Dal.GetSessionUserInfo(token);
        }
        public ManagerUserInfo GetUserByToken(string token)
        {
            return Dal.GetUserByToken(token);
        }

        public DataTable GetDevice(WhereClip where)
        {
            return Dal.GetDevice(where);
        }

        public DataTable GetDeviceWithOrder(WhereClip where)
        {
            return Dal.GetDeviceWithOrder(where);
        }

        public DataTable GetDeviceWithBuyCount(int MinBuyCount, int MaxBuyCount)
        {
            return Dal.GetDeviceWithBuyCount(MinBuyCount, MaxBuyCount);

        }

        public decimal GetMyBalance(string userid)
        {
            return Dal.GetMyBalance(userid);

        }

        public ManagerUserInfo GetUserInfo(string account, out string error)
        {
            return Dal.GetUserInfo(account, out   error);
        }

        public int Save(FindPwd m)
        {
            return Dal.Save(m);
        }

        public FindPwd GetFindPwdRecord(string id)
        {
            return Dal.GetFindPwdRecord(id);
        }

        public decimal GetGetBalance(string id)
        {
            return Dal.GetGetBalance(id);
        }

        public DataTable GetAccuontMoneyLog(string userID)
        {
            return Dal.GetAccuontMoneyLog(userID);
        }

        public string ReCharge(string id, decimal charegeBanlance, string userID)
        {
            return Dal.ReCharge(id, charegeBanlance,   userID);
        }
    }
}
