using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JoyMoe.Common.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tgs.Payment.ApplePay.Services;
using Tgs.Payment.ApplePay.ViewModels;
using TGS.ServiceUtility;

namespace Tgs.Payment.ApplePay.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly ILogger<DepositController> _logger;

        public DepositController(
            ILogger<DepositController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("callback")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<CallbackConfirmViewModel> DepositCallback(
            [FromServices] IGetService<GetDepositFormQuery, DepositFormInfo> getDepositFormService,
            [FromServices] ICommandService<SaveDepositReturnCommand> saveReturnService,
            [FromForm] CallbackDepositViewModel request,
            [FromForm] IFormCollection form)
        {
            foreach (var p in form)
                Console.WriteLine($"{p.Key}: {p.Value}");

            Console.WriteLine("======================================================================");

            //Console.WriteLine($"receive_id:{request.receive_id}");
            //Console.WriteLine($"receive_state:{request.receive_state}");
            //Console.WriteLine($"receive_type:{request.receive_type}");
            //Console.WriteLine($"receive_tradeno:{request.receive_tradeno}");
            //Console.WriteLine($"receive_money:{request.receive_money}");
            //Console.WriteLine($"receive_inmoney:{request.receive_inmoney}");
            //Console.WriteLine($"receive_inname:{request.receive_inname}");
            //Console.WriteLine($"receive_inbankname:{request.receive_inbankname}");
            //Console.WriteLine($"receive_inbanknum:{request.receive_inbanknum}");
            //Console.WriteLine($"receive_location:{request.receive_location}");
            //Console.WriteLine($"receive_inbankfullname:{request.receive_inbankfullname}");
            //Console.WriteLine($"receive_qrcode_url:{request.receive_qrcode_url}");
            //Console.WriteLine($"receive_trans_bankname:{request.receive_trans_bankname}");
            //Console.WriteLine($"receive_trans_name:{request.receive_trans_name}");
            //Console.WriteLine($"receive_trans_banknum:{request.receive_trans_banknum}");
            //Console.WriteLine($"receive_trans_branchname:{request.receive_trans_branchname}");
            //Console.WriteLine($"receive_regdate:{request.receive_regdate}");
            //Console.WriteLine($"receive_update:{request.receive_update}");
            //Console.WriteLine($"check:{request.check}");
            //Console.WriteLine($"result:{request.result}");
            //Console.WriteLine($"check2:{request.check2}");
            //Console.WriteLine("==================================================================");

            var depositForm = await getDepositFormService
                .GetAsync(new GetDepositFormQuery(request.receive_tradeno))
                .ConfigureAwait(false);

            var callbackMessage = new ApplePayReturn()
            {
                ReceiveId = request.receive_id,
                ReceiveMoney = request.receive_money,
                ReceiveInBankFullName = request.receive_inbankfullname,
                ReceiveInBankname = request.receive_inbankname,
                ReceiveInBankNum = request.receive_inbanknum,
                ReceiveLocation = request.receive_location,
                ReceiveInMoney = request.receive_inmoney,
                ReceiveInName = request.receive_inname,
                ReceiveQrcodeUrl = request.receive_qrcode_url,
                ReceiveRegdate = request.receive_regdate,
                ReceiveState = request.receive_state,
                ReceiveTradeNo = request.receive_tradeno,
                ReceiveTransBankName = request.receive_trans_bankname,
                ReceiveTransBankNum = request.receive_trans_banknum,
                ReceiveTransBranchName = request.receive_trans_branchname,
                ReceiveTransName = request.receive_trans_name,
                ReceiveType = request.receive_type,
                ReceiveUpdate = request.receive_update,
                Result = request.result,
                Check = request.check,
                Check2 = request.check2
            };

            await saveReturnService
                .ExecuteAsync(new SaveDepositReturnCommand(depositForm.Id, callbackMessage))
                .ConfigureAwait(false);

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance
            };

            _logger.LogInformation(JsonSerializer.Serialize(callbackMessage, jsonSerializerOptions));

            return new CallbackConfirmViewModel
            {
                Status = "success"
            };
        }
    }
}