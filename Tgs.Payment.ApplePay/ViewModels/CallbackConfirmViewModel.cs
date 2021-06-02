namespace Tgs.Payment.ApplePay.ViewModels
{
    public class CallbackConfirmViewModel
    {
        public string Message { get; init; } = string.Empty;

        public string Status { get; init; } = default!;
    }
}