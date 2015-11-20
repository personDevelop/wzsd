using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umeng.Entity
{
    public class AndroidMsgContent : IContent
    {
        /// <summary>
        /// 必填 消息类型，值可以为:
        /// </summary>
        public string display_type { get; set; }
        /// <summary>
        ///    // 必填 消息体。
        ///                           display_type=message时,body的内容只需填写custom字段。
        ///                          display_type=notification时, body包含如下参数:
        /// </summary>
        public MsgBody body { get; set; }
    }
}
