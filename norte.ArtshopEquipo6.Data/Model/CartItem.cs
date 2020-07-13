using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.ArtshopEquipo6.Data.Model
{
    public class CartItem : IdentityBase
    {
        [Display(Name = "Id De Compra")]
        public int CartId { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "Precio")]
        public decimal Price { get; set; }
       
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
      
        [Display(Name = "Producto")]
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
