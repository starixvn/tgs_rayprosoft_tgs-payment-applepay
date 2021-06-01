using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tgs.Payment.ApplePay
{
    public class ApplePayHasher
    {
        private readonly static MD5 _Md5;
        static ApplePayHasher()
        {
            _Md5 = MD5.Create();            
        }

        public string ComputeHash(string plainText)
        {                        
            var data = Encoding.UTF8.GetBytes(plainText);
            var hash = _Md5.ComputeHash(data);

            return Convert.ToHexString(hash).ToLower();
        }
    }
}
