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
        
        [ScaffoldColumn(false)]
        [Display(Name = "Kategoria")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana")]
        [StringLength(50)]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Marka")]
        [Required(ErrorMessage = "Marka produktu jest wymagana")]
        public string Brand { get; set; }

        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Cena produktu jest wymagana")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        public bool IsSold { get; set; }

        [Display(Name="Wyprzedaż")]
        public bool IsOnSale { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AddTime { get; set; }

        [ScaffoldColumn(false)]
        public string ImageName { get; set; }


        public virtual Category ProductCategory { get; set; }
    }
}