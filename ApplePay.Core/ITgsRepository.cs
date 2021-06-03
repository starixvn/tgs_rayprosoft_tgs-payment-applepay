using System;
using System.Threading.Tasks;

namespace Tgs.Payment.ApplePay
{
    public interface ITgsRepository
    {
        ValueTask<DepositFormInfo> GetDepositFormByIdAsync(Guid id);

        ValueTask<WithdrawFormInfo> GetWithdrawFormByIdAsync(Guid id);

        ValueTask SaveDepositReturnAsync(Guid id, ApplePayDepositReturn depositReturn);

        ValueTask SaveWithdrawReturnAsync(Guid id, ApplePayWithdrawReturn withdrawReturn);
    }
}