using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Bondage.Tier.Entities.Interfaces;

namespace Bondage.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="Break"/> class. Implements <see cref="IKey"/>, <see cref="IBase"/>
    /// </summary>
    public partial class Break : IKey, IBase
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="Break"/>
        /// </summary>
        public Break()
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
        /// Gets or Sets <see cref="Start"/>
        /// </summary>
        [Required]
        public DateTime? Start { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Finish"/>
        /// </summary>
        [Required]
        public DateTime? Finish { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Active"/>
        /// </summary>
        [Required]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Effort"/>
        /// </summary>
        [Required]
        public virtual Effort Effort { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Kind"/>
        /// </summary>
        [Required]
        public virtual Kind Kind { get; set; }
    }
}
