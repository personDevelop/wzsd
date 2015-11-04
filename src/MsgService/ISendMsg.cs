using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsgService
{
   public  interface ISendMsg
    {
        SysMsgInterSet MsgServiceSet { get; set; }
        bool SendMsg();
        bool SendMsg(SendMsgInfo msgInfo);
        bool SendMsg(string from, string to, string userid, string msg);

        string GetResultbyId(string seacrchid);

        string GetResultbyTime(string mobile, DateTime? start, DateTime? end);

        string GetBalance();

        bool PhraseResult(string content, out string result);
    }
}
