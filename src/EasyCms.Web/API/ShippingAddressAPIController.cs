using EasyCms.Business;
using EasyCms.Model;
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
    public class ShippingAddressAPIController : ApiController
    {

        // GET api/shopcart/5
        public HttpResponseMessage Get(string id)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            
            DataTable dt = new ShopShippingAddressBll().GetList(id.GetAccountID(), false);
            string result = JsonWithDataTable.Serialize(dt);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;

        }
        public HttpResponseMessage GetDefault(string id)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            DataTable dt = new ShopShippingAddressBll().GetList(id.GetAccountID(), true);
            string result = JsonWithDataTable.Serialize(dt);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }
        [HttpGet]
        public HttpResponseMessage Delete(string id)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            string result = new ShopShippingAddressBll().Delete(id );
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }
        [HttpGet]
        public HttpResponseMessage SetDefault(string id)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            string result = new ShopShippingAddressBll().SetDefault(id);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }

        public HttpResponseMessage Post([FromBody]ShopShippingAddress shopShippingAddress)
        {
            //检验验证码是否正确，
            string msg = string.Empty;
            if (string.IsNullOrWhiteSpace(shopShippingAddress.UserId))
            {
                msg = "用户ID不能为空";
            }
            else
                if (shopShippingAddress.RegionId < 1)
                {
                    msg = "收件地区不能为空";
                }
                else 
                    if (string.IsNullOrWhiteSpace(shopShippingAddress.ShipName))
                    {
                        msg = "收件人姓名不能为空";
                    }

            if (string.IsNullOrWhiteSpace(shopShippingAddress.CelPhone))
            {
                msg = "收件人电话不能为空";
            }
            else
                if (string.IsNullOrWhiteSpace(shopShippingAddress.Address))
                {
                    msg = "详细地址不能为空";
                }
                else
                {
                    shopShippingAddress.UserId = shopShippingAddress.UserId.GetAccountID();
                    msg = new ShopShippingAddressBll().Save(shopShippingAddress);
                }

            bool isSuccess = msg == "添加成功";
            var resp = new HttpResponseMessage(HttpStatusCode.OK); 
            string result = JsonWithDataTable.Serialize(new { IsSuccess = isSuccess, msg = msg,data=shopShippingAddress });
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;

        }

    }
}
