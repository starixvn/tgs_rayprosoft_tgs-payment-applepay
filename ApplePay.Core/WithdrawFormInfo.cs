using System;

namespace Tgs.Payment.ApplePay
{
    public record WithdrawFormInfo(
        Guid Id,
        string PlayerCode,
        Guid BrandId,
        Guid? BrandPaymentId,
        decimal Amount,
        int Status,
        Guid BankInfoId,
        string? BankInfo,
        ApplePayWithdrawApplyInfo? ApplyInfo,
        string? PaymentReturn = null);
}