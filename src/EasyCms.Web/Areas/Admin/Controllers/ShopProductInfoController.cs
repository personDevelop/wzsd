﻿using EasyCms.Business;
using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sharp.Common;
using EasyCms.Web.Common;
using System.Data;

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

        public string GetList(string categoryID, string Name, int pagenum, int pagesize)
        { 
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(  categoryID, Name, pagenum.PhrasePageIndex(), pagesize, ref recordCount);
            string result = JsonWithDataTable.Serialize(dt);
            result = string.Format("{{\"total\":\"{0}\",\"data\":{1}}}", recordCount, result);
            return result;
        }
        public string GetRelationList(string productID,  string categoryID, string Name, int pagenum, int pagesize )
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetRelationList(productID, true, categoryID, Name, pagenum.PhrasePageIndex(), pagesize, ref recordCount);
            string result = JsonWithDataTable.Serialize(dt);
            result = string.Format("{{\"total\":\"{0}\",\"data\":{1}}}", recordCount, result);
            return result; 
        }
        public string GetNotRelationList(string productID,  string categoryID, string Name, int pagenum, int pagesize )
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetRelationList(productID, false, categoryID, Name, pagenum.PhrasePageIndex(), pagesize, ref recordCount);
            string result = JsonWithDataTable.Serialize(dt);
            result = string.Format("{{\"total\":\"{0}\",\"data\":{1}}}", recordCount, result);
            return result;
        }
        [HttpPost]
        public string AddRelation(string productID, string RlationProductIDs, bool isDoubleRelation)
        {
            return bll.AddRelation(productID, RlationProductIDs, isDoubleRelation);
        }
        [HttpPost]
        public string RemoveRelation(string productID, string RlationProductIDs)
        {
            return bll.RemoveRelation(productID, RlationProductIDs);
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
                    List<string> listHasAdd = new List<string>();

                    foreach (var item in categorys)
                    {
                        if (listHasAdd.Contains(item))
                        {
                            continue;
                        }
                        listHasAdd.Add(item);
                        list.Add(new ShopProductCategory() { ID = Guid.NewGuid().ToString(), CategoryID = item, ProductID = p.ID });
                    }
                }
                List<ShopProductAttributes> listAttri = new List<ShopProductAttributes>();
                List<ShopProductSKU> listSku = new List<ShopProductSKU>();
                List<ShopProductSKUInfo> listSkuInfo = new List<ShopProductSKUInfo>();
                Dictionary<int, string> rowSpeckID = new Dictionary<int, string>();
                Dictionary<string, string> SkuIDName = new Dictionary<string, string>();
                Dictionary<int, ShopProductSKUInfo> rowShopProductSKUInfo = new Dictionary<int, ShopProductSKUInfo>();
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
                                ValueId = vals[1],
                                ProductId = p.ID
                            };
                        }

                        listAttri.Add(sav);
                    }
                    else if (item.StartsWith("WithGgVal|"))
                    {
                        string s = collection[item];
                        //选择的规格值
                        //if ()
                        //{

                        //}
                    }
                    else if (item.StartsWith("dtrow|"))
                    {
                        //动态行的值信息
                        ShopProductSKU sku = new ShopProductSKU();
                        sku.ProductId = p.ID;
                        string[] vals = item.Split('|');
                        int rowindex = int.Parse(vals[1]);


                        if (rowSpeckID.ContainsKey(rowindex))
                        {
                            sku.ID = rowSpeckID[rowindex];
                        }
                        else
                        {

                            sku.ID = Guid.NewGuid().ToString();
                            rowSpeckID.Add(rowindex, sku.ID);

                        }
                        listSku.Add(sku);
                        string[] fromVal = collection[item].Split('|');
                        sku.AttributeId = fromVal[0];
                        sku.ValueId = fromVal[1];
                        if (SkuIDName.ContainsKey(sku.ID))
                        {
                            SkuIDName[sku.ID] += "  " + fromVal[3] + ":" + fromVal[2];
                        }
                        else
                        {
                            SkuIDName.Add(sku.ID, fromVal[3] + ":" + fromVal[2]);
                        } 
                    }
                    else if (item.StartsWith("row|"))
                    {
                        //固定行的值信息
                        ShopProductSKUInfo skuinfo = null;
                        string[] vals = item.Split('|');
                        int rowindex = int.Parse(vals[1]);
                        if (rowSpeckID.ContainsKey(rowindex) && rowShopProductSKUInfo.ContainsKey(rowindex))
                        {
                            skuinfo = rowShopProductSKUInfo[rowindex];

                        }
                        else
                        {
                            skuinfo = new ShopProductSKUInfo();
                            skuinfo.ID = Guid.NewGuid().ToString();
                            if (rowSpeckID.ContainsKey(rowindex))
                            {
                                skuinfo.SKURelationID = rowSpeckID[rowindex];
                            }
                            else
                            {
                                skuinfo.SKURelationID = Guid.NewGuid().ToString();
                                rowSpeckID.Add(rowindex, skuinfo.SKURelationID);
                            }
                            rowShopProductSKUInfo.Add(rowindex, skuinfo);
                            skuinfo.ProductId = p.ID;
                            skuinfo.OrderNo = rowindex;
                            listSkuInfo.Add(skuinfo);

                        }
                        decimal o = 0;
                        decimal.TryParse(collection[item], out o);
                        switch (vals[3])
                        {
                            case "商品编号":
                            case "SKU":
                                skuinfo.SKU = collection[item];
                                break;
                            case "售价":
                            case "SalePrice":
                                skuinfo.SalePrice = o;
                                break;
                            case "市场价":
                            case "MarketPrice":
                                skuinfo.MarketPrice = o;
                                break;
                            case "成本价":
                            case "CostPrice":
                                skuinfo.CostPrice = o;
                                break;
                            case "重量":
                            case "Weight":
                                skuinfo.Weight = o;
                                break;
                            case "库存":
                            case "Stock":
                                skuinfo.Stock = o;
                                break;
                            case "最大库存":
                            case "MaxAlertStock":
                                skuinfo.MaxAlertStock = o;
                                break;
                            case "最低库存":
                            case "MinAlertStock":
                                skuinfo.MinAlertStock = o;
                                break;
                            case "IsSale":
                                if (collection[item] == "on")
                                {
                                    skuinfo.IsSale = true;
                                }
                                else
                                {
                                    skuinfo.IsSale = false;
                                }
                                break;
                            case "IsDefault":
                                if (collection[item] == "on")
                                {
                                    skuinfo.IsDefault = true;
                                }
                                else
                                {
                                    skuinfo.IsDefault = false;
                                }
                                break;
                        }

                    }

                }
                foreach (var item in listSkuInfo)
                {
                    if (SkuIDName.ContainsKey(item.SKURelationID))
                    {
                        item.Name = SkuIDName[item.SKURelationID];
                    }
                }
                //获取商品推荐
                List<int> StationModeList = new List<int>();
                foreach (string item in collection.Keys)
                {
                    if (item.StartsWith("spt"))
                    {
                        string ptID = item.Substring(3);
                        string[] s = ptID.Split('|');
                        if (!string.IsNullOrWhiteSpace(s[1]))
                        {
                            StationModeList.Add(Convert.ToInt32(s[1]));
                        }

                    }
                }
                int i = bll.Save(p, list, listAttri, listSku, listSkuInfo, StationModeList);
                if (i > -1)
                {
                    if (TempData.ContainsKey("IsSuccess"))
                    {
                        TempData["IsSuccess"] = "保存成功";

                    }
                    else
                    {
                        TempData.Add("IsSuccess", "保存成功");
                    }
                    if (collection["IsContinueAdd"] == "1")
                    {
                        p = new ShopProductInfo();

                    }

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
        [HttpPost]
        //
        // GET: /Admin/ShopProductInfo/Delete/5
        public string IsSJOperator(string id, int opcode)
        {
            return bll.IsSJOperator(id, opcode);
        }


        public string GetAttrWithProdcutVal(string ptypeid, string productID)
        {
            System.Data.DataTable dt = bll.GetAttrWithProdcutVal(ptypeid, productID);
            return JsonWithDataTable.Serialize(dt);
        }

        public string GetGgWithProdcutVal(string ptypeid, string productID)
        {
            DataSet dt = bll.GetGgWithProdcutVal(ptypeid, productID);
            return JsonWithDataTable.Serialize(dt);
        }

        public ActionResult  Ralation()
        {
            return View();
        }

        public ActionResult SelectProductCard(string activityId,string ShopCountProducntID)
        {
            ShopCountProducnt p = null;
            if (string.IsNullOrWhiteSpace(ShopCountProducntID))
            {
                p = new ShopCountProducnt() { ID = Guid.NewGuid().ToString(), ActivityID = activityId };
            }
            else
            {
                p = bll.GetShopCountProducnt(ShopCountProducntID);

            }
            return View(p);
        }
        [HttpPost]
        [ValidateInput(false)]

        public ActionResult SaveProductCard(FormCollection collection)
        {
            ShopCountProducnt p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetShopCountProducnt(collection["ID"]); 
                    p.BindForm<ShopCountProducnt>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopCountProducnt>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    } 
                }
                bll.SaveShopCountProducnt(p);
                if (TempData.ContainsKey("IsSuccess"))
                {
                    TempData.Add("IsSuccess", "保存成功");

                }
                else
                {
                    TempData["IsSuccess"] = "保存成功";
                }
                ModelState.Clear();
                if (collection["IsContinueAdd"] == "1")
                {
                    p = new ShopCountProducnt() {  ActivityID=p.ActivityID}; 
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("SelectProductCard", p);

        }


        public ActionResult AllProduct()
        {

            DataSet dt = bll.GetList();
            return View(dt);

        }

        [HttpPost]

        public ActionResult UpdateOrderNo(string attacheID,string producntID)
        {
            string error = bll.UpdateOrderNo(attacheID, producntID);


             return new  JsonResult(){   JsonRequestBehavior= JsonRequestBehavior.AllowGet, Data =new  {  isSuccess=string.IsNullOrWhiteSpace(error), Msg =error}  };

        }
    }
}
