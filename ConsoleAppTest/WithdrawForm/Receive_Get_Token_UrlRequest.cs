using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.WithdrawForm
{
    public class Receive_Get_Token_UrlRequest
    {
        /// <summary>
        /// 商戶guid
        /// </summary>
        [Required]
        public string Store_Guid { get; set; }
        /// <summary>
        /// 充值金額
        /// </summary>
        [Required]
        public decimal Money { get; set; }
        /// <summary>
        /// 訂單號碼
        /// </summary>
        [Required]
        public string TradeNo { get; set; }
        /// <summary>
        /// 收款方式 3: 银行卡轉银行卡, 4: 支付宝轉银行卡 (如无输入此参数 预设两种皆可使用 有带的话使用者不可选择其他)
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 异步通知URL (请填写当状态变更服务器POST消息到异步返回处理页面 请用 https://格式的完整路径
        /// 回传参数等同查询指定的收款单资料
        /// 参数与验证机制: 请查看上方说明
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
        /// 如需此功能请至后台开启
        /// 验证参数 加密格式 md5(store_guid + _ + tradeno + _ + api_key + _ + money)
        /// </summary>
        public string Token { get; set; }
    }
}
