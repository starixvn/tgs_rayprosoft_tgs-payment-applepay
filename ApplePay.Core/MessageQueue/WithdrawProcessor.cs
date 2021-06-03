using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.Extensions.Options;
using Tgs.MessageQueue;
using Tgs.Payment.Protos;

namespace Tgs.Payment.ApplePay.MessageQueue
{
    internal class WithdrawProcessor : IMessageProcessor, IMessageExceptionProcessor
    {
        private readonly ApplePaySerializer _applePaySerializer;
        private readonly ApplePayOptions _options;
        private readonly ApplePayClient _applePayClient;

        public WithdrawProcessor(ApplePaySerializer applePaySerializer, IOptions<ApplePayOptions> optionsAccessor, ApplePayClient applePayClient)
        {
            _applePaySerializer = applePaySerializer ?? throw new ArgumentNullException(nameof(applePaySerializer));
            _applePayClient = applePayClient ?? throw new ArgumentNullException(nameof(applePayClient));
            _options = optionsAccessor.Value;
        }

        public async ValueTask<byte[]> HandleAsync(byte[] data, CancellationToken cancellationToken = default)
        {
            var request = WithdrawRequest.Parser.ParseFrom(data);
            var settings = _applePaySerializer.Deserialize<ApplePayWithdrawSettings>(request.ApplyInfo)!;

            var order = new WithdrawOrder
            {
                StoreGuid = settings.StoreGuid,
                TradeNo = settings.TradeNo,
                Type = settings.Type,
                Money = decimal.Parse(request.Amount),
                Inname = settings.InName,
                Inbankname = settings.InBankName,
                Inbanknum = settings.InBankNum,
                NotifyUrl = $"{_options.CallbackBaseUrl}/withdraw/callback"
            };

            var withdrawResponse = await _applePayClient
                .WithdrawAsync(settings.StoreGuid, settings.ApiKey, order)
                .ConfigureAwait(false);

            if (withdrawResponse != null)
            {
                var applyInfo = new ApplePayWithdrawApplyInfo(settings, withdrawResponse);

                var msg = new WithdrawResponse
                {
                    Result = _applePaySerializer.Serialize(applyInfo)
                };

                return msg.ToByteArray();
            }
            else
            {
                var response = new ApplePayWithdrawFailResponse
                {
                    Status = "fail",
                    Errors = "response is null"
                };

                var applyInfo = new ApplePayWithdrawApplyInfo(settings, response);

                var msg = new WithdrawResponse
                {
                    Result = _applePaySerializer.Serialize(applyInfo)
                };

                return msg.ToByteArray();
            }
        }

        public ValueTask<byte[]> HandleExceptionAsync(byte[] data, Exception exception, CancellationToken cancellationToken = default)
        {
            var request = WithdrawRequest.Parser.ParseFrom(data);
            var settings = _applePaySerializer.Deserialize<ApplePayWithdrawSettings>(request.ApplyInfo)!;

            var response = new ApplePayWithdrawFailResponse
            {
                Status = "fail",
                Errors = exception.ToString()
            };

            var applyInfo = new ApplePayWithdrawApplyInfo(settings, response);

            var msg = new WithdrawResponse
            {
                Result = _applePaySerializer.Serialize(applyInfo)
            };

            return ValueTask.FromResult(msg.ToByteArray());
        }
    }
}