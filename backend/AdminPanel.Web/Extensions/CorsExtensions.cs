namespace AdminPanel.Web.Extensions;

public static class CorsExtensions
{
    private const string AllowAllPolicy = "AllowAll";
    
    public static IServiceCollection AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(AllowAllPolicy, policyBuilder =>
            {
                policyBuilder.SetIsOriginAllowed(_ => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }
    
    public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app)
    {
        app.UseCors(AllowAllPolicy);
        return app;
    }
}