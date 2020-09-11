using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace OnlineShop.Models
{
    public class User
    {
        [Display(Name = "Imie")]
        [StringLength(30, ErrorMessage = "Imie nie moze miec wiecej niz 30 znakow")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [StringLength(30, ErrorMessage = "Nazwisko nie moze miec wiecej niz 30 znakow")]
        public string Surname { get; set; }

        [Display(Name = "Adres zamieszkania")]
        [StringLength(100, ErrorMessage = "Adres nie moze miec wiecej niz 100 znakow")]
        public string Adress { get; set; }

        [Display(Name = "Kod pocztowy")]
        [RegularExpression("[0-9]{2}-[0-9]{3}", ErrorMessage = "Kod jest w formacie XX-XXX")]
        public string PostCode { get; set; }
    }
}