namespace Tgs.Payment.ApplePay
{
    public record ApplePayDepositApplyInfo(
        ApplePayDepositSettings Settings,
        ApplePayDepositResponse Response);
}