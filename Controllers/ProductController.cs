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
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowInformation(int id)
        {
            ShopContext shopContext = new ShopContext();

            return View(shopContext.Products.Where(p => p.ProductId == id).First());
        }
    }
}