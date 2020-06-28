using norte.ArtshopEquipo6.Data.Model;
using norte.ArtshopEquipo6.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    public class ArtistaController : BaseControllerBorrar
    {
        private BaseDataService<Artista> db = new BaseDataService<Artista>();


        public ArtistaController() {
            
        }
        public ActionResult Index()
        {
            var list = db.Get();
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

            CheckAuditPattern(art, false);

            if (ModelState.IsValid)
                resultado = db.Create(art);
            else
                return View(art);



            if(resultado)
                return RedirectToAction("Index");
            else
                return View(art);
        }


    }
}