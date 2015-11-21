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
using EasyCms.Model.ViewModel;
namespace EasyCms.Web.API
{
    public class APPController : BaseAPIControl
    {

        public HttpResponseMessage GetNews(int id = 1)
        {

            //获取page  
            int page = id;
            //新闻id，定标题，简介，缩略图，新闻url 
            DataTable dt = new NewsInfoBll().GetAppNews(page, host);
            return dt.Format();



        }

        public HttpResponseMessage GetNew(string id = "")
        {

            if (string.IsNullOrEmpty(id))
            {
                return "此新闻已被删除或屏蔽".FormatError();
            }
            else
            {
                NewsInfo news = new NewsInfoBll().GetEntity(id, host);
                if (news.Description == null)
                {
                    news.Description = string.Empty;
                }
                string result = JsonWithDataTable.Serialize(news);
                return result.FormatSuccess();
            }




        }

        /// <summary>
        /// id为空 则获取一级分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage GetChildCategory(string id = "")
        {


            DataTable dt = new ShopCategoryBll().GetAppEntityList(id, host);
            return dt.Format();


        }
        public HttpResponseMessage GetProduct(string id = "")
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);



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

        public HttpResponseMessage GetProductUrl(string id = "")
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);



            if (string.IsNullOrEmpty(id))
            {
                return "传递的参数不能为空".FormatError();
            }
            else
            {
                ProductLink p = new ShopProductInfoBll().GetProductLink(id, host);
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
        public HttpResponseMessage GetProductsByCategory(string id = "", int pageIndex = 1, string other = "")
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

                return new { PageIndex = pageIndex, RecordCount = dt.Rows.Count, TotalPageCount = pagecount, TotalRecourdCount = recordCount, Data = dt }.FormatObj();

            }


        }

        public HttpResponseMessage GetProductsByWhere()
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

        public HttpResponseMessage PostTj([FromBody] ShopProductStationMode sm)
        {




            sm.ID = Guid.NewGuid().ToString();
            sm.StationModeName = ((StationMode)sm.StationMode).ToString();

            int dt = new ShopProductInfoBll().SaveStation(sm);
            string result = JsonWithDataTable.Serialize(sm);
            return result.FormatSuccess();


        }
        [HttpGet]
        public HttpResponseMessage DeleteTj(string id)
        {



            int dt = new ShopProductInfoBll().DeleteStation(id);
            return "成功".FormatSuccess();


        }

        public HttpResponseMessage GetProductsByStation()
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

        public HttpResponseMessage GetProductsByMutilStation(string id, int pageIndex = 5)
        {
            string error = string.Empty;
            DataSet ds = new ShopProductInfoBll().GetProductsByMutilStation(id, pageIndex, host, out   error);
            if (ds == null) return error.FormatError();
            return ds.FormatObj();

        }

        public HttpResponseMessage GetProductsByCategoryStation(string id, int pageIndex = 1, int other = 5)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                return "分类不能为空".FormatError();
            }
            int pagecount = 0, recordCount = 0;
            DataTable dt = new ShopProductInfoBll().GetProductsByStation(id, pageIndex, other, host, ref pagecount, ref recordCount);

            return new { PageIndex = pageIndex, RecordCount = dt.Rows.Count, TotalPageCount = pagecount, TotalRecourdCount = recordCount, Data = dt }.FormatObj();

        }
        public HttpResponseMessage GetGateway()
        {


            return GatawayConfig.GetAllGataway().FormatObj();



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
            string RA = new ParameterInfoBll().GetParaValue(StaticValue.RegistAgreementID);
            return RA.FormatSuccess();
        }
        public HttpResponseMessage GetAbout()
        {
            string RA = new ParameterInfoBll().GetParaValue(StaticValue.About);
            return RA.FormatSuccess();
        }
        public HttpResponseMessage GetContact()
        {
            string RA = new ParameterInfoBll().GetParaValue(StaticValue.Contact);
            return RA.FormatSuccess();
        }
        public HttpResponseMessage GetBuyFlow()
        {
            string RA = new ParameterInfoBll().GetParaValue(StaticValue.BuyFlow);
            return RA.FormatSuccess();
        }
        public HttpResponseMessage GetReturnFlow()
        {
            string RA = new ParameterInfoBll().GetParaValue(StaticValue.ReturnFlow);
            return RA.FormatSuccess();
        }
        public HttpResponseMessage GetPara(string id)
        {
            string RA = new ParameterInfoBll().GetParaValue(id);
            return RA.FormatSuccess();
        }
        [HttpPost]
        public HttpResponseMessage CatchException([FromBody] AppException exception)
        {
            string userid = "";
            if (!string.IsNullOrWhiteSpace(exception.Token))
            {
                ManagerUserInfo user = CmsSessionExtend.GetAccount(exception.Token);// LoginModel.GetCachUserInfo(exception.Token);
                if (user != null)
                {
                    userid = user.ID;
                }

            }
            new LogBll().WriteException(exception, userid);
            return "操作成功".FormatSuccess();
        }


        public HttpResponseMessage GetCach(int id)
        {

            if (id == 0)
            {
                return CacheContainer.GetCachCount().FormatObj();
            }
            else
            {
                int count = CacheContainer.GetCachCount();
                System.Collections.Hashtable hs = CacheContainer.GetMemoryCache();
                string str = "数量：" + count + Environment.NewLine;
                foreach (var item in hs.Keys)
                {
                    str += item.ToString() + ":" + hs[item].ToString() + Environment.NewLine;
                }
                return str.FormatObj();
            }

        }


        public HttpResponseMessage GetTravel()
        {
            string travalCategoryID = new ParameterInfoBll().GetParaValue(StaticValue.Traval);
            if (string.IsNullOrWhiteSpace(travalCategoryID))
            {

                return "还没有设置旅游频道系统参数".FormatError();
            }
            else
            {
                DataTable dt = new ShopCategoryBll().GetAppEntity(travalCategoryID, host);
                return dt.Format();
            }
        }
        public HttpResponseMessage GetTravleList(int id, string pageIndex)
        {
            string travalCategoryID = new ParameterInfoBll().GetParaValue(StaticValue.Traval);
            if (string.IsNullOrWhiteSpace(travalCategoryID))
            {

                return "还没有设置旅游频道系统参数".FormatError();
            }
            else
            {
                if (id == 0)
                {
                    id = 1;
                }

                int pagecount = 0, recordCount = 0;
                DataTable dt = new ShopProductInfoBll().GetTravalList(travalCategoryID, id, pageIndex, host, ref pagecount, ref recordCount);

                return new { PageIndex = pageIndex, RecordCount = dt.Rows.Count, TotalPageCount = pagecount, TotalRecourdCount = recordCount, Data = dt }.FormatObj();


            }
        }
    }
}
