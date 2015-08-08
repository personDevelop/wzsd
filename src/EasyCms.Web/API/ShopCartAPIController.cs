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
    public class ShopCartAPIController : BaseAPIControl
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

        
        // POST api/shopcart
        [HttpPost]
        public HttpResponseMessage CardInfo([FromBody] CardInfo card)
        {
            try
            {
                string cardInfo = card.SPXX;
                if (string.IsNullOrWhiteSpace(cardInfo))
                {
                    return "购物车商品信息不能为空".FormatError();

                }
                //格式 shpid,;spid,skuid
                string[] cardShops = cardInfo.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> productIDS = new List<string>();
                List<string> SKUIDS = new List<string>();
                foreach (string item in cardShops)
                {
                    string[] spidandSku = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string spid = spidandSku[0];
                    if (!string.IsNullOrWhiteSpace(spid))
                    {
                        productIDS.Add(spid);
                    }
                    if (spidandSku.Length == 2)
                    {
                        
                        //开启规格的商品
                        string skuid = spidandSku[1];
                        if (!string.IsNullOrWhiteSpace(skuid))
                        {
                            SKUIDS.Add(skuid);
                        }
                    }
                }
                DataTable dt = new ShopShoppingCartsBll().GetCardInfo(productIDS, SKUIDS, host);
                return dt.Format();


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

    [Newtonsoft.Json.JsonObject]
    public class CardInfo { public string SPXX { get; set; } }
}
