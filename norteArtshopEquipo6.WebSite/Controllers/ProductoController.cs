using norte.ArtshopEquipo6.Data.Services;
using norte.ArtshopEquipo6.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    public class ProductoController : BaseControllerBorrar
    {
        private BaseDataService<Product> db = new BaseDataService<Product>();
        private BaseDataService<Artist> dbArtist = new BaseDataService<Artist>();

        // GET: Producto
        public ActionResult Index()


       {
            List<SelectListItem> lst = new List<SelectListItem>();

            dbArtist.Get().ForEach(a =>
             lst.Add(new SelectListItem() { Text = a.FullName, Value = a.Id.ToString() }));

            ViewBag.artistas = lst;
            var list = db.Get();
            return View(list);
        }


        // GET: Producto/Create
        public ActionResult Create()
        {
            var Producto = new Product();
            List<SelectListItem> lst = new List<SelectListItem>();

            dbArtist.Get().ForEach(a =>
             lst.Add(new SelectListItem() { Text = a.FullName, Value = a.Id.ToString() }));
            ViewBag.artistas = lst;
           
            return View(Producto);
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(Product prod, FormCollection form)
                  {
            try
            {
                bool resultado = false;
                prod.ChangedBy = User.Identity.GetUserName();
                prod.CreatedBy = User.Identity.GetUserName();
                prod.CreatedOn = DateTime.Now;
                prod.ChangedOn = DateTime.Now;
                prod.ArtistId = 29;
  
                CheckAuditPattern(prod, false);

                if (ModelState.IsValid)
                    resultado = db.Create(prod);
                else
                    return View(prod);

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
