using EasyCms.Dal.PromotionRule;
using EasyCms.Model;
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



        public string Regist(RegistModel registModel,ActionPlatform plat)
        {
            ManagerUserInfo user = user = new ManagerUserInfo()
            {
                ID = Guid.NewGuid().ToString(),
                Code = registModel.UserNo,
                Name = registModel.UserNo,
               
                NickyName = registModel.UserNo,
                Pwd = registModel.Pwd.EncryptSHA1(),
                CreateDate = DateTime.Now,
                LastModifyDate = DateTime.Now,
                StatusChangeDate = DateTime.Now,
                Status = UserStatus.正常
            };
            if (registModel.IsPc)
            {
                user.Email = registModel.Email; 
            }
            else
            {
                user.ContactPhone = registModel.TelPhone;
            }
            if (Dal.Exists<ManagerUserInfo>(ManagerUserInfo._.Code == registModel.UserNo))
            {
                return "当前账号已注册过";
            }
            else
            {

                try
                {
                    Dal.Submit(user);
                    //同时更新其等级 和成长值
                    //获取注册获得的成长值
                    BaseRule br = new BaseRule() {  UserInfo=user, Context=user};
                    br.Run(plat, ActionEvent.注册);
                    ParameterInfo valPara = new ParameterInfoDal().GetEntity(StaticValue.GrowthValueRegist);

                    if (valPara != null)
                    {
                        int grothvalue = 0;
                        if (int.TryParse(valPara.Value, out grothvalue))
                        {
                            ChangeOrder(user.ID, grothvalue);
                        }

                    }

                    return string.Empty;
                }
                catch (Exception ex)
                {

                    return "注册失败" + ex.Message;
                }

            }
        }

        public AccountRange GetAccountRange(string userID)
        {
            AccountRange ar = Dal.Find<AccountRange>(AccountRange._.AccountID == userID);
            ar.RangDict = Dal.Find<RangeDict>(RangeDict._.ID == ar.RangeID);
            return ar;
        }

        public DataTable GetListForAccount(int pagenum, int pagesize, WhereClip where, ref int recordCount)
        {
            int pageCount = 0;
            return Dal.From<ManagerUserInfo>().Where(where).OrderBy(ManagerUserInfo._.Code)
                .Select(ManagerUserInfo._.ID, ManagerUserInfo._.Code, ManagerUserInfo._.Name, ManagerUserInfo._.NickyName, ManagerUserInfo._.Birthday, ManagerUserInfo._.Sex,
        ManagerUserInfo._.ContactPhone, ManagerUserInfo._.CreateDate, ManagerUserInfo._.LastModifyDate,
          ManagerUserInfo._.Status, ManagerUserInfo._.Balance)
                   .ToDataTable(pagesize, pagenum, ref pageCount, ref recordCount);


        }

        public bool CheckRepeat(string val, bool isCode)
        {
            if (isCode)
            {
                return !(val.ToLower()=="root"|| Dal.Exists<ManagerUserInfo>(ManagerUserInfo._.Code == val));
            }
            else
            {
                return !Dal.Exists<ManagerUserInfo>(ManagerUserInfo._.Email == val);
            }
        }

        public string ChangeStatus(string id, UserStatus status)
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
                    ChangedValue = growthValue,
                    UserID=id,
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
                            ChangedValue = changeGrowth,
                             UserID = id,
                        };
                        list.Add(arc);
                    }
                }
                ar.GrowthValue = changeGrowth;
            }
            list.Add(ar);
            Dal.Submit(list);
        }

        public DataTable GetAccuontMoneyLog(string userID)
        {
            return Dal.From<AccuontMoneyLog>().Where(AccuontMoneyLog._.UserID == userID).OrderBy(AccuontMoneyLog._.OpTime)
                   .ToDataTable();
        }

        public string ReCharge(string id, decimal charegeBanlance, string userID)
        {
            string err = string.Empty;
            AccuontMoneyLog c = new AccuontMoneyLog();
            object o = Dal.Count<AccuontMoneyLog>(AccuontMoneyLog._.UserID == id&& AccuontMoneyLog._.OpTime.ConvertDate(ConvertDateType.八位年月日)== DateTime.Now.ToString("yyyyMMdd"), AccuontMoneyLog._.ID,false);
            if (o != DBNull.Value && (int)o >= 3)
            {
                return "您今天充值次数超过3次不能再充值了，请改天再充值";
            }
            else
            {
                ManagerUserInfo UserInfo =  Dal.From<ManagerUserInfo>().Where(ManagerUserInfo._.ID == id).Select(ManagerUserInfo._.ID, ManagerUserInfo._.Balance).ToFirst<ManagerUserInfo>() ;
             
                AccuontMoneyLog ml = new AccuontMoneyLog()
                {
                    Amount = charegeBanlance,
                    Balance = UserInfo.Balance+ charegeBanlance,
                    ID = Guid.NewGuid().ToString(),
                    Note ="系统管理员充值",
                    OpMoneyEvent = OpEvent.充值,
                    OpStatus = OpStatus.成功,
                    OpTime = DateTime.Now,
                    OpType = AddOrRemove.增加,
                    OpUserID = userID,
                    UserID = UserInfo.ID
                };

                UserInfo.Balance += charegeBanlance;
                SessionFactory dal = null;
                IDbTransaction tr = Dal.BeginTransaction(out dal);
                try
                {
                    dal.SubmitNew(tr, ref dal, UserInfo, ml);
                    dal.CommitTransaction(tr);
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction(tr);
                    err = ex.Message;
                    throw;
                } 
            }
            return err;
        }

        public decimal GetGetBalance(string id)
        {
            return Convert.ToDecimal(Dal.From<ManagerUserInfo>().Where(ManagerUserInfo._.ID==id ).Select(ManagerUserInfo._.Balance).ToScalar());
        }

        public FindPwd GetFindPwdRecord(string id)
        {
            return Dal.From<FindPwd>().Join<ManagerUserInfo>(FindPwd._.UserID== ManagerUserInfo._.ID)
                .Where(FindPwd._.ID==id)
                
                .Select(FindPwd._.UserID,FindPwd._.EndTime,FindPwd._.ID,ManagerUserInfo._.Code).ToFirst<FindPwd>( );
        }

        public int Save(FindPwd m)
        {
            return Dal.Submit(m);
        }

        public ManagerUserInfo GetUserInfo(string account, out string error)
        {
            ManagerUserInfo result = null;
            error = string.Empty;
            result = Dal.From<ManagerUserInfo>().Where(ManagerUserInfo._.Code == account).Select(ManagerUserInfo._.ID, ManagerUserInfo._.Code, ManagerUserInfo._.Email).ToFirst<ManagerUserInfo>();
            if (result==null)
            {
                result = Dal.From<ManagerUserInfo>().Where(ManagerUserInfo._.Email == account).Select(ManagerUserInfo._.ID, ManagerUserInfo._.Code, ManagerUserInfo._.Email).ToFirst<ManagerUserInfo>();

            }
            if (result==null)
            {
                error = "系统中不存在该会员账号或邮箱,请重新输入";
            }
            return result;
        }

        public decimal GetMyBalance(string userid)
        {
            decimal result = 0;
            object o= Dal.From<ManagerUserInfo>().Where(ManagerUserInfo._.ID == userid).Select(ManagerUserInfo._.Balance).ToScalar();
            if (o!=null && o!=DBNull.Value)
            {
                result = Convert.ToDecimal(o);
            }
            return result;

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
             AttachFile.GetCompressionfilePath(host, "Photo"),
                ManagerUserInfo._.NickyName,
                ManagerUserInfo._.Signature,
                ManagerUserInfo._.IDNumber,
                ManagerUserInfo._.Birthday,
                ManagerUserInfo._.Sex,
                ManagerUserInfo._.ContactPhone,
                ManagerUserInfo._.CreateDate,
                ManagerUserInfo._.LastModifyDate,
                ManagerUserInfo._.Status,
                 ManagerUserInfo._.Balance,
                ManagerUserInfo._.Note, AccountRange._.GrowthValue, AccountRange._.JF, RangeDict._.Name.Alias("RangeName"), RangeDict._.HasService, RangeDict._.Img.Alias("RangeImg"))
                .ToDataTable().Rows[0].ToFirst<AccountModel>();
            user.RangeImg = Dal.From<AttachFile>().Where(AttachFile._.RefID == user.RangeImg).Select(AttachFile.GetCompressionfilePath(host)).ToScalar() as string;

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




        public List<string> GetTelNo(WhereClip where)
        {
            return Dal.From<ManagerUserInfo>().Where(where).Select(ManagerUserInfo._.ContactPhone).ToSinglePropertyArray().ToList();
        }

        public List<string> GetTelNoWithOrder(WhereClip where)
        {
            return Dal.From<ManagerUserInfo>().Join<AccountRange>(AccountRange._.AccountID == ManagerUserInfo._.ID).Where(where).Select(ManagerUserInfo._.ContactPhone).ToSinglePropertyArray().ToList();
        }

        public List<string> GetTelNoWithBuyCount(int MinBuyCount, int MaxBuyCount)
        {
            DataTable dt = Dal.From<ShopOrder>().Where(ShopOrder._.OrderStatus != (int)OrderStatus.拒收 &&
                ShopOrder._.OrderStatus != (int)OrderStatus.取消订单 && ShopOrder._.OrderStatus != (int)OrderStatus.商家已收货等待退款 &&
                ShopOrder._.OrderStatus != (int)OrderStatus.退货取货中 && ShopOrder._.OrderStatus != (int)OrderStatus.退货完成 &&
                ShopOrder._.OrderStatus != (int)OrderStatus.作废).GroupBy(ShopOrder._.MemberID).Select(ShopOrder._.MemberCallPhone, ShopOrder._.ID.Count().Alias("orderCount"))
                                .ToDataTable();
            string whereStr = string.Empty;
            if (MinBuyCount > 0)
            {
                whereStr = " orderCount>=" + MinBuyCount;
            }
            if (MaxBuyCount > 0)
            {
                if (whereStr.Length > 0)
                {
                    whereStr += " and ";
                }
                whereStr = " orderCount<=" + MaxBuyCount;
            }
            return dt.Select(whereStr).AsQueryable().Select(d => d.Field<string>("MemberCallPhone")).ToList();

        }

        public int Save(TokenInfo ti)
        {
            return Dal.Submit(ti);
        }
        public int UpdateToken(string token)
        {
            DateTime now = DateTime.Now;

            TokenInfo t = new TokenInfo() { ID = token, RecordStatus = StatusType.update, LastTime = now };
            ExpressionClip value = new ExpressionClip();
            value.SqlBuilder = new StringBuilder("dateadd(second,Duration,@LastTime)");
            value.Parameters.Add("LastTime", now);
            t.SetModifiedProperty(TokenInfo._.OutTime, value);
            return Dal.Submit(t);

        }
        public int RemoveToken(string token)
        {
            return Dal.Delete<TokenInfo>(token);
        }
        public ManagerUserInfo GetSessionUserInfo(string token)
        {
            return Dal.From<TokenInfo>().Join<ManagerUserInfo>(TokenInfo._.UserID == ManagerUserInfo._.ID)

                .Where(TokenInfo._.ID == token).Select(ManagerUserInfo._.ID.All).ToFirst<ManagerUserInfo>();
                
        }
        public ManagerUserInfo GetUserByToken(string token)
        {
            object o = Dal.From<TokenInfo>().Where(TokenInfo._.ID == token).Select(TokenInfo._.OutTime).ToScalar();
            if (o != null && o != DBNull.Value)
            {
                DateTime outTime = (DateTime)o;
                if (outTime <= DateTime.Now)
                {
                    return null;
                }
                else
                {
                    UpdateToken(token);
                    return Dal.From<ManagerUserInfo>().Join<TokenInfo>(ManagerUserInfo._.ID == TokenInfo._.UserID && TokenInfo._.ID == token).Select(ManagerUserInfo._.ID.All, TokenInfo._.DeviceID)
                            .ToFirst<ManagerUserInfo>();
                }
            }
            else
            {
                return null;
            }


        }

        public DataTable GetDevice(WhereClip where)
        {
            return Dal.From<ManagerUserInfo>().Distinct()
                .Where(where && !ManagerUserInfo._.DeviceNo.IsNullOrEmpty()).Select(ManagerUserInfo._.DeviceNo, ManagerUserInfo._.ClientType)
                .ToDataTable();
        }

        public DataTable GetDeviceWithOrder(WhereClip where)
        {

            return Dal.From<ManagerUserInfo>().Join<AccountRange>(AccountRange._.AccountID == ManagerUserInfo._.ID &&
                !ManagerUserInfo._.DeviceNo.IsNullOrEmpty()).Where(where).Distinct()
                .Select(ManagerUserInfo._.DeviceNo, ManagerUserInfo._.ClientType).ToDataTable();
        }

        public DataTable GetDeviceWithBuyCount(int MinBuyCount, int MaxBuyCount)
        {
            DataTable dt = Dal.From<ShopOrder>().Where(!ShopOrder._.DeviceNo.IsNullOrEmpty() && ShopOrder._.OrderStatus != (int)OrderStatus.拒收 &&
                ShopOrder._.OrderStatus != (int)OrderStatus.取消订单
                && ShopOrder._.OrderStatus != (int)OrderStatus.商家已收货等待退款 &&
                ShopOrder._.OrderStatus != (int)OrderStatus.退货取货中 &&
                ShopOrder._.OrderStatus != (int)OrderStatus.退货完成 && ShopOrder._.OrderStatus != (int)OrderStatus.作废
                ).GroupBy(ShopOrder._.DeviceNo, ShopOrder._.ClientType).Select(ShopOrder._.DeviceNo, ShopOrder._.ClientType, ShopOrder._.ID.Count().Alias("orderCount"))
                                .ToDataTable();
            string whereStr = string.Empty;
            if (MinBuyCount > 0)
            {
                whereStr = " orderCount>=" + MinBuyCount;
            }
            if (MaxBuyCount > 0)
            {
                if (whereStr.Length > 0)
                {
                    whereStr += " and ";
                }
                whereStr = " orderCount<=" + MaxBuyCount;
            }
            return dt.Select(whereStr).CopyToDataTable();

        }

    }


}
