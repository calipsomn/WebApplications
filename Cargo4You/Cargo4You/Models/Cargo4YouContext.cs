using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cargo4You.Models
{
    public class Cargo4YouContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Cargo4YouContext() : base("name=Cargo4YouContext")
        {
        }

        public System.Data.Entity.DbSet<Cargo4You.Models.Parcel> Parcels { get; set; }
    }
}
