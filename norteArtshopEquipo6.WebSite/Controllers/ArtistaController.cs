using norte.ArtshopEquipo6.Data.Model;
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

        internal static IArtistaData db = new InMemoryArtistaData();

        public ArtistaController() {
            
        }
        public ActionResult Index()
        {
            var list = db.GetArtistas();
            return View(list);
        }



        public ActionResult Create()
        {
            var model = new Artista();

            return View(model);
        }



            [HttpPost]
        public ActionResult Create(Artista art)
        {
            bool resultado = false;
            resultado = db.AddArtista(art);

            if(resultado)
                return RedirectToAction("Index");
            else
                return View(art);
        }


    }
}