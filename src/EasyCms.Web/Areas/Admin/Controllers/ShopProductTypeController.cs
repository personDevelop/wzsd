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
    public class ShopProductTypeController : BaseControler
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


        public string GetAttrList(string ptypeid, bool isGg)
        {
            System.Data.DataTable dt = bll.GetAttrList(host, ptypeid, isGg);
            return JsonWithDataTable.Serialize(dt);
        }

        public ActionResult AddExtend(string id,  string   other)
        {
            AddExtendModel p=   new AddExtendModel() {  ProductTypeID=id, UseMode= other.Phrase<UsageMode>()};
            return View(p);
        }

        public string SaveExtendType(string ID, string ptypeID)
        {
            string e= bll.SaveExtendType(ID, ptypeID);
            if (string.IsNullOrEmpty(e)) e = "添加成功";
                return e;
        }
        public string DeleteExtend(string id)
        {
            return bll.DeleteExtend(id);
           
        }
        


    }
}
