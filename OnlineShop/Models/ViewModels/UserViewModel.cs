using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Uzytkownik")]
        [StringLength(30, ErrorMessage = "Nazwa nie moze miec wiecej niz 30 znakow")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Haslo")]
        [StringLength(30, ErrorMessage = "Haslo nie moze miec wiecej niz 30 znakow")]
        [DataType(DataType.Password)]
        //Later add regular expression for require special chars and at least one number
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = ("Nieprawidlowe haslo"))]
        [Display(Name = "Potwierdz haslo")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public User User { get; set; }
    }
}