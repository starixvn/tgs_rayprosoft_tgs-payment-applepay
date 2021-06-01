using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgs.Payment.ApplePay
{
    public record DepositFormInfo(
        Guid Id,
        string PlayerCode,
        Guid BrandId,
        Guid BrandPaymentId,
        decimal Amount,
        int Status,
        ApplePayDepositApplyInfo? ApplyInfo,
        string? PaymentReturn = null);
}
