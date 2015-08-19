using EasyCms.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyCms.Web.Common;

namespace EasyCms.Web.API
{
    public class ShopProductApiController : BaseAPIControl
    {

        public HttpResponseMessage GetSkuByProductID(string id)
        {

            string err = string.Empty;
            DataTable dt = new ShopProductInfoBll().GetSkuByProductID(id, out err);
            if (string.IsNullOrWhiteSpace(err))
                return dt.Format();
            else return err.FormatError();
        }

        public HttpResponseMessage GetProduct()
        {
            string pagesizeStr = Request.GetQueryValue("pagesize");
            string pageIndexStr = Request.GetQueryValue("pagenum");
            string err = string.Empty;
            int pageIndex, pagesize;
            if (int.TryParse(pageIndexStr, out pageIndex))
            {

            }
            pageIndex += 1;
            if (int.TryParse(pagesizeStr, out pagesize))
            {

            }
            else
            { pagesize = 20; }
            int pagecount = 0, recordCount = 0;
            DataTable dt = new ShopProductInfoBll().GetProduct(pageIndex, pagesize, ref pagecount, ref recordCount);

            return new { PageIndex = pageIndex, RecordCount = dt.Rows.Count, TotalPageCount = pagecount, TotalRecourdCount = recordCount, Data = dt }.FormatObj();

        }
    }
}
