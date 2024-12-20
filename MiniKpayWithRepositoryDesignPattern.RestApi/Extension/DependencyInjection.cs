﻿namespace MiniKpayWithRepositoryDesignPattern.RestApi.Extension;

#region DependencyInjection

public static class DependencyInjection
{

    #region AddDependencyInjection

    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
    {
        return services
            .AddDbContextService(builder)
            .AddDataAccessService()
            .AddBusinessLogicService();
    }

    #endregion

    #region AddDbContextService

    private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services
         .AddDbContext<AppDbContext>(opt =>
         {
             opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
         },
            ServiceLifetime.Transient, ServiceLifetime.Transient)
    
         .AddControllers().AddJsonOptions(opt =>
         {
             opt.JsonSerializerOptions.PropertyNamingPolicy = null;
         });

        return services;

       
    }

    #endregion

    #region AddDataAccessService

    private static IServiceCollection AddDataAccessService(this IServiceCollection services)
    {
        return services
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IWithdrawRepository, WithdrawRepository>()
        .AddScoped<IDepositRepository, DepositRepository>()
        .AddScoped<ITransactionRepository, TransationRepository>();
    }

    #endregion

    #region AddBusinessLogicService

    private static IServiceCollection AddBusinessLogicService(this IServiceCollection services)
    {
        return services
            .AddScoped<BL_User>()
            .AddScoped<BL_Withdraw>()
            .AddScoped<BL_Deposit>()
            .AddScoped<BL_Transaction>();
            
            
    }

    #endregion

}

#endregion