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
    public class ShopOrderApiController : BaseAPIControl
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="order">此处订单并不起作用，主要是为了接收其商品明细数据</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CreateOrder([FromBody] ShopOrderModel order)
        {
            if (order.OrderItems == null || order.OrderItems.Count == 0)
            {
                return "请选择要购买的商品".FormatError();
            }
            else
            {
                string err = string.Empty;

                try
                {
                    string userid = Request.GetAccountID();
                    order = new ShopOrderBll().CreateOrder(order, host,userid, out err);
                    if (!string.IsNullOrWhiteSpace(err))
                    {
                        return err.FormatError();

                    }
                    else
                    {
                        //获取默认地址
                        order.ShopAddress = new ShopShippingAddressBll().GetDefaultShopAddressForShow(userid);
                        //获取促销信息
                        //获取运费,先固定0
                        order.Freight = 0;

                        //获取配送信息  //先不获取了
                        if (string.IsNullOrWhiteSpace(err))
                        {
                            return order.FormatObj();
                        }
                        else
                        {
                            return err.FormatError();
                        }
                    }
                }
                catch (Exception ex)
                {

                    return ex.Format();
                }
            }



        }

        /// <summary>
        /// 返回的信息 包含 是否有拆分订单，自动拆分的原则是 团购或者参与促销活动的商品 必须单独一个订单,
        /// 或者包含虚拟产品，也会自动拆分订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PostOrder([FromBody] ShopOrderModel order)
        {
            string msg = string.Empty;

            bool isSuccess = msg == "订单提交成功";
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            string result = JsonWithDataTable.Serialize(new { IsSuccess = isSuccess, msg = msg });
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }

    }
}
