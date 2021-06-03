using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //Console.WriteLine(checkEncrypt());

            //Console.WriteLine(Pay_AddCheck());
            var r = Pay_AddCheck();

            //var r = Receive_AddCheck();
            Console.WriteLine(r);

            Console.ReadLine();
        }

        private static string checkEncrypt()
        {
            var store_guid = "TEST12345";
            var api_key = "AAA1234";

            var cryptoServiceProvider = new MD5CryptoServiceProvider();

            var plainText = store_guid + api_key;

            var encoding = Encoding.UTF8;
            var data = encoding.GetBytes(plainText);
            var hash = cryptoServiceProvider.ComputeHash(data);
            

            var result = Convert.ToHexString(hash).ToLower();
            return result;
        }

        private static string Pay_AddCheck()
        {
            var store_guid = "2FF00CD295A47E70B1CFFFACAC6D02CA";
            //跟我方系統對接用的訂單 自己產guid
            var tradeno = Guid.NewGuid();
            var api_key = "EXgNMxsIxfAFuupt9QQa";//ApplePay CS給的
            var money = 100;
            var plainText = $"{store_guid}_{tradeno}_{api_key}_{money}";
            return HashCode(plainText);
        }


        private static string Receive_AddCheck()
        {
            var store_guid = "2FF00CD295A47E70B1CFFFACAC6D02CA";
            var tradeno = Guid.NewGuid();
            Console.WriteLine(tradeno);
            var api_key = "EXgNMxsIxfAFuupt9QQa";


            var plaintText = $"{store_guid}{tradeno}{api_key}";
            return HashCode(plaintText);
        }





        private static string HashCode(string plainText)
        {            
            
            var cryptoServiceProvider = new MD5CryptoServiceProvider();
            
            var data = Encoding.UTF8.GetBytes(plainText);
            var hash = cryptoServiceProvider.ComputeHash(data);

            var result = Convert.ToHexString(hash).ToLower();
            return result;
        }

        private static string DepositCheck(string store_guid, string pay_id,string api_key)
        {            
            return HashCode($"{store_guid}{pay_id}{api_key}");
        }
        private static string DepositCheck2(string store_guid , string pay_id , string api_key , string pay_state , string pay_tradeno , string pay_money)
        {
            return HashCode($"{store_guid}{pay_id}{api_key}{pay_state}{pay_tradeno}{pay_money}");
        }

        private static string WithdrawCheck(string store_guid , string receive_id , string api_key)
        {
            return HashCode($"{store_guid}{receive_id}{api_key}");
        }

        private static string WithdrawCheck2(string store_guid , string receive_tradeno , string receive_state , string receive_inmoney , string api_key)
        {
            return HashCode($"{store_guid}{receive_tradeno}{receive_state}{receive_inmoney}{api_key}");
        }

        private static string StoreRechargeAddCheck(string store_guid , string recharge_id , string api_key)
        {
            return HashCode($"{store_guid},{recharge_id}{api_key}");
        }




    }
}
