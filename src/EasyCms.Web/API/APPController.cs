using EasyCms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Sharp.Common;
using System.Data;
using EasyCms.Business;
using System.Text;
using System.Web.Http;
using EasyCms.Web.Common;

namespace EasyCms.Web.API
{
    public class APPController : ApiController
    {
        string host { get { return this.Url.Request.RequestUri.Authority + RequestContext.VirtualPathRoot; } }
        public HttpResponseMessage GetNews(int id = 1)
        {
            //获取page  
            int page = id;
            //新闻id，定标题，简介，缩略图，新闻url 
            DataTable dt = new NewsInfoBll().GetAppNews(page, host);

            string result = JsonWithDataTable.Serialize(dt);
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;

        }

        public HttpResponseMessage GetNew(string id = "")
        {

            var resp = new HttpResponseMessage(HttpStatusCode.OK);


            if (string.IsNullOrEmpty(id))
            {
                resp.Content = new StringContent("此新闻已被删除或屏蔽", Encoding.UTF8, "text/plain");
            }
            else
            {
                NewsInfo news = new NewsInfoBll().GetEntity(id);
                if (news.Description == null)
                {
                    news.Description = string.Empty;
                }
                string result = JsonWithDataTable.Serialize(news);
                resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            }
            return resp;


        }

        /// <summary>
        /// id为空 则获取一级分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetChildCategory(string id = "")
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            DataTable dt = new ShopCategoryBll().GetAppEntity(id);
            string result = JsonWithDataTable.Serialize(dt);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;

        }
        public HttpResponseMessage GetProduct(string id = "")
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);


            if (string.IsNullOrEmpty(id))
            {
                resp.Content = new StringContent("此商品已下架", Encoding.UTF8, "text/plain");
            }
            else
            {
                ShopProductInfo p = new ShopProductInfoBll().GetSaleEntity(id);
                if (p == null)
                {
                    resp.Content = new StringContent("此商品已下架", Encoding.UTF8, "text/plain");
                }
                else
                {


                    string result = JsonWithDataTable.Serialize(p);
                    resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
                }
            }
            return resp;
        }
        public HttpResponseMessage GetProductsByCategory(string id = "", int pageIndex = 1)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrEmpty(id))
            {
                resp.Content = new StringContent("商品类型不能为空", Encoding.UTF8, "text/plain");
            }
            else
            {
                int pagecount = 0, recordCount = 0;
                DataTable dt = new ShopProductInfoBll().GetProductsByCategory(id, pageIndex, ref pagecount, ref recordCount);
                string result = JsonWithDataTable.Serialize(new { PageIndex = pageIndex, RecordCount = dt.Rows.Count, TotalPageCount = pagecount, TotalRecourdCount = recordCount, Data = dt });
                resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");

            }
            return resp;
        }

        public HttpResponseMessage GetProductsByWhere()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            string categoryID = Request.GetQueryValue("categoryID");
            string productName = Request.GetQueryValue("ProductName");
            string pageNumStr = Request.GetQueryValue("pagenum");
            string stationMode = Request.GetQueryValue("stationMode");
            int pageNum = 1;

            if (int.TryParse(pageNumStr, out pageNum))
            {

            }
            else pageNum = 1;
            WhereClip where = new WhereClip();
            if (!string.IsNullOrWhiteSpace(categoryID))
            {
                string ClassCode = new ShopCategoryBll().GetClassCode(categoryID);
                string[] classcode = ClassCode.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (classcode.Length > 1)
                {
                    where = ShopProductCategory._.CategoryID.In(classcode);
                }
                else
                {
                    where = ShopProductCategory._.CategoryID == categoryID;
                }

            }
            if (string.IsNullOrWhiteSpace(productName))
            {
                where = where && ShopProductInfo._.Name.Contains(productName);
            }
            where = where && new WhereClip(" not EXISTS (select 1 from ShopProductStationMode where StationMode=" + stationMode + "  and ShopProductInfo.ID=ProductID)");
            int pagecount = 0, recordCount = 0;

            System.Data.DataTable dt = new ShopProductInfoBll().GetProductByWhere(where, pageNum, ref pagecount, ref   recordCount);

            string result = JsonWithDataTable.Serialize(new { PageIndex = pageNum, RecordCount = dt.Rows.Count, TotalPageCount = pagecount, TotalRecourdCount = recordCount, Data = dt });
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }

        public HttpResponseMessage PostTj([FromBody] ShopProductStationMode sm)
        {


            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            sm.ID = Guid.NewGuid().ToString();
            sm.StationModeName = ((StationMode)sm.StationMode).ToString();
            int dt = new ShopProductInfoBll().SaveStation(sm);

            string result = JsonWithDataTable.Serialize(sm);
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }
        [HttpGet]
        public HttpResponseMessage DeleteTj(string id)
        {


            var resp = new HttpResponseMessage(HttpStatusCode.OK);


            int dt = new ShopProductInfoBll().DeleteStation(id);

            string result = JsonWithDataTable.Serialize("成功");
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");
            return resp;
        }

        public HttpResponseMessage GetProductsByStation()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);

            int id = 0, pageIndex = 1, pagesize = 20;
            string StationModestr = Request.GetQueryValue("StationMode");
            int.TryParse(StationModestr, out id);
            string pagenumstr = Request.GetQueryValue("pagenum");
            string pagesizestr = Request.GetQueryValue("pagesize");
            int.TryParse(pagenumstr, out pageIndex);
            int.TryParse(pagesizestr, out pagesize);
            //string pagesizestr = Request.GetQueryValue("pagesize");
            //int.TryParse(pagenumstr, out pageIndex);

            pageIndex += 1;


            int pagecount = 0, recordCount = 0;
            DataTable dt = new ShopProductInfoBll().GetProductsByStation(id, pageIndex, pagesize, ref pagecount, ref recordCount);
            string result = JsonWithDataTable.Serialize(new { PageIndex = pageIndex, RecordCount = dt.Rows.Count, TotalPageCount = pagecount, TotalRecourdCount = recordCount, Data = dt });
            resp.Content = new StringContent(result, Encoding.UTF8, "text/plain");


            return resp;
        }
    }
}
