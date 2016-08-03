using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cargo4You.DTO
{
    public class ParcelDTO
    {
        public int Id { get; set; }

        public double Dinensions { get; set; }
        
        public double Weight { get; set; }

        public double Price { get; set; }

        public bool Fragile { get; set; }
    }
}