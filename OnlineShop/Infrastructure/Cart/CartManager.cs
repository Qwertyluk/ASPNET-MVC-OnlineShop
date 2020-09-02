using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Infrastructure.SessionProvider;
using OnlineShop.DAL;

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

        public List<OrderElement> GetCart()
        {
            List<OrderElement> cartElements;

            if ((cartElements = session.Get<List<OrderElement>>(DefaultSessionProvider.CartElementsSessionName)) != null)
                return cartElements;
            else
                return new List<OrderElement>();
        }

        public void Add(int id)
        {
            List<OrderElement> cartElements = GetCart();
            OrderElement element;

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
                    element = new OrderElement()
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
            List<OrderElement> cartElements = GetCart();
            OrderElement element;

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

        void Clean()
        {
            session.Set<List<OrderElement>>(DefaultSessionProvider.CartElementsSessionName, null);
        }

        public decimal GetOrderValue()
        {
            decimal sum = 0M;

            GetCart().ForEach(e => sum += e.ProductElement.Price * e.Amount);

            return sum;
        }

        void CreateOrder()
        {
            Order newOrder = new Order()
            {
                OrderDate = DateTime.Now,
                StateOfOrder = OrderState.NotStarted,
                Value = GetOrderValue()
            };

            //fill rest of fields and add to database
        }

        public int GetAmountElementsInCart()
        {
            int sum = 0;

            GetCart().ForEach(e => sum += e.Amount);

            return sum;
        }
    }
}