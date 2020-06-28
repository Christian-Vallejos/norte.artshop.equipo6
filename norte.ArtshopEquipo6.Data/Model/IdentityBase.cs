using System;
using System.ComponentModel.DataAnnotations;

namespace norte.ArtshopEquipo6.Data.Model
{
    public class IdentityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        [Required]
        public DateTime ChangedOn { get; set; }
        public string ChangedBy { get; set; }
    }
}