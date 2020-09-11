using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Imie")]
        [StringLength(30, ErrorMessage = "Imie nie moze miec wiecej niz 30 znakow")]
        [Required(ErrorMessage = "Imie jest wymagane")]
        public string PurchaserName { get; set; }

        [Display(Name = "Nazwisko")]
        [StringLength(30, ErrorMessage = "Nazwisko nie moze miec wiecej niz 30 znakow")]
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string PurchaserSurname { get; set; }

        [Display(Name = "Numer telefonu")]
        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        public string PurchaserPhone { get; set; }

        [Display(Name = "Adres zamieszkania")]
        [StringLength(100, ErrorMessage = "Adres nie moze miec wiecej niz 100 znakow")]
        [Required(ErrorMessage = "Adres jest wymagany")]
        public string PurchaserAdress { get; set; }

        [Display(Name = "Kod pocztowy")]
        [RegularExpression("[0-9]{2}-[0-9]{3}", ErrorMessage = "Kod jest w formacie XX-XXX")]
        [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
        public string PurchaserPostCode { get; set; }

        [Display(Name = "Adres E-mail")]
        [EmailAddress]
        public string PurchaserEmail { get; set; }

        [Display(Name="Komentarz")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [ScaffoldColumn(false)]
        public decimal OrderValue { get; set; }
    }
}