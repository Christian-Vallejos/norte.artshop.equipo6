using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.ArtshopEquipo6.Data.Model
{
   public class Producto : IdentityBase
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ArtistId { get; set; }

        public string Image { get; set; }
        public float  Price{ get; set; }
       
        public int QuantitySold { get; set; }

        public float AvgStars { get; set; }
/*
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public string ChangedBy { get; set; }

*/
        public virtual Artista Artista { get; set; }
    }
}
