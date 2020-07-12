using norte.ArtshopEquipo6.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    public class HomeController : BaseController
         

    {
        protected new CartController cartController = new CartController();
        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                
               cartController.ConfirmarCarritoCreado();

                decimal monto;
                int cant;
                this.cartController.ObtenerInformacion( out cant, out monto);

                ViewBag.cantidad = cant;
                ViewBag.monto = monto;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}