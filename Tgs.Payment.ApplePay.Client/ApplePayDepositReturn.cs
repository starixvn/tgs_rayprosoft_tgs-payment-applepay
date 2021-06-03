namespace Tgs.Payment.ApplePay
{
    public class ApplePayDepositReturn
    {
        public string ReceiveId { get; init; } = default!;
        public string ReceiveState { get; init; } = default!;
        public string ReceiveType { get; init; } = default!;
        public string ReceiveTradeNo { get; init; } = default!;
        public string ReceiveMoney { get; init; } = default!;
        public string ReceiveInMoney { get; init; } = default!;
        public string ReceiveInName { get; init; } = default!;
        public string ReceiveInBankname { get; init; } = default!;
        public string ReceiveInBankNum { get; init; } = default!;
        public string ReceiveLocation { get; init; } = default!;
        public string ReceiveInBankFullName { get; init; } = default!;
        public string ReceiveQrcodeUrl { get; init; } = default!;
        public string ReceiveTransBankName { get; init; } = default!;
        public string ReceiveTransName { get; init; } = default!;
        public string ReceiveTransBankNum { get; init; } = default!;
        public string ReceiveTransBranchName { get; init; } = default!;
        public string ReceiveRegdate { get; init; } = default!;
        public string ReceiveUpdate { get; init; } = default!;
        public string Check { get; init; } = default!;
        public string Result { get; init; } = default!;
        public string Check2 { get; init; } = default!;
    }
}