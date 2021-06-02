using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Tgs.Payment.ApplePay
{
    public class ApplePayClient
    {
        private readonly HttpClient _httpClient;
        private readonly ApplePayHasher _applePayHasher;
        private readonly JsonSerializerOptions? _jsonSerializerOptions;
        private readonly ILogger<ApplePayClient> _logger;

        public ApplePayClient(
            HttpClient httpClient,
            IOptions<ApplePayOptions> optionsAccessor,
            ApplePayHasher applePayHasher,            
            ILogger<ApplePayClient> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonSerializerOptions = optionsAccessor.Value.SystemSerializerOptions;
            _applePayHasher = applePayHasher ?? throw new ArgumentNullException(nameof(applePayHasher));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async ValueTask<ApplePayDepositResponse?> DepositAsync(string storeGuid, string apiKey, DepositOrder order)
        {
            var hashData = $"{storeGuid}{order.TradeNo}{apiKey}";
            var hashCode = _applePayHasher.ComputeHash(hashData);

            order.Check = hashCode;

            var orderJson = JsonSerializer.Serialize(order, _jsonSerializerOptions);
            var orderDict = JsonSerializer
                .Deserialize<Dictionary<string, object>>(orderJson, _jsonSerializerOptions)!
                .AsEnumerable()
                .Select(p => new KeyValuePair<string?, string?>(p.Key, p.Value?.ToString()));

            var content = new FormUrlEncodedContent(orderDict);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await _httpClient
                .PostAsync("/api_server/receive_add.php", content)
                .ConfigureAwait(false);

            _logger.LogInformation($"Deposit StatusCode: {response.StatusCode}");

            var bodyJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            _logger.LogInformation($"Deposit Body: {bodyJson}");

            response.EnsureSuccessStatusCode();

            var apiResponseData = JsonSerializer.Deserialize<ApplePayDepositResponse>(bodyJson, _jsonSerializerOptions);

            return apiResponseData;
        }

        public async ValueTask<ApplePayWithdrawResponse?> WithdrawAsync(string store_guid, string apiKey, WithdrawOrder order)
        {
            var hashData = $"{store_guid}_{order.TradeNo}_{apiKey}_{order.Money}";
            var hashCode = _applePayHasher.ComputeHash(hashData);

            order.Check = hashCode;

            var orderJson = JsonSerializer.Serialize(order, _jsonSerializerOptions);
            var orderDict = JsonSerializer
                .Deserialize<Dictionary<string, object>>(orderJson, _jsonSerializerOptions)!
                .AsEnumerable()
                .Select(p => new KeyValuePair<string?, string?>(p.Key, p.Value?.ToString()));

            var content = new FormUrlEncodedContent(orderDict);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await _httpClient
                .PostAsync("/api_server/pay_add.php", content)
                .ConfigureAwait(false);

            _logger.LogInformation($"Withdraw StatusCode: {response.StatusCode}");

            var bodyJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            _logger.LogInformation($"Withdraw Body: {bodyJson}");

            response.EnsureSuccessStatusCode();

            var apiResponseData = JsonSerializer.Deserialize<ApplePayWithdrawResponse>(bodyJson, _jsonSerializerOptions);

            return apiResponseData;
        }
    }
}