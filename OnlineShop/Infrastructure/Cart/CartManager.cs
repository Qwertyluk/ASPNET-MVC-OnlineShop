using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Infrastructure.SessionProvider;
using OnlineShop.DAL;
using OnlineShop.Models.ViewModels;

namespace OnlineShop.Infrastructure.Cart
{
    public class CartManager
    {
        readonly ISessionProvider session;
        readonly ShopContext shopContext;

        public CartManager(ISessionProvider session, ShopContext shopContext)
        {
            this.session = session;
            this.shopContext = shopContext;
        }

        public List<CartOrderElement> GetCart()
        {
            List<CartOrderElement> cartElements;

            if ((cartElements = session.Get<List<CartOrderElement>>(DefaultSessionProvider.CartElementsSessionName)) != null)
                return cartElements;
            else
                return new List<CartOrderElement>();
        }

        public void Add(int id)
        {
            List<CartOrderElement> cartElements = GetCart();
            CartOrderElement element;

            if((element = cartElements.Find(c => c.ProductElement.ProductId == id)) != null)
            {
                //If order element already exists in the cart
                element.Amount++;
                //Refresh session with updated cart
                session.Set(DefaultSessionProvider.CartElementsSessionName, cartElements);
            }
            else
            {
                Product product;
                if((product = shopContext.Products.Where(p => p.ProductId == id).SingleOrDefault()) != null) { 
                    //If the added product exists in the database
                    element = new CartOrderElement()
                    {
                        ProductElement = product,
                        Amount = 1
                    };
                    //Add product to the cart
                    cartElements.Add(element);
                    //Refresh session with updated cart
                    session.Set(DefaultSessionProvider.CartElementsSessionName, cartElements);
                }
            }
        }

        public void Remove(int id)
        {
            List<CartOrderElement> cartElements = GetCart();
            CartOrderElement element;

            if ((element = cartElements.Find(c => c.ProductElement.ProductId == id)) != null)
            {
                if(element.Amount > 1)
                    //If there are more than one products just reduce their amount
                    element.Amount--;
                else { 
                    //If there is just one product remove it from the cart
                    cartElements.Remove(element);
                }
                session.Set(DefaultSessionProvider.CartElementsSessionName, cartElements);
            }
        }

        public void Clear()
        {
            session.Set<List<CartOrderElement>>(DefaultSessionProvider.CartElementsSessionName, null);
        }

        public decimal GetOrderValue()
        {
            decimal sum = 0M;

            GetCart().ForEach(e => sum += e.ProductElement.Price * e.Amount);

            return sum;
        }

        public bool CreateOrder(OrderViewModel model, string userId)
        {
            List<CartOrderElement> cartElements = GetCart();

            if(cartElements.Count > 0) {

                List<OrderElement> orderElements = new List<OrderElement>();

                foreach (var item in cartElements)
                {
                    OrderElement element = new OrderElement()
                    {
                        ProductId = item.ProductElement.ProductId,
                        Amount = item.Amount,
                        Value = item.ProductElement.Price * item.Amount
                    };

                    orderElements.Add(element);
                }

                Order newOrder = new Order()
                {
                    UserId = userId,
                    PurchaserName = model.PurchaserName,
                    PurchaserSurname = model.PurchaserSurname,
                    PurchaserAdress = model.PurchaserAdress,
                    PurchaserPostCode = model.PurchaserPostCode,
                    PurchaserPhoneNumber = model.PurchaserPhone,
                    PurchaserEmail = model.PurchaserEmail,
                    Comment = model.Comment,
                    OrderDate = DateTime.Now,
                    StateOfOrder = OrderState.New,
                    Value = GetOrderValue(),
                    OrderElements = orderElements
                };

                shopContext.Orders.Add(newOrder);
                shopContext.SaveChanges();

                return true;
            }

            return false;
        }

        public int GetAmountElementsInCart()
        {
            int sum = 0;

            GetCart().ForEach(e => sum += e.Amount);

            return sum;
        }
    }
}