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

        public Cart GetByUserName(string userName)
        {          

            var cart = CreateCartIfItDoesntExist(userName);

            return cart;
        }

        private Cart CreateCartIfItDoesntExist(string userName)
        {
            var cart = dbContext.Carts.
               Include("CartItems").
               Where(c => c.UserName == userName).
               SingleOrDefault();

            if (cart == null)
            {
                cart = new Cart
                {
                    UserName = userName,
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