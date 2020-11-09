using OnlineShop.Models;
using OnlineShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Infrastructure.Email
{
    sealed public class EmailSender
    {
        private static EmailSender emailSender;
        private static readonly object lock_obj = new object();
        private string Sender { get; set; }


        private EmailSender() { }

        public static EmailSender GetEmailSender
        {
            get
            {
                if(emailSender == null)
                {
                    lock (lock_obj)
                    {
                        if (emailSender == null)
                            emailSender = new EmailSender();
                    }
                }
                return emailSender;
            }
        }

        public static void Initialize(string sender)
        {
            GetEmailSender.Sender = sender;
        }

        public void ConfirmRegistration(ApplicationUser user)
        {
            var email = new RegistrationEmail()
            {
                To = user.Email,
                From = Sender,
                Username = user.UserName,
                User = user.User
            };
            email.Send();
        }

        public void ConfirmOrder(OrderViewModel order)
        {
            var email = new OrderEmail()
            {
                To = order.PurchaserEmail,
                From = Sender,
                Order = order
            };
            email.Send();
        }
    }
}