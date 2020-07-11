using norte.ArtshopEquipo6.Data.Model;
using norte.ArtshopEquipo6.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    public class ShoppingCartController : BaseController
    {

        private ArtShopDbContext db = new ArtShopDbContext();
       // private BaseDataService<ShoppingCart> db = new BaseDataService<ShoppingCart>();



        // GET: ShoppingCart
        public ActionResult Index()
        {
           string userid = TryGetUserId();
            if (userid != "" || userid != null)
            {
                //Agregar en la BD un campo que sea un nvarchar, este va a contener ids de productos, separados por comas. Luego nosotros con esos datos cargados en el usuario
                // podemos cargar una lista de los productos que posea en el carrito el usuario en cuestion.
                

                return View();
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }


        /*
        // GET: ShoppingCart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingCart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShoppingCart/Edit/5
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

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShoppingCart/Delete/5
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
        */
    }
}
