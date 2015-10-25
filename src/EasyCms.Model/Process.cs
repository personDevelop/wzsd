using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCms.Model
{
    public class Process
    {
        public string Name { get; set; }
        /// <summary>
        /// true  css样式为node  否则为proce
        /// </summary>
        public bool IsNode { get; set; }  
        /// <summary>
        /// true css样式为ready 否则为wait
        /// </summary>
        public bool IsReady { get; set; }
      
    }
}
