using Bondage.Tier.Services.Classes;
using Bondage.Tier.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Bondage.Tier.Web.Extensions
{
    public static class ServicesExtension
    {
        public static void AddCustomizedServices(this IServiceCollection @this)
        {
            @this.AddTransient<ITokenService, TokenService>();
            @this.AddTransient<IAuthService, AuthService>();
            @this.AddTransient<ISecurityService, SecurityService>();
            @this.AddTransient<IEffortService, EffortService>();
            // Add other services here
        }
    }
}
