using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.DepositForm
{
    public enum DepositFormResultStatus
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
        /// 格式錯誤 收款人 不得為空(需有中文or英文)
        /// </summary>
        [Description("格式錯誤 收款人 不得為空(需有中文or英文)")]
        InnameFormatError = -97,
        /// <summary>
        /// 重複訂單號
        /// </summary>
        [Description("重複訂單號")]
        DuplicateTradeNo = -96,
        /// <summary>
        /// 訂單優先度最大上限為9999；最小為0
        /// </summary>
        [Description("訂單優先度最大上限為9999；最小為0")] 
        OrderPriorityLimit = -95,
        /// <summary>
        /// 商戶無交易權限
        /// </summary>
        [Description("商戶無交易權限")]
        StoreNoTradeAuth = -6,
        /// <summary>
        /// 金額範圍有誤
        /// </summary>
        [Description("金額範圍有誤")]
        MoneyRangeError = -5,
        /// <summary>
        /// 餘額不足
        /// </summary>
        [Description("餘額不足")]
        BalanceInsufficient = -4,
        /// <summary>
        /// 查無付款單資料或為成功或失敗狀態無法取消
        /// </summary>
        [Description("查無付款單資料或為成功或失敗狀態無法取消")]
        NoDepositFormDataOrStatusCanNotCancel = -3,
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
