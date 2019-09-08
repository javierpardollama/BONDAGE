using Bondage.Tier.ExceptionHandling.Middlewares;

using Microsoft.AspNetCore.Builder;

namespace Bondage.Tier.Web.Extensions
{
    public static class ExceptionsExtension
    {
        public static void UseCustomizedExceptionMiddlewares(this IApplicationBuilder @this)
        {
            @this.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
