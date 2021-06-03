namespace Tgs.Payment.ApplePay
{
    public class ApplePayWithdrawFailResponse : ApplePayWithdrawResponse
    {
        public string? Status { get; init; }
        public string? Errors { get; set; }
    }
}