﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Bondage.Tier.Entities.Interfaces;

namespace Bondage.Tier.Entities.Classes
{
    public partial class Kind : IKey, IBase
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public bool Deleted { get; set; }

        [Required]
        public string Name { get; set; }
    }
}