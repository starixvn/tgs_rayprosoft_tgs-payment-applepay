using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgs.Payment.ApplePay.Services
{
    public record SaveDepositReturnCommand(Guid FormId, ApplePayReturn DepositReturn);
}
