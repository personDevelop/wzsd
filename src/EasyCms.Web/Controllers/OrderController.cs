 
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitOrder(ShopOrderModel order)
        {
            string Msg = string.Empty;
            if (order.OrderItems == null || order.OrderItems.Count == 0)
            {
                Msg = "请选择要购买的商品";
            }
            else
            {
               
                ManagerUserInfo user = EasyCms.Session.CmsSession.GetUser();

                bool mustGenerSign;
                try
                {
                    string orderID = new ShopOrderBll().Submit(order, user, out mustGenerSign, out Msg);

                    if (string.IsNullOrWhiteSpace(Msg))
                    { 
                        if (mustGenerSign)
                        {
                            bool isSucess = new ShopPaymentTypesBll().GenerPayPara(orderID, out Msg);
                            Redirect("");//去支付
                             
                        }
                        

                    }
                }
                catch (Exception e)
                {
                    
                }
            }
            return View("index",Msg);
        }

        
         public ActionResult Pay()
        {
            //商户订单号，商户网站订单系统中唯一订单号，必填
            string out_trade_no = "";

            //订单名称，必填
            string subject = "";

            //付款金额，必填
            string total_fee = "";

            //商品描述，可空
            string body = "";




            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            //sParaTemp.Add("service", AlipayConfig.service);
            //sParaTemp.Add("partner", AlipayConfig.partner);
            //sParaTemp.Add("seller_id", AlipayConfig.seller_id);
            //sParaTemp.Add("_input_charset", AlipayConfig.input_charset.ToLower());
            //sParaTemp.Add("payment_type", AlipayConfig.payment_type);
            //sParaTemp.Add("notify_url", AlipayConfig.notify_url);
            //sParaTemp.Add("return_url", AlipayConfig.return_url);
            //sParaTemp.Add("anti_phishing_key", AlipayConfig.anti_phishing_key);
            //sParaTemp.Add("exter_invoke_ip", AlipayConfig.exter_invoke_ip);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", body);
            //其他业务参数根据在线开发文档，添加参数.文档地址:https://doc.open.alipay.com/doc2/detail.htm?spm=a219a.7629140.0.0.O9yorI&treeId=62&articleId=103740&docType=1
            //如sParaTemp.Add("参数名","参数值");

            //建立请求
            //string sHtmlText = AlipaySubmit.BuildRequest(sParaTemp, "get", "确认");
            return View();
        }
    }
}