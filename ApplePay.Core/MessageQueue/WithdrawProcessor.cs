using System;
using System.Threading;
using System.Threading.Tasks;
using Tgs.MessageQueue;

namespace Tgs.Payment.ApplePay.MessageQueue
{
    internal class WithdrawProcessor : IMessageProcessor
    {
        public WithdrawProcessor()
        {

        }
        public ValueTask<byte[]> HandleAsync(byte[] data, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}