namespace Tgs.Payment.ApplePay
{
    public record ApplePayWithdrawApplyInfo(
        ApplePayWithdrawSettings Settings,
        ApplePayWithdrawResponse Response);
}