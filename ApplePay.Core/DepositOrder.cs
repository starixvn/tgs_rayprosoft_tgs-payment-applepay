using System;
using System.Text.Json.Serialization;

namespace Tgs.Payment.ApplePay
{
    public class DepositOrder
    {
        /// <summary>
        /// 商戶guid
        /// </summary>
        [JsonPropertyName("store_guid")]
        public string StoreGuid { get; set; } = default!;

        /// <summary>
        /// 商戶訂單號
        /// </summary>
        [JsonPropertyName("tradeno")]
        public Guid TradeNo { get; set; } = default!;

        /// <summary>
        /// 收款方式 1: 支付寶, 2: 微信, 3: 銀行卡轉銀行卡, 4: 支付寶轉銀行卡
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        /// <summary>
        /// 收款金額 (小數點第二位)
        /// </summary>
        [JsonPropertyName("money")]
        public decimal Money { get; set; }

        /// <summary>
        /// 玩家姓名 (對帳用)
        /// </summary>
        [JsonPropertyName("player_name")]
        public string? PlayerName { get; set; }

        /// <summary>
        /// 玩家帳號 (對帳用)
        /// </summary>
        [JsonPropertyName("player_acct")]
        public string? PlayerAcct { get; set; }

        /// <summary>
        /// 異步通知URL (請填寫當狀態變更服務器POST消息到異步返回處理頁面 請用 https://格式的完整路徑
        /// 回傳參數等同查詢指定的收款單資料
        /// 參數與驗證機制: 請查看上方說明
        /// </summary>
        [JsonPropertyName("notify_url")]
        public string? NotifyUrl { get; set; }

        /// <summary>
        /// 異步通知限制(預設0)
        /// 0: 所有狀態皆須傳送给服務器
        /// 1: 限定只在state=4 (交易成功状态) 才傳送给服務器
        /// 2: 限定在state=3 (取消訂單狀態) 與 state=4 (交易成功狀態) 才傳送给服務器
        /// </summary>
        [JsonPropertyName("notify_limited")]
        public string? NotifyLimited { get; set; }

        /// <summary>
        /// 驗證參數 加密格式 md5(store_guid + tradeno + api_key)
        /// </summary>
        [JsonPropertyName("check")]
        public string? Check { get; set; }

        /// <summary>
        /// 轉帳銀行
        /// </summary>
        [JsonPropertyName("trans_bankname")]
        public string? TransBankName { get; set; }

        /// <summary>
        /// 轉帳姓名
        /// </summary>
        [JsonPropertyName("trans_name")]
        public string TransName { get; set; } = default!;

        /// <summary>
        /// 轉帳卡號
        /// </summary>
        [JsonPropertyName("trans_banknum")]
        public string? TransBankNum { get; set; }

        /// <summary>
        /// 支行名稱
        /// </summary>
        [JsonPropertyName("trans_branchname")]
        public string? TransBranchName { get; set; }

        /// <summary>
        /// 銀行附言(五位數字)
        /// </summary>
        [JsonPropertyName("trans_bank_msg")]
        public string? TransBankMsg { get; set; }
    }
}