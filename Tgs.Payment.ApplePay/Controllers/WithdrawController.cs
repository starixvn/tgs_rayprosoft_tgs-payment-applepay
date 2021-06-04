using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tgs.Payment.ApplePay.Services;
using Tgs.Payment.ApplePay.ViewModels;
using TGS.ServiceUtility;

namespace Tgs.Payment.ApplePay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {
        private readonly ILogger<WithdrawController> _logger;

        public WithdrawController(
            ILogger<WithdrawController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("callback")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<CallbackConfirmViewModel> WithdrawCallback(
            [FromServices] IOptions<JsonOptions> jsonOptionsAccessor,
            [FromServices] IGetService<GetWithdrawFormQuery, WithdrawFormInfo> getWithdrawFormService,
            [FromServices] ICommandService<SaveWithdrawReturnCommand> saveReturnService,
            [FromForm] CallbackWithdrawViewModel request)
        {
            var jsonSerializerOptions = jsonOptionsAccessor.Value.JsonSerializerOptions;

            var withdrawForm = await getWithdrawFormService
                .GetAsync(new GetWithdrawFormQuery(request.pay_tradeno))
                .ConfigureAwait(false);

            var callbackMessage = new ApplePayWithdrawReturn()
            {
                Result = request.result,
                PayRate = request.pay_rate,
                PayBase = request.pay_base,
                PayFee = request.pay_fee,
                PayId = request.pay_id,
                PayInBankFullName = request.pay_inbankfullname,
                PayInBankName = request.pay_inbankname,
                PayInBankNum = request.pay_inbanknum,
                PayInName = request.pay_inname,
                PayLocation = request.pay_location,
                PayMoney = request.pay_money,
                PayRegDate = request.pay_regdate,
                PayState = request.pay_state,
                PayTradeNo = request.pay_tradeno,
                PayType = request.pay_type,
                PayUpdate = request.pay_update,
                Check = request.check,
                Check2 = request.check2
            };

            await saveReturnService
                .ExecuteAsync(new SaveWithdrawReturnCommand(withdrawForm.Id, callbackMessage))
                .ConfigureAwait(false);

            _logger.LogInformation(JsonSerializer.Serialize(callbackMessage, jsonSerializerOptions));

            return new CallbackConfirmViewModel
            {
                Status = "success"
            };
        }
    }
}