using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string PurchaserName { get; set; }
        public string PurchaserSurname { get; set; }
        public string PurchaserStreet { get; set; }
        public string PurchaserCity { get; set; }
        public string PurchaserPhoneNumber { get; set; }
        public string PurchaserEmail { get; set; }
        public string Comment { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderState StateOfOrder { get; set; }
        public decimal Value { get; set; }
    }

    public enum OrderState
    {
        NotStarted,
        InProgress,
        Ended
    }
}