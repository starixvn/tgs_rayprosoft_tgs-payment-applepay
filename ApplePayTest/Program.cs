using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tgs.Payment.ApplePay;

namespace ApplePayTest
{
    internal class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddNatsMessageQueue(config => { });
                    services.AddPaymentClient();
                    services
                        .AddSystemJsonSerializer()
                        .AddSingleton<ApplePaySerializer>();
                    services.AddHostedService<Demo>();
                });

        private static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}