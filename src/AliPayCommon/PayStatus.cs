using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliPayCommon
{
    /// <summary>
    /// 支付状态
    /// </summary>
    public enum AliPayStatus
    {
        订单支付失败 = 4000,
        用户中途取消 = 6001,
        网络连接出错 = 6002,
        正在处理中 = 8000,
        支付成功 = 9000,

    }
    /// <summary>
    /// 交易状态
    /// </summary>
    public enum AliTradeStatus
    {
        /// <summary>
        /// WAIT_BUYER_PAY
        /// </summary>
        WAIT_BUYER_PAY,
        /// <summary>
        ///1.在指定时间段内未支付时关闭的交易；
        ///2.在交易完成全额退款成功时关闭的交易。
        /// </summary>
        TRADE_CLOSED,
        /// <summary>
        /// 交易成功，且可对该交易做操作，如：多级分润、退款等。
        /// </summary>
        TRADE_SUCCESS,
        /// <summary>
        /// 交易成功且结束，即不可再做任何操作。
        /// </summary>
        TRADE_FINISHED
    }
    /// <summary>
    /// 退款状态
    /// </summary>
    public enum AliReturnStatus
    {
        /// <summary>
        /// 退款成功：全额退款情况：trade_status= TRADE_CLOSED，而
        ///refund_status=REFUND_SUCCESS
        ///非全额退款情况：trade_status= TRADE_SUCCESS，
        ///而 refund_status=REFUND_SUCCESS
        /// </summary>
        REFUND_SUCCESS,

        /// <summary>
        /// 退款关闭
        /// </summary>
        REFUND_CLOSED
    }

}
