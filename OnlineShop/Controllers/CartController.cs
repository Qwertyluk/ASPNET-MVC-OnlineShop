using OnlineShop.DAL;
using OnlineShop.Infrastructure.Cart;
using OnlineShop.Infrastructure.SessionProvider;
using OnlineShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        readonly CartManager cartManager;

        public CartController()
        {
            this.cartManager = new CartManager(new DefaultSessionProvider(), new ShopContext());
        }

        // GET: Cart
        public ActionResult Index()
        {
            CartViewModel viewModel = new CartViewModel() {
                OrderElements = cartManager.GetCart(),
                OrderValue = cartManager.GetOrderValue()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            cartManager.Add(id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            cartManager.Remove(id);

            return RedirectToAction("Index");
        }

        public ActionResult GetAmountElementsInCart()
        {
            return Content(cartManager.GetAmountElementsInCart().ToString());
        }
    }
}