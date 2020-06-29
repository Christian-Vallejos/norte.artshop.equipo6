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
        private List<Product> productos;
        private Random randomize;

        public InMemoryProductoData() {
             randomize = new Random();
            productos = new List<Product>();
            productos.Add(new Product()
            {
                ArtistId = 1,
                Id = 1,
                Title = "El Grito",
                AvgStars = 3,
                Description = "Calidad Premium",
                Image = "/Content/img/el-grito.png",
                Price = 3500,
                QuantitySold = 3,
                ChangedOn = DateTime.Now,
                CreatedBy = "Test",
                CreatedOn = DateTime.Now,
                ChangedBy = "Test"
            });

            productos.Add(new Product()
            {
                ArtistId = 1,
                Id = 2,
                Title = "La Persistencia",
                AvgStars = 3,
                Description = "Clasico inigualable",
                Image = "/Content/img/la-persistencia.jpg",
                Price = 3500,
                QuantitySold = 3,
                ChangedOn = DateTime.Now,
                CreatedBy = "Test",
                CreatedOn = DateTime.Now,
                ChangedBy = "Test"
            });

            productos.Add(new Product()
            {
                ArtistId = 1,
                Id = 3,
                Title = "La Persistencia",
                AvgStars = 5,
                Description = "Clasico - Impresionista",
                Image = "/Content/img/noche.jpg",
                Price = 3500,
                QuantitySold = 30,
                ChangedOn = DateTime.Now,
                CreatedBy = "Test",
                CreatedOn = DateTime.Now,
                ChangedBy = "Test"
            });

        }
        
        
        
        public bool AddProducto(Product prod)
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

        public IEnumerable<Product> GetProductos()
        {
            return productos;
        }
    }
}
