using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        public bool IsSold { get; set; }

        [ScaffoldColumn(false)]
        public bool IsOnSale { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AddTime { get; set; }

        [ScaffoldColumn(false)]
        public string ImageName { get; set; }


        public virtual Category ProductCategory { get; set; }
    }
}