using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppTest;

namespace ConsoleAppTest.DepositForm
{
    public class Pay_AddRequest
    {
        /// <summary>
        /// 商戶guid
        /// </summary>
        [Required]
        public string Store_Guid { get; set; }

        /// <summary>
        /// 商戶訂單號
        /// </summary>
        [Required]
        public string TradeNo { get; set; }
        /// <summary>
        /// 付款方式 1: 支付寶, 2: 微信, 3: 銀行卡
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// 付款金額 (小數點第二位)
        /// </summary>
        [Required]
        public decimal Money { get; set; }

        /// <summary>
        /// 收款人
        /// </summary>
        [Required]
        public string Inname { get; set; }

        /// <summary>
        /// 收款銀行
        /// </summary>
        [Required]
        public string Inbankname { get; set; }

        /// <summary>
        /// 收款帳號
        /// </summary>
        [Required]
        public string Inbanknum { get; set; }

        /// <summary>
        /// 開戶地
        /// </summary>
        public string Location { get; set; }


        /// <summary>
        /// 開戶網點
        /// </summary>
        public string Inbankfullname { get; set; }

        /// <summary>
        /// 訂單優先度; 1 2 3 4 5... 數字越大優先度越高 (最高9999)，預設值0
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 異步通知URL (請填寫當狀態變更服務器POST消息到異步返回處理頁面 請用 https://格式的完整路徑
        /// 回傳參數等同查詢指定的付款單資料
        /// 參數與驗證機制: 請查看上方說明
        /// </summary>
        public string Notify_url { get; set; }

        /// <summary>
        /// 异步通知限制(預設0)
        /// 0: 所有狀態皆須传送给服务器
        /// 1: 限定只在state=4 (交易成功状态) 才传送给服务器
        /// 2: 限定在state=3 (取消订单状态) 与 state=4 (交易成功状态) 才传送给服务器
        /// </summary>
        public string Notify_limited { get; set; }

        /// <summary>
        /// 验证参数 加密格式
        /// 1. 20200817前註冊商戶 md5(store_guid + tradeno + api_key)
        /// example : md5(aaaaabbbbbccccc)
        /// 2. 20200817後註冊商戶 md5(store_guid + _ + tradeno + _ + api_key + _ + money)
        /// example : md5(aaaaa_bbbbb_ccccc_12345)
        /// </summary>
        [Required]
        public string Check { get; set; }

    }
}
