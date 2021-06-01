using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppTest;

namespace ConsoleAppTest.DepositForm
{    
    public class Pay_Query_ProcessingResponse
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
        /// 进行中订单总笔数
        /// </summary>
        public int Process_storepay_num { get; set; }
        /// <summary>
        /// 最新三笔平均完成时间
        /// </summary>
        public string Avg_finishtime { get; set; }
        /// <summary>
        /// 付款单guid
        /// </summary>

        public string Pay_id { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string Pay_tradeno { get; set; }
        /// <summary>
        /// 新增日期
        /// </summary>
        public string Pay_regdate { get; set; }
    }

}
