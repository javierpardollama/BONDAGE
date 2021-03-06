﻿using System;
using System.ComponentModel.DataAnnotations;

using Bondage.Tier.Entities.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace Bondage.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="ApplicationUserClaim"/> class. Implements <see cref="IdentityUserClaim{int}"/>, <see cref="IKey"/>, <see cref="IBase"/>
    /// </summary>
    public partial class ApplicationUserClaim : IdentityUserClaim<int>, IKey, IBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ApplicationUserClaim"/>
        /// </summary>
        public ApplicationUserClaim()
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
        /// Gets or Sets <see cref="ApplicationUser"/>
        /// </summary>
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}