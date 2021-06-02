using System.Text.Json.Serialization;

namespace Tgs.Payment.ApplePay
{
    public class ApplePayDepositResponse
    {
        /// <summary>
        ///   1: 成功
        /// -99: 必傳參數錯誤
        /// -98: 同时寫入錯誤
        /// -12: 不可新增非正整数的金額
        /// -11: 餘額限制已達上限
        /// -10: 商戶無交易權限
        ///  -9: 帳戶末5碼長度錯誤
        ///  -8: 超出單日總限額限制
        ///  -7: 未開放此支付方式 1: 支付寶, 2: 微信
        ///  -6: 無可接單交易員
        ///  -5: 金額範圍有誤
        ///  -4: 系統出錯，請重新輸入
        ///  -3: 商戶代理有誤，請聯繫客服
        ///  -2: check驗證錯誤
        ///  -1: IP白名單錯誤
        ///   0: 查無此guid 或是商戶帳號狀態非正常, 或是商戶帳號審核非通過
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// 收款單guid
        /// </summary>
        public string? ReceiveId { get; set; }

        /// <summary>
        /// 申請狀態 1:提交成功, 2:匹配成功等待付款, 3: 取消訂單, 4:交易成功
        /// </summary>
        public string? ReceiveState { get; set; }

        /// <summary>
        /// 收款方式 1: 支付寶, 2: 微信, 3: 銀行卡轉銀行卡, 4: 支付寶轉銀行卡
        /// </summary>
        public string? ReceiveType { get; set; }

        /// <summary>
        /// 商戶訂單號
        /// </summary>
        public string? ReceiveTradeno { get; set; }

        /// <summary>
        /// 玩家姓名 (對帳用)
        /// </summary>
        public string? ReceivePlayerName { get; set; }

        /// <summary>
        /// 玩家帳號 (對帳用)
        /// </summary>
        [JsonPropertyName("receive_player_acct")]
        public string? ReceivePlayerAccount { get; set; }

        /// <summary>
        /// 收款金額 (小數點第二位)
        /// </summary>
        public string? ReceiveMoney { get; set; }

        /// <summary>
        /// 實際入帳金額 (小數點第二位)
        /// </summary>
        public string? ReceiveInmoney { get; set; }

        /// <summary>
        /// 收款qrcode連結
        /// </summary>
        public string? ReceiveQrcodeUrl { get; set; }

        /// <summary>
        /// 持卡人 (receive_type = 3 才會回傳)
        /// </summary>
        public string? ReceiveInname { get; set; }

        /// <summary>
        /// 所屬銀行 (receive_type = 3 才會回傳)
        /// </summary>
        public string? ReceiveInbankname { get; set; }

        /// <summary>
        /// 銀行卡號 (receive_type = 3 才會回傳)
        /// </summary>
        [JsonPropertyName("receive_inbanknum")]
        public string? ReceiveInbankNum { get; set; }

        /// <summary>
        /// 開戶地 (receive_type = 3 才會回傳)
        /// </summary>
        public string? ReceiveLocation { get; set; }

        /// <summary>
        /// 開戶網點 (receive_type = 3 才會回傳)
        /// </summary>
        public string? ReceiveInbankfullname { get; set; }

        /// <summary>
        /// 轉帳銀行
        /// </summary>
        public string? ReceiveTransBankname { get; set; }

        /// <summary>
        /// 轉帳姓名
        /// </summary>
        public string? ReceiveTransName { get; set; }

        /// <summary>
        /// 轉帳卡號
        /// </summary>
        public string? ReceiveTransBanknum { get; set; }

        /// <summary>
        /// 支行名稱
        /// </summary>
        public string? ReceiveTransBranchname { get; set; }

        /// <summary>
        /// 銀行附言
        /// </summary>
        public string? ReceiveTransBankMsg { get; set; }

        /// <summary>
        /// 新增日期
        /// </summary>
        public string? ReceiveRegdate { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public string? ReceiveUpdate { get; set; }

        /// <summary>
        /// 預覽網址
        /// </summary>
        public string? ReceiveUrl { get; set; }

        /// <summary>
        /// Result != 1(成功)時回傳的錯誤訊息
        /// </summary>
        public string? Msg { get; set; }
    }
}