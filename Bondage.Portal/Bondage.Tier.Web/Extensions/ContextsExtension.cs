using Bondage.Tier.Contexts.Classes;
using Bondage.Tier.Contexts.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Bondage.Tier.Web.Extensions
{
    public static class ContextsExtension
    {
        public static void AddCustomizedContexts(this IServiceCollection @this)
        {
            @this.AddScoped<IApplicationContext, ApplicationContext>();

            // Add other services here
        }
    }
}
