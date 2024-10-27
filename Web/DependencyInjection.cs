using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Minio;
using Web.Middlewares;
using Web.Options;

namespace Web;

internal static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        if (!EF.IsDesignTime)
        {
            services.AddOptions<MinioOptions>().BindConfiguration("MinioOptions");
            services.AddMinio(s =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var minioOptionsSnapshot = serviceProvider.GetRequiredService<IOptionsSnapshot<MinioOptions>>();
                var minioOptions = minioOptionsSnapshot.Value;
            
                s.WithCredentials(minioOptions.AccessKey, minioOptions.SecretKey);
                s.WithEndpoint(minioOptions.Endpoint);
                s.WithSSL(minioOptions.Ssl);
            });   
        }
        else
        {
            services.AddSingleton<IMinioClient>(s => new MinioClient());
        }
        
        services.AddTransient<TimeProvider>(s => TimeProvider.System);
        
        services.AddHsts(static configureOptions =>
        {
            configureOptions.Preload = true;
            configureOptions.IncludeSubDomains = true;
            configureOptions.MaxAge = TimeSpan.FromDays(60);
        });
        
        services.AddHttpsRedirection(static options =>
        {
            options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
            options.HttpsPort = 443;
        });

        services.AddHealthChecks();

        services.AddScoped<TransactionMiddleware>();
        services.AddControllers();
        
        return services;
    }
}