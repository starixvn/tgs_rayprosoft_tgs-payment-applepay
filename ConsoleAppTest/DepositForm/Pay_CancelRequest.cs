using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppTest;

namespace ConsoleAppTest.DepositForm
{
    public class Pay_CancelRequest
    {
        /// <summary>
        /// 商戶guid
        /// </summary>
        [Required]
        public string Store_Guid { get; set; }

        /// <summary>
        /// 付款單guid
        /// </summary>
        [Required]
        public string Pay_Guid { get; set; }

        /// <summary>
        /// 验证参数 加密格式 md5(store_guid + pay_guid + api_key)
        /// </summary>
        [Required]
        public string Check { get; set; }
    }
}
