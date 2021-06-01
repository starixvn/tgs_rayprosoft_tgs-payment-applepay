using System;

namespace Tgs.Payment.ApplePay
{
    public record ApplePayDepositSettings(string ApiKey, string StoreGuid, Guid TradeNo,string Type, string TransName);
}