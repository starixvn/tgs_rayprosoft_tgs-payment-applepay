using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppTest;

namespace ConsoleAppTest.DepositForm
{    
    public class Pay_QueryResponse
    {
        /// <summary>
        /// 1: 成功
        /// -99: 必传参数错误
        /// -3: 查无付款单资料
        /// -2: check验证错误
        /// -1: IP白名单错误
        /// 0: 查无此guid 或是商户帐号状态非正常, 或是商户帐号审核非通过
        /// </summary>
        public int Result { get; set; }
        /// <summary>
        /// 付款单guid
        /// </summary>
        public string Pay_id { get; set; }
        /// <summary>
        /// 申请状态 1:提交成功, 2:匹配成功等待付款, 3: 取消订单, 4: 交易成功, 5: 付款成功等待审核, 6: 交易异常, 7: 付款中
        /// </summary>
        public string Pay_state { get; set; }
        /// <summary>
        /// 付款方式 1: 支付宝, 2: 微信, 3: 银行卡
        /// </summary>
        public string Pay_type { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string Pay_tradeno { get; set; }
        /// <summary>
        /// 付款金额
        /// </summary>
        public int Pay_money { get; set; }
        /// <summary>
        /// 收款人
        /// </summary>
        public string Pay_inname { get; set; }
        /// <summary>
        /// 收款銀行
        /// </summary>
        public string Pay_inbankname { get; set; }
        /// <summary>
        /// 收款帐号
        /// </summary>
        public string Pay_inbanknum { get; set; }
        /// <summary>
        /// 开户地
        /// </summary>
        public string Pay_location { get; set; }
        /// <summary>
        /// 开户网点
        /// </summary>
        public string Pay_inbankfullname { get; set; }
        /// <summary>
        /// 新增日期
        /// </summary>
        public int Pay_regdate { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public int Pay_update { get; set; }
        /// <summary>
        /// 基本费
        /// </summary>
        public decimal Pay_base { get; set; }
        /// <summary>
        /// 费率
        /// </summary>
        public decimal Pay_rate { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        public decimal Pay_fee { get; set; }
        /// <summary>
        /// 验证参数 加密格式 md5(store_guid + pay_guid + api_key+pay_state+pay_tradeno+pay_money)
        /// </summary>
        public string Check2 { get; set; }
    }
}
