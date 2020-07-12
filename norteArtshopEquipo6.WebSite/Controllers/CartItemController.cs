using norte.ArtshopEquipo6.Data.Model;
using norte.ArtshopEquipo6.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    public class CartItemController : BaseController
    {
        protected CartController cartController = new CartController();
        ArtShopDbContext db = new ArtShopDbContext();


        // GET: CartItem
        public ActionResult Index()
        {
            var cart = cartController.GetCart();
            if (this.User.Identity.IsAuthenticated)
            {

                cartController.ConfirmarCarritoCreado();

                decimal monto;
                int cant;
                this.cartController.ObtenerInformacion(out cant, out monto);

                ViewBag.cantidad = cant;
                ViewBag.monto = monto;
            }
            return View(db.CartItem.Select(x => x).Include(x => x.Cart).Include(x => x.Product).Where(x => x.CartId == cart.Id));
        }

        // GET: CartItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public bool Create(CartItem cartItem)
        {
            try
            {

                Cart cart = this.cartController.GetCart();
                cartItem.CartId = cart.Id;
                if (cart.Items != null)
                    if (cart.Items.Where(x => x.ProductId == cartItem.ProductId).Count() > 0)
                    {
                        var CartItemInDB = cart.Items.Where(x => x.ProductId == cartItem.ProductId).First();

                        cartItem.Quantity += CartItemInDB.Quantity;

                        cartItem.CreatedOn = CartItemInDB.CreatedOn;
                        cartItem.Id = CartItemInDB.Id;
                    }
                db.CartItem.AddOrUpdate(cartItem);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                var x = e;
                Debug.WriteLine(x);
                return false;
            }
        }
        public ActionResult Remove1(int id)
        {
            try
            {
                var CarItemDB = db.CartItem.Where(x => x.Id == id).FirstOrDefault();

                if (CarItemDB.Quantity > 1)
                {
                    CarItemDB.Quantity -= 1;
                    db.CartItem.AddOrUpdate(CarItemDB);
                }
                else
                {
                    db.CartItem.Remove(CarItemDB);
                }


                db.SaveChanges();


                return RedirectToAction("Index");
            }




            catch (Exception e)
            {

                return RedirectToAction("Index");
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {

                var CarItemDB = db.CartItem.Where(x => x.Id == id).FirstOrDefault();

                db.CartItem.Remove(CarItemDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                //todo logguear error
                return RedirectToAction("Index");
            }
        }

        // GET: CartItem/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    CartItem p = db.CartItem.Where(x => x.Id == id).FirstOrDefault();
        //    if (p == null)
        //        return HttpNotFound();

        //    ViewBag.CartItem = p;
        //    return View(p);
        //    }

        public ActionResult Edit(CartItem item) {

            try
            {
                var CarItemDB = db.CartItem.Where(x => x.Id == item.Id).FirstOrDefault();

                if (item.Quantity > 0)
                {
                    CarItemDB.Quantity = item.Quantity;
                    db.CartItem.AddOrUpdate(CarItemDB);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            catch (Exception e)
            {
                //todo: loggear errores

                return RedirectToAction("Index");
            }


        }


        public ActionResult CambiarCantidad(int id, int qty)
        {
            try
            {
                var CarItemDB = db.CartItem.Where(x => x.Id == id).FirstOrDefault();

                if (qty > 0)
                {
                    CarItemDB.Quantity = qty;
                    db.CartItem.AddOrUpdate(CarItemDB);
                }
                   db.SaveChanges();
                return RedirectToAction("Index");
            }

            catch (Exception e)
            {
//todo: loggear errores
                return RedirectToAction("Index");
            }
        }

    }
}