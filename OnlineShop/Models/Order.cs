using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Imie jest wymagane")]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string PurchaserName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [StringLength(50)]
        [Display(Name = "Surname")]
        public string PurchaserSurname { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany")]
        [StringLength(50)]
        [Display(Name = "Street")]
        public string PurchaserAdress { get; set; }

        [Required(ErrorMessage = "Kod pocztoy jest wymagany")]
        [Display(Name = "Kod pocztowy")]
        [RegularExpression("[0-9]{2}-[0-9]{3}", ErrorMessage = "Kod jest w formacie XX-XXX")]
        public string PurchaserPostCode { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [Display(Name = "Phone number")]
        //Maybe in future phone attribute should be replace with a regular expression
        [Phone]
        public string PurchaserPhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress]
        public string PurchaserEmail { get; set; }

        public string Comment { get; set; }

        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public OrderState StateOfOrder { get; set; }

        [ScaffoldColumn(false)]
        public decimal Value { get; set; }

        public List<OrderElement> OrderElements { get; set; }
    }

    public enum OrderState
    {
        NotStarted,
        InProgress,
        Ended
    }
}