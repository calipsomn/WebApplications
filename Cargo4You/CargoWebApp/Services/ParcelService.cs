using CargoWebApp.DAL;
using CargoWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoWebApp.Services
{
    public class ParcelService : IDisposable
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        public List<Parcel> GetByUserlId(int userId)
        {
            return dbContext.Parcels.
                Include("User").
                Where(p => p.UserId == userId).
                ToList();
        }

        public Parcel GetById(int id)
        {
            var parcel = dbContext.Parcels.
                Include("User").
                Where(b => b.Id == id).
                SingleOrDefault();

            if (null == parcel)
                throw new System.Data.Entity.Core.ObjectNotFoundException
                    (string.Format("Unable to find book with id {0}", id));

            return parcel;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}