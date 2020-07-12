using norte.ArtshopEquipo6.Data.Model;
using norte.ArtshopEquipo6.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Web.UI;

namespace norteArtshopEquipo6.WebSite.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private static  ArtShopDbContext db = new ArtShopDbContext();


        public Cart GetCart()
        {
            Cart cart =null;

            var idUser = ClaimsPrincipal.Current.Identities.First().Claims.ToList()[0].Value;
            cart = db.Cart.Where(x => x.UserId == idUser).FirstOrDefault();

            var items = db.CartItem.Where(x => x.CartId == cart.Id).ToList();
            if (items.Count > 0)
                cart.Items = items;

            return cart;
        }

        public void ObtenerInformacion(out int cantidad,out decimal monto)
        {
            cantidad = -1;
            monto = -1;
            var UserId = ClaimsPrincipal.Current.Identities.First().Claims.ToList()[0].Value;

            var cartItems = db.CartItem.Where(x => x.Cart.UserId == UserId).ToList();

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
            bool creado = db.Cart.Where(x => x.UserId == userId).Count() >0;

            if (!creado)
            {
                Cart carrito = new Cart();
                carrito.UserId = userId;
                carrito.CartDate = DateTime.Now;
                carrito.CreatedOn = DateTime.Now;
                carrito.CreatedBy = userId;
                db.Cart.Add(carrito);
                //db.SaveChanges();

            }
        }


    }
}