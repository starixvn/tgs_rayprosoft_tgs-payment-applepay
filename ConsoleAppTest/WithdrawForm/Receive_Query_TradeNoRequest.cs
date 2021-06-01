using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.WithdrawForm
{
    public class Receive_Query_TradeNoRequest
    {
        /// <summary>
        /// 商戶guid
        /// </summary>
        [Required]
        public string Store_Guid { get; set; }
        /// <summary>
        /// 收款單訂單號
        /// </summary>
        [Required]
        public string Receive_tradeno { get; set; }
        /// <summary>
        /// 验证参数 加密格式 md5(store_guid + receive_tradeno + api_key)
        /// </summary>
        [Required]

        public string Check { get; set; }

    }
}
