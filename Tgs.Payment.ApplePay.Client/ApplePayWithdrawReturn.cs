namespace Tgs.Payment.ApplePay
{
    public class ApplePayWithdrawReturn
    {
        /// <summary>
        ///  1: 成功
        ///-99: 必傳参數錯誤
        /// -3: 查無付款單資料
        /// -2: check驗證錯誤
        /// -1: IP白名單錯誤
        ///  0: 查無此guid 或是商戶帳號狀態非正常, 或是商戶帳號審核非通過
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// 付款單guid
        /// </summary>
        public string PayId { get; init; } = default!;

        /// <summary>
        /// 申請狀態 1:提交成功, 2:匹配成功等待付款, 3: 取消訂單, 4: 交易成功, 5: 付款成功等待審核, 6: 交易異常, 7: 付款中
        /// </summary>
        public string PayState { get; init; } = default!;

        /// <summary>
        /// 付款方式 1: 支付寶, 2: 微信, 3: 銀行卡
        /// </summary>
        public string PayType { get; init; } = default!;

        /// <summary>
        /// 商戶訂單號
        /// </summary>
        public string PayTradeNo { get; init; } = default!;

        /// <summary>
        /// 付款金額
        /// </summary>
        public decimal PayMoney { get; init; } = default!;

        /// <summary>
        /// 收款人
        /// </summary>
        public string PayInName { get; init; } = default!;

        /// <summary>
        /// 收款銀行
        /// </summary>
        public string PayInBankName { get; init; } = default!;

        /// <summary>
        /// 收款帳號
        /// </summary>
        public string PayInBankNum { get; init; } = default!;

        /// <summary>
        /// 開戶地
        /// </summary>
        public string PayLocation { get; init; } = default!;

        /// <summary>
        /// 開戶網點
        /// </summary>
        public string PayInBankFullName { get; init; } = default!;

        /// <summary>
        /// 新增日期
        /// </summary>
        public int PayRegDate { get; init; } = default!;

        /// <summary>
        /// 修改日期
        /// </summary>
        public int PayUpdate { get; init; } = default!;

        /// <summary>
        /// 基本費
        /// </summary>
        public decimal PayBase { get; init; }

        /// <summary>
        /// 費率
        /// </summary>
        public decimal PayRate { get; init; }

        /// <summary>
        /// 手續費
        /// </summary>
        public decimal PayFee { get; init; }

        public string Check { get; init; } = default!;

        /// <summary>
        /// 驗證參數 加密格式 md5(store_guid + pay_guid + api_key+pay_state+pay_tradeno+pay_money)
        /// </summary>
        public string Check2 { get; init; } = default!;
    }
}