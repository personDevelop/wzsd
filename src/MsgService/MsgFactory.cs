using EasyCms.Business;
using EasyCms.Model;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MsgService
{
    public class MsgFactory
    {
        private MsgFactory() { }
        public static ISendMsg CreateSendMsg(SendTool st)
        {
            ISendMsg sendMsg = null;
            switch (st)
            {
                case SendTool.短信:
                    sendMsg = new SmsMsg();
                    break;
                case SendTool.APP客户端:
                    break;
                case SendTool.邮件:
                    break;
                case SendTool.站内信:
                    break;
                default:
                    break;
            }
            return sendMsg;


        }


        public static string SendMsg(string ids)
        {
       
            WhereClip where = SendMsgInfo._.ID.In(ids.Split(','));
            List<SendMsgInfo> msgList = new SendMsgInfoBll().GetList(where);
            foreach (SendMsgInfo item in msgList)
            {
                ISendMsg send = CreateSendMsg(item.SendTool);
                if (send != null)
                {
                    send.SendMsg(item);

                }
            }

            return "发送成功";



        }


    }
}
