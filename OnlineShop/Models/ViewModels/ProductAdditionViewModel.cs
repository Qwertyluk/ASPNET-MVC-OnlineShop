using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.ViewModels
{
    public class ProductAdditionViewModel
    {
        public Product Product { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public bool? AdditionSucceed { get; set; }
    }
}