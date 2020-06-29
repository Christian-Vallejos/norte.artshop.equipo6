using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace norte.ArtshopEquipo6.Data.Model
{


    public class Artist : IdentityBase
    {
        public Artist()
        {
            this.Products = new HashSet<Product>();
        }

        [Required]
        [DisplayName("Nombre")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Apellido")]
        public string LastName { get; set; }

        public string LifeSpan { get; set; }

        [Required]
        [DisplayName("País")]
        public string Country { get; set; }

        [DisplayName("Descripción")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Recetas")]
        public int TotalProducts { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
        public virtual ICollection<Product> Products { get; set; }

    }
}
