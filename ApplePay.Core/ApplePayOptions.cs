using System;
using System.Text.Json;

namespace Tgs.Payment.ApplePay
{
    public class ApplePayOptions
    {
        public string CallbackBaseUrl { get; set; } = default!;
        public string NatsUrl { get; set; } = default!;

        public Uri PaymentApiUrl { get; set; } = default!;

        public JsonSerializerOptions? SystemSerializerOptions { get; set; }
    }
}