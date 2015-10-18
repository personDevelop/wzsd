using EasyCms.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyCms.Web.Common;
using EasyCms.Model;
using Sharp.Common;
namespace EasyCms.Web.API
{
    public class ShopCommentApiController : BaseAPIControl
    {
        // GET api/<controller>
        public HttpResponseMessage Get(string id, int pageIndex = 1)
        {
            int recordCount = 0;
            DataTable dt = new ShopProductReviewsBll().GetListByProductID(id, pageIndex, 20, ref recordCount);
            return new { PageIndex = pageIndex, RecordCount = dt.Rows.Count, TotalPageCount = 0, TotalRecourdCount = recordCount, Data = dt }
                .FormatObj();

        }

        [HttpPost]
        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]ShopProductReviews comment)
        {
            try
            {
                comment.ID = Guid.NewGuid().ToString();
                string isAutoSX = new ParameterInfoBll().GetValue(StaticValue.IsCommentAuto);
                if (isAutoSX == "1")
                {
                    comment.Status = (int)DjStatus.生效;
                }
                else
                { comment.Status = (int)DjStatus.草稿; }
                comment.UserId = Request.GetAccountID();
                comment.CreatedDate = DateTime.Now;
                new ShopProductReviewsBll().Save(comment);
                if (string.IsNullOrWhiteSpace(comment.ProductId))
                {
                 
                    new ShopProductInfoBll().AccCommentCount(comment.ProductId,1);
                }
                return "评论成功".FormatSuccess();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

    }
}