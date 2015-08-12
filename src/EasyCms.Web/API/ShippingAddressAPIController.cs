using EasyCms.Business;
using EasyCms.Model;
using EasyCms.Web.Common;
using Sharp.Common;
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
        public HttpResponseMessage Get()
        {
            try
            {
                var resp = new HttpResponseMessage(HttpStatusCode.OK);
                string userid = Request.GetAccountID();

                string result = string.Empty;
                if (string.IsNullOrWhiteSpace(userid))
                {
                    //测试token  获取所有token
                    string token = Request.GetToken();
                    string msg = "当前的token值是【{0}】；系统里包含的token值是【{1}】";
                    string oldToken = string.Empty;
                    foreach (var item in Class1.list)
                    {
                        oldToken += item + " ";
                    }
                    msg = string.Format(msg, token, oldToken);
                    return ("无效令牌" + msg).FormatError();

                }
                else
                {
                    DataTable dt = new ShopShippingAddressBll().GetList(userid, false);
                    return dt.Format();
                }
            }
            catch (Exception ex)
            {
                return ex.Format();

            }

        }
        public HttpResponseMessage GetDefault()
        {
            try
            {

                DataTable dt = new ShopShippingAddressBll().GetList(Request.GetAccountID(), true);
                return dt.Format();
            }
            catch (Exception ex)
            {
                return ex.Format();

            }
        }
        [HttpGet]
        public HttpResponseMessage Delete(string id)
        {
            try
            {


                string result = new ShopShippingAddressBll().Delete(id);
                return result.FormatError();

            }
            catch (Exception ex)
            {
                return ex.Format();

            }
        }
        [HttpGet]
        public HttpResponseMessage SetDefault(string id)
        {
            try
            {

                string result = new ShopShippingAddressBll().SetDefault(id);
                return result.FormatError();
            }
            catch (Exception ex)
            {
                return ex.Format();

            }
        }

        public HttpResponseMessage Post([FromBody]  ShopShippingAddress shopShippingAddress)
        {
            try
            {
                //检验验证码是否正确，
                string msg = string.Empty;

                if (shopShippingAddress.RegionId < 1)
                {
                    msg = "收件地区不能为空";
                }
                else
                    if (string.IsNullOrWhiteSpace(shopShippingAddress.ShipName))
                    {
                        msg = "收件人姓名不能为空";
                    }
                    else

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
                                shopShippingAddress.UserId = Request.GetAccountID();
                                ShopShippingAddressBll bll = new ShopShippingAddressBll();
                                ShopShippingAddress entity = null;

                                if (shopShippingAddress.RecordStatus == Sharp.Common.StatusType.update)
                                {

                                    entity = bll.GetEntity(shopShippingAddress.ID);
                                    BaseEntity.CopyFrom<ShopShippingAddress>(entity, shopShippingAddress);

                                }
                                else
                                {

                                    entity = shopShippingAddress;
                                }

                                msg = bll.Save(entity);
                            }

                bool isSuccess = msg == "添加成功";
                if (isSuccess)
                {
                    return JsonWithDataTable.Serialize(shopShippingAddress).FormatSuccess();

                }
                else
                {
                    return msg.FormatError();
                }
            }
            catch (Exception ex)
            {
                return ex.Format();

            }


        }

    }
}
