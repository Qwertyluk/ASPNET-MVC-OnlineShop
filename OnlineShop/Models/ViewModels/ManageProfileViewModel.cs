using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.ViewModels
{
    public class ManageProfileViewModel
    {
        public ManageProfile ManageProfile { get; set; }
        public ManagePassword ManagePassword { get; set; }
    }

    public class ManageProfile
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

        [Display(Name = "Adres E-mail")]
        [EmailAddress]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Email { get; set; }

        [Display(Name = "Numer telefonu")]
        public string Phone { get; set; }

        [ScaffoldColumn(false)]
        public bool? ErrorOccured { get; set; }
    }

    public class ManagePassword
    {
        [Required(ErrorMessage = "Aktualne hasło jest wymagane")]
        [Display(Name = "Aktualne hasło")]
        [StringLength(30, ErrorMessage = "Hasło nie może mieć więcej niż 30 znaków")]
        [DataType(DataType.Password)]
        public string ActualPassword { get; set; }

        [Required(ErrorMessage = "Nowe hasło jest wymagane")]
        [Display(Name = "Nowe hasło")]
        [StringLength(30, ErrorMessage = "Hasło nie może mieć więcej niż 30 znaków")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Nieprawidlowe haslo")]
        [Display(Name = "Potwierdź nowe hasło")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }

        [ScaffoldColumn(false)]
        public bool? ErrorOccured { get; set; }
    }
}