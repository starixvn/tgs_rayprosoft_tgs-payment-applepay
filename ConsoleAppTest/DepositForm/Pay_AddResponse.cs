using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppTest;

namespace ConsoleAppTest.DepositForm
{
    public class Pay_AddResponse
    {
        /// <summary>
        /// 1: 成功
        /// -99: 必传参数错误
        /// -98: 同时写入错误
        /// -97: 格式錯誤 inname 不得為空(需有中文or英文)
        /// -96: 重複訂單號
        /// -95: 订单优先度最大上限为9999；最小为0
        /// -6: 商戶無交易權限
        /// -5: 金额範圍有誤
        /// -4: 馀额不足
        /// -2: check验证错误
        /// -1: IP白名单错误
        /// 0: 查无此guid 或是商户帐号状态非正常, 或是商户帐号审核非通过
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// 付款单guid (result: 1 才會傳)
        /// </summary>
        public string Pay_Id { get; set; }
    }
}
