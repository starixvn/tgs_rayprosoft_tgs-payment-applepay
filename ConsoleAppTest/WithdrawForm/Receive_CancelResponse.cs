using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.WithdrawForm
{    
    public class Receive_CancelResponse
    {
        /// <summary>
        /// 1: 成功
        /// -99: 必传参数错误
        /// -3: 查无收款单资料
        /// -2: check验证错误
        /// -1: IP白名单错误
        /// 0: 查无此guid 或是商户帐号状态非正常, 或是商户帐号审核非通过
        /// </summary>
        public int Result { get; set; }
        /// <summary>
        /// 收款单guid
        /// </summary>
        public string Receive_id { get; set; }
        /// <summary>
        /// 申请状态 1:提交成功, 2:匹配成功等待付款, 3: 取消订单, 4:交易成功
        /// </summary>
        public string Receive_state { get; set; }
        /// <summary>
        /// 收款方式 1: 支付宝, 2: 微信, 3: 银行卡轉银行卡, 4: 支付宝轉银行卡
        /// </summary>
        public string Receive_type { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string Receive_tradeno { get; set; }
        /// <summary>
        /// 收款金额 (小数点第二位)
        /// </summary>
        public decimal Receive_money { get; set; }
        /// <summary>
        /// 实际入帐金额 (小数点第二位)
        /// </summary>
        public decimal Receive_inmoney { get; set; }
        /// <summary>
        /// 收款qrcode連結
        /// </summary>
        public string Receive_qrcode_url { get; set; }
        /// <summary>
        /// 新增日期
        /// </summary>
        public int Receive_regdate { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public int Receive_update { get; set; }
    }

}
