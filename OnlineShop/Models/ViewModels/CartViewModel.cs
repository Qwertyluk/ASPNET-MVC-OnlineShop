using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartOrderElement> OrderElements { get; set; }

        public decimal OrderValue { get; set; }
    }
}