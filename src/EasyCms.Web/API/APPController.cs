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


using System.Web.Hosting;
namespace EasyCms.Web.API
{
    public class APPController : ApiController
    {
        string host
        {
            get
            {

                string url = this.Url.Request.RequestUri.Authority + RequestContext.VirtualPathRoot;
                if (!url.StartsWith("http://")) url = "http://" + url;
                return url;
            }
        }
        public HttpResponseMessage GetNews(int id = 1)
        {
            try
            {
                //获取page  
                int page = id;
                //新闻id，定标题，简介，缩略图，新闻url 
                DataTable dt = new NewsInfoBll().GetAppNews(page, host);
                return dt.Format();

            }
            catch (Exception ex)
            {
                return ex.Format();

            }

        }

        public HttpResponseMessage GetNew(string id = "")
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return "此新闻已被删除或屏蔽".FormatError();
                }
                else
                {
                    NewsInfo news = new NewsInfoBll().GetEntity(id);
                    if (news.Description == null)
                    {
                        news.Description = string.Empty;
                    }
                    string result = JsonWithDataTable.Serialize(news);
                    return result.FormatSuccess();
                }

            }
            catch (Exception ex)
            {

                return ex.Format();
            }


        }

        /// <summary>
        /// id为空 则获取一级分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetChildCategory(string id = "")
        {
            try
            {

                DataTable dt = new ShopCategoryBll().GetAppEntity(id, host);
                return dt.Format();
            }
            catch (Exception ex)
            {

                return ex.Format();
            }

        }
        public HttpResponseMessage GetProduct(string id = "")
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);


            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return "传递的参数不能为空".FormatError();
                }
                else
                {
                    ShopSaleProductInfo p = new ShopProductInfoBll().GetSaleEntity(id, host);
                    if (p == null)
                    {
                        return "此商品已下架".FormatError();

                    }
                    else
                    {


                       
                        return p.FormatObj();
                    }
                }
            }
            catch (Exception ex)
            {

                return ex.Format();
            }

        }
        public HttpResponseMessage GetProductsByCategory(string id = "", int pageIndex = 1, string other = "")
        {
            try
            {
                var resp = new HttpResponseMessage(HttpStatusCode.OK);

                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                if (string.IsNullOrEmpty(id))
                {
                    return "商品类型不能为空".FormatError();

                }
                else
                {
                    int pagecount = 0, recordCount = 0;
                    DataTable dt = new ShopProductInfoBll().GetProductsByCategory(id, pageIndex, other, host, ref pagecount, ref recordCount);
                    return dt.Format();

                }
            }
            catch (Exception ex)
            {
                return ex.Format();

            }

        }

        public HttpResponseMessage GetProductsByWhere()
        {
            try
            {

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


                    where = ShopProductCategory._.CategoryID.In(classcode);


                }
                if (string.IsNullOrWhiteSpace(productName))
                {
                    where = where && ShopProductInfo._.Name.Contains(productName);
                }
                where = where && new WhereClip(" not EXISTS (select 1 from ShopProductStationMode where StationMode=" + stationMode + "  and ShopProductInfo.ID=ProductID)");
                int pagecount = 0, recordCount = 0;

                System.Data.DataTable dt = new ShopProductInfoBll().GetProductByWhere(where, pageNum, host, ref pagecount, ref   recordCount);
                return new
                {
                    PageIndex = pageNum,
                    RecordCount = dt.Rows.Count,
                    TotalPageCount = pagecount,
                    TotalRecourdCount = recordCount,
                    Data = dt
                }.FormatObj();

            }
            catch (Exception ex)
            {

                return ex.Format();
            }
        }

        public HttpResponseMessage PostTj([FromBody] ShopProductStationMode sm)
        {


            try
            {

                sm.ID = Guid.NewGuid().ToString();
                sm.StationModeName = ((StationMode)sm.StationMode).ToString();
                int dt = new ShopProductInfoBll().SaveStation(sm);
                string result = JsonWithDataTable.Serialize(sm);
                return result.FormatSuccess();

            }
            catch (Exception ex)
            {
                return ex.Format();

            }
        }
        [HttpGet]
        public HttpResponseMessage DeleteTj(string id)
        {


            try
            {

                int dt = new ShopProductInfoBll().DeleteStation(id);
                return "成功".FormatSuccess();

            }
            catch (Exception ex)
            {
                return ex.Format();

            }
        }

        public HttpResponseMessage GetProductsByStation()
        {
            try
            {

                int id = 0, pageIndex = 1, pagesize = 20;
                string StationModestr = Request.GetQueryValue("StationMode");
                int.TryParse(StationModestr, out id);
                string pagenumstr = Request.GetQueryValue("pagenum");
                string pagesizestr = Request.GetQueryValue("pagesize");
                if (!int.TryParse(pagenumstr, out pageIndex))
                {
                    pageIndex = 1;
                }
                if (!int.TryParse(pagesizestr, out pagesize))
                {
                    pagesize = 20;
                }
                int pagecount = 0, recordCount = 0;
                DataTable dt = new ShopProductInfoBll().GetProductsByStation(id, pageIndex, pagesize, host, ref pagecount, ref recordCount);

                return new { PageIndex = pageIndex, RecordCount = dt.Rows.Count, TotalPageCount = pagecount, TotalRecourdCount = recordCount, Data = dt }.FormatObj();
            }
            catch (Exception ex)
            {
                return ex.Format();

            }
        }

        public HttpResponseMessage GetProductsByMutilStation(string id, int pageIndex = 5)
        {
            try
            {
                string error = string.Empty;
                DataSet ds = new ShopProductInfoBll().GetProductsByMutilStation(id, pageIndex, host, out   error);
                if (ds == null) return error.FormatError();
                return ds.FormatObj();
            }
            catch (Exception ex)
            {
                return ex.Format();

            }
        }

        public HttpResponseMessage GetGateway()
        {
            try
            {

                string result = JsonWithDataTable.Serialize(GatawayConfig.GetAllGataway());
                return result.FormatSuccess();
            }
            catch (Exception ex)
            {
                return ex.Format();

            }

        }

        public HttpResponseMessage GetGg(string id)
        {

            string err = string.Empty;
            List<ShopExtendWithValue> ds = new ShopProductInfoBll().GetProductGgInfo(id, out err);
            if (string.IsNullOrWhiteSpace(err))
                return ds.FormatObj();
            else return err.FormatError();
        }
        public HttpResponseMessage GetSku(string id)
        {

            string err = string.Empty;
            DataTable dt = new ShopProductInfoBll().GetProductSkuInfo(id, out err);
            if (string.IsNullOrWhiteSpace(err))
                return dt.Format();
            else return err.FormatError();
        }
        public HttpResponseMessage GetRegistAgreement()
        {
            string RA = new ParameterInfoBll().GetRegistAgreement();
            return RA.FormatSuccess();
        }
    }
}
