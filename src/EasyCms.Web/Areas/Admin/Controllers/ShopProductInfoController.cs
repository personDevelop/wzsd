using EasyCms.Business;
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
                List<ShopProductSKU> listSku = new List<ShopProductSKU>();
                List<ShopProductSKUInfo> listSkuInfo = new List<ShopProductSKUInfo>();
                Dictionary<int, string> rowSpeckID = new Dictionary<int, string>();

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


                int i = bll.Save(p, list, listAttri, listSku, listSkuInfo);
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
        [HttpPost]
        //
        // GET: /Admin/ShopProductInfo/Delete/5
        public string IsSJOperator(string id , int opcode)
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
    }
}
