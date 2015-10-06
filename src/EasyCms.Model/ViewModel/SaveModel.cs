using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCms.Model.ViewModel
{
    public class SaveModel
    {
        public int Sqtype { get; set; }
        public bool IsAll { get; set; }

        public string RoleID { get; set; }


        public List<RightData> RightData { get; set; }
    }

    public class RightData
    {
        public string ID { get; set; }

        public bool IsEnable { get; set; }

        public bool IsVisble { get; set; }

    }
}
