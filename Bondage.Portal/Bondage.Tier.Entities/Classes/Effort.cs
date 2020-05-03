using System;
using System.Collections.Generic;
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
        ///  Gets or Sets <see cref="Breaks"/>
        /// </summary>
        public virtual ICollection<Break> Breaks { get; set; }
    }
}
