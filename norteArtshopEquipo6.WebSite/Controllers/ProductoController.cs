using norte.ArtshopEquipo6.Data.Services;
using norte.ArtshopEquipo6.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    public class ProductoController : Controller
    {
        internal static IProductoData db = new InMemoryProductoData();

        // GET: Producto
        public ActionResult Index()
        {
            var list = db.GetProductos();
            return View(list);
        }


        // GET: Producto/Create
        public ActionResult Create()
        {
            var Producto = new Producto();
            return View(Producto);
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(Producto prod)
        {
            try
            {
                // TODO: Add insert logic here
                bool resultado = false;
                resultado = db.AddProducto(prod);

                if (resultado)
                    return RedirectToAction("Index");
                else
                    return View(prod);
            }
            catch
            {
                return View(prod);
            }
        }










        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
