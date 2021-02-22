using Bondage.Tier.Services.Classes;
using Bondage.Tier.Services.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace Bondage.Tier.Web.Extensions
{
    /// <summary>
    /// Represents a <see cref="ServicesExtension"/> class.
    /// </summary>
    public static class ServicesExtension
    {
        /// <summary>
        /// Extends Customized Services
        /// </summary>
        /// <param name="this">Injected <see cref="IServiceCollection"/></param>
        public static void AddCustomizedServices(this IServiceCollection @this)
        {
            @this.AddTransient<ITokenService, TokenService>();
            @this.AddTransient<IAuthService, AuthService>();
            @this.AddTransient<ISecurityService, SecurityService>();
            @this.AddTransient<IEffortService, EffortService>();
            @this.AddTransient<IGradeService, GradeService>();
            @this.AddTransient<IKindService, KindService>();
            @this.AddTransient<IMonthService, MonthService>();
            @this.AddTransient<IYearService, YearService>();
            @this.AddTransient<ICalendarService, CalendarService>();
            // Add other services here
        }
    }
}
