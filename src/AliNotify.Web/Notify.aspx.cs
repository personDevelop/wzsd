using AliPayCommon;
using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AliNotify.Web
{
    public partial class Notify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            AliAsynchNotify notify = null;
            NotifyUtil aliNotify = null;
            string returnStr = "";
            string Result = "";
            string content = "";
            try
            {
                SortedDictionary<string, string> sPara = GetRequestPost(out   notify, out content);
                if (sPara.Count > 0)//判断是否有带返回参数
                {
                    //根据订单的订单编号 查找支付方式，然后再获取支付宝的配置参数
                    //这里不能根据sellerid 获取 是因为支付宝的支付方式也分多种
                    //商户订单号
                    string orderID = notify.out_trade_no;
                    if (string.IsNullOrWhiteSpace(orderID))
                    {
                        Result = returnStr = "无订单号";

                    }
                    else
                    {
                        //先根据参数传递过来的值，或者支付宝的配置参数
                        aliNotify = new NotifyUtil(orderID);
                        if (aliNotify == null)
                        {
                            Result = returnStr = aliNotify.Error;
                        }
                        else
                        {
                            bool verifyResult = aliNotify.Verify(sPara, notify.notify_id, notify.sign);

                            if (verifyResult)//验证成功
                            {
                                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                //请在这里加上商户的业务逻辑程序代码


                                //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                                //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表
                                bool isEist = new AsynchNotifyLogBll().Exit(notify.notify_id, notify.trade_status);
                                if (isEist)
                                {
                                    //处理过该状态  只记录日志 不再操作业务
                                    Result = "处理过该状态";
                                }
                                else
                                {
                                    AliTradeStatus tradestatus = Sharp.Common.EnumPhrase.Phrase<AliTradeStatus>(notify.trade_status);
                                    switch (tradestatus)
                                    {
                                        case AliTradeStatus.WAIT_BUYER_PAY:
                                        case AliTradeStatus.TRADE_CLOSED:
                                        case AliTradeStatus.TRADE_FINISHED:
                                        default:
                                            Result = tradestatus + "不处理";
                                            break;
                                        case AliTradeStatus.TRADE_SUCCESS:
                                            //付款成功
                                            //更新订单的付款状态 和操作日志记录，并发送短信或系统内通知
                                            new ShopOrderBll().PaySuccess(notify.out_trade_no, notify.total_fee,false);
                                            Result = "付款成功";
                                            break;
                                    }

                                }



                                //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                                returnStr = "success";  //请不要修改或删除

                                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            }
                            else//验证失败
                            {
                                returnStr = "fail";
                            }
                        }
                    }

                }
                else
                {
                    Result = returnStr = "无通知参数";
                }

                //生成通知日志
                AsynchNotifyLog Loga = new AsynchNotifyLog()
                {
                    ID = Guid.NewGuid().ToString(),
                    Code = "alipaydirect",
                    Name = "支付宝无线即时到账",
                    CreateTime = DateTime.Now,
                    TradeStatus = notify.trade_status,
                    ResOrderID = notify.out_trade_no,
                    TradeNo = notify.out_trade_no,
                    NodifyID = notify.notify_id,
                    NotifyContent = content,
                    Body = notify.body,
                    ReturnContent = returnStr,
                    Result = Result,

                };
                new AsynchNotifyLogBll().Save(Loga);
                Response.Write(returnStr);
            }
            catch (Exception ex)
            {
                new LogBll().WriteException(ex);
                new LogBll().WriteException(content);
                throw;
            }
        }



        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost(out AliAsynchNotify notify, out string content)
        {

            int i = 0;
            content = string.Empty;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                string key = requestItem[i];
                string value = Request.Form[key];
                sArray.Add(key, value);

                content += key + "=" + value + "&";

            }
            notify = AliAsynchNotify.Phrase(sArray);
            return sArray;
        }
    }
}