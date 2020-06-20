using norte.ArtshopEquipo6.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.ArtshopEquipo6.Data.Services
{
    public class InMemoryArtistaData : IArtistaData
    {
        private List<Artista> artistas;

        public InMemoryArtistaData() {

            artistas = new List<Artista>();
            artistas.Add(new Artista() { Id = 1, ChangedBy="User 1",ChangedOn=DateTime.Now, Country="Argentina",
                CreatedBy="Test",CreatedOn=DateTime.Now, Description="Artista n 1",FirstName="Carlos", LastName="Bianchi",LifeSpan="span",TotalProducts=1
            });
            artistas.Add(new Artista() { Id = 2, ChangedBy="User 2",ChangedOn=DateTime.Now, Country="Argentina",
                CreatedBy="Test",CreatedOn=DateTime.Now, Description="Artista n 2",FirstName="Marcelo", LastName="Gallardo",LifeSpan="span",TotalProducts=2
            });
            artistas.Add(new Artista() { Id = 3, ChangedBy="User 3",ChangedOn=DateTime.Now, Country="Argentina",
                CreatedBy="Test",CreatedOn=DateTime.Now, Description="Artista n 3",FirstName="Maria", LastName="Dali",LifeSpan="span",TotalProducts=3
            });
            artistas.Add(new Artista() { Id = 4, ChangedBy="User 4",ChangedOn=DateTime.Now, Country="Argentina",
                CreatedBy="Test",CreatedOn=DateTime.Now, Description="Artista n 4",FirstName="Luciana", LastName="Piccasso",LifeSpan="span",TotalProducts=4
            });
        }

        public IEnumerable<Artista> GetArtistas()
        {
            return artistas.OrderBy(a=> a.Id);
        }


        public bool AddArtista(Artista art)
        {
            try
            {
                this.artistas.Add(art);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
