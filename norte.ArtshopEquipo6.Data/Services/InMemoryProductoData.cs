using norte.ArtshopEquipo6.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace norte.ArtshopEquipo6.Data.Services
{
    public class InMemoryProductoData : IProductoData

    {
        private List<Producto> productos;
        private Random randomize;

        public InMemoryProductoData() {
             randomize = new Random();
            productos = new List<Producto>();
            productos.Add(new Producto()
            {
                ArtistId = 1,
                Id = 1,
                Title = "El Grito",
                AvgStars = 3,
                Description = "Imitacion de cuadro clasico calidad premium",
                Image = "futura imagen",
                Price = 3500,
                QuantitySold = 3,
                ChangedOn = DateTime.Now,
                CreatedBy = "Test",
                CreatedOn = DateTime.Now,
                ChangedBy = "Test"
            });
        }
        
        
        
        public bool AddProducto(Producto prod)
        {
            try
            {
                this.productos.Add(prod);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Producto> GetProductos()
        {
            return productos;
        }
    }
}
