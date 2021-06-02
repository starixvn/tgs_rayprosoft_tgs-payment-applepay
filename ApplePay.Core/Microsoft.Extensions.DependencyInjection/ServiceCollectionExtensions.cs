using System;
using System.Reflection;
using Microsoft.Extensions.Options;
using Tgs.Payment.ApplePay;
using Tgs.Payment.ApplePay.MessageQueue;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplePay(this IServiceCollection services, Action<ApplePayOptions, IServiceProvider> configure)
            => services
                .AddOptions<ApplePayOptions>()
                .Configure(configure)
                .Services
                .AddHttpClient<ApplePayClient>()
                .ConfigureHttpClient((sp, httpClient) =>
                {
                    var options = sp.GetRequiredService<IOptions<ApplePayOptions>>().Value;

                    httpClient.BaseAddress = options.PaymentApiUrl;
                })
                .Services
                .RegisterAllServiceUtilityTypes(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient)
                .AddTransient<ApplePayHasher>()
                .AddSingleton<ApplePaySerializer>()
                .AddNatsMessageQueue(config =>
                {
                    config
                        .ConfigQueueOptions((options, sp) =>
                        {
                            var applePayOptions = sp.GetRequiredService<IOptions<ApplePayOptions>>().Value;

                            options.Url = applePayOptions.NatsUrl;
                        })
                        .AddProcessor<DepositProcessor>("tgs.payment.applepay.deposit", "tgs.payment.applepay.deposit")
                        .AddProcessor<WithdrawProcessor>("tgs.payment.applepay.withdraw", "tgs.payment.applepay.withdraw");
                });
    }
}