using System;
using System.Text.Json;
using System.Threading.Tasks;
using Tgs.Payment.ApplePay.Repositories.Entities;


namespace Tgs.Payment.ApplePay.Repositories
{
    internal class TgsRepository : ITgsRepository
    {
        private readonly TgsContext _dbContext;

        public TgsRepository(TgsContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
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
               JsonSerializer.Deserialize<ApplePayDepositApplyInfo>(data.ApplyInfo!),
               data.PaymentReturn);
        }
        public async ValueTask SaveDepositReturnAsync(Guid id, ApplePayReturn depositReturn)
        {
            var form = await _dbContext.DepositForms
                .FindAsync(id)
                .ConfigureAwait(false);

            form.Status = 1000;
            form.ActualAmount = decimal.Parse(depositReturn.ReceiveInMoney);
            form.PaymentReturn = JsonSerializer.Serialize(depositReturn);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}