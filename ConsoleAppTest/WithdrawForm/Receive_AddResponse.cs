using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.WithdrawForm
{    
    public class Receive_AddResponse
    {

        /// <summary>
        /// 1: 成功
        /// -99: 必传参数错误
        /// -98: 同时写入错误
        /// -12: 不可新增非正整数的金额
        /// -11: 餘額限制已達上限
        /// -10: 商戶無交易權限
        /// -9: 帐户末5码长度错误
        /// -8: 超出单日总限额限制
        /// -7: 未開放此支付方式 1: 支付宝, 2: 微信
        /// -6: 無可接單交易員
        /// -5: 金额範圍有誤
        /// -4: 系统出错，请重新输入
        /// -3: 商户代理有误，请联系客服
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
        /// 玩家姓名 (对帐用)
        /// </summary>
        public string Receive_player_name { get; set; }
        /// <summary>
        /// 玩家帐号 (对帐用)
        /// </summary>
        public string Receive_player_acct { get; set; }
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
        /// 持卡人 (receive_type = 3 才會回傳)
        /// </summary>
        public string Receive_inname { get; set; }
        /// <summary>
        /// 所属银行 (receive_type = 3 才會回傳)
        /// </summary>
        public string Receive_inbankname { get; set; }
        /// <summary>
        /// 银行卡号 (receive_type = 3 才會回傳)
        /// </summary>
        public string Receive_inbanknum { get; set; }
        /// <summary>
        /// 开户地 (receive_type = 3 才會回傳)
        /// </summary>
        public string Receive_location { get; set; }
        /// <summary>
        /// 开户网点 (receive_type = 3 才會回傳)
        /// </summary>
        public string Receive_inbankfullname { get; set; }
        /// <summary>
        /// 转帐银行
        /// </summary>
        public string Receive_trans_bankname { get; set; }
        /// <summary>
        /// 转帐姓名
        /// </summary>
        public string Receive_trans_name { get; set; }
        /// <summary>
        /// 转帐卡号
        /// </summary>
        public string Receive_trans_banknum { get; set; }
        /// <summary>
        /// 支行名称
        /// </summary>
        public string Receive_trans_branchname { get; set; }
        /// <summary>
        /// 银行附言
        /// </summary>
        public string Receive_trans_bank_msg { get; set; }
        /// <summary>
        /// 新增日期
        /// </summary>
        public int Receive_regdate { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public int Receive_update { get; set; }
        /// <summary>
        /// 预览网址
        /// </summary>
        public string Receive_url { get; set; }
    }

}
