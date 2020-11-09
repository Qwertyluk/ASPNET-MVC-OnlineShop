using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.ViewModels
{
    public class OrderEmail : Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public OrderViewModel Order { get; set; }

    }
}