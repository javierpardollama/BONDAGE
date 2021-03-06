﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Bondage.Tier.Entities.Interfaces;

namespace Bondage.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="Effort"/> class. Implements <see cref="IKey"/>, <see cref="IBase"/>
    /// </summary>
    public partial class Effort : IKey, IBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="Effort"/>
        /// </summary>
        public Effort()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Id"/>
        /// </summary>
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="LastModified"/>
        /// </summary>
        [Required]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Start"/>
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Finish"/>
        /// </summary>
        public DateTime? Finish { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Deleted"/>
        /// </summary>
        [Required]
        public bool Deleted { get; set; }

        /// <summary>
        ///  Gets or Sets <see cref="ApplicationUser"/>
        /// </summary>
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        ///  Gets or Sets <see cref="Kind"/>
        /// </summary>
        [Required]
        public virtual Kind Kind { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Active"/>
        /// </summary>
        [Required]
        public bool Active { get; set; }
    }
}
