using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cargo4You.Models
{
    public class Parcel
    {
        public int Id { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public double Depth { get; set; }

        public double Price { get; set; }

        public bool Fragile { get; set; }

        public bool Hazardous { get; set; }

        public bool Perishable { get; set; }
    }
}