using System;
using System.Threading.Tasks;
using Tgs.Payment.ApplePay.Repositories.Entities;

namespace Tgs.Payment.ApplePay.Repositories
{
    internal class TgsRepository : ITgsRepository
    {
        private readonly TgsContext _dbContext;
        private readonly ApplePaySerializer _serializer;

        public TgsRepository(TgsContext dbContext, ApplePaySerializer serializer)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        public async ValueTask<DepositFormInfo> GetDepositFormByIdAsync(Guid id)
        {
            var data = await _dbContext.DepositForms.FindAsync(id).ConfigureAwait(false);

            return new DepositFormInfo(
               data.Id,
               data.PlayerCode,
               data.BrandId,
               data.BrandPaymentId,
               data.Amount,
               data.Status,
               _serializer.Deserialize<ApplePayDepositApplyInfo>(data.ApplyInfo!),
               data.PaymentReturn);
        }

        public async ValueTask<WithdrawFormInfo> GetWithdrawFormByIdAsync(Guid id)
        {
            var data = await _dbContext.WithdrawForms.FindAsync(id).ConfigureAwait(false);

            return new WithdrawFormInfo(
                data.Id,
                data.PlayerCode,
                data.BrandId,
                data.BrandPaymentId,
                data.Amount,
                data.Status,
                data.BankInfoId,
                data.BankInfo,
                _serializer.Deserialize<ApplePayWithdrawApplyInfo>(data.ApplyInfo!),
                data.PaymentReturn);
        }

        public async ValueTask SaveDepositReturnAsync(Guid id, ApplePayDepositReturn depositReturn)
        {
            var form = await _dbContext.DepositForms
                .FindAsync(id)
                .ConfigureAwait(false);

            form.Status = 1000;
            form.ActualAmount = decimal.Parse(depositReturn.ReceiveInMoney);
            form.PaymentReturn = _serializer.Serialize(depositReturn);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async ValueTask SaveWithdrawReturnAsync(Guid id, ApplePayWithdrawReturn withdrawReturn)
        {
            var form = await _dbContext.WithdrawForms
                .FindAsync(id)
                .ConfigureAwait(false);

            form.PaymentReturn = _serializer.Serialize(withdrawReturn);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}