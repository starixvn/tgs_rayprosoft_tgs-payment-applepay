using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppTest;

namespace ConsoleAppTest.DepositForm
{
    public class Pay_Query_DateRequest
    {
        /// <summary>
        /// 商户guid
        /// </summary>
        [Required]
        public string Store_Guid { get; set; }
        /// <summary>
        /// 指定新增日期格式 ex: 2019/07/18 or 2019/09/18 10:23
        /// </summary>
        [Required] 
        public string Date { get; set; }
        /// <summary>
        /// 验证参数 加密格式 md5(store_guid + date + api_key)
        /// </summary>
        [Required] 
        public string Check { get; set; }
    }
}
