﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Bondage.Tier.Entities.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Bondage.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="ApplicationUser"/> class. Implements <see cref="IdentityUser{int}"/>, <see cref="IKey"/>, <see cref="IBase"/>
    /// </summary>
    public partial class ApplicationUser : IdentityUser<int>, IKey, IBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ApplicationUser"/>
        /// </summary>
        public ApplicationUser()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="LastModified"/>
        /// </summary>
        [Required]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Deleted"/>
        /// </summary>
        [Required]
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserRoles"/>
        /// </summary>
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserClaims"/>
        /// </summary>
        public virtual ICollection<ApplicationUserClaim> ApplicationUserClaims { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserLogins"/>
        /// </summary>
        public virtual ICollection<ApplicationUserLogin> ApplicationUserLogins { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUserTokens"/>
        /// </summary>
        public virtual ICollection<ApplicationUserToken> ApplicationUserTokens { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Efforts"/>
        /// </summary>
        public virtual ICollection<Effort> Efforts { get; set; }
    }
}
