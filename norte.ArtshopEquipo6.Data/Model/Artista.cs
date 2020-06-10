using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.ArtshopEquipo6.Data.Model
{

	public class Artista
    {
		public int Id { get; set; }
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string LifeSpan { get; set; }

		public string Country { get; set; }

		public string Description { get; set; }
		public int TotalProducts { get; set; }
		public DateTime CreatedOn { get; set; }
		public string CreatedBy { get; set; }		
		public DateTime ChangedOn { get; set; }
		public string ChangedBy { get; set; }
		}
}
