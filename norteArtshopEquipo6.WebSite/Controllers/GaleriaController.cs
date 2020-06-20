using norte.ArtshopEquipo6.Data.Model;
using norte.ArtshopEquipo6.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    public class GaleriaController : Controller
    {
        // GET: Galeria

        internal static IProductoData db = new InMemoryProductoData();

        public ActionResult Index()
        {
            var list = db.GetProductos();
            return View(list);
        }
    }
}