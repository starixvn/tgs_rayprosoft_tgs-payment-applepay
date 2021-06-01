using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppTest;

namespace ConsoleAppTest.DepositForm
{    
    public class Pay_Priority_UpdateResponse
    {
        /// <summary>
        /// 1: 成功
        /// -99: 必传参数错误
        /// -95: 订单优先度最大上限为9999；最小为0
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
        /// 商户订单号
        /// </summary>
        public string Pay_tradeno { get; set; }
        /// <summary>
        /// 订单优先度
        /// </summary>
        public int Pay_priority { get; set; }
    }

}
