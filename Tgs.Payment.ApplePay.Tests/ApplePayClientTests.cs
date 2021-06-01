using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JoyMoe.Common.Json;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;

namespace Tgs.Payment.ApplePay.Tests
{
    [TestFixture]
    public class ApplePayClientTests
    {
        [Test]
        public async Task Test_Deposit()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://mapay168.com");

            var applePayHasher = new ApplePayHasher();
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance
            };
            var logger = Substitute.For<ILogger<ApplePayClient>>();

            ApplePayClient applePayClient = new ApplePayClient(httpClient, applePayHasher, jsonSerializerOptions, logger);

            var storeGuid = "2FF00CD295A47E70B1CFFFACAC6D02CA";
            var apiKey = "EXgNMxsIxfAFuupt9QQa";
            var transName = "TestName001";
            var tradeNo = Guid.NewGuid();
            var type = "3";

            DepositOrder order = new DepositOrder()
            {
                StoreGuid = storeGuid,
                TradeNo = tradeNo,
                Money = 103,//同一筆金額及付款人姓名不可重複
                Type = type,
                TransName = transName,//同一筆金額及付款人姓名不可重複
                NotifyUrl = "https://dev.payment.tgsdev.gq/apple-test/Deposit/callback"
            };

            var r = await applePayClient.DepositAsync(storeGuid, apiKey, order);

            Assert.AreEqual(1, r.Result);
            Assert.AreEqual(type, r.ReceiveType);
            Assert.AreEqual(transName, r.ReceiveTransName);
        }

        [Test]
        public async Task Test_Withdraw()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://mapay168.com");

            var applePayHasher = new ApplePayHasher();
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance
            };
            var logger = Substitute.For<ILogger<ApplePayClient>>();

            ApplePayClient applePayClient = new ApplePayClient(httpClient, applePayHasher, jsonSerializerOptions, logger);

            var storeGuid = "2FF00CD295A47E70B1CFFFACAC6D02CA";
            var apiKey = "EXgNMxsIxfAFuupt9QQa";
            var inName = "Tester";
            var tradeNo = Guid.NewGuid();
            var type = "3";
            var inbankname = "testInbankName";
            var inbanknum = "123456789";

            var order = new WithdrawOrder()
            {
                StoreGuid = storeGuid,
                TradeNo = tradeNo,
                Type = type,
                Money = 100,
                Inname = inName,
                Inbankname = inbankname,
                Inbanknum = inbanknum
            };

            var r = await applePayClient.WithdrawAsync(storeGuid, apiKey, order);

            Assert.AreEqual(1, r.Result);
        }
    }
}