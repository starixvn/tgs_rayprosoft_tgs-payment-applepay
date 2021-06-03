namespace Tgs.Payment.ApplePay.ViewModels
{
    public class CallbackWithdrawViewModel
    {
        /// <summary>
        ///  1: 成功
        ///-99: 必傳參數錯誤
        /// -3: 查無付款單資料
        /// -2: check驗證錯誤
        /// -1: IP白名單錯誤
        ///  0: 查無此guid 或是商戶帳號狀態非正常, 或是商戶帳號審核非通過
        /// </summary>
        public int result { get; set; }

        /// <summary>
        /// 付款單guid
        /// </summary>
        public string pay_id { get; init; } = default!;

        /// <summary>
        /// 申請狀態 1:提交成功, 2:匹配成功等待付款, 3: 取消訂單, 4: 交易成功, 5: 付款成功等待審核, 6: 交易異常, 7: 付款中
        /// </summary>
        public string pay_state { get; init; } = default!;

        /// <summary>
        /// 付款方式 1: 支付寶, 2: 微信, 3: 銀行卡
        /// </summary>
        public string pay_type { get; init; } = default!;

        /// <summary>
        /// 商戶訂單號
        /// </summary>
        public string pay_tradeno { get; init; } = default!;

        /// <summary>
        /// 付款金額
        /// </summary>
        public decimal pay_money { get; init; }

        /// <summary>
        /// 收款人
        /// </summary>
        public string pay_inname { get; init; } = default!;

        /// <summary>
        /// 收款銀行
        /// </summary>
        public string pay_inbankname { get; init; } = default!;

        /// <summary>
        /// 收款帳號
        /// </summary>
        public string pay_inbanknum { get; init; } = default!;

        /// <summary>
        /// 開戶地
        /// </summary>
        public string pay_location { get; init; } = default!;

        /// <summary>
        /// 開戶網點
        /// </summary>
        public string pay_inbankfullname { get; init; } = default!;

        /// <summary>
        /// 新增日期
        /// </summary>
        public int pay_regdate { get; init; } = default!;

        /// <summary>
        /// 修改日期
        /// </summary>
        public int pay_update { get; init; } = default!;

        /// <summary>
        /// 基本費
        /// </summary>
        public decimal pay_base { get; init; }

        /// <summary>
        /// 費率
        /// </summary>
        public decimal pay_rate { get; init; }

        /// <summary>
        /// 手續費
        /// </summary>
        public decimal pay_fee { get; init; }

        public string check { get; init; } = default!;

        /// <summary>
        /// 驗證參數 加密格式 md5(store_guid + pay_guid + api_key+pay_state+pay_tradeno+pay_money)
        /// </summary>
        public string check2 { get; init; } = default!;
    }
}