using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EasyCms.Web.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index()
        {
            string userID = Session.GetUserID();
            List<ShopCardInfo> cardList = new List<ShopCardInfo>();
            if (string.IsNullOrWhiteSpace(userID))
            {
                //还没有登录，从cookie获取
                List<CookieCard> list = new List<CookieCard>();
                bool isHasCookie = false;
                string cookieValue = string.Empty;
                //先判断cookie里是否已有该商品，如果有则数量加1，
                foreach (string item in Request.Cookies.Keys)
                {
                    if (item == StaticValue.CardCookieName)
                    {
                        isHasCookie = true;
                        cookieValue = Request.Cookies[item].Value;
                        break;
                    }
                } 
                if (isHasCookie)
                {
                    cookieValue= HttpUtility.UrlDecode(cookieValue, Encoding.UTF8);
                    list = JsonWithDataTable.Deserialize(cookieValue, typeof(List<CookieCard>)) as List<CookieCard>;
                    ShopProductInfoBll bll = new ShopProductInfoBll();
                    foreach (var item in list)
                    {
                        ShopCardInfo sc = null;
                        switch (item.BuyType)
                        {
                            case ShopBuyType.普通购物:
                            case ShopBuyType.赠品:
                                //获取商品名称
                                sc =   bll.GetProduct(item.ProductId, item.SKU);
                                sc.AddTime = item.AddTime;
                                sc.ActivityID = item.ActivityID;
                                sc.BuyType = item.BuyType; 
                                sc.Quantity = item.Quantity;
                                sc.ID = item.ID;
                                break;
                            case ShopBuyType.套餐:
                                //暂时未实现套餐功能，可以用新建商品的方式 临时弄成套餐
                                break;
                            case ShopBuyType.团购: 
                            case ShopBuyType.秒杀:
                                //这两种不加入购物车，直接购买
                                continue;
                                
                            default:
                                break;
                        }
                        if (sc!=null)
                        {
                            cardList.Add(sc);
                        }
                      
                    }

                }
               
            }
            else
            {
                //从数据库获取
                ShopShoppingCartsBll bll = new ShopShoppingCartsBll();
                cardList = bll.GetMyCards( userID  );

            }
                return View(cardList);
        }


        public JsonResult Add(ShopBuyType buyType, string ActivityID, string ProductId, string SKU, decimal Quantity)
        {
            string userID = Session.GetUserID();
            if (string.IsNullOrWhiteSpace(userID))
            {
                //还没有登录，写到cookie里去
                List<CookieCard> list = new List<CookieCard>();
                bool isHasCookie = false;
                string cookieValue = string.Empty;
                //先判断cookie里是否已有该商品，如果有则数量加1，
                foreach (string item in Request.Cookies.Keys)
                {
                    if (item == StaticValue.CardCookieName)
                    {
                        isHasCookie = true;
                        cookieValue = Request.Cookies[item].Value;
                        break;
                    }
                }
                bool isEist = false;
                if (isHasCookie)
                {
                    cookieValue = HttpUtility.UrlDecode(cookieValue, Encoding.UTF8);
                    list = JsonWithDataTable.Deserialize(cookieValue, typeof(List<CookieCard>)) as List<CookieCard>;

                    foreach (var item in list)
                    {
                        if (item.BuyType == buyType && item.ActivityID == ActivityID
                            && item.ProductId == ProductId && item.SKU == SKU)
                        {
                            isEist = true;
                            item.Quantity += Quantity;
                            break;
                        }
                    }

                }
                if (!isEist)
                {
                    //直接添加cookie
                    CookieCard cc = new CookieCard() { ID = Guid.NewGuid().ToString(), ActivityID = ActivityID, BuyType = buyType, ProductId = ProductId, SKU = SKU, Quantity = Quantity, AddTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") };
                    list.Add(cc);
                }
                cookieValue = JsonWithDataTable.Serialize(list);
                HttpCookie hc = new HttpCookie(StaticValue.CardCookieName, cookieValue);
                Response.Cookies.Add(hc);

            }
            else
            {
                ShopShoppingCartsBll bll = new ShopShoppingCartsBll();
                ShopShoppingCarts card= bll.GetEntity(ShopShoppingCarts._.UserId==userID&& ShopShoppingCarts._.ItemType == buyType && ShopShoppingCarts._.ActivityID == ActivityID && ShopShoppingCarts._.ProductId == ProductId && ShopShoppingCarts._.SKU == SKU);
                if (card == null)
                {
                    card = new ShopShoppingCarts() { ID = Guid.NewGuid().ToString(), ActivityID = ActivityID, ItemType = buyType, ProductId = ProductId,
                        SKU = SKU, Quantity = Quantity, AddTime = DateTime.Now, UserId = userID
                    , Attributes = "", CostPrice = 0, Description = "", MarketPrice = 0, Name = "", SellPrice = 0, ThumbnailsUrl = "", Weight = 0 

                    };
                }
                else
                {
                    card.Quantity += Quantity;
                }
                bll.Save(card);
            }
            return new JsonResult() { JsonRequestBehavior=JsonRequestBehavior.AllowGet,Data=new { IsSuccess =true,msg= "添加到购物车" } };
        }

        public JsonResult DeleteCard(string[] ids)
        {
            string msg = string.Empty;
            string userID = Session.GetUserID();
            if (string.IsNullOrWhiteSpace(userID))
            {
                //还没有登录,从cookie里删除去
                List<CookieCard> list = new List<CookieCard>();
                bool isHasCookie = false;
                string cookieValue = string.Empty;
                //先判断cookie里是否已有该商品，如果有则数量加1，
                foreach (string item in Request.Cookies.Keys)
                {
                    if (item == StaticValue.CardCookieName)
                    {
                        isHasCookie = true;
                        cookieValue = Request.Cookies[item].Value;
                        break;
                    }
                }
                
                if (isHasCookie)
                {
                    cookieValue = HttpUtility.UrlDecode(cookieValue, Encoding.UTF8);
                    List<CookieCard>   Oldlist = JsonWithDataTable.Deserialize(cookieValue, typeof(List<CookieCard>)) as List<CookieCard>;

                    foreach (var item in Oldlist)
                    {
                        if (!ids.Contains( item.ID ))
                        {
                            list.Add(item);
                        }
                    }

                }
                HttpCookie hc = null;
                if (list.Count > 0)
                {
                    cookieValue = JsonWithDataTable.Serialize(list);
                      hc = new HttpCookie(StaticValue.CardCookieName, cookieValue);
                    
                }
                else
                {
                    
                    hc = new HttpCookie(StaticValue.CardCookieName, "");
                    hc.Expires = DateTime.Now.AddDays(-1);
                }
                Response.Cookies.Add(hc);

            }
            else
            {

                ShopShoppingCartsBll bll = new ShopShoppingCartsBll();
                msg = bll.Delete(ids) ;
               
            }
            return new JsonResult() {  JsonRequestBehavior= JsonRequestBehavior.AllowGet,
                 Data=new { IsSuccess=true,data=ids,msg=msg } 

            };

        }

    }
}