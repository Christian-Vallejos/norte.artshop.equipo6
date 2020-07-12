using norte.ArtshopEquipo6.Data.Model;
using norte.ArtshopEquipo6.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    public class CartItemController : BaseController
    {
        ArtShopDbContext db = new ArtShopDbContext();


        // GET: CartItem
        public ActionResult Index()
        {
            db.CartItem.Select(x => x).Include(x => x.Cart);
            return View();
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
                if(cart.Items != null)
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
                return false;
            }
        }
         public bool Remove1(CartItem cartItem)
        {
            try
            {
                var CarItemDB = db.CartItem.Where(x => x.Id == cartItem.Id).FirstOrDefault();

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
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool Delete(CartItem cartItem)
        {
            try
            {
                db.CartItem.Remove(cartItem);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // GET: CartItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartItem/Edit/5
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

        // GET: CartItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartItem/Delete/5
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
