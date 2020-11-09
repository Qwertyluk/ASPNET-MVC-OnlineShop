using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OnlineShop.App_Start;
using OnlineShop.DAL;
using OnlineShop.Infrastructure.Cart;
using OnlineShop.Infrastructure.Email;
using OnlineShop.Infrastructure.SessionProvider;
using OnlineShop.Models;
using OnlineShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        readonly CartManager cartManager;
        private ApplicationUserManager _userManager;

        public CartController()
        {
            this.cartManager = new CartManager(new DefaultSessionProvider(), new ShopContext());
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
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

        [Authorize]
        public async Task<ActionResult> CreateOrder()
        {
            //Get user id and data then push them to the view
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            OrderViewModel model = new OrderViewModel()
            {
                PurchaserName = user.User.Name,
                PurchaserSurname = user.User.Surname,
                PurchaserPhone = user.PhoneNumber,
                PurchaserAdress = user.User.Adress,
                PurchaserPostCode = user.User.PostCode,
                PurchaserEmail = user.Email,
                OrderValue = cartManager.GetOrderValue()
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ConfirmOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (cartManager.CreateOrder(model, User.Identity.GetUserId()))
                {
                    ViewBag.Message = "Twoje zamówienie zostało przyjęte.";

                    //Send email confirmation
                    EmailSender.GetEmailSender.ConfirmOrder(model);

                    cartManager.Clear();
                }
                else
                    ViewBag.Message = "Nie udało się przyjąć twojego zamówienia.";
            }
            else
                return View("CreateOrder", model);

            return View();
        }
    }
}