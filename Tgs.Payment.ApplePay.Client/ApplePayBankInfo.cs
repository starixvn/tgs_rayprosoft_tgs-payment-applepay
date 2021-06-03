namespace Tgs.Payment.ApplePay
{
    public record ApplePayBankInfo(
        string BankName,
        string BankAccount,
        string Name,
        string? BankBranch);
}