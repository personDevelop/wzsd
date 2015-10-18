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
            int goodCount = 0;
            int badCount = 0;
            int middleCount = 0;
            DataTable dt = new ShopProductReviewsBll().GetListByProductID(id, pageIndex, 20, ref recordCount,ref goodCount,ref middleCount,ref badCount);

            int goodPercent = (int)(goodCount * 100 / recordCount);
            int googNum = 0;
            if (goodPercent == 100)
            {
                googNum = 5;
            }
            else if (goodPercent >= 80)
            {
                googNum = 4;
            }
            else if (goodPercent >= 60)
            {
                googNum = 3;
            }
            else if (goodPercent >= 40)
            {
                googNum = 2;
            }
            else
            {
                googNum = 1;
            }


            return new
            {
                PageIndex = pageIndex,
                RecordCount = dt.Rows.Count,
                TotalPageCount = 0,
                TotalRecourdCount = recordCount,//总评论个数
                GoodPercent = goodPercent,//好评率
                GoodNum = googNum,//好评星级 1-5
                GoodCount=goodCount,//好评个数
                MiddleCount = middleCount,//中评个数
                BadCount = badCount,//差评个数
                Data = dt
            }
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

                    new ShopProductInfoBll().AccCommentCount(comment.ProductId, 1);
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