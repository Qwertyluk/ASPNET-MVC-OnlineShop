using OnlineShop.DAL;
using OnlineShop.Infrastructure.CacheProvider;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        readonly ShopContext shopContext = new ShopContext();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowInformation(int id)
        {
            return View(shopContext.Products.Where(p => p.ProductId == id).First());
        }

        public ActionResult DisplayProductsWithCategory(int id)
        {
            return View(shopContext.Products.Where(p => p.ProductCategory.CategoryId == id));
        }

        [ChildActionOnly]
        public ActionResult DisplayVerticalCategoryList()
        {
            DefaultCacheProvider cache = new DefaultCacheProvider();
            IEnumerable<Category> categoryEnumerable;

            if((categoryEnumerable = cache.Get<IEnumerable<Category>>(DefaultCacheProvider.CategoriesCacheName).ToList()) != null)
                return View("_DisplayVerticalCategoryList", categoryEnumerable);
            else
            {
                categoryEnumerable = shopContext.Categories.ToList();
                cache.Set(DefaultCacheProvider.CategoriesCacheName, categoryEnumerable, 3600);
                return View("_DisplayVerticalCategoryList", categoryEnumerable);
            }

            /*if (cache.isSet(DefaultCacheProvider.CategoriesCacheName))
                return View("_DisplayVerticalCategoryList", cache.Get<IEnumerable<Category>>(DefaultCacheProvider.CategoriesCacheName)); 
            else
            {
                IEnumerable<Category> categories = shopContext.Categories;
                cache.Set(DefaultCacheProvider.CategoriesCacheName, categories, 3600);
                return View("_DisplayVerticalCategoryList", categories);
            }*/

        }
    }
}