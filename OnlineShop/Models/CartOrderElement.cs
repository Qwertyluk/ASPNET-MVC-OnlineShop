using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class CartOrderElement
    {
        public int CartOrderElementId { get; set; }

        public Product ProductElement { get; set; }

        public int Amount { get; set; }
    }
}