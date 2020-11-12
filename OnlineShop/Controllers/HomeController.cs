using OnlineShop.DAL;
using OnlineShop.Infrastructure;
using OnlineShop.Infrastructure.CacheProvider;
using OnlineShop.Infrastructure.Email;
using OnlineShop.Models;
using OnlineShop.Models.ViewModels;
using Postal;
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
            DefaultCacheProvider cache = new DefaultCacheProvider();
            
            homeIndexModel.OnSaleProducts = shopContext.Products.Where(p => !p.IsSold && p.IsOnSale).OrderBy(p => Guid.NewGuid()).Take(3);
            homeIndexModel.NewProducts = shopContext.Products.Where(p => !p.IsSold).OrderByDescending(p => p.AddTime).Take(3);

            // Check if the Categories are in the cache
            if ((homeIndexModel.ExtantCategories = cache.Get<IEnumerable<Category>>(DefaultCacheProvider.CategoriesCacheName)) == null)
            { 
                // If not then download them from the database and cache them
                homeIndexModel.ExtantCategories = shopContext.Categories;
                cache.Set(DefaultCacheProvider.CategoriesCacheName, homeIndexModel.ExtantCategories, 3600);
            }

            return View(homeIndexModel);
        }

        public ActionResult StaticSites(string name)
        {
            return View(name);
        }
    }
}