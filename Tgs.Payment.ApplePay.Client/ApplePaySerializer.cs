using System;
using System.Text.Json;
using JoyMoe.Common.Json;
using TGS.Core.Infrastructures.Json;

namespace Tgs.Payment.ApplePay
{
    public class ApplePaySerializer
    {
        private readonly IJsonSerializationProvider _jsonSerializationProvider;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };

        public ApplePaySerializer(IJsonSerializationProvider jsonSerializationProvider)
        {
            _jsonSerializationProvider = jsonSerializationProvider ?? throw new ArgumentNullException(nameof(jsonSerializationProvider));
        }

        public string Serialize<T>(T data)
        {
            return _jsonSerializationProvider.SerializeToString(data, _jsonSerializerOptions);
        }

        public T Deserialize<T>(string json)
        {
            return _jsonSerializationProvider.DeserializeFromString<T>(json, _jsonSerializerOptions);
        }
    }
}