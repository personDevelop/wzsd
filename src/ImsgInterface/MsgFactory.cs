using EasyCms.Business;
using EasyCms.Model;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace ImsgInterface
{
    public class MsgFactory
    {
        private MsgFactory() { }
        public static ISendMsg CreateSendMsg(SendTool st)
        {
            ISendMsg sendMsg = null;
            string dllInfo = ConfigurationManager.AppSettings[st.ToString()];
            if (!string.IsNullOrWhiteSpace(dllInfo))
            {
                string[] Assamlyclass = dllInfo.Split(new char[] { '|' },
                     StringSplitOptions.RemoveEmptyEntries);
                if (Assamlyclass.Length == 2)
                {
                    sendMsg = Sharp.Common.Utils.CreateInstance(Assamlyclass[0], Assamlyclass[1]) as ISendMsg;
                }
            }
            return sendMsg;


        }


        public static string SendMsg(string ids, ref string err)
        {
            StringBuilder sb = new StringBuilder();

            WhereClip where = SendMsgInfo._.ID.In(ids.Split(','));
            List<SendMsgInfo> msgList = new SendMsgInfoBll().GetList(where);
            foreach (SendMsgInfo item in msgList)
            {
                ISendMsg send = CreateSendMsg(item.SendTool);
                if (send != null)
                {
                    string error = string.Empty;
                    bool isSuccess = send.SendMsg(item, ref error);
                    if (isSuccess)
                    {
                        sb.AppendLine(error);
                    }

                }
            }
            err = sb.ToString();
            return "发送成功";



        }


    }
}
