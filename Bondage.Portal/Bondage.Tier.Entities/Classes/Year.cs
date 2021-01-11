using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Bondage.Tier.Entities.Interfaces;

namespace Bondage.Tier.Entities.Classes
{
    /// <summary>
    /// Represents a <see cref="Year"/> class. Implements <see cref="IKey"/>, <see cref="IBase"/>
    /// </summary>
    public class Year
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="Year"/>
        /// </summary>
        public Year() 
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
        /// Gets or Sets <see cref="Number"/>
        /// </summary>
        public int Number { get; set; }
    }
}
