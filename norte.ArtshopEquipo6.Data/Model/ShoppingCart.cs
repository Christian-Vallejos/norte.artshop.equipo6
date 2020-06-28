using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.ArtshopEquipo6.Data.Model
{
    public class ShoppingCart
    {
        public List<Producto> Productos { get; set; }


        public double ValorFinal { get {
                return this.Productos.Select(x => x.Price).ToList().Sum();
                    } }



    }
}
