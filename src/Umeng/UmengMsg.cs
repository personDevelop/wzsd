using EasyCms.Business;
using EasyCms.Model;
using ImsgInterface;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Umeng.Entity;
using Newtonsoft.Json;
namespace Umeng
{
    public class UmengMsg : ISendMsg
    {
        SysMsgInterSetBll bll = new SysMsgInterSetBll();
        SendMsgInfo MsgInfo = null;
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
            MsgInfo = msgInfo;
            if (msgInfo.SendArea == SendArea.指定手机号)
            {
                err = "客户端推送不能为指定手机号的方式";
                return false;
            }
            if (!CheckPlatform(ref err))
            {

                return false;
            }

            DataTable telNumList = null;
            telNumList = GetDevice(msgInfo);

            if (msgInfo.SendArea != SendArea.全员推送 && (telNumList == null || telNumList.Rows.Count == 0))
            {
                err = "没有找到可发送的人员";
                return false;
            }
            if (msgInfo.SendArea == SendArea.全员推送)
            {
                PostAndroid(null);
                PostIos(null);
            }
            else
            {

                //分解出安卓 和IOS数量
                List<string> android = new List<string>();
                List<string> IOS = new List<string>();
                DataRow[] drs = telNumList.Select("ClientType=1");
                if (drs != null && drs.Length > 0)
                {
                    android = drs.Select(d => d.Field<string>("DeviceNo")).ToList();

                }
                drs = telNumList.Select("ClientType=2");

                if (drs != null && drs.Length > 0)
                {
                    IOS = drs.Select(d => d.Field<string>("DeviceNo")).ToList();

                }
                if (android.Count > 0)
                {

                    PostAndroid(android);

                }
                if (IOS.Count > 0)
                {
                    PostIos(IOS);

                }


            }
            if (telNumList != null)
            {
                msgInfo.TotalUserCount = telNumList.Rows.Count;
                msgInfo.HasSendUserCount = telNumList.Rows.Count;
            }

            msgInfo.HasSendCount += 1;
            new SendMsgInfoBll().Save(msgInfo);
            return true;
        }

        private DataTable GetDevice(SendMsgInfo msgInfo)
        {
            DataTable dt = null;
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
                    dt = new ManagerUserInfoBll().GetDevice(where);
                    break;
                case SendArea.用户等级:
                    dt = new ManagerUserInfoBll().GetDeviceWithOrder(where);
                    break;

                case SendArea.购买次数:
                    dt = new ManagerUserInfoBll().GetDeviceWithBuyCount(msgInfo.MinBuyCount, msgInfo.MaxBuyCount);

                    break;
                case SendArea.指定手机号:
                    break;
                default:
                    break;
            }
            return dt;
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
        public List<UmEntity> GetListUmEntity(List<string> deviceNo, out UmengSendType st)
        {
            List<UmEntity> list = new List<UmEntity>();
            st = GetSendType(deviceNo);
            switch (st)
            {
                case UmengSendType.unicast:
                    list.Add(new UmEntity() { device_token = deviceNo[0] });
                    break;
                case UmengSendType.listcast:


                    int totalCount = deviceNo.Count;
                    int loopCoount = deviceNo.Count / 500;
                    for (int i = 0; i <= loopCoount; i++)
                    {
                        string deviceNoStr = string.Empty;
                        int start = 500 * i;
                        int end = 500 * (i + 1);
                        if (end > totalCount)
                        {
                            end = totalCount;
                        }
                        for (int k = start; k < end; k++)
                        {
                            if (deviceNoStr.Length > 0)
                            {
                                deviceNoStr += ",";
                            }
                            deviceNoStr += deviceNo[i];
                        }
                        UmEntity ue = new UmEntity();
                        ue.device_token = deviceNoStr;
                        list.Add(new UmEntity() { device_token = deviceNoStr });
                    }

                    break;
                case UmengSendType.broadcast:

                    list.Add(new UmEntity());
                    break;
                case UmengSendType.groupcast:
                case UmengSendType.filecast:
                case UmengSendType.customizedcast:
                default:
                    break;
            }
            return list;
        }
        public void PostAndroid(List<string> deviceNo)
        {
            List<UmEntity> list = new List<UmEntity>();
            UmengSendType st = UmengSendType.broadcast;
            list = GetListUmEntity(deviceNo,out st);
            foreach (UmEntity item in list)
            {
                item.appkey = MsgServiceSet.AppKeyID; item.timestamp = ConvertDateTime(DateTime.Now);
                item.type = st.ToString(); item.production_mode = "true";
                item.description = MsgInfo.Note; item.thirdparty_id = MsgInfo.ID;

                AndroidMsgContent msgConetnt = new AndroidMsgContent()
                {
                    display_type = MsgInfo.MsgType.ToString()
                };
                MsgBody body = new MsgBody()
                {
                    ticker = MsgInfo.NoticeAlert,
                    title = MsgInfo.NoticeTitle,
                    text = MsgInfo.SendContent,
                    play_lights = "true",
                    play_sound = "true",
                    play_vibrate = "true",
                    after_open = "go_custom",
                    custom = ((int )MsgInfo.AppHandleTag).ToString() + "|" + MsgInfo.AppHandleContent
                };
                msgConetnt.body = body;
                item.payload = msgConetnt;
            }
            foreach (var item in list)
            {
                string postData = JsonConvert.SerializeObject(item);
                string sign = Sign(MsgServiceSet.Url, postData, MsgServiceSet.Pwd);
                Sharp.Common.HttpModle.HttpPost(MsgServiceSet.Url + "?sign=" + sign, postData);
            }


        }
        public void PostIos(List<string> deviceNo)
        {
            List<UmEntity> list = new List<UmEntity>();
            UmengSendType st = UmengSendType.broadcast;
            list = GetListUmEntity(deviceNo, out st);
           
            foreach (UmEntity item in list)
            {
                item.appkey = MsgServiceSet.AppKeyID; item.timestamp = ConvertDateTime(DateTime.Now);
                item.type = st.ToString(); item.production_mode = "true";
                item.description = MsgInfo.Note; item.thirdparty_id = MsgInfo.ID;

                IOSMsgContent msgConetnt = new IOSMsgContent() { AppHandleTag = ((int)MsgInfo.AppHandleTag).ToString(), AppHandleContent = MsgInfo.AppHandleContent };
                IOSaps body = new IOSaps()
                {
                    alert = MsgInfo.SendContent
                };
                msgConetnt.aps = body;
                item.payload = msgConetnt;
            }
            foreach (var item in list)
            {
                string postData = JsonConvert.SerializeObject(item);
                string sign = Sign(MsgServiceSet.Url, postData, MsgServiceSet.Pwd);
                Sharp.Common.HttpModle.HttpPost(MsgServiceSet.Url + "?sign=" + sign, postData);
            }


        }

        public UmengSendType GetSendType(List<string> deviceNo)
        {
            if (deviceNo == null || deviceNo.Count == 0)
            {
                return UmengSendType.broadcast;
            }
            if (deviceNo.Count == 1)
            {
                return UmengSendType.unicast;
            }
            else

                return UmengSendType.listcast;


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


