using norte.ArtshopEquipo6.Data.Services;
using norte.ArtshopEquipo6.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;
using System.IO;
using WebGrease;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    [Authorize]
    public class ProductoController : BaseController
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
        public ActionResult Create(Product prod,  HttpPostedFileBase file )
                  {
            try
            {
               if (file != null & file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("/content/products"), filename);
                    //valido si existe el archivo para no pisarlo
                    Boolean existe = System.IO.File.Exists(path);
                    while (existe)
                    {
                        //Si existe el archivo genero un UUID y grabo el archivo con otro nombre
                        //Lo meti dentro de un while por si se da una de las infimas posibilidades de que se repita un nombre. 
                        string newFilename = Guid.NewGuid() + filename;
                        path = Path.Combine(Server.MapPath("/content/products"), newFilename);
                        existe = System.IO.File.Exists(path);
                    }
                    file.SaveAs(path);
                    //Transformo el full path en path relativo (sino no funciona el mostrar imagen)
                    string temporalPath = "\\content\\" + path.Split(new string[] { "content" }, StringSplitOptions.None)[1];
                    prod.Image = temporalPath;
                }
                bool resultado = false;

                //Este metodo llena los campos de Createdon/changedby....
                CheckAuditPattern(prod, false);

                if (ModelState.IsValid)
                {
                    resultado = db.Create(prod);

                    if (resultado)
                        return RedirectToAction("Index");
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
