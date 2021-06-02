using System;

namespace Tgs.Payment.ApplePay.Services
{
    public record SaveDepositReturnCommand(Guid FormId, ApplePayReturn DepositReturn);
}