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
    public class ShopExtendInfoController : BaseControler
    {
        ShopExtendInfoBll bll = new ShopExtendInfoBll();
        //
        // GET: /Admin/ShopExtendInfo/
        public ActionResult Index()
        {

            return View();
        }
       

        
        public string GetList(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum + 1, pagesize, ref recordCount);

            string result = JsonWithDataTable.Serialize(dt);
            result = string.Format("{{\"total\":\"{0}\",\"data\":{1}}}", recordCount, result);
            return result;

        }
        public string GetListForSelecte(int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(pagenum, pagesize, ref recordCount, true);
            string result = JsonWithDataTable.Serialize(dt);
            result = string.Format("{{\"total\":\"{0}\",\"data\":{1}}}", recordCount, result);
            return result;
        }
        public string CheckRepeat(string ID, string categoryID, string RecordStatus, string val )
        {
            return bll.Exit(ID, categoryID, RecordStatus, val ).ToString().ToLower();

        }
        //
        // POST: /Admin/ShopExtendInfo/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(FormCollection collection)
        {
            ShopExtendInfo p = null; ;

            try
            {
                if (collection["RecordStatus"] != "add")
                {
                    p = bll.GetEntity(collection["ID"]);
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
              
                bll.Save(p);
                AddVals(p.ID, p.Vals);
                
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
                    p = new ShopExtendInfo();

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

            }
            return View("Edit", p);
        }

        //
        // GET: /Admin/ShopExtendInfo/Edit/5
        public ActionResult Edit(string id)
        {

            ShopExtendInfo p = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                p = new ShopExtendInfo();
            }
            else
                p = bll.GetEntity(id);
            return View("Edit", p);
        }

        [HttpPost]
        //
        // GET: /Admin/ShopExtendInfo/Delete/5
        public string Delete(string id)
        {
            return bll.Delete(id);
        }

        public ActionResult AddValue(string id)
        {
            ShopExtendInfo extend = bll.GetEntity(id);
            ViewBag.IsGg = false;
            ViewBag.TypeName = "属性";
            ViewBag.AttriId = id;
            if (extend.UsageMode > UsageMode.自定义属性)
            {
                //是规格
                ViewBag.Title = "添加规格值";
                ViewBag.IsGg = true;
                ViewBag.TypeName = "规格";
                ViewBag.Discribe = string.Format(@" <h1>添加【{0}】的规格值</h1>添加供客户可选的规格,如服装类型商品的颜色、尺码。", extend.Name);
            }
            else
            {
                //是属性
                ViewBag.Title = "添加属性值";
                ViewBag.Discribe = string.Format(@" <h1>添加【{0}】的属性值</h1>商品类型是一系列属性的组合，可以用来向客户展示某些商品具有的特有的属性。", extend.Name);
            }
            if (extend.UseAttrImg)
            {
                return View("AddImg");
            }
            else
                return View(); 
        }
        public ActionResult SaveValue(string AttributeId, string Vals)
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
       
        public ActionResult SaveImgValue(string AttributeId, string ImageID, string Note)
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


        [HttpPost] 
        //
        // GET: /Admin/ShopProductInfo/Delete/5
        public string DeleteExtendValue(string id)
        {
            string error;
              bll.DeleteAttrVal(id,out error);
            return error;
        }
         
       
        public string GetListWithSearch(string CategoryID, string Name, string FullName,
            string PTypeID, UsageMode UsageMode,   int pagenum, int pagesize)
        {
            int recordCount = 0;
            System.Data.DataTable dt = bll.GetList(  CategoryID,   Name,   FullName,
              PTypeID,   UsageMode, pagenum, pagesize, ref recordCount );
            string result = JsonWithDataTable.Serialize(dt);
            result = string.Format("{{\"total\":\"{0}\",\"data\":{1}}}", recordCount, result);
            return result;
        }
    }
}
