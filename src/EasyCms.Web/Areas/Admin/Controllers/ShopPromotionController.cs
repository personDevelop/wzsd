using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using EasyCms.Web.Common;
using EasyCms.Session;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class ShopPromotionController : Controller
    {
        ShopPromotionBll bll = new ShopPromotionBll();
        //
        // GET: /Admin/ShopPromotion/
        public ActionResult Index()
        {

            return View();
        }
    
        public string GetList(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum.PhrasePageIndex(), pagesize, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }
       
       
        //
        // POST: /Admin/ShopPromotion/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopPromotion p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<ShopPromotion>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopPromotion>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                    p.CreateUser = CmsSession.GetUserID() ?? "root";
                }
                if (p.ActionType!= ActionType.免运费 && p.HandsaleCount<=0)
                {
                    ModelState.AddModelError("HandsaleCount", "赠送数量必须大于0");
                }
                if (p.ActionType== ActionType.商品 &&(p.ActionEvent== ActionEvent.注册|| p.ActionEvent == ActionEvent.评价
                    || p.ActionEvent == ActionEvent.评论))
                {
                    ModelState.AddModelError("ActionEvent", "注册、评价、评论的时候不能执行送商品的规则");
                }
                if (p.ActionType == ActionType.打折扣 && (p.ActionEvent == ActionEvent.注册 || p.ActionEvent == ActionEvent.评价
                    || p.ActionEvent == ActionEvent.评论))
                {
                    ModelState.AddModelError("ActionEvent", "注册、评价、评论的时候不能执行送打折扣的规则");
                }
                if (p.ActionType == ActionType.免运费 && (p.ActionEvent == ActionEvent.注册 || p.ActionEvent == ActionEvent.评价
                   || p.ActionEvent == ActionEvent.评论))
                {
                    ModelState.AddModelError("ActionEvent", "注册、评价、评论的时候不能执行免运费的规则");
                }
                switch (p.ActionType)
                {
                    case ActionType.优惠券:
                        if (string.IsNullOrWhiteSpace(p.CouponID))
                        {
                            ModelState.AddModelError("CouponName", "优惠券不能为空");
                        }
                        else
                        {
                            p.CouponName = new CouponRuleBll().GetCouponName(p.CouponID);


                        }
                        break;
                    case ActionType.积分:
                        break;
                    case ActionType.现金:
                        break;
                    case ActionType.商品:
                        if (string.IsNullOrWhiteSpace(p.HandsaleProductId))
                        {
                            ModelState.AddModelError("HandProductName", "赠送商品不能为空");
                        }
                        break;
                    case ActionType.打折扣:
                        break;
                    case ActionType.免运费:
                        break;
                    case ActionType.经验值:
                        break;
                    default:
                        break;
                }
                if (ModelState.IsValid)
                {
                    bll.Save(p);
                    if (TempData.ContainsKey("IsSuccess"))
                    {
                        TempData["IsSuccess"] = "保存成功";

                    }
                    else
                    {
                        TempData.Add("IsSuccess", "保存成功");
                    }
                    ModelState.Clear();
                    if (collection["IsContinueAdd"] == "1")
                    {
                        p = new ShopPromotion();

                    }
                    else
                    {
                        p = bll.GetEntity(p.ID);
                    }
                }
               
               


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/ShopPromotion/Edit/5
        public ActionResult Edit(string id)
        {

            ShopPromotion p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopPromotion();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ShopPromotion/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
