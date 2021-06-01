using System;

namespace Tgs.Payment.ApplePay
{
    public record ApplePayWithdrawSettings(string ApiKey, string StoreGuid, Guid TradeNo, decimal Money);
}