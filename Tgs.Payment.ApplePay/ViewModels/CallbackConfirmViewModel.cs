using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tgs.Payment.ApplePay.ViewModels
{
    public class CallbackConfirmViewModel
    {
        public string Message { get; init; } = string.Empty;

        public string Status { get; init; } = default!;
    }
}
