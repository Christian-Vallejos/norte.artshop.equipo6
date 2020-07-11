using Microsoft.AspNet.Identity;
using norte.ArtshopEquipo6.Data.Model;
using norte.ArtshopEquipo6.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    [Authorize]
    public class ArtistaController : BaseController
    {
        private BaseDataService<Artist> db = new BaseDataService<Artist>();


        public ArtistaController() {
            
        }
        public ActionResult Index()
        {
            var list = db.Get();
            return View(list);
        }


        public ActionResult Create()
        {
            var model = new Artist();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Artist art)
        {
            bool resultado = false;
           
            art.ChangedBy = User.Identity.GetUserName();
            art.CreatedBy = User.Identity.GetUserName();
            art.CreatedOn = DateTime.Now;
            art.ChangedOn = DateTime.Now;
          
            
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