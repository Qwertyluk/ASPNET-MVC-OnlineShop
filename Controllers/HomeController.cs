using OnlineShop.DAL;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ShopContext shopContext = new ShopContext();

            HomeIndexModel homeIndexModel = new HomeIndexModel();

            homeIndexModel.OnSaleProducts = shopContext.Products.Where(p => !p.IsSold && p.IsOnSale).OrderBy(p => Guid.NewGuid()).Take(3);
            homeIndexModel.NewProducts = shopContext.Products.Where(p => !p.IsSold).OrderByDescending(p => p.AddTime).Take(3);
            homeIndexModel.ExtantCategories = shopContext.Categories;

            return View(homeIndexModel);
        }

        public ActionResult StaticSites(string name)
        {
            return View(name);
        }
    }
}