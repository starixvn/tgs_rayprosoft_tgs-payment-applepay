using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.WithdrawForm
{    
    public class Receive_Get_Token_UrlResponse
    {
        /// <summary>
        /// 1: 成功
        /// -99: 必传参数错误
        /// -98: 系统错误，请洽客服人员
        /// 11: 商戶無API KEY 或 商户guid錯誤
        /// 12: token验证錯誤
        /// </summary>
        public int Result { get; set; }
        /// <summary>
        /// 收銀台token網址
        /// </summary>
        public string Url { get; set; }
    }

}
