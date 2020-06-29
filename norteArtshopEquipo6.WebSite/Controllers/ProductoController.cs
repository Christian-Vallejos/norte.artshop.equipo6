using norte.ArtshopEquipo6.Data.Services;
using norte.ArtshopEquipo6.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;

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

            ViewBag.Artistas =  new SelectList(dbArtist.Get(), "Id", "FullName");
            return View(Producto);
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(Product prod, FormCollection form)
                  {
            try
            {
                bool resultado = false;

                //Este metodo llena los campos de Createdon/changedby....
                CheckAuditPattern(prod, false);

                if (ModelState.IsValid)
                {
                    resultado = db.Create(prod);

                    if (resultado)
                        return RedirectToAction("Index");
                    else
                        return View(prod);
                }


                ViewBag.Artistas = new SelectList(dbArtist.Get(), "Id", "FullName",prod.ArtistId);
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
            Product p = db.GetById(id);
            if (p == null)
                return HttpNotFound();


            return View(p);
        }



        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = db.GetById(id);
            if (p == null)
                return HttpNotFound();

            ViewBag.Artistas = new SelectList(dbArtist.Get(), "Id", "FullName");
            return View(p);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                bool resultado = false;

                if (ModelState.IsValid)
                { 
                    resultado = db.Update(product);
                
                    if(resultado)
                        return RedirectToAction("Index");
                }


                ViewBag.Artistas = new SelectList(dbArtist.Get(), "Id", "FullName",product.ArtistId);
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            Product p = db.GetById(id);
            if (p == null)
                return HttpNotFound();

            return View(p);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            try
            {
                bool resultado = db.Delete(product);

                if (resultado)
                    return RedirectToAction("Index");

                ViewBag.MessageDanger = "Error al intentar borrar el producto, intente mas tarde.";
                return View(product);
            }
            catch
            {
                return View();
            }
        }
    }
}
