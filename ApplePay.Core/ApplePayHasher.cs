using System;
using System.Security.Cryptography;
using System.Text;

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