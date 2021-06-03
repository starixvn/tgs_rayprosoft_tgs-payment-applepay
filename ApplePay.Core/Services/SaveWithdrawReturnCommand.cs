using System;

namespace Tgs.Payment.ApplePay.Services
{
    public record SaveWithdrawReturnCommand(Guid FormId, ApplePayWithdrawReturn WithdrawReturn);
}