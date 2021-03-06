﻿using EasyCms.Business;
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
        public HttpResponseMessage Get(string id, int pageIndex = 1,int other=0)
        {
            int recordCount = 0;
            int goodCount = 0;
            int badCount = 0;
            int middleCount = 0;
            DataTable dt = new ShopProductReviewsBll().GetListByProductID(id,other, pageIndex, 20, ref recordCount, ref goodCount, ref middleCount, ref badCount);

            int goodPercent = 0;
            if (recordCount>0)
            {
                goodPercent = (int)(goodCount * 100 / recordCount);
            }  
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
                GoodCount = goodCount,//好评个数
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
                    comment.Status =  DjStatus.生效;
                }
                else
                { comment.Status =  DjStatus.未审核; }
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

          [HttpPost]
        public HttpResponseMessage GetCommentProduct([FromBody]CommentModel cm)
        {
            int recordCount = 0;
            string orderID = cm.OrderId;//空查所有，非空查当前订单下所有商品
            int state = cm.state;//0查所有，1查待评论的，2.查已评论的
            DataTable dt = new ShopProductReviewsBll().GetCommentProduct(host,Request.GetAccountID(), orderID, state, cm.pageIndex, 20, ref recordCount);

            return new
            {
                PageIndex = cm.pageIndex,
                RecordCount = dt.Rows.Count,
                TotalPageCount = 0,
                TotalRecourdCount = recordCount,
                Data = dt
            }.FormatObj();
        }

        public class CommentModel
        {
            /// <summary>
            /// 空查所有，非空查当前订单下所有商品
            /// </summary>
            public string OrderId { get; set; }
            /// <summary>
            /// 页数
            /// </summary>
            public int pageIndex { get; set; }

            /// <summary>
            /// 0查所有，1查待评论的，2.查已评论的
            /// </summary>
            public int state { get; set; }
    
    }
    }
}