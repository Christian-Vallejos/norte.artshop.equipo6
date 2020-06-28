using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace norte.ArtshopEquipo6.Data.Model
{

    //public class Artista
    //   {
    //	public int Id { get; set; }
    //	public string FirstName { get; set; }

    //	public string LastName { get; set; }

    //	public string LifeSpan { get; set; }

    //	public string Country { get; set; }

    //	public string Description { get; set; }
    //	public int TotalProducts { get; set; }
    //	public DateTime CreatedOn { get; set; }
    //	public string CreatedBy { get; set; }		
    //	public DateTime ChangedOn { get; set; }
    //	public string ChangedBy { get; set; }
    //	}

    public class Artista : IdentityBase
    {
        public Artista()
        {
            this.Products = new HashSet<Producto>();
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
        public virtual ICollection<Producto> Products { get; set; }

    }
}
