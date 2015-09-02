using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCms.Model
{
    public class StaticValue
    {
        /// <summary>
        /// 旅游分类ID
        /// </summary>
        public const string TravelCategoryID = "";
        /// <summary>
        /// 用户注册协议ID
        /// </summary>
        public const string RegistAgreementID = "60544642-c2dd-411b-acdf-5ba2ca6c92b9";
        public static string GeneratoRandom()
        {
            Random r = new Random();
            string temMsg = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                temMsg += r.Next(0, 9);
            }
            return temMsg;
        }
        /// <summary>
        /// 促销规则
        /// </summary>
        public const string RuleType = "84e88925-afdb-4385-8622-acac8e689dee";

        /// <summary>
        /// 促销规则
        /// </summary>
        public const string CouponType = "482d62aa-5302-4773-b719-ae39acf012a5";

    }


    public enum StationMode
    {
        首页Bar轮询,
        推荐商品,
        热卖商品,
        特价商品,
        最新商品,
        畅销精品,
        分类首页推荐
    }
    public enum ShopBuyType
    {
        普通购物,
        赠品,
        套餐,
        团购,
        秒杀
    }

    public enum ShopSaleStatus
    {
        下架,
        上架,
        上架审批,
        上架退回
    }

    public enum ValidEnum
    { 
        有效,
        无效

    
    }
}