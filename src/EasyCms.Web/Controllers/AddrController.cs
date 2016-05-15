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
    public class AddrController : Controller
    {
        // GET: Addr
        public ActionResult Index(string id)
        {
            ShopShippingAddress ssar = null;
            if (!string.IsNullOrWhiteSpace(id) )
            {
                ssar = new ShopShippingAddressBll().GetEntity(id);
            }
            if (ssar==null)
            {
                ssar = new ShopShippingAddress();
            }
            return View(ssar);
        }

      
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ShopShippingAddress addr)
        {
            string jsonerror = string.Empty;
            string userid = CmsSession.GetUserID();
            addr.UserId = userid;
            if (string.IsNullOrWhiteSpace(userid))
            {
                 
                jsonerror += "还没有登录,请先登录.";
            }
            if (string.IsNullOrWhiteSpace(addr.ShipName))
            {
                jsonerror += "<br/>请输入收货人姓名.";
            }
            if (string.IsNullOrWhiteSpace(addr.CelPhone))
            {
                jsonerror += "<br/>请输入手机号码.";
            }
            if (string.IsNullOrWhiteSpace(addr.Address))
            { 
                jsonerror += "<br/>请输入详细地址.";
            }
            if (addr.RegionId<1)
            {
                jsonerror += "<br/>请选择所在地区.";
            }

            if (string.IsNullOrWhiteSpace(jsonerror))
            {
                string error;
                ShopShippingAddressBll bll = new ShopShippingAddressBll();
                error = bll.Save(addr);
                if (error!="操作成功")
                {
                    jsonerror += error;
                } 
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            
                if (string.IsNullOrWhiteSpace(jsonerror))
                {
                string pathName = new AdministrativeRegionsBll().GetPathByID(addr.RegionId);
                addr.PathName = pathName;
                    return Json(new { result = true, Msg = jsonerror,data=JsonWithDataTable.Serialize(addr,false,ShopShippingAddress._.UserId.FullName
                        , ShopShippingAddress._.RegionId.FullName, ShopShippingAddress._.Latitude.FullName, ShopShippingAddress._.EmailAddress.FullName
                        , ShopShippingAddress._.Longitude.FullName, ShopShippingAddress._.TelPhone.FullName, ShopShippingAddress._.Zipcode.FullName) });
                }
                else
                {
                    return Json(new { result = false, Msg = jsonerror });

                }
            
        }

        [HttpPost]
        [AllowAnonymous]
         
        public ActionResult setdefault(string id)
        {
            string jsonerror = string.Empty;
            string userid = CmsSession.GetUserID();
            
            if (string.IsNullOrWhiteSpace(userid))
            {

                jsonerror += "还没有登录,请先登录.";
            }
             
            if (string.IsNullOrWhiteSpace(jsonerror))
            {
                string error;
                ShopShippingAddressBll bll = new ShopShippingAddressBll();
                error = bll.SetDefault(id);
                if (error != "操作成功")
                {
                    jsonerror += error;
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单

            if (string.IsNullOrWhiteSpace(jsonerror))
            {
                
                return Json(new
                {
                    IsSuccess = true,
                    Msg = jsonerror
                } );
            }
            else
            {
                return Json(new { IsSuccess = false, Msg = jsonerror });

            }

        }

        [HttpPost]
        [AllowAnonymous]
        
        public ActionResult delete(string id)
        {
            string jsonerror = string.Empty;
            string userid = CmsSession.GetUserID();

            if (string.IsNullOrWhiteSpace(userid))
            {

                jsonerror += "还没有登录,请先登录.";
            }

            if (string.IsNullOrWhiteSpace(jsonerror))
            { 
                ShopShippingAddressBll bll = new ShopShippingAddressBll();
                
                if (!bll.Delete(id))
                {
                    jsonerror += "删除失败";
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单

            if (string.IsNullOrWhiteSpace(jsonerror))
            {

                return Json(new
                {
                    IsSuccess = true,
                    Msg = jsonerror
                });
            }
            else
            {
                return Json(new { IsSuccess = false, Msg = jsonerror });

            }

        }

    }
}