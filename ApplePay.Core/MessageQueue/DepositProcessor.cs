using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.Extensions.Options;
using Tgs.MessageQueue;

using Tgs.Payment.Protos;

namespace Tgs.Payment.ApplePay.MessageQueue
{
    internal class DepositProcessor : IMessageProcessor, IMessageExceptionProcessor
    {
        private readonly ApplePaySerializer _applePaySerializer;
        private readonly ApplePayClient _applePayClient;
        private readonly ApplePayOptions _options;

        public DepositProcessor(ApplePaySerializer applePaySerializer, ApplePayClient applePayClient, IOptions<ApplePayOptions> optionsAccessor)
        {
            _applePaySerializer = applePaySerializer ?? throw new ArgumentNullException(nameof(applePaySerializer));
            _applePayClient = applePayClient ?? throw new ArgumentNullException(nameof(applePayClient));
            _options = optionsAccessor.Value;
        }

        public async ValueTask<byte[]> HandleAsync(byte[] data, CancellationToken cancellationToken)
        {
            var request = DepositRequest.Parser.ParseFrom(data);
            var settings = _applePaySerializer.Deserialize<ApplePayDepositSettings>(request.ApplyInfo)!;

            var order = new DepositOrder
            {
                StoreGuid = settings.StoreGuid,
                TradeNo = settings.TradeNo,
                TransName = settings.TransName,
                Type = settings.Type,
                Money = decimal.Parse(request.Amount),
                NotifyUrl = $"{_options.CallbackBaseUrl}/deposit/callback"
            };

            var depositResponse = await _applePayClient
                .DepositAsync(settings.StoreGuid, settings.ApiKey, order)
                .ConfigureAwait(false);

            if (depositResponse != null && depositResponse.Result == 1)
            {
                var applyInfo = new ApplePayDepositApplyInfo(settings, depositResponse);

                var msg = new DepositResponse
                {
                    Result = _applePaySerializer.Serialize(applyInfo)
                };

                return msg.ToByteArray();
            }
            else
            {
                var response = new ApplePayDepositResponse
                {
                    Result = depositResponse!.Result,
                    Msg = depositResponse!.Msg
                };

                var applyInfo = new ApplePayDepositApplyInfo(settings, response);

                var msg = new DepositResponse
                {
                    Result = _applePaySerializer.Serialize(applyInfo)
                };

                return msg.ToByteArray();
            }
        }

        public ValueTask<byte[]> HandleExceptionAsync(byte[] data, Exception exception, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    }
}