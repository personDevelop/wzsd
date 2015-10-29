using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Common;
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

        public static bool GetEncriptContanct(string no, ValidType type, out string error)
        {
            error = string.Empty;
            bool isSuccess = true;
            switch (type)
            {
                case ValidType.手机短信:
                    if (string.IsNullOrWhiteSpace(no))
                    {
                        error = "手机号不能为空";
                        isSuccess = false;
                    }
                    else
                    {
                        if (no.Length != 11)
                        {
                            error = "手机号格式不正确";
                            isSuccess = false;
                        }
                        else
                        {
                            error = "*******" + no.Substring(7);

                        }
                    }
                    break;
                case ValidType.邮箱:
                    if (string.IsNullOrWhiteSpace(no))
                    {
                        error = "邮箱不能为空";
                        isSuccess = false;
                    }
                    else
                    {

                        if (no.IsEmail())
                        {
                            string pri = no.Substring(0, no.IndexOf("@"));
                            switch (pri.Length)
                            {
                                case 1:
                                    error = no;
                                    break;
                                case 2:
                                    error = pri[0] + "*";
                                    break;
                                case 3:
                                    error = pri[0] + "*" + pri[2];
                                    break;
                                case 4:
                                    error = pri[0] + "**" + pri[3];
                                    break;
                                case 5:
                                    error = pri[0] + "***" + pri[4];
                                    break;
                                default:
                                    error = "****" + pri.Substring(4);
                                    break;

                            }
                            error += no.Substring(no.IndexOf("@"));
                        }
                        else
                        {

                            error = "邮箱格式不正确";
                            return false;
                        }
                    }
                    break;
                case ValidType.手机和邮箱:
                default:
                    error = "不支持该方式";
                    isSuccess = false;
                    break;
            }
            return isSuccess;
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


        /// <summary>
        /// 是否记录操作日志
        /// </summary>

        public const string IsRecordOper = "8b433294-8ef0-4479-a8e6-7d0ffb39f3fa";


        /// <summary>
        /// 用户商品评论是否自动生效
        /// </summary>

        public const string IsCommentAuto = "8a16a38e-bad6-4d6e-86d5-7376ff9ad0f5";

        /// <summary>
        /// 没有找到对应功能时是否记录日志 1记录 0不记录
        /// </summary>
        public const string IsRecordNotFundFunc = "1e1b4608-94a9-41b8-9488-1d3f0a84e073";
        public const string FunctionCachKey = "FunctionCachKey";
        public const string FunctionRightCachKey = "FunctionRightCachKey";

        /// <summary>
        /// 订单导出编号
        /// </summary>
        public const string ExportOrder = "ExportOrder";
        /// <summary>
        /// 退货单导出编号
        /// </summary>
        public const string ExportReturnOrder = "ExportReturnOrder";
     



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

    public enum AddOrRemove
    {
        增加,
        减少
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
        商家不同意退换 = 8,
        退货取货中 = 10,
        商家已收货等待退款 = 11,
        退货完成 = 12,
        取消退货 = 13,
        申请取消订单 = 14,
        取消订单处理中 = 15,
        取消订单 = 16,
        完成 = 99,

    }
    public enum QryOrderStatus
    {
        等待付款 = 0,
        等待商家确认 = 1,
        等待商家发货 = 2,
        已发货 = 3,
        拒收 = 5,
        取消订单 = 16,
        完成 = 99,
    }
    public enum ShipStatus
    {
        等待付款 = 0,
        等待商家确认 = 1,
        等待商家发货 = 2,
        已发货 = 3,
        完成 = 99
    }

    public enum PayStatus
    {
        未付款,
        已付款,
        待商家确认
    }

    public enum JFStatus
    {
        在途,
        完成


    }
    public enum JFType
    {
        其他,
        积分, 优惠券, 赠品
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
        包邮,
        系统派送=89,
        使用优惠券 = 90,
        使用积分 = 91,
        其他 = 99


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
        完成取货 = 14,
        修改订单=15,
        评价订单=16,
        作废 = 99,

    }

    public enum UserStatus
    {
        未激活,
        正常,
        锁定,
        注销

    }

    public enum FunctionType
    {
        后台菜单,
        商城导航,
        API,
        其它
    }

    public enum AccessType
    {
        层级模块,
        普通模块,
        MVC功能,
        API功能,
        URL功能,
        其它
    }



    public enum QryLogType
    {
        操作日志,
        异常信息 = 4
    }


    public enum ValidType
    {
        手机短信,
        邮箱,
        手机和邮箱
    }

    public enum ValidCode
    {
        无,//主要是起到验证是否有传递这个值的作用
        注册,
        修改密码,
        忘记密码

    }
    /// <summary>
    /// 单据状态
    /// </summary>
    public enum DjStatus
    {
        草稿,
        生效,
        审批退回,
        删除

    }
    /// <summary>
    /// 顾客单据状态
    /// </summary>
    public enum UserDjStatus
    {
        无,
        等待审核 = 7,
        审批不通过 = 8,
        取货中 = 10,
        等待退款 = 11,
        已完成 = 12,
        已取消 = 13

    }
    /// <summary>
    /// 顾客单据状态
    /// </summary>
    public enum LogisticStatus
    {
        无,
        取货中 = 10,
        取货完成 = 11

    }
    /// <summary>
    /// 顾客单据状态
    /// </summary>
    public enum ReturnMoneyStatus
    {
        无,
        退款中 = 11,
        退款完成 = 12

    }

    public enum ReturnType
    {
        整单退,
        部分退

    }
    public enum ServiceType
    {
        退货,
        换货
    }



    public enum CommentOrder
    {
        无,
        差评,
        中评,
        好评

    }

    public enum ShowType
    {
        无,
        文本,
        数值,
        日期

    }
    public enum AggregateType
    {
        无,
        求和,
        平均,
        最大,
        最小

    }
    public enum AlignType
    {
        无,
        居左,
        居中,
        居右

    }

    public enum SendCouponType
    { 
        全员发放,
        用户等级,
        注册时间,
        购买次数 
    }
}