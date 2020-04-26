using Bondage.Tier.Settings.Classes;

using Microsoft.Extensions.DependencyInjection;

namespace Bondage.Tier.Web.Extensions
{
    public static class CrossOriginRequestsExtension
    {
        public static void AddCustomizedCrossOriginRequests(this IServiceCollection @this, JwtSettings @jwtSettings)
        {
            @this.AddCors(options =>
            {
                options.AddPolicy("Authentication", builder =>
                {
                    builder.WithOrigins(@jwtSettings.JwtAudience).AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });
        }
    }
}
