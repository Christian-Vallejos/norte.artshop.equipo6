using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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
        public float  Price{ get; set; }

        [Display(Name = "Cantidad Vendida")]
        public int QuantitySold { get; set; }

        [Display(Name = "Estrellas Promedio")]
        public float AvgStars { get; set; }

        public virtual Artist Artist { get; set; }

    }
}
