using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.ArtshopEquipo6.Data.Model
{
    public class CartItem : IdentityBase
    {

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
