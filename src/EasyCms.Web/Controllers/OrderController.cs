using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ShopOrderModel order)
        {
           
            string error = string.Empty;
            if (order.OrderItems == null || order.OrderItems.Count == 0)
            {
                 
                error = "请选择要购买的商品";
            }
            else
            { 
                string userid = CmsSession.GetUserID();
                order = new ShopOrderBll().CreateOrder(order, "", userid, out error);
                if (string.IsNullOrWhiteSpace(error))
                { 
                    //获取默认地址
                    order.ShopAddress = new ShopShippingAddressBll().GetDefaultShopAddressForShow(userid);
                    //获取促销信息
                    //获取运费,先固定0
                    order.Freight = 0;

                    //获取配送信息  //先不获取了
                    
                }

            }
            if (string.IsNullOrWhiteSpace(error))
            {
                return View(order);
            }
            else
            {
                return null;
            }
          
        }
    }
}