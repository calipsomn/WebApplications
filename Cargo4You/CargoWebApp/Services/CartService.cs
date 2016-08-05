using CargoWebApp.DAL;
using CargoWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoWebApp.Services
{
    public class CartService : IDisposable
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        public Cart GetBySessionId(string sessionId)
        {
            var cart = dbContext.Carts.
                Include("CartItems").
                Where(c => c.SessionId == sessionId).
                SingleOrDefault();

            cart = CreateCartIfItDoesntExist(sessionId, cart);

            return cart;
        }

        private Cart CreateCartIfItDoesntExist(string sessionId, Cart cart)
        {
            if (null == cart)
            {
                cart = new Cart
                {
                    SessionId = sessionId,
                    CartItems = new List<CartItem>()
                };
                dbContext.Carts.Add(cart);
                dbContext.SaveChanges();
            }

            return cart;
        }

        public Cart GetById(int id)
        {
            var cart = dbContext.Carts.
                Include("CartItems").
                Include("CartItems.Parcel").
                Where(c => c.Id == id).
                SingleOrDefault();

            if (null == cart)
                throw new System.Data.Entity.Core.ObjectNotFoundException
                    (string.Format("Unable to find cart with id {0}", id));

            return cart;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}