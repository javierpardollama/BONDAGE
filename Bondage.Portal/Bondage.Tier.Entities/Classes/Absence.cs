using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Bondage.Tier.Entities.Interfaces;

namespace Bondage.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="Absence"/> class. Implements <see cref="IKey"/>, <see cref="IBase"/>
    /// </summary>
    public class Absence : IKey, IBase
    {
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
        /// Gets or Sets <see cref="Date"/>
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        ///  Gets or Sets <see cref="ApplicationUser"/>
        /// </summary>
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        ///  Gets or Sets <see cref="Grade"/>
        /// </summary>
        [Required]
        public virtual Grade Grade { get; set; }
    }
}
