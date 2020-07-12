using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace norte.ArtshopEquipo6.Data.Model
{
   public class Product : IdentityBase
    {

        [Required]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Artista")]
        public int ArtistId { get; set; }

       
        [Display(Name = "Imagen")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public double  Price{ get; set; }

        [Display(Name = "Cantidad Vendida")]
        public int QuantitySold { get; set; }

        [Display(Name = "Estrellas Promedio")]
        public double AvgStars { get; set; }

        public virtual Artist Artist { get; set; }

    }
}
