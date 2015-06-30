using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using EasyCms.Web.Common;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class ShopProductInfoController : Controller
    {
        ShopProductInfoBll bll = new ShopProductInfoBll();
        //
        // GET: /Admin/ShopProductInfo/
        public ActionResult Index()
        {

            return View();
        }

        public string GetList(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum + 1, pagesize, ref   recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;

        }
        public string GetListForSelecte(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum, pagesize, ref   recordCount, true);
            string result = JsonWithDataTable.Serialize(dt);
            result = "{\"total\":\"" + recordCount.ToString() + "\",\"data\":" + result + "}";
            return result;
        }

        //
        // POST: /Admin/ShopProductInfo/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopProductInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<ShopProductInfo>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopProductInfo>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                    //p.CreatedUserID = Session.GetUserID();
                }
                List<BaseEntity> list = new List<BaseEntity>();

                if (!string.IsNullOrWhiteSpace(p.ShopCategoryID))
                {
                    string[] categorys = p.ShopCategoryID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in categorys)
                    {
                        list.Add(new ShopProductCategory() { ID = Guid.NewGuid().ToString(), CategoryID = item, ProductID = p.ID });
                    }
                }
                List<ShopProductAttributes> listAttri = new List<ShopProductAttributes>();
                foreach (string item in collection.Keys)
                {
                    if (item.StartsWith("WithProdcutVal|"))
                    {
                        string[] keys = item.Split('|');
                        string[] vals = collection[item].Split('|');
                        ShopProductAttributes sav = null;
                        if (keys[2] == "2")
                        {
                            //先判断下有没有该值的信息，没有则保存，并返回id

                            sav = new ShopProductAttributes() { ID = Guid.NewGuid().ToString(), AttributeId = keys[1], ProductId = p.ID, ValueStr = collection[item] };
                        }
                        else
                        {
                            sav = new ShopProductAttributes()
                            {
                                ID = Guid.NewGuid().ToString(),
                                AttributeId = vals[0],
                                ValueId =vals[1],
                                ProductId = p.ID
                            };
                        }

                        listAttri.Add(sav);
                    }

                }
                int i = bll.Save(p, list, listAttri);
                if (i > -1)
                {
                    TempData.Add("IsSuccess", "保存成功");
                }
                else
                {
                    ModelState.AddModelError("error", "保存失败");
                }

                ModelState.Clear();


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/ShopProductInfo/Edit/5
        public ActionResult Edit(string id)
        {

            ShopProductInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopProductInfo();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }
        public string CheckRepeat(string ID, string RecordStatus, string val)
        {
            return bll.Exit(ID, RecordStatus, val).ToString().ToLower();

        }
        [HttpPost]
        //
        // GET: /Admin/ShopProductInfo/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }


        public string GetAttrWithProdcutVal(string ptypeid, string productID)
        {
            System.Data.DataTable dt = bll.GetAttrWithProdcutVal(ptypeid, productID);
            return JsonWithDataTable.Serialize(dt);
        }

        public string GetGgWithProdcutVal(string ptypeid, string productID)
        {
            System.Data.DataTable dt = bll.GetGgWithProdcutVal(ptypeid, productID);
            return JsonWithDataTable.Serialize(dt);
        }
    }
}
