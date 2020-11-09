using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OnlineShop.App_Start;
using OnlineShop.DAL;
using OnlineShop.Models;
using OnlineShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ManageController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly ShopContext context = new ShopContext();

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

        // GET: Manage
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            return View(new ManageProfileViewModel()
            {
                ManageProfile = new ManageProfile()
                {
                    Name = user.User.Name,
                    Surname = user.User.Surname,
                    Adress = user.User.Adress,
                    PostCode = user.User.PostCode,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    ErrorOccured = null
                },
                ManagePassword = new ManagePassword()
            });
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateProfile(ManageProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.User.Name = model.ManageProfile.Name;
                user.User.Surname = model.ManageProfile.Surname;
                user.User.Adress = model.ManageProfile.Adress;
                user.User.PostCode = model.ManageProfile.PostCode;
                user.Email = model.ManageProfile.Email;
                user.PhoneNumber = model.ManageProfile.Phone;
                var result = await UserManager.UpdateAsync(user);

                model.ManageProfile.ErrorOccured = !result.Succeeded;

                if (model.ManageProfile.ErrorOccured.Value)
                    AddErrors(result);
            }

            return View("Index", model);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdatePassword(ManagePassword ManagePassword)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            ManageProfileViewModel modelReturn = new ManageProfileViewModel()
            {
                ManageProfile = new ManageProfile()
                {
                    Name = user.User.Name,
                    Surname = user.User.Surname,
                    Adress = user.User.Adress,
                    PostCode = user.User.PostCode,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    ErrorOccured = null
                },
                ManagePassword = ManagePassword
            };

            if (ModelState.IsValid)
            {
                var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), ManagePassword.ActualPassword, ManagePassword.NewPassword);
                modelReturn.ManagePassword.ErrorOccured = !result.Succeeded;
                if (modelReturn.ManagePassword.ErrorOccured.Value)
                    AddErrors(result);
            }

            return View("Index", modelReturn);
        }

        [Authorize]
        [HttpGet]
        public ActionResult DisplayOrders()
        {
            IEnumerable<Order> orders;

            ViewBag.IsAdmin = User.IsInRole("Admin");

            if (ViewBag.IsAdmin)
                orders = context.Orders.Include("OrderElements").OrderByDescending(o => o.OrderDate);
            else
            {
                string userId = User.Identity.GetUserId();
                orders = context.Orders.Where(o => o.UserId == userId).OrderByDescending(o => o.OrderDate).Include("OrderElements");
            }


            return View(orders);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeOrderState(Order order)
        {
            context.Orders.Find(order.OrderId).StateOfOrder = order.StateOfOrder;
            context.SaveChanges();

            return RedirectToAction("DisplayOrders");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddProduct()
        {
            ProductAdditionViewModel model = new ProductAdditionViewModel()
            {
                Product = new Product(),
                Categories = context.Categories
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(Product product, HttpPostedFileBase file)
        {
            ProductAdditionViewModel model = new ProductAdditionViewModel()
            {
                Categories = context.Categories
            };

            if (ModelState.IsValid)
            {
                if (file is object && file.ContentLength > 0)
                {
                    product.AddTime = DateTime.Now;
                    product.ImageName = Guid.NewGuid() + file.FileName;
                    product.Price = Math.Round(product.Price, 2);

                    //Save the file
                    file.SaveAs(Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageProductCatalogPath"]), product.ImageName));

                    //Add a product to the database
                    context.Entry(product).State = EntityState.Added;
                    context.SaveChanges();

                    model.Product = new Product();
                    model.AdditionSucceed = true;

                    ModelState.Clear();

                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("FileError", "Nie załadowano pliku");
                }
            }

            model.Product = product;
            model.AdditionSucceed = false;

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditProduct(int productId)
        {
            ProductAdditionViewModel model = new ProductAdditionViewModel()
            {
                Product = context.Products.Find(productId),
                Categories = context.Categories
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file is object && file.ContentLength > 0)
                {
                    //Delete existing product image
                    if (System.IO.File.Exists(Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageProductCatalogPath"]), product.ImageName)))
                        System.IO.File.Delete(Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageProductCatalogPath"]), product.ImageName));
                    
                    product.ImageName = Guid.NewGuid() + file.FileName;
                    //Save the file as a new product image
                    file.SaveAs(Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageProductCatalogPath"]), product.ImageName));
                }

                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("ShowInformation", "Product", new { id = product.ProductId });
            }

            //Return to the view with the same product information
            ProductAdditionViewModel model = new ProductAdditionViewModel()
            {
                Product = product,
                Categories = context.Categories,
                AdditionSucceed = false
            };

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int productId)
        {
            return View(context.Products.Find(productId));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductFromDB(int productId)
        {
            Product deleteProduct = context.Products.Find(productId);

            context.Entry(deleteProduct).State = EntityState.Deleted;
            context.SaveChanges();

            //Delete existing product image
            if (System.IO.File.Exists(Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageProductCatalogPath"]), deleteProduct.ImageName)))
                System.IO.File.Delete(Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageProductCatalogPath"]), deleteProduct.ImageName));

            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("Validation", error);
            }
        }
    }
}