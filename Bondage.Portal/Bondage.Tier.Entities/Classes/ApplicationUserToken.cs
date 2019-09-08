using System;
using System.ComponentModel.DataAnnotations;

using Bondage.Tier.Entities.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Bondage.Tier.Entities.Classes
{
    public partial class ApplicationUserToken : IdentityUserToken<int>, IBase
    {
        public ApplicationUserToken()
        {
        }

        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
