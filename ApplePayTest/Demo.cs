using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tgs.Payment.ApplePay;
using Tgs.Payment.Clients;

namespace ApplePayTest
{
    internal class Demo : BackgroundService
    {
        private readonly ApplePaySerializer _applePaySerializer;
        private readonly ILogger<Demo> _logger;
        private readonly IPaymentClient _paymentClient;

        public Demo(IPaymentClient paymentClient, ApplePaySerializer applePaySerializer, ILogger<Demo> logger)
        {
            _paymentClient = paymentClient ?? throw new ArgumentNullException(nameof(paymentClient));
            _applePaySerializer = applePaySerializer ?? throw new ArgumentNullException(nameof(applePaySerializer));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var apiKey = "EXgNMxsIxfAFuupt9QQa";
            var storeGuid = "2FF00CD295A47E70B1CFFFACAC6D02CA";
            var tradeNo = Guid.NewGuid();
            var payType = "3";
            //var transName = "testTransName";

            //var depositSettings = new ApplePayDepositSettings(
            //    apiKey,
            //    storeGuid,
            //    tradeNo,
            //    payType,
            //    transName
            //    );

            //var depositReturn = await _paymentClient.DepositAsync("tgs.payment.applepay.deposit", 100M, _applePaySerializer.Serialize(depositSettings));
            //_logger.LogInformation($"Deposit Return:", depositReturn);

            var money = 100M;
            var payee = "TestInName";
            var payeeBankName = "TestBankName";
            var payeeBankNum = "TestBankNum";
            var withdrawSettings = new ApplePayWithdrawSettings(
                apiKey,
                storeGuid,
                tradeNo,
                payType,
                money,
                payee,
                payeeBankName,
                payeeBankNum
                );

            var withdrawReturn = await _paymentClient.WithdrawAsync("tgs.payment.applepay.withdraw", money, _applePaySerializer.Serialize(withdrawSettings));
            _logger.LogInformation($"Withdraw Return:", withdrawReturn);
        }
    }
}
