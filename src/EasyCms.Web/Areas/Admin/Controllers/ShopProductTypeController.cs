using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using EasyCms.Web.Common;
using System.Web.Helpers;

namespace EasyCms.Web.Areas.Admin.Controllers
{
    public class ShopProductTypeController : Controller
    {
        ShopProductTypeBll bll = new ShopProductTypeBll();
        //
        // GET: /Admin/ShopProductType/
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
        public string GetListForSelecte()
        {

            System.Data.DataTable dt = bll.GetList(true);
            return JsonWithDataTable.Serialize(dt);
        }

        public string GetAttrList(string ptypeid, bool isGg)
        {
            System.Data.DataTable dt = bll.GetAttrList(ptypeid, isGg);
            return JsonWithDataTable.Serialize(dt);
        }

        public string CheckRepeat(string ID, string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID, RecordStatus, val, IsCode).ToString().ToLower();

        }

        //
        // POST: /Admin/ShopProductType/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopProductType p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<ShopProductType>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopProductType>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }

                }
                //获取商品类型
                List<string> brandList = new List<string>();
                foreach (string item in collection.Keys)
                {
                    if (item.StartsWith("sbd"))
                    {
                        string ptID = item.Substring(3);
                        if (!string.IsNullOrWhiteSpace(ptID))
                        {
                            brandList.Add(ptID);
                        }

                    }
                }
                bll.Save(p, brandList);
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
                    p = new ShopProductType();

                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/ShopProductType/Edit/5
        public ActionResult Edit(string id)
        {

            ShopProductType p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopProductType();
                p.ID = Guid.NewGuid().ToString();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ShopProductType/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }

        public ActionResult EditExtend(int id, string other)
        {
            ShopExtendInfo extend = null;
            if (!string.IsNullOrWhiteSpace(other))
            {
                string[] ptandextendid = other.Split(',');
                if (ptandextendid.Length == 1)
                {

                }
                else
                {
                    extend = bll.GetShopExtendInfo(ptandextendid[1]);
                }



                if (extend == null)
                {
                    extend = new ShopExtendInfo();
                    extend.ProductTypeID = ptandextendid[0];
                }
                if (id == 1)
                {
                    extend.UsageMode = 2;
                    //规格
                    return View("EditGg", extend);

                }
                else
                {
                    extend.UsageMode = 0;
                    //扩展属性
                    return View("EditExtend", extend);
                }
            }
            return new ContentResult() { Content = "没有商品类型" };
        }

        //
        // POST: /Admin/ShopProductType/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveExtend(FormCollection collection)
        {
            ShopExtendInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetShopExtendInfo(collection["ID"]);
                    p.BindForm<ShopExtendInfo>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopExtendInfo>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }

                }
                if (string.IsNullOrWhiteSpace(p.ProductTypeID))
                {
                    return Json(new { result = false, msg = "请先保存商品类型" });
                }
                bll.SaveShopExtendInfo(p);
                AddVals(p.ID, p.Vals);

                return Json(new { result = true, msg = string.Empty, id = p.ID, RecordStatus = p.RecordStatus.ToString() });

            }
            catch (Exception ex)
            {

                return Json(new { result = false, msg = ex.Message });

            }

        }


        public ActionResult AddExtendVal(string AttributeId, string Vals)
        {
            try
            {
                AddVals(AttributeId, Vals);
                return Json(new { result = true, msg = string.Empty });
            }
            catch (Exception ex)
            {

                return Json(new { result = false, msg = ex.Message });
            }
        }

        private void AddVals(string AttributeId, string Vals)
        {
            if (!string.IsNullOrWhiteSpace(Vals))
            {



                string[] vals = Vals.Split(new char[] { ',', ';', '，', '；', '/', '\\', '、', '、' }, StringSplitOptions.RemoveEmptyEntries);
                List<ShopExtendInfoValue> list = new List<ShopExtendInfoValue>();
                foreach (var item in vals)
                {
                    ShopExtendInfoValue s = new ShopExtendInfoValue()
                    {
                        ID = Guid.NewGuid().ToString(),
                        ValueStr = item,
                        AttributeId = AttributeId
                    };
                    list.Add(s);

                }
                int i = bll.Save(list);
            }
        }
        public ActionResult AddExtendImgVal(string AttributeId, string ImageID, string Note)
        {
            try
            {
                ShopExtendInfoValue s = new ShopExtendInfoValue()
                {
                    ID = Guid.NewGuid().ToString(),
                    ImageID = ImageID,
                    AttributeId = AttributeId,
                    ValueStr = Note,

                };
                List<ShopExtendInfoValue> list = new List<ShopExtendInfoValue>();
                list.Add(s);
                int i = bll.Save(list);
                return Json(new { result = true, msg = string.Empty });
            }
            catch (Exception ex)
            {

                return Json(new { result = false, msg = ex.Message });
            }

        }


    }
}
