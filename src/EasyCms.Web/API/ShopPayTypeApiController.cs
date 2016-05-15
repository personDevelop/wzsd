using EasyCms.Business;
using EasyCms.Web.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace EasyCms.Web.API
{
    public class ShopPayTypeApiController : ApiController
    {
        public HttpResponseMessage GetPayType()
        {

           
                DataTable dt = new ShopPaymentTypesBll().GetPayType(1);
                return dt.Format();
               
           

        }
    }
}
