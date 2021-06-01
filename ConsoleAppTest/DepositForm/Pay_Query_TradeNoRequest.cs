using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppTest;

namespace ConsoleAppTest.DepositForm
{
    public class Pay_Query_TradeNoRequest
    {
        /// <summary>
        /// 商户guid
        /// </summary>
        [Required] 
        public string Store_Guid { get; set; }
        /// <summary>
        /// 付款单訂單號
        /// </summary>
        [Required] 
        public string Pay_TradeNo { get; set; }
        /// <summary>
        /// 验证参数 加密格式 md5(store_guid + pay_tradeno + api_key)
        /// </summary>
        [Required] 
        public string Check { get; set; }
    }
}
