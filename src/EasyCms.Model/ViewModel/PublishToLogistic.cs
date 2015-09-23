using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model.ViewModel
{
    [JsonObject]
    public class PublishToLogistic
    {
        /// <summary>
        /// 物流快递公司ID
        /// </summary>
        public string LogistID { get; set; }



        /// <summary>
        /// 订单ID集合
        /// </summary>
        public List<string> OrderID { get; set; }
    }
}
