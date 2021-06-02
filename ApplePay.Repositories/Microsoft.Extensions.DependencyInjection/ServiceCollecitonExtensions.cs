using System;
using Microsoft.EntityFrameworkCore;
using Tgs.Payment.ApplePay;
using Tgs.Payment.ApplePay.Repositories;
using Tgs.Payment.ApplePay.Repositories.Entities;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollecitonExtensions
    {
        public static IServiceCollection AddApplePayRepositories(
            this IServiceCollection services,
            Action<IServiceProvider, DbContextOptionsBuilder> configure,
            int poolSize = 128)
        {
            return services
            .AddDbContext<TgsContext>(configure)
            .AddTransient<ITgsRepository, TgsRepository>();
        }
    }
}