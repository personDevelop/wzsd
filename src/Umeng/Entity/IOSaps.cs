using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umeng.Entity
{
    public class IOSaps
    { /// <summary>
        /// 必填   
        /// </summary>
        public string alert { get; set; }
        /// <summary>
        /// 可选 
        /// </summary>
        public string badge { get; set; }
        /// <summary>
        /// 可选 
        /// </summary>
        public string sound { get; set; }
        /// <summary>
        /// 可选 
        /// </summary>
        public string content_available { get; set; }
        /// <summary>
        /// 可选, 注意: ios8才支持该字段。
        /// </summary>
        public string category { get; set; }

    }
}
