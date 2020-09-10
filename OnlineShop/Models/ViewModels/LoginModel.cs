using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nazwa uzytkownika jest wymagana")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Haslo jest wymagane")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Zapamietaj mnie")]
        public bool Remember { get; set; }
    }
}