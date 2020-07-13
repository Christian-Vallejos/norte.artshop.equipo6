using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.ArtshopEquipo6.Data.Model
{
    public class Cart : IdentityBase
    {
        public string UserId { get; set; }

        [Display(Name = "Fecha de Compra")]
        public DateTime CartDate { get; set; }
        [Display(Name = "Cantidad Comprada")]
        public int ItemCount { get; set; }
 
        public string Comprado { get; set; }

        public List<CartItem> Items { get; set; }

    }
}
