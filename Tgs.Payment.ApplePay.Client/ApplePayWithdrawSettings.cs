using System;

namespace Tgs.Payment.ApplePay
{
    public record ApplePayWithdrawSettings(string ApiKey, string StoreGuid, Guid TradeNo, string Type, decimal Money, string InName, string InBankName, string InBankNum);
}