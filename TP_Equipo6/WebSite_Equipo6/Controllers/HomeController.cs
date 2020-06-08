using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite_Equipo6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Acerca de nosotros.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Datos de Contacto.";

            return View();
        }
        public ActionResult ListadoCuadros()
        {
            ViewBag.Message = "Listado de Cuadros Disponibles";

            return View();
        }

        public ActionResult AccesoAdministracion()
        {
            ViewBag.Message = "Acceso Administracion";

            return View();
        }
        public ActionResult RegistrarUsuario()
        {
            ViewBag.Message = "Registrar Usuario";

            return View();
        }
    }
}