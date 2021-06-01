using System.Text.Json.Serialization;

namespace Tgs.Payment.ApplePay.ViewModels
{
    public class CallbackDepositViewModel
    {
        /// <summary>
        /// 收款单guid
        /// </summary>
        public string receive_id { get; init; } = default!;
        /// <summary>
        /// 申请状态 1:提交成功, 2:匹配成功等待付款, 3: 取消订单, 4:交易成功
        /// </summary>
        public string receive_state { get; init; } = default!;
        /// <summary>
        /// 收款方式 1: 支付宝, 2: 微信, 3: 银行卡轉银行卡, 4: 支付宝轉银行卡
        /// </summary>
        public string receive_type { get; init; } = default!;
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string receive_tradeno { get; init; } = default!;
        /// <summary>
        /// 收款金额 (小数点第二位)
        /// </summary>
        public string receive_money { get; init; } = default!;
        /// <summary>
        /// 实际入帐金额 (小数点第二位)
        /// </summary>
        public string receive_inmoney { get; init; } = default!;
        /// <summary>
        /// 持卡人 (receive_type = 3 才會回傳)
        /// </summary>
        public string receive_inname { get; init; } = default!;
        /// <summary>
        /// 所属银行 (receive_type = 3 才會回傳)
        /// </summary>
        public string receive_inbankname { get; init; } = default!;
        /// <summary>
        /// 银行卡号 (receive_type = 3 才會回傳)
        /// </summary>
        public string receive_inbanknum { get; init; } = default!;
        /// <summary>
        /// 开户地 (receive_type = 3 才會回傳)
        /// </summary>
        public string receive_location { get; init; } = default!;
        /// <summary>
        /// 开户网点 (receive_type = 3 才會回傳)
        /// </summary>
        public string receive_inbankfullname { get; init; } = default!;
        /// <summary>
        /// 收款qrcode連結
        /// </summary>
        public string receive_qrcode_url { get; init; } = default!;
        /// <summary>
        /// 转帐银行
        /// </summary>
        public string receive_trans_bankname { get; init; } = default!;
        /// <summary>
        /// 转帐姓名
        /// </summary>
        public string receive_trans_name { get; init; } = default!;
        /// <summary>
        /// 转帐卡号
        /// </summary>
        public string receive_trans_banknum { get; init; } = default!;
        /// <summary>
        /// 支行名称
        /// </summary>
        public string receive_trans_branchname { get; init; } = default!;
        /// <summary>
        /// 新增日期
        /// </summary>
        public string receive_regdate { get; init; } = default!;
        /// <summary>
        /// 修改日期
        /// </summary>
        public string receive_update { get; init; } = default!;
        /// <summary>
        ///  1: 成功
        ///-99: 必传参数错误
        /// -3: 查无收款单资料
        /// -2: check验证错误
        /// -1: IP白名单错误
        ///  0: 查无此guid 或是商户帐号状态非正常, 或是商户帐号审核非通过
        /// </summary>
        public string result { get; init; } = default!;
        public string check { get; init; } = default!;
        public string check2 { get; init; } = default!;
    }
}