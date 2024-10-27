using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Npgsql;
using Persistence.Contracts;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddOptions<NpgsqlConnectionStringBuilder>().BindConfiguration("Postgres");
        services.AddDbContextPool<AppDbContext>((sp, options) =>
        {
            var npgsqlConnectionStringBuilderOptions = sp.GetRequiredService<IOptions<NpgsqlConnectionStringBuilder>>();
            var npgsqlConnectionStringBuilder = npgsqlConnectionStringBuilderOptions.Value;
            var connectionString = npgsqlConnectionStringBuilder.ConnectionString;
            options
                .UseSnakeCaseNamingConvention()
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseNpgsql(connectionString, ob =>
                {
                    ob.MigrationsAssembly("Persistence");
                    ob.MigrationsHistoryTable(
                        HistoryRepository.DefaultTableName,
                        npgsqlConnectionStringBuilder.SearchPath);
                });
        });
        
        services.AddScoped<DbContext>(sp => sp.GetRequiredService<AppDbContext>());
        services.AddScoped<DbContextAdapter>();
        services.AddScoped<IDbContext>(sp => sp.GetRequiredService<DbContextAdapter>());
        services.AddScoped<IMigrationContext>(sp => sp.GetRequiredService<DbContextAdapter>());
        services.AddScoped<ITransactionContext>(sp => sp.GetRequiredService<DbContextAdapter>());
        
        return services;
    }
}