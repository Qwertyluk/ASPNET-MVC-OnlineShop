using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class HomeIndexModel
    {
        public IEnumerable <Product> NewProducts { get; set; }
        public IEnumerable <Product> OnSaleProducts { get; set; }

        public IEnumerable <Category> ExtantCategories { get; set; }
    }
}