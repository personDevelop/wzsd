using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umeng.Entity
{
    /// <summary>
    /// 发送策略
    /// </summary>
    public class IOSSendPolicy
    {


        /// <summary>
        ///   可选 定时发送时间，若不填写表示立即发送。
        ///                      定时发送时间不能小于当前时间
        ///                      格式: "YYYY-MM-DD HH:mm:ss"。 
        ///                     注意, start_time只对任务生效。
        /// </summary>
        public string start_time { get; set; }
        /// <summary>
        ///   可选 消息过期时间,其值不可小于发送时间或者
        ///                          start_time(如果填写了的话), 
        ///                        如果不填写此参数，默认为3天后过期。格式同start_time
        /// </summary>
        public string expire_time { get; set; }
        /// <summary>
        ///   可选 发送限速，每秒发送的最大条数。  开发者发送的消息如果有请求自己服务器的资源，可以考虑此参数
        /// </summary>
        public string max_send_num { get; set; }
        /// <summary>
        ///   可选 开发者对消息的唯一标识，服务器会根据这个标识避免重复发送。
        ///                        有些情况下（例如网络异常）开发者可能会重复调用API导致
        ///                        消息多次下发到客户端。如果需要处理这种情况，可以考虑此参数。
        ///                      注意, out_biz_no只对任务生效。
        /// </summary>
        public string out_biz_no { get; set; }
    }

    /// <summary>
    /// 发送策略
    /// </summary>
    public class AndroidSendPolicy : IOSSendPolicy
    {
        /// <summary>
        ///   可选 开发者对消息的唯一标识，服务器会根据这个标识避免重复发送。
        ///                        有些情况下（例如网络异常）开发者可能会重复调用API导致
        ///                        消息多次下发到客户端。如果需要处理这种情况，可以考虑此参数。
        ///                      注意, out_biz_no只对任务生效。
        /// </summary>
        public string out_biz_no { get; set; }
    }
}
