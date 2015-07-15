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
    public class ShopCartController : ApiController
    {
       

        // GET api/shopcart/5
        public HttpResponseMessage Get(string id)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            DataTable dt = new ShopShoppingCartsBll().GetList(id); 
            string result = JsonWithDataTable.Serialize(dt); 
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;

        }

        // POST api/shopcart
        public int Post([FromBody]ShopShoppingCarts shopCart)
        {
            return new ShopShoppingCartsBll().Save(shopCart);
        }


        // DELETE api/shopcart/5
        public string Delete(string id)
        {
            return new ShopShoppingCartsBll().Delete(id);
        }
    }
}
