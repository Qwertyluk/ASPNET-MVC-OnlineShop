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
            //ShopContext shopContext = new ShopContext();

            //shopContext.Categories.Add(new Category() { CategoryId = 1, Description = "test", Name = "nazwa" });
            //shopContext.SaveChanges();

            return View();
        }
    }
}