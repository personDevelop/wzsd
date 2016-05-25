using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCms.Model
{
  public   class MessageModel
    {
        public MessageModel() { }
        public MessageModel(string title,string msg, ShowMsgType msgType) { this.title = title; Msg = msg; MsgType = msgType; }
        private string title  = null;
        public string Title
        {
            get
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    switch (MsgType)
                    {
                        case ShowMsgType.error:
                            title = "错误信息";
                            break;
                        case ShowMsgType.success:
                            title = "操作成功";
                            break;
                        case ShowMsgType.info:
                            title = "提示信息";
                            break;
                        case ShowMsgType.warning:
                            title = "警示信息";
                            break;
                        default:
                            break;
                    }
                }
                return title;
            }

            set
            {
                title = value;
            }
        }
        public ShowMsgType MsgType { get; set; }

        public string Msg { get; set; }

        public string ButtonGroup { get; set; }

         

    }

    public enum ShowMsgType
    {
        error,
        success,
        info,
        warning

    }
}
