using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class OrderElement
    {
        public Product ProductElement { get; set; }

        public int Amount { get; set; }
    }
}