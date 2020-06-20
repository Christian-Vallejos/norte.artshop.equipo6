using norte.ArtshopEquipo6.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.ArtshopEquipo6.Data.Services
{
    public interface IArtistaData
    {
        IEnumerable<Artista> GetArtistas();

        bool AddArtista(Artista art);

    }
}
