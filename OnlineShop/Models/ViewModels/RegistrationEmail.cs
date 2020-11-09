using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models.ViewModels
{
    public class RegistrationEmail : Email
    {
        public string To { get; set; }

        public string From { get; set; }

        public string Username { get; set; }

        public User User { get; set; }
    }
}