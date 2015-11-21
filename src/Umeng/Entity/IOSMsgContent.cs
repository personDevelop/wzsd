using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umeng.Entity
{
    public class IOSMsgContent : IContent
    {
        public IOSaps aps { get; set; }

        public string AppHandleTag { get; set; }
        public string AppHandleContent { get; set; }
 
    }
}
