using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImsgInterface
{
    public interface ISendMsg
    {
        SysMsgInterSet MsgServiceSet { get; set; }
        bool SendMsg();
        bool SendMsg(SendMsgInfo msgInfo,ref string error);
        bool SendMsg(string from, string to, string userid, string msg, ref string error);

        string GetResultbyId(string seacrchid);

        string GetResultbyTime(string mobile, DateTime? start, DateTime? end);

        string GetBalance();

        bool PhraseResult(string content, out string result);

        bool CheckPlatform(ref string err);

        string Sign(string content0 = "", string content1 = "", string content2 = "");
    }
}
