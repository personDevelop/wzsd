using EasyCms.Business;
using EasyCms.Model;
using ImsgInterface;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Umeng.Entity;

namespace Umeng
{
    public class UmengMsg : ISendMsg
    {
        SysMsgInterSetBll bll = new SysMsgInterSetBll();

        public UmengMsg()
        {

            MsgServiceSet = bll.GetEnableService(SendTool.APP客户端);
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
            if (msgInfo.SendArea == SendArea.指定手机号)
            {
                err = "客户端推送不能为指定手机号的方式";
                return false;
            }
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
                    break;
                case SendArea.注册时间:
                case SendArea.指定会员:
                    telNumList = new ManagerUserInfoBll().GetDevice(where);
                    break;
                case SendArea.用户等级:
                    telNumList = new ManagerUserInfoBll().GetDeviceWithOrder(where);
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

            if (msgInfo.SendArea != SendArea.全员推送 && telNumList.Count == 0)
            {
                err = "没有找到可发送的人员";
                return false;
            }
            UmengSendType st = UmengSendType.broadcast;  //广播
            UmEntity post = new UmEntity()
            {

                appkey = MsgServiceSet.AppKeyID,
                timestamp = ConvertDateTime(DateTime.Now),


            };
            if (telNumList.Count == 1)
            {
                //单播
                st = UmengSendType.unicast;
                post.type = st;
                post.device_token = telNumList[0];
            }
            else if (telNumList.Count < 500)
            {
                //列播
                st = UmengSendType.listcast;
                post.device_token = telNumList[0];
                string deviceStr = telNumList[0];
                for (int i = 1; i < telNumList.Count; i++)
                {
                    deviceStr = "," + telNumList[i];
                }
                post.device_token = deviceStr;
            }
            else if (msgInfo.SendArea != SendArea.全员推送)
            {
                //这时候 可能就需要分段 列播了
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

                //result = MsgService.SendSms(MsgServiceSet.UserNo, MsgServiceSet.Pwd, s.ContactNum, s.SendContent, s.SendTime.ToString("yyyy-MM-dd HH:mm:ss"), s.OrderNo.ToString());

                s.MsgStatus = PhraseResult(result, out result);
                bll.Save(s);


            }
            catch (Exception ex)
            {

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


                //result = MsgService.GetResultbyId(MsgServiceSet.UserNo, MsgServiceSet.Pwd, seacrchid);
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

                //result = MsgService.GetResultbyTime(MsgServiceSet.UserNo, MsgServiceSet.Pwd, telNo, startstr, endstr);
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

                //result = MsgService.GetBalance(MsgServiceSet.UserNo, MsgServiceSet.Pwd);

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
                err = "没有设置可用的友盟平台";
            }

            else if (string.IsNullOrWhiteSpace(MsgServiceSet.UserNo))
            {
                err = "没有设置友盟平台的应用唯一标识appkey";
            }
            else if (string.IsNullOrWhiteSpace(MsgServiceSet.Pwd))
            {
                err = "没有设置短信平台的服务器秘钥app_master_secret";
            }
            else if (string.IsNullOrWhiteSpace(MsgServiceSet.Url))
            {
                err = "没有设置短信平台的地址URL";
            }

            return isResult;
        }


        public string Sign(string content0 = "", string content1 = "", string content2 = "")
        {
            string method = "POST";
            string result = method + content0 + content1 + content2;
            result = GetMD5(result);
            return result;

        }

        /// <summary>
        /// 计算MD5
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string GetMD5(String s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            StringBuilder strReturn = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                strReturn.Append(Convert.ToString(bytes[i], 16).PadLeft(2, '0'));
            }

            return strReturn.ToString().PadLeft(32, '0');
        }


        /// <summary> 
        /// DateTime时间格式转换为Unix时间戳格式 
        /// </summary> 
        /// <param name="time"> DateTime时间格式</param> 
        /// <returns>Unix时间戳格式</returns> 
        public string ConvertDateTime(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return ((int)(time - startTime).TotalSeconds).ToString();
        }


       
    }



    public enum UmengSendType
    {
        /// <summary>
        /// 单播 向指定的设备发送消息，包括向单个device_token或者单个alias发消息。
        /// </summary>
        unicast,
        /// <summary>
        /// 列播 向指定的一批设备发送消息，包括向多个device_token或者多个alias发消息。
        /// </summary>
        listcast,
        /// <summary>
        /// 广播 向安装该App的所有设备发送消息
        /// </summary>
        broadcast,
        /// <summary>
        /// 组播 向满足特定条件的设备集合发送消息，例如: "特定版本"、"特定地域"等。友盟消息推送所支持的维度筛选和友盟统计分析所提供的数据展示维度是一致的，后台数据也是打通的
        /// </summary>
        groupcast,
        /// <summary>
        /// 文件播( 开发者将批量的device_token或者alias存放到文件, 通过文件ID进行消息发送。
        /// </summary>
        filecast,
        /// <summary>
        /// 自定义播 开发者通过自有的alias进行推送, 可以针对单个或者一批alias进行推送，也可以将alias存放到文件进行发送。
        /// </summary>
        customizedcast
    }

    public enum MsgShowType
    {
        /// <summary>
        /// 通知
        /// </summary>
        notification,
        /// <summary>
        /// 消息  
        /// </summary>
        message
    }
}


