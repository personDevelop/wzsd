using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyCms.Web.Common;
using EasyCms.Business;
namespace EasyCms.Web.API
{
    public class CouponApiController : BaseAPIControl
    {
        public HttpResponseMessage GetCoupon()
        {
            try
            {

                DataTable dt = new CouponRuleBll().GetCoupon(host);
                return dt.Format();
            }
            catch (Exception ex)
            {

                return ex.Format();
            }
        }
    }
}
