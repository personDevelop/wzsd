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
    public class ShopCartAPIController : ApiController
    {


        // GET api/shopcart/5
        public HttpResponseMessage Get(string id)
        {
            try
            {

                DataTable dt = new ShopShoppingCartsBll().GetList(Request.GetAccountID());
                return dt.Format();
            }
            catch (Exception ex)
            {
                return ex.Format();

            }

        }

        // POST api/shopcart
        public HttpResponseMessage Post([FromBody]ShopShoppingCarts shopCart)
        {
            try
            {
                shopCart.UserId = Request.GetAccountID();
                new ShopShoppingCartsBll().Save(shopCart);
                return "操作成功".FormatSuccess();

            }
            catch (Exception ex)
            {
                return ex.Format();

            }

        }


        // DELETE api/shopcart/5
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                return new ShopShoppingCartsBll().Delete(id).FormatError();
                
            }
            catch (Exception ex)
            {
                return ex.Format();

            }
        }
    }
}
