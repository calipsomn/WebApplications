using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cargo4You.DTO
{
    public class ParcelDTO
    {
        public int Id { get; set; }
        
        public double Weight { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Depth { get; set; }

        public double Price { get; set; }

        public bool Fragile { get; set; }

        public bool Hazardous { get; set; }

        public bool Perishable { get; set; }
    }
}