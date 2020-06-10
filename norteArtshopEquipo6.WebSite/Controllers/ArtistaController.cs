using norte.ArtshopEquipo6.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    public class ArtistaController : Controller
    {
        //get de artistas

        private IArtistaData db;

        public ArtistaController() {
            db = new InMemoryArtistaData();
        }
        public ActionResult Index()
        {
            var list = db.GetArtistas();
            return View(list);
        }
    }
}