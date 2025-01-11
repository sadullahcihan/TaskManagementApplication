using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Application.Services.Repositories;
using Persistence.Repositories;

using Npgsql.EntityFrameworkCore.PostgreSQL;


namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("BaseDb")));

        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());


        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDutyRepository, DutyRepository>();
        return services;
    }
}
