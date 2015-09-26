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


        /// <summary>
        /// 优惠券占总金额总比例
        /// </summary>
        public const string CouponPercent = "0e8dc049-3503-498a-9512-1176ef8da7ac";

        /// <summary>
        /// 购物成长值兑换规则
        /// </summary>

        public const string GrowthValueBuy = "12c70a2b-1252-4b8f-a8f9-d0408165f380";

        /// <summary>
        /// 注册成长值兑换规则
        /// </summary>

        public const string GrowthValueRegist = "d6070e00-f3b1-47ad-a55a-673fb3cec6c5";

        /// <summary>
        /// 登陆成长值兑换规则
        /// </summary>

        public const string GrowthValueLogin = "4f2bc1e9-cd6d-4ad8-bfb2-a16df43b36f3";
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


    public enum OrderStatus
    {
        等待付款 = 0,
        等待商家确认 = 1,
        等待商家发货 = 2,
        已发货 = 3,
        已收货 = 4,
        拒收 = 5,
        作废 = 6,
        发起退货申请 = 7,
        等待商家退货确认 = 8,
        商家不同意退换 = 9,
        商家同意退换 = 10,
        退货完成 = 11,
        商家已收货等待退款 = 12,
        退款完成 = 13,
        申请取消订单 = 14,
        取消订单 = 15,
        完成 = 16,
    }
    public enum QryOrderStatus
    {
        等待付款 = 0,
        等待商家确认 = 1,
        等待商家发货 = 2,
        已发货 = 3,
        已收货 = 4,
        拒收 = 5,
        作废 = 6,
        完成 = 16,
    }
    public enum ShipStatus
    {
        等待商家发货 = 2,
        已发货 = 3,
        完成 = 16
    }

    public enum PayStatus
    {
        未付款,
        已付款
    }

    public enum JFStatus
    {
        在途,
        完成


    }
    public enum JFType
    {
        其他,
        购物,
        注册,
        促销活动
    }


    public enum RuleType
    {
        满额送优惠券,
        满额送积分,
        满额送赠品,
        满额免运费,
        首单送优惠券,
        首单送积分,
        首单送赠品,
        首单免运费,
        注册送优惠券,
        注册送积分,
        包邮


    }

    public enum ActionEnum
    {
        创建订单 = 0,
        付款 = 1,
        发货 = 2,
        签收 = 3,
        申请退货 = 4,
        不同意退货 = 5,
        同意退货 = 6,
        完成退货 = 7,
        完成退款 = 8,
        申请取消订单 = 9,
        取消订单 = 10,
        快递中转 = 11,
        导出订单 = 12,
        拒收 = 13,
        作废 = 99,

    }

    public enum UserStatus
    {
        未激活,
        正常,
        锁定,
        注销

    }
}