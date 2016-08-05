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

        public virtual Cart Cart { get; set; }
    }
}