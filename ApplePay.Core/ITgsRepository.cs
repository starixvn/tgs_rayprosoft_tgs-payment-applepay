using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgs.Payment.ApplePay
{
    public interface ITgsRepository
    {
        ValueTask<DepositFormInfo> GetDepositFormByIdAsync(Guid id);
        ValueTask SaveDepositReturnAsync(Guid id, ApplePayReturn depositReturn);
    }
}
