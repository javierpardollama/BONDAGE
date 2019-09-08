using System;
using System.ComponentModel.DataAnnotations;

namespace Bondage.Tier.Entities.Interfaces
{
    public interface IBase
    {
        [Required]
        DateTime LastModified { get; set; }

        [Required]
        bool Deleted { get; set; }
    }
}
