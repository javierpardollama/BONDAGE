using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Bondage.Tier.Entities.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Bondage.Tier.Entities.Classes
{
    public partial class ApplicationUser : IdentityUser<int>, IKey, IBase
    {
        public ApplicationUser()
        {
        }

        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public virtual ICollection<ApplicationUserClaim> ApplicationUserClaims { get; set; }

        public virtual ICollection<ApplicationUserLogin> ApplicationUserLogins { get; set; }

        public virtual ICollection<ApplicationUserToken> ApplicationUserTokens { get; set; }

        public virtual ICollection<Effort> Endeavours { get; set; }
    }
}
