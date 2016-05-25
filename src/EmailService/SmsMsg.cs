using EasyCms.Model;
using ImsgInterface;
using Sharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace EmailService
{
    public class SendEmail : ISendMsg
    {

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



            return true;
        }
        public bool SendMsg(string from, string to, string userid, string msg, ref string error)
        { return true; }
        /// <summary>
        /// 及时发送
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool SendMsg(string host, int port, string from, string pwd, string to, string subject, string msgCotent, ref string err)
        {
            if (port==0)
            {
                port = 25;
            }
            MailMessage msg = new MailMessage(from, to)
            {
                Body = msgCotent,
                Subject = subject,
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                Priority = MailPriority.Normal
            };


          
            try
            {
                SmtpClient mSmtpClient = new SmtpClient()
                { Host = host, Port = port, UseDefaultCredentials = false, EnableSsl = false,
                    Credentials = new System.Net.NetworkCredential(from, pwd),
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network };
                mSmtpClient.Send(msg);
                MsgSendLog s = new MsgSendLog()
                {
                    ID = Guid.NewGuid().ToString(),
                    UserID = "系统管理员",
                    MyNum = from,
                    ContactNum = to,
                    SendTool = SendTool.邮件,
                    SendContent = msgCotent,
                    SendTime = DateTime.Now,
                    OrderNo = DateTime.Now.ToString("yyMMddHHmmssffffff")
                };
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                throw;
            }
            return false;

        }


        public EasyCms.Model.SysMsgInterSet MsgServiceSet
        {
            get;
            set;
        }
        public string GetResultbyId(string seacrchid)
        {
            return null;
        }
        public string GetResultbyTime(string telNo, DateTime? start, DateTime? end)
        {
            return null;
        }

        public string GetBalance()
        {
            return null;
        }

        public bool PhraseResult(string content, out string result)
        {
            result = string.Empty;
            return true;
        }



        public bool CheckPlatform(ref string err)
        {
            return true;
        }


        public string Sign(string content0 = "", string content1 = "", string content2 = "")
        {
            throw new NotImplementedException();
        }
    }
}
