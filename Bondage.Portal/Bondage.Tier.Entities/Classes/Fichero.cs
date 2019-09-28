using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bondage.Tier.Entities.Interfaces;

namespace Bondage.Tier.Entities.Classes
{
    public class Fichero : IKey, IBase
    {
        public Fichero()
        {
        }

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime LastModified { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual Fichero Parent { get; set; }

        [Required]
        public bool Carpeta { get; set; }

        public byte[] Data { get; set; }

        [Required]
        public virtual ApplicationUser By { get; set; }

        [Required]
        public string ImageUri { get; set; }
    }
}
