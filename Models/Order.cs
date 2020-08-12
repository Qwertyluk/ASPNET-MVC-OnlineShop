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
        [Required(ErrorMessage = "Purchaser name is required.")]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string PurchaserName { get; set; }
        [Required(ErrorMessage = "Purchaser surname is required.")]
        [StringLength(50)]
        [Display(Name = "Surname")]
        public string PurchaserSurname { get; set; }
        [Required(ErrorMessage = "Purchaser full address is required.")]
        [StringLength(50)]
        [Display(Name = "Street")]
        public string PurchaserStreet { get; set; }
        [Required(ErrorMessage = "Purchaser full address is required.")]
        [StringLength(50)]
        [Display(Name = "City")]
        public string PurchaserCity { get; set; }
        [Required(ErrorMessage = "Purchaser phone number is required.")]
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
    }

    public enum OrderState
    {
        NotStarted,
        InProgress,
        Ended
    }
}