namespace Tgs.Payment.ApplePay
{
    public class ApplePayWithdrawResponse
    {
        /// <summary>
        ///   1: 成功
        /// -99: 必傳參數錯誤
        /// -98: 同時寫入錯誤
        /// -97: 格式錯誤 inname 不得為空(需有中文or英文)
        /// -96: 重複訂單號
        /// -95: 訂單優先度最大上限為9999；最小為0
        ///  -6: 商戶無交易權限
        ///  -5: 金額範圍有誤
        ///  -4: 餘額不足
        ///  -2: check驗證錯誤
        ///  -1: IP白名單錯誤
        ///   0: 查無此guid 或是商戶帳號狀態非正常, 或是商戶帳號審核非通過
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// 付款單guid (result: 1 才會傳)
        /// </summary>
        public string? PayId { get; set; }
    }
}