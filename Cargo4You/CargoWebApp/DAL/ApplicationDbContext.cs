using CargoWebApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CargoWebApp.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public System.Data.Entity.DbSet<CargoWebApp.ViewModels.CartViewModel> CartViewModels { get; set; }

        public System.Data.Entity.DbSet<CargoWebApp.ViewModels.ParcelViewModel> ParcelViewModels { get; set; }
    }
}