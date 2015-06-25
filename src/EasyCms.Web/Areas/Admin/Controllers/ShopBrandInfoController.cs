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
    public class ShopBrandInfoController : Controller
    {
        ShopBrandInfoBll bll = new ShopBrandInfoBll();
        //
        // GET: /Admin/ShopBrandInfo/
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
        public string CheckRepeat(string ID,   string RecordStatus, string val, bool IsCode)
        {
            return bll.Exit(ID,  RecordStatus, val, IsCode).ToString().ToLower();

        } 

        //
        // POST: /Admin/ShopBrandInfo/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopBrandInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
                    p.BindForm<ShopBrandInfo>(collection);
                }
                else
                {
                    // TODO: Add insert logic here
                    p = collection.Bind<ShopBrandInfo>();

                }

                if (p.RecordStatus == Sharp.Common.StatusType.add)
                {
                    if (string.IsNullOrWhiteSpace(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                    }
                   
                }
                //获取商品类型
                List<string> producTypeList = new List<string>();
                foreach (string item in collection.Keys)
                {
                    if (item.StartsWith("spt"))
                    {
                        string ptID = item.Substring(3);
                        if (!string.IsNullOrWhiteSpace(ptID))
                        {
                            producTypeList.Add(ptID);
                        }
                            
                    }
                }
                bll.Save(p, producTypeList);
                TempData.Add("IsSuccess", "保存成功");
                ModelState.Clear();


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/ShopBrandInfo/Edit/5
        public ActionResult Edit(string id)
        {

            ShopBrandInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopBrandInfo();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ShopBrandInfo/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }
    }
}
