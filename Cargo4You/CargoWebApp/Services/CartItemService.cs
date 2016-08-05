using CargoWebApp.DAL;
using CargoWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CargoWebApp.Services
{
    public class CartItemService : IDisposable
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        public CartItem GetByCartIdAndParcelId(int cartId, int parcelId)
        {
            return dbContext.CartItems.SingleOrDefault(ci => ci.CartId == cartId && ci.ParcelId == parcelId);
        }

        public CartItem AddToCart(CartItem cartItem)
        {
            var existingCartItem = GetByCartIdAndParcelId(cartItem.CartId, cartItem.ParcelId);

            if (null == existingCartItem)
            {
                dbContext.Entry(cartItem).State = EntityState.Added;
                existingCartItem = cartItem;
            }
            else
            {
                existingCartItem.Quantity += cartItem.Quantity;
            }

            dbContext.SaveChanges();

            return existingCartItem;
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            dbContext.Entry(cartItem).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            dbContext.Entry(cartItem).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}