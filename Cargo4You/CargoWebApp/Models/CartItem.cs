using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoWebApp.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ParcelId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Parcel Parcel { get; set; }
    }
}