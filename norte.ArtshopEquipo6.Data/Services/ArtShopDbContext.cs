using norte.ArtshopEquipo6.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.ArtshopEquipo6.Data.Services
{
    public partial class ArtShopDbContext : DbContext
    {
        public ArtShopDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<ArtShopDbContext>(null);
        }
        /// <summary>
        /// PluralizingTableNameConvention
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        /// DbSet Artist se utiliza para representar una tabla.
        public virtual DbSet<Artist> Artist { get; set; }

        /// DbSet Product se utiliza para representar una tabla.
        public virtual DbSet<Product> Product { get; set; }
        /// DbSet Product se utiliza para representar una tabla.
        public virtual DbSet<Error> Error { get; set; }

        public virtual DbSet<CartItem> CartItem { get; set; }

        public virtual DbSet<Cart> Cart { get; set; }

    }
}
