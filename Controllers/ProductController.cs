using OnlineShop.DAL;
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
            //shopContext = new ShopContext();

            return View(shopContext.Products.Where(p => p.ProductId == id).First());
        }

        public ActionResult DisplayProductsWithCategory(int id)
        {
            //shopContext = new ShopContext();

            return View(shopContext.Products.Where(p => p.ProductCategory.CategoryId == id));
        }

        [ChildActionOnly]
        public ActionResult DisplayVerticalCategoryList()
        {
            //shopContext = new ShopContext();

            return View("_DisplayVerticalCategoryList", shopContext.Categories);
        }
    }
}