using EasyCms.Business;
using EasyCms.Model;
using ImsgInterface;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsgService
{
    public class SmsMsg : ISendMsg
    {
        SysMsgInterSetBll bll = new SysMsgInterSetBll();
        cn.vcomlive.wsqd.SmsService MsgService = null;
        public SmsMsg()
        {

            MsgServiceSet = bll.GetEnableService(SendTool.短信);
            MsgService = new cn.vcomlive.wsqd.SmsService();
            if (MsgServiceSet != null && !string.IsNullOrWhiteSpace(MsgServiceSet.Url))
            {
                MsgService.Url = MsgServiceSet.Url;
            }
        }

        /// <summary>
        /// 轮询发送
        /// </summary>
        /// <returns></returns>
        public bool SendMsg()
        {
            //从数据库里获取待发送的短信 进行发送
            return true;
        }
        public bool SendMsg(SendMsgInfo msgInfo, ref string err)
        {
            if (!CheckPlatform(ref err))
            {

                return false;
            }
            List<string> telNumList = new List<string>();
            WhereClip where = null;
            switch (msgInfo.SendArea)
            {
                case SendArea.全员推送:
                    //获取所有账户
                    where = ManagerUserInfo._.IsManager == false;
                    break;
                case SendArea.用户等级:
                    //获取当前等级下的所有账户
                    where = ManagerUserInfo._.IsManager == false && AccountRange._.RangeID == msgInfo.UserOrder;
                    break;
                case SendArea.注册时间:
                    //获取当前注册范围内的所有账户
                    where = ManagerUserInfo._.IsManager == false;
                    if (msgInfo.StartRegistTime.HasValue)
                    {
                        where = where && ManagerUserInfo._.CreateDate >= msgInfo.StartRegistTime.Value.Date;
                    }
                    if (msgInfo.EndRegistTime.HasValue)
                    {
                        where = where && ManagerUserInfo._.CreateDate < msgInfo.EndRegistTime.Value.AddDays(1).Date;
                    }
                    break;
                case SendArea.购买次数:
                    //获取当前购买次数范围内的所有账户

                    break;
                case SendArea.指定会员:
                    //指定会员
                    where = ManagerUserInfo._.IsManager == false;

                    if (!string.IsNullOrWhiteSpace(msgInfo.CustomerAccuont))
                    {
                        string[] tels = msgInfo.CustomerAccuont.Split(',');
                        where = where && ManagerUserInfo._.ID.In(tels);
                    }
                    break;
                case SendArea.指定手机号:
                    //指定手机号
                    if (!string.IsNullOrWhiteSpace(msgInfo.CustomerTelNo))
                    {
                        string[] tels = msgInfo.CustomerTelNo.Split(',');
                        foreach (var item in tels)
                        {
                            if (!telNumList.Contains(item))
                            {
                                telNumList.Add(item);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            switch (msgInfo.SendArea)
            {
                case SendArea.全员推送:
                case SendArea.注册时间:
                case SendArea.指定会员:
                    telNumList = new ManagerUserInfoBll().GetTelNo(where);
                    break;
                case SendArea.用户等级:
                    telNumList = new ManagerUserInfoBll().GetTelNoWithOrder(where);
                    break;

                case SendArea.购买次数:
                    telNumList = new ManagerUserInfoBll().GetTelNoWithBuyCount(msgInfo.MinBuyCount, msgInfo.MaxBuyCount);

                    break;
                case SendArea.指定手机号:
                    break;
                default:
                    break;
            }
            telNumList = telNumList.Distinct().ToList();
            if (telNumList.Count == 0)
            {
                err = "没有找到可发送的人员";
                return false;
            }
            foreach (var item in telNumList)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    SendMsg(MsgServiceSet.TelNum, item, "", msgInfo.SendContent, ref err);
                }

            }
            msgInfo.TotalUserCount = telNumList.Count;
            msgInfo.HasSendUserCount = telNumList.Count;
            msgInfo.HasSendCount += 1;
            new SendMsgInfoBll().Save(msgInfo);
            return true;
        }
        /// <summary>
        /// 及时发送
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendMsg(string from, string to, string userid, string msg, ref string err)
        {
            if (!CheckPlatform(ref err))
            {

                return false;
            }
            string result = string.Empty;
            try
            {

                MsgSendLog s = new MsgSendLog()
                    {
                        ID = Guid.NewGuid().ToString(),
                        UserID = userid,
                        MyNum = from,
                        ContactNum = to,
                        SendTool = SendTool.短信,
                        SendContent = msg,
                        SendTime = DateTime.Now,
                        OrderNo = DateTime.Now.ToString("yyMMddHHmmssffffff")
                    };

                result = MsgService.SendSms(MsgServiceSet.UserNo, MsgServiceSet.Pwd, s.ContactNum, s.SendContent, s.SendTime.ToString("yyyy-MM-dd HH:mm:ss"), s.OrderNo.ToString());

                s.MsgStatus = PhraseResult(result, out result);
                bll.Save(s);


            }
            catch (Exception ex)
            {
                err = ex.Message;
                throw;
            }
            return true;

        }


        public EasyCms.Model.SysMsgInterSet MsgServiceSet
        {
            get;
            set;
        }
        public string GetResultbyId(string seacrchid)
        {
            string result = string.Empty;
            try
            {


                result = MsgService.GetResultbyId(MsgServiceSet.UserNo, MsgServiceSet.Pwd, seacrchid);
                bool isSuccess = PhraseResult(result, out result);
                MsgSendLog s = new MsgSendLog();
                s.Where = MsgSendLog._.OrderNo == seacrchid;
                s.RecordStatus = Sharp.Common.StatusType.update;
                s.MsgStatus = isSuccess;
                bll.Save(s);


            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
        public string GetResultbyTime(string telNo, DateTime? start, DateTime? end)
        {
            string result = string.Empty;
            try
            {

                string startstr = "";
                string endstr = "";
                if (start.HasValue)
                {
                    startstr = start.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }
                if (end.HasValue)
                {
                    endstr = end.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }

                result = MsgService.GetResultbyTime(MsgServiceSet.UserNo, MsgServiceSet.Pwd, telNo, startstr, endstr);
                PhraseResult(result, out result);
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public string GetBalance()
        {
            string result = string.Empty;
            try
            {

                result = MsgService.GetBalance(MsgServiceSet.UserNo, MsgServiceSet.Pwd);

            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public bool PhraseResult(string content, out string result)
        {
            result = string.Empty;
            switch (content)
            {
                case "501":
                    result = "错误的密码或账号";
                    break;
                case "502":
                    result = "任务流失号不能为空";
                    break;
                case "503":
                    result = "没有记录";
                    break;
                case "504":
                    result = "发送信息成功";
                    break;
                case "505":
                    result = "发送信息失败";
                    break;
                case "506":
                    result = "短信内容不能为空";
                    break;
                default:
                    result = @"<Result>
<mobie>{0}</mobie>
<exec_time>{0}</exec_time>
<Message>{0}</Message>
<state>{0}</state>
<user_task_id>{0}</user_task_id>
</Result>";

                    break;

            }

            return true;
        }

         

        public bool CheckPlatform(ref string err)
        {
            bool isResult = true;
            if (MsgServiceSet == null)
            {
                err = "没有设置可用的短信平台";
            }
            else if (string.IsNullOrWhiteSpace(MsgServiceSet.UserNo))
            {
                err = "没有设置短信平台的用户名";
            }
            else if (string.IsNullOrWhiteSpace(MsgServiceSet.Pwd))
            {
                err = "没有设置短信平台的密码";
            }
            else if (string.IsNullOrWhiteSpace(MsgServiceSet.Url))
            {
                err = "没有设置短信平台的地址URL";
            }
            return isResult;
        }


        public string Sign(string content0 = "", string content1 = "", string content2 = "")
        {
            throw new NotImplementedException();
        }
    }
}
