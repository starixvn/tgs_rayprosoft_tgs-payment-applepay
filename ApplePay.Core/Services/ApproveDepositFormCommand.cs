using System;

namespace Tgs.Payment.ApplePay.Services
{
    public record ApproveDepositFormCommand(Guid FormId, Guid BrandId);
}
