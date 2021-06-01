using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.WithdrawForm
{
    public class Receive_AddRequest
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
        /// 收款方式 1: 支付宝, 2: 微信, 3: 银行卡轉银行卡, 4: 支付宝轉银行卡
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// 收款金額 (小数点第二位)
        /// </summary>
        [Required]
        public decimal Money { get; set; }
        /// <summary>
        /// 玩家姓名 (对帐用)
        /// </summary>
        public string Player_Name { get; set; }
        /// <summary>
        /// 玩家帐号 (对帐用)
        /// </summary>
        public string Player_Acct { get; set; }

        /// <summary>
        /// 异步通知URL (请填写当状态变更服务器POST消息到异步返回处理页面 请用 https://格式的完整路径
        /// 回传参数等同查询指定的收款单资料
        /// 参数与验证机制: 请查看上方说明
        /// </summary>
        public string Notify_Url { get; set; }

        /// <summary>
        /// 异步通知限制(預設0)
        /// 0: 所有狀態皆須传送给服务器
        /// 1: 限定只在state=4 (交易成功状态) 才传送给服务器
        /// 2: 限定在state=3 (取消订单状态) 与 state=4 (交易成功状态) 才传送给服务器
        /// </summary>
        public string Notify_Limited { get; set; }

        /// <summary>
        /// 验证参数 加密格式 md5(store_guid + tradeno + api_key)
        /// </summary>
        [Required]
        public string Check { get; set; }

        /// <summary>
        /// 转帐银行
        /// </summary>
        public string Trans_bankname { get; set; }

        /// <summary>
        /// 转帐姓名
        /// </summary>
        [Required]
        public string Trans_name { get; set; }

        /// <summary>
        /// 转帐卡号
        /// </summary>
        public string Trans_banknum { get; set; }

        /// <summary>
        /// 支行名称
        /// </summary>
        public string Trans_branchname { get; set; }

        /// <summary>
        /// 银行附言(五位数字)
        /// </summary>
        public int Trans_bank_msg { get; set; }
    }
}
