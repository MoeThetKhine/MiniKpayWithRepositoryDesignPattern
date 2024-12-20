using Microsoft.EntityFrameworkCore;
using MiniKpayWithRepositoryDesignPattern.Database.Models;
using MiniKpayWithRepositoryDesignPattern.Repository.Features.Deposit;
using MiniKpayWithRepositoryDesignPattern.Repository.Features.Transaction;
using MiniKpayWithRepositoryDesignPattern.Repository.Features.User;
using MiniKpayWithRepositoryDesignPattern.Repository.Features.Withdraw;

namespace MiniKpayWithRepositoryDesignPattern.RestApi.Extension;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
    {
        return services
            .AddDbContextService(builder)
            .AddDataAccessService()
            .AddBusinessLogicService();
    }
    private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services
         .AddDbContext<AppDbContext>(opt =>
         {
             opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
         })
         .AddControllers().AddJsonOptions(opt =>
         {
             opt.JsonSerializerOptions.PropertyNamingPolicy = null;
         });

        return services;
    }

    private static IServiceCollection AddDataAccessService(this IServiceCollection services)
    {
        return services
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IWithdrawRepository, WithdrawRepository>()
        .AddScoped<IDepositRepository, DepositRepository>()
        .AddScoped<ITransactionRepository, TransationRepository>();

    }

    private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
    {
        return services
            .AddScoped<BL_Transaction>()
            .AddScoped<BL_User>()
            .AddScoped<BL_Withdraw>()
            .AddScoped<BL_Deposit>();

    }

}
