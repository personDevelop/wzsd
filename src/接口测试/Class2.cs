using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 接口测试
{
    class Class2
    {
        public int int1 { get; set; }
        public int? int2 { get; set; }

        public DateTime DateTime1 { get; set; }
        public DateTime? DateTime2 { get; set; }

        public dd enumdd { get; set; }
        public bool bool1 { get; set; }
        public bool? bool2 { get; set; }


        public string  string1 { get; set; }
        public string string2 { get; set; }

    }
    public enum dd
    {
        a, b, c
    }
}
