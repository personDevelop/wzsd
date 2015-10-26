﻿using EasyCms.Model;
using EasyCms.Model.ViewModel;
using Sharp.Common;
using Sharp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        public bool Exit(string ID, string RecordStatus, string val, bool iscode)
        {
            WhereClip where = new WhereClip();
            if (iscode)
            {
                where = ManagerUserInfo._.Code == val;
            }
            else { where = ManagerUserInfo._.Email == val; }


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
                    //同时更新其等级 和成长值
                    //获取注册获得的成长值
                    ParameterInfo valPara = new ParameterInfoDal().GetEntity(StaticValue.GrowthValueRegist);
                    if (valPara != null)
                    {
                        int grothvalue = 0;
                        if (int.TryParse(valPara.Value, out grothvalue))
                        {
                            ChangeOrder(user.ID, grothvalue);
                        }

                    }

                    return "注册成功";
                }
                catch (Exception ex)
                {

                    return "注册失败" + ex.Message;
                }

            }
        }

        public DataTable GetListForAccount(int pagenum, int pagesize, WhereClip where, ref int recordCount)
        {
            int pageCount = 0;
            return Dal.From<ManagerUserInfo>().Where(where).OrderBy(ManagerUserInfo._.Code)
                .Select(ManagerUserInfo._.ID, ManagerUserInfo._.Code, ManagerUserInfo._.Name, ManagerUserInfo._.NickyName, ManagerUserInfo._.Birthday, ManagerUserInfo._.Sex,
        ManagerUserInfo._.ContactPhone, ManagerUserInfo._.CreateDate, ManagerUserInfo._.LastModifyDate,
          ManagerUserInfo._.Status)
                   .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);


        }

        public string ChangeStatus(string id, int status)
        {
            ManagerUserInfo user = new ManagerUserInfo() { RecordStatus = StatusType.update, ID = id, Status = status };
            Dal.Submit(user);
            return "操作成功";
        }


        public void ChangeOrder(string id, int growthValue, bool isAdd = true)
        {
            if (growthValue == 0)
            {
                return;

            }
            List<BaseEntity> list = new List<BaseEntity>();

            AccountRange ar = Dal.From<AccountRange>().Where(AccountRange._.AccountID == id).ToFirst<AccountRange>();
            DateTime now = DateTime.Now;
            if (ar == null)
            {
                ar = new AccountRange() { ID = Guid.NewGuid().ToString(), AccountID = id, GetRangeTime = now, GrowthValue = growthValue };
                //获取第一等级
                RangeDict dict = Dal.From<RangeDict>().Where(RangeDict._.MinVal == 0).ToFirst<RangeDict>();
                if (dict != null)
                {
                    ar.RangeID = dict.ID;
                }
                AccuountRangeChange arc = new AccuountRangeChange()
                {
                    ID = Guid.NewGuid().ToString(),
                    ChangeTime = now,
                    CurrentRangeID = ar.RangeID,
                    ChangedValue = growthValue
                };
                list.Add(arc);
            }
            else
            {
                int changeGrowth = ar.GrowthValue + growthValue;
                if (!isAdd)
                {
                    changeGrowth = ar.GrowthValue - growthValue;
                }
                RangeDict dict = Dal.From<RangeDict>().Where(RangeDict._.MinVal <= changeGrowth && RangeDict._.MaxVal > changeGrowth).ToFirst<RangeDict>();
                if (dict != null)
                {
                    if (dict.ID != ar.RangeID)
                    {
                        //发生变更等级
                        AccuountRangeChange arc = new AccuountRangeChange()
                        {
                            ID = Guid.NewGuid().ToString(),
                            ChangeTime = now,
                            PriRangeID = ar.RangeID,
                            CurrentRangeID = dict.ID,
                            ChangeingValue = ar.GrowthValue,
                            ChangedValue = changeGrowth
                        };
                        list.Add(arc);
                    }
                }
                ar.GrowthValue = changeGrowth;
            }
            list.Add(ar);
            Dal.Submit(list);
        }



        public Model.ViewModel.AccountModel GetMySelf(string userid, string host, out string err)
        {
            err = string.Empty;
            AccountModel user = Dal.From<ManagerUserInfo>()
                .Join<AccountRange>(ManagerUserInfo._.ID == AccountRange._.AccountID, JoinType.leftJoin)
                .Join<RangeDict>(AccountRange._.RangeID == RangeDict._.ID, JoinType.leftJoin)
                .Join<AttachFile>(AttachFile._.RefID == ManagerUserInfo._.Photo, JoinType.leftJoin)
                .Where(ManagerUserInfo._.ID == userid).Select(ManagerUserInfo._.ID,
                ManagerUserInfo._.Name,
                ManagerUserInfo._.Email,
                ManagerUserInfo._.QQ,
             AttachFile.GetFilePath(host, "Photo"),
                ManagerUserInfo._.NickyName,
                ManagerUserInfo._.Signature,
                ManagerUserInfo._.IDNumber,
                ManagerUserInfo._.Birthday,
                ManagerUserInfo._.Sex,
                ManagerUserInfo._.ContactPhone,
                ManagerUserInfo._.CreateDate,
                ManagerUserInfo._.LastModifyDate,
                ManagerUserInfo._.Status,
                ManagerUserInfo._.Note, AccountRange._.GrowthValue, AccountRange._.JF, RangeDict._.Name.Alias("RangeName"), RangeDict._.HasService, RangeDict._.Img.Alias("RangeImg"))
                .ToDataTable().Rows[0].ToFirst<AccountModel>();
            user.RangeImg = Dal.From<AttachFile>().Where(AttachFile._.RefID == user.RangeImg).Select(AttachFile.GetFilePath(host)).ToScalar() as string;

            if (!string.IsNullOrWhiteSpace(user.HasService))
            {
                string[] service = user.HasService.Split(',');
                List<AccountService> list = Dal.From<ParameterInfo>().Where(ParameterInfo._.ID.In(service)).Select(ParameterInfo._.ID, ParameterInfo._.Code, ParameterInfo._.Name)
                    .ToDataTable().ToList<AccountService>();
                user.AccountService = list;

            }
            return user;

        }

        public string ChangePwd(string userid, ChangePwdModel changePwd)
        {
            ManagerUserInfo user = Dal.From<ManagerUserInfo>().Where(ManagerUserInfo._.ID == userid).Select(ManagerUserInfo._.ID, ManagerUserInfo._.Pwd).ToFirst<ManagerUserInfo>();

            if (user.Pwd != changePwd.OldPwd.EncryptSHA1())
            {
                return "旧密码不正确";
            }
            else
            {
                user.Pwd = changePwd.NewPwd.EncryptSHA1();
                Dal.Submit(user);
                return string.Empty;
            }

        }

        public SysRoleInfo GetRole(string userid)
        {
            return Dal.From<SysRoleInfo>().Join<SysRoleAndUserRalation>(SysRoleAndUserRalation._.RoleId == SysRoleInfo._.ID && SysRoleAndUserRalation._.UserId == userid
                ).Select(SysRoleInfo._.ID.All).ToFirst<SysRoleInfo>();
        }

        public bool ResetPwd(ResetPwdModel changePwd, bool isManager, out string value)
        {
            value = string.Empty;
            ManagerUserInfo user = Dal.From<ManagerUserInfo>().Where(ManagerUserInfo._.IsManager == isManager
                && (ManagerUserInfo._.Code == changePwd.Account || ManagerUserInfo._.ContactPhone == changePwd.Account || ManagerUserInfo._.Email == changePwd.Account)
                ).ToFirst<ManagerUserInfo>();
            if (user == null)
            {
                value = "您的账户不存在";
                return false;
            }
            else
            {

                switch (changePwd.VaryType)
                {
                    case ValidType.手机短信:
                        return StaticValue.GetEncriptContanct(user.ContactPhone, changePwd.VaryType, out value);

                        break;
                    case ValidType.邮箱:
                        return StaticValue.GetEncriptContanct(user.Email, changePwd.VaryType, out value);

                        break;
                    case ValidType.手机和邮箱:
                    default:
                        value = "不支持通过该方式找回密码";
                        return false;
                        break;

                }
                return true;

            }
        }


        public bool ResetPwdPost(ResetPwdPostModel changePwd, bool isManager, out string value)
        {
            value = string.Empty;
            ManagerUserInfo user = Dal.From<ManagerUserInfo>().Where(ManagerUserInfo._.IsManager == isManager
                && (ManagerUserInfo._.Code == changePwd.Account || ManagerUserInfo._.ContactPhone == changePwd.Account || ManagerUserInfo._.Email == changePwd.Account)
                ).ToFirst<ManagerUserInfo>();
            if (user == null)
            {
                value = "您的账户不存在";
                return false;
            }
            else
            {
                switch (changePwd.VaryType)
                {
                    case ValidType.手机短信:
                        if (string.IsNullOrWhiteSpace(user.ContactPhone))
                        {
                            value = "您的账户没有设置手机号，不能通过该方式找回密码";
                            return false;
                        }
                        else
                        {

                            if (user.ContactPhone.Length != 11)
                            {
                                value = "*******" + user.ContactPhone.Substring(7);
                            }
                            else
                            {

                                value = "您的账户手机号不正确，不能通过该方式找回密码";
                                return false;
                            }
                        }
                        break;
                    case ValidType.邮箱:
                        if (string.IsNullOrWhiteSpace(user.Email))
                        {
                            value = "您的账户没有设置邮箱，不能通过该方式找回密码";
                            return false;
                        }
                        else
                        {

                            if (user.Email.Contains("@"))
                            {
                                string pri = user.Email.Substring(0, user.Email.IndexOf("@"));
                                switch (pri.Length)
                                {
                                    case 1:
                                        value = user.Email;
                                        break;
                                    case 2:
                                        value = pri[0] + "*";
                                        break;
                                    case 3:
                                        value = pri[0] + "*" + pri[2];
                                        break;
                                    case 4:
                                        value = pri[0] + "**" + pri[3];
                                        break;
                                    case 5:
                                        value = pri[0] + "***" + pri[4];
                                        break;
                                    default:
                                        value = "****" + pri.Substring(4);
                                        break;

                                }
                                value += user.Email.Substring(user.Email.IndexOf("@"));
                            }
                            else
                            {

                                value = "您的邮箱格式不正确，不能通过该方式找回密码";
                                return false;
                            }
                        }
                        break;
                    case ValidType.手机和邮箱:
                    default:
                        value = "不支持通过该方式找回密码";
                        return false;
                        break;

                }
                return true;

            }
        }

        public ManagerUserInfo GeUserWithCodeOrTelOrEmail(string usercodeOrTelOrEmail)
        {
            ManagerUserInfo user = Dal.From<ManagerUserInfo>().Where((ManagerUserInfo._.Code == usercodeOrTelOrEmail ||
                ManagerUserInfo._.ContactPhone == usercodeOrTelOrEmail || ManagerUserInfo._.Email == usercodeOrTelOrEmail)
                ).ToFirst<ManagerUserInfo>();
            return user;
        }

        public string ChangePwd(string userid, ResetPwdPostModel changePwd)
        {

            if (changePwd.NewPwd != changePwd.ConfirmNewPwd)
            {
                return "两次输入的密码不一致";
            }
            else
            {
                ManagerUserInfo user = new ManagerUserInfo();
                user.RecordStatus = StatusType.update;
                user.Where = ManagerUserInfo._.ID == userid;
                user.Pwd = changePwd.NewPwd.EncryptSHA1();
                Dal.Submit(user);
                return string.Empty;
            }
        }

        public bool ModifyInfo(UserInfo user, out string msg)
        {
            ManagerUserInfo mu = new ManagerUserInfo()
            {
                ID = user.ID,
                RecordStatus = StatusType.update,
                Name = user.Name,
                NickyName = user.NickyName,
                Email = user.Email,
                ContactPhone = user.ContactPhone,
                Sex = user.Sex,
                Signature = user.Signature
            };

            if (!string.IsNullOrWhiteSpace(user.Birthday))
            {
                DateTime dt;
                if (DateTime.TryParseExact(user.Birthday, "yyyy-MM-dd", CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.AssumeLocal, out dt))
                {
                    mu.Birthday = dt;
                }
            }
            Dal.Submit(mu);
            msg = "修改成功";
            return true;
        }
    }


}
