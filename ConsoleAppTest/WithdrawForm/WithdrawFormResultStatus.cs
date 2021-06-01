using System.ComponentModel;

namespace ConsoleAppTest.WithdrawForm
{
    public enum WithdrawFormResultStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 1,

        /// <summary>
        /// 必傳參數錯誤
        /// </summary>
        [Description("必傳參數錯誤")]
        RequiredParametersError = -99,

        /// <summary>
        /// 同時寫入錯誤
        /// </summary>
        [Description("同時寫入錯誤")]
        SimultaneouslyWriteError = -98,

        /// <summary>
        /// 不可新增非正整數的金額
        /// </summary>
        [Description("不可新增非正整數的金額")]
        CanNotInsertNonPositiveMoney = -12,

        /// <summary>
        /// 餘額限制已達上限
        /// </summary>
        [Description("餘額限制已達上限")]
        BalanceMaxLimit = -11,

        /// <summary>
        /// 商戶無交易權限
        /// </summary>
        [Description("商戶無交易權限")]
        StoreNoTradeAuth = -10,

        /// <summary>
        /// 帳戶末5碼長度錯誤
        /// </summary>
        [Description("帳戶末5碼長度錯誤")]
        AccountLastFiveLengthError = -9,

        /// <summary>
        /// 超出單日總限額限制
        /// </summary>
        [Description("超出單日總限額限制")]
        OverDailySumLimit = -8,

        /// <summary>
        /// 未開放此支付方式 1: 支付寶, 2: 微信
        /// </summary>
        [Description("未開放此支付方式 1: 支付寶, 2: 微信")]
        NonPayMethod = -7,

        /// <summary>
        /// 無可接單交易員
        /// </summary>
        [Description("無可接單交易員")]
        NoAcceptOrderTrader = -6,

        /// <summary>
        /// 金額範圍有誤
        /// </summary>
        [Description("金額範圍有誤")]
        MoneyRangeError = -5,

        /// <summary>
        /// 系統出錯，請重新輸入
        /// </summary>
        [Description("系統出錯，請重新輸入")]
        SystemError = -4,

        /// <summary>
        /// 商戶代理有誤，請聯繫客服
        /// </summary>
        [Description("商戶代理有誤，請聯繫客服")]
        StoreAgentError = -3,

        /// <summary>
        /// check驗證錯誤
        /// </summary>
        [Description("check驗證錯誤")]
        CheckValidateError = -2,

        /// <summary>
        /// IP白名單錯誤
        /// </summary>
        [Description("IP白名單錯誤")]
        IpWhiteListError = -1,

        /// <summary>
        /// 查無此guid 或是商戶帳號狀態非正常, 或是商戶帳號审核非通过
        /// </summary>
        [Description("查無此guid 或是商戶帳號狀態非正常, 或是商戶帳號审核非通过")]
        NoStoreGuid = 0
    }
}