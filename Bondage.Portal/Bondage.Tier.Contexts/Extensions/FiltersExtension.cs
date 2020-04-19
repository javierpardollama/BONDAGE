using Bondage.Tier.Entities.Classes;

using Microsoft.EntityFrameworkCore;

namespace Bondage.Tier.Contexts.Extensions
{
    public static class FiltersExtension
    {
        public static void AddCustomizedFilters(this ModelBuilder @this)
        {
            // Configure entity filters      
            @this.Entity<ApplicationRole>().HasQueryFilter(p => !p.Deleted);
            @this.Entity<ApplicationRoleClaim>().HasQueryFilter(p => !p.Deleted);
            @this.Entity<ApplicationUser>().HasQueryFilter(p => !p.Deleted);
            @this.Entity<ApplicationUserClaim>().HasQueryFilter(p => !p.Deleted);
            @this.Entity<ApplicationUserLogin>().HasQueryFilter(p => !p.Deleted);
            @this.Entity<ApplicationUserRole>().HasQueryFilter(p => !p.Deleted);
            @this.Entity<ApplicationUserToken>().HasQueryFilter(p => !p.Deleted);
        }
    }
}
