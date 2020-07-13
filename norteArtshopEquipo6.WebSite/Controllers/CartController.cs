using norte.ArtshopEquipo6.Data.Model;
using norte.ArtshopEquipo6.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Web.UI;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    [Authorize]
    public class CartController : BaseController
    {
        private  ArtShopDbContext db = new ArtShopDbContext();
   


        public ActionResult Index()
        {
            var list = GetCart();
            return View(list);
        }

        public Cart GetCart()
        {
            Cart cart =null;

            var idUser = ClaimsPrincipal.Current.Identities.First().Claims.ToList()[0].Value;
            cart = db.Cart.Where(x => x.UserId == idUser).Where(x=> x.Comprado == "false").FirstOrDefault();

            var items = db.CartItem.Where(x => x.CartId == cart.Id).Where(x => x.Cart.Comprado == "false").ToList();
            if (items.Count > 0)
                cart.Items = items;

            return cart;
        }

        public void ObtenerInformacion(out int cantidad,out decimal monto)
        {
            cantidad = -1;
            monto = -1;
            var UserId = ClaimsPrincipal.Current.Identities.First().Claims.ToList()[0].Value;

            var cartItems = db.CartItem.Where(x => x.Cart.UserId == UserId).Where(x => x.Cart.Comprado == "false").ToList();

            if (cartItems.Count > 0)
            {
                cantidad = 0;
                monto = 0;
                foreach (CartItem ci in cartItems)
                {
                    cantidad += ci.Quantity;
                    monto += ci.Price * ci.Quantity;
                }            
            }

        }


        public void ConfirmarCarritoCreado()
        {
            var userId = ClaimsPrincipal.Current.Identities.First().Claims.ToList()[0].Value;
            bool creado = db.Cart.Where(x => x.UserId == userId).Where(x=> x.Comprado == "false").Count() >0;

            if (!creado)
            {
                Cart carrito = new Cart();
                carrito.UserId = userId;
                carrito.CartDate = DateTime.Now;
                carrito.Comprado = "false";
                CheckAuditPattern(carrito, true);
                db.Cart.Add(carrito);
                db.SaveChanges();


            }
        }

        public ActionResult ConfirmarCompraCarrito()
        {
            decimal monto;
            int cant;
            ObtenerInformacion(out cant, out monto);
            ViewBag.cantidad = cant;
            ViewBag.monto = monto;

               //  return RedirectToAction("CompraConfirmada");
            return View();
        }

        public ActionResult CompraConfirmada()
        {
            //Confirmar la compra
            var cart = GetCart();
            cart.Comprado = "true";
            CheckAuditPattern(cart, false);
            db.Cart.AddOrUpdate(cart);
            db.SaveChanges();

            //guardar carrito

            //mostrar mensaje
            ViewBag.NumeroCompra = cart.Id;
            return View();
                
       }

        public ActionResult ListadoCompras()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                return View(db.CartItem.Select(x => x).Include(x=> x.Cart).Where(x=> x.Cart.Comprado == "true"));

            }
            else {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}