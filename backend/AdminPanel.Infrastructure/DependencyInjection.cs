using System.Text;
using AdminPanel.Application.Abstractions.Authentication;
using AdminPanel.Domain.Accounts;
using AdminPanel.Domain.Clients;
using AdminPanel.Domain.Payments;
using AdminPanel.Domain.Rates;
using AdminPanel.Domain.RefreshTokens;
using AdminPanel.Infrastructure.Authentication;
using AdminPanel.Infrastructure.DataAccess;
using AdminPanel.Infrastructure.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AdminPanel.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddStorageServices(services, configuration);
        AddAuthenticationServices(services, configuration);
        services.AddAuthorization();
    }
    
    public static void ApplyPendingMigrations(this IServiceProvider serviceProvider)
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();
    }
    
    private static void AddStorageServices(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
                               ?? throw new InvalidOperationException("Connection string not found");
        
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IRateRepository, RateRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
    }
    
    private static void AddAuthenticationServices(IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptionsConfiguration = configuration.GetSection("JwtOptions");
        services.Configure<JwtOptions>(jwtOptionsConfiguration);
        
        var jwtOptions = jwtOptionsConfiguration.Get<JwtOptions>() 
                         ?? throw new InvalidOperationException("JwtOptions not found");
        
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IAccountContext, AccountContext>();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireSignedTokens = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.AccessTokenSettings.Issuer,
                    ValidAudience = jwtOptions.AccessTokenSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.AccessTokenSettings.Key)),
                    ClockSkew = TimeSpan.FromMinutes(0)
                };
            });
    }
}